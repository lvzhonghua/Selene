using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Base
{
    #region IDB
    /// <summary>
    /// 查询指令
    /// </summary>
    /// <typeparam name="TEntity">实体形参</typeparam>
    /// <typeparam name="TId">实体主键形参</typeparam>
    public interface IDB<TEntity>
    {
        #region IList
        /// <summary>
        /// 查询所有的实体对象
        /// </summary>
        /// <returns>返回IList</returns>
        IList<TEntity> GetAllEntityList();

        /// <summary>
        /// 查询所有的实体对象
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>符合条件的DataTable</returns>
        IList<TEntity> GetAllEntityList(string filter);

        IList<TEntity> GetAllEntityList(string filter, List<DbParameter> parms);

        IList<TEntity> GetEntityList(string cmdText);

        IList<TEntity> GetEntityList(string cmdText, List<DbParameter> parms);
        #endregion

        #region GetTable
        /// <summary>
        /// 获取所有的table数据
        /// </summary>
        /// <returns>返回table</returns>
        DataTable GetTable();

        /// <summary>
        /// 获取所有的table数据
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>返回table</returns>
        DataTable GetTable(string filter);

        DataTable GetTable(string filter, List<DbParameter> parms);

        #endregion

        #region TEntity
        /// <summary>
        /// 根据主键ID查找实体对象
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>主键对应的实体</returns>
        TEntity GetEntityByTId(object id);

        /// <summary>
        /// 根据filter实体对象
        /// </summary>
        /// <param name="id">条件形如【and t='t'】</param>
        /// <returns>符合条件的实体</returns>
        TEntity GetEntityByFilter(string filter);


        TEntity GetEntityByFilter(string filter, List<DbParameter> parms);

        TEntity GetEntity(string cmdText);

        TEntity GetEntity(string cmdText, List<DbParameter> parms);

        /// <summary>
        /// 根据主键查询是否存在
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在 true是 false否</returns>
        bool GetEntityByTIdRtnBool(object id);

        /// <summary>
        /// 根据条件查询是否存在
        /// </summary>
        /// <param name="id">条件形如【and t='t'】</param>
        /// <returns>是否存在 true是 false否</returns>
        bool GetEntityByFilterRtnBool(string filter);

        /// <summary>
        /// 根据实体判断是否已经存在于数据库
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>是否存在  true是 false否</returns>
        bool GetEntityByEntityRtnBool(TEntity entity);

        #endregion
    }
    #endregion
}
