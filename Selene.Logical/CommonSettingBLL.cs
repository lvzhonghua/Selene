using Newtonsoft.Json;
using Selene.DAL.DAL;
using Selene.DAL.IDAL;
using Selene.Model;
using Selene.Model.Enums;
using Selene.Model.SettingModel;
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
    public partial class CommonSettingBLL : IDisposable
    {
        protected ICommonSettingDAL commonSettingDAL;

        public CommonSettingBLL()
        {
            commonSettingDAL = new CommonSettingDAL();
        }

        public static string CheatSheetsSettingKey = "cheatSheetsSetting";
        public static string HeaderFooterStyleSettingKey = "headerFooterStyleSetting";
        public static string LineageMapStyleSettingKey = "lineageMapStyleSetting";


        public void Dispose()
        {
        }
    }
}
