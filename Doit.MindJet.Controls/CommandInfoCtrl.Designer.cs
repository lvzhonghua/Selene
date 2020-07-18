namespace Doit.MindJet.Controls
{
    partial class CommandInfoCtrl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblExecuteTime = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tablePanel.ColumnCount = 2;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.Controls.Add(this.lblExecuteTime, 1, 1);
            this.tablePanel.Controls.Add(this.picImage, 0, 0);
            this.tablePanel.Controls.Add(this.lblDescription, 1, 0);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 2;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.Size = new System.Drawing.Size(200, 50);
            this.tablePanel.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Location = new System.Drawing.Point(53, 1);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(143, 23);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "指令描述";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExecuteTime
            // 
            this.lblExecuteTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExecuteTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExecuteTime.Location = new System.Drawing.Point(53, 25);
            this.lblExecuteTime.Name = "lblExecuteTime";
            this.lblExecuteTime.Size = new System.Drawing.Size(143, 24);
            this.lblExecuteTime.TabIndex = 2;
            this.lblExecuteTime.Text = "时间";
            this.lblExecuteTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(4, 4);
            this.picImage.Name = "picImage";
            this.tablePanel.SetRowSpan(this.picImage, 2);
            this.picImage.Size = new System.Drawing.Size(42, 42);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // CommandInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel);
            this.MinimumSize = new System.Drawing.Size(200, 50);
            this.Name = "CommandInfoCtrl";
            this.Size = new System.Drawing.Size(200, 50);
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.Label lblExecuteTime;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblDescription;
    }
}
