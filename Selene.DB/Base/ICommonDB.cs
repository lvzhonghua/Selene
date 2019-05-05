using Selene.DB.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Base
{
    public interface ICommonDB<TEntity> : IDB<TEntity>, ISupportSaveDB<TEntity>, ISupportDeleteDB<TEntity> where TEntity : ModelBase,new()
    {
        /// <summary>
        /// 查询实体迭代
        /// </summary>
        /// <returns>返回实体迭代</returns>
        IEnumerable<TEntity> GetAllEntityEnumerable();

        /// <summary>
        /// 查询实体迭代
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>返回实体迭代</returns>
        IEnumerable<TEntity> GetAllEntityEnumerable(string filter);
    }
}
