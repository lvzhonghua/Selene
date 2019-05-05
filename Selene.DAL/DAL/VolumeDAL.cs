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
    public class VolumeDAL : CommonDB<Volume>, IVolumeDAL
    {
        public Volume GetDefaultVolume()
        {
            string cmdText = string.Format("select * from {0} order by sort", TableName);
            return GetEntity(cmdText);
        }


        public IList<Volume> GetVolumes()
        {
            string cmdText = string.Format("select * from {0} order by sort", TableName);
            return GetEntityList(cmdText);
        }


        public bool ExistVolume(string name, int id)
        {
            string cmdText = string.Format("select count(id) from {0} where name=@name", TableName);
            List<DbParameter> paramList = new List<DbParameter>(){
                new SQLiteParameter("name",name)
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
