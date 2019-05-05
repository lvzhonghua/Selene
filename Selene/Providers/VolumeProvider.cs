using Selene.Logical;
using Selene.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Providers
{
    public class VolumeProvider : IDataListItemProvider
    {
        public List<ListItem> GetDataList()
        {
            return new VolumeBLL().GetVolumes().Select(volume => new ListItem(volume.Name, volume.Id.ToString())).ToList();
        }
    }
}
