using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.Commands
{
    /// <summary>
    /// 指令栈（支持指令撤销）
    /// </summary>
    public class CommandStack
    {
        private Stack<ICommand> commands = new Stack<ICommand>();

        public DateTime Time { get; private set; }

        /// <summary>
        /// 获得指令集合
        /// </summary>
        /// <returns></returns>
        public ICommand[] ToArray()
        {
            return this.commands.ToArray();
        }

        /// <summary>
        /// 附加并执行指令
        /// </summary>
        /// <param name="command">指令对象</param>
        public void AppendAndExecute(ICommand command)
        {
            if (command == this) return;

            this.commands.Push(command);
            command.Execute();

            this.Time = DateTime.Now;
        }

        /// <summary>
        ///  撤销指令
        /// </summary>
        /// <returns>被撤销的指令</returns>
        public ICommand Undo()
        {
            ICommand command = null;
            if (this.commands.Count > 0) command = this.commands.Pop();

            this.Time = DateTime.Now;

            return command;
        }

        /// <summary>
        /// 清空指令栈
        /// </summary>
        public void Clear()
        {
            this.commands.Clear();
            this.Time = DateTime.Now;
        }
    }
}
