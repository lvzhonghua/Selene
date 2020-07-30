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
            this.GraphicsPath.FillMode = FillMode.Alternate;

            this.GraphicsPath.AddLines(new PointF[] {this.fromPoint,this.p2,this.p3,this.toPoint });

            //箭头
            int directOfX = this.toPoint.X > this.p3.X ? -1 : 1;
            if (this.toPoint.X == this.p3.X) directOfX = 0;

            int directOfY = this.toPoint.Y > this.p3.Y ? -1 : 1;
            if (this.toPoint.Y == this.p3.Y) directOfY = 0;

            PointF pointUp = new PointF(this.toPoint.X + 6 * directOfX,this.toPoint.Y + 6);
            PointF pointDown = new PointF(this.toPoint.X + 6 * directOfX, this.toPoint.Y - 6);
            PointF pointLeft = new PointF(this.toPoint.X - 6, this.toPoint.Y + 6 * directOfY);
            PointF pointRight = new PointF(this.toPoint.X + 6, this.toPoint.Y + 6 * directOfY);

            if (directOfX == 0)
            {
                this.GraphicsPath.AddLine(this.toPoint, pointLeft);
                this.GraphicsPath.AddLine(this.toPoint, pointRight);
            }

            if (directOfY == 0)
            {
                this.GraphicsPath.AddLine(this.toPoint, pointUp);
                this.GraphicsPath.AddLine(this.toPoint, pointDown);
            }

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
