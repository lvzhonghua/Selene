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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panContainer = new System.Windows.Forms.Panel();
            this.panMindTree = new Doit.Controls.BufferedGraphicsPanel();
            this.tvNodeInSameLevel = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tvTest = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvTest);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.tvNodeInSameLevel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1227, 698);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 0;
            // 
            // panContainer
            // 
            this.panContainer.AutoScroll = true;
            this.panContainer.Controls.Add(this.panMindTree);
            this.panContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContainer.Location = new System.Drawing.Point(0, 0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(981, 696);
            this.panContainer.TabIndex = 0;
            // 
            // panMindTree
            // 
            this.panMindTree.Location = new System.Drawing.Point(3, 3);
            this.panMindTree.Name = "panMindTree";
            this.panMindTree.Size = new System.Drawing.Size(967, 682);
            this.panMindTree.TabIndex = 2;
            this.panMindTree.Paint += new System.Windows.Forms.PaintEventHandler(this.panMindTree_Paint);
            // 
            // tvNodeInSameLevel
            // 
            this.tvNodeInSameLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvNodeInSameLevel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tvNodeInSameLevel.Location = new System.Drawing.Point(0, 529);
            this.tvNodeInSameLevel.Name = "tvNodeInSameLevel";
            this.tvNodeInSameLevel.Size = new System.Drawing.Size(238, 167);
            this.tvNodeInSameLevel.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 525);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(238, 4);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // tvTest
            // 
            this.tvTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTest.Location = new System.Drawing.Point(0, 0);
            this.tvTest.Name = "tvTest";
            this.tvTest.Size = new System.Drawing.Size(238, 525);
            this.tvTest.TabIndex = 4;
            // 
            // FormDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 698);
            this.Controls.Add(this.splitContainer1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "FormDocument";
            this.Text = "文档";
            this.Load += new System.EventHandler(this.FormDocument_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panContainer;
        private Controls.BufferedGraphicsPanel panMindTree;
        private System.Windows.Forms.TreeView tvTest;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView tvNodeInSameLevel;
    }
}