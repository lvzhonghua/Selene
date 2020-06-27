namespace Doit.Print.Controls
{
    partial class CellStyleDesignerCtrl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CellStyleDesignerCtrl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLoadAssembly = new System.Windows.Forms.ToolStripButton();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvTypeList = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvTypeToAssociated = new System.Windows.Forms.TreeView();
            this.imgList2 = new System.Windows.Forms.ImageList(this.components);
            this.lblTypeToAssociated = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panDesigner = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panPreview = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pGridAssociate = new System.Windows.Forms.PropertyGrid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnCellPreview = new System.Windows.Forms.ToolStripButton();
            this.pGridFieldStyle = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadAssembly,
            this.btnLine});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1188, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLoadAssembly
            // 
            this.btnLoadAssembly.Image = global::Doit.Print.Controls.Properties.Resources.关联图元_16;
            this.btnLoadAssembly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadAssembly.Name = "btnLoadAssembly";
            this.btnLoadAssembly.Size = new System.Drawing.Size(76, 22);
            this.btnLoadAssembly.Text = "加载对象";
            this.btnLoadAssembly.Click += new System.EventHandler(this.btnLoadAssembly_Click);
            // 
            // btnLine
            // 
            this.btnLine.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLine.Image = global::Doit.Print.Controls.Properties.Resources.线条_编辑_16;
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(52, 22);
            this.btnLine.Text = "线条";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvTypeList);
            this.splitContainer1.Panel1.Controls.Add(this.splitter3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.splitter2);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1188, 597);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvTypeList
            // 
            this.tvTypeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTypeList.ImageIndex = 0;
            this.tvTypeList.ImageList = this.imgList;
            this.tvTypeList.Location = new System.Drawing.Point(0, 288);
            this.tvTypeList.Name = "tvTypeList";
            this.tvTypeList.SelectedImageIndex = 0;
            this.tvTypeList.Size = new System.Drawing.Size(261, 307);
            this.tvTypeList.TabIndex = 12;
            this.tvTypeList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvTypeList_ItemDrag);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "类型_16.png");
            this.imgList.Images.SetKeyName(1, "数字_16.png");
            this.imgList.Images.SetKeyName(2, "日期_16.png");
            this.imgList.Images.SetKeyName(3, "字符串_16.png");
            this.imgList.Images.SetKeyName(4, "成员_16.png");
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.Highlight;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 285);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(261, 3);
            this.splitter3.TabIndex = 11;
            this.splitter3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvTypeToAssociated);
            this.panel1.Controls.Add(this.lblTypeToAssociated);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 285);
            this.panel1.TabIndex = 10;
            // 
            // tvTypeToAssociated
            // 
            this.tvTypeToAssociated.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvTypeToAssociated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTypeToAssociated.FullRowSelect = true;
            this.tvTypeToAssociated.HideSelection = false;
            this.tvTypeToAssociated.ImageIndex = 0;
            this.tvTypeToAssociated.ImageList = this.imgList2;
            this.tvTypeToAssociated.ItemHeight = 30;
            this.tvTypeToAssociated.Location = new System.Drawing.Point(0, 0);
            this.tvTypeToAssociated.Name = "tvTypeToAssociated";
            this.tvTypeToAssociated.SelectedImageIndex = 0;
            this.tvTypeToAssociated.ShowLines = false;
            this.tvTypeToAssociated.ShowPlusMinus = false;
            this.tvTypeToAssociated.ShowRootLines = false;
            this.tvTypeToAssociated.Size = new System.Drawing.Size(261, 259);
            this.tvTypeToAssociated.TabIndex = 5;
            this.tvTypeToAssociated.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvTypeToAssociated_ItemDrag);
            // 
            // imgList2
            // 
            this.imgList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList2.ImageStream")));
            this.imgList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList2.Images.SetKeyName(0, "成员_48.png");
            this.imgList2.Images.SetKeyName(1, "日期_48.png");
            this.imgList2.Images.SetKeyName(2, "数字_48.png");
            this.imgList2.Images.SetKeyName(3, "字符串_48.png");
            // 
            // lblTypeToAssociated
            // 
            this.lblTypeToAssociated.AllowDrop = true;
            this.lblTypeToAssociated.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTypeToAssociated.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTypeToAssociated.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTypeToAssociated.Location = new System.Drawing.Point(0, 259);
            this.lblTypeToAssociated.Name = "lblTypeToAssociated";
            this.lblTypeToAssociated.Size = new System.Drawing.Size(261, 26);
            this.lblTypeToAssociated.TabIndex = 0;
            this.lblTypeToAssociated.Text = "要关联的类型(空)";
            this.lblTypeToAssociated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTypeToAssociated.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTypeToAssociated_DragDrop);
            this.lblTypeToAssociated.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblTypeToAssociated_DragEnter);
            this.lblTypeToAssociated.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTypeToAssociated_DragOver);
            this.lblTypeToAssociated.DragLeave += new System.EventHandler(this.lblTypeToAssociated_DragLeave);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panDesigner);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pGridFieldStyle);
            this.splitContainer2.Size = new System.Drawing.Size(921, 299);
            this.splitContainer2.SplitterDistance = 697;
            this.splitContainer2.TabIndex = 4;
            // 
            // panDesigner
            // 
            this.panDesigner.AllowDrop = true;
            this.panDesigner.BackColor = System.Drawing.Color.White;
            this.panDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDesigner.Location = new System.Drawing.Point(0, 0);
            this.panDesigner.Name = "panDesigner";
            this.panDesigner.Size = new System.Drawing.Size(695, 297);
            this.panDesigner.TabIndex = 4;
            this.panDesigner.DragDrop += new System.Windows.Forms.DragEventHandler(this.panDesigner_DragDrop);
            this.panDesigner.DragEnter += new System.Windows.Forms.DragEventHandler(this.panDesigner_DragEnter);
            this.panDesigner.DragOver += new System.Windows.Forms.DragEventHandler(this.panDesigner_DragOver);
            this.panDesigner.DragLeave += new System.EventHandler(this.panDesigner_DragLeave);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 299);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(921, 3);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 302);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(921, 295);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panPreview);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.pGridAssociate);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(913, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "测试";
            // 
            // panPreview
            // 
            this.panPreview.BackColor = System.Drawing.Color.White;
            this.panPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPreview.Location = new System.Drawing.Point(267, 28);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(643, 238);
            this.panPreview.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Location = new System.Drawing.Point(264, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 238);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // pGridAssociate
            // 
            this.pGridAssociate.Dock = System.Windows.Forms.DockStyle.Left;
            this.pGridAssociate.Location = new System.Drawing.Point(3, 28);
            this.pGridAssociate.Name = "pGridAssociate";
            this.pGridAssociate.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pGridAssociate.Size = new System.Drawing.Size(261, 238);
            this.pGridAssociate.TabIndex = 2;
            this.pGridAssociate.ToolbarVisible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCellPreview});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(907, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnCellPreview
            // 
            this.btnCellPreview.Image = global::Doit.Print.Controls.Properties.Resources.预览_16;
            this.btnCellPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCellPreview.Name = "btnCellPreview";
            this.btnCellPreview.Size = new System.Drawing.Size(76, 22);
            this.btnCellPreview.Text = "生成预览";
            // 
            // pGridFieldStyle
            // 
            this.pGridFieldStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridFieldStyle.Location = new System.Drawing.Point(0, 0);
            this.pGridFieldStyle.Name = "pGridFieldStyle";
            this.pGridFieldStyle.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pGridFieldStyle.Size = new System.Drawing.Size(218, 297);
            this.pGridFieldStyle.TabIndex = 3;
            this.pGridFieldStyle.ToolbarVisible = false;
            // 
            // CellStyleDesignerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CellStyleDesignerCtrl";
            this.Size = new System.Drawing.Size(1188, 622);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoadAssembly;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panDesigner;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PropertyGrid pGridAssociate;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnCellPreview;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ImageList imgList2;
        private System.Windows.Forms.TreeView tvTypeList;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTypeToAssociated;
        private System.Windows.Forms.TreeView tvTypeToAssociated;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.PropertyGrid pGridFieldStyle;
    }
}
