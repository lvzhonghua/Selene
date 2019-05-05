namespace Selene.Forms
{
    partial class DBToolForm
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
            this.lbDBInfo = new System.Windows.Forms.ListBox();
            this.lbTableInfo = new System.Windows.Forms.ListBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDBInfo
            // 
            this.lbDBInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDBInfo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDBInfo.FormattingEnabled = true;
            this.lbDBInfo.ItemHeight = 37;
            this.lbDBInfo.Location = new System.Drawing.Point(0, 0);
            this.lbDBInfo.Name = "lbDBInfo";
            this.lbDBInfo.Size = new System.Drawing.Size(306, 1172);
            this.lbDBInfo.TabIndex = 0;
            this.lbDBInfo.SelectedIndexChanged += new System.EventHandler(this.lbDBInfo_SelectedIndexChanged);
            // 
            // lbTableInfo
            // 
            this.lbTableInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTableInfo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableInfo.FormattingEnabled = true;
            this.lbTableInfo.ItemHeight = 37;
            this.lbTableInfo.Location = new System.Drawing.Point(306, 0);
            this.lbTableInfo.Name = "lbTableInfo";
            this.lbTableInfo.Size = new System.Drawing.Size(360, 1172);
            this.lbTableInfo.TabIndex = 1;
            this.lbTableInfo.SelectedIndexChanged += new System.EventHandler(this.lbTableInfo_SelectedIndexChanged);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(666, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 37;
            this.dgvMain.Size = new System.Drawing.Size(1342, 1172);
            this.dgvMain.TabIndex = 2;
            // 
            // DBToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2008, 1172);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.lbTableInfo);
            this.Controls.Add(this.lbDBInfo);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DBToolForm";
            this.Text = "本地数据工具";
            this.Load += new System.EventHandler(this.DBTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDBInfo;
        private System.Windows.Forms.ListBox lbTableInfo;
        private System.Windows.Forms.DataGridView dgvMain;

    }
}