using System;
using System.Drawing;
using System.Windows.Forms;

using Doit.Print.Models;

namespace Doit.Print.Test
{
    public partial class FormGEO : Form
    {
        private Font currentFont = new Font("宋体",12f);
        private SizeF sizeOfContent = SizeF.Empty;

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

            this.panGDI.Refresh();
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

            int x = 40;
            int y = 40;

            //绘制外框
            string content = this.txtContent.Text.Trim();
            int height = (int)Doit.UI.GEOHelper.GetContentHeightOnFixedWidth(graphics, content, this.currentFont, width);
            Rectangle rectContent = new Rectangle(x,y,width, (int)height);
            Pen penOfRectangle = new Pen(Color.Gray,1f);
            penOfRectangle.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(penOfRectangle, rectContent);
            //绘制文字
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.Character;
            graphics.DrawString(content, this.currentFont, Brushes.Gray, rectContent,format);
            
            this.sizeOfContent = graphics.MeasureString(content, this.currentFont,width);
            this.lblContentInfo.Text = $"要显示的内容：(w:{this.sizeOfContent.Width} h:{this.sizeOfContent.Height})";

            //绘制宽度标识
            Point A = Point.Empty;
            Point B = Point.Empty;

            Pen penOfSize = new Pen(Color.Blue, 1f);

            A = new Point(x, y - 25);
            B = new Point(x, y - 5);
            graphics.DrawLine(penOfSize, A, B);

            A = new Point(x + width, y - 25);
            B = new Point(x + width, y - 5);
            graphics.DrawLine(penOfSize, A, B);

            penOfSize.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            A = new Point(x, y - 15);
            B = new Point(x + width, y - 15);
            graphics.DrawLine(penOfSize, A, B);

            Font font = new Font("宋体", 12f);
            int spacing = 4;
            SizeF sizeOfWidthValue = graphics.MeasureString(width.ToString(), font);
            RectangleF rectOfWidthValue = new RectangleF();
            rectOfWidthValue.Width = sizeOfWidthValue.Width + spacing * 2;
            rectOfWidthValue.Height = sizeOfWidthValue.Height + spacing * 2;
            rectOfWidthValue.X = x + (width - rectOfWidthValue.Width) / 2;
            rectOfWidthValue.Y = y - spacing - rectOfWidthValue.Height;
            Doit.UI.GDIHelper.FillRoundRectangleWithText(graphics, rectOfWidthValue, width.ToString(), font, Color.Blue, Color.White, spacing, spacing, 5, true);

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
            rectOfHeightValue.X = (height - rectOfHeightValue.Width) / 2;
            rectOfHeightValue.Y = y - spacing - rectOfHeightValue.Height;

            graphics.TranslateTransform(0, y + height);
            graphics.RotateTransform(-90f);
            Doit.UI.GDIHelper.FillRoundRectangleWithText(graphics, rectOfHeightValue, height.ToString(), font, Color.Blue, Color.White, spacing, spacing, 5, true);
            graphics.RotateTransform(90f);
            graphics.TranslateTransform(-0, -(y + height));

            //绘制箭头
            penOfSize.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            A = new Point(x, y - 15);
            B = new Point(x + 5, y - 10);
            graphics.DrawLine(penOfSize, A, B);

            B = new Point(x + 5, y - 20);
            graphics.DrawLine(penOfSize, A, B);

            A = new Point(x + width , y - 15);
            B = new Point(x + width - 5, y - 10);
            graphics.DrawLine(penOfSize, A, B);

            B = new Point(x + width - 5, y - 20);
            graphics.DrawLine(penOfSize, A, B);

            A = new Point(x - 15, y);
            B = new Point(x - 10, y + 5);
            graphics.DrawLine(penOfSize, A, B);

            B = new Point(x - 20, y + 5);
            graphics.DrawLine(penOfSize, A, B);

            A = new Point(x - 15, y + height);
            B = new Point(x - 10, y + height - 5);
            graphics.DrawLine(penOfSize, A, B);

            B = new Point(x - 20, y + height - 5);
            graphics.DrawLine(penOfSize, A, B);


            this.panGDI.Height = (this.panContainer.Height >= (20 + height + 20)) ? this.panContainer.Height : (20 + height + 20);
        }

        private void tbar_Scroll(object sender, EventArgs e)
        {
            this.txtWidth.Text = (this.tbarWidth.Value * 5).ToString();

            int width = int.Parse(this.txtWidth.Text.Trim());
            int height = int.Parse(this.txtWidth.Text.Trim());

            this.panGDI.Width = (this.panContainer.Width >= (20 + width + 20)) ? this.panContainer.Width : (20 + width + 20);
            this.panGDI.Height = (this.panContainer.Height >= (20 + height + 20)) ? this.panContainer.Height : (20 + height + 20);

            this.panGDI.Refresh();
        }

        private void panGDI_Paint(object sender, PaintEventArgs e)
        {
            this.DrawContent(e.Graphics);
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            this.panGDI.Refresh();
        }

        private void btnFontSelect_Click(object sender, EventArgs e)
        {
            TextDisassemblyResult disassemblyResult = TextDisassembly.Disassembly(null, this.txtTextContent.Text, 0, null);

        }
    }
}
