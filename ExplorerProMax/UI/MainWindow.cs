using ExplorerProMax.Core.PathEntity;
using ExplorerProMax.UI.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerProMax.UI
{
    public partial class MainWindow : Form
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private FolderWindow GetFocusedFolderWindow()
        {
            if (folderWindow1.ContainsFocus)
            {
                Console.WriteLine("1");
                return folderWindow1;
            }
            else
            {
                Console.WriteLine("2");
                return folderWindow2;
            }
        }
        private FolderWindow GetUnFocusedFolderWindow()
        {
            if (!folderWindow1.ContainsFocus)
            {
                Console.WriteLine("1");
                return folderWindow1;
            }
            else
            {
                Console.WriteLine("2");
                return folderWindow2;
            }
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;

            foreach(IPathEntity entity in currentFolderWindow.SelectedEntities)
            {
                currentFolderWindow.OpenFile(entity);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;

            foreach (IPathEntity entity in currentFolderWindow.SelectedEntities)
            {

                if (entity is Core.PathEntity.FileInfo && (entity as  Core.PathEntity.FileInfo).Extention != "exe")
                    currentFolderWindow.OpenFile(entity);
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            var focusedFolderWindow = GetFocusedFolderWindow();
            var unfocusedFolderWindow = GetUnFocusedFolderWindow();
            if (focusedFolderWindow.AtHome || focusedFolderWindow.AtHome)
                return;

            unfocusedFolderWindow.Explorer.CopyFilesToCurrentDirectory(focusedFolderWindow.SelectedEntities);
        }

        private void tsbMove_Click(object sender, EventArgs e)
        {

            var focusedFolderWindow = GetFocusedFolderWindow();
            var unfocusedFolderWindow = GetUnFocusedFolderWindow();
            if (focusedFolderWindow.AtHome || focusedFolderWindow.AtHome)
                return;

            unfocusedFolderWindow.Explorer.MoveFilesToCurrentDirectory(focusedFolderWindow.SelectedEntities);
        }

        private void tsbEditAttributes_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;

            var editEntity = new EditEntity(currentFolderWindow.Explorer, currentFolderWindow.SelectedEntities.First());
            editEntity.ShowDialog();
        }

        private void tsbNewFolder_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;

            var createFolder = new EditEntity(currentFolderWindow.Explorer, EditEntityOptions.CREATE_DIRECTORY);
            createFolder.ShowDialog();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;
            currentFolderWindow.Explorer.DeleteEntities(currentFolderWindow.SelectedEntities);
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbNewFile_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;

            var createFile = new EditEntity(currentFolderWindow.Explorer, EditEntityOptions.CREATE_FILE);
            createFile.ShowDialog();
        }

        private void folderWindow2_Enter(object sender, EventArgs e)
        {

        }

        private void folderWindow1_Enter(object sender, EventArgs e)
        {

        }
    }
}
