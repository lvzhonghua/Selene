using Selene.Logical;
using Selene.Manage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms
{
    public partial class DBToolForm : Form
    {
        public DBToolForm()
        {
            InitializeComponent();
        }

        private void DBTool_Load(object sender, EventArgs e)
        {
            lbDBInfo.DisplayMember = "name";
            lbDBInfo.ValueMember = "path";
            lbDBInfo.DataSource = GetLocalDBInfo();
            
        }

        private List<DBListItem> GetLocalDBInfo()
        {
            string[] dbs = Directory.GetFiles(CommonMessage.data_path, "*.db");
            
            return dbs.Select(db => { return new DBListItem(db); }).ToList();
        }

        private void lbDBInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path=lbDBInfo.SelectedValue.ToString();
            List<string> tables=DBManage.GetAllTables(path);

            lbTableInfo.DataSource = tables;
        }

        private void lbTableInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = lbTableInfo.SelectedValue.ToString();
            string path = lbDBInfo.SelectedValue.ToString();
            dgvMain.DataSource = null;
            dgvMain.DataSource=DBManage.GetDataTable(path, tableName);
        }

    }

    public class DBListItem
    {
        public DBListItem() { }
        public DBListItem(string path) {
            this.Path = path;
            FileInfo fileInfo=new FileInfo(path);
            this.Name = fileInfo.Name.Replace(".db","");
        }

        public string Path { get; set; }

        public string Name { get; set; }
    }
}
