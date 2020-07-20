using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Doit.MindJet.Linkers;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 分支步骤
    /// </summary>
    class SplitStep : MindStep
    {
        /// <summary>
        /// 左侧三角形
        /// </summary>
        protected GraphicsPath leftTriangle = new GraphicsPath(FillMode.Winding);

        /// <summary>
        /// 左侧连接点
        /// </summary>
        public Linker LeftLinker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        /// <summary>
        /// 拆分条目
        /// </summary>
        public List<MindStepItem> Items { get; set; } = new List<MindStepItem>();

        public SplitStep()
        {
            this.Category = MindStepCategory.Split;
            this.Text = "拆分";
            //this.Text = "拆分\n\n拆分\n\n拆分\n\n拆分\n\n拆分\n\n拆分\n\n拆分\n\n拆分";
            this.LeftLinker.Parent = this;

            this.Items.Add(new MindStepItem() { Parent = this, Direction = MindStepItemDirection.Right, Text = "分支1" });
            this.Items.Add(new MindStepItem() { Parent = this, Direction = MindStepItemDirection.Right, Text = "分支2" });
            this.Items.Add(new MindStepItem() { Parent = this, Direction = MindStepItemDirection.Right, Text = "分支3" });
            this.Items.Add(new MindStepItem() { Parent = this, Direction = MindStepItemDirection.Right, Text = "分支4" });
            this.Items.Add(new MindStepItem() { Parent = this, Direction = MindStepItemDirection.Right, Text = "分支5" });
        }

        protected void SetfItemsToSameSize(Graphics graphics)
        {
            SizeF maxSizeOfItemText = SizeF.Empty;

            foreach (var item in this.Items)
            {
                SizeF sizeOfItemText = graphics.MeasureString(item.Text, StyleSchema.CurrentSchema.TextFont);
                if (maxSizeOfItemText.Width < sizeOfItemText.Width) maxSizeOfItemText.Width = sizeOfItemText.Width;
                if (maxSizeOfItemText.Height < sizeOfItemText.Height) maxSizeOfItemText.Height = sizeOfItemText.Height;
            }

            foreach (var item in this.Items)
            {
                item.SizeOfTextLimit = maxSizeOfItemText;
            }
        }

        protected float GetTotalHeightOfItems(Graphics graphics)
        {
            float totalHeight = 0;

            foreach (var item in this.Items)
            {
                item.Measure(graphics);

                totalHeight += item.Bounds.Height;
            }

            return totalHeight;
        }

        protected void SetItemsToSameHeight(Graphics graphics, float height)
        {
            foreach (var item in this.Items)
            {
                item.SizeOfTextLimit = new SizeF(item.SizeOfTextLimit.Width,height);
                item.Measure(graphics);
            }
        }

        protected void SetItemsLocation(Graphics graphics, float x)
        {
            float y = this.Bounds.Top;

            foreach (var item in this.Items)
            {
                item.Location = new PointF(x, y);
                y += item.Bounds.Height;
            }
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfText = graphics.MeasureString(this.Text, StyleSchema.CurrentSchema.TextFont);

            float hSpace = StyleSchema.CurrentSchema.HorizontalSpace;
            float vSpace = StyleSchema.CurrentSchema.VerticalSpace;

            this.SetfItemsToSameSize(graphics);

            float boundsHeight = 0;

            float tempHeight = vSpace + sizeOfText.Height + vSpace;
            float totalHeightOfItems = this.GetTotalHeightOfItems(graphics);
            if (tempHeight > totalHeightOfItems)
            {
                boundsHeight = tempHeight;

                float sameHeight = tempHeight / this.Items.Count - vSpace * 2;

                this.SetItemsToSameHeight(graphics,sameHeight);
            }
            else
            {
                boundsHeight = totalHeightOfItems;
            }

            float boundsWidth = hSpace + sizeOfText.Width + hSpace + this.Items[0].Bounds.Width;

            this.Bounds = new RectangleF(this.Location.X + hSpace + this.LeftLinker.Radius * 2 + hSpace,
                                                        this.Location.Y,
                                                        boundsWidth,
                                                        boundsHeight);

            this.LeftLinker.Location = new PointF((this.Location.X + hSpace + this.LeftLinker.Radius),
                                                                   (this.Bounds.Top + this.Bounds.Bottom) / 2);

            this.rectOfText.X = this.Location.X + hSpace + this.LeftLinker.Radius * 2 + hSpace + hSpace;
            this.rectOfText.Y = this.Location.Y + (this.Bounds.Height - sizeOfText.Height) / 2;
            this.rectOfText.Width = sizeOfText.Width;
            this.rectOfText.Height = sizeOfText.Height;

            this.SetItemsLocation(graphics, this.rectOfText.Right + hSpace);

            this.leftTriangle.Reset();
            this.leftTriangle.AddPolygon(new PointF[]  {
                                                        new PointF(this.Location.X, (this.Bounds.Top + this.Bounds.Bottom) /2 ),
                                                        new PointF(this.Bounds.Left, this.Bounds.Top),
                                                        new PointF(this.Bounds.Left, this.Bounds.Bottom)
                                                    });

            this.locationOfText.X = this.rectOfText.X + 2;
            this.locationOfText.Y = this.rectOfText.Y + 2;

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddPath(this.leftTriangle, true);
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.Bounds));

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        protected void DrawItems(Graphics graphics)
        {
            foreach (var item in this.Items)
            {
                item.Draw(graphics);
            }
        }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);

            //绘制边框
            graphics.DrawPath(StyleSchema.GetFramePen(this.Status), this.GraphicsPath);
            //绘制Text
            graphics.DrawString(this.Text,
                                          StyleSchema.CurrentSchema.TextFont,
                                          StyleSchema.GetTextBrush(this.Status),
                                          this.locationOfText);
            //绘制连接点
            this.LeftLinker.Draw(graphics);

            //绘制StepItem
            this.DrawItems(graphics);
        }

        public override Glyph HitTest(PointF point)
        {
            if (this.rectOfText.Contains(point)) return this;
            if (this.leftTriangle.IsVisible(point)) return this.LeftLinker;

            Glyph glyph = null;
            foreach (var item in this.Items)
            {
                glyph = item.HitTest(point);
                if (glyph != null) return glyph;
            }

            return null;
        }
    }
}
