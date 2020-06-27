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
    /// 样式设计器占位符
    /// </summary>
    public abstract class StyleHolder : IHolder
    {
        public string GUID { get; private set; }

        public virtual object Model { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public StyleHolderCategory Category { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public StyleHolderStatus Status { get; set; }

        public StyleHolder()
        {
            this.GUID = Guid.NewGuid().ToString();
        }

        public abstract void Measure(Graphics graphics);

        public abstract void Draw(Graphics graphics);

        public abstract bool HitTest(PointF point);

        public abstract void Move(PointF offset);

        public abstract XmlNode ToXmlNode();

        public abstract void FromXmlNode(XmlNode xmlNode);
    }
}
