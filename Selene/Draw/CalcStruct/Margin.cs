using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.CalcStruct
{
    public struct Margin
    {
        public float Top { get; set; }

        public float Bottom { get; set; }

        public float Left { get; set; }

        public float Right { get; set; }

        public Margin(float top)
            : this()
        {
            this.Top = top;
        }

        public Margin(float top, float right)
            : this()
        {
            this.Top = top;
            Right = right;
        }

        public Margin(float top, float right, float bottom)
            : this()
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Margin(float top, float right, float bottom, float left)
            : this()
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
            this.Left = left;
        }
    }
}
