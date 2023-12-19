namespace ExplorerProMax.UI.Components
{
    partial class FolderWindow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderWindow));
            this.lvFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbDisk = new System.Windows.Forms.ComboBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.bBackward = new System.Windows.Forms.Button();
            this.bForward = new System.Windows.Forms.Button();
            this.fswObserver = new System.IO.FileSystemWatcher();
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fswObserver)).BeginInit();
            this.SuspendLayout();
            // 
            // lvFiles
            // 
            this.lvFiles.AllowColumnReorder = true;
            this.lvFiles.AllowDrop = true;
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.LabelEdit = true;
            this.lvFiles.LargeImageList = this.ilIcons;
            this.lvFiles.Location = new System.Drawing.Point(3, 31);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(597, 657);
            this.lvFiles.SmallImageList = this.ilIcons;
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragDrop);
            this.lvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            this.lvFiles.DragLeave += new System.EventHandler(this.lvFiles_DragLeave);
            this.lvFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFiles_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Назва";
            this.columnHeader1.Width = 203;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            this.columnHeader2.Width = 69;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Розмір";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Змінено";
            this.columnHeader4.Width = 92;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Атрибути";
            this.columnHeader5.Width = 75;
            // 
            // cbDisk
            // 
            this.cbDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisk.Location = new System.Drawing.Point(3, 4);
            this.cbDisk.Name = "cbDisk";
            this.cbDisk.Size = new System.Drawing.Size(115, 21);
            this.cbDisk.TabIndex = 1;
            this.cbDisk.TabStop = false;
            this.cbDisk.SelectedIndexChanged += new System.EventHandler(this.cbDisk_SelectedIndexChanged);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(127, 4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(409, 20);
            this.tbPath.TabIndex = 2;
            this.tbPath.TabStop = false;
            this.tbPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPath_KeyDown);
            this.tbPath.Leave += new System.EventHandler(this.tbPath_Leave);
            // 
            // bBackward
            // 
            this.bBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBackward.Location = new System.Drawing.Point(540, 4);
            this.bBackward.Name = "bBackward";
            this.bBackward.Size = new System.Drawing.Size(27, 21);
            this.bBackward.TabIndex = 3;
            this.bBackward.TabStop = false;
            this.bBackward.Text = "<";
            this.bBackward.UseVisualStyleBackColor = true;
            this.bBackward.Click += new System.EventHandler(this.bBackward_Click);
            // 
            // bForward
            // 
            this.bForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bForward.Location = new System.Drawing.Point(573, 4);
            this.bForward.Name = "bForward";
            this.bForward.Size = new System.Drawing.Size(27, 21);
            this.bForward.TabIndex = 4;
            this.bForward.TabStop = false;
            this.bForward.Text = ">";
            this.bForward.UseVisualStyleBackColor = true;
            this.bForward.Click += new System.EventHandler(this.bForward_Click);
            // 
            // fswObserver
            // 
            this.fswObserver.EnableRaisingEvents = true;
            this.fswObserver.SynchronizingObject = this;
            this.fswObserver.Changed += new System.IO.FileSystemEventHandler(this.fswObserver_Changed);
            this.fswObserver.Created += new System.IO.FileSystemEventHandler(this.fswObserver_Changed);
            this.fswObserver.Deleted += new System.IO.FileSystemEventHandler(this.fswObserver_Changed);
            this.fswObserver.Renamed += new System.IO.RenamedEventHandler(this.fswObserver_Renamed);
            // 
            // ilIcons
            // 
            this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcons.Images.SetKeyName(0, "Ex.png");
            this.ilIcons.Images.SetKeyName(1, "folder.ico");
            this.ilIcons.Images.SetKeyName(2, "prev.png");
            this.ilIcons.Images.SetKeyName(3, "imageres_32.ico");
            this.ilIcons.Images.SetKeyName(4, "imageres_36.ico");
            // 
            // FolderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bForward);
            this.Controls.Add(this.bBackward);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.cbDisk);
            this.Controls.Add(this.lvFiles);
            this.Name = "FolderWindow";
            this.Size = new System.Drawing.Size(603, 691);
            this.Load += new System.EventHandler(this.FolderWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fswObserver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox cbDisk;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button bBackward;
        private System.Windows.Forms.Button bForward;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.IO.FileSystemWatcher fswObserver;
        private System.Windows.Forms.ImageList ilIcons;
    }
}
