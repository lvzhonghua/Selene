namespace Doit.MindJet.Tool
{
    partial class FormMindTree
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
            this.mindTreeCtrl = new Doit.MindJet.Controls.MindTreeCtrl();
            this.SuspendLayout();
            // 
            // mindTreeCtrl
            // 
            this.mindTreeCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mindTreeCtrl.Location = new System.Drawing.Point(0, 0);
            this.mindTreeCtrl.Name = "mindTreeCtrl";
            this.mindTreeCtrl.Size = new System.Drawing.Size(1227, 698);
            this.mindTreeCtrl.TabIndex = 1;
            // 
            // FormMindTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 698);
            this.Controls.Add(this.mindTreeCtrl);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "FormMindTree";
            this.Text = "脑图文档";
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.MindTreeCtrl mindTreeCtrl;
    }
}