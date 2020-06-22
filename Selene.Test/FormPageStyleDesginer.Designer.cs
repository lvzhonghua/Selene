namespace Selene.Test
{
    partial class FormPageStyleDesginer
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
            this.pageStyleDesginerCtrl = new Selene.Control.PageStyleDesginerCtrl();
            this.SuspendLayout();
            // 
            // pageStyleDesginerCtrl
            // 
            this.pageStyleDesginerCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageStyleDesginerCtrl.Location = new System.Drawing.Point(0, 0);
            this.pageStyleDesginerCtrl.Name = "pageStyleDesginerCtrl";
            this.pageStyleDesginerCtrl.Size = new System.Drawing.Size(800, 450);
            this.pageStyleDesginerCtrl.TabIndex = 0;
            // 
            // FormPageStyleDesginer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pageStyleDesginerCtrl);
            this.Name = "FormPageStyleDesginer";
            this.Text = "页面样式";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.PageStyleDesginerCtrl pageStyleDesginerCtrl;
    }
}