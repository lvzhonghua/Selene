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
    public partial class FormTestDrawPanel : Form
    {
        public FormTestDrawPanel()
        {
            InitializeComponent();
        }

        private void testDrawPanel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.FillRectangle(Brushes.Red,10, 10, this.testDrawPanel1.Width - 10 * 2, this.testDrawPanel1.Height - 10 * 2);
        }

        private void testDrawPanel1_SizeChanged(object sender, EventArgs e)
        {
            this.testDrawPanel1.Invalidate();
        }
    }
}
