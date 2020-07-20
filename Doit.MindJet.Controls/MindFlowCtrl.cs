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
using Doit.MindJet.Linkers;

namespace Doit.MindJet.Controls
{
    public partial class MindFlowCtrl : UserControl
    {
        private MindFlow mindFlow = new MindFlow();

        /// <summary>
        /// 思维流程
        /// </summary>
        public MindFlow MindFlow { get { return this.mindFlow; } }

        private Point mousePosition;
        private MindStep currentMindStep = null;

        public MindFlowCtrl()
        {
            InitializeComponent();
        }

        private void panMindFlow_Paint(object sender, PaintEventArgs e)
        {
            this.mindFlow.Draw(e.Graphics);
        }

        private void btnStep_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            ToolStripButton btnStep = sender as ToolStripButton;
            if (btnStep == null) return;

            MindStepCategory stepCategory = MindStepCategory.Normal;

            switch (btnStep.Name)
            {
                case "btnStartStep":
                    stepCategory = MindStepCategory.Start;
                    break;
                case "btnNormalStep":
                default:
                    stepCategory = MindStepCategory.Normal;
                    break;
                case "btnMergeStep":
                    stepCategory = MindStepCategory.Merge;
                    break;
                case "btnSplitStep":
                    stepCategory = MindStepCategory.Split;
                    break;
                case "btnJudgeStep":
                    stepCategory = MindStepCategory.Judge;
                    break;
                case "btnEndStep":
                    stepCategory = MindStepCategory.End;
                    break;
            }

            MindStep mindStep = MindStepFactory.Create(stepCategory);

            btnStep.DoDragDrop(mindStep, DragDropEffects.Move);
        }

        private void panMindFlow_DragDrop(object sender, DragEventArgs e)
        {
            this.panMindFlow.BackColor = SystemColors.Control;
            MindStep mindStep = e.Data.GetData(e.Data.GetFormats()[0]) as MindStep;
            if (mindStep == null) return;

            mindStep.Location = this.panMindFlow.PointToClient(new Point(e.X, e.Y));

            this.mindFlow.AddStep(mindStep);
            this.panMindFlow.Refresh();
        }

        private void panMindFlow_DragEnter(object sender, DragEventArgs e)
        {
            this.panMindFlow.BackColor = SystemColors.Highlight;
            e.Effect = DragDropEffects.Move;
        }

        private void panMindFlow_DragLeave(object sender, EventArgs e)
        {
            this.panMindFlow.BackColor = SystemColors.Control;
        }

        private void panMindFlow_DragOver(object sender, DragEventArgs e)
        {
            this.panMindFlow.BackColor = SystemColors.Highlight;
        }

        private void panMindFlow_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Glyph glyph = this.mindFlow.HitTest(e.Location);
                    if (glyph is MindStep)
                    {
                        this.mousePosition = Control.MousePosition;
                        this.currentMindStep = glyph as MindStep;
                    }
                    if (glyph is MindStepLinker)
                    {
                        if (this.mindFlow.TempConnection == null) this.mindFlow.TempConnection = new MindStepConnection();
                        if (this.mindFlow.TempConnection.From == null)
                        {
                            this.mindFlow.TempConnection.From = glyph as MindStepLinker;
                            this.mindFlow.TempConnection.To = new TempLinker() { Location = e.Location };
                        }
                        else
                        {
                            this.mindFlow.TempConnection.To = glyph as MindStepLinker;
                        }

                    }
                    break;
                case MouseButtons.Right:
                    break;

            }
        }

        private void panMindFlow_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (this.currentMindStep != null)
                    {
                        PointF offset = new PointF(Control.MousePosition.X - this.mousePosition.X,
                                                               Control.MousePosition.Y - this.mousePosition.Y);
                        PointF oldLocation = this.currentMindStep.Location;
                        this.currentMindStep.Location = new PointF(oldLocation.X + offset.X, oldLocation.Y + offset.Y);
                        this.mousePosition = Control.MousePosition;
                        this.panMindFlow.Refresh();
                    }

                    if (this.mindFlow.TempConnection != null && 
                        this.mindFlow.TempConnection.From != null &&
                        this.mindFlow.TempConnection.To is TempLinker)
                    {
                        this.mindFlow.TempConnection.To.Location = e.Location;
                        this.mindFlow.TempConnection.Status = GlyphStatus.Selected;
                        this.panMindFlow.Refresh();
                    }

                    break;
                case MouseButtons.Right:
                    break;

            }
        }

        private void panMindFlow_MouseUp(object sender, MouseEventArgs e)
        {
            this.currentMindStep = null;

            if (this.mindFlow.TempConnection != null &&
                this.mindFlow.TempConnection.From != null &&
                this.mindFlow.TempConnection.To is TempLinker)
            {
                Glyph glyph = this.mindFlow.HitTest(e.Location);

                if (glyph is MindStepLinker && glyph != this.mindFlow.TempConnection.From)
                {
                    this.mindFlow.TempConnection.To = glyph as MindStepLinker;
                    this.mindFlow.TempConnection.Status = GlyphStatus.Normal;
                    this.mindFlow.AddConnection(this.mindFlow.TempConnection);
                }
            }
            
            this.mindFlow.TempConnection = null;
            this.panMindFlow.Refresh();
        }
    }
}
