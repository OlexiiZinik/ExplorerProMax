using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.PathEntity
{
    public interface IListable
    {
        string FullPath { get; }
        List<IPathEntity> ListDirectory();
        IListable Parent { get; }
    }
}
