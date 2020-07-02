using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Models
{
    /// <summary>
    /// 带上下标的文字内容
    /// </summary>
    public class ContentWithSuffix
    {
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Content { get; set; } = "内容";

        /// <summary>
        /// 上下标内容
        /// </summary>
        public string SuffixContent { get; set; } = "上下标";

        /// <summary>
        /// 样式
        /// </summary>
        public SuffixStyle Style { get; set; } = new SuffixStyle();

        /// <summary>
        /// 文字区域
        /// </summary>
        public RectangleF ContentBounds { get; set; } = RectangleF.Empty;

        /// <summary>
        /// 上下标区域
        /// </summary>
        public RectangleF SuffixBounds { get; set; } = RectangleF.Empty;

        /// <summary>
        /// 整体区域
        /// </summary>
        public RectangleF Bounds { get; set; } = RectangleF.Empty;

        /// <summary>
        /// 位置的X轴坐标
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// 位置的Y轴坐标
        /// </summary>
        public float Y { get; set; }
    }
}
