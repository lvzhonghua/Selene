using Selene.DB.DBAttribute;
using Selene.DB.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Model
{
    [TableAttribute("sz_common_setting")]
    public class CommonSetting : ModelBase
    {
        /// <summary>
        /// id
        /// </summary>
        [ColumnAttribute(IsKey=true,IsIdentity=true)]
        public int Id { get; set; }

        /// <summary>
        /// 设置key
        /// 可重复，如果重复可以根据type，subType进一步去重
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// key重复时的去重标识
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// key重复时的去重标识
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// 设置的json
        /// </summary>
        public string SettingJson { get; set; }
    }
}
