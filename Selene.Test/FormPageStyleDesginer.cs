using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Test
{
    public partial class FormPageStyleDesginer : Form
    {
        private static FormPageStyleDesginer instance;

        public static FormPageStyleDesginer Instance
        {
            get 
            {
                if (instance == null || instance.IsDisposed) instance = new FormPageStyleDesginer();
                return instance;
            }
        }
        private FormPageStyleDesginer()
        {
            InitializeComponent();
        }
    }
}
