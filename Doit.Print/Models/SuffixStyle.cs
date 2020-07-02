using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Models
{
    /// <summary>
    /// 上下标
    /// </summary>
    public class SuffixStyle
    {
        /// <summary>
        /// 类型（默认：上标）
        /// </summary>
        public SuffixType Type { get; set; } = SuffixType.Supper;

        /// <summary>
        /// 文字内容字体（默认：宋体，12f）
        /// </summary>
        public Font ContentFont { get; set; } = new Font("宋体",12f);

        /// <summary>
        /// 文字内容颜色（默认：黑色）
        /// </summary>
        public Color ContentColor { get; set; } = Color.Black;

        /// <summary>
        /// 上下标字体（默认：宋体，6f）
        /// </summary>
        public Font SuffixFont { get; set; } = new Font("宋体", 6f);

        /// <summary>
        /// 上下标颜色（默认：黑色）
        /// </summary>
        public Color SuffixColor { get; set; } = Color.Black;
    }
}
