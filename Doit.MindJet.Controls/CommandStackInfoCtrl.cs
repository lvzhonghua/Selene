using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Doit.MindJet.Commands;

namespace Doit.MindJet.Controls
{
    public class CommandStackInfoCtrl : Panel
    {
        private CommandStack commandStack;

        /// <summary>
        /// 指令栈
        /// </summary>
        public CommandStack CommandStack
        {
            get { return this.commandStack; }
            set
            {
                this.commandStack = value;
                this.ListCommands();
            }
        }

        public CommandStackInfoCtrl()
        {
            this.AutoScroll = true;
        }

        private void ListCommands()
        {
            this.Controls.Clear();
            if (this.commandStack == null) return;

            ICommand[] commands = this.commandStack.ToArray();
            if (commands == null || commands.Length == 0) return;

            for (int index = commands.Length - 1; index >= 0; index--)
            {
                ICommand command = commands[index];
                CommandInfoCtrl infoCtrl = new CommandInfoCtrl();
                infoCtrl.Command = command;
                infoCtrl.Dock = DockStyle.Top;

                this.Controls.Add(infoCtrl);
            }

        }
    }
}
