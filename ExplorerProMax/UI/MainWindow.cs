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
                return folderWindow1;
            else
                return folderWindow2;
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

            foreach(IFileSystemEntity entity in currentFolderWindow.SelectedEntities)
            {
                currentFolderWindow.OpenFile(entity);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;

            foreach (IFileSystemEntity entity in currentFolderWindow.SelectedEntities)
            {

                if (entity is Core.PathEntity.FileEntity && (entity as  Core.PathEntity.FileEntity).Extention != "exe")
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


        private void tsbSearch_Click(object sender, EventArgs e)
        {
            var currentFolderWindow = GetFocusedFolderWindow();
            if (currentFolderWindow.AtHome)
                return;

            SearchForm searchForm = new SearchForm(currentFolderWindow.Explorer);
            if(searchForm.ShowDialog() == DialogResult.OK)
            {
                currentFolderWindow.ShowSearchResult(searchForm.SearchResult);
                tsbCancelSearch.Visible = true;
            }
        }

        private void tsbCancelSearch_Click(object sender, EventArgs e)
        {
            tsbCancelSearch.Visible = false;
            if(!folderWindow1.AtHome)
                folderWindow1.ShowCurrentDirectory();
            if (!folderWindow2.AtHome)
                folderWindow2.ShowCurrentDirectory();
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {

        }
        #region KeyBindings
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.F:
                        if (e.Shift && tsbCancelSearch.Visible)
                            tsbCancelSearch.PerformClick();
                        else
                            tsbSearch.PerformClick();
                        break;
                    case Keys.R:
                        tsbEditAttributes.PerformClick();
                        break;
                }
            }
            else if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        folderWindow1.OpenAndFocusDiskSelect();
                        break;
                    case Keys.F2:
                        folderWindow2.OpenAndFocusDiskSelect();
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        tsbHelp.PerformClick();
                        break;
                    case Keys.F3:
                        tsbOpen.PerformClick();
                        break;
                    case Keys.F4:
                        tsbEdit.PerformClick();
                        break;
                    case Keys.F5:
                        tsbCopy.PerformClick();
                        break;
                    case Keys.F6:
                        tsbMove.PerformClick();
                        break;
                    case Keys.F7:
                        tsbNewFolder.PerformClick();
                        break;
                    case Keys.F8:
                        tsbNewFile.PerformClick();
                        break;
                    case Keys.F9:
                        tsbDelete.PerformClick();
                        break;
                    case Keys.F10:
                        tsbExit.PerformClick();
                        break;
                }
            }
        }
        #endregion
    }
}
