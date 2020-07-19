using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Doit.MindJet.MindFlows;
using System.Drawing.Drawing2D;

namespace Doit.MindJet.Controls
{
    public partial class MindFlowCtrl : UserControl
    {
        private MindStep startStepOfTest = null;
        private MindStep endStepOfTest = null;
        private MindStep normalStepOfTest = null;
        private MindStep mergeStepOfTest = null;
        private MindStep splitStepOfTest = null;
        private MindStep judgeStepOfTest = null;

        public MindFlowCtrl()
        {
            InitializeComponent();
        }

        private void StepDrawTest(Graphics graphics)
        {
            if (this.startStepOfTest != null) this.startStepOfTest.Draw(graphics);
            if (this.endStepOfTest != null) this.endStepOfTest.Draw(graphics);
            if (this.normalStepOfTest != null) this.normalStepOfTest.Draw(graphics);
            if (this.mergeStepOfTest != null) this.mergeStepOfTest.Draw(graphics);
            if (this.splitStepOfTest != null) this.splitStepOfTest.Draw(graphics);
            if (this.judgeStepOfTest != null) this.judgeStepOfTest.Draw(graphics);
        }

        private void panMindFlow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            this.StepDrawTest(e.Graphics);
        }

        private void btnStartStep_Click(object sender, EventArgs e)
        {
            this.startStepOfTest = MindStepFactory.Create(MindStepCategory.Start, new PointF(200, 100));

            this.panMindFlow.Refresh();
        }

        private void btnEndStep_Click(object sender, EventArgs e)
        {
            this.endStepOfTest = MindStepFactory.Create(MindStepCategory.End, new PointF(200, 200));

            this.panMindFlow.Refresh();
        }

        private void btnNormalStep_Click(object sender, EventArgs e)
        {
            this.normalStepOfTest = MindStepFactory.Create(MindStepCategory.Normal, new PointF(200, 300));

            this.panMindFlow.Refresh();
        }

        private void btnMergeStep_Click(object sender, EventArgs e)
        {
            this.mergeStepOfTest = MindStepFactory.Create(MindStepCategory.Merge, new PointF(300, 300));

            this.panMindFlow.Refresh();
        }

        private void btnSplitStep_Click(object sender, EventArgs e)
        {
            this.splitStepOfTest = MindStepFactory.Create(MindStepCategory.Split, new PointF(300, 200));

            this.panMindFlow.Refresh();
        }

        private void btnJudgeStep_Click(object sender, EventArgs e)
        {
            this.judgeStepOfTest = MindStepFactory.Create(MindStepCategory.Judge, new PointF(300, 400));

            this.panMindFlow.Refresh();
        }
    }
}
