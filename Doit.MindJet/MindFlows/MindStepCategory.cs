using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 思维步骤类别
    /// </summary>
    public enum MindStepCategory
    {
        /// <summary>
        /// 起始
        /// </summary>
        Start = 0,
        
        /// <summary>
        /// 结束
        /// </summary>
        End = 1,
        
        /// <summary>
        /// 普通
        /// </summary>
        Normal = 2,

        /// <summary>
        /// 判断
        /// </summary>
        Judge = 3,

        /// <summary>
        /// 拆分
        /// </summary>
        Split = 4,

        /// <summary>
        /// 合并
        /// </summary>
        Merge = 5,

    }
}
