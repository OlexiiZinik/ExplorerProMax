using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.FileSystem
{
    public abstract class FileSystemManager
    {
        public abstract List<IPathEntity> ListDirectory(IListable directory);
        public abstract List<DriveEntity> GetAllDisks();
        public abstract IListable GetParent(IPathEntity pathEntity);
        public abstract void MoveFiles(List<IPathEntity> files, IListable destination);
        public abstract void MoveFile(IPathEntity file, IListable destination);
        public abstract void MoveDirectory(IPathEntity directory, IListable destination);
        public abstract void CopyFiles(string[] files, IListable destination);
        public abstract void CopyFiles(List<IPathEntity> files, IListable destination);
        public abstract void MakeDirectory(IListable location, string name, FileAttributes fileAttributes);
        public abstract void MakeFile(IListable location, string name, FileAttributes fileAttributes);  
        public abstract void RenameEntity(IPathEntity entity, string name, FileAttributes fileAttributes);
        public abstract void DeleteEntities(List<IPathEntity> files);
        public abstract List<IPathEntity> Search(IListable location, string pattern, bool includeSubDirectories, bool strictSearch);
        //public abstract string GetFileName(IPathEntity file);
        //public abstract string GetFileExtention(IPathEntity file);
        //public abstract string GetFileFullName(IPathEntity file);
        //public abstract string GetDirectoryName(IPathEntity file);
        public abstract FileAttributes GetFileAttributes(FileEntity file);
        public abstract FileAttributes GetDirectoryAttributes(IListable directory);
        public abstract DateTime GetFileTimeModified(FileEntity file);
        public abstract DateTime GetDirectoryTimeModified(IListable directory);
        public abstract long GetFileSize(FileEntity file);
        public abstract long GetDiskSize(DriveEntity drive);
        public abstract long GetDiskFreeSpace(DriveEntity drive);
        public abstract string GetDiskLabel(DriveEntity drive);


    }
}
