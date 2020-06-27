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
    /// 单元样式设计器占位符
    /// </summary>
    public class CellStyleHolder : StyleHolder
    {
        public override void Measure(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override bool HitTest(PointF point)
        {
            throw new NotImplementedException();
        }

        public override void Move(PointF offset)
        {
            throw new NotImplementedException();
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
