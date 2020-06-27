using Doit.Print.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print.Holders
{
    /// <summary>
    /// 设计器占位符工厂
    /// </summary>
    public class StyleHolderFactory
    {
        /// <summary>
        /// 创建占位符
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns>占位符</returns>
        public StyleHolder Create(object model)
        {
            StyleHolder holder = null;

            if (model is CellStyle)
            {
                holder = new CellStyleHolder();
            }
            else if (model is FieldStyle)
            {
                holder = new FieldStyleHolder();
            }
            else if (model is LineStyle)
            {
                holder = new LineStyleHolder();
            }

            if (holder != null) holder.Model = model;

            return holder;
        }
    }
}
