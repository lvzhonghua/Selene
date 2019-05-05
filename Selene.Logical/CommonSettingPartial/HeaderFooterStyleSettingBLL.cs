using Newtonsoft.Json;
using Selene.Model;
using Selene.Model.Enums;
using Selene.Model.SettingModel.Book;
using Selene.Model.SettingModel.Book.HFStyle;
using Selene.Model.SettingModel.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public partial class CommonSettingBLL
    {
        public HeaderFooterStyleSetting GetHeaderFooterStyleSetting()
        {
            CommonSetting commonSetting = commonSettingDAL.GetCommonSetting(CommonSettingBLL.HeaderFooterStyleSettingKey);
            if (commonSetting == null)
            {
                var defaultHeaderFooterStyleSetting = HeaderFooterStyleSettingFactory.DefaultHeaderFooterStyleSetting();
                SaveHFSSetting(defaultHeaderFooterStyleSetting);

                return defaultHeaderFooterStyleSetting;
            }
            if (HeaderFooterStyle.Tradition.ToString().Equals(commonSetting.Type))
            {
                return JsonConvert.DeserializeObject<HFStyleTradition>(commonSetting.SettingJson);
            }
            else
            {
                return JsonConvert.DeserializeObject<HFStyleModern>(commonSetting.SettingJson);
            }
        }

        public bool SaveHeaderFooterStyleSetting(HeaderFooterStyleSetting headerFooterStyleSetting)
        {
            CommonSetting commonSetting = commonSettingDAL.GetCommonSetting(CommonSettingBLL.HeaderFooterStyleSettingKey);
            if (commonSetting == null)
            {
                commonSetting = new CommonSetting();
                commonSetting.SettingJson = JsonConvert.SerializeObject(headerFooterStyleSetting);
                commonSetting.Key = CommonSettingBLL.HeaderFooterStyleSettingKey;
                commonSetting.Type = headerFooterStyleSetting.HFStyle.ToString();

                return commonSettingDAL.SaveRtnBool(commonSetting);
            }
            else
            {
                commonSetting.SettingJson = JsonConvert.SerializeObject(headerFooterStyleSetting);
                commonSetting.Type = headerFooterStyleSetting.HFStyle.ToString();

                return commonSettingDAL.UpdateRtnBool(commonSetting);
            }
        }

        private bool SaveHFSSetting(HeaderFooterStyleSetting headerFooterStyleSetting)
        {
            CommonSetting commonSetting = new CommonSetting();
            commonSetting.SettingJson = JsonConvert.SerializeObject(headerFooterStyleSetting);
            commonSetting.Key = CommonSettingBLL.HeaderFooterStyleSettingKey;
            commonSetting.Type = headerFooterStyleSetting.HFStyle.ToString();

            return commonSettingDAL.SaveRtnBool(commonSetting);
        }

        public bool SaveDefaultHeaderFooterStyleSetting()
        {
            var defaultHeaderFooterStyleSetting = HeaderFooterStyleSettingFactory.DefaultHeaderFooterStyleSetting();

            return SaveHFSSetting(defaultHeaderFooterStyleSetting);
        }
    }
}
