namespace Doit.Print.Test
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
            this.panZoomAndMove = new Doit.Controls.BufferedGraphicsPanel();
            this.pGridSelected = new System.Windows.Forms.PropertyGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panString = new Doit.Controls.BufferedGraphicsPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panBesizer = new Doit.Controls.BufferedGraphicsPanel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panZoomAndMove);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pGridSelected);
            this.splitContainer1.Size = new System.Drawing.Size(1144, 550);
            this.splitContainer1.SplitterDistance = 925;
            this.splitContainer1.TabIndex = 1;
            // 
            // panZoomAndMove
            // 
            this.panZoomAndMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panZoomAndMove.Location = new System.Drawing.Point(0, 0);
            this.panZoomAndMove.Name = "panZoomAndMove";
            this.panZoomAndMove.Size = new System.Drawing.Size(923, 548);
            this.panZoomAndMove.TabIndex = 2;
            this.panZoomAndMove.Paint += new System.Windows.Forms.PaintEventHandler(this.panGDI_Paint);
            this.panZoomAndMove.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panGDI_MouseClick);
            this.panZoomAndMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panGDI_MouseDown);
            this.panZoomAndMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panGDI_MouseMove);
            this.panZoomAndMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panGDI_MouseUp);
            // 
            // pGridSelected
            // 
            this.pGridSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridSelected.Location = new System.Drawing.Point(0, 0);
            this.pGridSelected.Name = "pGridSelected";
            this.pGridSelected.Size = new System.Drawing.Size(213, 548);
            this.pGridSelected.TabIndex = 0;
            this.pGridSelected.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pGridSelected_PropertyValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1158, 582);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1150, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "缩放与平移";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panString);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1150, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "字符绘制";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panString
            // 
            this.panString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panString.Location = new System.Drawing.Point(3, 3);
            this.panString.Name = "panString";
            this.panString.Size = new System.Drawing.Size(1144, 550);
            this.panString.TabIndex = 0;
            this.panString.Paint += new System.Windows.Forms.PaintEventHandler(this.panString_Paint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panBesizer);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1150, 556);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "比萨尔曲线";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panBesizer
            // 
            this.panBesizer.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panBesizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBesizer.Location = new System.Drawing.Point(3, 3);
            this.panBesizer.Name = "panBesizer";
            this.panBesizer.Size = new System.Drawing.Size(1144, 550);
            this.panBesizer.TabIndex = 0;
            this.panBesizer.Paint += new System.Windows.Forms.PaintEventHandler(this.panBesizer_Paint);
            this.panBesizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panBesizer_MouseMove);
            // 
            // FormGDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 604);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormGDI";
            this.Text = "绘图测试";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Doit.Controls.BufferedGraphicsPanel panZoomAndMove;
        private System.Windows.Forms.PropertyGrid pGridSelected;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Doit.Controls.BufferedGraphicsPanel panString;
        private System.Windows.Forms.TabPage tabPage3;
        private Doit.Controls.BufferedGraphicsPanel panBesizer;
    }
}