using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.Commands
{
    /// <summary>
    /// 指令串
    /// </summary>
    public class MacroCommand : ICommand
    {
        private List<ICommand> commands = new List<ICommand>();
        public string Description { get { return "组合指令"; } }

        public DateTime ExecuteTime { get; private set; }

        public Image Image { get { return global::Doit.MindJet.Resource.指令集_48; } }

        /// <summary>
        /// 附加指令
        /// </summary>
        /// <param name="command">指令对象</param>
        public void Append(ICommand command)
        {
            if (command == this) return;

            this.commands.Add(command);
        }

        public void Execute()
        {
            foreach (var command in this.commands)
            {
                command.Execute();
            }

            this.ExecuteTime = DateTime.Now;
        }
    }
}
