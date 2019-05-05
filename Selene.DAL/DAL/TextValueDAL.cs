using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.IDAL
{
    public class TextValueDAL : CommonDB<TextValue>, ITextValueDAL
    {

        public IList<TextValue> GetTextValues(string key)
        {
            string cmdText = string.Format("select * from {0} where key=@key order by sort", TableName);
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("key",key)
            };

            return GetEntityList(cmdText, paramList);
        }

        public IList<TextValue> GetTextValues(string key, string type)
        {
            string cmdText = string.Format("select * from {0} where key=@key and type=@type order by sort", TableName);

            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("key",key),
                new SQLiteParameter("type",type)
            };
            return GetEntityList(cmdText, paramList);
        }

        public IList<TextValue> GetTextValues(string key, string type, string subType)
        {
            string cmdText = string.Format("select * from {0} where key=@key and type=@type and subType=@subType order by sort", TableName);

            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("key",key),
                new SQLiteParameter("type",type),
                new SQLiteParameter("subType",subType)
            };
            return GetEntityList(cmdText, paramList);
        }
    }
}
