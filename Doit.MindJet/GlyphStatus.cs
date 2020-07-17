using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet
{
    /// <summary>
    /// 图元的状态
    /// </summary>
    public enum GlyphStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        
        /// <summary>
        /// 选中
        /// </summary>
        Selected = 1,
        
        /// <summary>
        /// 当前
        /// </summary>
        Current = 2,

        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 3
    }
}
