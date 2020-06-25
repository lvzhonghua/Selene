using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Models
{
    /// <summary>
    /// 边框的样式
    /// </summary>
    public class BorderStyle
    {
        /// <summary>
        /// 样色
        /// </summary>
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// 宽度
        /// </summary>
        public float Weight { get; set; } = 1f;

        /// <summary>
        /// 线性
        /// </summary>
        public DashStyle DashStyle { get; set; } = DashStyle.Solid;

        /// <summary>
        /// 圆角半径（左上角）
        /// </summary>
        public float CornerRadius_Left_Top { get; set; } = 0f;

        /// <summary>
        /// 圆角半径（右上角）
        /// </summary>
        public float CornerRadius_Right_Top { get; set; } = 0f;

        /// <summary>
        /// 圆角半径（左下角）
        /// </summary>
        public float CornerRadius_Left_Bottom { get; set; } = 0f;

        /// <summary>
        /// 圆角半径（右下角）
        /// </summary>
        public float CornerRadius_Right_Bottom { get; set; } = 0f;

        private static BorderStyle none = new BorderStyle { Weight = 0f };
   
        /// <summary>
        /// 无边框
        /// </summary>
        public static BorderStyle None 
        {
            get { return none; }
        }

        private static BorderStyle solid = new BorderStyle { Weight = 1f, DashStyle = DashStyle.Solid };

        /// <summary>
        /// 实线边框
        /// </summary>
        public static BorderStyle Solid 
        {
            get { return solid; }
        }
    }
}
