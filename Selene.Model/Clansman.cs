using Selene.DB.DBAttribute;
using Selene.DB.Message;
using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model
{
    [TableAttribute("zp_clansman")]
    public class Clansman:ModelBase
    {
        /// <summary>
        /// id
        /// </summary>
        [ColumnAttribute(IsKey=true,IsIdentity=true)]
        public int Id { get; set; }

        /// <summary>
        /// 谱名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public int Pid { get; set; }

        /// <summary>
        /// 卷
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// 相对世数，始祖的世数为0来进行相对
        /// 实际世数要从Genealogy中加上统一的始祖世数【AncestorWorldNumber】
        /// </summary>
        public int RelativeWorldNumber { get; set; }

        /// <summary>
        /// 父级名称描述
        /// </summary>
        public string ParentNameDesc { get; set; }

        /// <summary>
        /// 谱文
        /// </summary>
        public string GenealogyNote { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 年号
        /// </summary>
        public string ReignTitle { get; set; }

        /// <summary>
        /// 是否加公
        /// </summary>
        public bool AddDuke { get; set; }

        /// <summary>
        /// 行辈/行
        /// </summary>
        public string Seniority { get; set; }

        /// <summary>
        /// 原行
        /// </summary>
        public string TenetSeniority { get; set; }

        /// <summary>
        /// 本行
        /// </summary>
        public string ThisSeniority { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        public string Monicker { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 子级的类型，相对于父级，儿子、女儿、嗣子、<嗣女>
        /// </summary>
        public string OwnType { get; set; }

        /// <summary>
        /// 字
        /// </summary>
        public string StyledHimself { get; set; }

        /// <summary>
        /// 号
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 生子顺序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 子级信息,生子
        /// </summary>
        public string SonChildrenNames { get; set; }

        /// <summary>
        /// 子级信息,生女
        /// </summary>
        public string DaughterChildrenNames { get; set; }

        /// <summary>
        /// 子级信息,嗣子
        /// </summary>
        public string HeirChildrenNames { get; set; }

        /// <summary>
        /// 所有的子级信息
        /// </summary>
        public string ChildrenNames { get; set; }

        public Clansman()
        {
            //性别默认为1
            this.Sex = SexStatus.male;
        }

    }
}
