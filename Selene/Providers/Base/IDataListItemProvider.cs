using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Providers.Base
{
    public interface IDataListItemProvider
    {
        List<ListItem> GetDataList();
    }
}
