using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Permissions;

namespace Doit.MindJet
{
    /// <summary>
    /// 抽象图元
    /// </summary>
    public abstract class Glyph : IHitable, IDrawable
    {
        /// <summary>
        /// 图元状态
        /// </summary>
        public GlyphStatus Status { get; set; }
        public abstract bool HitTest(PointF point);

        public abstract void Draw(Graphics graphics);

        public abstract void Measure(Graphics graphics);
    }
}
