using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel.Book.HFStyle
{
    public class HFStyleModern : HeaderFooterStyleSetting
    {
        /// <summary>
        /// 上下标题字体
        /// </summary>
        public string TopBottomTitleFont { get; set; }

        /// <summary>
        /// 页边标题字体
        /// </summary>
        public string EdgeTitleFont { get; set; }

        /// <summary>
        /// 偶数页标题
        /// </summary>
        public string EvenPageTitle { get; set; }

        /// <summary>
        /// 页码字体
        /// </summary>
        public string PageNumberFont { get; set; }

        /// <summary>
        /// 页边上
        /// </summary>
        public string EdgeTop { get; set; }

        /// <summary>
        /// 页边中
        /// </summary>
        public string EdgeCenter { get; set; }

        /// <summary>
        /// 页边下
        /// </summary>
        public string EdgeBottom { get; set; }

        public HFStyleModern()
        {
            this.HFStyle = HeaderFooterStyle.Modern;
        }

    }
}
