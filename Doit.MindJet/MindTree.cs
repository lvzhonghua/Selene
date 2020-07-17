using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Doit.MindJet
{
    /// <summary>
    /// 老图树
    /// </summary>
    public class MindTree : MindNode
    {
        /// <summary>
        /// 选中的节点
        /// </summary>
        public MindNode SelectedNode { get; set; }

        public void AddNode(MindNode parent, MindNode node)
        {
            parent.AddNode(node);
        }

        public override void Measure(Graphics graphics)
        {
            base.Measure(graphics);
        }

        public override void Draw(Graphics graphics)
        {
            Dictionary<int, MindNodesOfSampleLevel> nodeDict = MindTreeHelper.GetMaxWidthInSameLevel(this, graphics);

            int maxLevel = nodeDict.Keys.Max();

            int xStart = 10;
            int yStart = 10;
            int xSpace = 60;
            int ySpace = 10;

            PointF location = new PointF();
            location.X = xStart;

            float maxWidth = 0;

            for (int level = 0; level <= maxLevel; level++)
            {
                MindNodesOfSampleLevel nodeList = nodeDict[level];

                int nodeIndex = 0;

                location.X += xSpace + maxWidth;
                location.Y = yStart;

                foreach (MindNode node in nodeList.Nodes)
                {
                    node.Location = location;

                    node.Measure(graphics);
                    node.Draw(graphics);

                    location.Y += ySpace + node.Bounds.Height;

                    nodeIndex++;
                }

                maxWidth = nodeList.MaxWidth;
            }

            foreach (var nodeList in nodeDict.Values)
            {
                foreach (var node in nodeList.Nodes)
                {
                    node.DrawLinkLine(graphics);
                }
            }
        }

        /// <summary>
        /// 获得树的所有展开的节点
        /// </summary>
        /// <returns>所有展开的节点</returns>
        public List<MindNode> GetAllExpandedNodes()
        {
            return MindTreeHelper.GetAllExpandedNodesOfTree(this);
        }

        /// <summary>
        /// 获取被击中的接点
        /// </summary>
        /// <param name="point">击中测试点</param>
        /// <returns></returns>
        public MindNode GetNodeBeHit(Point point)
        {
            MindNode nodeBeHit = null;
            List<MindNode> nodes = this.GetAllExpandedNodes();

            foreach (var node in nodes)
            {
                if (node.HitTest(point))
                {
                    nodeBeHit = node;
                    break;
                }
                else
                {
                    if(node != this.SelectedNode) node.Status = GlyphStatus.Normal;
                }
            }

            return nodeBeHit;
        }
    }
}
