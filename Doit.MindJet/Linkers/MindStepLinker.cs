using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.Linkers
{
    /// <summary>
    /// 思维步骤连接点
    /// </summary>
    public class MindStepLinker : Linker
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
            this.GraphicsPath.AddEllipse(this.Bounds);

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }
    }
}
