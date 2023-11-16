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
            this.cbDisk = new System.Windows.Forms.ComboBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.bBackward = new System.Windows.Forms.Button();
            this.bForward = new System.Windows.Forms.Button();
            this.lStats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvFiles
            // 
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            this.lvFiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.lvFiles.Location = new System.Drawing.Point(3, 73);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(545, 580);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 203;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 69;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date Modified";
            this.columnHeader4.Width = 92;
            // 
            // cbDisk
            // 
            this.cbDisk.FormattingEnabled = true;
            this.cbDisk.Location = new System.Drawing.Point(3, 17);
            this.cbDisk.Name = "cbDisk";
            this.cbDisk.Size = new System.Drawing.Size(121, 21);
            this.cbDisk.TabIndex = 1;
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(3, 44);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(545, 20);
            this.tbPath.TabIndex = 2;
            // 
            // bBackward
            // 
            this.bBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBackward.Location = new System.Drawing.Point(488, 17);
            this.bBackward.Name = "bBackward";
            this.bBackward.Size = new System.Drawing.Size(27, 21);
            this.bBackward.TabIndex = 3;
            this.bBackward.Text = "<";
            this.bBackward.UseVisualStyleBackColor = true;
            // 
            // bForward
            // 
            this.bForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bForward.Location = new System.Drawing.Point(521, 17);
            this.bForward.Name = "bForward";
            this.bForward.Size = new System.Drawing.Size(27, 21);
            this.bForward.TabIndex = 4;
            this.bForward.Text = ">";
            this.bForward.UseVisualStyleBackColor = true;
            // 
            // lStats
            // 
            this.lStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lStats.AutoSize = true;
            this.lStats.Location = new System.Drawing.Point(3, 661);
            this.lStats.Name = "lStats";
            this.lStats.Size = new System.Drawing.Size(31, 13);
            this.lStats.TabIndex = 5;
            this.lStats.Text = "Stats";
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
            this.Size = new System.Drawing.Size(551, 686);
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
    }
}
