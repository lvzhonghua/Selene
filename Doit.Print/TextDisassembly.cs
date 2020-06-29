using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            if (string.IsNullOrEmpty(content)) throw new Exception("文字内容为空，无法拆解");

            content += "\r\n";
            char[] chars = content.ToCharArray();
            int charLength = chars.Length;

            TextDisassemblyResult disassemblyResult = new TextDisassemblyResult();
            disassemblyResult.Content = content;
            disassemblyResult.AreaWidth = areaWidth;
            disassemblyResult.ParagraphStyle = paragraphStyle;

            int paragrahIndex = 0;

            Paragraph paragraph = new Paragraph();
            paragraph.DisassemblyResult = disassemblyResult;
            paragraph.Style = paragraphStyle;
            paragraph.Index = paragrahIndex;
            disassemblyResult.Paragraphs.Add(paragraph);

            StringBuilder sbParagraphContent = new StringBuilder();
           
            for (int index = 0; index < charLength; index++)
            {
                char currentChar = chars[index];
                if ((int)currentChar != 13) 
                {
                    if((int)currentChar != 10) sbParagraphContent.Append(currentChar);
                }
                else //回车符（\r = 13）
                {
                    if (index + 1 >= charLength) break;

                    char nextChar = chars[index + 1];
                    if ((int)nextChar == 10) //换行符（\n = 12）
                    {
                        paragraph = disassemblyResult.Paragraphs[paragrahIndex];
                        paragraph.Content = sbParagraphContent.ToString();

                        //新段落
                        sbParagraphContent.Clear();
                        paragrahIndex++;
                        paragraph = new Paragraph();
                        paragraph.DisassemblyResult = disassemblyResult;
                        paragraph.Style = paragraphStyle;
                        paragraph.Index = paragrahIndex;
                        disassemblyResult.Paragraphs.Add(paragraph);
                    }
                }

            }

            disassemblyResult.Paragraphs.RemoveAt(disassemblyResult.Paragraphs.Count - 1);

            return disassemblyResult;
        }
    }
}
