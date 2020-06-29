using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Models
{
    /// <summary>
    /// 字符信息
    /// </summary>
    public class CharInfo
    {
        /// <summary>
        /// 字符
        /// </summary>
        public char Char { get; set; }

        /// <summary>
        /// 在当前行的索引
        /// </summary>
        public int IndexInLine { get; set; }

        /// <summary>
        /// 边界
        /// </summary>
        public RectangleF Bounds { get; set; } = RectangleF.Empty;
    }
}
