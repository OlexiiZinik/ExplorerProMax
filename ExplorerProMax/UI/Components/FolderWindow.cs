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
        public bool AtHome {  get; private set; }
        public FolderWindow()
        {
            InitializeComponent();
            cbDisk.Items.Add(String.Empty);
            cbDisk.Items.AddRange(Explorer.GetAllDisks().Select(x => x.Name).ToArray());
            lvFiles.Items.Clear();
            bForward.Enabled = false;
            fswObserver.EnableRaisingEvents = false;
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
            AtHome = true;
            cbDisk.Text = "";
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
                AtHome = false;
                cbDisk.Text = Explorer.GetCurrentWorkingDisk().Name;
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
            cbDisk.Text = AtHome ? "" : Explorer.GetCurrentWorkingDisk().Name;
        }

        public void ShowFiles(IListable listable)
        {
            ShowFiles(listable.ListDirectory());
        }

        public void ShowFiles(List<IPathEntity> files)
        {
            lvFiles.Items.Clear();
            for (int i = 5; i < lvFiles.Items.Count; i++)
                ilIcons.Images.RemoveAt(i);

            foreach (IPathEntity entity in files)
            {
                var record = new ListViewObjectItem(entity);
                if (entity is ParentLink)
                    record.ImageIndex = 2;
                else if(entity.Type == EntityType.DIRECTORY)
                    record.ImageIndex = 1;
                else if (entity.Type == EntityType.DISK)
                    if(entity.Name == "C:")
                        record.ImageIndex = 4;
                    else
                        record.ImageIndex = 3;
                else
                {
                    ilIcons.Images.Add(Icon.ExtractAssociatedIcon(entity.FullPath));
                    record.ImageIndex = ilIcons.Images.Count - 1;
                }
                
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
                    if (Explorer.CurrentWorkingDirectory.Parent is null)
                        ShowHome();
                    else
                        ChangeDirectory(Explorer.CurrentWorkingDirectory.Parent);
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

        private void tbPath_Leave(object sender, EventArgs e)
        {
            tbPath.Text = AtHome ? "" : Explorer.CurrentWorkingDirectory.FullPath;
        }

        private void tbPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
            { return; }

            if (tbPath.Text == String.Empty)
            {
                ShowHome();
                return;
            }

            Core.PathEntity.DirectoryInfo path;
            try
            {
                path = new Core.PathEntity.DirectoryInfo(tbPath.Text);
                ChangeDirectory(path);
            }
            catch (DirectoryNotFoundException)
            {
                try
                {
                    ChangeDirectory(new Core.PathEntity.FileInfo(tbPath.Text).Parent);
                }
                catch
                {
                    tbPath.Text = AtHome ? "" : Explorer.CurrentWorkingDirectory.FullPath;
                }
            }
        }

        private void cbDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDisk.Text == String.Empty)
                ShowHome();
            else
                ChangeDirectory(new DiskInfo(cbDisk.Text+@"\"));
        }
    }
}
