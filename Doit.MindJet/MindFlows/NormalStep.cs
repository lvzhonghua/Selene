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
    /// 普通步骤
    /// </summary>
    class NormalStep : MindStep
    {
        protected RectangleF rectOfLeft = Rectangle.Empty;
        protected RectangleF rectOfRight = Rectangle.Empty;

        /// <summary>
        /// 左侧连接点
        /// </summary>
        public Linker LeftLinker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        /// <summary>
        /// 右侧连接点
        /// </summary>
        public Linker RightLinker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        public NormalStep()
        {
            this.Category = MindStepCategory.Normal;
            this.Text = "步骤";

            this.LeftLinker.Parent = this;
            this.RightLinker.Parent = this;
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfText = graphics.MeasureString(this.Text, StyleSchema.CurrentSchema.TextFont);

            float hSpace = StyleSchema.CurrentSchema.HorizontalSpace;
            float vSpace = StyleSchema.CurrentSchema.VerticalSpace;

            float boundsWidth = hSpace + this.LeftLinker.Radius * 2 + hSpace + hSpace + sizeOfText.Width + hSpace + hSpace + this.RightLinker.Radius * 2 + hSpace;
            float boundsHeight = vSpace + sizeOfText.Height + vSpace;

            this.Bounds = new RectangleF(this.Location, new SizeF(boundsWidth, boundsHeight));

            this.rectOfLeft.X = this.Location.X;
            this.rectOfLeft.Y = this.Location.Y;
            this.rectOfLeft.Width = hSpace + this.LeftLinker.Radius * 2 + hSpace;
            this.rectOfLeft.Height = this.Bounds.Height;

            this.LeftLinker.Location = new PointF((this.rectOfLeft.Left + this.rectOfLeft.Right) / 2, (this.rectOfLeft.Top + this.rectOfLeft.Bottom) / 2);

            this.rectOfText.X = this.Location.X + hSpace + this.LeftLinker.Radius * 2 + hSpace + hSpace;
            this.rectOfText.Y = this.Location.Y + vSpace;
            this.rectOfText.Width = sizeOfText.Width;
            this.rectOfText.Height = sizeOfText.Height;

            this.rectOfRight.X = this.Bounds.Right - (hSpace + this.RightLinker.Radius * 2 + hSpace);
            this.rectOfRight.Y = this.Bounds.Y;
            this.rectOfRight.Width = hSpace + this.RightLinker.Radius * 2 + hSpace;
            this.rectOfRight.Height = this.Bounds.Height;

            this.RightLinker.Location = new PointF((this.rectOfRight.Left + this.rectOfRight.Right) / 2, (this.rectOfRight.Top + this.rectOfRight.Bottom) / 2);

            this.locationOfText.X = this.rectOfText.X + 2;
            this.locationOfText.Y = this.rectOfText.Y + 2;

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.rectOfLeft));
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.rectOfRight));
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.Bounds));

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
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
            this.RightLinker.Draw(graphics);
        }
    }
}
