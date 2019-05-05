using Selene.Draw.Enums;
using Selene.Logical.Utils;
using Selene.UIUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.CalcStruct
{
    public class Block : BaseContainer
    {
        private string text;
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                if (!string.IsNullOrEmpty(this.text) && Direction.Vertical == TextDirection)
                {
                    text = string.Join("\n", text.ToCharArray());
                }
            }
        }

        public Align TextAlign { get; set; }

        private Direction textDirection;
        public Direction TextDirection
        {
            get
            {
                return textDirection;
            }
            set
            {
                textDirection = value;
                if (!string.IsNullOrEmpty(text) && Direction.Vertical == textDirection)
                {
                    text = string.Join("\n", text.ToCharArray());
                }
            }
        }

        public Color ForeColor { get; set; }

        public bool RightToLeft { get; set; }

        public bool AutoSize { get; set; }

        public Font Font { get; set; }

        protected PointF TextLocation { get; set; }

        protected Brush ForeColorBrush
        {
            get
            {
                return new SolidBrush(this.ForeColor);
            }
        }

        public Block()
        {
            this.Font = new Font("黑体", 12f);
            this.ForeColor = Color.Black;
            this.Background = Color.Transparent;
            this.TextAlign = Align.CenterMiddle;
        }

        public override void Draw()
        {
            base.Draw();

            DrawText();

        }

        public override void DrawBeforeCalc()
        {
            if (SizeF == SizeF.Empty)
            {
                this.AutoSize = true;
            }

            this.CalcSize();

            base.DrawBeforeCalc();
        }

        /// <summary>
        /// 计算size大小
        /// </summary>
        public void CalcSize()
        {
            RectangleF textRectF = GetTextRectF();
            if (this.AutoSize)
            {
                this.SizeF = new SizeF(textRectF.Right, textRectF.Height);
            }
            else
            {
                if (this.Width == 0f)
                {
                    this.Width = textRectF.Right;
                }
                if (this.Height == 0f)
                {
                    //如果是纵向，则顶部和底部各加一点空白
                    if (TextDirection == Direction.Vertical)
                    {
                        this.Height = textRectF.Height + textRectF.Width / 2;
                    }
                    else
                    {
                        this.Height = textRectF.Height;
                    }

                }
            }

        }

        protected void DrawText()
        {
            //如果文本是空的，则不存在包裹文字的画block
            if (string.IsNullOrEmpty(this.Text))
            {
                return;
            }
            if (this.AutoSize)
            {
                this.TextAlign = Align.LeftTop;
            }

            float x = this.PaddingRectF.Location.X;
            float y = this.PaddingRectF.Location.Y;

            RectangleF textRectF = GetTextRectF();

            //如果是竖向的字，就不能取textRectF的right
            float textWidth = textRectF.Right;
            if (TextDirection == Direction.Vertical)
            {
                textWidth = textRectF.Right + textRectF.Left;
            }

            switch (TextAlign)
            {
                case Align.LeftTop:
                    x = this.PaddingRectF.Location.X;
                    y = this.PaddingRectF.Location.Y;
                    break;
                case Align.CenterTop:
                    x = this.PaddingRectF.Location.X + (SizeF.Width - textWidth) / 2;
                    y = this.PaddingRectF.Location.Y;
                    break;
                case Align.RightTop:
                    x = this.PaddingRectF.Location.X + (SizeF.Width - textWidth);
                    y = this.PaddingRectF.Location.Y;
                    break;
                case Align.LeftMiddle:
                    x = this.PaddingRectF.Location.X;
                    y = this.PaddingRectF.Location.Y + (SizeF.Height - textRectF.Height) / 2;
                    break;
                case Align.CenterMiddle:
                    x = this.PaddingRectF.Location.X + (SizeF.Width - textWidth) / 2;
                    y = this.PaddingRectF.Location.Y + (SizeF.Height - textRectF.Height) / 2;
                    break;
                case Align.RightMiddle:
                    x = this.PaddingRectF.Location.X + (SizeF.Width - textWidth);
                    y = this.PaddingRectF.Location.Y + (SizeF.Height - textRectF.Height) / 2;
                    break;
                case Align.LeftBottom:
                    x = this.PaddingRectF.Location.X;
                    y = this.PaddingRectF.Location.Y + (SizeF.Height - textRectF.Height);
                    break;
                case Align.CenterBottom:
                    x = this.PaddingRectF.Location.X + (SizeF.Width - textWidth) / 2;
                    y = this.PaddingRectF.Location.Y + (SizeF.Height - textRectF.Height);
                    break;
                case Align.RightBottom:
                    x = this.PaddingRectF.Location.X + (SizeF.Width - textWidth);
                    y = this.PaddingRectF.Location.Y + (SizeF.Height - textRectF.Height);
                    break;
            }

            this.TextLocation = new PointF(x, y);

            this.Graphics.DrawString(this.Text, this.Font, this.ForeColorBrush, this.TextLocation);
        }

        protected RectangleF GetTextRectF()
        {
            return TextUtil.MeasureDisplayStringWidth(this.Graphics, this.Text, this.Font);
        }


    }
}
