namespace Doit.MindJet.Tool
{
    partial class FormDocument
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
            this.panContainer.Size = new System.Drawing.Size(1227, 698);
            this.panContainer.TabIndex = 0;
            // 
            // panMindTree
            // 
            this.panMindTree.Location = new System.Drawing.Point(3, 3);
            this.panMindTree.Name = "panMindTree";
            this.panMindTree.Size = new System.Drawing.Size(1212, 692);
            this.panMindTree.TabIndex = 2;
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
            this.contextMenu.Size = new System.Drawing.Size(166, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // menuAddSubNode
            // 
            this.menuAddSubNode.Image = global::Doit.MindJet.Tool.Properties.Resources.关联图元_16;
            this.menuAddSubNode.Name = "menuAddSubNode";
            this.menuAddSubNode.Size = new System.Drawing.Size(165, 22);
            this.menuAddSubNode.Text = "添加子节点(&A)";
            this.menuAddSubNode.Click += new System.EventHandler(this.menuAddSubNode_Click);
            // 
            // menuDeleteNode
            // 
            this.menuDeleteNode.Image = global::Doit.MindJet.Tool.Properties.Resources.delete_16;
            this.menuDeleteNode.Name = "menuDeleteNode";
            this.menuDeleteNode.Size = new System.Drawing.Size(165, 22);
            this.menuDeleteNode.Text = "删除当前节点(&D)";
            this.menuDeleteNode.Click += new System.EventHandler(this.menuDeleteNode_Click);
            // 
            // menuAddNode
            // 
            this.menuAddNode.Image = global::Doit.MindJet.Tool.Properties.Resources.子级_16;
            this.menuAddNode.Name = "menuAddNode";
            this.menuAddNode.Size = new System.Drawing.Size(165, 22);
            this.menuAddNode.Text = "添加同级节点(&S)";
            this.menuAddNode.Click += new System.EventHandler(this.menuAddNode_Click);
            // 
            // FormDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 698);
            this.Controls.Add(this.panContainer);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "FormDocument";
            this.Text = "文档";
            this.Load += new System.EventHandler(this.FormDocument_Load);
            this.panContainer.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panContainer;
        private Controls.BufferedGraphicsPanel panMindTree;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAddSubNode;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuAddNode;
    }
}