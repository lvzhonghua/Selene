using Selene.Model.SettingModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel
{
    public class CommonSettingFactory
    {
        public static CheatSheetsSetting DefaultCheatSheetsSetting()
        {
            CheatSheetsSetting cheatSheetsSetting = new CheatSheetsSetting();

            cheatSheetsSetting.TitleFont = "黑体,16.5";
            cheatSheetsSetting.ContentFont = "黑体,11.5";

            return cheatSheetsSetting;
        }
    }
}
