using ExplorerProMax.Core.PathEntity;
using ExplorerProMax.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core
{
    public static class Utils
    {
        public static List<PathEntity.IPathEntity> ListDirectory(PathEntity.IListable directory)
        {
            var result = new List<PathEntity.IPathEntity>();
            var files = Directory.GetFiles(directory.FullPath);
            var directoris = Directory.GetDirectories(directory.FullPath);
            result.Add(new PathEntity.ParentLink(directory));
            result.AddRange(directoris.Select((d) => new PathEntity.DirectoryInfo(d)));
            result.AddRange(files.Select((d) => new PathEntity.FileInfo(d)));
            return result;
        }
        public static List<PathEntity.DiskInfo> GetAllDisks()
        {
            var result = new List<PathEntity.DiskInfo>();
            result.AddRange(DriveInfo.GetDrives().Select((d) => new PathEntity.DiskInfo(d.Name)));
            return result;
        }

        public static IListable GetParent(IPathEntity pathEntity)
        {
            var splitedPath = pathEntity.FullPath.Split(@"/\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if(splitedPath.Length <= 1)
            {
                return null;
            }
            return new PathEntity.DirectoryInfo(String.Join(@"\", splitedPath.Take(splitedPath.Length - 1)) + @"\");
        }

        public static void MoveFiles(List<IPathEntity> files, IListable destination)
        {
            foreach (var file in files)
            {
                try
                {
                    if (file is PathEntity.FileInfo)
                        MoveFile(file, destination);

                    else if (file is PathEntity.DirectoryInfo)
                        MoveDirectory(file, destination);
                }
                catch { }
            }
        }

        public static void MoveFile(IPathEntity file, IListable destination)
        {
            if (!(file is PathEntity.FileInfo))
                return;

            string newFilePath = Path.Combine(destination.FullPath, (file as PathEntity.FileInfo).FullName);

            if (!File.Exists(newFilePath))
                File.Move(file.FullPath, newFilePath);
        }
        public static void MoveDirectory(IPathEntity directory, IListable destination)
        {
            if (!(directory is PathEntity.DirectoryInfo))
                return;

            string newDirectoryPath = Path.Combine(destination.FullPath, (directory as PathEntity.DirectoryInfo).Name);
            if (!Directory.Exists(newDirectoryPath))
                Directory.Move(directory.FullPath, newDirectoryPath);

        }

        public static void CopyFiles(string[] files, IListable destination)
        {
            List<IPathEntity> entities = new List<IPathEntity>();
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    entities.Add(new PathEntity.FileInfo(file));
                }
                else if (Directory.Exists(file))
                {
                    entities.Add(new PathEntity.DirectoryInfo(file));
                }
            }
            CopyFiles(entities, destination);
        }

        public static void CopyFiles(List<IPathEntity> files, IListable destination)
        {
            foreach (var file in files)
            {
                if(file is PathEntity.FileInfo)
                {
                    File.Copy(file.FullPath, Path.Combine(destination.FullPath, Path.GetFileName(file.FullPath)));

                }
                else if (file is PathEntity.DirectoryInfo)
                {
                    CopyDirectory(file.FullPath, Path.Combine(destination.FullPath, file.Name), true);
                }
            }
        }
        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new System.IO.DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            System.IO.DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destinationDir);

            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (System.IO.DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        public static void MakeDirectory(IListable location, string name, FileAttributes fileAttributes)
        {
            string directory = Path.Combine(location.FullPath, name);
            if (File.Exists(directory))
                return;

            var di = Directory.CreateDirectory(directory);
            di.Attributes = fileAttributes;
        }

        public static void MakeFile(IListable location, string name, FileAttributes fileAttributes)
        {
            string filename = Path.Combine(location.FullPath, name);
            if (File.Exists(filename))
                return;

            using (File.Create(filename)) { }
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
            fileInfo.Attributes = fileAttributes;
        }
        public static void RenameEntity(IPathEntity entity, string name, FileAttributes fileAttributes)
        {
            string newPath = Path.Combine(entity.Parent.FullPath, name);
            if (entity is PathEntity.FileInfo)
            {
                File.Move((entity as PathEntity.FileInfo).FullPath, newPath);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(newPath);
                fileInfo.Attributes = fileAttributes;
            }
            else if (entity is PathEntity.DirectoryInfo)
            {
                Directory.Move((entity as PathEntity.DirectoryInfo).FullPath, newPath);
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(newPath);
                directoryInfo.Attributes = fileAttributes;
            }
        }
        public static void DeleteEntities(List<IPathEntity> files)
        {
            foreach (IPathEntity entity in files)
            {
                try { 
                    if (entity is PathEntity.DirectoryInfo)
                        Directory.Delete(entity.FullPath);
                    else if (entity is PathEntity.FileInfo)
                        File.Delete(entity.FullPath);
                }
                catch { }
            }
        }
    }
}
