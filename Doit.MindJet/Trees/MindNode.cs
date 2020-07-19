using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Doit.MindJet.Linkers;

namespace Doit.MindJet.Trees
{
    /// <summary>
    /// 脑图节点
    /// </summary>
    public class MindNode : Glyph
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 节点文字
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public MindNode Parent { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<MindNode> Nodes { get; private set; } = new List<MindNode>();

        /// <summary>
        /// 层级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 左侧节点
        /// </summary>
        public Linker LeftLinker { get; set; } = new MindNodeLeftLinker();

        /// <summary>
        /// 右侧节点
        /// </summary>
        public Linker RightLinker { get; set; } = new MindNodeRightLinker();

        /// <summary>
        /// 子节点展开
        /// </summary>
        public bool Expanded { get; set; } = true;

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node">节点</param>
        public void AddNode(MindNode node)
        {
            node.Level = this.Level + 1;
            node.Parent = this;
            this.Nodes.Add(node);
        }

        /// <summary>
        /// 移除节点
        /// </summary>
        /// <param name="node">节点</param>
        public void RemoveNode(MindNode node)
        {
            this.Nodes.Remove(node);
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfName = graphics.MeasureString(this.Text,StyleSchema.CurrentSchema.TextFont);
            this.Bounds = new RectangleF(this.Location, new SizeF(sizeOfName.Width + 2f, sizeOfName.Height + 4f));

            this.LeftLinker.Location = new PointF(this.Bounds.Left, (this.Bounds.Top + this.Bounds.Bottom) / 2);
            this.LeftLinker.Parent = this;
            this.RightLinker.Location = new PointF(this.Bounds.Right, (this.Bounds.Top + this.Bounds.Bottom) / 2);
            this.RightLinker.Parent = this;
        }

        /// <summary>
        /// 绘制连接线
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void DrawLinkLine(Graphics graphics)
        {
            if (this.Expanded == false) return;
            //绘制与子节点的连线
            foreach (MindNode childNode in this.Nodes)
            {
                MindTreeHelper.DrawLinkLine(graphics, this, childNode);
            }
        }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);
       
            //绘制边框
            graphics.DrawRectangle(StyleSchema.GetFramePen(this.Status), Rectangle.Round(this.Bounds));
            //绘制Name
            graphics.DrawString(this.Text,
                                          StyleSchema.CurrentSchema.TextFont,
                                          StyleSchema.GetTextBrush(this.Status), 
                                          new PointF(this.Location.X + 2, this.Location.Y + 4));
            //绘制左边节点标志
            this.LeftLinker.Draw(graphics);
            this.RightLinker.Measure(graphics);
            //绘制右边节点标志
            if (this.Nodes.Count > 0) this.RightLinker.Draw(graphics);

        }

        public override Glyph HitTest(PointF point)
        {
            if (this.Bounds.Contains(point))  return this;

            if(this.LeftLinker.HitTest(point) != null) return this.LeftLinker;
            if(this.RightLinker.HitTest(point) != null) return this.RightLinker;

            return null;
        }
    }
}
