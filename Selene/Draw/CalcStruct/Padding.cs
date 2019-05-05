using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.CalcStruct
{
    public struct Padding
    {
        public float Top { get; set; }

        public float Bottom { get; set; }

        public float Left { get; set; }

        public float Right { get; set; }

        public Padding(float top)
            : this()
        {
            this.Top = top;
        }

        public Padding(float top, float right)
            : this()
        {
            this.Top = top;
            Right = right;
        }

        public Padding(float top, float right, float bottom)
            : this()
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Padding(float top, float right, float bottom, float left)
            : this()
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
            this.Left = left;
        }
    }
}
