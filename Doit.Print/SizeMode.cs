using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print
{
    /// <summary>
    /// 尺寸模式
    /// </summary>
    public enum SizeMode
    {
        /// <summary>
        /// 自动大小
        /// </summary>
        AutoSize,
        
        /// <summary>
        /// 固定大小
        /// </summary>
        Fixed,
        
        /// <summary>
        /// 宽度固定
        /// </summary>
        WidthFixed,

        /// <summary>
        /// 高度固定
        /// </summary>
        HeightFixed
    }
}
