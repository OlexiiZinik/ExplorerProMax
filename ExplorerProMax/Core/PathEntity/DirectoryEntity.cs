using ExplorerProMax.Core.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.PathEntity
{
    public class DirectoryEntity: IPathEntity, IListable
    {
        public string Name { get => GetName(); }

        public EntityType Type => EntityType.DIRECTORY;

        public string FullPath { get; private set; }
        public DateTime LastEdited => Utils.FSManager.GetDirectoryTimeModified(this);
        public FileAttributes Attributes => Utils.FSManager.GetDirectoryAttributes(this);
        public IListable Parent => Utils.FSManager.GetParent(this);

        public DirectoryEntity() { }


        public DirectoryEntity(string fullPath, bool checkExists = true)
        {
            if (checkExists)
                if (!Directory.Exists(fullPath))
                    throw new DirectoryNotFoundException($"Directory \"{fullPath}\" Does not exist");
            FullPath = fullPath;
        }

        public string GetName()
        {
            return FullPath.Split(@"\/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Last();
        }

        public List<IPathEntity> ListDirectory()
        {
            return Utils.FSManager.ListDirectory(this);
        }
    }
}
