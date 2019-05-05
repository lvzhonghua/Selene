namespace Selene.Forms.LineageInfo
{
    partial class InsertLineageForm
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataTextBox2 = new Selene.BaseControl.DataTextBox();
            this.dataTextBox1 = new Selene.BaseControl.DataTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataNumberBox1 = new Selene.BaseControl.DataNumberBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddPartVolume = new System.Windows.Forms.Button();
            this.dataComboBox1 = new Selene.BaseControl.DataComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataComboBox2 = new Selene.BaseControl.DataComboBox();
            this.dataCheckBox1 = new Selene.BaseControl.DataCheckBox();
            this.dataRichTextBox1 = new Selene.BaseControl.DataRichTextBox();
            this.dataTextBox5 = new Selene.BaseControl.DataTextBox();
            this.dataTextBox4 = new Selene.BaseControl.DataTextBox();
            this.dataTextBox3 = new Selene.BaseControl.DataTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "插入到已插入的世系中";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(119, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "插入一个新的世系";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "所在分卷：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataTextBox2);
            this.groupBox1.Controls.Add(this.dataTextBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataNumberBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddPartVolume);
            this.groupBox1.Controls.Add(this.dataComboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(11, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 171);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dataTextBox2
            // 
            this.dataTextBox2.Location = new System.Drawing.Point(79, 87);
            this.dataTextBox2.ModelName = null;
            this.dataTextBox2.Multiline = true;
            this.dataTextBox2.Name = "dataTextBox2";
            this.dataTextBox2.PropertyName = null;
            this.dataTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTextBox2.Size = new System.Drawing.Size(388, 78);
            this.dataTextBox2.TabIndex = 10;
            // 
            // dataTextBox1
            // 
            this.dataTextBox1.Location = new System.Drawing.Point(79, 54);
            this.dataTextBox1.ModelName = null;
            this.dataTextBox1.Name = "dataTextBox1";
            this.dataTextBox1.PropertyName = null;
            this.dataTextBox1.Size = new System.Drawing.Size(388, 21);
            this.dataTextBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "世系说明：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "世系名称：";
            // 
            // dataNumberBox1
            // 
            this.dataNumberBox1.Location = new System.Drawing.Point(401, 22);
            this.dataNumberBox1.ModelName = null;
            this.dataNumberBox1.Name = "dataNumberBox1";
            this.dataNumberBox1.PropertyName = null;
            this.dataNumberBox1.Size = new System.Drawing.Size(66, 21);
            this.dataNumberBox1.TabIndex = 6;
            this.dataNumberBox1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "世系起始世数：";
            // 
            // btnAddPartVolume
            // 
            this.btnAddPartVolume.Location = new System.Drawing.Point(171, 21);
            this.btnAddPartVolume.Name = "btnAddPartVolume";
            this.btnAddPartVolume.Size = new System.Drawing.Size(71, 23);
            this.btnAddPartVolume.TabIndex = 4;
            this.btnAddPartVolume.Text = "添加分卷";
            this.btnAddPartVolume.UseVisualStyleBackColor = true;
            this.btnAddPartVolume.Click += new System.EventHandler(this.btnAddPartVolume_Click);
            // 
            // dataComboBox1
            // 
            this.dataComboBox1.DisplayMember = "Text";
            this.dataComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataComboBox1.FormattingEnabled = true;
            this.dataComboBox1.Location = new System.Drawing.Point(79, 22);
            this.dataComboBox1.ModelName = null;
            this.dataComboBox1.Name = "dataComboBox1";
            this.dataComboBox1.PropertyName = null;
            this.dataComboBox1.Size = new System.Drawing.Size(86, 20);
            this.dataComboBox1.TabIndex = 3;
            this.dataComboBox1.ValueMember = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "支系：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "房系：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "侧边标题：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(485, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "谱文（注意：谱名必须最先输入，后跟一个逗号，然后接着输入父辈信息，再跟一个逗号）";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(334, 498);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(415, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dataComboBox2
            // 
            this.dataComboBox2.DisplayMember = "Text";
            this.dataComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataComboBox2.Enabled = false;
            this.dataComboBox2.FormattingEnabled = true;
            this.dataComboBox2.Location = new System.Drawing.Point(165, 10);
            this.dataComboBox2.ModelName = null;
            this.dataComboBox2.Name = "dataComboBox2";
            this.dataComboBox2.PropertyName = null;
            this.dataComboBox2.Size = new System.Drawing.Size(325, 20);
            this.dataComboBox2.TabIndex = 15;
            this.dataComboBox2.ValueMember = "Value";
            // 
            // dataCheckBox1
            // 
            this.dataCheckBox1.AutoSize = true;
            this.dataCheckBox1.Location = new System.Drawing.Point(11, 502);
            this.dataCheckBox1.ModelName = null;
            this.dataCheckBox1.Name = "dataCheckBox1";
            this.dataCheckBox1.PropertyName = null;
            this.dataCheckBox1.Size = new System.Drawing.Size(144, 16);
            this.dataCheckBox1.TabIndex = 12;
            this.dataCheckBox1.Text = "插入世系后不关闭窗口";
            this.dataCheckBox1.UseVisualStyleBackColor = true;
            // 
            // dataRichTextBox1
            // 
            this.dataRichTextBox1.Location = new System.Drawing.Point(11, 312);
            this.dataRichTextBox1.ModelName = null;
            this.dataRichTextBox1.Name = "dataRichTextBox1";
            this.dataRichTextBox1.PropertyName = null;
            this.dataRichTextBox1.Size = new System.Drawing.Size(479, 179);
            this.dataRichTextBox1.TabIndex = 10;
            this.dataRichTextBox1.Text = "";
            // 
            // dataTextBox5
            // 
            this.dataTextBox5.Location = new System.Drawing.Point(77, 254);
            this.dataTextBox5.ModelName = null;
            this.dataTextBox5.Name = "dataTextBox5";
            this.dataTextBox5.PropertyName = null;
            this.dataTextBox5.Size = new System.Drawing.Size(413, 21);
            this.dataTextBox5.TabIndex = 9;
            // 
            // dataTextBox4
            // 
            this.dataTextBox4.Location = new System.Drawing.Point(326, 222);
            this.dataTextBox4.ModelName = null;
            this.dataTextBox4.Name = "dataTextBox4";
            this.dataTextBox4.PropertyName = null;
            this.dataTextBox4.Size = new System.Drawing.Size(164, 21);
            this.dataTextBox4.TabIndex = 7;
            // 
            // dataTextBox3
            // 
            this.dataTextBox3.Location = new System.Drawing.Point(78, 222);
            this.dataTextBox3.ModelName = null;
            this.dataTextBox3.Name = "dataTextBox3";
            this.dataTextBox3.PropertyName = null;
            this.dataTextBox3.Size = new System.Drawing.Size(164, 21);
            this.dataTextBox3.TabIndex = 5;
            // 
            // InsertLineageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 526);
            this.Controls.Add(this.dataComboBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dataCheckBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataRichTextBox1);
            this.Controls.Add(this.dataTextBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataTextBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataTextBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButton1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertLineageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "插入世系";
            this.Load += new System.EventHandler(this.InsertLineageForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private BaseControl.DataComboBox dataComboBox1;
        private System.Windows.Forms.Button btnAddPartVolume;
        private System.Windows.Forms.Label label2;
        private BaseControl.DataNumberBox dataNumberBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private BaseControl.DataTextBox dataTextBox1;
        private BaseControl.DataTextBox dataTextBox2;
        private System.Windows.Forms.Label label5;
        private BaseControl.DataTextBox dataTextBox3;
        private BaseControl.DataTextBox dataTextBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private BaseControl.DataTextBox dataTextBox5;
        private BaseControl.DataRichTextBox dataRichTextBox1;
        private System.Windows.Forms.Label label8;
        private BaseControl.DataCheckBox dataCheckBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private BaseControl.DataComboBox dataComboBox2;
    }
}