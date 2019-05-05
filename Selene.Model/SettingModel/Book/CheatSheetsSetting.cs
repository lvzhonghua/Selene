using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel.Book
{
    public class CheatSheetsSetting
    {
        /// <summary>
        /// 标题字体
        /// </summary>
        public string TitleFont { get; set; }

        /// <summary>
        /// 正文字体
        /// </summary>
        public string ContentFont { get; set; }

        /// <summary>
        /// 开始世数或字辈
        /// </summary>
        public string StartLineageOrSeniority { get; set; }

        /// <summary>
        /// 不自动添加姓氏
        /// </summary>
        public bool NoAutoAddFamilyName { get; set; }

        /// <summary>
        /// 实名提取顺序
        /// </summary>
        public string RealNameExtractSort { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public string SortType { get; set; }

        /// <summary>
        /// 强制在偶数页结束
        /// </summary>
        public bool ForceEvenEnd { get; set; }

        /// <summary>
        /// 强制使用横板速查表
        /// </summary>
        public bool ForceHorizontalCheatSheets { get; set; }

        /// <summary>
        /// 允许速查表在单独的一卷内打印
        /// </summary>
        public bool AllowCheatSheetsOneselfPrint { get; set; }

        /// <summary>
        /// 打印世系图页码
        /// </summary>
        public bool PrintLineagePageNumber { get; set; }
    }
}
