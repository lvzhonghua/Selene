using Selene.DB.DBBaseException;
using Selene.DB.Enums;
using Selene.DB.Helper;
using Selene.DB.Message;
using Selene.DB.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Base
{
    public abstract class CommonDB<TEntity> : ICommonDB<TEntity>
        where TEntity : ModelBase, new()
    {
        #region TableInfo
        private string tableName = string.Empty;
        private string tableKey = string.Empty;

        //获得表名
        protected string TableName
        {
            get
            {
                if (tableName == string.Empty || tableName == "")
                {
                    tableName = DBUtil.GetTableName<TEntity>();
                }
                return tableName;
            }
        }

        //获得表的主键
        protected string TableKey
        {
            get
            {
                if (tableKey == string.Empty || tableKey == "")
                {
                    tableKey = DBUtil.GetKeyColumn<TEntity>();
                }
                return tableKey;
            }
        }

        #endregion

        #region DataMode
        //获取当前的数据库连接模式
        private string _dataMode = "Sqlite";

        /// <summary>
        /// 只读：分为SqlServer、Access两种类型
        /// </summary>
        protected string _DataMode
        {
            get { return _dataMode; }
        }

        /// <summary>
        /// 连接字符串类型[枚举]
        /// </summary>
        protected DataMode EDataMode
        {
            get
            {
                return (DataMode)Enum.Parse(typeof(DataMode), _dataMode);
            }
        }

        #endregion

        #region IHelper
        private IHelper helper;
        /// <summary>
        /// 操作数据实体的方法 继承状态才能访问
        /// </summary>
        protected IHelper Helper
        {
            get
            {
                //简单工厂，创建何种对象由简单工厂处理
                helper = HelperFactory.CreateHelper(_dataMode);
                return helper;
            }
        }
        #endregion

        #region IEnumerable
        /// <summary>
        /// 查询所有实体的迭代
        /// </summary>
        /// <returns>返回所有实体的迭代</returns>
        public IEnumerable<TEntity> GetAllEntityEnumerable()
        {
            DataTable dt = GetTable();
            IList<TEntity> entitys = DBUtil.TableConvertList<TEntity>(dt);
            return entitys.AsEnumerable();
        }

        /// <summary>
        /// 查询所有实体的迭代
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>返回所有实体的迭代</returns>
        public IEnumerable<TEntity> GetAllEntityEnumerable(string filter)
        {
            DataTable dt = GetTable(filter);
            IList<TEntity> entitys = DBUtil.TableConvertList<TEntity>(dt);
            return entitys.AsEnumerable();
        }
        #endregion

        #region IList
        /// <summary>
        /// 查询整个实体的IList
        /// </summary>
        /// <returns>返回所有实体的IList</returns>
        public IList<TEntity> GetAllEntityList()
        {
            DataTable dt = GetTable();
            IList<TEntity> entitys = null;
            try
            {
                entitys = DBUtil.TableConvertList<TEntity>(dt);
            }
            catch (Exception ex)
            {
                throw new DBException(DBEx.DBConvertEx, ex);
            }
            return entitys;
        }

        /// <summary>
        /// 查询整个实体的IList
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>返回所有实体的IList</returns>
        public IList<TEntity> GetAllEntityList(string filter)
        {
            return GetAllEntityList(filter, null);
        }
        #endregion

        #region TEntity
        /// <summary>
        /// 根据ID查找得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetEntityByTId(object id)
        {
            string filter = string.Format(" and {0}='{1}'", TableKey, id);
            IList<TEntity> entitys = GetAllEntityList(filter);
            if (entitys != null && entitys.Count > 0)
            {
                return entitys[0];
            }
            return null;
        }

        /// <summary>
        /// 根据filter实体对象
        /// </summary>
        /// <param name="id">条件形如【and t='t'】</param>
        /// <returns>符合条件的实体</returns>
        public TEntity GetEntityByFilter(string filter)
        {
            return GetEntityByFilter(filter, null);
        }


        /// <summary>
        /// 根据主键查询是否存在
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在 true是 false否</returns>
        public virtual bool GetEntityByTIdRtnBool(object id)
        {
            var entity = GetEntityByTId(id);
            if (entity != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据实体判断是否已经存在于数据库
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>是否存在  true是 false否</returns>
        public virtual bool GetEntityByEntityRtnBool(TEntity entity)
        {
            string filter = DBUtil.EntityConvertKeyWhere<TEntity>(entity);
            var result = GetEntityByFilterRtnBool(filter);
            return result;
        }

        /// <summary>
        /// 根据条件查询是否存在
        /// </summary>
        /// <param name="id">条件形如【and t='t'】</param>
        /// <returns>是否存在 true是 false否</returns>
        public bool GetEntityByFilterRtnBool(string filter)
        {
            var entity = GetEntityByFilter(filter);
            if (entity != null)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region GetTable
        /// <summary>
        /// 查询所有的数据返回DT
        /// </summary>
        /// <returns>返回所有的DataTable</returns>
        public DataTable GetTable()
        {
            DataTable dt = GetTable("");
            return dt;
        }

        /// <summary>
        /// 查询DataTable 后接where and条件
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>符合条件的DataTable</returns>
        public DataTable GetTable(string filter)
        {
            return GetTable(filter, null);
        }

        public DataTable GetTable(string filter, List<DbParameter> parms)
        {
            string selectNames = DBUtil.GetColumns<TEntity>();
            string cmdFormat = string.Format("select {0} from {1} where 1=1 {2}", selectNames, TableName, filter);
            if (parms != null)
            {
                return Helper.GetDataTable(cmdFormat, parms);
            }
            return Helper.GetDataTable(cmdFormat);
        }
        #endregion

        #region Save
        /// <summary>
        /// 保存对象返回保存的实体(含主键ID)
        /// </summary>
        /// <param name="entity">要保存的实体</param>
        /// <returns>保存成功的实体</returns>
        public TEntity SaveRtnEntity(TEntity entity)
        {
            if (SaveRtnBool(entity))
            {
                //反射方式将得到的id设置对实体
                var entityType = typeof(TEntity);
                var Properties = entityType.GetProperties();

                PropertyInfo propertyInfo = Properties.First(pro => pro.Name.Equals(TableKey));
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(entity, helper.LastInsertRowId());
                }
                return entity;
            }
            return null;
        }

        /// <summary>
        /// 保存对象返回是否保存成功
        /// </summary>
        /// <param name="entity">要保存的实体</param>
        /// <returns>是否保存成功</returns>
        public bool SaveRtnBool(TEntity entity)
        {
            string cmdText = DBUtil.EntityConvertInsert<TEntity>(entity);
            if (Helper.ExecuteCommand(cmdText) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dt">一批数据</param>
        /// <returns>是否保存成功</returns>
        public bool BatchSave(DataTable dt)
        {
            return Helper.BatchInsert(dt);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新对象返回保存的实体(含主键ID)
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>更新成功的实体</returns>
        public TEntity UpdateRtnEntity(TEntity entity)
        {
            if (UpdateRtnBool(entity))
            {
                return entity;
            }
            return null;
        }

        /// <summary>
        /// 更新对象返回是否保存成功
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>是否更新成功</returns>
        public bool UpdateRtnBool(TEntity entity)
        {
            string cmdText = DBUtil.EntityConvertUpdate<TEntity>(entity);
            if (Helper.ExecuteCommand(cmdText) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region SaveUpdate
        /// <summary>
        /// 保存或更新 返回更新的实体，并且out一个参数表示是保存还是更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="flag">flag=true是保存false是更新</param>
        /// <returns>保存成功的实体</returns>
        public virtual TEntity SaveOrUpdateRtnEntity(TEntity entity, out bool flag)
        {
            if (GetEntityByEntityRtnBool(entity))
            {    //存在是更新
                flag = false;
                return UpdateRtnEntity(entity);
            }
            else
            {    //新增
                flag = true;
                return SaveRtnEntity(entity);
            }
        }

        /// <summary>
        /// 保存或更新 返回更新的实体，并且out一个参数表示是保存还是更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="flag">flag=true是保存false是更新</param>
        /// <returns>是否保存成功</returns>
        public virtual bool SaveOrUpdateRtnBool(TEntity entity, out bool flag)
        {
            if (GetEntityByEntityRtnBool(entity))
            {    //存在是更新
                flag = false;
                return UpdateRtnBool(entity);
            }
            else
            {    //新增
                flag = true;
                return SaveRtnBool(entity);
            }
        }

        #endregion

        #region Delete
        /// <summary>
        /// 根据实体对象删除对象
        /// </summary>
        /// <param name="entity">实体实参</param>
        /// <returns>是否删除成功</returns>
        public virtual bool DeleteEntity(TEntity entity)
        {
            //得到主键的where
            string filter = DBUtil.EntityConvertKeyWhere<TEntity>(entity);
            return DeleteEntityByFilter(filter);
        }

        /// <summary>
        /// 根据主键ID删除对象
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否删除成功</returns>
        public virtual bool DeleteEntity(object id)
        {
            //得到主键的where
            string filter = string.Format(" and {0}='{1}'", TableKey, id);
            return DeleteEntityByFilter(filter);
        }

        /// <summary>
        /// 根据filter删除对象
        /// </summary>
        /// <param name="filter">条件形如【and t='t'】</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteEntityByFilter(string filter)
        {
            string cmdText = string.Format("delete from {0} where 1=1 {1}", TableName, filter);
            var result = Helper.ExecuteCommand(cmdText);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        #endregion


        public IList<TEntity> GetAllEntityList(string filter, List<DbParameter> parms)
        {
            DataTable dt = GetTable(filter, parms);
            IList<TEntity> entitys = null;
            try
            {
                entitys = DBUtil.TableConvertList<TEntity>(dt);
            }
            catch (Exception ex)
            {
                throw new DBException(DBEx.DBConvertEx, ex);
            }
            return entitys;
        }

        public TEntity GetEntityByFilter(string filter, List<DbParameter> parms)
        {
            IList<TEntity> entitys = GetAllEntityList(filter, parms);
            if (entitys != null && entitys.Count > 0)
            {
                return entitys[0];
            }
            return null;
        }


        public TEntity GetEntity(string cmdText)
        {
            return GetEntity(cmdText, null);
        }

        public TEntity GetEntity(string cmdText, List<DbParameter> parms)
        {
            var list = GetEntityList(cmdText, parms);
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            return list[0];
        }


        public IList<TEntity> GetEntityList(string cmdText)
        {
            return GetEntityList(cmdText, null);
        }

        public IList<TEntity> GetEntityList(string cmdText, List<DbParameter> parms)
        {
            var table = Helper.GetDataTable(cmdText, parms);
            return DBUtil.TableConvertList<TEntity>(table);
        }


        public bool ApplyChangeRtnBool(TEntity entity)
        {
            if (entity.ModelStatus == ModelStatus.Add)
            {
                return SaveRtnBool(entity);
            }
            else if (entity.ModelStatus == ModelStatus.Update)
            {
                return UpdateRtnBool(entity);
            }
            else if (entity.ModelStatus == ModelStatus.Delete)
            {
                return DeleteEntity(entity);
            }
            return false;
        }

        public TEntity ApplyChangeRtnEntity(TEntity entity)
        {
            if (entity.ModelStatus == ModelStatus.Add)
            {
                return SaveRtnEntity(entity);
            }
            else if (entity.ModelStatus == ModelStatus.Update)
            {
                return UpdateRtnEntity(entity);
            }
            return null;
        }
    }
}
