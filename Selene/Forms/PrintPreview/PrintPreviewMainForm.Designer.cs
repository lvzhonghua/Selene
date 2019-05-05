namespace Selene.Forms.PrintPreview
{
    partial class PrintPreviewMainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPageSetting = new System.Windows.Forms.Button();
            this.cboPageCount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numSkip = new Selene.BaseControl.DataNumberBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.cboZoomScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ppcPrintMain = new System.Windows.Forms.PrintPreviewControl();
            this.pdMainDocument = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPageSetting);
            this.panel1.Controls.Add(this.cboPageCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numSkip);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnNextPage);
            this.panel1.Controls.Add(this.btnPrevPage);
            this.panel1.Controls.Add(this.cboZoomScale);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 29);
            this.panel1.TabIndex = 1;
            // 
            // btnPageSetting
            // 
            this.btnPageSetting.Location = new System.Drawing.Point(146, 4);
            this.btnPageSetting.Name = "btnPageSetting";
            this.btnPageSetting.Size = new System.Drawing.Size(70, 23);
            this.btnPageSetting.TabIndex = 16;
            this.btnPageSetting.Text = "页面设置";
            this.btnPageSetting.UseVisualStyleBackColor = true;
            this.btnPageSetting.Click += new System.EventHandler(this.btnPageSetting_Click);
            // 
            // cboPageCount
            // 
            this.cboPageCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageCount.FormattingEnabled = true;
            this.cboPageCount.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "6",
            "8"});
            this.cboPageCount.Location = new System.Drawing.Point(421, 6);
            this.cboPageCount.Name = "cboPageCount";
            this.cboPageCount.Size = new System.Drawing.Size(42, 20);
            this.cboPageCount.TabIndex = 15;
            this.cboPageCount.SelectedIndexChanged += new System.EventHandler(this.cboPageCount_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "显示页数:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(948, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(831, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(37, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(757, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(68, 21);
            this.txtSearch.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(696, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "查找内容:";
            // 
            // numSkip
            // 
            this.numSkip.PropertyName = null;
            this.numSkip.Location = new System.Drawing.Point(651, 6);
            this.numSkip.Name = "numSkip";
            this.numSkip.Size = new System.Drawing.Size(37, 21);
            this.numSkip.TabIndex = 7;
            this.numSkip.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "跳转到:";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(534, 4);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(60, 23);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(469, 4);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(60, 23);
            this.btnPrevPage.TabIndex = 4;
            this.btnPrevPage.Text = "上一页";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // cboZoomScale
            // 
            this.cboZoomScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZoomScale.FormattingEnabled = true;
            this.cboZoomScale.Items.AddRange(new object[] {
            "自动缩放",
            "200%",
            "175%",
            "150%",
            "125%",
            "100%",
            "75%",
            "50%",
            "25%"});
            this.cboZoomScale.Location = new System.Drawing.Point(282, 6);
            this.cboZoomScale.Name = "cboZoomScale";
            this.cboZoomScale.Size = new System.Drawing.Size(73, 20);
            this.cboZoomScale.TabIndex = 3;
            this.cboZoomScale.SelectedIndexChanged += new System.EventHandler(this.cboZoomScale_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "缩放比例:";
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(69, 4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "打印机设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(7, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ppcPrintMain
            // 
            this.ppcPrintMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppcPrintMain.AutoZoom = false;
            this.ppcPrintMain.Document = this.pdMainDocument;
            this.ppcPrintMain.Location = new System.Drawing.Point(3, 32);
            this.ppcPrintMain.Name = "ppcPrintMain";
            this.ppcPrintMain.Size = new System.Drawing.Size(994, 494);
            this.ppcPrintMain.TabIndex = 2;
            this.ppcPrintMain.Zoom = 0.42258340461933275D;
            this.ppcPrintMain.StartPageChanged += new System.EventHandler(this.ppcPrintMain_StartPageChanged);
            // 
            // pdMainDocument
            // 
            this.pdMainDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pdMainDocument_BeginPrint);
            this.pdMainDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdMainDocument_PrintPage);
            // 
            // PrintPreviewMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 529);
            this.Controls.Add(this.ppcPrintMain);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "PrintPreviewMainForm";
            this.Text = "打印预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintPreviewMainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private BaseControl.DataNumberBox numSkip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.ComboBox cboZoomScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintPreviewControl ppcPrintMain;
        private System.Drawing.Printing.PrintDocument pdMainDocument;
        private System.Windows.Forms.ComboBox cboPageCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPageSetting;

    }
}