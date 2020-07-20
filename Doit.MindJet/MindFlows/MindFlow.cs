using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 思维流程
    /// </summary>
    public class MindFlow : Glyph
    {
        /// <summary>
        /// 临时连接
        /// </summary>
        public MindStepConnection TempConnection { get; set; } = null; 

        private List<MindStepConnection> connections = new List<MindStepConnection>();

        /// <summary>
        /// 步骤连接
        /// </summary>
        public List<MindStepConnection> Connections { get { return this.connections; } }

        /// <summary>
        /// 添加连接
        /// </summary>
        /// <param name="stepConnection">连接</param>
        public void AddConnection(MindStepConnection stepConnection)
        {
            this.connections.Add(stepConnection);
        }

        private List<MindStep> steps = new List<MindStep>();
        
        /// <summary>
        /// 流程步骤
        /// </summary>
        public List<MindStep> Steps { get { return this.steps; } }

        /// <summary>
        /// 添加步骤
        /// </summary>
        /// <param name="step">步骤</param>
        public void AddStep(MindStep step)
        {
            this.steps.Add(step);
        }

        /// <summary>
        /// 移除步骤
        /// </summary>
        /// <param name="step"></param>
        public void RemoveStep(MindStep step)
        {
            this.steps.Remove(step);
        }

        public override void Draw(Graphics graphics)
        {
            foreach (var step in this.steps)
            {
                step.Draw(graphics);
            }

            foreach (var connection in this.connections)
            {
                connection.Draw(graphics);
            }

            if (this.TempConnection != null) this.TempConnection.Draw(graphics);
        }

        public override Glyph HitTest(PointF point)
        {
            Glyph glyph = null;
            foreach (var step in this.steps)
            {
                glyph = step.HitTest(point);
                if (glyph != null) break;
            }

            return glyph;
        }
    }
}
