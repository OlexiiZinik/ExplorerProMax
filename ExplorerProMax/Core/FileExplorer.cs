﻿using ExplorerProMax.Core.PathEntity;
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

        public DiskInfo GetCurrentWorkingDisk()
        {
            if(CurrentWorkingDirectory is null)
                return null;

            IListable dir = CurrentWorkingDirectory;
            while (dir.Parent != null)
            {
                dir = dir.Parent;
            }
            return new DiskInfo(dir.FullPath);
        }
        public void DeleteEntities(List<IPathEntity> files)
        {
            Utils.DeleteEntities(files);
        }
        public void MoveFilesToCurrentDirectory(List<IPathEntity> files)
        {
            if (CurrentWorkingDirectory != null)
                Utils.MoveFiles(files, CurrentWorkingDirectory);
        }
        public void CopyFilesToCurrentDirectory(string[] files)
        {
            if (CurrentWorkingDirectory != null)
                Utils.CopyFiles(files, CurrentWorkingDirectory);
        }

        public void CopyFilesToCurrentDirectory(List<IPathEntity> files)
        {
            if (CurrentWorkingDirectory != null)
                Utils.CopyFiles(files, CurrentWorkingDirectory);
        }

        public void CreateDirectory(string name, FileAttributes fileAttributes)
        {
            if(CurrentWorkingDirectory != null)
                Utils.MakeDirectory(CurrentWorkingDirectory, name, fileAttributes);
        }

        public void CreateFile(string name, FileAttributes fileAttributes)
        {
            if (CurrentWorkingDirectory != null)
                Utils.MakeFile(CurrentWorkingDirectory, name, fileAttributes);
        }
        public void RenameEntity(IPathEntity entity, string name, FileAttributes fileAttributes)
        {
            if (CurrentWorkingDirectory != null)
                Utils.RenameEntity(entity, name, fileAttributes);
        }

        public List<IPathEntity> Serarch(string template, bool includeSubDirectoris, bool strictSearch) 
        {
            if (CurrentWorkingDirectory != null)
                return Utils.Search(CurrentWorkingDirectory, template, includeSubDirectoris, strictSearch);
            return new List<IPathEntity>();
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
