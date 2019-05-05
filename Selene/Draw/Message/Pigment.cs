using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.Message
{
    public class Pigment
    {
        private float penWidth;

        public float PenWidth
        {
            get
            {
                if (this.penWidth == default(float))
                {
                    this.penWidth = 1.0f;
                }
                return this.penWidth;
            }
            set
            {
                this.penWidth = value;
            }
        }

        private Pen pen;
        public Pen Pen
        {
            get
            {
                if (pen == null)
                {
                    pen = new Pen(Color);
                }
                return pen;
            }
            set
            {
                this.pen = value;
            }
        }

        private Font font;
        public Font Font
        {
            get
            {
                if (this.font == null)
                {
                    this.font = new Font("微软雅黑", 12f);
                }
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }

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

        private Brush brush;
        public Brush Brush
        {
            get
            {
                if (this.brush == null)
                {
                    this.brush = new SolidBrush(this.Color);
                }
                return this.brush;
            }
            set
            {
                this.brush = value;
            }
        }

        public void SetFontSize(float size)
        {
            this.Font = new Font(this.Font.FontFamily, size);
        }
    }
}
