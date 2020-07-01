using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Models
{
    /// <summary>
    /// 段落
    /// </summary>
    public class Paragraph
    {
        /// <summary>
        /// 段落编号
        /// </summary>
        public int Index { get; set; }
        
        /// <summary>
        /// 段落渲染区宽度
        /// </summary>
        public float AreaWidth { get; set; }

        /// <summary>
        /// 段落样式
        /// </summary>
        public ParagraphStyle Style { get; set; }

        /// <summary>
        /// 字符数
        /// </summary>
        public int CharCount { get; set; }

        /// <summary>
        /// 行数
        /// </summary>
        public int LineCount { get { return this.CharLines.Count; } }

        /// <summary>
        /// 文字行列表
        /// </summary>
        public List<CharLine> CharLines { get; set; } = new List<CharLine>();

        /// <summary>
        /// 所属拆解结果
        /// </summary>
        public TextDisassemblyResult DisassemblyResult { get; set; }

        /// <summary>
        /// 段落文字内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 边界
        /// </summary>
        public RectangleF Bounds { get; set; } = RectangleF.Empty;

        /// <summary>
        /// 边界的X轴坐标
        /// </summary>
        public float X { get; set; } = 0f;

        /// <summary>
        /// 边界的Y轴坐标
        /// </summary>
        public float Y { get; set; } = 0f;
    }
}
