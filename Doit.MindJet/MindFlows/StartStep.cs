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
    /// 起始步骤
    /// </summary>
    class StartStep : MindStep
    {
        protected RectangleF rectOfRight = Rectangle.Empty;

        public StartStep()
        {
            this.Category = MindStepCategory.Start;
            this.Text = "开始";

            this.Linker.Parent = this;
        }

        /// <summary>
        /// 连接点
        /// </summary>
        public Linker Linker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfText = graphics.MeasureString(this.Text, StyleSchema.CurrentSchema.TextFont);

            float hSpace = StyleSchema.CurrentSchema.HorizontalSpace;
            float vSpace = StyleSchema.CurrentSchema.VerticalSpace;

            float boundsHeight = vSpace + sizeOfText.Height + vSpace;
            float boundsWidth = boundsHeight / 2 + hSpace + sizeOfText.Width + hSpace + hSpace + this.Linker.Radius * 2 + hSpace;
            
            this.Bounds = new RectangleF(this.Location, new SizeF(boundsWidth, boundsHeight));

            this.rectOfText.X = this.Location.X + (boundsHeight / 2 + hSpace);
            this.rectOfText.Y = this.Location.Y + vSpace;
            this.rectOfText.Width = sizeOfText.Width;
            this.rectOfText.Height = sizeOfText.Height;

            this.rectOfRight.X = this.Bounds.Right - (hSpace + this.Linker.Radius * 2 + hSpace);
            this.rectOfRight.Y = this.Bounds.Y;
            this.rectOfRight.Width = hSpace + this.Linker.Radius * 2 + hSpace;
            this.rectOfRight.Height = this.Bounds.Height;

            this.Linker.Location = new PointF((this.rectOfRight.Left + this.rectOfRight.Right)/2, (this.rectOfRight.Top + this.rectOfRight.Bottom) / 2);

            this.locationOfText.X = this.rectOfText.X + 2;
            this.locationOfText.Y = this.rectOfText.Y + 2;

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddPie(Rectangle.Round(new RectangleF(this.Location,new SizeF(boundsHeight,boundsHeight))), 90, 180);
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.rectOfRight));
            this.GraphicsPath.AddRectangle(Rectangle.Round(new RectangleF(this.Location.X + boundsHeight / 2, this.Location.Y, this.Bounds.Width - boundsHeight / 2, boundsHeight)));

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);

            //绘制边框
            graphics.DrawPath(StyleSchema.GetFramePen(this.Status),this.GraphicsPath);
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
            if (this.rectOfRight.Contains(point)) return this.Linker;

            return null;
        }
    }
}
