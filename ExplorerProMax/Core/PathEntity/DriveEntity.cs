using ExplorerProMax.Core.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.PathEntity
{
    public class DriveEntity : IPathEntity, IListable
    {
        public string FullPath { get; private set; }
        public string Name => FullPath.Replace(@"\", "");
        public EntityType Type => EntityType.DISK;
        public string Label => Utils.FSManager.GetDiskLabel(this);
        public long Size => Utils.FSManager.GetDiskSize(this);
        public long FreeSpace => Utils.FSManager.GetDiskFreeSpace(this);
        public IListable Parent => null;

        public DriveEntity() { }

        public DriveEntity(string fullPath, bool checkExists = true)
        {
            FullPath = fullPath;
            if (checkExists)
            {
                if (!Directory.Exists(fullPath))
                    throw new DriveNotFoundException($"Disk \"{fullPath}\" Does not exist");
            }
        }
        public List<IPathEntity> ListDirectory()
        {
            return Utils.FSManager.ListDirectory(this);
        }
    }
}