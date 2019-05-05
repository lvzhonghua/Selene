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

namespace Selene.Forms.Tools
{
    public partial class CopyGenealogySettingForm : Form
    {
        DBListItem currentDbListItem;
        public CopyGenealogySettingForm(DBListItem currentDbListItem)
        {
            InitializeComponent();

            this.currentDbListItem = currentDbListItem;
        }

        private void CopyGenealogySettingForm_Load(object sender, EventArgs e)
        {
            lbGenealogy.DisplayMember = "Name";
            lbGenealogy.ValueMember = "Path";
            lbGenealogy.DataSource = GetGenealogyList();
        }

        private List<DBListItem> GetGenealogyList()
        {
            string[] dbs = Directory.GetFiles(CommonMessage.data_path, "*.db");

            return dbs.Where(db => !db.Equals(currentDbListItem.Path)).Select(db => { return new DBListItem(db); }).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
