using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Doit.MindJet.Trees
{
    public class MindTreeHelper
    {
        /// <summary>
        /// 绘制连接线
        /// </summary>
        /// <param name="graphics">绘图板</param>
        /// <param name="fromNode">起始节点</param>
        /// <param name="toNode">终止节点</param>
        public static void DrawLinkLine(Graphics graphics, MindNode fromNode, MindNode toNode)
        {
            Pen pen = StyleSchema.GetLinkLinePen(GlyphStatus.Unknown);

            Doit.UI.GDIHelper.DrawArrowLine(graphics, fromNode.RightLinker.Location, toNode.LeftLinker.Location, pen.Color, 1,false);
        }

        public static List<MindNode> GetAllExpandedNodesOfTree(MindTree tree)
        {
            List<MindNode> nodes = new List<MindNode>();

            foreach (var node in tree.Nodes)
            {
                nodes.Add(node);
                nodes.AddRange(GetAllExpandedNodesOfNode(node));
            }

            return nodes;
        }

        private static List<MindNode> GetAllExpandedNodesOfNode(MindNode node)
        {
            List<MindNode> nodes = new List<MindNode>();

            if (node.Expanded == false) return nodes;

            foreach (var childNode in node.Nodes)
            {
                nodes.Add(childNode);
                nodes.AddRange(GetAllExpandedNodesOfNode(childNode));
            }

            return nodes;
        }

        public static Dictionary<int, MindNodesOfSameLevel> GetMaxWidthInSameLevel(MindTree tree, Graphics graphics)
        {
            List<MindNode> nodes = GetAllExpandedNodesOfTree(tree);

            int maxLevel = 0;

            foreach (var node in nodes)
            {
                if (maxLevel < node.Level) maxLevel = node.Level;
            }

            Dictionary<int, MindNodesOfSameLevel> nodeDict = new Dictionary<int, MindNodesOfSameLevel>();

            for (int level = 0; level <= maxLevel; level++)
            {
                float maxWidth = 0;
                float maxHeight = 0;
                MindNodesOfSameLevel nodeList = new MindNodesOfSameLevel()
                {
                    Level = level
                };

                foreach (var node in nodes)
                {
                    if (node.Level != level) continue;

                    nodeList.InsertNode(node);
                    node.Measure(graphics);

                    if (maxWidth < node.Bounds.Width) maxWidth = node.Bounds.Width;
                    if (maxHeight < node.Bounds.Height) maxHeight = node.Bounds.Height;
                }

                nodeList.MaxWidth = maxWidth;
                nodeList.MaxHeight = maxHeight;

                nodeDict.Add(level, nodeList);
            }

            return nodeDict;
        }
    }
}
