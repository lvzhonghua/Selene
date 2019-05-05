using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.BaseControl.Interface
{
    public interface IDataControl
    {
        string PropertyName { get; set; }

        string ModelName { get; set; }
    }
}
