using Selence.DB.Ex;
using Selene.DB.Helper;
using Selene.DB.Message;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public class DBManage
    {
        public static void CreateOrOpenDB(string dataPath, string dbname)
        {
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
            string fullDBName = CalcFullDBPath(dataPath, dbname);


            if (File.Exists(fullDBName))
            {
                return;
            }
            File.Create(fullDBName).Close();


        }

        public static void CreateOrOpenDBAndInit(string dataPath, string dbname)
        {
            CreateOrOpenDB(dataPath, dbname);
            //设置全局连接为当前创建的库
            SetSqliteDBPath(dataPath, dbname);

            //创建表
            CreateGenealogyTable();
            CreateClansmanTable();
            CreateCommonSettingTable();
            CreateLineageTable();
            CreateTextValueTable();
            CreateVolumeTable();


            //初始化默认数据
            using (CommonSettingBLL commonSettingBLL = new CommonSettingBLL())
            {
                commonSettingBLL.SaveDefaultCheatSheetsSetting();
            }
            using (VolumeBLL volumeBLL = new VolumeBLL())
            {
                volumeBLL.SaveDefaultVolume();
            }
        }

        public static bool CreateGenealogyTable()
        {
            SQLiteTable genealogyTable = new SQLiteTable("zp_genealogy_info");
            SQLiteColumnList columns = new SQLiteColumnList()
            {
                new SQLiteColumn("id",true),
                new SQLiteColumn("name",ColType.Text),
                new SQLiteColumn("familyName",ColType.Text),
                new SQLiteColumn("seniority",ColType.Text),
                new SQLiteColumn("seniorityWorldNumber",ColType.Integer),
                new SQLiteColumn("styleName",ColType.Text),
                new SQLiteColumn("worldManageNumber",ColType.Integer),
                new SQLiteColumn("worldImageManageNumber",ColType.Integer),
                new SQLiteColumn("ancestorParentInfo",ColType.Text),
                new SQLiteColumn("ancestorWorldNumber",ColType.Integer)
            };

            genealogyTable.Columns = columns;

            return HelperFactory.CreateHelper().CreateTable(genealogyTable) > 0;
        }

        public static void SetSqliteDBPath(string dataPath, string dbname)
        {
            DBConfig.ConnString = CalcFullDBPath(dataPath, dbname);
        }

        public static void SetSqliteDBPath(string dataPath)
        {
            DBConfig.ConnString = dataPath;
        }

        public static string CalcFullDBPath(string dataPath, string dbname)
        {
            if (dataPath.LastIndexOf("\\") == dataPath.Length - 1)
            {
                return dataPath + dbname;
            }
            else
            {
                return dataPath + "\\" + dbname;
            }
        }

        public static List<string> GetAllTables(string dbpath)
        {
            IHelper helper = HelperFactory.CreateHelper();
            helper.SetConnString(string.Format(DBConfig.connStringFormat, dbpath));

            List<string> tables = new List<string>();

            DataTable dt = helper.GetTableList();
            foreach (DataRow row in dt.Rows)
            {
                tables.Add(row[0].ToString());
            }

            return tables;
        }

        public static DataTable GetDataTable(string dbpath, string tableName)
        {
            IHelper helper = HelperFactory.CreateHelper();
            helper.SetConnString(string.Format(DBConfig.connStringFormat, dbpath));

            string cmdText = string.Format("select * from {0}", tableName);

            return helper.GetDataTable(cmdText);
        }

        public static bool CreateClansmanTable()
        {
            SQLiteTable genealogyTable = new SQLiteTable("zp_clansman");
            SQLiteColumnList columns = new SQLiteColumnList()
            {
                new SQLiteColumn("id",ColType.Integer,true,true,true,"0"),
                new SQLiteColumn("name",ColType.Text),
                new SQLiteColumn("pid",ColType.Integer),
                new SQLiteColumn("volume",ColType.Integer),
                new SQLiteColumn("relativeWorldNumber",ColType.Integer),
                new SQLiteColumn("seniority",ColType.Text),
                new SQLiteColumn("genealogyNote",ColType.Text),
                new SQLiteColumn("year",ColType.Integer),
                new SQLiteColumn("reignTitle",ColType.Text),
                new SQLiteColumn("addDuke",ColType.Boolean),
                new SQLiteColumn("tenetSeniority",ColType.Text),
                new SQLiteColumn("thisSeniority",ColType.Text),
                new SQLiteColumn("monicker",ColType.Text),
                new SQLiteColumn("sex",ColType.Integer),
                new SQLiteColumn("ownType",ColType.Text),
                new SQLiteColumn("parentNameDesc",ColType.Text),
                new SQLiteColumn("styledHimself",ColType.Text),
                new SQLiteColumn("mark",ColType.Text),
                new SQLiteColumn("sonChildrenNames",ColType.Text),
                new SQLiteColumn("daughterChildrenNames",ColType.Text),
                new SQLiteColumn("heirChildrenNames",ColType.Text),
                new SQLiteColumn("childrenNames",ColType.Text),
                new SQLiteColumn("sort",ColType.Integer)
            };

            genealogyTable.Columns = columns;

            return HelperFactory.CreateHelper().CreateTable(genealogyTable) > 0;
        }

        public static bool CreateCommonSettingTable()
        {
            SQLiteTable commonSettingTable = new SQLiteTable("sz_common_setting");
            SQLiteColumnList columns = new SQLiteColumnList()
            {
                new SQLiteColumn("id",ColType.Integer,true,true,true,"0"),
                new SQLiteColumn("key",ColType.Text),
                new SQLiteColumn("type",ColType.Text),
                new SQLiteColumn("subType",ColType.Text),
                new SQLiteColumn("settingJson",ColType.Text)
            };

            commonSettingTable.Columns = columns;

            return HelperFactory.CreateHelper().CreateTable(commonSettingTable) > 0;
        }

        public static bool CreateLineageTable()
        {
            SQLiteTable lineageTable = new SQLiteTable("zp_lineage_info");

            SQLiteColumnList columns = new SQLiteColumnList(){
                new SQLiteColumn("id",ColType.Integer,true,true,true,"0"),
                new SQLiteColumn("ancestorWroldNumberName",ColType.Text),
                new SQLiteColumn("edgeTitle",ColType.Text),
                new SQLiteColumn("topTitle",ColType.Text),
                new SQLiteColumn("worldNumberPrefix",ColType.Text),
                new SQLiteColumn("worldNumberSuffix",ColType.Text),
                new SQLiteColumn("worldNumberComments",ColType.Text),
                new SQLiteColumn("sort",ColType.Integer)
            };

            lineageTable.Columns = columns;

            return HelperFactory.CreateHelper().CreateTable(lineageTable) > 0;
        }

        public static bool CreateTextValueTable()
        {
            SQLiteTable commonSettingTable = new SQLiteTable("sz_text_value");
            SQLiteColumnList columns = new SQLiteColumnList()
            {
                new SQLiteColumn("id",ColType.Integer,true,true,true,"0"),
                new SQLiteColumn("key",ColType.Text),
                new SQLiteColumn("type",ColType.Text),
                new SQLiteColumn("subType",ColType.Text),
                new SQLiteColumn("text",ColType.Text),
                new SQLiteColumn("value",ColType.Text),
                new SQLiteColumn("sort",ColType.Integer)
            };

            commonSettingTable.Columns = columns;

            return HelperFactory.CreateHelper().CreateTable(commonSettingTable) > 0;
        }

        public static bool CreateVolumeTable()
        {
            SQLiteTable volumeTable = new SQLiteTable("zp_volume");
            SQLiteColumnList columns = new SQLiteColumnList()
            {
                new SQLiteColumn("id",ColType.Integer,true,true,true,"0"),
                new SQLiteColumn("name",ColType.Text),
                new SQLiteColumn("sort",ColType.Integer),
                new SQLiteColumn("startIndex",ColType.Integer),
                new SQLiteColumn("needCatalogue",ColType.Boolean),
                new SQLiteColumn("needCheatSheets",ColType.Boolean)
            };

            volumeTable.Columns = columns;

            return HelperFactory.CreateHelper().CreateTable(volumeTable) > 0;
        }
    }
}
