using Selene.DB.DBAttribute;
using Selene.DB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Message
{
    public abstract class ModelBase
    {
        [ColumnAttribute(false)]
        public ModelStatus ModelStatus { get; set; }
    }
}
