﻿namespace Doit.Print.Test
{
    partial class FormMaint
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuTest_GEO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCellStyleDesigner = new System.Windows.Forms.ToolStripButton();
            this.btnGDI = new System.Windows.Forms.ToolStripButton();
            this.btnGEO = new System.Windows.Forms.ToolStripButton();
            this.menuTest_CellStyleDesginer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTest_GDI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTest});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1180, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile_Exit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(58, 21);
            this.menuFile.Text = "文件(&F)";
            // 
            // menuFile_Exit
            // 
            this.menuFile_Exit.Name = "menuFile_Exit";
            this.menuFile_Exit.Size = new System.Drawing.Size(116, 22);
            this.menuFile_Exit.Text = "退出(&X)";
            this.menuFile_Exit.Click += new System.EventHandler(this.menuFile_Exit_Click);
            // 
            // menuTest
            // 
            this.menuTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTest_CellStyleDesginer,
            this.menuTest_GDI,
            this.menuTest_GEO});
            this.menuTest.Name = "menuTest";
            this.menuTest.Size = new System.Drawing.Size(59, 21);
            this.menuTest.Text = "测试(&T)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCellStyleDesigner,
            this.toolStripSeparator1,
            this.btnGDI,
            this.toolStripSeparator2,
            this.btnGEO});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1180, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 521);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1180, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(56, 17);
            this.lblInfo.Text = "状态信息";
            // 
            // menuTest_GEO
            // 
            this.menuTest_GEO.Image = global::Doit.Print.Test.Properties.Resources.GEO_16;
            this.menuTest_GEO.Name = "menuTest_GEO";
            this.menuTest_GEO.Size = new System.Drawing.Size(180, 22);
            this.menuTest_GEO.Text = "几何算法(&A)";
            this.menuTest_GEO.Click += new System.EventHandler(this.menuTest_GEO_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCellStyleDesigner
            // 
            this.btnCellStyleDesigner.Image = global::Doit.Print.Test.Properties.Resources.cell_16;
            this.btnCellStyleDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCellStyleDesigner.Name = "btnCellStyleDesigner";
            this.btnCellStyleDesigner.Size = new System.Drawing.Size(76, 22);
            this.btnCellStyleDesigner.Text = "单元样式";
            this.btnCellStyleDesigner.Click += new System.EventHandler(this.menuTest_CellStyleDesginer_Click);
            // 
            // btnGDI
            // 
            this.btnGDI.Image = global::Doit.Print.Test.Properties.Resources.ZoomAndMove_16;
            this.btnGDI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGDI.Name = "btnGDI";
            this.btnGDI.Size = new System.Drawing.Size(52, 22);
            this.btnGDI.Text = "绘图";
            this.btnGDI.Click += new System.EventHandler(this.menuTest_GDI_Click);
            // 
            // btnGEO
            // 
            this.btnGEO.Image = global::Doit.Print.Test.Properties.Resources.GEO_16;
            this.btnGEO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGEO.Name = "btnGEO";
            this.btnGEO.Size = new System.Drawing.Size(76, 22);
            this.btnGEO.Text = "几何算法";
            this.btnGEO.ToolTipText = "几何算法";
            this.btnGEO.Click += new System.EventHandler(this.menuTest_GEO_Click);
            // 
            // menuTest_CellStyleDesginer
            // 
            this.menuTest_CellStyleDesginer.Image = global::Doit.Print.Test.Properties.Resources.cell_16;
            this.menuTest_CellStyleDesginer.Name = "menuTest_CellStyleDesginer";
            this.menuTest_CellStyleDesginer.Size = new System.Drawing.Size(180, 22);
            this.menuTest_CellStyleDesginer.Text = "单元样式(&C)";
            this.menuTest_CellStyleDesginer.Click += new System.EventHandler(this.menuTest_CellStyleDesginer_Click);
            // 
            // menuTest_GDI
            // 
            this.menuTest_GDI.Image = global::Doit.Print.Test.Properties.Resources.ZoomAndMove_16;
            this.menuTest_GDI.Name = "menuTest_GDI";
            this.menuTest_GDI.Size = new System.Drawing.Size(180, 22);
            this.menuTest_GDI.Text = "绘图(&G)";
            this.menuTest_GDI.Click += new System.EventHandler(this.menuTest_GDI_Click);
            // 
            // FormMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 543);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMaint";
            this.Text = "打印支撑库测试";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMaint_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Exit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.ToolStripButton btnCellStyleDesigner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuTest;
        private System.Windows.Forms.ToolStripMenuItem menuTest_CellStyleDesginer;
        private System.Windows.Forms.ToolStripMenuItem menuTest_GDI;
        private System.Windows.Forms.ToolStripButton btnGDI;
        private System.Windows.Forms.ToolStripMenuItem menuTest_GEO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnGEO;
    }
}

