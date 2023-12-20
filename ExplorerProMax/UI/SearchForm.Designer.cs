namespace ExplorerProMax.UI
{
    partial class SearchForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbTemplate = new System.Windows.Forms.TextBox();
            this.lLocation = new System.Windows.Forms.Label();
            this.bSearch = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbIncludeSubDirectories = new System.Windows.Forms.CheckBox();
            this.cbStrictSearch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Назва";
            // 
            // tbTemplate
            // 
            this.tbTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTemplate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTemplate.Location = new System.Drawing.Point(12, 60);
            this.tbTemplate.Name = "tbTemplate";
            this.tbTemplate.Size = new System.Drawing.Size(271, 23);
            this.tbTemplate.TabIndex = 6;
            this.tbTemplate.Text = "*.*";
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLocation.Location = new System.Drawing.Point(12, 9);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(0, 15);
            this.lLocation.TabIndex = 10;
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSearch.Location = new System.Drawing.Point(160, 158);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(124, 47);
            this.bSearch.TabIndex = 12;
            this.bSearch.Text = "Застосувати";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(12, 158);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(124, 47);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Скасувати";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cbIncludeSubDirectories
            // 
            this.cbIncludeSubDirectories.AutoSize = true;
            this.cbIncludeSubDirectories.Checked = true;
            this.cbIncludeSubDirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncludeSubDirectories.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIncludeSubDirectories.Location = new System.Drawing.Point(12, 89);
            this.cbIncludeSubDirectories.Name = "cbIncludeSubDirectories";
            this.cbIncludeSubDirectories.Size = new System.Drawing.Size(187, 19);
            this.cbIncludeSubDirectories.TabIndex = 13;
            this.cbIncludeSubDirectories.Text = "Шукати в піддиректоріях";
            this.cbIncludeSubDirectories.UseVisualStyleBackColor = true;
            // 
            // cbStrictSearch
            // 
            this.cbStrictSearch.AutoSize = true;
            this.cbStrictSearch.Checked = true;
            this.cbStrictSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStrictSearch.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStrictSearch.Location = new System.Drawing.Point(12, 114);
            this.cbStrictSearch.Name = "cbStrictSearch";
            this.cbStrictSearch.Size = new System.Drawing.Size(257, 19);
            this.cbStrictSearch.TabIndex = 14;
            this.cbStrictSearch.Text = "Суворий пошук (Співпадіння 1 в 1)";
            this.cbStrictSearch.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 217);
            this.Controls.Add(this.cbStrictSearch);
            this.Controls.Add(this.cbIncludeSubDirectories);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.lLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchForm";
            this.Text = "Пошук";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTemplate;
        private System.Windows.Forms.Label lLocation;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.CheckBox cbIncludeSubDirectories;
        private System.Windows.Forms.CheckBox cbStrictSearch;
    }
}