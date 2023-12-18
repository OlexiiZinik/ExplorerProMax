﻿namespace ExplorerProMax.UI.Components
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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "123",
            "asd",
            "fgh",
            "gjh",
            "cvb"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("321");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "222",
            "asd"}, -1);
            this.lvFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.cbDisk = new System.Windows.Forms.ComboBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.bBackward = new System.Windows.Forms.Button();
            this.bForward = new System.Windows.Forms.Button();
            this.lStats = new System.Windows.Forms.Label();
            this.fswObserver = new System.IO.FileSystemWatcher();
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
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            this.lvFiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.lvFiles.LabelEdit = true;
            this.lvFiles.LargeImageList = this.ilIcons;
            this.lvFiles.Location = new System.Drawing.Point(3, 31);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(597, 631);
            this.lvFiles.SmallImageList = this.ilIcons;
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
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
            // ilIcons
            // 
            this.ilIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cbDisk
            // 
            this.cbDisk.Location = new System.Drawing.Point(3, 4);
            this.cbDisk.Name = "cbDisk";
            this.cbDisk.Size = new System.Drawing.Size(115, 21);
            this.cbDisk.TabIndex = 1;
            this.cbDisk.TabStop = false;
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
            // lStats
            // 
            this.lStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lStats.AutoSize = true;
            this.lStats.Location = new System.Drawing.Point(3, 665);
            this.lStats.Name = "lStats";
            this.lStats.Size = new System.Drawing.Size(31, 13);
            this.lStats.TabIndex = 5;
            this.lStats.Text = "Stats";
            // 
            // fswObserver
            // 
            this.fswObserver.SynchronizingObject = this;
            this.fswObserver.Changed += new System.IO.FileSystemEventHandler(this.fswObserver_Changed);
            this.fswObserver.Created += new System.IO.FileSystemEventHandler(this.fswObserver_Changed);
            this.fswObserver.Deleted += new System.IO.FileSystemEventHandler(this.fswObserver_Changed);
            this.fswObserver.Renamed += new System.IO.RenamedEventHandler(this.fswObserver_Renamed);
            // 
            // FolderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lStats);
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
        private System.Windows.Forms.Label lStats;
        private System.Windows.Forms.ImageList ilIcons;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.IO.FileSystemWatcher fswObserver;
    }
}
