using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.Commands
{
    /// <summary>
    /// 指令接口
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 描述
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 指令执行的时间
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// 指令图标
        /// </summary>
        Image Image { get; }

        /// <summary>
        /// 执行
        /// </summary>
        void Execute();

        /// <summary>
        /// 反执行，对撤销的支持
        /// </summary>
        void Unexecute();
    }
}
