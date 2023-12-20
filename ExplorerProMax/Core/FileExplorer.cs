using ExplorerProMax.Core.FileSystem;
using ExplorerProMax.Core.PathEntity;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            if (CurrentWorkingDirectory?.FullPath == directory.FullPath)
                return;

            if(path_history.Count - 1 > current_path_index)
                path_history = path_history.Take(current_path_index+1).ToList();

            path_history.Add(directory);
            current_path_index++;

            CurrentWorkingDirectory = directory;
        }

        public List<IFileSystemEntity> ListDirectory() 
        {
            return CurrentWorkingDirectory.ListDirectory();
        }

        public List<DriveEntity> GetAllDisks()
        {
            return Utils.FSManager.GetAllDisks();
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

        public DriveEntity GetCurrentWorkingDisk()
        {
            if(CurrentWorkingDirectory is null)
                return null;

            IListable dir = CurrentWorkingDirectory;
            while (dir.Parent != null)
            {
                dir = dir.Parent;
            }
            return new DriveEntity(dir.FullPath);
        }
        public void DeleteEntities(List<IFileSystemEntity> files)
        {
            Utils.FSManager.DeleteEntities(files);
        }
        public void MoveFilesToCurrentDirectory(List<IFileSystemEntity> files)
        {
            if (CurrentWorkingDirectory != null)
                Utils.FSManager.MoveFiles(files, CurrentWorkingDirectory);
        }
        public void CopyFilesToCurrentDirectory(string[] files)
        {
            if (CurrentWorkingDirectory != null)
                Utils.FSManager.CopyFiles(files, CurrentWorkingDirectory);
        }

        public void CopyFilesToCurrentDirectory(List<IFileSystemEntity> files)
        {
            if (CurrentWorkingDirectory != null)
                Utils.FSManager.CopyFiles(files, CurrentWorkingDirectory);
        }

        public void CreateDirectory(string name, FileAttributes fileAttributes)
        {
            if(CurrentWorkingDirectory != null)
                Utils.FSManager.MakeDirectory(CurrentWorkingDirectory, name, fileAttributes);
        }

        public void CreateFile(string name, FileAttributes fileAttributes)
        {
            if (CurrentWorkingDirectory != null)
                Utils.FSManager.MakeFile(CurrentWorkingDirectory, name, fileAttributes);
        }
        public void RenameEntity(IFileSystemEntity entity, string name, FileAttributes fileAttributes)
        {
            if (CurrentWorkingDirectory != null)
                Utils.FSManager.RenameEntity(entity, name, fileAttributes);
        }

        public List<IFileSystemEntity> Serarch(string pattern, bool includeSubDirectoris, bool strictSearch) 
        {
            if (CurrentWorkingDirectory != null)
                return Utils.FSManager.Search(CurrentWorkingDirectory, pattern, includeSubDirectoris, strictSearch);
            return new List<IFileSystemEntity>();
        }

        //private void FillEmptyHistory()
        //{
        //    if (path_history.Count == 0)
        //    {
        //        IListable parent = CurrentWorkingDirectory.Parent;
        //        while (parent != null)
        //        {
        //            current_path_index++;
        //            path_history.Insert(0, parent);
        //            parent = parent.Parent;
        //        }
        //    }
        //}
    }
}
