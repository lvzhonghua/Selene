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
        public LineageMapStyleSetting GetLineageMapStyleSetting()
        {
            CommonSetting commonSetting = commonSettingDAL.GetCommonSetting(CommonSettingBLL.LineageMapStyleSettingKey);
            if (commonSetting == null)
            {
                var defaultLineageMapStyleSetting = LineageMapStyleSettingFactory.DefaultLineageMapStyleSetting();
                SaveLMSSetting(defaultLineageMapStyleSetting);

                return defaultLineageMapStyleSetting;
            }
            if (LineageMapStyle.MessengerWire.ToString().Equals(commonSetting.Type))
            {
                return JsonConvert.DeserializeObject<MessengerWireLineageMapStyleSetting>(commonSetting.SettingJson);
            }
            else
            {
                return JsonConvert.DeserializeObject<BoxLineageMapStyleSetting>(commonSetting.SettingJson);
            }
        }

        public bool SaveLineageMapStyleSetting(LineageMapStyleSetting lineageMapStyleSetting)
        {
            CommonSetting commonSetting = commonSettingDAL.GetCommonSetting(CommonSettingBLL.LineageMapStyleSettingKey);
            if (commonSetting == null)
            {
                commonSetting = new CommonSetting();
                commonSetting.SettingJson = JsonConvert.SerializeObject(lineageMapStyleSetting);
                commonSetting.Key = CommonSettingBLL.LineageMapStyleSettingKey;
                commonSetting.Type = lineageMapStyleSetting.LMStyle.ToString();

                return commonSettingDAL.SaveRtnBool(commonSetting);
            }
            else
            {
                commonSetting.SettingJson = JsonConvert.SerializeObject(lineageMapStyleSetting);
                commonSetting.Type = lineageMapStyleSetting.LMStyle.ToString();

                return commonSettingDAL.UpdateRtnBool(commonSetting);
            }
        }

        private bool SaveLMSSetting(LineageMapStyleSetting lineageMapStyleSetting)
        {
            CommonSetting commonSetting = new CommonSetting();
            commonSetting.SettingJson = JsonConvert.SerializeObject(lineageMapStyleSetting);
            commonSetting.Key = CommonSettingBLL.LineageMapStyleSettingKey;
            commonSetting.Type = lineageMapStyleSetting.LMStyle.ToString();

            return commonSettingDAL.SaveRtnBool(commonSetting);
        }

        public bool SaveDefaultLineageMapStyleSetting()
        {
            var defaultLineageMapStyleSetting = LineageMapStyleSettingFactory.DefaultLineageMapStyleSetting();

            return SaveLMSSetting(defaultLineageMapStyleSetting);
        }
    }
}
