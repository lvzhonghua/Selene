using Doit.MindJet.Linkers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindDrafts
{
    public class MindShapeConnection : Glyph
    {
        /// <summary>
        /// 连接起始
        /// </summary>
        public MindShape From { get; set; }

        /// <summary>
        /// 连接终止
        /// </summary>
        public MindShape To { get; set; }

        private PointF fromPoint = PointF.Empty;
        private PointF p2 = PointF.Empty;
        private PointF p3 = PointF.Empty;
        private PointF toPoint = PointF.Empty;

        public override void Measure(Graphics graphics)
        {
            if (this.From == null || this.To == null) return;

            ConnectionPoints connectionPoints = PointCalculator.GetConnectionPoints(this.From, this.To);
            this.fromPoint = connectionPoints.FromPoint;
            this.p2 = connectionPoints.P2;
            this.p3 = connectionPoints.P3;
            this.toPoint = connectionPoints.ToPoint;

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;

            this.GraphicsPath.AddLines(new PointF[] {this.fromPoint,this.p2,this.p3,this.toPoint });

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        public override void Draw(Graphics graphics)
        {
            if (this.From == null || this.To == null) return;

            this.Measure(graphics);

            graphics.DrawPath(StyleSchema.GetLinkLinePen(this.Status), this.GraphicsPath);
        }
    }
}
