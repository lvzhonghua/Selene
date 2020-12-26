using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Selene.Test
{
    public class TestDrawPanel : Panel
    {
        public TestDrawPanel()
        {
            //使控件支持双缓冲，方便高性能的绘制图形
            this.SetStyle(ControlStyles.DoubleBuffer |
                   ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.UserPaint |
                   ControlStyles.AllPaintingInWmPaint,
                   true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //开启绘图板的抗锯齿效果
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            base.OnPaint(e);
        }
    }
}
