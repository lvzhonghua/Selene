using Selene.DAL.IDAL;
using Selene.Model;
using Selene.Model.SettingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public class TextValueBLL : IDisposable
    {
        private ITextValueDAL textValueDAL;
        
        public TextValueBLL()
        {
            this.textValueDAL = new TextValueDAL();
        }

        public void Dispose()
        {
        }
    }
}
