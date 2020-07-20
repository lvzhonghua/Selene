using Doit.MindJet.Linkers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindFlows
{
    class MindStepItem : Glyph
    {
        /// <summary>
        /// 文字矩形
        /// </summary>
        protected RectangleF rectOfText = Rectangle.Empty;

        /// <summary>
        /// 节点矩形
        /// </summary>
        protected RectangleF rectOfLinker = Rectangle.Empty;

        /// <summary>
        /// 节点方向
        /// </summary>
        public MindStepItemDirection Direction { get; set; } = MindStepItemDirection.Right;

        /// <summary>
        /// 文字区域限定的大小
        /// </summary>
        public SizeF SizeOfTextLimit { get; set; } = SizeF.Empty;

        /// <summary>
        /// 节点
        /// </summary>
        public Linker Linker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        /// <summary>
        /// 思维步骤
        /// </summary>
        public MindStep Parent { get; set; }

        public MindStepItem()
        {
            this.Text = "Item";
            this.Linker.Parent = this;
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfText = graphics.MeasureString(this.Text, StyleSchema.CurrentSchema.TextFont);

            float hSpace = StyleSchema.CurrentSchema.HorizontalSpace;
            float vSpace = StyleSchema.CurrentSchema.VerticalSpace;

            this.rectOfText.Y = this.Location.Y + vSpace;
            this.rectOfText.Width = sizeOfText.Width;
            this.rectOfText.Height = sizeOfText.Height;

            if (this.rectOfText.Width < this.SizeOfTextLimit.Width) this.rectOfText.Width = this.SizeOfTextLimit.Width;
            if (this.rectOfText.Height < this.SizeOfTextLimit.Height) this.rectOfText.Height = this.SizeOfTextLimit.Height;

            float boundsWidth = hSpace + this.rectOfText.Width + hSpace + hSpace + this.Linker.Radius * 2 + hSpace;
            float boundsHeight = vSpace + this.rectOfText.Height + vSpace;

            this.Bounds = new RectangleF(this.Location, new SizeF(boundsWidth, boundsHeight));

            this.rectOfLinker.Width = hSpace + this.Linker.Radius * 2 + hSpace;
            this.rectOfLinker.Height = this.Bounds.Height;

            switch (this.Direction)
            {
                case MindStepItemDirection.Left:
                    this.rectOfLinker.X = this.Location.X;
                    this.rectOfLinker.Y = this.Location.Y;

                    this.rectOfText.X = this.rectOfLinker.Right + hSpace;
                    break;
                case MindStepItemDirection.Right:
                    this.rectOfLinker.X = this.Bounds.Right - (hSpace + this.Linker.Radius * 2 + hSpace);
                    this.rectOfLinker.Y = this.Location.Y;

                    this.rectOfText.X = this.Location.X + hSpace;
                    break;
            }

            this.Linker.Location = new PointF((this.rectOfLinker.Left + this.rectOfLinker.Right) / 2, (this.rectOfLinker.Top + this.rectOfLinker.Bottom) / 2);

            this.locationOfText.X = this.rectOfText.X + 2;
            this.locationOfText.Y = this.rectOfText.Y + (this.rectOfText.Height - sizeOfText.Height) /2 + 2;

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.rectOfLinker));
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
            this.Linker.Draw(graphics);
        }

        public override Glyph HitTest(PointF point)
        {
            if (this.rectOfText.Contains(point)) return this;

            if (this.rectOfLinker.Contains(point)) return this.Linker;

            return null;
        }
    }
}
