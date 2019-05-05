using Selene.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Providers
{
    public class StyleProvider:IDataListItemProvider
    {
        public List<ListItem> GetDataList()
        {
            return new List<ListItem>()
            {
                new ListItem("书籍式","book",true),
                new ListItem("现代欧式","modern-ou",false)
            };
        }
    }
}
