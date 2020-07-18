namespace Doit.MindJet.Controls
{
    partial class MindTreeCtrl
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
            this.components = new System.ComponentModel.Container();
            this.panContainer = new System.Windows.Forms.Panel();
            this.panMindTree = new Doit.Controls.BufferedGraphicsPanel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAddSubNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.panContainer.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panContainer
            // 
            this.panContainer.AutoScroll = true;
            this.panContainer.Controls.Add(this.panMindTree);
            this.panContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContainer.Location = new System.Drawing.Point(0, 0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(770, 439);
            this.panContainer.TabIndex = 1;
            // 
            // panMindTree
            // 
            this.panMindTree.Location = new System.Drawing.Point(1, 1);
            this.panMindTree.Name = "panMindTree";
            this.panMindTree.Size = new System.Drawing.Size(719, 402);
            this.panMindTree.TabIndex = 3;
            this.panMindTree.Paint += new System.Windows.Forms.PaintEventHandler(this.panMindTree_Paint);
            this.panMindTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panMindTree_MouseClick);
            this.panMindTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panMindTree_MouseDoubleClick);
            this.panMindTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panMindTree_MouseMove);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddSubNode,
            this.menuDeleteNode,
            this.toolStripMenuItem1,
            this.menuAddNode});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(181, 98);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // menuAddSubNode
            // 
            this.menuAddSubNode.Image = global::Doit.MindJet.Controls.Properties.Resources.关联图元_16;
            this.menuAddSubNode.Name = "menuAddSubNode";
            this.menuAddSubNode.Size = new System.Drawing.Size(180, 22);
            this.menuAddSubNode.Text = "添加子节点(&A)";
            this.menuAddSubNode.Click += new System.EventHandler(this.menuAddSubNode_Click);
            // 
            // menuDeleteNode
            // 
            this.menuDeleteNode.Image = global::Doit.MindJet.Controls.Properties.Resources.delete_16;
            this.menuDeleteNode.Name = "menuDeleteNode";
            this.menuDeleteNode.Size = new System.Drawing.Size(180, 22);
            this.menuDeleteNode.Text = "删除当前节点(&D)";
            this.menuDeleteNode.Click += new System.EventHandler(this.menuDeleteNode_Click);
            // 
            // menuAddNode
            // 
            this.menuAddNode.Image = global::Doit.MindJet.Controls.Properties.Resources.子级_16;
            this.menuAddNode.Name = "menuAddNode";
            this.menuAddNode.Size = new System.Drawing.Size(180, 22);
            this.menuAddNode.Text = "添加同级节点(&S)";
            this.menuAddNode.Click += new System.EventHandler(this.menuAddNode_Click);
            // 
            // MindTreeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panContainer);
            this.Name = "MindTreeCtrl";
            this.Size = new System.Drawing.Size(770, 439);
            this.Load += new System.EventHandler(this.MindTreeCtrl_Load);
            this.panContainer.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panContainer;
        private Doit.Controls.BufferedGraphicsPanel panMindTree;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAddSubNode;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuAddNode;
    }
}
