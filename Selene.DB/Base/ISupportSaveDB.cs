using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Base
{
    public interface ISupportSaveDB<TEntity>
    {
        #region Save
        /// <summary>
        /// 保存对象返回保存的实体(含主键ID)
        /// </summary>
        /// <param name="entity">要保存的实体</param>
        /// <returns>保存成功的实体</returns>
        TEntity SaveRtnEntity(TEntity entity);

        /// <summary>
        /// 保存对象返回是否保存成功
        /// </summary>
        /// <param name="entity">要保存的实体</param>
        /// <returns>是否保存成功</returns>
        bool SaveRtnBool(TEntity entity);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dt">一批数据</param>
        /// <returns>是否保存成功</returns>
        bool BatchSave(DataTable dt);
        #endregion

        #region Update
        /// <summary>
        /// 更新对象返回保存的实体(含主键ID)
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>更新成功的实体</returns>
        TEntity UpdateRtnEntity(TEntity entity);

        /// <summary>
        /// 更新对象返回是否保存成功
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>是否更新成功</returns>
        bool UpdateRtnBool(TEntity entity);
        #endregion

        #region SaveUpdate
        /// <summary>
        /// 保存或更新 返回更新的实体，并且out一个参数表示是保存还是更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="flag">flag=true是保存false是更新</param>
        /// <returns>保存成功的实体</returns>
        TEntity SaveOrUpdateRtnEntity(TEntity entity, out bool flag);

        /// <summary>
        /// 保存或更新 返回更新的实体，并且out一个参数表示是保存还是更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="flag">flag=true是保存false是更新</param>
        /// <returns>是否保存成功</returns>
        bool SaveOrUpdateRtnBool(TEntity entity, out bool flag);


        bool ApplyChangeRtnBool(TEntity entity);

        TEntity ApplyChangeRtnEntity(TEntity entity);
        #endregion
    }
}
