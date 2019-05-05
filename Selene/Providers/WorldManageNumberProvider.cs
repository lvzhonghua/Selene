using Selene.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Providers
{
    public class WorldManageNumberProvider:IDataListItemProvider
    {
        public List<ListItem> GetDataList()
        {
            return new List<ListItem>()
            {
                new ListItem("1世","1"),
                new ListItem("2世","2"),
                new ListItem("3世","3"),
                new ListItem("4世","4"),
                new ListItem("5世","5",true),
                new ListItem("6世","6"),
                new ListItem("7世","7"),
                new ListItem("8世","8"),
                new ListItem("9世","9"),
            };
        }
    }
}
