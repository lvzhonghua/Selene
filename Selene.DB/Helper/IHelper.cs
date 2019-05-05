using Selence.DB.Ex;
using Selene.DB.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Helper
{
    public interface IHelper
    {

        #region 连接字符串

        /// <summary>
        /// 连接字符串类型
        /// </summary>
        string _DataMode { get; }

        /// <summary>
        /// 连接字符串类型[枚举]
        /// </summary>
        DataMode EDataMode { get; }

        /// <summary>
        /// 得到连接字符串对象
        /// </summary>
        /// <returns>返回连接字符串对象</returns>
        DbConnection GetConnection();

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns>返回连接字符串</returns>
        string GetString();

        void SetConnString(string connString);

        #endregion

        #region 执行查询命令
        /// <summary>
        /// 执行查询命令
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parms">参数</param>
        /// <returns>受影响的行数</returns>
        int ExecuteCommand(string cmdText, CommandType cmdType, List<DbParameter> parms);

        /// <summary>
        /// 执行查询命令
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="parms">参数</param>
        /// <returns>受影响的行数</returns>
        int ExecuteCommand(string cmdText, List<DbParameter> parms);

        /// <summary>
        /// 执行查询命令
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <returns>受影响的行数</returns>
        int ExecuteCommand(string cmdText);

        #endregion

        #region 查询得到table
        /// <summary>
        /// 查询得到table
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parms">参数</param>
        /// <returns>返回DataTable</returns>
        DataTable GetDataTable(string cmdText, CommandType cmdType, List<DbParameter> parms);

        /// <summary>
        /// 查询得到table
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="parms">参数</param>
        /// <returns>返回DataTable</returns>
        DataTable GetDataTable(string cmdText, List<DbParameter> parms);

        /// <summary>
        /// 查询得到table
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <returns>返回DataTable</returns>
        DataTable GetDataTable(string cmdText);

        #endregion

        #region IDataReader
        /// <summary>
        /// 获取IDataReader
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parms">参数</param>
        /// <returns>返回IDataReader</returns>
        IDataReader GetDataReader(string cmdText, CommandType cmdType, List<DbParameter> parms);

        /// <summary>
        /// 获取IDataReader
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="parms">参数</param>
        /// <returns>返回IDataReader</returns>
        IDataReader GetDataReader(string cmdText, List<DbParameter> parms);

        /// <summary>
        /// 获取IDataReader
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <returns>返回IDataReader</returns>
        IDataReader GetDataReader(string cmdText);

        #endregion

        #region 获取第一行第一列的值
        /// <summary>
        /// 获取第一行第一列的值
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parms">参数</param>
        /// <returns>返回第一行第一列的值</returns>
        Object GetDataScalar(string cmdText, CommandType cmdType, List<DbParameter> parms);

        /// <summary>
        /// 获取第一行第一列的值
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="parms">参数</param>
        /// <returns>返回第一行第一列的值</returns>
        Object GetDataScalar(string cmdText, List<DbParameter> parms);

        /// <summary>
        /// 获取第一行第一列的值
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <returns>返回第一行第一列的值</returns>
        Object GetDataScalar(string cmdText);

        dataType GetDataScalar<dataType>(string cmdText, CommandType cmdType, List<DbParameter> parms);

        dataType GetDataScalar<dataType>(string cmdText, List<DbParameter> parms);

        dataType GetDataScalar<dataType>(string cmdText);
        #endregion

        #region 查询得到Dateset
        /// <summary>
        /// 查询得到Dateset
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parms">参数</param>
        /// <returns>返回Dateset</returns>
        DataSet GetDataSet(string cmdText, CommandType cmdType, List<DbParameter> parms);

        /// <summary>
        /// 查询得到Dateset
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="parms">参数</param>
        /// <returns>返回Dateset</returns>
        DataSet GetDataSet(string cmdText, List<DbParameter> parms);

        /// <summary>
        /// 查询得到Dateset
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <returns>返回Dateset</returns>
        DataSet GetDataSet(string cmdText);

        #endregion

        #region 批量插入
        /// <summary>
        /// 执行批量插入
        /// </summary>
        /// <param name="dt">一批数据</param>
        /// <returns>是否成功</returns>
        bool BatchInsert(DataTable dt);
        #endregion

        #region ex
        /// <summary>
        /// 数据转义
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>after data</returns>
        string Escape(string data);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dic">数据</param>
        /// <returns>受影响的行数</returns>
        int Insert(string tableName, Dictionary<string, object> dic);

        int Insert<TEntity>(Dictionary<string, object> dic);

        DataTable Select(string sql);

        DataTable Select(string sql, Dictionary<string, object> dicParameters = null);

        DataTable Select(string sql, List<DbParameter> parameters);

        int Update(string tableName, Dictionary<string, object> dicData, string colCond, object varCond);

        int Update<TEntity>(Dictionary<string, object> dicData, string colCond, object varCond);

        int Update(string tableName, Dictionary<string, object> dicData, Dictionary<string, object> dicCond);

        int Update<TEntity>(Dictionary<string, object> dicData, Dictionary<string, object> dicCond);

        int LastInsertRowId();

        int CreateTable(SQLiteTable table);

        int RenameTable(string tableFrom, string tableTo);

        int CopyAllData(string tableFrom, string tableTo);

        int DropTable(string table);

        void UpdateTableStructure(string targetTable, SQLiteTable newStructure);

        int AttachDatabase(string database, string alias);

        int DetachDatabase(string alias);

        DataTable GetTableList();

        DataTable GetColumnStatus(string tableName);

        DataTable ShowDatabase();
        #endregion
    }
}
