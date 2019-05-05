using Selene.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Manage
{
    public class DrawModelData
    {
        public Graphics Graphics { get; set; }

        public PageSettings PageSettings { get; set; }

        public int CurrentPageIndex { get; set; }

        public Genealogy Genealogy { get; set; }

        public List<Clansman> ClansmanList { get; set; }
    }
}
