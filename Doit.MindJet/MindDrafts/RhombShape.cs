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
    /// <summary>
    /// 菱形图案
    /// </summary>
    class RhombShape : MindShape
    {
        protected PointF[] fourPoints = new PointF[4] { PointF.Empty, PointF.Empty, PointF.Empty, PointF.Empty,};

        public RhombShape()
        {
            this.Category = MindShapeCategory.Rhomb;
            this.Text = "菱形";

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

            RectangleF boundsOfText = new RectangleF();
            boundsOfText.X = this.rectOfText.X - this.Padding.Left;
            boundsOfText.Y = this.rectOfText.Y - this.Padding.Top;
            boundsOfText.Width = this.Padding.Left + this.rectOfText.Width + this.Padding.Right;
            boundsOfText.Height = this.Padding.Top + this.rectOfText.Height + this.Padding.Bottom;

            this.fourPoints[0].X = boundsOfText.Left - boundsOfText.Width / 3;
            this.fourPoints[0].Y = (boundsOfText.Top + boundsOfText.Bottom) / 2;

            this.fourPoints[1].X = (boundsOfText.Left + boundsOfText.Right) / 2;
            this.fourPoints[1].Y = boundsOfText.Top - boundsOfText.Height / 3;

            this.fourPoints[2].X = boundsOfText.Right + boundsOfText.Width / 3;
            this.fourPoints[2].Y = (boundsOfText.Top + boundsOfText.Bottom) / 2;

            this.fourPoints[3].X = (boundsOfText.Left + boundsOfText.Right) / 2;
            this.fourPoints[3].Y = boundsOfText.Bottom + boundsOfText.Height / 3;


            this.LeftLinker.Location = this.fourPoints[0];
            this.TopLinker.Location = this.fourPoints[1];
            this.RightLinker.Location = this.fourPoints[2];
            this.BottomLinker.Location = this.fourPoints[3];

            this.LeftLinker.Measure(graphics);
            this.TopLinker.Measure(graphics);
            this.RightLinker.Measure(graphics);
            this.BottomLinker.Measure(graphics);

            this.Bounds = new RectangleF(this.fourPoints[0].X,
                                                       this.fourPoints[1].Y,
                                                       this.fourPoints[2].X - this.fourPoints[0].X,
                                                       this.fourPoints[3].Y - this.fourPoints[1].Y);

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
            graphics.DrawPolygon(StyleSchema.GetFramePen(this.Status), this.fourPoints);
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
