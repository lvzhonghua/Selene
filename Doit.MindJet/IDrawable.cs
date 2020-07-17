using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet
{
    /// <summary>
    /// 可绘制接口
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// 计算尺寸与位置
        /// </summary>
        /// <param name="graphics">绘图板</param>
        void Measure(Graphics graphics);

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="graphics">绘图板</param>
        void Draw(Graphics graphics);
    }
}
