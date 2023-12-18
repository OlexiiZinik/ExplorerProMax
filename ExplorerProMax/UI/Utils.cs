using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.UI
{
    public static class Utils
    {
        public static string SizeToString(long size)
        {
            double len = size;
            string[] units = { "B", "KB", "MB", "GB", "TB", "PB" };
            int order = 0;
            while (len >= 1024 && order < units.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return String.Format("{0:0.##} {1}", len, units[order]);
        }
    }
}
