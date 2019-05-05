using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.DBAttribute
{
     [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnAttribute : Attribute
    {
        private bool isKey;     //是否是主键
        private bool isMapping = true;   //是否映射 默认为true
        private string mapColumn;    //映射的列名
        private bool isIdentity = false;    // 是否自增 默认为false

        /// <summary>
        /// 空重载
        /// </summary>
        public ColumnAttribute() { }

        /// <summary>
        /// 重载isMapping
        /// </summary>
        /// <param name="isMapping">是否映射 默认为true</param>
        public ColumnAttribute(bool isMapping)
        {
            this.isMapping = isMapping;
        }

        /// <summary>
        /// 重载mapColumn
        /// </summary>
        /// <param name="mapColumn">映射的列名</param>
        public ColumnAttribute(string mapColumn)
        {
            this.isMapping = true;
            this.mapColumn = mapColumn;
        }

        /// <summary>
        /// 重载isMapping、mapColumn
        /// </summary>
        /// <param name="isMapping">是否映射 默认为true</param>
        /// <param name="mapColumn">映射的列名</param>
        public ColumnAttribute(bool isMapping, string mapColumn)
        {
            this.isMapping = isMapping;
            this.mapColumn = mapColumn;
        }

        /// <summary>
        /// 取IsMapping
        /// </summary>
        public bool IsMapping
        {
            get
            {
                return isMapping;
            }
        }

        /// <summary>
        /// 取MapColumn
        /// </summary>
        public string MapColumn
        {
            get
            {
                return mapColumn;
            }
        }

        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsKey
        {
            get { return isKey; }
            set { isKey = value; }
        }

        /// <summary>
        /// 是否是自增列
        /// </summary>
        public bool IsIdentity
        {
            get { return isIdentity; }
            set { isIdentity = value; }
        }

    }
}
