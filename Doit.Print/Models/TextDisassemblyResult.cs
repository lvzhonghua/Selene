using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Models
{
    /// <summary>
    /// 文字内容拆解结果
    /// </summary>
    public class TextDisassemblyResult
    {
        /// <summary>
        /// 绘图板
        /// </summary>
        public Graphics Graphics { get; set; }

        /// <summary>
        /// 渲染区宽度
        /// </summary>
        public float AreaWidth { get; set; }

        /// <summary>
        /// 段落样式
        /// </summary>
        public ParagraphStyle ParagraphStyle { get; set; }

        /// <summary>
        /// 字符数
        /// </summary>
        public int CharCount { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int LineCount { get; set; }

        /// <summary>
        /// 段落数
        /// </summary>
        public int ParagraphCount { get { return this.Paragraphs.Count; } }

        /// <summary>
        /// 段落列表
        /// </summary>
        public List<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();

        /// <summary>
        /// 段落文字内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 边界
        /// </summary>
        public RectangleF Bounds { get; set; } = RectangleF.Empty;
    }
}
