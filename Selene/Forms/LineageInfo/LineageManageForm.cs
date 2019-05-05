using Selene.Logical;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms.LineageInfo
{
    public partial class LineageManageForm : Form
    {
        private LineageBLL lineageBLL;

        public LineageManageForm()
        {
            InitializeComponent();

            lineageBLL = new LineageBLL();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LineageManageForm_Load(object sender, EventArgs e)
        {
            LoadLineageListView();
        }

        public void LoadLineageListView()
        {
            lvLineage.Items.Clear();

            var lineages = lineageBLL.GetLineages();

            int index = 0;
            var listViewItems = lineages.Select(lineage =>
            {
                ListViewItem item = new ListViewItem();
                item.Tag = lineage;
                item.Text = (++index).ToString();
                item.SubItems.Add(lineage.AncestorWroldNumberName);
                item.SubItems.Add(lineage.EdgeTitle);
                item.SubItems.Add(lineage.TopTitle);
                item.SubItems.Add("");
                item.SubItems.Add(lineage.WorldNumberPrefix);
                item.SubItems.Add(lineage.WorldNumberSuffix);

                return item;
            }).ToArray();

            lvLineage.Items.AddRange(listViewItems);
        }

        private void btnInsertLineage_Click(object sender, EventArgs e)
        {
            InsertLineageForm insertLineageForm = new InsertLineageForm();
            insertLineageForm.ShowDialog();
        }

        private void lvLineage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvLineage.SelectedItems.Count <= 0)
            {
                return;
            }
            Lineage lineage = lvLineage.SelectedItems[0].Tag as Lineage;

            EditLineageForm editLineageForm = new EditLineageForm(lineage);
            editLineageForm.SetLineageManageForm(this);
            editLineageForm.ShowDialog();
        }
    }
}
