using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Doit.Print.Models;

namespace Doit.Print
{
    /// <summary>
    /// 文字内容拆解器
    /// </summary>
    public class TextDisassembly
    {
        /// <summary>
        /// 文字内容拆解成段落和行
        /// </summary>
        /// <param name="graphics">渲染画布</param>
        /// <param name="content">文字内容</param>
        /// <param name="areaWidth">渲染区宽度</param>
        /// <param name="paragraphStyle">段落样式</param>
        /// <returns>拆解结果</returns>
        public static TextDisassemblyResult Disassembly(Graphics graphics, string content, float areaWidth, ParagraphStyle paragraphStyle)
        {
            TextDisassemblyResult disassemblyResult = new TextDisassemblyResult();
            disassemblyResult.Graphics = graphics;
            disassemblyResult.Content = content;
            disassemblyResult.AreaWidth = areaWidth;
            disassemblyResult.ParagraphStyle = paragraphStyle;

            //拆解成段落
            List<Paragraph> paragraphs = GetParagraphs(content);
            disassemblyResult.Paragraphs = paragraphs;

            for (int index = 0; index < paragraphs.Count; index++)
            {
                Paragraph paragraph = paragraphs[index];

                paragraph.DisassemblyResult = disassemblyResult;
                paragraph.Style = paragraphStyle;

                paragraph.CharLines = GetLines(paragraph);
            }

            if (paragraphs.Count > 0)
            {
                disassemblyResult.Bounds = new RectangleF(paragraphStyle.Padding_Left,
                                                                                paragraphStyle.Padding_Top,
                                                                                areaWidth,
                                                                                paragraphs[paragraphs.Count - 1].Bounds.Bottom - paragraphStyle.Padding_Top);
            }

            return disassemblyResult;
        }

        /// <summary>
        /// 将文字根据换行符拆解成段落
        /// </summary>
        /// <param name="content">文字内容</param>
        /// <returns>段落列表</returns>
        private static List<Paragraph> GetParagraphs(string content)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();

            if (string.IsNullOrEmpty(content)) return paragraphs;

            content += "\r\n";
            char[] chars = content.ToCharArray();
            int charLength = chars.Length;
            
            int paragrahIndex = 0;

            Paragraph paragraph = new Paragraph();
            paragraph.Index = paragrahIndex;
            paragraphs.Add(paragraph);

            StringBuilder sbParagraphContent = new StringBuilder();

            //段落拆分
            for (int index = 0; index < charLength; index++)
            {
                char currentChar = chars[index];
                if ((int)currentChar != 13)
                {
                    if ((int)currentChar != 10) sbParagraphContent.Append(currentChar);
                }
                else //回车符（\r = 13）
                {
                    if (index + 1 >= charLength) break;

                    char nextChar = chars[index + 1];
                    if ((int)nextChar == 10) //换行符（\n = 12）
                    {
                        paragraph = paragraphs[paragrahIndex];
                        paragraph.Content = sbParagraphContent.ToString();

                        //新段落
                        sbParagraphContent.Clear();
                        paragrahIndex++;
                        paragraph = new Paragraph();
                        paragraph.Index = paragrahIndex;
                        paragraphs.Add(paragraph);
                    }
                }
            }

            //去掉在最后一行（废数据）
            paragraphs.RemoveAt(paragraphs.Count - 1);

            return paragraphs;
        }

        /// <summary>
        /// 将段落拆解成行
        /// </summary>
        /// <param name="paragraph">段落</param>
        /// <returns></returns>
        private static List<CharLine> GetLines(Paragraph paragraph)
        {
            List<CharLine> charLines = new List<CharLine>();
           
            Graphics graphics = paragraph.DisassemblyResult.Graphics;
            float areaWidth = paragraph.DisassemblyResult.AreaWidth;
            ParagraphStyle style = paragraph.Style;

            //根据AreaWidth将段落才分成行
            SizeF sizeOfNormalChar = graphics.MeasureString("好", style.Font);
            float normalCharWidth = sizeOfNormalChar.Width;
            float normalCharHeight = sizeOfNormalChar.Height;
            float paragraphSpacing = normalCharHeight * style.ParagraphSpacing;

            paragraph.X = style.Padding_Left;
            float bottomOfPreviousParagraph = (paragraph.Index == 0) ? style.Padding_Top : paragraph.DisassemblyResult.Paragraphs[paragraph.Index - 1].Bounds.Bottom;
            paragraph.Y = bottomOfPreviousParagraph + paragraphSpacing;

            if (string.IsNullOrEmpty(paragraph.Content))   //空段落
            {
                paragraph.Bounds = new RectangleF(paragraph.X, paragraph.Y, areaWidth, normalCharHeight * 1);
                return charLines;
            }

            SizeF sizeOfParagraphContent = graphics.MeasureString(paragraph.Content, style.Font);
            float maxFontHeight = sizeOfParagraphContent.Height;

            float xStartOfFirstLineInParagraph = paragraph.X + style.Indent * normalCharWidth;
            float yOfLine = paragraph.Y;

            if (xStartOfFirstLineInParagraph + sizeOfParagraphContent.Width + style.Padding_Right < areaWidth)
            {
                //一行可以放下整个段落
                CharLine line = new CharLine() { Paragraph = paragraph, IndexInParagraph = 0, Content = paragraph.Content, X = xStartOfFirstLineInParagraph, Y = yOfLine };

                line.Chars = GetChars(line);

                charLines.Add(line);
                yOfLine += normalCharHeight;
            }
            else
            {
                //一行放不下整个段落，分成多行显示
                float xStartOfLine = style.Padding_Left;

                char[] charsOfContent = paragraph.Content.ToArray();

                int lineIndex = 0;
                float xTotal = 0;

                StringBuilder sbLine = new StringBuilder();
                CharLine line = null;

                bool isNewLine = true;

                for (int index = 0; index < charsOfContent.Length; index++)
                {
                    if (lineIndex == 0)
                    {
                        xStartOfLine = xStartOfFirstLineInParagraph;
                    }
                    else
                    {
                        xStartOfLine = style.Padding_Left;
                    }

                    if (isNewLine == true)
                    {
                        xTotal = xStartOfLine;
                        line = new CharLine { Paragraph = paragraph, IndexInParagraph = lineIndex, X = xStartOfLine, Y = yOfLine };
                        charLines.Add(line);

                        yOfLine += normalCharHeight;
                        lineIndex++;

                        isNewLine = false;
                        sbLine.Clear();
                    } 

                    sbLine.Append(charsOfContent[index]);
                    line.Content = sbLine.ToString();
                    SizeF sizeOfChar = graphics.MeasureString(charsOfContent[index].ToString(), style.Font);
                    xTotal += sizeOfChar.Width;

                    if (xTotal > areaWidth - style.Padding_Right - sizeOfChar.Width)   //换新行
                    {
                        line.Chars = GetChars(line);

                        isNewLine = true;
                    }
                }

                if (isNewLine == false) //最后一行
                {
                    line.Chars = GetChars(line);
                }
            }

            paragraph.Bounds = new RectangleF(paragraph.X, paragraph.Y, areaWidth, maxFontHeight * charLines.Count);

            return charLines;
        }

        /// <summary>
        /// 将行分解成字
        /// </summary>
        /// <param name="line">行</param>
        /// <returns>字符集</returns>
        private static List<CharInfo> GetChars(CharLine line)
        {
            List<CharInfo> chars = new List<CharInfo>();
            if (string.IsNullOrEmpty(line.Content)) return chars;

            Graphics graphics = line.Paragraph.DisassemblyResult.Graphics;
            ParagraphStyle style = line.Paragraph.Style;

            char[] charsOfLine = line.Content.ToArray();
            float xOfCharBounds = line.X;
            for (int indexOfCharsOfLine = 0; indexOfCharsOfLine < charsOfLine.Length; indexOfCharsOfLine++)
            {
                CharInfo charInfo = new CharInfo() { Char = charsOfLine[indexOfCharsOfLine], Line = line, IndexInLine = indexOfCharsOfLine };
                SizeF sizeOfChar = graphics.MeasureString(charsOfLine[indexOfCharsOfLine].ToString(), style.Font);
                charInfo.Bounds = new RectangleF(xOfCharBounds, line.Y, sizeOfChar.Width, sizeOfChar.Height);

                chars.Add(charInfo);
                xOfCharBounds += sizeOfChar.Width;
            }
            line.Bounds = new RectangleF(line.X,
                                                       line.Y,
                                                       chars[chars.Count - 1].Bounds.Right - line.X,
                                                       chars[chars.Count - 1].Bounds.Bottom - line.Y);
            return chars;
        }

        #region 废弃代码
        ///// <summary>
        ///// 获得一行文字的字符信息
        ///// </summary>
        ///// <param name="graphics">绘图板</param>
        ///// <param name="lineContent">文字</param>
        ///// <param name="font">字体</param>
        ///// <param name="offset">偏移量</param>
        ///// <returns></returns>
        //private static List<CharInfo> GetCharInfosOfLine(Graphics graphics, string lineContent, Font font, PointF offset)
        //{
        //    int charCount = lineContent.Length;
        //    List<CharInfo> charInfos = new List<CharInfo>();

        //    CharacterRange[] ranges = new CharacterRange[charCount];
        //    int start = 0;
        //    for (int index = 0; index < charCount; index++)
        //    {
        //        ranges[index] = new CharacterRange(start + index, 1);
        //    }

        //    StringFormat stringFormat = new StringFormat();
        //    stringFormat.FormatFlags = StringFormatFlags.NoWrap;
        //    stringFormat.SetMeasurableCharacterRanges(ranges);

        //    //获取最大宽
        //    SizeF size = graphics.MeasureString(lineContent, font);
        //    RectangleF layoutRect = new RectangleF(0.0f, 0.0f, size.Width, size.Height);

        //    Region[] stringRegions = graphics.MeasureCharacterRanges(lineContent, font, layoutRect, stringFormat);

        //    for (int index = 0; index < charCount; index++)
        //    {
        //        Region region = stringRegions[index];
        //        RectangleF bounds = region.GetBounds(graphics);
        //        bounds.Offset(offset);
        //        bounds.Inflate(2f, 1f);

        //        charInfos.Add(new CharInfo() { Bounds = bounds, IndexInLine = index, Char = lineContent[index] });
        //    }

        //    return charInfos;
        //}
        #endregion
    }
}
