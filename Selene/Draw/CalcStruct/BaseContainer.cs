using Selene.Draw.Enums;
using Selene.Logical.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.CalcStruct
{
    public abstract class BaseContainer
    {
        /// <summary>
        /// 控件的id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 控件的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// tag
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 控件排列方式-相对于父级
        /// </summary>
        public Align Align { get; set; }

        private PointF location;
        /// <summary>
        /// 控件的位置
        /// </summary>
        public PointF Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
                GlobalLocation = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PointF GlobalLocation { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public float Width
        {
            get
            {
                return this.SizeF.Width;
            }
            set
            {
                this.SizeF.Width = value;
            }
        }

        /// <summary>
        /// 高度
        /// </summary>
        public float Height
        {
            get
            {
                return this.SizeF.Height;
            }
            set
            {
                this.SizeF.Height = value;
            }
        }

        public Color Background { get; set; }

        protected Brush BackgroundBursh
        {
            get
            {
                return new SolidBrush(this.Background);
            }
        }

        /// <summary>
        /// 控件的大小
        /// </summary>
        public SizeF SizeF;

        /// <summary>
        /// margin距离
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// padding距离
        /// </summary>
        public Padding Padding { get; set; }

        /// <summary>
        /// 边框线
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// Graphics对象
        /// </summary>
        public Graphics Graphics { get; set; }

        /// <summary>
        /// 是否画区域线，主要用于测试
        /// </summary>
        public bool DrawAreaLine { get; set; }

        /// <summary>
        /// 父级控件
        /// </summary>
        private BaseContainer parent;
        public BaseContainer Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
                this.parent.AddChildren(this);
            }
        }

        /// <summary>
        /// 子级控件集合
        /// </summary>
        public List<BaseContainer> Childrens { get; set; }

        public BaseContainer()
        {
            this.Childrens = new List<BaseContainer>();
            this.Align = Align.Empty;
        }

        public void AddChildren(BaseContainer container)
        {
            SetParent(container, this);

            this.Childrens.Add(container);
        }

        public void AddChildrens(List<Block> blocks)
        {
            blocks.ForEach(block => SetParent(block, this));
            this.Childrens.AddRange(blocks);
        }

        private void SetParent(BaseContainer children, BaseContainer parent)
        {
            children.parent = parent;

            if (children.Graphics == null)
            {
                children.Graphics = parent.Graphics;
            }
        }

        /// <summary>
        /// 画之前的一些计算
        /// </summary>
        public virtual void DrawBeforeCalc()
        {
            CalcRelativeLocation();
        }

        /// <summary>
        /// 根据相对于父级容器的居中来计算location的值
        /// </summary>
        protected void CalcRelativeLocation()
        {
            if (this.Parent == null)
            {
                return;
            }

            float x = this.Parent.PaddingRectF.X + Location.X;
            float y = this.Parent.PaddingRectF.Y + Location.Y;

            switch (this.Align)
            {
                case Align.LeftTop:
                    x = this.Parent.PaddingRectF.X;
                    y = this.Parent.PaddingRectF.Y;
                    break;
                case Align.CenterTop:
                    x = this.Parent.PaddingRectF.X + (this.Parent.PaddingRectF.Width - this.MarginRectF.Width) / 2;
                    y = this.Parent.PaddingRectF.Y;
                    break;
                case Align.RightTop:
                    x = this.Parent.PaddingRectF.X + (this.Parent.PaddingRectF.Width - this.MarginRectF.Width);
                    y = this.Parent.PaddingRectF.Y;
                    break;
                case Align.LeftMiddle:
                    x = this.Parent.PaddingRectF.X;
                    y = this.Parent.PaddingRectF.Y + (this.Parent.PaddingRectF.Height - this.MarginRectF.Height) / 2;
                    break;
                case Align.CenterMiddle:
                    x = this.Parent.PaddingRectF.X + (this.Parent.PaddingRectF.Width - this.MarginRectF.Width) / 2;
                    y = this.Parent.PaddingRectF.Y + (this.Parent.PaddingRectF.Height - this.MarginRectF.Height) / 2;
                    break;
                case Align.RightMiddle:
                    x = this.Parent.PaddingRectF.X + (this.Parent.PaddingRectF.Width - this.MarginRectF.Width);
                    y = this.Parent.PaddingRectF.Y + (this.Parent.PaddingRectF.Height - this.MarginRectF.Height) / 2;
                    break;
                case Align.LeftBottom:
                    x = this.Parent.PaddingRectF.X;
                    y = this.Parent.PaddingRectF.Y + (this.Parent.PaddingRectF.Height - this.MarginRectF.Height);
                    break;
                case Align.CenterBottom:
                    x = this.Parent.PaddingRectF.X + (this.Parent.PaddingRectF.Width - this.MarginRectF.Width) / 2;
                    y = this.Parent.PaddingRectF.Y + (this.Parent.PaddingRectF.Height - this.MarginRectF.Height);
                    break;
                case Align.RightBottom:
                    x = this.Parent.PaddingRectF.X + (this.Parent.PaddingRectF.Width - this.MarginRectF.Width);
                    y = this.Parent.PaddingRectF.Y + (this.Parent.PaddingRectF.Height - this.MarginRectF.Height);
                    break;
            }
            this.GlobalLocation = new PointF(x, y);
            this.location = new PointF(GlobalLocation.X - this.Parent.PaddingRectF.X, GlobalLocation.Y - this.Parent.PaddingRectF.Y);
        }

        public virtual void Draw()
        {
            //进行画之前的一些计算
            DrawBeforeCalc();

            DrawBackground();

            DrawBorder();

            if (DrawAreaLine)
            {
                

                DrawBorderLine();

                DrawMarginLine();

                DrawPaddingLine();
            }

        }

        protected virtual void DrawBorder()
        {
            float top = Border.Top;
            if (top > 0)
            {
                PointF startPoint = new PointF(BorderRectF.X, BorderRectF.Y);
                SizeF sizeF = new SizeF(BorderRectF.Width, top);

                this.DrawLine(Border.TopColor, top, startPoint, sizeF);
            }

            float left = Border.Left;
            if (left > 0)
            {
                PointF startPoint = new PointF(BorderRectF.X, BorderRectF.Y);
                SizeF sizeF = new SizeF(left, BorderRectF.Height);

                this.DrawLine(Border.LeftColor, left, startPoint, sizeF);
            }
            float right = Border.Right;
            if (right > 0)
            {
                PointF startPoint = new PointF(BorderRectF.X + BorderRectF.Width - right, BorderRectF.Y);
                SizeF sizeF = new SizeF(right, BorderRectF.Height);

                this.DrawLine(Border.RightColor, right, startPoint, sizeF);
            }

            float bottom = Border.Bottom;
            if (bottom > 0)
            {
                PointF startPoint = new PointF(BorderRectF.X, BorderRectF.Y + BorderRectF.Height - bottom);
                SizeF sizeF = new SizeF(BorderRectF.Width, bottom);

                this.DrawLine(Border.BottomColor, bottom, startPoint, sizeF);
            }
        }

        protected Pen GetPen(Color color, float width)
        {
            return new Pen(color, width);
        }

        protected Pen GetPen(Color color)
        {
            return new Pen(color);
        }

        protected void DrawBorderLine()
        {
            this.Graphics.DrawRectangle(GetPen(Color.Yellow), BorderRectF.X, BorderRectF.Y, BorderRectF.Width, BorderRectF.Height);
        }

        protected void DrawPaddingLine()
        {
            this.Graphics.DrawRectangle(GetPen(Color.Red), PaddingRectF.X, PaddingRectF.Y, PaddingRectF.Width, PaddingRectF.Height);
        }

        protected void DrawMarginLine()
        {
            this.Graphics.DrawRectangle(GetPen(Color.Blue), MarginRectF.X, MarginRectF.Y, MarginRectF.Width, MarginRectF.Height);
        }
        /// <summary>
        /// pading 区域的矩形框
        /// </summary>
        public RectangleF PaddingRectF
        {
            get
            {
                float lx = GlobalLocation.X;
                float ly = GlobalLocation.Y;

                float x = lx + Margin.Left + Border.Left + Padding.Left;
                float y = ly + Margin.Top + Border.Top + Padding.Top;

                float w = SizeF.Width;
                float h = SizeF.Height;

                return new RectangleF(new PointF(x, y), new SizeF(w, h));
            }
        }

        /// <summary>
        /// Border的矩形区域
        /// </summary>
        public RectangleF BorderRectF
        {
            get
            {
                float lx = GlobalLocation.X;
                float ly = GlobalLocation.Y;

                float x = lx + Margin.Left;
                float y = ly + Margin.Top;

                float w = SizeF.Width + Border.Left + Border.Right + Padding.Left + Padding.Right;
                float h = SizeF.Height + Border.Top + Border.Bottom + Padding.Top + Padding.Bottom;

                return new RectangleF(new PointF(x, y), new SizeF(w, h));
            }
        }

        /// <summary>
        /// Margin的矩形区域
        /// </summary>
        public RectangleF MarginRectF
        {
            get
            {
                float x = GlobalLocation.X;
                float y = GlobalLocation.Y;

                float w = SizeF.Width + Margin.Left + Margin.Right + Border.Left + Border.Right + Padding.Left + Padding.Right;
                float h = SizeF.Height + Margin.Top + Margin.Bottom + Border.Top + Border.Bottom + Padding.Top + Padding.Bottom;

                return new RectangleF(new PointF(x, y), new SizeF(w, h));
            }
        }

        protected void DrawLine(Color color, float width, PointF startPoint, SizeF sizeF)
        {
            Brush brush = new SolidBrush(color);
            RectangleF rectangleF = new RectangleF();
            rectangleF.Location = startPoint;

            rectangleF.Size = sizeF;

            this.Graphics.FillRectangle(brush, rectangleF);
        }

        protected void DrawBackground()
        {
            this.Graphics.FillRectangle(BackgroundBursh, this.PaddingRectF);
        }

        public ContainsRegion GetContainsRegion()
        {
            float parentWidth = this.Parent.PaddingRectF.Width;
            float parentHeight = this.Parent.PaddingRectF.Height;
            float parentX = this.Parent.PaddingRectF.X;
            float parentY = this.Parent.PaddingRectF.Y;

            float thisX = this.GlobalLocation.X;
            float thisY = this.GlobalLocation.Y;
            float thisWidth = this.Width + thisX;
            float thisHeight = this.Height + thisY;


            int result = 0;

            if (thisX < parentX)
            {
                result += (int)ContainsRegion.Left;
            }
            if (thisY < parentY)
            {
                result += (int)ContainsRegion.Top;
            }
            if (thisWidth > parentWidth)
            {
                result += (int)ContainsRegion.Right;
            }
            if (thisHeight > parentHeight)
            {
                result += (int)ContainsRegion.Bottom;
            }

            return (ContainsRegion)result;
        }

        public bool IsRegionLegal(ContainsRegion containsRegion)
        {
            ContainsRegion currentRegion = GetContainsRegion();

            return ResolveContainsRegion(currentRegion).IndexOf((int)containsRegion) >= 0;
        }

        private List<int> ResolveContainsRegion(ContainsRegion currentRegion)
        {
            int current = (int)currentRegion;
            char[] region2 = Convert.ToString(current, 2).ToCharArray();

            List<int> region2List = new List<int>();

            int index = 0;
            foreach (var item in region2)
            {
                if (item == '1')
                {
                    region2List.Add(Convert.ToInt32(item.ToString().PadRight(region2.Length - index, '0'),2));
                }
                index++;
            }
            return region2List;
        }
    }
}
