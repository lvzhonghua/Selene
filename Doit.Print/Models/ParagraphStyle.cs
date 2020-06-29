using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Models
{
    /// <summary>
    /// 段落样式
    /// </summary>
    public class ParagraphStyle
    {
        /// <summary>
        /// 左边缝（默认值：4f）
        /// </summary>
        public float Padding_Left { get; set; } = 4f;

        /// <summary>
        /// 顶边缝（默认值：4f）
        /// </summary>
        public float Padding_Top { get; set; } = 4f;

        /// <summary>
        /// 右边缝（默认值：4f）
        /// </summary>
        public float Padding_Right { get; set; } = 4f;

        /// <summary>
        /// 底边缝（默认值：4f）
        /// </summary>
        public float Padding_Bottom { get; set; } = 4f;

        /// <summary>
        /// 字体（默认值：宋体，12f）
        /// </summary>
        public Font Font { get; set; } = new Font("宋体",12f);

        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// 行间距
        /// </summary>
        public float LineSpacing { get; set; }

        /// <summary>
        /// 段前间距
        /// </summary>
        public float BeforeSpacing { get; set; }

        /// <summary>
        /// 段后间距
        /// </summary>
        public float AfterSpacing { get; set; }

        /// <summary>
        /// 首行缩进（默认值：2个字符）
        /// </summary>
        public int Indent { get; set; } = 2;

    }
}
