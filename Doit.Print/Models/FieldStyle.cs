using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 根据内容自动调整大小
        /// </summary>
        public bool AutoSize { get; set; }

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
        /// 大小
        /// </summary>
        public SizeF Size { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Text { get; set; }
    }
}
