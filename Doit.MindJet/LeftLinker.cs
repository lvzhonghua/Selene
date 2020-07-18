using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet
{
    /// <summary>
    /// 左侧连接点
    /// </summary>
    public class LeftLinker : Linker
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
            this.GraphicsPath.AddPie(Rectangle.Round(this.Bounds), 90, 180);

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }
    }
}
