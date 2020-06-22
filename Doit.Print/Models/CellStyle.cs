using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Doit.Print.Models
{
    public class CellStyle
    {
        /// <summary>
        /// 单元样式关联的数据对象类型
        /// </summary>
        public Type AssociateType { get; set; }

        /// <summary>
        /// 数据对象成员的字体设置信息
        /// </summary>
        public Dictionary<string, Font> CellMemberFonts { get; set; } = new Dictionary<string, Font>();

        /// <summary>
        /// 数据对象成员的位置信息
        /// </summary>
        public Dictionary<string, PointF> CellMemberLocations { get; set; } = new Dictionary<string, PointF>();

        /// <summary>
        /// 单元边界
        /// </summary>
        public RectangleF Bounds { get; set; }

        /// <summary>
        /// 线条列表
        /// </summary>
        public List<LineStyle> Lines { get; set; } = new List<LineStyle>();

    }
}
