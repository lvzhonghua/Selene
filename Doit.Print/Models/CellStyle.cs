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
        /// 字段或属性的样式
        /// </summary>
        public Dictionary<string, FieldStyle> FieldStyles { get; set; } = new Dictionary<string, FieldStyle>();

        /// <summary>
        /// 单元边界
        /// </summary>
        public RectangleF Bounds { get; set; }

        /// <summary>
        /// 线条列表
        /// </summary>
        public List<LineStyle> LineStyles { get; set; } = new List<LineStyle>();

    }
}
