using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Doit.MindJet
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
        /// 位置
        /// </summary>
        public PointF Location { get; set; }

        /// <summary>
        /// 边界
        /// </summary>
        public RectangleF Bounds { get; private set; }

        /// <summary>
        /// 左侧节点位置
        /// </summary>
        public PointF LeftLinker { get; set; }

        /// <summary>
        /// 右侧节点位置
        /// </summary>
        public PointF RightLinker { get; set; }

        /// <summary>
        /// 节点半径
        /// </summary>
        public float LinkerRadius { get; set; } = 6;

        /// <summary>
        /// 子节点展开
        /// </summary>
        public bool Expanded { get; set; } = true;

        public void AddNode(MindNode node)
        {
            node.Level = this.Level + 1;
            node.Parent = this;
            this.Nodes.Add(node);
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfName = graphics.MeasureString(this.Text,StyleSchema.CurrentSchema.TextFont);
            this.Bounds = new RectangleF(this.Location, new SizeF(sizeOfName.Width + 2f, sizeOfName.Height + 4f));

            this.LeftLinker = new PointF(this.Bounds.Left, (this.Bounds.Top + this.Bounds.Bottom) / 2);
            this.RightLinker = new PointF(this.Bounds.Right, (this.Bounds.Top + this.Bounds.Bottom) / 2);
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
            RectangleF leftRect = new RectangleF();
            leftRect.X = this.LeftLinker.X - this.LinkerRadius;
            leftRect.Y = this.LeftLinker.Y - this.LinkerRadius;
            leftRect.Width = leftRect.Height = this.LinkerRadius * 2;
            graphics.FillPie(StyleSchema.GetFrameBrush(this.Status), Rectangle.Round(leftRect), 90, 180);
            //绘制右边节点标志
            if (this.Nodes.Count > 0)
            {
                RectangleF rightRect = new RectangleF();
                rightRect.X = this.RightLinker.X - this.LinkerRadius;
                rightRect.Y = this.RightLinker.Y - this.LinkerRadius;
                rightRect.Width = rightRect.Height = this.LinkerRadius * 2;

                graphics.FillPie(StyleSchema.GetFrameBrush(this.Status), Rectangle.Round(rightRect), -90, 180);
            }
        }

        public override bool HitTest(PointF point)
        {
            return this.Bounds.Contains(point);
        }
    }
}
