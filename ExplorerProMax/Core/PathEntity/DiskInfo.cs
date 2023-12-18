using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.PathEntity
{
    public class DiskInfo : IPathEntity, IListable
    {
        public string Name => FullPath.Replace(@"\", "");

        public EntityType Type => EntityType.DISK;

        public string Label {  get; private set; }
        public long Size { get; private set; }
        public long FreeSpace { get; private set; }


        public string FullPath { get; private set; }

        public DiskInfo() { }

        public DiskInfo(string fullPath, bool checkExists = true)
        {
            FullPath = fullPath;
            if (checkExists)
            {
                if (!Directory.Exists(fullPath))
                    throw new DriveNotFoundException($"Disk \"{fullPath}\" Does not exist");
                FillInfo();
            }
        }

        private void FillInfo()
        {
            DriveInfo di = DriveInfo.GetDrives().Where(d => d.Name == FullPath).First();
            Label = di.VolumeLabel;
            Size = di.TotalSize;
            FreeSpace = di.TotalFreeSpace;
        }

        public List<IPathEntity> ListDirectory()
        {
            return Utils.ListDirectory(this);
        }
    }
}