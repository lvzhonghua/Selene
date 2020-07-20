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
    /// 判断步骤
    /// </summary>
    class JudgeStep : MindStep
    {
        /// <summary>
        /// 左侧三角形
        /// </summary>
        protected GraphicsPath leftTriangle= new GraphicsPath(FillMode.Winding);

        /// <summary>
        /// 左侧连接点
        /// </summary>
        public Linker LeftLinker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        /// <summary>
        /// Yes条目
        /// </summary>
        public MindStepItem ItemOfYes { get; protected set; } = new MindStepItem() { Direction= MindStepItemDirection.Right, Text = "是" };

        /// <summary>
        /// No条目
        /// </summary>
        public MindStepItem ItemOfNo { get; protected set; } = new MindStepItem() { Direction = MindStepItemDirection.Right, Text = "否" };

        public JudgeStep()
        {
            this.Category = MindStepCategory.Judge;
            this.Text = "判断";

            this.LeftLinker.Parent = this;
            this.ItemOfYes.Parent = this;
            this.ItemOfNo.Parent = this;
        }

        public override void Measure(Graphics graphics)
        {
            SizeF sizeOfText = graphics.MeasureString(this.Text, StyleSchema.CurrentSchema.TextFont);

            float hSpace = StyleSchema.CurrentSchema.HorizontalSpace;
            float vSpace = StyleSchema.CurrentSchema.VerticalSpace;

            SizeF sizeOfYes = graphics.MeasureString(this.ItemOfYes.Text, StyleSchema.CurrentSchema.TextFont);
            SizeF sizeOfNo = graphics.MeasureString(this.ItemOfNo.Text, StyleSchema.CurrentSchema.TextFont);

            this.ItemOfYes.SizeOfTextLimit =
                this.ItemOfNo.SizeOfTextLimit  = new SizeF(Math.Max(sizeOfYes.Width,sizeOfNo.Width),
                                                                                Math.Max(sizeOfYes.Height, sizeOfNo.Height));

            this.ItemOfYes.Measure(graphics);
            this.ItemOfNo.Measure(graphics);

            float boundsHeight = 0;

            float tempHeight = vSpace + sizeOfText.Height + vSpace;
            if (tempHeight > this.ItemOfYes.Bounds.Height + this.ItemOfNo.Bounds.Height)
            {
                boundsHeight = tempHeight;

                this.ItemOfYes.SizeOfTextLimit =
                    this.ItemOfNo.SizeOfTextLimit = new SizeF(Math.Max(sizeOfYes.Width, sizeOfNo.Width),
                                                                                   tempHeight / 2 - vSpace * 2);

                this.ItemOfYes.Measure(graphics);
                this.ItemOfNo.Measure(graphics);
            }
            else
            {
                boundsHeight = this.ItemOfYes.Bounds.Height + this.ItemOfNo.Bounds.Height;
            }

            float boundsWidth = hSpace + sizeOfText.Width + hSpace + 
                                          Math.Max(this.ItemOfYes.Bounds.Width,this.ItemOfNo.Bounds.Width);

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

            this.ItemOfYes.Location = new PointF(this.rectOfText.Right + hSpace,this.Bounds.Top);
            this.ItemOfNo.Location = new PointF(this.rectOfText.Right + hSpace, this.Bounds.Top + this.ItemOfYes.Bounds.Height - 1);
            this.ItemOfYes.Measure(graphics);
            this.ItemOfNo.Measure(graphics);

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
            this.GraphicsPath.AddPath(this.leftTriangle,true);
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.ItemOfYes.Bounds));
            this.GraphicsPath.AddRectangle(Rectangle.Round(this.ItemOfNo.Bounds));
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

            //绘制StepItem
            this.ItemOfYes.Draw(graphics);
            this.ItemOfNo.Draw(graphics);
        }
    }
}
