namespace Doit.Print.Test
{
    partial class FormCellStyleDesigner
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
            this.cellStyleDesigner = new Doit.Print.Controls.CellStyleDesignerCtrl();
            this.SuspendLayout();
            // 
            // cellStyleDesigner
            // 
            this.cellStyleDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cellStyleDesigner.Location = new System.Drawing.Point(0, 0);
            this.cellStyleDesigner.Name = "cellStyleDesigner";
            this.cellStyleDesigner.Size = new System.Drawing.Size(1236, 681);
            this.cellStyleDesigner.TabIndex = 0;
            // 
            // FormCellStyleDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 681);
            this.Controls.Add(this.cellStyleDesigner);
            this.Name = "FormCellStyleDesigner";
            this.Text = "单元样式设计";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CellStyleDesignerCtrl cellStyleDesigner;
    }
}