using Selene.DB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.DBBaseException
{
    public class DBException : Exception
    {
        /// <summary>
        /// 空重载 为默认DB错误
        /// </summary>
        public DBException()
            : base(DBExFactory.CreateDBExFactory(DBEx.DBEx))
        { }

        /// <summary>
        /// DB枚举错误
        /// </summary>
        /// <param name="dbex">枚举</param>
        public DBException(DBEx dbex)
            : base(DBExFactory.CreateDBExFactory(dbex))
        { }

        /// <summary>
        /// 自定义错误信息
        /// </summary>
        /// <param name="mess">自定义错误信息</param>
        public DBException(string mess)
            : base(mess)
        { }

        /// <summary>
        /// 自定义错误信息、Exception
        /// </summary>
        /// <param name="mess">自定义错误信息</param>
        /// <param name="ex">Exception</param>
        public DBException(string mess, Exception ex)
            : base(mess, ex)
        { }

        /// <summary>
        /// Exception
        /// </summary>
        /// <param name="ex">Exception</param>
        public DBException(Exception ex)
            : base(DBExFactory.CreateDBExFactory(DBEx.DBEx), ex)
        { }

        /// <summary>
        /// 枚举错误、Exception
        /// </summary>
        /// <param name="dbex">枚举错误</param>
        /// <param name="ex">Exception</param>
        public DBException(DBEx dbex, Exception ex)
            : base(DBExFactory.CreateDBExFactory(dbex), ex)
        { }

    }

}
