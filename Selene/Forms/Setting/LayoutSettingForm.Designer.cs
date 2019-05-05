namespace Selene.Forms.PartVolume
{
    partial class LayoutSettingForm
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpConventionalSetting = new System.Windows.Forms.TabPage();
            this.tpCatalogueSetting = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tpHeaderFooter = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tpLineageMapStyle = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpConventionalSetting);
            this.tcMain.Controls.Add(this.tpCatalogueSetting);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tpHeaderFooter);
            this.tcMain.Controls.Add(this.tabPage5);
            this.tcMain.Controls.Add(this.tpLineageMapStyle);
            this.tcMain.Controls.Add(this.tabPage7);
            this.tcMain.Controls.Add(this.tabPage8);
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(404, 432);
            this.tcMain.TabIndex = 0;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tpConventionalSetting
            // 
            this.tpConventionalSetting.Location = new System.Drawing.Point(4, 22);
            this.tpConventionalSetting.Name = "tpConventionalSetting";
            this.tpConventionalSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpConventionalSetting.Size = new System.Drawing.Size(396, 406);
            this.tpConventionalSetting.TabIndex = 0;
            this.tpConventionalSetting.Text = "常规";
            this.tpConventionalSetting.UseVisualStyleBackColor = true;
            // 
            // tpCatalogueSetting
            // 
            this.tpCatalogueSetting.Location = new System.Drawing.Point(4, 22);
            this.tpCatalogueSetting.Name = "tpCatalogueSetting";
            this.tpCatalogueSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpCatalogueSetting.Size = new System.Drawing.Size(396, 406);
            this.tpCatalogueSetting.TabIndex = 1;
            this.tpCatalogueSetting.Text = "目录";
            this.tpCatalogueSetting.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(396, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "谱序";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tpHeaderFooter
            // 
            this.tpHeaderFooter.Location = new System.Drawing.Point(4, 22);
            this.tpHeaderFooter.Name = "tpHeaderFooter";
            this.tpHeaderFooter.Size = new System.Drawing.Size(396, 406);
            this.tpHeaderFooter.TabIndex = 3;
            this.tpHeaderFooter.Text = "页眉页脚";
            this.tpHeaderFooter.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(396, 406);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "源流图";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tpLineageMapStyle
            // 
            this.tpLineageMapStyle.Location = new System.Drawing.Point(4, 22);
            this.tpLineageMapStyle.Name = "tpLineageMapStyle";
            this.tpLineageMapStyle.Size = new System.Drawing.Size(396, 406);
            this.tpLineageMapStyle.TabIndex = 5;
            this.tpLineageMapStyle.Text = "世系图";
            this.tpLineageMapStyle.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(396, 406);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "世表";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(396, 406);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "其他";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(244, 436);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(325, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LayoutSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 463);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayoutSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "版面设置";
            this.Load += new System.EventHandler(this.LayoutSettingForm_Load);
            this.tcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpConventionalSetting;
        private System.Windows.Forms.TabPage tpCatalogueSetting;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tpHeaderFooter;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tpLineageMapStyle;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}