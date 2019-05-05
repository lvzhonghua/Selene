using Selene.Model.Enums;
using Selene.Model.Enums.Lineage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model.SettingModel.Book
{
    public class MessengerWireLineageMapStyleSetting:LineageMapStyleSetting
    {
        
        /// <summary>
        /// 顶栏文字
        /// </summary>
        public string TopTitle { get; set; }

        /**暂且省略是否的逻辑配置项**/

        
        

        /// <summary>
        /// 房系字体
        /// </summary>
        public string BranchFont { get; set; }

        /// <summary>
        /// 正文字体
        /// </summary>
        public string ContentFont { get; set; }

        /// <summary>
        /// 上转下接字体
        /// </summary>
        public string UpTurnDownJoinFont { get; set; }

        /// <summary>
        /// 行间距
        /// </summary>
        public double RowSpace { get; set; }

        /// <summary>
        /// 字间距
        /// </summary>
        public double CharacterSpace { get; set; }

        /// <summary>
        /// 世系说明行间距
        /// </summary>
        public double LineageNoteRowSpace { get; set; }

        /// <summary>
        /// 世系说明字间距
        /// </summary>
        public double LineageNoteCharacterSpace { get; set; }

        /// <summary>
        /// 谱名到边框间距
        /// </summary>
        public double ClansmanNameToBorderSpace { get; set; }

        /// <summary>
        /// 正文到边框间距
        /// </summary>
        public double ContentToBorderSpace { get; set; }

        /// <summary>
        /// 谱名到前谱文间距
        /// </summary>
        public double ClansmanNameToPrevGenealogyNoteSpace { get; set; }

        /// <summary>
        /// 正文到谱名间距
        /// </summary>
        public double ContentToClansmanName { get; set; }

        public MessengerWireLineageMapStyleSetting()
        {
            this.LMStyle = LineageMapStyle.MessengerWire;
        }
    }
}
