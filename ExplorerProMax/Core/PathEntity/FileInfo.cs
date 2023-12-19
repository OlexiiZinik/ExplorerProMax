using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ExplorerProMax.Core.PathEntity
{
    public class FileInfo : IPathEntity
    {
        public string FullPath { get; private set; }
        public string Location { get => GetLocation(); }
        public string Extention { get => GetExtention(); }
        public EntityType Type => EntityType.FILE;
        public string Name { get => GetName(); }
        public string FullName { get => FullPath.Split(@"\/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Last(); }
        public DateTime LastEdited => new System.IO.FileInfo(FullPath).LastWriteTime;
        public FileAttributes Attributes => new System.IO.FileInfo(FullPath).Attributes;
        public long Size => new System.IO.FileInfo(FullPath).Length;

        public IListable Parent => Utils.GetParent(this);

        public FileInfo() { }

        public FileInfo(string fullPath, bool checkExists = true)
        {
            if(checkExists)
                if(!File.Exists(fullPath))
                    throw new FileNotFoundException($"File \"{fullPath}\" Does not exist");
            FullPath = fullPath;
        }

        public string GetName()
        {
            string[] nameSplited;
            if (!FullName.Contains("."))
                return FullName;

            if (FullName.StartsWith("."))
            {
                nameSplited = FullName.Remove(0, 1).Split(".".ToCharArray());
                if (nameSplited.Length == 1)
                    return "." + nameSplited[0];
                else
                {
                    return "." + string.Join(".", nameSplited.Take(nameSplited.Length - 1).ToArray());
                }
                
            }
            nameSplited = FullName.Split(".".ToCharArray());
            return string.Join(".", nameSplited.Take(nameSplited.Length - 1).ToArray());


        }
        public string GetExtention()
        {
            var nameSplited = FullName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (nameSplited.Length == 1)
                return "";
            else
                return nameSplited.Last();
        }

        public string GetLocation()
        {
            var pathSplited = FullPath.Split(@"\/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return string.Join(@"\", pathSplited.Take(pathSplited.Length - 1)) + @"\";
        }
    }
}