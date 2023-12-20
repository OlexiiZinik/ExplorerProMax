using ExplorerProMax.Core.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core
{
    public static class Utils
    {
        private static FileSystemManager _FSManager = new WindowsFileSystemManager();
        public static FileSystemManager FSManager => _FSManager;
    }
}
