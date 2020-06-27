using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doit.Print.Test
{
    public partial class FormGEO : Form
    {
        private Font currentFont = new Font("宋体",12f);
        public FormGEO()
        {
            InitializeComponent();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = this.currentFont;

            if (fontDlg.ShowDialog() != DialogResult.OK) return;

            this.currentFont = fontDlg.Font;
            this.txtContent.Font = this.currentFont;
            this.btnFont.Text = $"字体({this.currentFont.Name},{this.currentFont.Size},{this.currentFont.Style})";
        }

        private void FormGEO_Load(object sender, EventArgs e)
        {
            this.txtContent.Font = this.currentFont;
            this.btnFont.Text = $"字体({this.currentFont.Name},{this.currentFont.Size},{this.currentFont.Style})";

            this.tbar_Scroll(null, null);
        }

        private void DrawContent(Graphics graphics)
        {  
            int width = int.Parse(this.txtWidth.Text.Trim());
            int height = int.Parse(this.txtHeight.Text.Trim());

            int x = 40;
            int y = 40;

            Point A = Point.Empty;
            Point B = Point.Empty;

            Pen penOfSize = new Pen(Color.Blue, 1f);
            //绘制宽度标识
            A = new Point(x,y - 25);
            B = new Point(x,y - 5);
            graphics.DrawLine(penOfSize, A, B);

            A = new Point(x + width, y - 25);
            B = new Point(x + width, y - 5);
            graphics.DrawLine(penOfSize, A, B);

            penOfSize.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            A = new Point(x, y - 15);
            B = new Point(x + width, y - 15);
            graphics.DrawLine(penOfSize, A, B);

            Font font = new Font("宋体",12f);
            int spacing = 4;
            SizeF sizeOfWidthValue = graphics.MeasureString(width.ToString(), font);
            RectangleF rectOfWidthValue = new RectangleF();
            rectOfWidthValue.Width = sizeOfWidthValue.Width + spacing * 2;
            rectOfWidthValue.Height = sizeOfWidthValue.Height + spacing * 2;
            rectOfWidthValue.X = x + (width - rectOfWidthValue.Width) / 2;
            rectOfWidthValue.Y = y - spacing - rectOfWidthValue.Height;
            Doit.UI.GDIHelper.FillRoundRectangleWithText(graphics, rectOfWidthValue, width.ToString(), font, Color.Blue, Color.White, spacing, spacing,5, true);

            //绘制高度标识
            penOfSize.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            A = new Point(x - 25, y);
            B = new Point(x - 5, y);
            graphics.DrawLine(penOfSize, A, B);

            A = new Point(x - 25, y + height);
            B = new Point(x - 5, y + height);
            graphics.DrawLine(penOfSize, A, B);

            penOfSize.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            A = new Point(x - 15, y);
            B = new Point(x - 15, y + height);
            graphics.DrawLine(penOfSize, A, B);

            SizeF sizeOfHeightValue = graphics.MeasureString(height.ToString(), font);
            RectangleF rectOfHeightValue = new RectangleF();
            rectOfHeightValue.Width = sizeOfHeightValue.Width + spacing * 2;
            rectOfHeightValue.Height = sizeOfHeightValue.Height + spacing * 2;
            rectOfHeightValue.X =  (height - rectOfHeightValue.Width) / 2;
            rectOfHeightValue.Y = y - spacing - rectOfHeightValue.Height;

            graphics.TranslateTransform(0, y + height);
            graphics.RotateTransform(-90f);
            Doit.UI.GDIHelper.FillRoundRectangleWithText(graphics, rectOfHeightValue, height.ToString(), font, Color.Blue, Color.White, spacing, spacing, 5, true);
            graphics.RotateTransform(90f);
            graphics.TranslateTransform(-0, - (y + height));

            //绘制外框
            Rectangle rectContent = new Rectangle(x,y,width,height);
            Pen penOfRectangle = new Pen(Color.Gray,1f);
            penOfRectangle.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(penOfRectangle, rectContent);
        }

        private void tbar_Scroll(object sender, EventArgs e)
        {
            this.lblException.Text = "";

            this.txtWidth.Text = (this.tbarWidth.Value * 5).ToString();
            this.txtHeight.Text = (this.tbarHeight.Value * 5).ToString();

            int width = int.Parse(this.txtWidth.Text.Trim());
            int height = int.Parse(this.txtHeight.Text.Trim());

            this.panGDI.Width = (this.panContainer.Width >= (20 + width + 20)) ? this.panContainer.Width : (20 + width + 20);
            this.panGDI.Height = (this.panContainer.Height >= (20 + height + 20)) ? this.panContainer.Height : (20 + height + 20);

            this.panGDI.Refresh();
        }

        private void panGDI_Paint(object sender, PaintEventArgs e)
        {
            this.DrawContent(e.Graphics);
        }
    }
}
