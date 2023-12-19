namespace ExplorerProMax.UI
{
    partial class EditEntity
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bApply = new System.Windows.Forms.Button();
            this.cbAttributeReadOnly = new System.Windows.Forms.CheckBox();
            this.cbAttributeHidden = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAttributeSystem = new System.Windows.Forms.CheckBox();
            this.cbAttributeDirectory = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(12, 64);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(287, 23);
            this.tbName.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(12, 215);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(139, 47);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Скасувати";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bApply
            // 
            this.bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bApply.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bApply.Location = new System.Drawing.Point(160, 215);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(139, 47);
            this.bApply.TabIndex = 2;
            this.bApply.Text = "Застосувати";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // cbAttributeReadOnly
            // 
            this.cbAttributeReadOnly.AutoSize = true;
            this.cbAttributeReadOnly.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAttributeReadOnly.Location = new System.Drawing.Point(12, 138);
            this.cbAttributeReadOnly.Name = "cbAttributeReadOnly";
            this.cbAttributeReadOnly.Size = new System.Drawing.Size(257, 19);
            this.cbAttributeReadOnly.TabIndex = 3;
            this.cbAttributeReadOnly.Text = "Тільки для читання Read-Only (RO)";
            this.cbAttributeReadOnly.UseVisualStyleBackColor = true;
            // 
            // cbAttributeHidden
            // 
            this.cbAttributeHidden.AutoSize = true;
            this.cbAttributeHidden.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAttributeHidden.Location = new System.Drawing.Point(12, 161);
            this.cbAttributeHidden.Name = "cbAttributeHidden";
            this.cbAttributeHidden.Size = new System.Drawing.Size(173, 19);
            this.cbAttributeHidden.TabIndex = 4;
            this.cbAttributeHidden.Text = "Прихований Hidden (H)";
            this.cbAttributeHidden.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Назва";
            // 
            // cbAttributeSystem
            // 
            this.cbAttributeSystem.AutoSize = true;
            this.cbAttributeSystem.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAttributeSystem.Location = new System.Drawing.Point(12, 184);
            this.cbAttributeSystem.Name = "cbAttributeSystem";
            this.cbAttributeSystem.Size = new System.Drawing.Size(166, 19);
            this.cbAttributeSystem.TabIndex = 6;
            this.cbAttributeSystem.Text = "Системний System (S)";
            this.cbAttributeSystem.UseVisualStyleBackColor = true;
            // 
            // cbAttributeDirectory
            // 
            this.cbAttributeDirectory.AutoSize = true;
            this.cbAttributeDirectory.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAttributeDirectory.Location = new System.Drawing.Point(12, 115);
            this.cbAttributeDirectory.Name = "cbAttributeDirectory";
            this.cbAttributeDirectory.Size = new System.Drawing.Size(194, 19);
            this.cbAttributeDirectory.TabIndex = 7;
            this.cbAttributeDirectory.Text = "Директорія Directory (D)";
            this.cbAttributeDirectory.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Атрибути";
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLocation.Location = new System.Drawing.Point(12, 20);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(0, 15);
            this.lLocation.TabIndex = 9;
            // 
            // EditEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 274);
            this.Controls.Add(this.lLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAttributeDirectory);
            this.Controls.Add(this.cbAttributeSystem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAttributeHidden);
            this.Controls.Add(this.cbAttributeReadOnly);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditEntity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.CheckBox cbAttributeReadOnly;
        private System.Windows.Forms.CheckBox cbAttributeHidden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAttributeSystem;
        private System.Windows.Forms.CheckBox cbAttributeDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lLocation;
    }
}