using Selene.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Providers.Control
{
    public class ZoomScaleProvider : IDataListItemProvider
    {

        public List<ListItem> GetDataList()
        {
            return new List<ListItem>()
            {
                new ListItem("自动缩放","auto"),
                new ListItem("200%","2"),
                new ListItem("175%","1.75"),
                new ListItem("150%","1.5"),
                new ListItem("125%","1.25"),
                new ListItem("100%","1"),
                new ListItem("75%","0.75"),
                new ListItem("50%","0.5"),
                new ListItem("25%","0.25")
            };
        }
    }
}
