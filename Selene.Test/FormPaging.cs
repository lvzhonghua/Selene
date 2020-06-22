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
    public partial class FormPaging : Form
    {
        private static FormPaging instance;
        public static FormPaging Instance
        {
            get 
            {
                if (instance == null || instance.IsDisposed) instance = new FormPaging();
                return instance;
            }
        }

        private FormPaging()
        {
            InitializeComponent();
        }
    }
}
