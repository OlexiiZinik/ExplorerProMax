using ExplorerProMax.Core.PathEntity;
using ExplorerProMax.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.FileSystem
{
    public class WindowsFileSystemManager : FileSystemManager
    {
        public WindowsFileSystemManager() { }

        public override List<IFileSystemEntity> ListDirectory(IListable directory)
        {
            var result = new List<IFileSystemEntity>();
            var files = Directory.GetFiles(directory.FullPath);
            var directoris = Directory.GetDirectories(directory.FullPath);
            result.Add(new ParentLink(directory));
            result.AddRange(directoris.Select((d) => new PathEntity.DirectoryEntity(d)));
            result.AddRange(files.Select((d) => new PathEntity.FileEntity(d)));
            return result;
        }
      
        public override List<DriveEntity> GetAllDisks()
        {
            var result = new List<DriveEntity>();
            result.AddRange(DriveInfo.GetDrives().Select((d) => new DriveEntity(d.Name)));
            return result;
        }
      
        public override IListable GetParent(IFileSystemEntity pathEntity)
        {
            var splitedPath = pathEntity.FullPath.Split(@"/\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (splitedPath.Length <= 1)
            {
                return null;
            }
            return new PathEntity.DirectoryEntity(string.Join(@"\", splitedPath.Take(splitedPath.Length - 1)) + @"\");
        }
       
        public override void MoveFiles(List<IFileSystemEntity> files, IListable destination)
        {
            foreach (var file in files)
            {
                try
                {
                    if (file is PathEntity.FileEntity)
                        MoveFile(file, destination);

                    else if (file is PathEntity.DirectoryEntity)
                        MoveDirectory(file, destination);
                }
                catch { }
            }
        }
       
        public override void MoveFile(IFileSystemEntity file, IListable destination)
        {
            if (!(file is PathEntity.FileEntity))
                return;

            string newFilePath = Path.Combine(destination.FullPath, (file as PathEntity.FileEntity).FullName);

            if (!File.Exists(newFilePath))
                File.Move(file.FullPath, newFilePath);
        }
        
        public override void MoveDirectory(IFileSystemEntity directory, IListable destination)
        {
            if (!(directory is PathEntity.DirectoryEntity))
                return;

            string newDirectoryPath = Path.Combine(destination.FullPath, (directory as PathEntity.DirectoryEntity).Name);
            if (!Directory.Exists(newDirectoryPath))
                Directory.Move(directory.FullPath, newDirectoryPath);

        }
        
        public override void CopyFiles(string[] files, IListable destination)
        {
            List<IFileSystemEntity> entities = new List<IFileSystemEntity>();
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    entities.Add(new PathEntity.FileEntity(file));
                }
                else if (Directory.Exists(file))
                {
                    entities.Add(new PathEntity.DirectoryEntity(file));
                }
            }
            CopyFiles(entities, destination);
        }
        
        public override void CopyFiles(List<IFileSystemEntity> files, IListable destination)
        {
            foreach (var file in files)
            {
                if (file is PathEntity.FileEntity)
                {
                    File.Copy(file.FullPath, Path.Combine(destination.FullPath, Path.GetFileName(file.FullPath)));

                }
                else if (file is PathEntity.DirectoryEntity)
                {
                    CopyDirectory(file.FullPath, Path.Combine(destination.FullPath, file.Name), true);
                }
            }
        }
        
        private void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        
        public override void MakeDirectory(IListable location, string name, FileAttributes fileAttributes)
        {
            string directory = Path.Combine(location.FullPath, name);
            if (File.Exists(directory))
                return;

            var di = Directory.CreateDirectory(directory);
            di.Attributes = fileAttributes;
        }
        
        public override void MakeFile(IListable location, string name, FileAttributes fileAttributes)
        {
            string filename = Path.Combine(location.FullPath, name);
            if (File.Exists(filename))
                return;

            using (File.Create(filename)) { }
            FileInfo fileInfo = new FileInfo(filename);
            fileInfo.Attributes = fileAttributes;
        }
        
        public override void RenameEntity(IFileSystemEntity entity, string name, FileAttributes fileAttributes)
        {
            string newPath = Path.Combine(entity.Parent.FullPath, name);
            if (entity is PathEntity.FileEntity)
            {
                File.Move((entity as PathEntity.FileEntity).FullPath, newPath);
                FileInfo fileInfo = new FileInfo(newPath);
                fileInfo.Attributes = fileAttributes;
            }
            else if (entity is PathEntity.DirectoryEntity)
            {
                Directory.Move((entity as PathEntity.DirectoryEntity).FullPath, newPath);
                DirectoryInfo directoryInfo = new DirectoryInfo(newPath);
                directoryInfo.Attributes = fileAttributes;
            }
        }
        
        public override void DeleteEntities(List<IFileSystemEntity> files)
        {
            foreach (IFileSystemEntity entity in files)
            {
                try
                {
                    if (entity is PathEntity.DirectoryEntity)
                        Directory.Delete(entity.FullPath);
                    else if (entity is PathEntity.FileEntity)
                        File.Delete(entity.FullPath);
                }
                catch { }
            }
        }
        
        public override List<IFileSystemEntity> Search(IListable location, string pattern, bool includeSubDirectories, bool strictSearch)
        {
            return GetFiles(location.FullPath, pattern, includeSubDirectories, strictSearch);
        }
        
        private List<IFileSystemEntity> GetFiles(string path, string pattern, bool includeSubDirectories, bool strictSearch)
        {
            var files = new List<IFileSystemEntity>();
            var dirInfo = new DirectoryInfo(path);

            if (path.Split(@"/\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length > 1 && dirInfo.Attributes.HasFlag(FileAttributes.System))
                return files;

            char[] chars = pattern.Replace(".", "").ToCharArray();
            var directories = new string[] { };

            try
            {
                string[] strFiles;

                if (strictSearch)
                {
                    strFiles = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);

                }
                else
                {
                    strFiles = Directory.GetFiles(
                    path,
                    "*.*",
                    SearchOption.TopDirectoryOnly
                    );
                    strFiles = strFiles.Where(p => p.Split(@"/\".ToCharArray()).Last().IndexOfAny(chars) >= 0).ToArray();
                }

                foreach (var file in strFiles)
                {
                    if (File.Exists(file))
                        files.Add(new PathEntity.FileEntity(file));
                    if (Directory.Exists(file))
                        files.Add(new PathEntity.DirectoryEntity(file));

                }
                if (!includeSubDirectories)
                    return files;

                directories = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException) { }

            foreach (var directory in directories)
                try
                {
                    files.AddRange(GetFiles(directory, pattern, includeSubDirectories, strictSearch));
                }
                catch (UnauthorizedAccessException) { }

            return files;
        }

        public override FileAttributes GetFileAttributes(FileEntity file)
        {
            return new FileInfo(file.FullPath).Attributes;
        }

        public override FileAttributes GetDirectoryAttributes(IListable directory)
        {
            return new DirectoryInfo(directory.FullPath).Attributes;
        }

        public override DateTime GetFileTimeModified(FileEntity file)
        {
            return new FileInfo(file.FullPath).LastWriteTime;
        }

        public override DateTime GetDirectoryTimeModified(IListable directory)
        {
            return new DirectoryInfo(directory.FullPath).LastWriteTime;
        }

        public override long GetFileSize(FileEntity file)
        {
            return new FileInfo(file.FullPath).Length;
        }

        public override long GetDiskSize(DriveEntity drive)
        {
            return new DriveInfo(drive.FullPath).TotalSize;
        }

        public override long GetDiskFreeSpace(DriveEntity drive)
        {
            return new DriveInfo(drive.FullPath).TotalFreeSpace;
        }

        public override string GetDiskLabel(DriveEntity drive)
        {
            return new DriveInfo(drive.FullPath).VolumeLabel;
        }
    }
}
