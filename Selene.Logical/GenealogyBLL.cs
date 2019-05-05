using Selene.DAL;
using Selene.Logical.Message;
using Selene.Model;
using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public class GenealogyBLL
    {
        public GenealogyBLL()
        {
            genealogyDAL = new GenealogyDAL();
        }

        private IGenealogyDAL genealogyDAL;
        public bool SaveGenealogy(Genealogy genealogy, Clansman clansman, Lineage lineage)
        {
            if (genealogyDAL.SaveRtnBool(genealogy))
            {
                bool result = false;
                using (ClansmanBLL clansmanBLL = new ClansmanBLL())
                {
                    var defaultVolume = new VolumeBLL().GetDefaultVolume();
                    clansman.Volume = defaultVolume.Id;
                    result = clansmanBLL.SaveClansmanRtnBool(clansman);
                }
                using (LineageBLL lineageBLL = new LineageBLL())
                {
                    result = lineageBLL.SaveLineageRtnBool(lineage);
                }
                return result;
            }
            return false;
        }

        public int GetAncestorWorldNumber()
        {
            return genealogyDAL.GetAncestorWorldNumber();
        }

        public Genealogy GetGenealogy()
        {
            return genealogyDAL.GetAllEntityList().First();
        }

        public bool UpdateGenealogy(Genealogy genealogy)
        {
            return genealogyDAL.UpdateRtnBool(genealogy);
        }
    }
}
