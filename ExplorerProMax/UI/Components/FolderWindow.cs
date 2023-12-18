using ExplorerProMax.Core;
using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            bForward.Enabled = false;
            fswObserver.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            ShowHome();
        }

        private void FolderWindow_Load(object sender, EventArgs e)
        {
            
        }

        public void ShowHome()
        {
            tbPath.Text = "";
            fswObserver.EnableRaisingEvents = false;
            cbDisk.Text = string.Empty;
            bBackward.Enabled = false;
            ShowFiles(Explorer.GetAllDisks().Cast<IPathEntity>().ToList());
        }

        public void ChangeDirectory(IListable path)
        {
            try
            {
                Explorer.ChangeDirectory(path);
                bForward.Enabled = false;
                ShowCurrentDirectory();
                
            }
            catch (UnauthorizedAccessException e)
            {
                Explorer.Backward();
                fswObserver.Path = Explorer.CurrentWorkingDirectory.FullPath;
                fswObserver.EnableRaisingEvents = true;
                MessageBox.Show("У доступі відмовлено", "Помилка доступу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowCurrentDirectory()
        {
            ShowFiles(Explorer.CurrentWorkingDirectory);
            tbPath.Text = Explorer.CurrentWorkingDirectory.FullPath;
            bBackward.Enabled = true;
            fswObserver.Path = Explorer.CurrentWorkingDirectory.FullPath;
            fswObserver.EnableRaisingEvents = true;
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
                if (doubleClicked is ParentLink)
                {
                    bBackward.PerformClick();
                    bForward.Enabled = false;
                }

            }
        }

        private void bBackward_Click(object sender, EventArgs e)
        {
            try
            {
                Explorer.Backward();
                ShowCurrentDirectory();
            }
            catch (DirectoryNotFoundException)
            {
                ShowHome();
            }
            bForward.Enabled = true;
        }

        private void bForward_Click(object sender, EventArgs e)
        {
            bForward.Enabled = Explorer.Forward();
            ShowCurrentDirectory();
        }

        private void fswObserver_Changed(object sender, FileSystemEventArgs e)
        {
            ShowCurrentDirectory();
        }

        private void fswObserver_Renamed(object sender, RenamedEventArgs e)
        {
            ShowCurrentDirectory();
        }
    }
}
