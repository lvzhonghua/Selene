using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doit.Print.Test
{
    public class PanelGDI : Panel
    {
        public PanelGDI()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | 
                               ControlStyles.OptimizedDoubleBuffer |
                               ControlStyles.UserPaint |
                               ControlStyles.AllPaintingInWmPaint,
                               true);
        }
    }
}
