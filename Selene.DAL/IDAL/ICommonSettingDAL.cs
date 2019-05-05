using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.IDAL
{
    public interface ICommonSettingDAL : ICommonDB<CommonSetting>
    {
        CommonSetting GetCommonSetting(string key);

        CommonSetting GetCommonSetting(string key,string type);

        CommonSetting GetCommonSetting(string key,string type,string subType);
    }
}
