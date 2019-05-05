using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL
{
    public class GenealogyDAL:CommonDB<Genealogy>,IGenealogyDAL
    {

        public int GetAncestorWorldNumber()
        {
            string cmdText = string.Format("select ancestorWorldNumber from {0}", TableName);

            return Helper.GetDataScalar<int>(cmdText);
        }
    }
}
