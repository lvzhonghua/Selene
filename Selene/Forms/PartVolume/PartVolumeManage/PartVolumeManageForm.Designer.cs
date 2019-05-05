namespace Selene.Forms.PartVolume.PartVolumeManage
{
    partial class PartVolumeManageForm
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
            this.btnAddPartVolume = new System.Windows.Forms.Button();
            this.btnEditPartVolume = new System.Windows.Forms.Button();
            this.btnDeletePartVolume = new System.Windows.Forms.Button();
            this.btnUpMove = new System.Windows.Forms.Button();
            this.btnDownMove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvPartVolume = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNeedCatalogue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCheatSheets = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnAddPartVolume
            // 
            this.btnAddPartVolume.Location = new System.Drawing.Point(378, 12);
            this.btnAddPartVolume.Name = "btnAddPartVolume";
            this.btnAddPartVolume.Size = new System.Drawing.Size(94, 23);
            this.btnAddPartVolume.TabIndex = 1;
            this.btnAddPartVolume.Text = "添加分卷";
            this.btnAddPartVolume.UseVisualStyleBackColor = true;
            this.btnAddPartVolume.Click += new System.EventHandler(this.btnAddPartVolume_Click);
            // 
            // btnEditPartVolume
            // 
            this.btnEditPartVolume.Location = new System.Drawing.Point(378, 45);
            this.btnEditPartVolume.Name = "btnEditPartVolume";
            this.btnEditPartVolume.Size = new System.Drawing.Size(94, 23);
            this.btnEditPartVolume.TabIndex = 2;
            this.btnEditPartVolume.Text = "修改分卷信息";
            this.btnEditPartVolume.UseVisualStyleBackColor = true;
            this.btnEditPartVolume.Click += new System.EventHandler(this.btnEditPartVolume_Click);
            // 
            // btnDeletePartVolume
            // 
            this.btnDeletePartVolume.Location = new System.Drawing.Point(378, 77);
            this.btnDeletePartVolume.Name = "btnDeletePartVolume";
            this.btnDeletePartVolume.Size = new System.Drawing.Size(94, 23);
            this.btnDeletePartVolume.TabIndex = 3;
            this.btnDeletePartVolume.Text = "删除分卷";
            this.btnDeletePartVolume.UseVisualStyleBackColor = true;
            this.btnDeletePartVolume.Click += new System.EventHandler(this.btnDeletePartVolume_Click);
            // 
            // btnUpMove
            // 
            this.btnUpMove.Location = new System.Drawing.Point(378, 201);
            this.btnUpMove.Name = "btnUpMove";
            this.btnUpMove.Size = new System.Drawing.Size(94, 23);
            this.btnUpMove.TabIndex = 4;
            this.btnUpMove.Text = "上移";
            this.btnUpMove.UseVisualStyleBackColor = true;
            this.btnUpMove.Click += new System.EventHandler(this.btnUpMove_Click);
            // 
            // btnDownMove
            // 
            this.btnDownMove.Location = new System.Drawing.Point(378, 233);
            this.btnDownMove.Name = "btnDownMove";
            this.btnDownMove.Size = new System.Drawing.Size(94, 23);
            this.btnDownMove.TabIndex = 5;
            this.btnDownMove.Text = "下移";
            this.btnDownMove.UseVisualStyleBackColor = true;
            this.btnDownMove.Click += new System.EventHandler(this.btnDownMove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(378, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvPartVolume
            // 
            this.lvPartVolume.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chStartIndex,
            this.chNeedCatalogue,
            this.chCheatSheets});
            this.lvPartVolume.FullRowSelect = true;
            this.lvPartVolume.GridLines = true;
            this.lvPartVolume.Location = new System.Drawing.Point(9, 12);
            this.lvPartVolume.MultiSelect = false;
            this.lvPartVolume.Name = "lvPartVolume";
            this.lvPartVolume.Size = new System.Drawing.Size(360, 380);
            this.lvPartVolume.TabIndex = 8;
            this.lvPartVolume.UseCompatibleStateImageBehavior = false;
            this.lvPartVolume.View = System.Windows.Forms.View.Details;
            this.lvPartVolume.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPartVolume_MouseDoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "卷名";
            this.chName.Width = 130;
            // 
            // chStartIndex
            // 
            this.chStartIndex.Text = "起始页";
            this.chStartIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chNeedCatalogue
            // 
            this.chNeedCatalogue.Text = "需要目录";
            this.chNeedCatalogue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chNeedCatalogue.Width = 65;
            // 
            // chCheatSheets
            // 
            this.chCheatSheets.Text = "需要速查表";
            this.chCheatSheets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCheatSheets.Width = 93;
            // 
            // PartVolumeManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 397);
            this.Controls.Add(this.lvPartVolume);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDownMove);
            this.Controls.Add(this.btnUpMove);
            this.Controls.Add(this.btnDeletePartVolume);
            this.Controls.Add(this.btnEditPartVolume);
            this.Controls.Add(this.btnAddPartVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartVolumeManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分卷管理";
            this.Load += new System.EventHandler(this.PartVolumeManageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddPartVolume;
        private System.Windows.Forms.Button btnEditPartVolume;
        private System.Windows.Forms.Button btnDeletePartVolume;
        private System.Windows.Forms.Button btnUpMove;
        private System.Windows.Forms.Button btnDownMove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvPartVolume;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chStartIndex;
        private System.Windows.Forms.ColumnHeader chNeedCatalogue;
        private System.Windows.Forms.ColumnHeader chCheatSheets;
    }
}