using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Doit.MindJet.Trees;

namespace Doit.MindJet.Commands
{
    /// <summary>
    /// 移除MindNode节点指令
    /// </summary>
    public class MindNodeRemoveCommand : ICommand
    {
        protected MindNode parent;
        protected MindNode node;

        public DateTime Time { get; protected set; }

        public string Description { get { return "移除MindNode节点"; } }

        public Image Image { get { return global::Doit.MindJet.Resource.delete_48; } }

        public MindNodeRemoveCommand(MindNode parent, MindNode node)
        {
            this.parent = parent;
            this.node = node;
        }

        public virtual void Execute()
        {
            this.parent.RemoveNode(this.node);

            this.Time = DateTime.Now;
        }

        public void Unexecute()
        {
            this.parent.AddNode(this.node);

            this.Time = DateTime.Now;
        }
    }
}
