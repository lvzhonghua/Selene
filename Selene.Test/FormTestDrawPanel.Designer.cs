
namespace Selene.Test
{
    partial class FormTestDrawPanel
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
            this.testDrawPanel1 = new Selene.Test.TestDrawPanel();
            this.SuspendLayout();
            // 
            // testDrawPanel1
            // 
            this.testDrawPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testDrawPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testDrawPanel1.Location = new System.Drawing.Point(102, 46);
            this.testDrawPanel1.Name = "testDrawPanel1";
            this.testDrawPanel1.Size = new System.Drawing.Size(601, 329);
            this.testDrawPanel1.TabIndex = 0;
            this.testDrawPanel1.SizeChanged += new System.EventHandler(this.testDrawPanel1_SizeChanged);
            this.testDrawPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.testDrawPanel1_Paint);
            // 
            // FormTestDrawPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testDrawPanel1);
            this.Name = "FormTestDrawPanel";
            this.Text = "FormTestDrawPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private TestDrawPanel testDrawPanel1;
    }
}