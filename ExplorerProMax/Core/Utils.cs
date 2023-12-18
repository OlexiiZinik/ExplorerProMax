﻿using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core
{
    public static class Utils
    {
        public static List<PathEntity.IPathEntity> ListDirectory(PathEntity.IListable directory)
        {
            var result = new List<PathEntity.IPathEntity>();
            var files = Directory.GetFiles(directory.FullPath);
            var directoris = Directory.GetDirectories(directory.FullPath);
            result.Add(new PathEntity.ParentLink(directory));
            result.AddRange(directoris.Select((d) => new PathEntity.DirectoryInfo(d)));
            result.AddRange(files.Select((d) => new PathEntity.FileInfo(d)));
            return result;
        }
        public static List<PathEntity.DiskInfo> GetAllDisks()
        {
            var result = new List<PathEntity.DiskInfo>();
            result.AddRange(DriveInfo.GetDrives().Select((d) => new PathEntity.DiskInfo(d.Name)));
            return result;
        }

        public static IListable GetParent(IPathEntity pathEntity)
        {
            var splitedPath = pathEntity.FullPath.Split(@"/\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if(splitedPath.Length <= 1)
            {
                return null;
            }
            return new PathEntity.DirectoryInfo(String.Join(@"\", splitedPath.Take(splitedPath.Length - 1)) + @"\");
        }
    }
}
