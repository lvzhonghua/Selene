namespace Selene.Forms.Tools
{
    partial class CopyGenealogySettingForm
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
            this.lbGenealogy = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEx1 = new Selene.BaseControl.LabelEx();
            this.SuspendLayout();
            // 
            // lbGenealogy
            // 
            this.lbGenealogy.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGenealogy.FormattingEnabled = true;
            this.lbGenealogy.ItemHeight = 22;
            this.lbGenealogy.Location = new System.Drawing.Point(24, 32);
            this.lbGenealogy.Name = "lbGenealogy";
            this.lbGenealogy.Size = new System.Drawing.Size(243, 202);
            this.lbGenealogy.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(51, 315);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请从下面的列表中选择要复制哪个宗谱的设置";
            // 
            // labelEx1
            // 
            this.labelEx1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelEx1.LineDistance = 5;
            this.labelEx1.Location = new System.Drawing.Point(9, 250);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(278, 81);
            this.labelEx1.TabIndex = 4;
            this.labelEx1.Text = "提示：通过“复制设置”可以将其它宗谱中的版面设置、页面设置、自动纠错设置、谱文格式设置直接复制到当前宗谱中来使用";
            // 
            // CopyGenealogySettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 351);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbGenealogy);
            this.Controls.Add(this.labelEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyGenealogySettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "复制设置";
            this.Load += new System.EventHandler(this.CopyGenealogySettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGenealogy;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private BaseControl.LabelEx labelEx1;
    }
}