namespace Doit.MindJet.Tool
{
    partial class FormMindFlow
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
            this.mindFlowCtrl = new Doit.MindJet.Controls.MindFlowCtrl();
            this.SuspendLayout();
            // 
            // mindFlowCtrl
            // 
            this.mindFlowCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mindFlowCtrl.Location = new System.Drawing.Point(0, 0);
            this.mindFlowCtrl.Name = "mindFlowCtrl";
            this.mindFlowCtrl.Size = new System.Drawing.Size(1015, 568);
            this.mindFlowCtrl.TabIndex = 0;
            // 
            // FormMindFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 568);
            this.Controls.Add(this.mindFlowCtrl);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "FormMindFlow";
            this.Text = "思维流程文档";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MindFlowCtrl mindFlowCtrl;
    }
}