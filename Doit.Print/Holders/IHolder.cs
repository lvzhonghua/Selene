using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;

namespace Doit.Print.Holders
{

    /// <summary>
    /// 占位符接口
    /// </summary>
    public interface IHolder
    {
        /// <summary>
        /// 标识符
        /// </summary>
        string GUID { get; }

        /// <summary>
        /// 实体模型
        /// </summary>
        object Model { get; set; }

        /// <summary>
        /// 击中测试
        /// </summary>
        /// <param name="point">点</param>
        /// <returns>是否击中</returns>
        bool HitTest(PointF point);

        /// <summary>
        /// 测量尺寸
        /// </summary>
        /// <param name="graphics">绘图板</param>
        void Measure(Graphics graphics);

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="graphics">绘图板</param>
        void Draw(Graphics graphics);

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="offset">偏移量</param>
        void Move(PointF offset);

        /// <summary>
        /// 转化为XmlNode
        /// </summary>
        /// <returns>XmlNode</returns>
        XmlNode ToXmlNode();

        /// <summary>
        /// 将XmlNode转化为Holder对象
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        void FromXmlNode(XmlNode xmlNode);
    }
}
