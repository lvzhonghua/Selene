using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Doit.MindJet.Linkers
{
    public class TempLinker : Linker
    {
        public override void Measure(Graphics graphics)
        {
            this.Bounds = new RectangleF()
            {
                X = this.Location.X - this.Radius,
                Y = this.Location.Y - this.Radius,
                Width = this.Radius * 2,
                Height = this.Radius * 2
            };

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddPolygon(new PointF[]
                                                        {
                                                            new PointF(this.Location.X, this.Location.Y - this.Radius),
                                                            new PointF(this.Location.X + this.Radius, this.Location.Y),
                                                            new PointF(this.Location.X, this.Location.Y + this.Radius)
                                                        });

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);
            graphics.FillPath(StyleSchema.GetFrameBrush(GlyphStatus.Selected), this.GraphicsPath);
        }
    }
}
