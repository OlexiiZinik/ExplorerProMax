using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core
{
    public class FileExplorer
    {
        public IListable CurrentWorkingDirectory { get; private set; }

        private List<IListable> path_history = new List<IListable>();
        private int current_path_index = -1;

        public FileExplorer() { }

        public void ChangeDirectory(IListable directory) 
        {
            if(path_history.Count - 1 > current_path_index)
                path_history = path_history.Take(current_path_index+1).ToList();

            path_history.Add(directory);
            current_path_index++;

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
            if(current_path_index > -1)
                current_path_index--;

            if(current_path_index < 0)
            {
                throw new DirectoryNotFoundException();
            }            
            CurrentWorkingDirectory = path_history[current_path_index];
        }
        public bool Forward()
        {
            if(path_history.Count == 0)
            {
                return false;
            }
            if(path_history.Count - 1 > current_path_index)
            {
                current_path_index++;
                CurrentWorkingDirectory = path_history[current_path_index];
                return path_history.Count - 1 > current_path_index;
            }
            return false;
        }

        private void FillEmptyHistory()
        {
            if (path_history.Count == 0)
            {
                IListable parent = CurrentWorkingDirectory.Parent;
                while (parent != null)
                {
                    current_path_index++;
                    path_history.Insert(0, parent);
                    parent = parent.Parent;
                }
            }

        }
    }
}
