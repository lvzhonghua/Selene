using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet
{
    /// <summary>
    /// 图元的可击中接口
    /// </summary>
    public interface IHitable
    {
        /// <summary>
        /// 击中测试
        /// </summary>
        /// <param name="point">探测点</param>
        /// <returns>击中的图元</returns>
        Glyph HitTest(PointF point);
    }
}
