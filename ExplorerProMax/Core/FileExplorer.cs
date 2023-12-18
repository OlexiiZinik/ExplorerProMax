using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core
{
    public class FileExplorer
    {
        public IListable CurrentWorkingDirectory { get; private set; }

        private List<IListable> path_history = new List<IListable>();
        private int current_path;

        public FileExplorer() { }

        public void ChangeDirectory(IListable directory) 
        {
            path_history.Add(directory);
            CurrentWorkingDirectory = directory;
        }

        public List<IPathEntity> ListDirectory() 
        {
            return CurrentWorkingDirectory.ListDirectory();
        }

        public List<DiskInfo> GetAllDisks()
        {
            return Utils.GetAllDisks();
        }

        public void Backward()
        {
            //if(path_history.Count > 0)
        }
    }
}
