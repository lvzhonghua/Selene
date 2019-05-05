using Selene.DB.DBAttribute;
using Selene.DB.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model
{
    /// <summary>
    /// 存储文本、值类型的数据
    /// </summary>
    [TableAttribute("zp_volume")]
    public class Volume : ModelBase
    {
        /// <summary>
        /// id
        /// </summary>
        [ColumnAttribute(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 卷名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 开始页码
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 需要目录
        /// </summary>
        public bool NeedCatalogue { get; set; }

        /// <summary>
        /// 需要速查表
        /// </summary>
        public bool NeedCheatSheets { get; set; }
    }
}
