using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Doit.MindJet.Commands
{
    /// <summary>
    /// 添加MindNode节点指令
    /// </summary>
    public class MindNodeAddCommand : ICommand
    {
        protected MindNode parent;
        protected MindNode node;

        public DateTime ExecuteTime { get; protected set; }

        public string Description { get { return "添加MindNode节点"; } }

        public Image Image { get { return global::Doit.MindJet.Resource.关联图元_48; } }

        public MindNodeAddCommand(MindNode parent, MindNode node)
        {
            this.parent = parent;
            this.node = node;
        }

        public virtual void Execute()
        {
            this.parent.AddNode(this.node);

            this.ExecuteTime = DateTime.Now;
        }
    }
}
