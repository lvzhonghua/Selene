using Selene.DB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Helper
{
    /// <summary>
    /// Helper简单工厂类，根据具体的客户请求创建具体的Helper实现类
    /// </summary>
    public class HelperFactory
    {
        public static IHelper CreateHelper(DataMode dateMoel)
        {
            IHelper helper = null;
            switch (dateMoel)
            {
                case DataMode.SqlServer:
                  
                    break;
                case DataMode.Access:
                    
                    break;
                case DataMode.Sqlite:
                    helper = new SqliteHelper();
                    break;
                default:
                    helper = new SqliteHelper();
                    break;
            }
            return helper;
        }

        /// <summary>
        /// 创建具体的Helper实现类
        /// </summary>
        /// <param name="dateMoel">使用请求</param>
        /// <returns>Helper</returns>
        public static IHelper CreateHelper(string dateMoel)
        {
            DataMode dm = (DataMode)Enum.Parse(typeof(DataMode), dateMoel);
            return CreateHelper(dm);
        }

        public static IHelper CreateHelper()
        {
            return CreateHelper(DataMode.Sqlite);
        }
    }

}
