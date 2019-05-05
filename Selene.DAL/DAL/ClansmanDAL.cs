using Selene.DAL.IDAL;
using Selene.DB.Base;
using Selene.DB.Utils;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.DAL
{
    public class ClansmanDAL:CommonDB<Clansman>,IClansmanDAL
    {

        public Clansman GetClansmanParent(string ownName, string parentName)
        {
            string filter = string.Format("and name=@parentName and childrenNames like @ownName");
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("parentName",parentName),
                new SQLiteParameter("ownName","%"+ownName+"%")
            };

            return GetEntityByFilter(filter, paramList);
        }


        public int GetClansmanPid(string ownName, string parentName)
        {
            string cmdText = string.Format("select id from {0} where name=@parentName and childrenNames like @ownName",TableName);
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("parentName",parentName),
                new SQLiteParameter("ownName","%"+ownName+"%")
            };

            return Helper.GetDataScalar<int>(cmdText, paramList);
        }


        public int GetCurrentChildrenCount(int pid)
        {
            string cmdText = string.Format("select count(id) from {0} where pid=@pid");
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("pid",pid)
            };
            return Helper.GetDataScalar<int>(cmdText, paramList);
        }


        public int GetCurrentChildrenCount(int pid, string ownType)
        {
            string cmdText = string.Format("select count(id) from {0} where pid=@pid and ownType=@ownType",TableName);
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("pid",pid),
                new SQLiteParameter("ownType",ownType)
            };
            return Helper.GetDataScalar<int>(cmdText, paramList);
        }


        public bool CheckPersonExist(string ownName, int pid)
        {
            string cmdText = string.Format("select count(id) from {0} where pid=@pid and name=@ownName", TableName);
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("pid",pid),
                new SQLiteParameter("ownName",ownName)
            };
            return Helper.GetDataScalar<int>(cmdText, paramList)>0;
        }


        public bool CheckPersonSortExist(int pid, int sort,int id)
        {
            string cmdText = string.Format("select count(id) from {0} where pid=@pid and sort=@sort", TableName);
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("pid",pid),
                new SQLiteParameter("sort",sort)
            };

            if (id > 0)
            {
                cmdText = string.Format("{0} and id!=@id", cmdText);
                paramList.Add(new SQLiteParameter("id", id));
            }

            return Helper.GetDataScalar<int>(cmdText, paramList) > 0;
        }
    }
}
