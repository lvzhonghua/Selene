using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Doit.MindJet.MindDrafts
{
    public class TempShape : MindShape
    {
        public TempShape()
        {
            this.Category = MindShapeCategory.Rect;
            this.Text = "临时图形";

            this.LeftLinker.Parent = this;
            this.TopLinker.Parent = this;
            this.RightLinker.Parent = this;
            this.BottomLinker.Parent = this;
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfText = graphics.MeasureString(this.Text, StyleSchema.CurrentSchema.TextFont);

            this.rectOfText.X = this.Location.X;
            this.rectOfText.Y = this.Location.Y;
            this.rectOfText.Width = sizeOfText.Width;
            this.rectOfText.Height = sizeOfText.Height;

            this.locationOfText.X = this.rectOfText.X + 2f;
            this.locationOfText.Y = this.rectOfText.Y + 4f;

            RectangleF bounds = new RectangleF();
            bounds.X = this.rectOfText.X - this.Padding.Left;
            bounds.Y = this.rectOfText.Y - this.Padding.Top;
            bounds.Width = this.Padding.Left + this.rectOfText.Width + this.Padding.Right;
            bounds.Height = this.Padding.Top + this.rectOfText.Height + this.Padding.Bottom;
            this.Bounds = bounds;

            this.LeftLinker.Location = new PointF(bounds.Left, (bounds.Top + bounds.Bottom) / 2);
            this.TopLinker.Location = new PointF((bounds.Left + bounds.Right) / 2, bounds.Top);
            this.RightLinker.Location = new PointF(bounds.Right, (bounds.Top + bounds.Bottom) / 2);
            this.BottomLinker.Location = new PointF((bounds.Left + bounds.Right) / 2, bounds.Bottom);

            this.LeftLinker.Measure(graphics);
            this.TopLinker.Measure(graphics);
            this.RightLinker.Measure(graphics);
            this.BottomLinker.Measure(graphics);

            this.GraphicsPath.Reset();
            this.GraphicsPath.FillMode = FillMode.Winding;
            this.GraphicsPath.AddRectangle(this.Bounds);

            this.Region.MakeEmpty();
            this.Region.Union(this.GraphicsPath);
        }

        public override void Draw(Graphics graphics)
        {
            this.Measure(graphics);

            //绘制边框
            graphics.DrawRectangle(StyleSchema.GetFramePen(this.Status), Rectangle.Round(this.Bounds));
            //绘制Text
            graphics.DrawString(this.Text,
                                          StyleSchema.CurrentSchema.TextFont,
                                          StyleSchema.GetTextBrush(this.Status),
                                          this.locationOfText);
            //绘制连接点
            if (this.Status == GlyphStatus.Normal || this.Status == GlyphStatus.Unknown) return;

            this.LeftLinker.Draw(graphics);
            this.TopLinker.Draw(graphics);
            this.RightLinker.Draw(graphics);
            this.BottomLinker.Draw(graphics);
        }
    }
}
