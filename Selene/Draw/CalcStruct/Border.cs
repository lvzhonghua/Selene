using Selene.Logical.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.CalcStruct
{
    public struct Border
    {
        public float Top { get; set; }

        public float Left { get; set; }

        public float Right { get; set; }

        public float Bottom { get; set; }

        private Color color;
        public Color Color
        {
            get
            {
                if (this.color == Color.Empty)
                {
                    this.color = Color.Black;
                }
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        private Color topColor;
        public Color TopColor
        {
            get
            {
                if (this.topColor == Color.Empty)
                {
                    this.topColor = this.Color;
                }
                return this.topColor;
            }
            set
            {
                this.topColor = value;
            }
        }

        private Color leftColor;
        public Color LeftColor
        {
            get
            {
                if (this.leftColor == Color.Empty)
                {
                    this.leftColor = this.Color;
                }
                return this.leftColor;
            }
            set
            {
                this.leftColor = value;
            }
        }

        private Color rightColor;
        public Color RightColor
        {
            get
            {
                if (this.rightColor == Color.Empty)
                {
                    this.rightColor = this.Color;
                }
                return this.rightColor;
            }
            set
            {
                this.rightColor = value;
            }
        }

        private Color bottomColor;
        public Color BottomColor
        {
            get
            {
                if (this.bottomColor == Color.Empty)
                {
                    this.bottomColor = this.Color;
                }
                return this.bottomColor;
            }
            set
            {
                this.bottomColor = value;
            }
        }

        public Border(float top)
            : this()
        {
            this.Top = top;
        }

        public Border(float top, float right)
            : this()
        {
            this.Top = top;
            Right = right;
        }

        public Border(float top, float right, float bottom)
            : this()
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Border(float top, float right, float bottom, float left)
            : this()
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
            this.Left = left;
        }

        public static readonly Border Empty;
    }
}
