﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.Linkers
{
    public class MindShapeLinker : Linker
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
            this.GraphicsPath.AddRectangle(this.Bounds);

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);
            graphics.DrawRectangle(StyleSchema.GetFramePen(this.Status), Rectangle.Round(this.Bounds));
        }
    }
}
