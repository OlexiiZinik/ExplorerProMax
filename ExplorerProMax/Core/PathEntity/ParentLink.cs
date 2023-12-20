using ExplorerProMax.Core.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.PathEntity
{
    public class ParentLink : IFileSystemEntity
    {
        public string Name => "..";

        public EntityType Type => EntityType.PARENT_DIR;

        public string FullPath { get; private set; }

        public IListable Parent => Utils.FSManager.GetParent(this);

        public ParentLink(IListable location) 
        {
            FullPath = location.FullPath;
        }
    }
}
