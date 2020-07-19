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
            this.contextMenuDo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuUndo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAddSubNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearCommandStack = new System.Windows.Forms.ToolStripMenuItem();
            this.panContainer.SuspendLayout();
            this.contextMenuDo.SuspendLayout();
            this.contextMenuUndo.SuspendLayout();
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
            this.panMindTree.Size = new System.Drawing.Size(735, 421);
            this.panMindTree.TabIndex = 3;
            this.panMindTree.Paint += new System.Windows.Forms.PaintEventHandler(this.panMindTree_Paint);
            this.panMindTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panMindTree_MouseClick);
            this.panMindTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panMindTree_MouseDoubleClick);
            this.panMindTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panMindTree_MouseMove);
            // 
            // contextMenuDo
            // 
            this.contextMenuDo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddSubNode,
            this.menuDeleteNode,
            this.toolStripMenuItem1,
            this.menuAddNode});
            this.contextMenuDo.Name = "contextMenu";
            this.contextMenuDo.Size = new System.Drawing.Size(166, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // contextMenuUndo
            // 
            this.contextMenuUndo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUndo,
            this.menuRedo,
            this.toolStripMenuItem2,
            this.menuClearCommandStack});
            this.contextMenuUndo.Name = "contextMenuUndo";
            this.contextMenuUndo.Size = new System.Drawing.Size(165, 76);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // menuAddSubNode
            // 
            this.menuAddSubNode.Image = global::Doit.MindJet.Controls.Properties.Resources.关联图元_16;
            this.menuAddSubNode.Name = "menuAddSubNode";
            this.menuAddSubNode.Size = new System.Drawing.Size(165, 22);
            this.menuAddSubNode.Text = "添加子节点(&A)";
            this.menuAddSubNode.Click += new System.EventHandler(this.menuAddSubNode_Click);
            // 
            // menuDeleteNode
            // 
            this.menuDeleteNode.Image = global::Doit.MindJet.Controls.Properties.Resources.delete_16;
            this.menuDeleteNode.Name = "menuDeleteNode";
            this.menuDeleteNode.Size = new System.Drawing.Size(165, 22);
            this.menuDeleteNode.Text = "删除当前节点(&D)";
            this.menuDeleteNode.Click += new System.EventHandler(this.menuDeleteNode_Click);
            // 
            // menuAddNode
            // 
            this.menuAddNode.Image = global::Doit.MindJet.Controls.Properties.Resources.子级_16;
            this.menuAddNode.Name = "menuAddNode";
            this.menuAddNode.Size = new System.Drawing.Size(165, 22);
            this.menuAddNode.Text = "添加同级节点(&S)";
            this.menuAddNode.Click += new System.EventHandler(this.menuAddNode_Click);
            // 
            // menuUndo
            // 
            this.menuUndo.Image = global::Doit.MindJet.Controls.Properties.Resources.撤销_16;
            this.menuUndo.Name = "menuUndo";
            this.menuUndo.Size = new System.Drawing.Size(164, 22);
            this.menuUndo.Text = "撤销(&U)";
            this.menuUndo.Click += new System.EventHandler(this.menuUndo_Click);
            // 
            // menuRedo
            // 
            this.menuRedo.Image = global::Doit.MindJet.Controls.Properties.Resources.重做_16;
            this.menuRedo.Name = "menuRedo";
            this.menuRedo.Size = new System.Drawing.Size(164, 22);
            this.menuRedo.Text = "重做(&R)";
            this.menuRedo.Click += new System.EventHandler(this.menuRedo_Click);
            // 
            // menuClearCommandStack
            // 
            this.menuClearCommandStack.Image = global::Doit.MindJet.Controls.Properties.Resources.清空_16;
            this.menuClearCommandStack.Name = "menuClearCommandStack";
            this.menuClearCommandStack.Size = new System.Drawing.Size(164, 22);
            this.menuClearCommandStack.Text = "清空操作历史(&C)";
            this.menuClearCommandStack.Click += new System.EventHandler(this.menuClearCommandStack_Click);
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
            this.contextMenuDo.ResumeLayout(false);
            this.contextMenuUndo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panContainer;
        private Doit.Controls.BufferedGraphicsPanel panMindTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuDo;
        private System.Windows.Forms.ToolStripMenuItem menuAddSubNode;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuAddNode;
        private System.Windows.Forms.ContextMenuStrip contextMenuUndo;
        private System.Windows.Forms.ToolStripMenuItem menuUndo;
        private System.Windows.Forms.ToolStripMenuItem menuRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuClearCommandStack;
    }
}
