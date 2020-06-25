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
    public partial class FormGDI : Form
    {
        private List<Node> nodes = new List<Node>();
        private LayoutManager layoutManager = new LayoutManager();
        private Point lastMousePosition = Point.Empty;

        public FormGDI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.panGDI.MouseWheel += this.panGDI_MouseWheel;

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

            this.layoutManager.Offset = new PointF(e.X - this.lastMousePosition.X, e.Y - this.lastMousePosition.Y);

            this.panGDI.Invalidate();
        }

        private void panGDI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            this.lastMousePosition = e.Location;
        }

        private void panGDI_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            this.lastMousePosition = e.Location;
        }

        private void panGDI_MouseWheel(object sender, MouseEventArgs e)
        {
            float newScale = this.layoutManager.Scale + 0.001f * e.Delta;
            if (newScale < 0.1f || newScale > 5f) return;

            this.layoutManager.Scale = newScale;
            this.panGDI.Invalidate();
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

            public void Draw(Graphics graphics)
            {
                SizeF textSize = graphics.MeasureString(this.Text, this.Font);

                this.Bounds = new RectangleF(this.Location, textSize);

                Doit.UI.GDIHelper.FillRoundRectangleWithText(graphics, this.Bounds, this.Text, this.Font, this.BackColor, this.ForeColor, 2, 4, 5, true);
            }
        }

        private class LayoutManager
        {
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
                set { this.offset = value; }
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
                graphics.Transform = new System.Drawing.Drawing2D.Matrix(this.scale, 0.0f, 0.0f, this.scale, this.offset.X, this.offset.Y);
            }
        }

    }

}
