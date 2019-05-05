using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.IDAL
{
    public interface IVolumeDAL:ICommonDB<Volume>
    {
        Volume GetDefaultVolume();

        IList<Volume> GetVolumes();

        bool ExistVolume(string name, int id);
    }
}
