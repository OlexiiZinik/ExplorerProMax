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

namespace ExplorerProMax.UI
{
    public enum EditEntityOptions
    {
        CREATE_FILE,
        CREATE_DIRECTORY,
    }

    public partial class EditEntity : Form
    {
        public EditEntityOptions Options { get; private set; }
        public IPathEntity CurrentWorkingEntity { get; private set; }
        public FileExplorer Explorer { get; private set; }



        public EditEntity(FileExplorer explorer, EditEntityOptions editEntityOptions) : this(explorer)
        {
            Explorer = explorer;
            switch (editEntityOptions)
            {
                case EditEntityOptions.CREATE_FILE:
                    Text = $"Створення файлу у {explorer.CurrentWorkingDirectory.FullPath}";
                    cbAttributeDirectory.Checked = false;
                    break;
                case EditEntityOptions.CREATE_DIRECTORY:
                    Text = $"Створення каталогу у {explorer.CurrentWorkingDirectory.FullPath}";
                    cbAttributeDirectory.Checked = true;
                    break;

                default:
                    throw new ArgumentException("Specifi param entity to edit entity");
            }
            Options = editEntityOptions;

            lLocation.Text = explorer.CurrentWorkingDirectory.FullPath;
        }
        public EditEntity(FileExplorer explorer, IPathEntity entity) : this(explorer)
        {

            if (entity is FileInfo)
            {
                Text = $"Редагування файлу {entity.FullPath}";
                tbName.Text = (entity as FileInfo).FullName;
                cbAttributeDirectory.Checked = false;
                cbAttributeReadOnly.Checked = (entity as FileInfo).Attributes.HasFlag(System.IO.FileAttributes.ReadOnly);
                cbAttributeHidden.Checked = (entity as FileInfo).Attributes.HasFlag(System.IO.FileAttributes.Hidden);
                cbAttributeSystem.Checked = (entity as FileInfo).Attributes.HasFlag(System.IO.FileAttributes.System);
            }
            else if (entity is DirectoryInfo)
            {
                Text = $"Редагування каталогу {entity.FullPath}";
                tbName.Text = (entity as DirectoryInfo).Name;
                cbAttributeDirectory.Checked = true;
                cbAttributeReadOnly.Checked = (entity as DirectoryInfo).Attributes.HasFlag(System.IO.FileAttributes.ReadOnly);
                cbAttributeHidden.Checked = (entity as DirectoryInfo).Attributes.HasFlag(System.IO.FileAttributes.Hidden);
                cbAttributeSystem.Checked = (entity as DirectoryInfo).Attributes.HasFlag(System.IO.FileAttributes.System);
            }
            else
                throw new ArgumentException("Specifi param entity to edit entity");

            CurrentWorkingEntity = entity;

            lLocation.Text = entity.FullPath;
            
        }

        public EditEntity(FileExplorer explorer)
        {
            InitializeComponent();
            Explorer = explorer;
            cbAttributeDirectory.Enabled = false;
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            System.IO.FileAttributes attributes = 0;
            if (cbAttributeReadOnly.Checked) attributes |= System.IO.FileAttributes.ReadOnly;
            if (cbAttributeHidden.Checked) attributes |= System.IO.FileAttributes.Hidden;
            if (cbAttributeSystem.Checked) attributes |= System.IO.FileAttributes.System;

            if (CurrentWorkingEntity is FileInfo)
            {
                attributes &= ~System.IO.FileAttributes.Directory;
                Explorer.RenameEntity(CurrentWorkingEntity, tbName.Text, attributes);
                Close();
                return;
            }
            else if (CurrentWorkingEntity is DirectoryInfo)
            {
                attributes |= System.IO.FileAttributes.Directory;
                Explorer.RenameEntity(CurrentWorkingEntity, tbName.Text, attributes);
                Close();
                return;
            }

            switch (Options)
            {
                case EditEntityOptions.CREATE_FILE:
                    attributes &= ~System.IO.FileAttributes.Directory;
                    Explorer.CreateFile(tbName.Text, attributes);
                    break;
                case EditEntityOptions.CREATE_DIRECTORY:
                    attributes |= System.IO.FileAttributes.Directory;
                    Explorer.CreateDirectory(tbName.Text, attributes);
                    break;
            }
            

            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //public DialogResult ShowDialog()
        //{

        //}
    }
}
