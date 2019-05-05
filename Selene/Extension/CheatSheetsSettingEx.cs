using Selene.Model.SettingModel;
using Selene.Model.SettingModel.Book;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel
{
    public static class CheatSheetsSettingEx
    {
        public static Font GetTitleFont(this CheatSheetsSetting cheatSheetsSetting)
        {
            return ConvertToFont(cheatSheetsSetting.TitleFont);
        }

        public static Font GetContentFont(this CheatSheetsSetting cheatSheetsSetting)
        {
            return ConvertToFont(cheatSheetsSetting.ContentFont);
        }

        private static Font ConvertToFont(string font)
        {
            string[] fonts = font.Split(',');
            return new Font(fonts[0], float.Parse(fonts[1]));
        }
    }
}


