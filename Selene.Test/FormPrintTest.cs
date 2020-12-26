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
    public partial class FormPrintTest : Form
    {
        private Font fontPrint = new Font("宋体",20f,FontStyle.Italic);

        public FormPrintTest()
        {
            InitializeComponent();
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = this.fontPrint;

            if (fontDlg.ShowDialog() != DialogResult.OK) return;

            this.fontPrint = fontDlg.Font;

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            previewDlg.Document = this.printDoc;
            previewDlg.Width = 800;
            previewDlg.Height = 600;
            previewDlg.ShowDialog();
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("哈哈，😄",new Font("宋体",50f),Brushes.Blue, 10,10);

            e.Graphics.DrawString("我是水印", new Font("黑体", 200f), new SolidBrush(Color.FromArgb(50, 0, 0,255)), 50, 200);

            e.Graphics.DrawCurve(Pens.Green,
                                             new Point[] {
                                                 new Point(0, 10),
                                                 new Point(100, 18),
                                                 new Point(200, 10),
                                                 new Point(300, 18),
                                                 new Point(400, 10),
                                                 new Point(500, 18),
                                                 new Point(600, 10) });

            e.Graphics.DrawString(this.txtTest.Text.Trim(), this.fontPrint, Brushes.Red, new PointF(10f, 50f));
        }
    }
}
