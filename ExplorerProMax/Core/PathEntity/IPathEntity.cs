using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.PathEntity
{
    public enum EntityType
    {
        FILE,
        DIRECTORY,
        DISK,
        PARENT_DIR,
    }

    public interface IPathEntity
    {
        string Name { get; }
        EntityType Type { get; }
        string FullPath { get; }
        IListable Parent {  get; }
    }
}
