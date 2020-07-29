namespace Doit.MindJet.Tool
{
    partial class FormMindDraft
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
            this.mindDraftCtrl = new Doit.MindJet.Controls.MindDraftCtrl();
            this.SuspendLayout();
            // 
            // mindDraftCtrl
            // 
            this.mindDraftCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mindDraftCtrl.Location = new System.Drawing.Point(0, 0);
            this.mindDraftCtrl.Name = "mindDraftCtrl";
            this.mindDraftCtrl.Size = new System.Drawing.Size(800, 450);
            this.mindDraftCtrl.TabIndex = 0;
            // 
            // FormMindDraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mindDraftCtrl);
            this.Name = "FormMindDraft";
            this.Text = "草图";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MindDraftCtrl mindDraftCtrl;
    }
}