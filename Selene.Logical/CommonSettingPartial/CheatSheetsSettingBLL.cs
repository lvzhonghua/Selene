using Newtonsoft.Json;
using Selene.Model;
using Selene.Model.SettingModel;
using Selene.Model.SettingModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public partial class CommonSettingBLL
    {
        public CheatSheetsSetting GetCheatSheetsSetting()
        {
            CommonSetting commonSetting = commonSettingDAL.GetCommonSetting(CommonSettingBLL.CheatSheetsSettingKey);
            if (commonSetting == null)
            {
                CheatSheetsSetting cheatSheetsSetting = CommonSettingFactory.DefaultCheatSheetsSetting();
                SaveCheatSheetsSetting(cheatSheetsSetting);

                return cheatSheetsSetting;
            }
            return JsonConvert.DeserializeObject<CheatSheetsSetting>(commonSetting.SettingJson);
        }

        public bool SaveCheatSheetsSetting(CheatSheetsSetting cheatSheetsSetting)
        {
            CommonSetting commonSetting = commonSettingDAL.GetCommonSetting(CommonSettingBLL.CheatSheetsSettingKey);
            if (commonSetting == null)
            {
                commonSetting = new CommonSetting();
                commonSetting.SettingJson = JsonConvert.SerializeObject(cheatSheetsSetting);
                commonSetting.Key = CommonSettingBLL.CheatSheetsSettingKey;

                return commonSettingDAL.SaveRtnBool(commonSetting);
            }
            else
            {
                commonSetting.SettingJson = JsonConvert.SerializeObject(cheatSheetsSetting);
                return commonSettingDAL.UpdateRtnBool(commonSetting);
            }

        }

        public bool SaveDefaultCheatSheetsSetting()
        {
            CheatSheetsSetting cheatSheetsSetting = CommonSettingFactory.DefaultCheatSheetsSetting();
            CommonSetting commonSetting = new CommonSetting();
            commonSetting.SettingJson = JsonConvert.SerializeObject(cheatSheetsSetting);
            commonSetting.Key = CommonSettingBLL.CheatSheetsSettingKey;

            return commonSettingDAL.SaveRtnBool(commonSetting);
        }
    }
}
