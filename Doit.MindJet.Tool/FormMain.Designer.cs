namespace Doit.MindJet.Tool
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1183, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dockPanel
            // 
            this.dockPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 25);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1183, 646);
            this.dockPanel.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 671);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "脑图工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
    }
}

