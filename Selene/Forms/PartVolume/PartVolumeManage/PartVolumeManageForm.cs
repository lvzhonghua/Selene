using Selene.BaseControl;
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

namespace Selene.Forms.PartVolume.PartVolumeManage
{
    public partial class PartVolumeManageForm : FormBase
    {
        private VolumeBLL volumeBLL;

        public PartVolumeManageForm()
        {
            InitializeComponent();

            volumeBLL = new VolumeBLL();
        }

        private void btnAddPartVolume_Click(object sender, EventArgs e)
        {
            PartVolumeDetailedForm partVolumeDetailedForm = new PartVolumeDetailedForm();
            partVolumeDetailedForm.SetVolumeManageForm(this);
            partVolumeDetailedForm.ShowDialog();
        }

        private void PartVolumeManageForm_Load(object sender, EventArgs e)
        {
            ReloadDataSource();
        }

        private void btnEditPartVolume_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }


        private void ShowEditForm()
        {
            if (lvPartVolume.SelectedItems.Count != 0)
            {
                ListViewItem selectItem = lvPartVolume.SelectedItems[0];
                var volume = selectItem.Tag as Volume;

                PartVolumeDetailedForm partVolumeDetailedForm = new PartVolumeDetailedForm();
                partVolumeDetailedForm.SetVolumeManageForm(this);
                partVolumeDetailedForm.SetVolume(volume);
                partVolumeDetailedForm.ShowDialog();
            }
        }

        public void ReloadDataSource()
        {
            lvPartVolume.Items.Clear();

            var volumes = volumeBLL.GetVolumes();


            var items = volumes.Select(volume =>
            {
                var item = new ListViewItem();
                item.Tag = volume;
                item.Text = volume.Name;
                item.SubItems.Add(volume.StartIndex.ToString());
                item.SubItems.Add(volume.NeedCatalogue ? "是" : "否");
                item.SubItems.Add(volume.NeedCheatSheets ? "是" : "否");

                return item;
            }).ToArray();


            lvPartVolume.Items.AddRange(items);
        }

        private void lvPartVolume_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowEditForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeletePartVolume_Click(object sender, EventArgs e)
        {
            if (lvPartVolume.SelectedItems.Count != 0)
            {
                ListViewItem selectItem = lvPartVolume.SelectedItems[0];
                var volume = selectItem.Tag as Volume;

                if (volumeBLL.DeleteVolume(volume))
                {
                    ReloadDataSource();
                }
            }
        }

        public int GetVolumeSumCount()
        {
            return lvPartVolume.Items.Count;
        }

        private void btnUpMove_Click(object sender, EventArgs e)
        {
            if (this.lvPartVolume.SelectedItems.Count <= 0)
            {
                return;
            }
            var currentSel = this.lvPartVolume.SelectedItems[0];
            var currentIndex = currentSel.Index;
            if (currentIndex == 0)
            {
                return;
            }
            var upItem = this.lvPartVolume.Items[--currentIndex];

            var currentVolume = currentSel.Tag as Volume;
            var upVolume = upItem.Tag as Volume;

            int oldSort = currentVolume.Sort;
            currentVolume.Sort = upVolume.Sort;
            upVolume.Sort = oldSort;

            if (volumeBLL.UpdateVolume(currentVolume) && volumeBLL.UpdateVolume(upVolume))
            {
                ReloadDataSource();
            }
        }

        private void btnDownMove_Click(object sender, EventArgs e)
        {
            if (this.lvPartVolume.SelectedItems.Count <= 0)
            {
                return;
            }
            var currentSel = this.lvPartVolume.SelectedItems[0];
            var currentIndex = currentSel.Index;
            if (currentIndex == this.lvPartVolume.Items.Count-1)
            {
                return;
            }
            var downItem = this.lvPartVolume.Items[++currentIndex];

            var currentVolume = currentSel.Tag as Volume;
            var downVolume = downItem.Tag as Volume;

            int oldSort = currentVolume.Sort;
            currentVolume.Sort = downVolume.Sort;
            downVolume.Sort = oldSort;

            if (volumeBLL.UpdateVolume(currentVolume) && volumeBLL.UpdateVolume(downVolume))
            {
                ReloadDataSource();
            }
        }
    }
}
