using Doit.MindJet.Linkers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindDrafts
{
    class RectShape : MindShape
    {
        public RectShape()
        {
            this.Category = MindShapeCategory.Rect;
            this.Text = "矩形";

            this.Linkers.AddRange(new MindShapeLinker[] {
                new MindShapeLinker{ Name = "左侧连接点", Flag = "Left" , Parent = this },
                new MindShapeLinker{ Name = "顶部连接点", Flag = "Top", Parent = this },
                new MindShapeLinker{ Name = "右侧连接点", Flag = "Right", Parent = this },
                new MindShapeLinker{ Name = "底部连接点", Flag = "Bottom", Parent = this }
            });
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

            this.Linkers[0].Location = new PointF(bounds.Left, (bounds.Top + bounds.Bottom)/2);
            this.Linkers[1].Location = new PointF((bounds.Left + bounds.Right) / 2, bounds.Top);
            this.Linkers[2].Location = new PointF(bounds.Right, (bounds.Top + bounds.Bottom) / 2);
            this.Linkers[3].Location = new PointF((bounds.Left + bounds.Right) / 2, bounds.Bottom);

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
            foreach (var linker in this.Linkers)
            {
                linker.Draw(graphics);
            }
        }

        public override Glyph HitTest(PointF point)
        {
            if (this.rectOfText.Contains(point)) return this;

            Glyph beHit = null;
            foreach (var linker in this.Linkers)
            {
                beHit = linker.HitTest(point);

                if (beHit != null) break;
            }

            return beHit;
        }
    }
}
