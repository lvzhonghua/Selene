using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel.Book.HFStyle
{
    public class HFStyleTradition : HeaderFooterStyleSetting
    {
        /// <summary>
        /// 页眉中部字体
        /// </summary>
        public string HeaderCenterFont { get; set; }

        /// <summary>
        /// 其它部分字体
        /// </summary>
        public string OtherFont { get; set; }

        /// <summary>
        /// 偶数页标题
        /// </summary>
        public string EvenPageTitle { get; set; }

        /// <summary>
        /// 页码字体
        /// </summary>
        public string PageNumberFont { get; set; }

        /// <summary>
        /// 强制谱序和世系图中打印页眉页脚
        /// </summary>
        public bool ForceSeqLineageHF { get; set; }

        /// <summary>
        /// 页眉式样
        /// </summary>
        public LineStyle HeaderLineStyle { get; set; }

        /// <summary>
        /// 页脚式样
        /// </summary>
        public LineStyle FooterLineStyle { get; set; }

        /// <summary>
        /// 粗线宽度
        /// </summary>
        public double ThickWidth { get; set; }

        /// <summary>
        /// 细线宽度
        /// </summary>
        public double ThinWidth { get; set; }

        /// <summary>
        /// 线条间距
        /// </summary>
        public double LineSpace { get; set; }

        /// <summary>
        /// 页眉左
        /// </summary>
        public string HeaderLeft { get; set; }

        /// <summary>
        /// 页眉中
        /// </summary>
        public string HeaderCenter { get; set; }

        /// <summary>
        /// 页眉右
        /// </summary>
        public string HeaderRight { get; set; }

        /// <summary>
        /// 页脚左
        /// </summary>
        public string FooterLeft { get; set; }

        /// <summary>
        /// 页脚中
        /// </summary>
        public string FooterCenter { get; set; }

        /// <summary>
        /// 页脚右
        /// </summary>
        public string FooterRight { get; set; }

        public HFStyleTradition()
        {
            this.HFStyle = HeaderFooterStyle.Tradition;
        }
    }
}
