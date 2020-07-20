using Doit.MindJet.Linkers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 步骤之间的连接
    /// </summary>
    public class MindStepConnection : Glyph
    {
        /// <summary>
        /// 连接起始点
        /// </summary>
        public Linker From { get; set; }

        /// <summary>
        /// 连接终止点
        /// </summary>
        public Linker To { get; set; }

        private PointF from = PointF.Empty;
        private PointF to = PointF.Empty;

        public override void Measure(Graphics graphics)
        {
            if (this.From == null || this.To == null) return;

            this.from.X = this.From.Location.X + StyleSchema.CurrentSchema.LinkerRadius;
            this.from.Y = this.From.Location.Y;

            this.to.X = this.To.Location.X + StyleSchema.CurrentSchema.LinkerRadius;
            this.to.Y = this.To.Location.Y;

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;

            this.GraphicsPath.AddPath(Doit.UI.GEOHelper.CreateBezierPath(this.from, this.to),true);

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        public override void Draw(Graphics graphics)
        {
            if (this.From == null || this.To == null) return;

            this.Measure(graphics);

            Doit.UI.GDIHelper.DrawArrowLine(graphics,
                                                              this.from,
                                                              this.to,
                                                              StyleSchema.GetLinkLinePen(this.Status).Color,
                                                              3);
        }
    }
}
