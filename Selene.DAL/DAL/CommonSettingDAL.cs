using Selene.DAL.IDAL;
using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.DAL
{
    public class CommonSettingDAL : CommonDB<CommonSetting>, ICommonSettingDAL
    {

        public CommonSetting GetCommonSetting(string key)
        {
            string cmdText = string.Format("select * from {0} where key=@key", TableName);
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("key",key)
            };

            return GetEntity(cmdText, paramList);
        }

        public CommonSetting GetCommonSetting(string key, string type)
        {
            string cmdText = string.Format("select * from {0} where key=@key and type=@type", TableName);
            
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("key",key),
                new SQLiteParameter("type",type)
            };
            return GetEntity(cmdText, paramList);
        }

        public CommonSetting GetCommonSetting(string key, string type, string subType)
        {
            string cmdText = string.Format("select * from {0} where key=@key and type=@type and subType=@subType", TableName);
            
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("key",key),
                new SQLiteParameter("type",type),
                new SQLiteParameter("subType",subType)
            };

            return GetEntity(cmdText, paramList);
        }
    }
}
