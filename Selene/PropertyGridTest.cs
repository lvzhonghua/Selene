using Selene.Model.SettingModel.Book.HFStyle;
using Selene.UIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene
{
    public partial class PropertyGridTest : Form
    {
        public PropertyGridTest()
        {
            InitializeComponent();
        }

        private void PropertyGridTest_Load(object sender, EventArgs e)
        {

            this.propertyGrid1.SelectedObject = PropertyGridUtil.GetObject<HFStyleTradition>();
            
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            var gi = e.NewSelection;
            
        }
    }

    
}
