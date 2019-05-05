﻿using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL
{
    public interface IGenealogyDAL:ICommonDB<Genealogy>
    {
        /// <summary>
        /// 得到始祖的世数
        /// </summary>
        int GetAncestorWorldNumber();
    }
}
