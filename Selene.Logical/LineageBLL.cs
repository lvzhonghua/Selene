using Selene.DAL.IDAL;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public class LineageBLL : IDisposable
    {
        private ILineageDAL lineageDAL;
        public LineageBLL()
        {
            lineageDAL = new LineageDAL();
        }

        public bool SaveLineageRtnBool(Lineage lineage)
        {
            return lineageDAL.SaveRtnBool(lineage);
        }

        public IList<Lineage> GetLineages()
        {
            return lineageDAL.GetLineages();
        }

        public bool UpdateLineageRtnBool(Lineage lineage)
        {
            return lineageDAL.UpdateRtnBool(lineage);
        }

        public void Dispose()
        {
        }
    }
}
