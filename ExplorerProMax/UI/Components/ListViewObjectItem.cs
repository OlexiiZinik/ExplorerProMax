﻿using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerProMax.UI.Components
{
    public class ListViewObjectItem : ListViewItem
    {
        public IPathEntity Item { get; private set; }

        public ListViewObjectItem(IPathEntity pathEntity) : base()
        {
            Item = pathEntity;
            if (pathEntity is FileInfo ||  pathEntity is DirectoryInfo)
            {
                this.Text = Item.Name;
            }
            else if (pathEntity is DiskInfo)
            {
                this.Text = $"({pathEntity.Name}) {(pathEntity as DiskInfo).Label}";
            }

            if (pathEntity is FileInfo)
            {
                this.SubItems.Add(new ListViewSubItem(this, (Item as FileInfo).Extention.ToUpper()));
                this.SubItems.Add(new ListViewSubItem(this, Utils.SizeToString((Item as FileInfo).Size)));
                this.SubItems.Add(new ListViewSubItem(this, "123"));
            }
            
            else if (pathEntity is DirectoryInfo)
            {
                this.SubItems.Add(new ListViewSubItem(this, "Directory"));
            }
            else if (pathEntity is DiskInfo) 
            {
                this.SubItems.Add(new ListViewSubItem(this, "Drive"));
                this.SubItems.Add(new ListViewSubItem(this, $"{Utils.SizeToString((Item as DiskInfo).FreeSpace)} вільно з {Utils.SizeToString((Item as DiskInfo).Size)}"));
                this.SubItems.Add(new ListViewSubItem(this, "123"));
            }
        }
    }
}
