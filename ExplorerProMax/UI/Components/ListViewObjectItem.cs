using ExplorerProMax.Core.PathEntity;
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
            if (pathEntity is FileEntity ||  pathEntity is DirectoryEntity || pathEntity is ParentLink)
            {
                this.Text = Item.Name;
            }
            else if (pathEntity is DriveEntity)
            {
                this.Text = $"({pathEntity.Name}) {(pathEntity as DriveEntity).Label}";
            }

            if (pathEntity is FileEntity)
            {
                this.SubItems.Add(new ListViewSubItem(this, (Item as FileEntity).Extention.ToUpper()));
                this.SubItems.Add(new ListViewSubItem(this, Utils.SizeToString((Item as FileEntity).Size)));
                this.SubItems.Add(new ListViewSubItem(this, (Item as FileEntity).LastEdited.ToString("yyyy/MM/dd HH:mm:ss")));
                this.SubItems.Add(new ListViewSubItem(this, String.Join("", (Item as FileEntity).Attributes.ToString().Where(c=> !Char.IsLower(c)))));
            }
            
            else if (pathEntity is DirectoryEntity)
            {
                this.SubItems.Add(new ListViewSubItem(this, "Directory"));
                this.SubItems.Add(new ListViewSubItem(this, ""));
                this.SubItems.Add(new ListViewSubItem(this, (Item as DirectoryEntity).LastEdited.ToString("yyyy/MM/dd HH:mm:ss")));
                this.SubItems.Add(new ListViewSubItem(this, String.Join("", (Item as DirectoryEntity).Attributes.ToString().Where(c => !Char.IsLower(c)))));
            }
            else if (pathEntity is DriveEntity) 
            {
                this.SubItems.Add(new ListViewSubItem(this, "Drive"));
                this.SubItems.Add(new ListViewSubItem(this, $"{Utils.SizeToString((Item as DriveEntity).FreeSpace)} вільно з {Utils.SizeToString((Item as DriveEntity).Size)}"));
                this.SubItems.Add(new ListViewSubItem(this, ""));
                this.SubItems.Add(new ListViewSubItem(this, ""));
            }
            else if (pathEntity is ParentLink)
            {
                this.SubItems.Add(new ListViewSubItem(this, ".."));
                this.SubItems.Add(new ListViewSubItem(this, $""));
                this.SubItems.Add(new ListViewSubItem(this, ""));
                this.SubItems.Add(new ListViewSubItem(this, ""));
            }
        }
    }
}
