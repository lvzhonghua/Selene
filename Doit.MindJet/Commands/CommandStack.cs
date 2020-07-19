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

        private Stack<ICommand> commandsOfUndo = new Stack<ICommand>();

        public DateTime LastTime { get; private set; }

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

            this.LastTime = DateTime.Now;
        }

        /// <summary>
        ///  撤销指令
        /// </summary>
        public void Undo()
        {
            if (this.commands.Count == 0) return;

            ICommand command = this.commands.Pop();
            command.Unexecute();

            this.commandsOfUndo.Push(command);

            this.LastTime = DateTime.Now;
        }

        /// <summary>
        /// 重做指令
        /// </summary>
        public void Redo()
        {
            if (this.commandsOfUndo.Count == 0) return;

            ICommand command = this.commandsOfUndo.Pop();
            command.Execute();

            this.commands.Push(command);

            this.LastTime = DateTime.Now;

        }

        /// <summary>
        /// 清空指令栈
        /// </summary>
        public void Clear()
        {
            this.commands.Clear();
            this.commandsOfUndo.Clear();
            this.LastTime = DateTime.Now;
        }
    }
}
