using System;
using System.ComponentModel;
using System.Drawing;

namespace Doit.Print.Models
{
    /// <summary>
    /// 字段样式
    /// </summary>
    public class FieldStyle
    {
        /// <summary>
        /// 关联的数据类型
        /// </summary>
        public Type TypeOfAssociated { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 尺寸模式
        /// </summary>
        public SizeMode SizeMode { get; set; } = SizeMode.AutoSize;

        /// <summary>
        /// 背景色（默认为白色）
        /// </summary>
        public Color BackColor { get; set; } = Color.White;
        
        /// <summary>
        /// 边框样式（默认无边框）
        /// </summary>
        public BorderStyle BorderStyle { get; set; } = BorderStyle.None;

        /// <summary>
        /// 字体（默认为宋体，大小为12）
        /// </summary>
        public Font Font { get; set; } = new Font("宋体",12f);

        /// <summary>
        /// 前景色（默认为黑色）
        /// </summary>
        public Color ForeColor { get; set; } = Color.Black;

        /// <summary>
        /// 位置
        /// </summary>
        public PointF Location { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 边界
        /// </summary>
        public RectangleF Bounds { get; set; }

        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public ContentAlignment TextAlign { get; set; } = ContentAlignment.MiddleCenter;
    }
}
