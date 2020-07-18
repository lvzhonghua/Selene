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
            this.panContainer = new System.Windows.Forms.Panel();
            this.panMindTree = new Doit.Controls.BufferedGraphicsPanel();
            this.panContainer.SuspendLayout();
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panContainer;
        private Controls.BufferedGraphicsPanel panMindTree;
    }
}