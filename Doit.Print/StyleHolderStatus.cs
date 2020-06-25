using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print
{
    /// <summary>
    /// 设计器占位符的状态
    /// </summary>
    public enum StyleHolderStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,

        /// <summary>
        /// 正在移动
        /// </summary>
        Moving,

        /// <summary>
        /// 正在调整大小
        /// </summary>
        Resizing,

        /// <summary>
        /// 选中
        /// </summary>
        Selected
    }
}
