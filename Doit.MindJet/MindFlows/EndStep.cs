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
    /// 结束步骤
    /// </summary>
    class EndStep : MindStep
    {
        protected RectangleF rectOfLeft = Rectangle.Empty;

        /// <summary>
        /// 连接点
        /// </summary>
        public Linker Linker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        public EndStep()
        {
            this.Category = MindStepCategory.End;
            this.Text = "结束";

            this.Linker.Parent = this;
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfText = graphics.MeasureString(this.Text, StyleSchema.CurrentSchema.TextFont);

            float hSpace = StyleSchema.CurrentSchema.HorizontalSpace;
            float vSpace = StyleSchema.CurrentSchema.VerticalSpace;

            float boundsHeight = vSpace + sizeOfText.Height + vSpace;
            float boundsWidth = hSpace + this.Linker.Radius * 2 + hSpace + hSpace + sizeOfText.Width + hSpace  + boundsHeight / 2;

            this.Bounds = new RectangleF(this.Location, new SizeF(boundsWidth, boundsHeight));

            this.rectOfLeft.X = this.Location.X;
            this.rectOfLeft.Y = this.Location.Y;
            this.rectOfLeft.Width = hSpace + this.Linker.Radius * 2 + hSpace;
            this.rectOfLeft.Height = this.Bounds.Height;

            this.Linker.Location = new PointF((this.rectOfLeft.Left + this.rectOfLeft.Right) / 2, (this.rectOfLeft.Top + this.rectOfLeft.Bottom) / 2);

            this.rectOfText.X = this.Location.X + hSpace + this.Linker.Radius * 2 + hSpace + hSpace;
            this.rectOfText.Y = this.Location.Y + vSpace;
            this.rectOfText.Width = sizeOfText.Width;
            this.rectOfText.Height = sizeOfText.Height;

            this.locationOfText.X = this.rectOfText.X + 2;
            this.locationOfText.Y = this.rectOfText.Y + 2;

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddPie(Rectangle.Round(new RectangleF(new PointF(this.Bounds.Right - boundsHeight,this.Bounds.Y), new SizeF(boundsHeight, boundsHeight))), -90, 180);
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.rectOfLeft));
            this.GraphicsPath.AddRectangle(Rectangle.Round(new RectangleF(this.Location, new SizeF(this.Bounds.Width - boundsHeight / 2, boundsHeight))));

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
            this.Linker.Draw(graphics);
        }

        public override Glyph HitTest(PointF point)
        {  
            if (this.rectOfText.Contains(point)) return this;
            if (this.rectOfLeft.Contains(point)) return this.Linker;
            return null;
        }
    }
}
