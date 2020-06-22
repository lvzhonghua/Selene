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
    public partial class FormLineage : Form
    {
        private static FormLineage instance;

        public static FormLineage Instance
        {
            get 
            {
                if (instance == null || instance.IsDisposed) instance = new FormLineage();

                return instance;
            }
        }

        private FormLineage()
        {
            InitializeComponent();
        }
    }
}
