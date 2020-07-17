using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet
{
    /// <summary>
    /// 可击中接口
    /// </summary>
    public interface IHitable
    {
        /// <summary>
        /// 击中测试
        /// </summary>
        /// <param name="point">探测点</param>
        /// <returns>是否击中</returns>
        bool HitTest(PointF point);
    }
}
