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
    /// 修改节点文字的指令
    /// </summary>
    public class MindeNodeTextModifyCommand : ICommand
    {
        protected MindNode node;

        protected string oldText;
        protected string text;

        public DateTime Time { get; protected set; }

        public string Description { get { return "修改节点文字"; } }

        public Image Image { get { return global::Doit.MindJet.Resource.修改_48; } }

        public MindeNodeTextModifyCommand(MindNode node, string oldText, string text)
        {
            this.node = node;
            this.oldText = oldText;
            this.text = text;
        }

        public virtual void Execute()
        {
            this.node.Text = text;

            this.Time = DateTime.Now;
        }

        public void Unexecute()
        {
            this.node.Text = this.oldText;

            this.Time = DateTime.Now;
        }
    }
}
