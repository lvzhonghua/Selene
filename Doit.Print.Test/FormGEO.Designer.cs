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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGEO));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.lblContentInfo = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.tbarWidth = new System.Windows.Forms.TrackBar();
            this.panContainer = new System.Windows.Forms.Panel();
            this.panGDI = new Doit.Print.Test.PanelGDI();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTextContent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tvDisassemblyResult = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFontSelect = new System.Windows.Forms.Button();
            this.txtPadding_V = new System.Windows.Forms.TextBox();
            this.txtPadding_H = new System.Windows.Forms.TextBox();
            this.cboParagraphSpacing = new System.Windows.Forms.ComboBox();
            this.cboIndent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLineSpacing = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panParagraph = new Doit.Print.Test.PanelGDI();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarWidth)).BeginInit();
            this.panContainer.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1353, 623);
            this.splitContainer1.SplitterDistance = 389;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnFont);
            this.panel1.Controls.Add(this.lblContentInfo);
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.tbarWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 621);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "宽度：";
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.Location = new System.Drawing.Point(215, 32);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(167, 23);
            this.btnFont.TabIndex = 5;
            this.btnFont.Text = "字体(宋体,12)";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // lblContentInfo
            // 
            this.lblContentInfo.AutoSize = true;
            this.lblContentInfo.Location = new System.Drawing.Point(4, 36);
            this.lblContentInfo.Name = "lblContentInfo";
            this.lblContentInfo.Size = new System.Drawing.Size(89, 12);
            this.lblContentInfo.TabIndex = 4;
            this.lblContentInfo.Text = "要显示的内容：";
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(5, 61);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(377, 557);
            this.txtContent.TabIndex = 3;
            this.txtContent.Text = "生命中有太多对你重要的东西，如果不往内心深处去探索，这些东西就都会变成杂音。\r\n\r\n如何保持持续的专注呢？\r\n1、要在一个漫长的赛道上\r\n2、要有持续不断的心力和" +
    "茁壮的体力\r\n3、不断更新迭代的创始人认知，同频更新的高管团队，以及创始人的管理能力\r\n4、最关键的“不被卡住”的那点运气，柳暗花明又一村的感觉";
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Location = new System.Drawing.Point(348, 5);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(34, 21);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "400";
            // 
            // tbarWidth
            // 
            this.tbarWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarWidth.AutoSize = false;
            this.tbarWidth.Location = new System.Drawing.Point(42, 2);
            this.tbarWidth.Maximum = 250;
            this.tbarWidth.Minimum = 1;
            this.tbarWidth.Name = "tbarWidth";
            this.tbarWidth.Size = new System.Drawing.Size(300, 22);
            this.tbarWidth.TabIndex = 1;
            this.tbarWidth.Value = 100;
            this.tbarWidth.Scroll += new System.EventHandler(this.tbar_Scroll);
            // 
            // panContainer
            // 
            this.panContainer.AutoScroll = true;
            this.panContainer.BackColor = System.Drawing.Color.White;
            this.panContainer.Controls.Add(this.panGDI);
            this.panContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContainer.Location = new System.Drawing.Point(0, 0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(958, 621);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1367, 655);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1359, 629);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文字尺寸";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1359, 629);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "行与段落";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(1353, 623);
            this.splitContainer2.SplitterDistance = 479;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtTextContent);
            this.groupBox3.Location = new System.Drawing.Point(6, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 202);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文字内容";
            // 
            // txtTextContent
            // 
            this.txtTextContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTextContent.Location = new System.Drawing.Point(3, 17);
            this.txtTextContent.Multiline = true;
            this.txtTextContent.Name = "txtTextContent";
            this.txtTextContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextContent.Size = new System.Drawing.Size(459, 182);
            this.txtTextContent.TabIndex = 7;
            this.txtTextContent.Text = resources.GetString("txtTextContent.Text");
            this.txtTextContent.TextChanged += new System.EventHandler(this.Style_Change);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tvDisassemblyResult);
            this.groupBox2.Location = new System.Drawing.Point(6, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 336);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拆解结果";
            // 
            // tvDisassemblyResult
            // 
            this.tvDisassemblyResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDisassemblyResult.ImageIndex = 0;
            this.tvDisassemblyResult.ImageList = this.imgList;
            this.tvDisassemblyResult.Location = new System.Drawing.Point(3, 17);
            this.tvDisassemblyResult.Name = "tvDisassemblyResult";
            this.tvDisassemblyResult.SelectedImageIndex = 0;
            this.tvDisassemblyResult.Size = new System.Drawing.Size(459, 316);
            this.tvDisassemblyResult.TabIndex = 12;
            this.tvDisassemblyResult.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDisassemblyResult_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "line_16.png");
            this.imgList.Images.SetKeyName(1, "paragraph_16.png");
            this.imgList.Images.SetKeyName(2, "内容_16.png");
            this.imgList.Images.SetKeyName(3, "字符_16.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFontSelect);
            this.groupBox1.Controls.Add(this.txtPadding_V);
            this.groupBox1.Controls.Add(this.txtPadding_H);
            this.groupBox1.Controls.Add(this.cboParagraphSpacing);
            this.groupBox1.Controls.Add(this.cboIndent);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboLineSpacing);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 64);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "格式";
            // 
            // btnFontSelect
            // 
            this.btnFontSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFontSelect.Location = new System.Drawing.Point(347, 14);
            this.btnFontSelect.Name = "btnFontSelect";
            this.btnFontSelect.Size = new System.Drawing.Size(112, 45);
            this.btnFontSelect.TabIndex = 13;
            this.btnFontSelect.Text = "字体(宋体,12)";
            this.btnFontSelect.UseVisualStyleBackColor = true;
            this.btnFontSelect.Click += new System.EventHandler(this.btnFontSelect_Click);
            // 
            // txtPadding_V
            // 
            this.txtPadding_V.Location = new System.Drawing.Point(302, 38);
            this.txtPadding_V.Name = "txtPadding_V";
            this.txtPadding_V.Size = new System.Drawing.Size(39, 21);
            this.txtPadding_V.TabIndex = 12;
            this.txtPadding_V.Text = "4";
            this.txtPadding_V.TextChanged += new System.EventHandler(this.Style_Change);
            // 
            // txtPadding_H
            // 
            this.txtPadding_H.Location = new System.Drawing.Point(302, 14);
            this.txtPadding_H.Name = "txtPadding_H";
            this.txtPadding_H.Size = new System.Drawing.Size(39, 21);
            this.txtPadding_H.TabIndex = 12;
            this.txtPadding_H.Text = "4";
            this.txtPadding_H.TextChanged += new System.EventHandler(this.Style_Change);
            // 
            // cboParagraphSpacing
            // 
            this.cboParagraphSpacing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParagraphSpacing.FormattingEnabled = true;
            this.cboParagraphSpacing.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.cboParagraphSpacing.Location = new System.Drawing.Point(56, 37);
            this.cboParagraphSpacing.Name = "cboParagraphSpacing";
            this.cboParagraphSpacing.Size = new System.Drawing.Size(64, 20);
            this.cboParagraphSpacing.TabIndex = 9;
            this.cboParagraphSpacing.TextChanged += new System.EventHandler(this.Style_Change);
            // 
            // cboIndent
            // 
            this.cboIndent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndent.FormattingEnabled = true;
            this.cboIndent.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "4"});
            this.cboIndent.Location = new System.Drawing.Point(175, 14);
            this.cboIndent.Name = "cboIndent";
            this.cboIndent.Size = new System.Drawing.Size(68, 20);
            this.cboIndent.TabIndex = 9;
            this.cboIndent.TextChanged += new System.EventHandler(this.Style_Change);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "段间距：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(283, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "V";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(284, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "H";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(249, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "间隙：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "段缩进：";
            // 
            // cboLineSpacing
            // 
            this.cboLineSpacing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineSpacing.FormattingEnabled = true;
            this.cboLineSpacing.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cboLineSpacing.Location = new System.Drawing.Point(56, 13);
            this.cboLineSpacing.Name = "cboLineSpacing";
            this.cboLineSpacing.Size = new System.Drawing.Size(64, 20);
            this.cboLineSpacing.TabIndex = 9;
            this.cboLineSpacing.TextChanged += new System.EventHandler(this.Style_Change);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "行间距：";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panParagraph);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 621);
            this.panel2.TabIndex = 3;
            // 
            // panParagraph
            // 
            this.panParagraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panParagraph.BackColor = System.Drawing.Color.White;
            this.panParagraph.Location = new System.Drawing.Point(0, 0);
            this.panParagraph.Name = "panParagraph";
            this.panParagraph.Size = new System.Drawing.Size(844, 600);
            this.panParagraph.TabIndex = 2;
            this.panParagraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panParagraph_Paint);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1359, 629);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "内容分页";
            // 
            // FormGEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 655);
            this.Controls.Add(this.tabControl1);
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
            this.panContainer.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tbarWidth;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label lblContentInfo;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Panel panContainer;
        private PanelGDI panGDI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboLineSpacing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboParagraphSpacing;
        private System.Windows.Forms.ComboBox cboIndent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private PanelGDI panParagraph;
        private System.Windows.Forms.TextBox txtPadding_V;
        private System.Windows.Forms.TextBox txtPadding_H;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TreeView tvDisassemblyResult;
        private System.Windows.Forms.Button btnFontSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTextContent;
        private System.Windows.Forms.ImageList imgList;
    }
}