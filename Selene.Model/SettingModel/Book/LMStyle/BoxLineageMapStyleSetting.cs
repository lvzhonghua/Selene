using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel.Book
{
    public class BoxLineageMapStyleSetting : LineageMapStyleSetting
    {
        /// <summary>
        /// 嗣子标识
        /// </summary>
        public string HeirTag { get; set; }

        /// <summary>
        /// 祧子标识
        /// </summary>
        public string TiaoSonTag { get; set; }

        /// <summary>
        /// 女孩标识
        /// </summary>
        public string GirlTag { get; set; }

        /**暂且省略是否的逻辑配置项**/

        /// <summary>
        /// 世系图打印位置
        /// </summary>
        public string LineageMapPrintPlace { get; set; }

        /// <summary>
        /// 页码字体
        /// </summary>
        public string PageFont { get; set; }

        public BoxLineageMapStyleSetting()
        {
            this.LMStyle = LineageMapStyle.Box;
        }
    }
}
