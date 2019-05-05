using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.DBAttribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 表名
        /// </summary>
        private string tableName;

        public TableAttribute() { }
        public TableAttribute(string tableName)
        {
            this.tableName = tableName;
        }

        public string TableName
        {
            get
            {
                return tableName;
            }
        }
    }
}
