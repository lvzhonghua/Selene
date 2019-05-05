namespace Selene.Forms.GenealogyInfo
{
    partial class ClansmanAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClansmanAddForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtGenealogyNote = new Selene.BaseControl.DataRichTextBox();
            this.cbkNumberToChina = new System.Windows.Forms.CheckBox();
            this.cbkWriteSpace = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dcboPartVolumeParent = new Selene.BaseControl.DataComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPartVolumeManage = new System.Windows.Forms.Button();
            this.dcboVolume = new Selene.BaseControl.DataComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvFamily = new System.Windows.Forms.TreeView();
            this.imgTreeView = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataTextBox4 = new Selene.BaseControl.DataTextBox();
            this.dataTextBox3 = new Selene.BaseControl.DataTextBox();
            this.dataTextBox2 = new Selene.BaseControl.DataTextBox();
            this.dataTextBox1 = new Selene.BaseControl.DataTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGenealogyNoteSel = new System.Windows.Forms.TextBox();
            this.btnSetPhoto = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbShowWorldNumber = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rtxtGenealogyNote);
            this.groupBox1.Controls.Add(this.cbkNumberToChina);
            this.groupBox1.Controls.Add(this.cbkWriteSpace);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dcboPartVolumeParent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPartVolumeManage);
            this.groupBox1.Controls.Add(this.dcboVolume);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资料原稿录入";
            // 
            // rtxtGenealogyNote
            // 
            this.rtxtGenealogyNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtGenealogyNote.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtGenealogyNote.Location = new System.Drawing.Point(8, 50);
            this.rtxtGenealogyNote.ModelName = null;
            this.rtxtGenealogyNote.Name = "rtxtGenealogyNote";
            this.rtxtGenealogyNote.PropertyName = null;
            this.rtxtGenealogyNote.Size = new System.Drawing.Size(591, 306);
            this.rtxtGenealogyNote.TabIndex = 0;
            this.rtxtGenealogyNote.Text = "";
            this.rtxtGenealogyNote.TextChanged += new System.EventHandler(this.rtxtGenealogyNote_TextChanged);
            this.rtxtGenealogyNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtGenealogyNote_KeyDown);
            // 
            // cbkNumberToChina
            // 
            this.cbkNumberToChina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbkNumberToChina.AutoSize = true;
            this.cbkNumberToChina.Location = new System.Drawing.Point(467, 373);
            this.cbkNumberToChina.Name = "cbkNumberToChina";
            this.cbkNumberToChina.Size = new System.Drawing.Size(132, 16);
            this.cbkNumberToChina.TabIndex = 9;
            this.cbkNumberToChina.Text = "录入时数字转为汉字";
            this.cbkNumberToChina.UseVisualStyleBackColor = true;
            // 
            // cbkWriteSpace
            // 
            this.cbkWriteSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbkWriteSpace.AutoSize = true;
            this.cbkWriteSpace.Location = new System.Drawing.Point(310, 373);
            this.cbkWriteSpace.Name = "cbkWriteSpace";
            this.cbkWriteSpace.Size = new System.Drawing.Size(144, 16);
            this.cbkWriteSpace.TabIndex = 8;
            this.cbkWriteSpace.Text = "录入时不允许录入空格";
            this.cbkWriteSpace.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "提示：可以按回车键插入\"※\"强制换行";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(546, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "中查找。";
            // 
            // dcboPartVolumeParent
            // 
            this.dcboPartVolumeParent.DisplayMember = "Text";
            this.dcboPartVolumeParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dcboPartVolumeParent.FormattingEnabled = true;
            this.dcboPartVolumeParent.Location = new System.Drawing.Point(410, 23);
            this.dcboPartVolumeParent.ModelName = null;
            this.dcboPartVolumeParent.Name = "dcboPartVolumeParent";
            this.dcboPartVolumeParent.PropertyName = null;
            this.dcboPartVolumeParent.Size = new System.Drawing.Size(121, 20);
            this.dcboPartVolumeParent.TabIndex = 4;
            this.dcboPartVolumeParent.ValueMember = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "定位父辈：自动在所属分卷和";
            // 
            // btnPartVolumeManage
            // 
            this.btnPartVolumeManage.Location = new System.Drawing.Point(156, 23);
            this.btnPartVolumeManage.Name = "btnPartVolumeManage";
            this.btnPartVolumeManage.Size = new System.Drawing.Size(81, 21);
            this.btnPartVolumeManage.TabIndex = 2;
            this.btnPartVolumeManage.Text = "添加分卷";
            this.btnPartVolumeManage.UseVisualStyleBackColor = true;
            this.btnPartVolumeManage.Click += new System.EventHandler(this.btnPartVolumeManage_Click);
            // 
            // dcboVolume
            // 
            this.dcboVolume.DisplayMember = "Text";
            this.dcboVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dcboVolume.FormattingEnabled = true;
            this.dcboVolume.Location = new System.Drawing.Point(65, 24);
            this.dcboVolume.ModelName = null;
            this.dcboVolume.Name = "dcboVolume";
            this.dcboVolume.PropertyName = null;
            this.dcboVolume.Size = new System.Drawing.Size(85, 20);
            this.dcboVolume.TabIndex = 1;
            this.dcboVolume.ValueMember = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "所属分卷";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.tvFamily);
            this.panel1.Location = new System.Drawing.Point(625, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 385);
            this.panel1.TabIndex = 1;
            // 
            // tvFamily
            // 
            this.tvFamily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFamily.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvFamily.FullRowSelect = true;
            this.tvFamily.ImageIndex = 0;
            this.tvFamily.ImageList = this.imgTreeView;
            this.tvFamily.Location = new System.Drawing.Point(0, 0);
            this.tvFamily.Name = "tvFamily";
            this.tvFamily.SelectedImageIndex = 0;
            this.tvFamily.Size = new System.Drawing.Size(598, 385);
            this.tvFamily.TabIndex = 0;
            this.tvFamily.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFamily_NodeMouseClick);
            this.tvFamily.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFamily_NodeMouseDoubleClick);
            // 
            // imgTreeView
            // 
            this.imgTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTreeView.ImageStream")));
            this.imgTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTreeView.Images.SetKeyName(0, "personnel.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dataTextBox4);
            this.groupBox2.Controls.Add(this.dataTextBox3);
            this.groupBox2.Controls.Add(this.dataTextBox2);
            this.groupBox2.Controls.Add(this.dataTextBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 419);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 117);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选填信息";
            // 
            // dataTextBox4
            // 
            this.dataTextBox4.Location = new System.Drawing.Point(331, 69);
            this.dataTextBox4.ModelName = null;
            this.dataTextBox4.Name = "dataTextBox4";
            this.dataTextBox4.PropertyName = null;
            this.dataTextBox4.Size = new System.Drawing.Size(250, 21);
            this.dataTextBox4.TabIndex = 7;
            // 
            // dataTextBox3
            // 
            this.dataTextBox3.Location = new System.Drawing.Point(65, 69);
            this.dataTextBox3.ModelName = null;
            this.dataTextBox3.Name = "dataTextBox3";
            this.dataTextBox3.PropertyName = null;
            this.dataTextBox3.Size = new System.Drawing.Size(100, 21);
            this.dataTextBox3.TabIndex = 6;
            // 
            // dataTextBox2
            // 
            this.dataTextBox2.Location = new System.Drawing.Point(331, 33);
            this.dataTextBox2.ModelName = null;
            this.dataTextBox2.Name = "dataTextBox2";
            this.dataTextBox2.PropertyName = null;
            this.dataTextBox2.Size = new System.Drawing.Size(250, 21);
            this.dataTextBox2.TabIndex = 5;
            // 
            // dataTextBox1
            // 
            this.dataTextBox1.Location = new System.Drawing.Point(65, 33);
            this.dataTextBox1.ModelName = null;
            this.dataTextBox1.Name = "dataTextBox1";
            this.dataTextBox1.PropertyName = null;
            this.dataTextBox1.Size = new System.Drawing.Size(100, 21);
            this.dataTextBox1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "世系图附加说明：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "支系：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "页面侧边标题：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "支系：";
            // 
            // txtGenealogyNoteSel
            // 
            this.txtGenealogyNoteSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenealogyNoteSel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenealogyNoteSel.Location = new System.Drawing.Point(625, 427);
            this.txtGenealogyNoteSel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.txtGenealogyNoteSel.Multiline = true;
            this.txtGenealogyNoteSel.Name = "txtGenealogyNoteSel";
            this.txtGenealogyNoteSel.Size = new System.Drawing.Size(598, 154);
            this.txtGenealogyNoteSel.TabIndex = 3;
            // 
            // btnSetPhoto
            // 
            this.btnSetPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetPhoto.Location = new System.Drawing.Point(13, 551);
            this.btnSetPhoto.Name = "btnSetPhoto";
            this.btnSetPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnSetPhoto.TabIndex = 4;
            this.btnSetPhoto.Text = "设置相片";
            this.btnSetPhoto.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(544, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(407, 551);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "添加为断代谱文";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(323, 551);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(628, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "族丁成员结构图:";
            // 
            // cbShowWorldNumber
            // 
            this.cbShowWorldNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowWorldNumber.AutoSize = true;
            this.cbShowWorldNumber.Checked = true;
            this.cbShowWorldNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowWorldNumber.Location = new System.Drawing.Point(992, 8);
            this.cbShowWorldNumber.Name = "cbShowWorldNumber";
            this.cbShowWorldNumber.Size = new System.Drawing.Size(72, 16);
            this.cbShowWorldNumber.TabIndex = 9;
            this.cbShowWorldNumber.Text = "显示世数";
            this.cbShowWorldNumber.UseVisualStyleBackColor = true;
            this.cbShowWorldNumber.CheckedChanged += new System.EventHandler(this.cbShowWorldNumber_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackgroundImage = global::Selene.Properties.Resources.tree;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.Location = new System.Drawing.Point(1103, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(27, 27);
            this.button7.TabIndex = 14;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackgroundImage = global::Selene.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Location = new System.Drawing.Point(1197, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(27, 27);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackgroundImage = global::Selene.Properties.Resources.find;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFind.Location = new System.Drawing.Point(1135, 0);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(27, 27);
            this.btnFind.TabIndex = 13;
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackgroundImage = global::Selene.Properties.Resources.edit;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Location = new System.Drawing.Point(1166, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(27, 27);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ClansmanAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 586);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbShowWorldNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSetPhoto);
            this.Controls.Add(this.txtGenealogyNoteSel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClansmanAddForm";
            this.Text = "资料录入";
            this.Load += new System.EventHandler(this.GenealogyAddForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGenealogyNoteSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPartVolumeManage;
        private BaseControl.DataComboBox dcboVolume;
        private System.Windows.Forms.Label label2;
        private BaseControl.DataComboBox dcboPartVolumeParent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvFamily;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private BaseControl.DataTextBox dataTextBox2;
        private BaseControl.DataTextBox dataTextBox1;
        private BaseControl.DataTextBox dataTextBox4;
        private BaseControl.DataTextBox dataTextBox3;
        private System.Windows.Forms.Button btnSetPhoto;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbkWriteSpace;
        private System.Windows.Forms.CheckBox cbkNumberToChina;
        private Selene.BaseControl.DataRichTextBox rtxtGenealogyNote;
        private System.Windows.Forms.ImageList imgTreeView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbShowWorldNumber;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button button7;
    }
}