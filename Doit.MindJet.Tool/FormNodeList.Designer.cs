namespace Doit.MindJet.Tool
{
    partial class FormNodeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNodeList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvTree = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tvNodeInSameLevel = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvNodeInSameLevel);
            this.splitContainer1.Size = new System.Drawing.Size(290, 577);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvTree
            // 
            this.tvTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTree.ImageIndex = 0;
            this.tvTree.ImageList = this.imgList;
            this.tvTree.Location = new System.Drawing.Point(0, 0);
            this.tvTree.Name = "tvTree";
            this.tvTree.SelectedImageIndex = 0;
            this.tvTree.Size = new System.Drawing.Size(288, 406);
            this.tvTree.TabIndex = 4;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "selected_16.png");
            this.imgList.Images.SetKeyName(1, "node-tree_16.png");
            this.imgList.Images.SetKeyName(2, "子级_16.png");
            this.imgList.Images.SetKeyName(3, "节点_16.png");
            // 
            // tvNodeInSameLevel
            // 
            this.tvNodeInSameLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvNodeInSameLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNodeInSameLevel.ImageIndex = 0;
            this.tvNodeInSameLevel.ImageList = this.imgList;
            this.tvNodeInSameLevel.Location = new System.Drawing.Point(0, 0);
            this.tvNodeInSameLevel.Name = "tvNodeInSameLevel";
            this.tvNodeInSameLevel.SelectedImageIndex = 0;
            this.tvNodeInSameLevel.Size = new System.Drawing.Size(288, 163);
            this.tvNodeInSameLevel.TabIndex = 2;
            // 
            // FormNodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 577);
            this.Controls.Add(this.splitContainer1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Name = "FormNodeList";
            this.Text = "节点";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvTree;
        private System.Windows.Forms.TreeView tvNodeInSameLevel;
        private System.Windows.Forms.ImageList imgList;
    }
}