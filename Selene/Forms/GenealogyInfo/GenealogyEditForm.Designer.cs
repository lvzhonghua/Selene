namespace Selene.Forms.GenealogyInfo
{
    partial class GenealogyEditForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHr = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataNumberBox3 = new Selene.BaseControl.DataNumberBox();
            this.dataTextBox3 = new Selene.BaseControl.DataTextBox();
            this.dataNumberBox1 = new Selene.BaseControl.DataNumberBox();
            this.txtFamilyName = new Selene.BaseControl.DataTextBox();
            this.txtName = new Selene.BaseControl.DataTextBox();
            this.dataTextBox4 = new Selene.BaseControl.DataTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "宗谱名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓氏：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "行第起始世数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "行第：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "或称“行辈”";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "或称“字辈”";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "或称“派诀”";
            // 
            // lblHr
            // 
            this.lblHr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHr.Location = new System.Drawing.Point(8, 240);
            this.lblHr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHr.Name = "lblHr";
            this.lblHr.Size = new System.Drawing.Size(387, 2);
            this.lblHr.TabIndex = 11;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(116, 305);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "始祖的世数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "始祖的父辈信息或简要描述：";
            // 
            // dataNumberBox3
            // 
            this.dataNumberBox3.Location = new System.Drawing.Point(98, 250);
            this.dataNumberBox3.ModelName = "genealogy";
            this.dataNumberBox3.Name = "dataNumberBox3";
            this.dataNumberBox3.PropertyName = "AncestorWorldNumber";
            this.dataNumberBox3.Size = new System.Drawing.Size(75, 21);
            this.dataNumberBox3.TabIndex = 17;
            // 
            // dataTextBox3
            // 
            this.dataTextBox3.Location = new System.Drawing.Point(187, 275);
            this.dataTextBox3.ModelName = "genealogy";
            this.dataTextBox3.Name = "dataTextBox3";
            this.dataTextBox3.PropertyName = "AncestorParentInfo";
            this.dataTextBox3.Size = new System.Drawing.Size(202, 21);
            this.dataTextBox3.TabIndex = 16;
            // 
            // dataNumberBox1
            // 
            this.dataNumberBox1.Location = new System.Drawing.Point(98, 76);
            this.dataNumberBox1.ModelName = "genealogy";
            this.dataNumberBox1.Name = "dataNumberBox1";
            this.dataNumberBox1.PropertyName = "SeniorityWorldNumber";
            this.dataNumberBox1.Size = new System.Drawing.Size(75, 21);
            this.dataNumberBox1.TabIndex = 5;
            // 
            // txtFamilyName
            // 
            this.txtFamilyName.Location = new System.Drawing.Point(98, 39);
            this.txtFamilyName.ModelName = "genealogy";
            this.txtFamilyName.Name = "txtFamilyName";
            this.txtFamilyName.PropertyName = "FamilyName";
            this.txtFamilyName.Size = new System.Drawing.Size(75, 21);
            this.txtFamilyName.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 8);
            this.txtName.ModelName = "genealogy";
            this.txtName.Name = "txtName";
            this.txtName.PropertyName = "Name";
            this.txtName.Size = new System.Drawing.Size(159, 21);
            this.txtName.TabIndex = 1;
            // 
            // dataTextBox4
            // 
            this.dataTextBox4.Location = new System.Drawing.Point(98, 115);
            this.dataTextBox4.ModelName = "genealogy";
            this.dataTextBox4.Multiline = true;
            this.dataTextBox4.Name = "dataTextBox4";
            this.dataTextBox4.PropertyName = "Seniority";
            this.dataTextBox4.Size = new System.Drawing.Size(291, 116);
            this.dataTextBox4.TabIndex = 18;
            // 
            // GenealogyEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 335);
            this.Controls.Add(this.dataTextBox4);
            this.Controls.Add(this.dataNumberBox3);
            this.Controls.Add(this.dataTextBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblHr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataNumberBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFamilyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenealogyEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改基本信息";
            this.Load += new System.EventHandler(this.GenealogyEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BaseControl.DataTextBox txtName;
        private System.Windows.Forms.Label label2;
        private BaseControl.DataTextBox txtFamilyName;
        private System.Windows.Forms.Label label3;
        private BaseControl.DataNumberBox dataNumberBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHr;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private BaseControl.DataTextBox dataTextBox3;
        private BaseControl.DataNumberBox dataNumberBox3;
        private BaseControl.DataTextBox dataTextBox4;
    }
}