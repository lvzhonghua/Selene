using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical.ViewModel
{
    public class ClansmanTree:Clansman
    {
        public List<ClansmanTree> Childrens { get; set; }
    }
}
