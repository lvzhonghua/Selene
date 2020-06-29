using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Doit.Print.Models
{
    /// <summary>
    /// 字符行
    /// </summary>
    public class CharLine
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 在当前段落的行号
        /// </summary>
        public int IndexInParagraph { get; set; }

        /// <summary>
        /// 字符列表
        /// </summary>
        public List<CharInfo> Chars { get; set; } = new List<CharInfo>();

        /// <summary>
        /// 所属段落
        /// </summary>
        public Paragraph Paragraph { get; set; }

        /// <summary>
        /// 行文字内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 边界
        /// </summary>
        public RectangleF Bounds { get; set; } = RectangleF.Empty;
    }
}
