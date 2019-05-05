namespace Selene.Forms.PartVolume.PartVolumeManage
{
    partial class PartVolumeDetailedForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNeedCatalogue = new System.Windows.Forms.CheckBox();
            this.cboNeedCheatSheets = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numStartIndex = new Selene.BaseControl.DataNumberBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分卷名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始页码:";
            // 
            // cboNeedCatalogue
            // 
            this.cboNeedCatalogue.AutoSize = true;
            this.cboNeedCatalogue.Location = new System.Drawing.Point(26, 74);
            this.cboNeedCatalogue.Name = "cboNeedCatalogue";
            this.cboNeedCatalogue.Size = new System.Drawing.Size(72, 16);
            this.cboNeedCatalogue.TabIndex = 2;
            this.cboNeedCatalogue.Text = "需要目录";
            this.cboNeedCatalogue.UseVisualStyleBackColor = true;
            // 
            // cboNeedCheatSheets
            // 
            this.cboNeedCheatSheets.AutoSize = true;
            this.cboNeedCheatSheets.Location = new System.Drawing.Point(118, 74);
            this.cboNeedCheatSheets.Name = "cboNeedCheatSheets";
            this.cboNeedCheatSheets.Size = new System.Drawing.Size(84, 16);
            this.cboNeedCheatSheets.TabIndex = 3;
            this.cboNeedCheatSheets.Text = "需要速查表";
            this.cboNeedCheatSheets.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(124, 21);
            this.txtName.TabIndex = 4;
            // 
            // numStartIndex
            // 
            this.numStartIndex.Location = new System.Drawing.Point(79, 38);
            this.numStartIndex.ModelName = null;
            this.numStartIndex.Name = "numStartIndex";
            this.numStartIndex.PropertyName = null;
            this.numStartIndex.Size = new System.Drawing.Size(77, 21);
            this.numStartIndex.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(208, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(208, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PartVolumeDetailedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 98);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.numStartIndex);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboNeedCheatSheets);
            this.Controls.Add(this.cboNeedCatalogue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartVolumeDetailedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加分卷";
            this.Load += new System.EventHandler(this.PartVolumeDetailedForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cboNeedCatalogue;
        private System.Windows.Forms.CheckBox cboNeedCheatSheets;
        private System.Windows.Forms.TextBox txtName;
        private BaseControl.DataNumberBox numStartIndex;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}