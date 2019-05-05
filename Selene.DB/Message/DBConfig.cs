using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Message
{
    public class DBConfig
    {
        public static string connStringFormat = "DataSource={0};Version=3;";
        private static string connString;
        public static String ConnString{
            get
            {
                return String.Format(DBConfig.connStringFormat,DBConfig.connString);
            }
            set
            {
                DBConfig.connString = value;
            }
        }


    }
}
