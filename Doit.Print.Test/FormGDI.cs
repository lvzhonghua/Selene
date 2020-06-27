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
        private Node selectedNode = null;
       
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

            this.panGDI.Refresh();
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
            this.panGDI.Refresh();
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
            this.panGDI.Refresh();
        }
    }

}
