using Doit.Print.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Renderers
{
    /// <summary>
    /// 带上小标的文本渲染器
    /// </summary>
    class ContentWithSuffixRenderer
    {
        /// <summary>
        /// 绘制带上下标的文字内容
        /// </summary>
        /// <param name="graphics">绘图板</param>
        /// <param name="contentWithSuffix">带上下标的文字内容</param>
        public static void Render(Graphics graphics, ContentWithSuffix contentWithSuffix)
        {
            SuffixStyle style = contentWithSuffix.Style;

            SizeF sizeOfContent = graphics.MeasureString(contentWithSuffix.Content, style.ContentFont);
            contentWithSuffix.ContentBounds = new RectangleF(contentWithSuffix.X,
                                                                                     contentWithSuffix.Y,
                                                                                     sizeOfContent.Width,
                                                                                     sizeOfContent.Height);

            SizeF sizeOfSuffix = graphics.MeasureString(contentWithSuffix.SuffixContent, style.SuffixFont);

            SuffixType type = style.Type;

            switch (type)
            {
                case SuffixType.Supper:
                    contentWithSuffix.SuffixBounds = new RectangleF(contentWithSuffix.ContentBounds.Right,
                                                                                          contentWithSuffix.Y,
                                                                                          sizeOfSuffix.Width,
                                                                                          sizeOfSuffix.Height);
                    break;
                case SuffixType.Sub:
                    contentWithSuffix.SuffixBounds = new RectangleF(contentWithSuffix.ContentBounds.Right,
                                                                                          contentWithSuffix.ContentBounds.Bottom - sizeOfSuffix.Height,
                                                                                          sizeOfSuffix.Width,
                                                                                          sizeOfSuffix.Height);
                    break;
            }

            contentWithSuffix.Bounds = new RectangleF(contentWithSuffix.X,
                                                                          contentWithSuffix.Y,
                                                                          contentWithSuffix.SuffixBounds.Right - contentWithSuffix.X,
                                                                          contentWithSuffix.ContentBounds.Bottom - contentWithSuffix.Y);

            SolidBrush brush = new SolidBrush(style.ContentColor);
            graphics.DrawString(contentWithSuffix.Content, style.ContentFont, brush, contentWithSuffix.ContentBounds);

            brush.Color = style.SuffixColor;
            graphics.DrawString(contentWithSuffix.SuffixContent, style.SuffixFont, brush, contentWithSuffix.SuffixBounds);
        }
    }
}
