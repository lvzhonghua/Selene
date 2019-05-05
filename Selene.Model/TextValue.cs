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
    [TableAttribute("sz_text_value")]
    public class TextValue : ModelBase
    {
        /// <summary>
        /// id
        /// </summary>
        [ColumnAttribute(IsKey = true, IsIdentity = true)]
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
        /// 显示文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 实际值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public int Sort { get; set; }

        public TextValue() { }

        public TextValue(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public TextValue(string key,string text, string value)
        {
            this.Key = key;
            this.Text = text;
            this.Value = value;
        }

        public TextValue(string key, string text, string value,int sort)
        {
            this.Key = key;
            this.Text = text;
            this.Value = value;
            this.Sort = sort;
        }
    }
}
