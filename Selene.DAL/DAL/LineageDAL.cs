using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.IDAL
{
    public class LineageDAL : CommonDB<Lineage>, ILineageDAL
    {
        public IList<Lineage> GetLineages()
        {
            string cmdText = string.Format("select * from {0} order by sort", TableName);

            return GetEntityList(cmdText);
        }
    }
}
