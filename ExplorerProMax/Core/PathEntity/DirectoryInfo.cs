using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.PathEntity
{
    public class DirectoryInfo: IPathEntity, IListable
    {
        public string Name { get => GetName(); }

        public EntityType Type => EntityType.DIRECTORY;

        public string FullPath { get; private set; }

        public IListable Parent => Utils.GetParent(this);

        public DirectoryInfo() { }


        public DirectoryInfo(string fullPath, bool checkExists = true)
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
            return Utils.ListDirectory(this);
        }
    }
}
