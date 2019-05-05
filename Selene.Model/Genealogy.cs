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
    [TableAttribute("zp_genealogy_info")]
    public class Genealogy : ModelBase
    {

        /// <summary>
        /// id
        /// </summary>
        [ColumnAttribute(IsKey=true,IsIdentity=true)]
        public int Id { get; set; }

        /// <summary>
        /// 宗谱名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 姓氏名称
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// 辈分
        /// </summary>
        public string Seniority { get; set; }

        /// <summary>
        /// 世数，与辈分对应，是由第几世开始
        /// </summary>
        public int SeniorityWorldNumber { get; set; }

        /// <summary>
        /// 体例名称
        /// </summary>
        public string StyleName { get; set; }

        /// <summary>
        /// 每个世系中要管理的世数
        /// </summary>
        public int WorldManageNumber { get; set; }

        /// <summary>
        /// 每个世系图中的管理世数
        /// </summary>
        public int WorldImageManageNumber { get; set; }

        /// <summary>
        /// 始祖的父辈信息
        /// </summary>
        public string AncestorParentInfo { get; set; }

        /// <summary>
        /// 始祖的世数
        /// </summary>
        public int AncestorWorldNumber { get; set; }
    }
}
