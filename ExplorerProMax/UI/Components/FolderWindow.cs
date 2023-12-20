using ExplorerProMax.Core;
using ExplorerProMax.Core.PathEntity;
using Peter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExplorerProMax.UI.Components
{
    public partial class FolderWindow : UserControl
    {
        public FileExplorer Explorer { get; private set; } = new FileExplorer();
        public bool AtHome {  get; private set; }

        public List<IFileSystemEntity> SelectedEntities => GetSelectedEntities();

        private ListViewColumnSorter lvwColumnSorter;

        public FolderWindow()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvFiles.ListViewItemSorter = lvwColumnSorter;
            cbView.SelectedIndex = 0;
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
            ShowFiles(Explorer.GetAllDisks().Cast<IFileSystemEntity>().ToList());
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

        public void ShowFiles(List<IFileSystemEntity> files)
        {
            lvFiles.Items.Clear();
            for (int i = 5; i < ilIconsSmall.Images.Count; i++)
            {
                ilIconsSmall.Images.RemoveAt(i);
                ilIconsLarge.Images.RemoveAt(i);
            }

            foreach (IFileSystemEntity entity in files)
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
                    var icon = Icon.ExtractAssociatedIcon(entity.FullPath);
                    ilIconsSmall.Images.Add(icon);
                    ilIconsLarge.Images.Add(icon);
                    record.ImageIndex = ilIconsSmall.Images.Count - 1;
                }
                
                lvFiles.Items.Add(record);

            }
        }

        public void ShowSearchResult(List<IFileSystemEntity> files)
        {
            fswObserver.EnableRaisingEvents = false;
            ShowFiles(files);
        }

        private void lvFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                OpenSelectedFileOrDirectory();
            }
        }
        private void OpenSelectedFileOrDirectory()
        {
            IFileSystemEntity selectedItem = SelectedEntities.First();
            if (selectedItem == null)
                return;

            if (selectedItem is IListable)
            {
                ChangeDirectory(selectedItem as IListable);
            }
            else if (selectedItem is ParentLink)
            {
                if (Explorer.CurrentWorkingDirectory.Parent is null)
                    ShowHome();
                else
                    ChangeDirectory(Explorer.CurrentWorkingDirectory.Parent);
                bForward.Enabled = false;
            }
            else if (selectedItem is FileEntity)
            {
                OpenFile(selectedItem);
            }
        }

        public void OpenFile(IFileSystemEntity file)
        {
            if (!(file is FileEntity))
                return;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = (file as FileEntity).FullPath;
            Process.Start(info);
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

            DirectoryEntity path;
            try
            {
                path = new DirectoryEntity(tbPath.Text);
                ChangeDirectory(path);
            }
            catch (DirectoryNotFoundException)
            {
                try
                {
                    ChangeDirectory(new FileEntity(tbPath.Text).Parent);
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
                ChangeDirectory(new DriveEntity(cbDisk.Text+@"\"));
        }


        private void lvFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (AtHome)
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Explorer.CopyFilesToCurrentDirectory(files);
            lvFiles.BackColor = Color.White;
            ShowCurrentDirectory();
        }

        private void lvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (!AtHome)
                {
                    lvFiles.BackColor = Color.DeepSkyBlue;
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    lvFiles.BackColor = Color.Red;
                    e.Effect = DragDropEffects.None;
                }

            }
        }

        private void lvFiles_DragLeave(object sender, EventArgs e)
        {
            lvFiles.BackColor = Color.White;
        }

        private void lvFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.lvFiles.Sort();
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbView.SelectedIndex == 0) 
                lvFiles.View = View.Details;
            else if(cbView.SelectedIndex == 1)
                lvFiles.View = View.LargeIcon;
            else
                lvFiles.View = View.Details;
        }

        private void ShowContextMenu(List<IFileSystemEntity> entitys, int X, int Y)
        {
            ShellContextMenu ctxMnu = new ShellContextMenu();
            FileSystemInfo[] fsi = new FileSystemInfo[entitys.Count];
            for (int i = 0; i < entitys.Count; i++)
            {
                if (entitys[i] is FileEntity)
                    fsi[i] = new FileInfo(entitys[i].FullPath);
                else if (entitys[i] is DirectoryEntity)
                    fsi[i] = new DirectoryInfo(entitys[i].FullPath);
                else if (entitys[i] is DriveEntity)
                    return;
            }
            ctxMnu.ShowContextMenu(fsi, this.PointToScreen(new Point(X + 5, Y + 35)));
        }

        private void lvFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if(!AtHome && e.Button == MouseButtons.Right)
            {
                var files = new List<IFileSystemEntity>();
                foreach (var selectedItem in lvFiles.SelectedItems)
                    files.Add((selectedItem as ListViewObjectItem).Item);
                ShowContextMenu(files, e.X,e.Y);
            }
        }

        private void lvFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (!AtHome && e.Button == MouseButtons.Right && lvFiles.SelectedItems.Count == 0)
            {
                var files = new List<IFileSystemEntity>();
                files.Add((IFileSystemEntity)Explorer.CurrentWorkingDirectory);
                ShowContextMenu(files, e.X, e.Y);
            }
        }

        public List<IFileSystemEntity> GetSelectedEntities()
        {
            var entities = new List<IFileSystemEntity>();
            foreach (var selectedItem in lvFiles.SelectedItems)
                entities.Add((selectedItem as ListViewObjectItem).Item);
            return entities;
        }

        private void lvFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                OpenSelectedFileOrDirectory();
            }
        }

        public void OpenAndFocusDiskSelect()
        {
            cbDisk.DroppedDown = !cbDisk.DroppedDown;
            cbDisk.Focus();
        }

        private void cbDisk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lvFiles.Focus();
            }
        }
    }
}
