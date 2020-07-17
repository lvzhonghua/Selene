using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet
{
    /// <summary>
    /// 一棵树中，位于同一层级的节点集合
    /// </summary>
    public class MindNodesOfSampleLevel
    {
        /// <summary>
        /// 节点的层级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 节点集合
        /// </summary>
        public List<MindNode> Nodes { get; private set; } = new List<MindNode>();

        /// <summary>
        /// 最大宽
        /// </summary>
        public float MaxWidth { get; set; }

        /// <summary>
        /// 最大高
        /// </summary>
        public float MaxHeight { get; set; }

        /// <summary>
        /// 将界面加入集合
        /// </summary>
        /// <param name="node">节点</param>
        public void InsertNode(MindNode node)
        {
            this.Nodes.Add(node);
        }
    }
}
