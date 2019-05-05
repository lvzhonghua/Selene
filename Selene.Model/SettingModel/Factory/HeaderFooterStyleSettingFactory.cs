using Selene.Model.Enums;
using Selene.Model.SettingModel.Book;
using Selene.Model.SettingModel.Book.HFStyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel.Factory
{
    public class HeaderFooterStyleSettingFactory
    {
        public static HFStyleTradition DefaultHFStyleTradition()
        {
            HFStyleTradition defaultHFStyleTradition = new HFStyleTradition();
            defaultHFStyleTradition.FooterLineStyle = LineStyle.Thick;
            defaultHFStyleTradition.HeaderLineStyle = LineStyle.Thick;
            defaultHFStyleTradition.HeaderCenterFont = "黑体,12.5";
            defaultHFStyleTradition.OtherFont = "黑体,12.5";
            defaultHFStyleTradition.HFStyle = HeaderFooterStyle.Tradition;
            defaultHFStyleTradition.PageNumberFont = "黑体,10";
            defaultHFStyleTradition.ThickWidth = 3.0d;
            defaultHFStyleTradition.ThinWidth = 1.0d;

            return defaultHFStyleTradition;
        }

        public static HFStyleModern DefaultHFStyleModern()
        {
            HFStyleModern defaultHFStyleModern = new HFStyleModern();
            defaultHFStyleModern.TopBottomTitleFont = "黑体,12.5";
            defaultHFStyleModern.EdgeTitleFont = "黑体,12.5";
            defaultHFStyleModern.HFStyle = HeaderFooterStyle.Modern;
            defaultHFStyleModern.PageNumberFont = "黑体,10";

            return defaultHFStyleModern;
        }

        public static HeaderFooterStyleSetting DefaultHeaderFooterStyleSetting()
        {
            return DefaultHFStyleTradition();
        }
    }
}
