using ExplorerProMax.Core;
using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExplorerProMax.UI.Components
{
    public partial class FolderWindow : UserControl
    {
        public FileExplorer Explorer { get; private set; } = new FileExplorer();
        public FolderWindow()
        {
            InitializeComponent();
            cbDisk.Items.AddRange(Explorer.GetAllDisks().Select(x => x.Name).ToArray());
            lvFiles.Items.Clear();
            ShowHome();
        }

        private void FolderWindow_Load(object sender, EventArgs e)
        {
            
        }

        public void ShowHome()
        {
            cbDisk.Text = string.Empty;
            bBackward.Enabled = false;
            ShowFiles(Explorer.GetAllDisks().Cast<IPathEntity>().ToList());
        }

        public void ChangeDirectory(IListable path)
        {
            bBackward.Enabled = true;
            Explorer.ChangeDirectory(path);
            tbPath.Text = Explorer.CurrentWorkingDirectory.FullPath;
            ShowCurrentDirectory();
        }

        public void ShowCurrentDirectory()
        {
            ShowFiles(Explorer.CurrentWorkingDirectory);
        }

        public void ShowFiles(IListable listable)
        {
            ShowFiles(listable.ListDirectory());
        }

        public void ShowFiles(List<IPathEntity> files)
        {
            lvFiles.Items.Clear();
            foreach (IPathEntity entity in files)
            {
                var record = new ListViewObjectItem(entity);
                lvFiles.Items.Add(record);

            }
        }

        private void lvFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                IPathEntity doubleClicked = (lvFiles.SelectedItems[0] as ListViewObjectItem).Item;
                if(doubleClicked is IListable)
                {
                    ChangeDirectory(doubleClicked as IListable);
                }

            }
        }

        private void bBackward_Click(object sender, EventArgs e)
        {

        }

        private void bForward_Click(object sender, EventArgs e)
        {

        }
    }
}
