﻿namespace Doit.MindJet.Controls
{
    partial class MindFlowCtrl
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnStartStep = new System.Windows.Forms.ToolStripButton();
            this.btnNormalStep = new System.Windows.Forms.ToolStripButton();
            this.btnMergeStep = new System.Windows.Forms.ToolStripButton();
            this.btnSplitStep = new System.Windows.Forms.ToolStripButton();
            this.btnJudgeStep = new System.Windows.Forms.ToolStripButton();
            this.btnEndStep = new System.Windows.Forms.ToolStripButton();
            this.panContainer = new System.Windows.Forms.Panel();
            this.panMindFlow = new Doit.Controls.BufferedGraphicsPanel();
            this.toolStrip1.SuspendLayout();
            this.panContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartStep,
            this.btnNormalStep,
            this.btnMergeStep,
            this.btnSplitStep,
            this.btnJudgeStep,
            this.btnEndStep});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1144, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnStartStep
            // 
            this.btnStartStep.Image = global::Doit.MindJet.Controls.Properties.Resources.开始_16;
            this.btnStartStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartStep.Name = "btnStartStep";
            this.btnStartStep.Size = new System.Drawing.Size(52, 22);
            this.btnStartStep.Text = "起始";
            this.btnStartStep.Click += new System.EventHandler(this.btnStartStep_Click);
            // 
            // btnNormalStep
            // 
            this.btnNormalStep.Image = global::Doit.MindJet.Controls.Properties.Resources.普通_16;
            this.btnNormalStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNormalStep.Name = "btnNormalStep";
            this.btnNormalStep.Size = new System.Drawing.Size(52, 22);
            this.btnNormalStep.Text = "普通";
            this.btnNormalStep.Click += new System.EventHandler(this.btnNormalStep_Click);
            // 
            // btnMergeStep
            // 
            this.btnMergeStep.Image = global::Doit.MindJet.Controls.Properties.Resources.合并_16;
            this.btnMergeStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMergeStep.Name = "btnMergeStep";
            this.btnMergeStep.Size = new System.Drawing.Size(52, 22);
            this.btnMergeStep.Text = "合并";
            this.btnMergeStep.Click += new System.EventHandler(this.btnMergeStep_Click);
            // 
            // btnSplitStep
            // 
            this.btnSplitStep.Image = global::Doit.MindJet.Controls.Properties.Resources.分离_16;
            this.btnSplitStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplitStep.Name = "btnSplitStep";
            this.btnSplitStep.Size = new System.Drawing.Size(52, 22);
            this.btnSplitStep.Text = "拆分";
            this.btnSplitStep.Click += new System.EventHandler(this.btnSplitStep_Click);
            // 
            // btnJudgeStep
            // 
            this.btnJudgeStep.Image = global::Doit.MindJet.Controls.Properties.Resources.判断_16;
            this.btnJudgeStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJudgeStep.Name = "btnJudgeStep";
            this.btnJudgeStep.Size = new System.Drawing.Size(52, 22);
            this.btnJudgeStep.Text = "判断";
            this.btnJudgeStep.Click += new System.EventHandler(this.btnJudgeStep_Click);
            // 
            // btnEndStep
            // 
            this.btnEndStep.Image = global::Doit.MindJet.Controls.Properties.Resources.结束_16;
            this.btnEndStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEndStep.Name = "btnEndStep";
            this.btnEndStep.Size = new System.Drawing.Size(52, 22);
            this.btnEndStep.Text = "结束";
            this.btnEndStep.Click += new System.EventHandler(this.btnEndStep_Click);
            // 
            // panContainer
            // 
            this.panContainer.AutoScroll = true;
            this.panContainer.Controls.Add(this.panMindFlow);
            this.panContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContainer.Location = new System.Drawing.Point(0, 25);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(1144, 678);
            this.panContainer.TabIndex = 2;
            // 
            // panMindFlow
            // 
            this.panMindFlow.Location = new System.Drawing.Point(1, 1);
            this.panMindFlow.Name = "panMindFlow";
            this.panMindFlow.Size = new System.Drawing.Size(1073, 659);
            this.panMindFlow.TabIndex = 3;
            this.panMindFlow.Paint += new System.Windows.Forms.PaintEventHandler(this.panMindFlow_Paint);
            // 
            // MindFlowCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panContainer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MindFlowCtrl";
            this.Size = new System.Drawing.Size(1144, 703);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnStartStep;
        private System.Windows.Forms.Panel panContainer;
        private Doit.Controls.BufferedGraphicsPanel panMindFlow;
        private System.Windows.Forms.ToolStripButton btnEndStep;
        private System.Windows.Forms.ToolStripButton btnNormalStep;
        private System.Windows.Forms.ToolStripButton btnMergeStep;
        private System.Windows.Forms.ToolStripButton btnSplitStep;
        private System.Windows.Forms.ToolStripButton btnJudgeStep;
    }
}
