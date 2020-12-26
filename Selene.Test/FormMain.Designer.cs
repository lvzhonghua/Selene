namespace Selene.Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTechTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTechTest_Lineage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTechTest_Paging = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTechTest_PageStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLineage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPaging = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPageStyle = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTechTest});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1157, 25);
            this.menuStrip1.TabIndex = 1;
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
            this.menuFile_Exit.Size = new System.Drawing.Size(115, 22);
            this.menuFile_Exit.Text = "退出(&E)";
            this.menuFile_Exit.Click += new System.EventHandler(this.menuFile_Exit_Click);
            // 
            // menuTechTest
            // 
            this.menuTechTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTechTest_Lineage,
            this.menuTechTest_Paging,
            this.menuTechTest_PageStyle});
            this.menuTechTest.Name = "menuTechTest";
            this.menuTechTest.Size = new System.Drawing.Size(95, 21);
            this.menuTechTest.Text = "技术点测试(&T)";
            // 
            // menuTechTest_Lineage
            // 
            this.menuTechTest_Lineage.Name = "menuTechTest_Lineage";
            this.menuTechTest_Lineage.Size = new System.Drawing.Size(139, 22);
            this.menuTechTest_Lineage.Text = "世系图(&L)";
            this.menuTechTest_Lineage.Click += new System.EventHandler(this.menuTechTest_Lineage_Click);
            // 
            // menuTechTest_Paging
            // 
            this.menuTechTest_Paging.Name = "menuTechTest_Paging";
            this.menuTechTest_Paging.Size = new System.Drawing.Size(139, 22);
            this.menuTechTest_Paging.Text = "分页算法(&P)";
            this.menuTechTest_Paging.Click += new System.EventHandler(this.menuTechTest_Paging_Click);
            // 
            // menuTechTest_PageStyle
            // 
            this.menuTechTest_PageStyle.Name = "menuTechTest_PageStyle";
            this.menuTechTest_PageStyle.Size = new System.Drawing.Size(139, 22);
            this.menuTechTest_PageStyle.Text = "样式设计(&S)";
            this.menuTechTest_PageStyle.Click += new System.EventHandler(this.menuTechTest_PageStyle_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLineage,
            this.toolStripSeparator1,
            this.btnPaging,
            this.toolStripSeparator2,
            this.btnPageStyle});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1157, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLineage
            // 
            this.btnLineage.Image = global::Selene.Test.Properties.Resources.树型_16;
            this.btnLineage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLineage.Name = "btnLineage";
            this.btnLineage.Size = new System.Drawing.Size(64, 22);
            this.btnLineage.Text = "世系图";
            this.btnLineage.Click += new System.EventHandler(this.menuTechTest_Lineage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPaging
            // 
            this.btnPaging.Image = ((System.Drawing.Image)(resources.GetObject("btnPaging.Image")));
            this.btnPaging.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaging.Name = "btnPaging";
            this.btnPaging.Size = new System.Drawing.Size(76, 22);
            this.btnPaging.Text = "分页算法";
            this.btnPaging.Click += new System.EventHandler(this.menuTechTest_Paging_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPageStyle
            // 
            this.btnPageStyle.Image = global::Selene.Test.Properties.Resources.style_16;
            this.btnPageStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPageStyle.Name = "btnPageStyle";
            this.btnPageStyle.Size = new System.Drawing.Size(76, 22);
            this.btnPageStyle.Text = "页面样式";
            this.btnPageStyle.Click += new System.EventHandler(this.menuTechTest_PageStyle_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 579);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "技术测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem menuTechTest;
        private System.Windows.Forms.ToolStripMenuItem menuTechTest_Lineage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLineage;
        private System.Windows.Forms.ToolStripMenuItem menuTechTest_Paging;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPaging;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuTechTest_PageStyle;
        private System.Windows.Forms.ToolStripButton btnPageStyle;
    }
}

