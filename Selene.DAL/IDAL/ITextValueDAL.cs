using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.IDAL
{
    public interface ITextValueDAL : ICommonDB<TextValue>
    {
        IList<TextValue> GetTextValues(string key);

        IList<TextValue> GetTextValues(string key,string type);

        IList<TextValue> GetTextValues(string key,string type,string subType);
    }
}
