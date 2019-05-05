using Selene.DAL.DAL;
using Selene.DAL.IDAL;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public class VolumeBLL : IDisposable
    {
        private IVolumeDAL volumeDAL;
        public VolumeBLL()
        {
            volumeDAL = new VolumeDAL();
        }

        public bool SaveDefaultVolume()
        {
            Volume defaultVolume = new Volume();
            defaultVolume.Name = "卷一";
            defaultVolume.NeedCatalogue = true;
            defaultVolume.NeedCheatSheets = true;
            defaultVolume.Sort = 0;
            defaultVolume.StartIndex = 1;

            return volumeDAL.SaveRtnBool(defaultVolume);
        }

        public Volume GetDefaultVolume()
        {
            return volumeDAL.GetDefaultVolume();
        }

        public IList<Volume> GetVolumes()
        {
            return volumeDAL.GetVolumes();
        }

        public Volume GetVolumeById(int id)
        {
            return volumeDAL.GetEntityByTId(id);
        }

        public bool ExistVolume(string name, int id)
        {
            return volumeDAL.ExistVolume(name, id);
        }

        public bool ApplyChange(Volume volume)
        {
            return volumeDAL.ApplyChangeRtnBool(volume);
        }

        public bool DeleteVolume(Volume volume)
        {
            return volumeDAL.DeleteEntity(volume);
        }

        public bool UpdateVolume(Volume volume)
        {
            return volumeDAL.UpdateRtnBool(volume);
        }

        public void Dispose()
        {
        }
    }
}
