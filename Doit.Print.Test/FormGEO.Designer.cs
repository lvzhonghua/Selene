namespace Doit.Print.Test
{
    partial class FormGEO
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkWidthFixed = new System.Windows.Forms.CheckBox();
            this.chkHeightFixed = new System.Windows.Forms.CheckBox();
            this.tbarWidth = new System.Windows.Forms.TrackBar();
            this.tbarHeight = new System.Windows.Forms.TrackBar();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.panContainer = new System.Windows.Forms.Panel();
            this.panGDI = new Doit.Print.Test.PanelGDI();
            this.lblException = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarHeight)).BeginInit();
            this.panContainer.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1367, 655);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblException);
            this.panel1.Controls.Add(this.btnFont);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.tbarHeight);
            this.panel1.Controls.Add(this.tbarWidth);
            this.panel1.Controls.Add(this.chkHeightFixed);
            this.panel1.Controls.Add(this.chkWidthFixed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 653);
            this.panel1.TabIndex = 0;
            // 
            // chkWidthFixed
            // 
            this.chkWidthFixed.AutoSize = true;
            this.chkWidthFixed.Checked = true;
            this.chkWidthFixed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWidthFixed.Location = new System.Drawing.Point(6, 14);
            this.chkWidthFixed.Name = "chkWidthFixed";
            this.chkWidthFixed.Size = new System.Drawing.Size(72, 16);
            this.chkWidthFixed.TabIndex = 0;
            this.chkWidthFixed.Text = "宽度固定";
            this.chkWidthFixed.UseVisualStyleBackColor = true;
            // 
            // chkHeightFixed
            // 
            this.chkHeightFixed.AutoSize = true;
            this.chkHeightFixed.Location = new System.Drawing.Point(6, 46);
            this.chkHeightFixed.Name = "chkHeightFixed";
            this.chkHeightFixed.Size = new System.Drawing.Size(72, 16);
            this.chkHeightFixed.TabIndex = 0;
            this.chkHeightFixed.Text = "高度固定";
            this.chkHeightFixed.UseVisualStyleBackColor = true;
            // 
            // tbarWidth
            // 
            this.tbarWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarWidth.AutoSize = false;
            this.tbarWidth.Location = new System.Drawing.Point(74, 8);
            this.tbarWidth.Maximum = 250;
            this.tbarWidth.Name = "tbarWidth";
            this.tbarWidth.Size = new System.Drawing.Size(273, 22);
            this.tbarWidth.TabIndex = 1;
            this.tbarWidth.Value = 100;
            this.tbarWidth.Scroll += new System.EventHandler(this.tbar_Scroll);
            // 
            // tbarHeight
            // 
            this.tbarHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarHeight.AutoSize = false;
            this.tbarHeight.Location = new System.Drawing.Point(74, 42);
            this.tbarHeight.Maximum = 250;
            this.tbarHeight.Name = "tbarHeight";
            this.tbarHeight.Size = new System.Drawing.Size(273, 22);
            this.tbarHeight.TabIndex = 1;
            this.tbarHeight.Value = 50;
            this.tbarHeight.Scroll += new System.EventHandler(this.tbar_Scroll);
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Location = new System.Drawing.Point(353, 11);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(34, 21);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "400";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Location = new System.Drawing.Point(353, 41);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(34, 21);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Text = "200";
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(5, 101);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(382, 520);
            this.txtContent.TabIndex = 3;
            this.txtContent.Text = "生命中有太多对你重要的东西，如果不往内心深处去探索，这些东西就都会变成杂音。\r\n\r\n如何保持持续的专注呢？\r\n1、要在一个漫长的赛道上\r\n2、要有持续不断的心力和" +
    "茁壮的体力\r\n3、不断更新迭代的创始人认知，同频更新的高管团队，以及创始人的管理能力\r\n4、最关键的“不被卡住”的那点运气，柳暗花明又一村的感觉";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "要显示的内容：";
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.Location = new System.Drawing.Point(220, 72);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(167, 23);
            this.btnFont.TabIndex = 5;
            this.btnFont.Text = "字体(宋体,12)";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // panContainer
            // 
            this.panContainer.AutoScroll = true;
            this.panContainer.BackColor = System.Drawing.Color.White;
            this.panContainer.Controls.Add(this.panGDI);
            this.panContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContainer.Location = new System.Drawing.Point(0, 0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(967, 653);
            this.panContainer.TabIndex = 2;
            // 
            // panGDI
            // 
            this.panGDI.BackColor = System.Drawing.Color.White;
            this.panGDI.Location = new System.Drawing.Point(0, 0);
            this.panGDI.Name = "panGDI";
            this.panGDI.Size = new System.Drawing.Size(900, 600);
            this.panGDI.TabIndex = 2;
            this.panGDI.Paint += new System.Windows.Forms.PaintEventHandler(this.panGDI_Paint);
            // 
            // lblException
            // 
            this.lblException.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblException.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblException.ForeColor = System.Drawing.Color.Red;
            this.lblException.Location = new System.Drawing.Point(0, 628);
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size(392, 25);
            this.lblException.TabIndex = 6;
            this.lblException.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormGEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 655);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormGEO";
            this.Text = "几何测试";
            this.Load += new System.EventHandler(this.FormGEO_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarHeight)).EndInit();
            this.panContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tbarHeight;
        private System.Windows.Forms.TrackBar tbarWidth;
        private System.Windows.Forms.CheckBox chkHeightFixed;
        private System.Windows.Forms.CheckBox chkWidthFixed;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Panel panContainer;
        private PanelGDI panGDI;
        private System.Windows.Forms.Label lblException;
    }
}