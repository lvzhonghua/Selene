using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Doit.MindJet.MindTrees;

namespace Doit.MindJet.Commands.MindTrees
{
    /// <summary>
    /// 添加MindNode节点指令
    /// </summary>
    public class NodeAddCommand : ICommand
    {
        protected MindNode parent;
        protected MindNode node;

        public DateTime Time { get; protected set; }

        public string Description { get { return "添加MindNode节点"; } }

        public Image Image { get { return global::Doit.MindJet.Resource.关联图元_48; } }

        public NodeAddCommand(MindNode parent, MindNode node)
        {
            this.parent = parent;
            this.node = node;
        }

        public virtual void Execute()
        {
            this.parent.AddNode(this.node);

            this.Time = DateTime.Now;
        }

        public void Unexecute()
        {
            this.parent.RemoveNode(this.node);

            this.Time = DateTime.Now;
        }
    }
}
