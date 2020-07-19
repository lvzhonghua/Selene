using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Doit.MindJet.Trees;

namespace Doit.MindJet.Tool
{
    public partial class FormNodeList : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private MindTree mindTree;
        /// <summary>
        /// 节点
        /// </summary>
        public MindTree MindTree 
        {
            get { return this.mindTree; }
            set 
            {
                this.mindTree = value;
                if (this.mindTree == null) return;

                this.ListTree();
            }
        }
        public FormNodeList()
        {
            InitializeComponent();
        }

        private void ListTree()
        {
            this.tvTree.Nodes.Clear();

            foreach (var node in this.mindTree.Nodes)
            {
                TreeNode tvNode = this.tvTree.Nodes.Add($"{node.Text} - {node.Level}");
                tvNode.Tag = node;
                tvNode.ImageKey = "node-tree_16.png";

                if (node.Nodes.Count == 0)
                {
                    tvNode.ImageKey = "节点_16.png";
                    continue;
                }

                this.ListNodes(tvNode, node);
            }

            this.tvTree.ExpandAll();

            Dictionary<int, MindNodesOfSameLevel> nodeList = MindTreeHelper.GetMaxWidthInSameLevel(this.mindTree,this.CreateGraphics());

            this.tvNodeInSameLevel.Nodes.Clear();

            foreach (int level in nodeList.Keys)
            {
                MindNodesOfSameLevel nodes = nodeList[level];
                TreeNode tvNode = this.tvNodeInSameLevel.Nodes.Add($"{level} - {nodes.MaxWidth}");
                tvNode.ImageKey = "子级_16.png";

                foreach (var node in nodes.Nodes)
                {
                    TreeNode tvSubNode = tvNode.Nodes.Add($"{node.Text} - {node.Bounds.Width}");
                    tvSubNode.ImageKey = "节点_16.png";
                }

            }
        }

        private void ListNodes(TreeNode tvNode, MindNode node)
        {
            foreach (var subNode in node.Nodes)
            {
                TreeNode tvSubNode = tvNode.Nodes.Add($"{subNode.Text} - {subNode.Level}");
                tvSubNode.Tag = subNode;
                tvSubNode.ImageKey = "node-tree_16.png";

                if (subNode.Nodes.Count == 0)
                {
                    tvSubNode.ImageKey = "节点_16.png";
                    continue;
                }

                this.ListNodes(tvSubNode, subNode);
            }
        }
    }
}
