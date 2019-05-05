using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Base
{
    public interface ISupportDeleteDB<TEntity>
    {
        /// <summary>
        /// 根据实体对象删除对象
        /// </summary>
        /// <param name="entity">实体实参</param>
        /// <returns>是否删除成功</returns>
        bool DeleteEntity(TEntity entity);

        /// <summary>
        /// 根据主键ID删除对象
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否删除成功</returns>
        bool DeleteEntity(object id);

        /// <summary>
        /// 根据filter删除对象
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>是否删除成功</returns>
        bool DeleteEntityByFilter(string filter);
    }
}
