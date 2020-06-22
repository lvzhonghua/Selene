using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Doit.Print.Models
{
    /// <summary>
    /// 线条样式信息
    /// </summary>
    public class LineStyle
    {
        /// <summary>
        /// 线条粗细
        /// </summary>
        public float Weight { get; set; } = 1f;

        /// <summary>
        /// 线条颜色
        /// </summary>
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// 线条样式
        /// </summary>
        public DashStyle DashStyle { get; set; } = DashStyle.Solid;

        /// <summary>
        /// 起始点
        /// </summary>
        public PointF Start { get; set; }

        /// <summary>
        /// 终止点
        /// </summary>
        public PointF End { get; set; }
    }
}
