﻿namespace Doit.Print.Test
{
    partial class FormGDI
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panGDI = new System.Windows.Forms.Panel();
            this.pGridSelected = new System.Windows.Forms.PropertyGrid();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1158, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
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
            this.splitContainer1.Panel1.Controls.Add(this.panGDI);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pGridSelected);
            this.splitContainer1.Size = new System.Drawing.Size(1158, 582);
            this.splitContainer1.SplitterDistance = 937;
            this.splitContainer1.TabIndex = 1;
            // 
            // panGDI
            // 
            this.panGDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGDI.Location = new System.Drawing.Point(0, 0);
            this.panGDI.Name = "panGDI";
            this.panGDI.Size = new System.Drawing.Size(935, 580);
            this.panGDI.TabIndex = 2;
            this.panGDI.Paint += new System.Windows.Forms.PaintEventHandler(this.panGDI_Paint);
            this.panGDI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panGDI_MouseDown);
            this.panGDI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panGDI_MouseMove);
            this.panGDI.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panGDI_MouseUp);
            // 
            // pGridSelected
            // 
            this.pGridSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridSelected.Location = new System.Drawing.Point(0, 0);
            this.pGridSelected.Name = "pGridSelected";
            this.pGridSelected.Size = new System.Drawing.Size(215, 580);
            this.pGridSelected.TabIndex = 0;
            // 
            // FormGDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 604);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormGDI";
            this.Text = "绘图测试";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panGDI;
        private System.Windows.Forms.PropertyGrid pGridSelected;
    }
}