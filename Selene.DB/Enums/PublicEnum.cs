using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Enums
{
    /// <summary>
    /// 数据库连接类型枚举
    /// </summary>
    public enum DataMode
    {
        SqlServer = 0,
        Access = 1,
        Sqlite=2
    }

    /// <summary>
    /// DB错误信息枚举
    /// </summary>
    public enum DBEx
    {
        DBConnectionEx = 0,
        DBConvertEx = 1,
        DBCommandEx = 2,
        DBEx = 3,
        DBExVirtualGetEntity = 4,
        DBExVirtualSaveOrUpdate = 5
    }

    /// <summary>
    /// 枚举转字符串工厂
    /// </summary>
    public class DBExFactory
    {
        /// <summary>
        /// 枚举转换字符串
        /// </summary>
        /// <param name="dbex">枚举值</param>
        /// <returns>对应的字符串</returns>
        public static string CreateDBExFactory(DBEx dbex)
        {
            string result = "";
            switch (dbex)
            {
                case DBEx.DBConnectionEx:
                    result = "DB连接字符串错误";
                    break;
                case DBEx.DBConvertEx:
                    result = "DB对象转换错误";
                    break;
                case DBEx.DBCommandEx:
                    result = "DBCommon命令执行错误";
                    break;
                case DBEx.DBEx:
                    result = "DB内部错误";
                    break;
                case DBEx.DBExVirtualGetEntity:
                    result = "DB子类根据ID查询没有重写GetEntityByTId方法";
                    break;
                case DBEx.DBExVirtualSaveOrUpdate:
                    result = "DB子类根据ID查询没有重写SaveOrUpdate方法";
                    break;
                default:
                    result = "DB内部错误";
                    break;
            }
            return result;
        }
    }
}
