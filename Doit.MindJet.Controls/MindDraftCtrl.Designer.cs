namespace Doit.MindJet.Controls
{
    partial class MindDraftCtrl
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
            this.panContainer = new System.Windows.Forms.Panel();
            this.panMindDraft = new Doit.Controls.BufferedGraphicsPanel();
            this.panContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panContainer
            // 
            this.panContainer.AutoScroll = true;
            this.panContainer.Controls.Add(this.panMindDraft);
            this.panContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContainer.Location = new System.Drawing.Point(0, 0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(987, 630);
            this.panContainer.TabIndex = 2;
            // 
            // panMindDraft
            // 
            this.panMindDraft.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panMindDraft.Location = new System.Drawing.Point(1, 1);
            this.panMindDraft.Name = "panMindDraft";
            this.panMindDraft.Size = new System.Drawing.Size(924, 595);
            this.panMindDraft.TabIndex = 3;
            this.panMindDraft.Paint += new System.Windows.Forms.PaintEventHandler(this.panMindDraft_Paint);
            this.panMindDraft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panMindDraft_MouseDown);
            this.panMindDraft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panMindDraft_MouseMove);
            this.panMindDraft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panMindDraft_MouseUp);
            // 
            // MindDraftCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panContainer);
            this.Name = "MindDraftCtrl";
            this.Size = new System.Drawing.Size(987, 630);
            this.Load += new System.EventHandler(this.MindDraftCtrl_Load);
            this.panContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panContainer;
        private Doit.Controls.BufferedGraphicsPanel panMindDraft;
    }
}
