using Selene.Draw.CalcStruct;
using Selene.Draw.Enums;
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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            BlockContainer bc = new BlockContainer();
            bc.Graphics = plMain.CreateGraphics();
            bc.Graphics.Clear(Color.Gray);
            bc.DrawAreaLine = true;
            bc.Location = new PointF(50,50);
            bc.SizeF = new SizeF(plMain.Width-101, plMain.Height-101);
            bc.Draw();

            BlockContainer bc1 = new BlockContainer();
            bc1.Align = Align.RightMiddle;
            bc1.SizeF = new SizeF(200, 200);
            bc1.Border = new Border(10, 20, 30, 40);
            bc1.Margin = new Draw.CalcStruct.Margin(10,20,30,40);
            bc1.Padding = new Draw.CalcStruct.Padding(10, 20, 30, 40);
            bc1.Parent = bc;
            bc1.DrawAreaLine = true;
            bc1.Draw();


            Block block = new Block();
            block.Parent = bc1;
            block.Location = new PointF(30, 30);
            block.TextAlign = Align.LeftMiddle;
            block.Padding = new Draw.CalcStruct.Padding() { Left = 10 };
            block.SizeF = new SizeF(100, 100);
            block.Text = "程欢";
            block.DrawAreaLine = true;
            block.Draw();
        }
    }
}
