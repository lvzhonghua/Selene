using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Doit.Print.Models;

namespace Doit.Print.Renderers
{
    /// <summary>
    /// Graphics扩展方法
    /// </summary>
    public static class GraphicsExtension
    {
        /// <summary>
        /// 绘制带上下标的文字内容
        /// </summary>
        /// <param name="graphics">绘图板</param>
        /// <param name="contentWithSuffix">带上下标的文字内容</param>
        public static void DrawContentWithSuffix(this Graphics graphics, ContentWithSuffix contentWithSuffix)
        {
            ContentWithSuffixRenderer.Render(graphics, contentWithSuffix);
        }
    }
}
