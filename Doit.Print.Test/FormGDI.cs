using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Doit.UI;

namespace Doit.Print.Test
{
    public partial class FormGDI : Form
    {
        private List<Node> nodes = new List<Node>();
        private LayoutManager layoutManager = new LayoutManager();
        private Node selectedNode = null;
       
        public FormGDI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.panZoomAndMove.MouseWheel += this.panGDI_MouseWheel;

            this.nodes.Add(new Node 
            { 
                BackColor = Color.Red, 
                Font = new Font("宋体", 20f),
                ForeColor = Color.Blue, 
                Location = new PointF(100f,100f), 
                Name = "Node1", 
                Text = "Node 1" 
            }) ;

            this.nodes.Add(new Node
            {
                BackColor = Color.Green,
                Font = new Font("宋体", 12f),
                ForeColor = Color.White,
                Location = new PointF(150f, 150f),
                Name = "Node2",
                Text = "Node 2"
            });            
        }

        private void Draw(Graphics graphics)
        {
            //graphics.Clear(this.panGDI.BackColor);

            this.layoutManager.UpdateLayout(graphics);

            foreach (var node in this.nodes)
            {
                node.Draw(graphics);

                node.UpdateDisplay(this.layoutManager.Offset, this.layoutManager.Scale);
            }

            this.lblInfo.Text = $"Scale：{this.layoutManager.Scale} Offset：X = {this.layoutManager.Offset.X} Y = {this.layoutManager.Offset.Y}";
        }

        private void panGDI_Paint(object sender, PaintEventArgs e)
        {
            this.Draw(e.Graphics);
        }

        private void panGDI_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (this.selectedNode == null)
            {
                this.layoutManager.CurrentMousePosition = Control.MousePosition;
            }
            else
            {
                this.selectedNode.Location = new PointF()
                {
                    X = (e.Location.X - this.layoutManager.Offset.X) / this.layoutManager.Scale,
                    Y = (e.Location.Y - this.layoutManager.Offset.Y) / this.layoutManager.Scale
                };
            }

            this.panZoomAndMove.Refresh();
        }

        private void panGDI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (this.selectedNode == null)
            {
                this.layoutManager.LastMousePosition = Control.MousePosition;
            }
            else
            {
            }
        }

        private void panGDI_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    if (this.selectedNode != null) this.selectedNode = null;
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void panGDI_MouseWheel(object sender, MouseEventArgs e)
        {
            float newScale = this.layoutManager.Scale + 0.001f * e.Delta;
            if (newScale < 0.1f || newScale > 5f) return;

            this.layoutManager.Scale = newScale;
            this.panZoomAndMove.Refresh();
        }

        private void panGDI_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            this.selectedNode = this.GetSelectedNode(e.Location);
            this.pGridSelected.SelectedObject = this.selectedNode;
        }

        private Node GetSelectedNode(PointF point)
        {
            Node selectedNode = null;

            foreach (Node node in this.nodes)
            {
                if (node.ContainPointF(point) == true)
                {
                    selectedNode = node;
                    break;
                }
            }

            return selectedNode;
        }

        private class Node
        {
            [DisplayName("背景色"), Description("节点的背景色")]
            public Color BackColor { get; set; } = Color.Blue;

            [DisplayName("前景色"), Description("节点的前景色")]
            public Color ForeColor { get; set; } = Color.White;

            [DisplayName("字体"), Description("节点的文字的字体")]
            public Font Font { get; set; } = new Font("宋体",10);

            [DisplayName("名称"),Description("节点的名称")]
            public string Name { get; set; }
            
            [DisplayName("文字"),Description("显示的文字")]
            public string Text { get; set; }

            [DisplayName("边界"), Description("节点的边界")]
            public RectangleF Bounds { get; set; }

            [DisplayName("位置"), Description("节点的位置")]
            public PointF Location { get; set; }

            [DisplayName("呈现边界"), Description("节点的呈现边界")]
            public RectangleF DisplayBounds { get; set; } = RectangleF.Empty;

            public void Draw(Graphics graphics)
            {
                SizeF textSize = graphics.MeasureString(this.Text, this.Font);

                this.Bounds = new RectangleF(this.Location, textSize);

                Doit.UI.GDIHelper.FillRoundRectangleWithText(graphics, this.Bounds, this.Text, this.Font, this.BackColor, this.ForeColor, 2, 4, 5, true);
            }

            public void UpdateDisplay(PointF offset, float scale)
            {
                this.DisplayBounds = new RectangleF()
                {
                    X = this.Bounds.X * scale + offset.X,
                    Y = this.Bounds.Y * scale + offset.Y,
                    Width = this.Bounds.Width * scale,
                    Height = this.Bounds.Height * scale
                };
            }

            public bool ContainPointF(PointF point)
            {
                return this.DisplayBounds.Contains(point);
            }
        }

        private class LayoutManager
        {
            private Point lastMousePosition = Point.Empty;

            public Point LastMousePosition 
            {
                get { return this.lastMousePosition; }
                set { this.lastMousePosition = value; }
            }

            private Point currentMousePosition = Point.Empty;

            public Point CurrentMousePosition
            {
                get { return this.currentMousePosition; }
                set { this.currentMousePosition = value; }
            }

            private float scale = 1.0f;

            public float Scale
            {
                get { return this.scale; }
                set { this.scale = value; }
            }

            private PointF offset = PointF.Empty;

            public PointF Offset 
            {
                get { return this.offset; }
            }

            private bool layoutChanged = false;

            public bool LayoutChange 
            { 
                get { return this.layoutChanged; }
            }

            public void UpdateLayout(Graphics graphics)
            {
                if (this.layoutChanged == true)
                {
                    this.layoutChanged = false;
                }

                this.DrawGraph(graphics, PointF.Empty);
            }

            public void DrawGraph(Graphics graphics,  PointF graphMousePosition)
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                this.offset.X = this.currentMousePosition.X - this.lastMousePosition.X;
                this.offset.Y = this.currentMousePosition.Y - this.lastMousePosition.Y;

                graphics.Transform = new System.Drawing.Drawing2D.Matrix(this.scale, 0.0f, 0.0f, this.scale, this.offset.X, this.offset.Y);
            }
        }

        private void pGridSelected_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.panZoomAndMove.Refresh();
        }

        private void MeasureCharacterRangesRegions1(PaintEventArgs e)
        {
            string measureString = "第一 and 第二 ranges";
            Font stringFont = new Font("Times New Roman", 16.0F);

            CharacterRange[] characterRanges = { new CharacterRange(0, 2), new CharacterRange(7, 2) };

            float x = 10.0F;
            float y = 10.0F;
            float width = 35.0F;
            float height = 200.0F;
            RectangleF layoutRect = new RectangleF(x, y, width, height);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            stringFormat.SetMeasurableCharacterRanges(characterRanges);

            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, x, y, stringFormat);

            Region[] stringRegions = e.Graphics.MeasureCharacterRanges(measureString, stringFont, layoutRect, stringFormat);

            RectangleF measureRect1 = stringRegions[0].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), Rectangle.Round(measureRect1));

            RectangleF measureRect2 = stringRegions[1].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), Rectangle.Round(measureRect2));
        }

        private void MeasureCharacterRangesRegions2(PaintEventArgs e)
        {
            string measureString = "复利才是高利润的基础";
            Font stringFont = new Font("宋体",26.0F);

            CharacterRange[] characterRanges = { new CharacterRange(0, 2), new CharacterRange(4, 3), new CharacterRange(8, 2) };

            float x = 100.0F;
            float y = 100.0F;
            float width = 1000F;
            float height = 500F;
            RectangleF layoutRect = new RectangleF(x, y, width, height);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            stringFormat.SetMeasurableCharacterRanges(characterRanges);

            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, x, y, stringFormat);

            Region[] stringRegions = e.Graphics.MeasureCharacterRanges(measureString, stringFont, layoutRect, stringFormat);

            RectangleF measureRect1 = stringRegions[0].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Red, 2), Rectangle.Round(measureRect1));

            RectangleF measureRect2 = stringRegions[1].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 2), Rectangle.Round(measureRect2));

            RectangleF measureRect3 = stringRegions[2].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Green, 2), Rectangle.Round(measureRect3));
        }

        private void DrawALineOfText(PaintEventArgs e)
        {
            string[] stringsToPaint = { "Tail", "编程序", " Toys" };

            Font[] fonts = { new Font("Arial", 14, FontStyle.Regular), new Font("华文中宋", 24, FontStyle.Italic), new Font("Arial", 14, FontStyle.Regular) };

            Point startPoint = new Point(100, 20);

            TextFormatFlags flags = TextFormatFlags.NoPadding;

            Size proposedSize = new Size(int.MaxValue, int.MaxValue);

            for (int index = 0; index < stringsToPaint.Length; index++)
            {
                Size size = TextRenderer.MeasureText(e.Graphics, stringsToPaint[index],  fonts[index], proposedSize, flags);
                Rectangle rect = new Rectangle(startPoint, size);
                TextRenderer.DrawText(e.Graphics, stringsToPaint[index], fonts[index], startPoint, Color.Black, flags);
                startPoint.X += size.Width;
            }
        }

        private void MeasureStringMin(PaintEventArgs e)
        {
            string measureString = "Measure String 1 2 3";
            Font stringFont = new Font("Arial", 50);

            SizeF stringSize = e.Graphics.MeasureString(measureString, stringFont);

            PointF position = new PointF(100,150);

            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), position.X, position.Y, stringSize.Width, stringSize.Height);

            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, position);
        }

        private void DrawStringFloatFormat(PaintEventArgs e)
        {
            String drawString = "Sample是简单的意思。123 & ! = : ：,，; ；";

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            PointF point = new PointF(800.0f,10.0f);

            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            SizeF size = e.Graphics.MeasureString(drawString, drawFont, point, drawFormat);

            RectangleF rect = new RectangleF(point, size);

            e.Graphics.DrawString(drawString, drawFont, drawBrush, rect, drawFormat);
            e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(rect));
        }

        private void DrawStringRotated(PaintEventArgs e)
        {
            String drawString = "斜着绘制的文字";

            Font drawFont = new Font("宋体", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            PointF point = new PointF(300.0f, 100.0f);

            SizeF size = e.Graphics.MeasureString(drawString, drawFont);

            RectangleF rect = new RectangleF(point, size);

            e.Graphics.TranslateTransform(point.X, point.Y);
            e.Graphics.RotateTransform(30f);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, rect);
            e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(rect));
            e.Graphics.RotateTransform(-30f);
            e.Graphics.TranslateTransform(-point.X, -point.Y);
        }

        private void DrawStringOnPath(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Point[] myArray =
            {
                new Point(100, 400),
                new Point(180, 575),
                new Point(160, 425),
                new Point(280, 400),
                new Point(300, 510),
                new Point(220, 450),
                new Point(600, 600),
                new Point(650, 550),
                new Point(800, 500),
                new Point(950, 550)
            };

            GraphicsPath myPath = new GraphicsPath();
            myPath.AddBeziers(myArray);

            Pen myPen = new Pen(Color.Blue, 1);
            e.Graphics.DrawPath(myPen, myPath);

            RectangleF[] regions = e.Graphics.MeasureString("一定要实现 Text on Path (文字沿着路径渲染)，我做到了",
                                                                                new Font(FontFamily.GenericSerif, 24), 
                                                                                new SolidBrush(Color.Red), 
                                                                                TextPathAlign.Center, 
                                                                                TextPathPosition.CenterPath, 
                                                                                100, 
                                                                                0, 
                                                                                myPath);
            foreach (var region in regions)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.GreenYellow), region);
            }
            e.Graphics.DrawString("一定要实现 Text on Path (文字沿着路径渲染)，我做到了", 
                                            new Font(FontFamily.GenericSerif, 24), 
                                            new SolidBrush(Color.Red),
                                            TextPathAlign.Center, 
                                            TextPathPosition.CenterPath, 
                                            100,
                                            0, 
                                            myPath);
        }

        private void panString_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            this.MeasureCharacterRangesRegions1(e);
            this.MeasureCharacterRangesRegions2(e);
            this.DrawALineOfText(e);
            this.MeasureStringMin(e);
            this.DrawStringFloatFormat(e);
            this.DrawStringRotated(e);
            this.DrawStringOnPath(e);
        }
    }

}
