using Selene.DB.DBAttribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Utils
{
    public class DBUtil
    {
        #region 注解
        /// <summary>
        /// 根据实体拼接到字段对象
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>拼接的select 和from之间的字段</returns>
        internal static string GetColumns<TEntity>()
        where TEntity : class,new()
        {
            //得到TEntity的类型
            Type tentity = typeof(TEntity);
            //得到对象的所有的属性
            var properties = tentity.GetProperties();
            //存储属性串
            StringBuilder stringBuilder = new StringBuilder();
            ColumnAttribute att = null;
            //循环属性得到属性串
            foreach (var item in properties)
            {
                att = Attribute.GetCustomAttribute(item, typeof(ColumnAttribute)) as ColumnAttribute;
                if (att == null)
                {
                    stringBuilder.Append(item.Name + ",");     //"name,"
                    continue;
                }
                //如果有注解
                if (att.IsMapping) //注解为映射 
                {
                    if (att.MapColumn != null && att.MapColumn != "")  //并且有映射信息
                    {
                        stringBuilder.Append(att.MapColumn + ",");     //"name,"
                    }
                    else    //默认取属性名
                    {
                        stringBuilder.Append(item.Name + ",");     //"name,"
                    }
                }
                else   //注解信息为不映射
                {
                    continue;   //跳出本次
                }

            }
            string selectNames = stringBuilder.ToString();
            selectNames = selectNames.Substring(0, selectNames.Length - 1);
            return selectNames;
        }

        /// <summary>
        /// 根据实体注解得到主键字段
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <returns>主键</returns>
        internal static string GetKeyColumn<TEntity>()
        {
            string key = string.Empty;
            //得到TEntity的类型
            Type tentity = typeof(TEntity);
            //得到对象的所有的属性
            var properties = tentity.GetProperties();
            //数据注解
            ColumnAttribute att = null;
            //循环
            foreach (var item in properties)
            {
                //如果没有标记主键，则默认取第一个属性
                if (key == string.Empty)
                {
                    key = item.Name;
                }
                //获得注解
                att = Attribute.GetCustomAttribute(item, typeof(ColumnAttribute)) as ColumnAttribute;
                if (att == null || att.IsKey == false) { continue; }
                key = item.Name;  //如果取到注解的属性就直接跳出
                break;
            }
            return key;
        }

        /// <summary>
        /// 根据注解实体得到表名
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <returns>表名</returns>
        internal static string GetTableName<TEntity>()
        {
            //得到TEntity的类型
            Type tentity = typeof(TEntity);
            //得到对象的所有的属性
            //return tentity.Name;
            TableAttribute att = Attribute.GetCustomAttribute(tentity, typeof(TableAttribute)) as TableAttribute;
            if (att == null || att.TableName == "")
            {
                return tentity.Name;
            }
            return att.TableName;
        }
        #endregion

        #region table <-> list
        /// <summary>
        /// 将DataTable转换为IList
        /// </summary>
        /// <typeparam name="TEntity">IList的强类型</typeparam>
        /// <param name="dt">需要转换的DateTable</param>
        /// <returns>转换后的IList</returns>
        public static IList<TEntity> TableConvertList<TEntity>(DataTable dt)
        where TEntity : class,new()
        {
            IList<TEntity> listEntity = new List<TEntity>();// 定义集合
            Type type = typeof(TEntity); // 获得此模型的类型

            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                TEntity t = new TEntity();

                PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性

                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        //处理GUID的自动转换为string
                        if ("System.Guid".Equals(dr[tempName].GetType().FullName))
                        {
                            value = value.ToString();
                        }

                        if ((value is DBNull))
                        {
                            value = null;
                        }
                        if (value == null)
                        {
                            if(pi.PropertyType==typeof(int)){
                                value = default(int);
                            }
                        }
                        value = Convert.ChangeType(value, pi.PropertyType);

                        pi.SetValue(t, value, null);
                    }
                }
                listEntity.Add(t);
            }
            return listEntity;
        }

        //#region List泛型集合转换为DataTable
        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable<T>(list, null);
        }

        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="propertyName">需要返回的列的列名</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        var _type = pi.PropertyType;
                        result.Columns.Add(pi.Name);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            if (obj != null)
                            {
                                tempList.Add(obj.ToString().Trim());
                            }
                            else
                            {
                                tempList.Add(obj);
                            }
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                if (obj != null)
                                {
                                    tempList.Add(obj.ToString().Trim());
                                }
                                else
                                {
                                    tempList.Add(obj);
                                }
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        #endregion

        #region Insert-Update-SelectKey-KeyWhere
        /// <summary>
        /// 将实体转换为添加的SQL语句
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <param name="entity">实体实参</param>
        /// <returns>添加的SQL语句</returns>
        internal static string EntityConvertInsert<TEntity>(TEntity entity)
            where TEntity : class,new()
        {
            //得到TEntity的类型
            Type tentity = typeof(TEntity);
            //得到对象的所有的属性
            var properties = tentity.GetProperties();
            //存储属性串
            StringBuilder stringBuilder = new StringBuilder();
            //存储属性串对应的值
            StringBuilder stringBuilderValue = new StringBuilder();
            ColumnAttribute att = null;
            //循环属性得到属性串
            foreach (var item in properties)
            {
                att = Attribute.GetCustomAttribute(item, typeof(ColumnAttribute)) as ColumnAttribute;
                if (att == null)
                {
                    stringBuilder.Append(item.Name + ",");     //"name,"
                    stringBuilderValue.Append("'" + item.GetValue(entity, null) + "',");   //'free,'
                    continue;
                }

                //如果有注解
                //先判断【自增】 和【不映射】
                if (att.IsIdentity || att.IsMapping == false)
                {    //如果是自增，则直接跳过
                    continue;
                }
                //注解为映射 
                if (att.MapColumn != null && att.MapColumn != "")  //并且有映射信息
                {
                    stringBuilder.Append(att.MapColumn + ",");     //"name,"
                }
                else    //默认取属性名
                {
                    stringBuilder.Append(item.Name + ",");     //"name,"
                }
                stringBuilderValue.Append("'" + item.GetValue(entity, null) + "',");   //'free,'

            }
            string selectNames = stringBuilder.ToString();
            selectNames = selectNames.Substring(0, selectNames.Length - 1);

            string selectNamesValue = stringBuilderValue.ToString();
            selectNamesValue = selectNamesValue.Substring(0, selectNamesValue.Length - 1);
            string tableName = GetTableName<TEntity>();
            string insertSql = string.Format("insert into {0}({1}) values({2})", tableName, selectNames, selectNamesValue);
            return insertSql;
        }

        /// <summary>
        /// 将实体转换为修改的SQL语句
        /// </summary>
        /// <typeparam name="TEntity">实体形参</typeparam>
        /// <param name="entity">实体实参</param>
        /// <returns>更新的SQL语句</returns>
        internal static string EntityConvertUpdate<TEntity>(TEntity entity)
             where TEntity : class,new()
        {
            //得到TEntity的类型
            Type tentity = typeof(TEntity);
            //得到对象的所有的属性
            var properties = tentity.GetProperties();
            //存储属性串
            StringBuilder stringBuilder = new StringBuilder();
            //Where 条件
            string where = "";
            ColumnAttribute att = null;
            //循环属性得到属性串
            foreach (var item in properties)
            {
                att = Attribute.GetCustomAttribute(item, typeof(ColumnAttribute)) as ColumnAttribute;
                var value = item.GetValue(entity, null);
                //如果等于空 拼set后 直接重来
                if (att == null)
                {
                    stringBuilder.Append(string.Format("{0}='{1}',", item.Name, value));   //t='newT'
                    continue;
                }

                //不映射的直接从来
                if (att.IsMapping == false)
                {
                    continue;
                }

                //如果是主键 拼条件后 直接从来
                if (att.IsKey)
                {
                    //判断是否自定义列
                    if (att.MapColumn != "" && att.MapColumn != null)
                    {
                        where = string.Format(" and {0}='{1}'", att.MapColumn, value);
                    }
                    else
                    {
                        where = string.Format(" and {0}='{1}'", item.Name, value);
                    }
                    continue;
                }

                //最后处理自定义列映射
                if (att.MapColumn != "" && att.MapColumn != null)
                {
                    stringBuilder.Append(string.Format("{0}='{1}',", att.MapColumn, value));   //t='newT'
                }

            }
            //set 列
            string selectNames = stringBuilder.ToString();
            selectNames = selectNames.Substring(0, selectNames.Length - 1);
            //获取表名
            string tableName = GetTableName<TEntity>();
            string updateSql = string.Format("UPDATE {0} SET {1} WHERE 1=1 {2}", tableName, selectNames, where);
            return updateSql;
        }

        /// <summary>
        /// 根据实体查找主键值
        /// </summary>
        /// <typeparam name="TEntity">实体形参</typeparam>
        /// <param name="entity">实体实参</param>
        /// <returns>根据主键值查找主键值</returns>
        internal static string EntityConvertSelectKey<TEntity>(TEntity entity)
        where TEntity : class,new()
        {
            //得到TEntity的类型
            Type tentity = typeof(TEntity);
            //得到对象的所有的属性
            var properties = tentity.GetProperties();

            //获取表名
            string tableName = GetTableName<TEntity>();
            //SelectSql
            string selectSql = "";
            ColumnAttribute att = null;
            //循环属性得到属性串
            foreach (var item in properties)
            {
                att = Attribute.GetCustomAttribute(item, typeof(ColumnAttribute)) as ColumnAttribute;
                var value = item.GetValue(entity, null);
                //如果等于空 拼set后 直接重来
                if (att == null)
                {
                    continue;
                }
                //不映射的直接从来
                if (att.IsMapping == false)
                {
                    continue;
                }
                //如果是主键 拼条件后 直接从来
                if (att.IsKey)
                {
                    var columns = item.Name;
                    //判断是否自定义列
                    if (att.MapColumn != "" && att.MapColumn != null)
                    {
                        columns = att.MapColumn;
                    }
                    if (att.IsIdentity)
                    {
                        selectSql = string.Format(" select {0} from {1} where 1=1 and {2}={3}", columns, tableName, columns, value);
                    }
                    else
                    {
                        selectSql = string.Format(" select {0} from {1} where 1=1 and {2}='{3}'", columns, tableName, columns, value);
                    }
                    break;
                }
            }
            return selectSql;
        }

        /// <summary>
        /// 根据实体拼接主键where条件
        /// </summary>
        /// <typeparam name="TEntity">实体形参</typeparam>
        /// <param name="entity">实体实参</param>
        /// <returns>主键where条件【形如 and key=''】</returns>
        internal static string EntityConvertKeyWhere<TEntity>(TEntity entity)
        where TEntity : class,new()
        {
            //得到TEntity的类型
            Type tentity = typeof(TEntity);
            //得到对象的所有的属性
            var properties = tentity.GetProperties();

            //获取表名
            string tableName = GetTableName<TEntity>();
            //whereKey
            string whereKey = "";
            ColumnAttribute att = null;
            //循环属性得到属性串
            foreach (var item in properties)
            {
                att = Attribute.GetCustomAttribute(item, typeof(ColumnAttribute)) as ColumnAttribute;
                var value = item.GetValue(entity, null);
                //如果等于空 拼set后 直接重来
                if (att == null)
                {
                    continue;
                }
                //不映射的直接从来
                if (att.IsMapping == false)
                {
                    continue;
                }
                //如果是主键 拼条件后 直接从来
                if (att.IsKey)
                {
                    var columns = item.Name;
                    //判断是否自定义列
                    if (att.MapColumn != "" && att.MapColumn != null)
                    {
                        columns = att.MapColumn;
                    }
                    if (att.IsIdentity)
                    {
                        whereKey = string.Format(" and {0}={1} ", columns, value);
                    }
                    else
                    {
                        whereKey = string.Format(" and {0}='{1}' ", columns, value);
                    }
                    break;
                }
            }
            return whereKey;
        }
        #endregion
    }
}
