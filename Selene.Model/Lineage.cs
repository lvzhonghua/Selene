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
    /// 存储族谱基本信息
    /// </summary>
    [TableAttribute("zp_lineage_info")]
    public class Lineage : ModelBase
    {
        /// <summary>
        /// id
        /// </summary>
        [ColumnAttribute(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 始祖世系名称
        /// </summary>
        public string AncestorWroldNumberName { get; set; }

        /// <summary>
        /// 页边标题
        /// </summary>
        public string EdgeTitle { get; set; }

        /// <summary>
        /// 顶栏标题
        /// </summary>
        public string TopTitle { get; set; }

        /// <summary>
        /// 世数前缀
        /// </summary>
        public string WorldNumberPrefix { get; set; }

        /// <summary>
        /// 世数后缀
        /// </summary>
        public string WorldNumberSuffix { get; set; }

        /// <summary>
        /// 世系说明
        /// </summary>
        public string WorldNumberComments { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
