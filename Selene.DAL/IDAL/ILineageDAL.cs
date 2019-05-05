using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.IDAL
{
    public interface ILineageDAL : ICommonDB<Lineage>
    {
        IList<Lineage> GetLineages();
    }
}
