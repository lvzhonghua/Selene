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
    /// 节点的连接点
    /// </summary>
    public class Linker : Glyph
    {
        /// <summary>
        /// 半径
        /// </summary>
        public float Radius { get; set; } = 6f;

        /// <summary>
        /// 关联的节点
        /// </summary>
        public MindNode Node { get; set; }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);
            graphics.FillPath(StyleSchema.GetFrameBrush(this.Status), this.GraphicsPath);
        }
    }
}
