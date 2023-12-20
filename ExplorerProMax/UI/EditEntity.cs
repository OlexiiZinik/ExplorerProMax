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

            if (entity is FileEntity)
            {
                Text = $"Редагування файлу {entity.FullPath}";
                tbName.Text = (entity as FileEntity).FullName;
                cbAttributeDirectory.Checked = false;
                cbAttributeReadOnly.Checked = (entity as FileEntity).Attributes.HasFlag(FileAttributes.ReadOnly);
                cbAttributeHidden.Checked = (entity as FileEntity).Attributes.HasFlag(FileAttributes.Hidden);
                cbAttributeSystem.Checked = (entity as FileEntity).Attributes.HasFlag(FileAttributes.System);
            }
            else if (entity is DirectoryEntity)
            {
                Text = $"Редагування каталогу {entity.FullPath}";
                tbName.Text = (entity as DirectoryEntity).Name;
                cbAttributeDirectory.Checked = true;
                cbAttributeReadOnly.Checked = (entity as DirectoryEntity).Attributes.HasFlag(FileAttributes.ReadOnly);
                cbAttributeHidden.Checked = (entity as DirectoryEntity).Attributes.HasFlag(FileAttributes.Hidden);
                cbAttributeSystem.Checked = (entity as DirectoryEntity).Attributes.HasFlag(FileAttributes.System);
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
            FileAttributes attributes = 0;
            if (cbAttributeReadOnly.Checked) attributes |= FileAttributes.ReadOnly;
            if (cbAttributeHidden.Checked) attributes |= FileAttributes.Hidden;
            if (cbAttributeSystem.Checked) attributes |= FileAttributes.System;

            if (CurrentWorkingEntity is FileEntity)
            {
                attributes &= ~FileAttributes.Directory;
                Explorer.RenameEntity(CurrentWorkingEntity, tbName.Text, attributes);
                Close();
                return;
            }
            else if (CurrentWorkingEntity is DirectoryEntity)
            {
                attributes |= FileAttributes.Directory;
                Explorer.RenameEntity(CurrentWorkingEntity, tbName.Text, attributes);
                Close();
                return;
            }

            switch (Options)
            {
                case EditEntityOptions.CREATE_FILE:
                    attributes &= ~FileAttributes.Directory;
                    Explorer.CreateFile(tbName.Text, attributes);
                    break;
                case EditEntityOptions.CREATE_DIRECTORY:
                    attributes |= FileAttributes.Directory;
                    Explorer.CreateDirectory(tbName.Text, attributes);
                    break;
            }
            

            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
