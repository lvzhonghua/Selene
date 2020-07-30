using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Doit.MindJet.MindDrafts
{
    public class TempShape : MindShape
    {
        public TempShape()
        {
            this.Category = MindShapeCategory.Temp;

            this.LeftLinker.Parent = this;
            this.TopLinker.Parent = this;
            this.RightLinker.Parent = this;
            this.BottomLinker.Parent = this;
        }

        private PointF[] points = new PointF[3] { PointF.Empty,PointF.Empty,PointF.Empty};

        public override void Measure(Graphics graphics)
        {
            this.Bounds = new RectangleF(this.Location, new SizeF(20,10));

            points[0].X = this.Bounds.Left;
            points[0].Y = this.Bounds.Top;

            points[1].X = this.Bounds.Right;
            points[1].Y = (this.Bounds.Top + this.Bounds.Bottom) / 2;

            points[2].X = this.Bounds.Left;
            points[2].Y = this.Bounds.Bottom;

            this.LeftLinker.Location = new PointF(this.Bounds.Left, (this.Bounds.Top + this.Bounds.Bottom) / 2);
            this.TopLinker.Location = new PointF((this.Bounds.Left + this.Bounds.Right) / 2, this.Bounds.Top);
            this.RightLinker.Location = new PointF(this.Bounds.Right, (this.Bounds.Top + this.Bounds.Bottom) / 2);
            this.BottomLinker.Location = new PointF((this.Bounds.Left + this.Bounds.Right) / 2, this.Bounds.Bottom);

            this.LeftLinker.Measure(graphics);
            this.TopLinker.Measure(graphics);
            this.RightLinker.Measure(graphics);
            this.BottomLinker.Measure(graphics);

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddRectangle(this.Bounds);

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);

            //绘制边框
            graphics.FillPolygon(StyleSchema.GetFrameBrush(GlyphStatus.Selected),this.points);
        }
    }
}
