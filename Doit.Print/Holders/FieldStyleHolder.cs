using Doit.Print.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Doit.Print.Holders
{
    /// <summary>
    /// 属性样式设计器占位符
    /// </summary>
    public class FieldStyleHolder : StyleHolder
    {
        private FieldStyle model;
        public override object Model 
        {
            get { return this.model; }
            set { this.model = value as FieldStyle; }
        }

        public override void Measure(Graphics graphics)
        {
            if(this.model == null) throw new Exception("实体为空，无法测量图形");

            SizeF textSize = graphics.MeasureString(this.model.Text, this.model.Font);

            switch (this.model.SizeMode)
            {
                case SizeMode.AutoSize:
                    this.model.Width = textSize.Width;
                    this.model.Height = textSize.Height;
                    this.model.Bounds = new RectangleF(this.model.Location, textSize);
                    break;
                case SizeMode.Fixed:
                    this.model.Bounds = new RectangleF(this.model.Location, new SizeF(this.model.Width,this.model.Height));
                    break;
                case SizeMode.WidthFixed: //宽度固定，文字换行，计算高度

                    break;
                case SizeMode.HeightFixed:
                    this.model.Bounds = new RectangleF(this.model.Location,new SizeF(textSize.Width,this.model.Height));
                    break;
            }
        }

        public override void Draw(Graphics graphics)
        {
            if (this.model == null) throw new Exception("实体为空，无法绘制图形");

            this.Measure(graphics);

        }

        public override bool HitTest(PointF point)
        {
            return false;
        }

        public override void Move(PointF offset)
        {
        }

        public override void FromXmlNode(XmlNode xmlNode)
        {
            throw new NotImplementedException();
        }

        public override XmlNode ToXmlNode()
        {
            throw new NotImplementedException();
        }
    }
}
