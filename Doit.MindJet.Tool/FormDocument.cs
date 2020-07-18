using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doit.MindJet.Tool
{
    public partial class FormDocument : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private MindTree mindTree = new MindTree();

        public MindTree MindTree { get { return this.mindTree; } }

        private TextBox txtInput = new TextBox() { Multiline = true };

        public FormDocument()
        {
            InitializeComponent();
        }

        private void InitTestData()
        {
            MindNode root = new MindNode() { Text = "微软公司", Level = 0 };

            this.mindTree.AddNode(root);

            MindNode usa = new MindNode() { Text = "美国总部" };
            MindNode global_YJ = new MindNode() { Text = "研究院" };
            MindNode global_DV = new MindNode() { Text = "工程院" };
            MindNode ocean = new MindNode() { Text = "亚太总部" };

            MindNode china = new MindNode() { Text = "中国公司" };
            MindNode china_RD = new MindNode() { Text = "研发中心" };
            MindNode china_COM = new MindNode() { Text = "微软中国" };
            china_COM.Expanded = false;

            MindNode china_DSZ = new MindNode() { Text = "董事长" };
            MindNode china_CEO = new MindNode() { Text = "CEO" };
            MindNode china_CTO = new MindNode() { Text = "首席技术官" };
            MindNode ocean_YJ = new MindNode() { Text = "亚洲研究院" };
            MindNode ocean_DV = new MindNode() { Text = "亚洲工程院" };
            MindNode china_TK = new MindNode() { Text = "技术支持中心" };
            MindNode china_TK_01 = new MindNode() { Text = "客服部" };
            MindNode china_TK_02 = new MindNode() { Text = "技术部" };
            MindNode china_TK_03 = new MindNode() { Text = "推广部" };
            MindNode china_TK_04 = new MindNode() { Text = "关系部" };

            MindNode jp = new MindNode() { Text = "日本公司" };
            MindNode jp_BZ = new MindNode() { Text = "商务中心" };
            MindNode jp_YF = new MindNode() { Text = "研发中心" };

            this.mindTree.AddNode(root, usa);
            this.mindTree.AddNode(usa, global_YJ);
            this.mindTree.AddNode(usa, global_DV);

            this.mindTree.AddNode(root, ocean);
            this.mindTree.AddNode(ocean, china);
            this.mindTree.AddNode(china, china_RD);
            this.mindTree.AddNode(china, china_COM);
            this.mindTree.AddNode(china_COM, china_DSZ);
            this.mindTree.AddNode(china_COM, china_CEO);
            this.mindTree.AddNode(china_COM, china_CTO);
            this.mindTree.AddNode(china, ocean_YJ);
            this.mindTree.AddNode(china, ocean_DV);
            this.mindTree.AddNode(china, china_TK);
            this.mindTree.AddNode(china_TK, china_TK_01);
            this.mindTree.AddNode(china_TK, china_TK_02);
            this.mindTree.AddNode(china_TK, china_TK_03);
            this.mindTree.AddNode(china_TK, china_TK_04);

            this.mindTree.AddNode(ocean, jp);
            this.mindTree.AddNode(jp, jp_BZ);
            this.mindTree.AddNode(jp, jp_YF);
        }

        private void FormDocument_Load(object sender, EventArgs e)
        {
            this.InitTestData();

            this.txtInput.TextChanged += TxtInput_TextChanged;
            this.txtInput.LostFocus += TxtInput_LostFocus;
        }

        private void TxtInput_LostFocus(object sender, EventArgs e)
        {
            this.panMindTree.Controls.Remove(this.txtInput);

            this.panMindTree.Refresh();
        }

        private void TxtInput_TextChanged(object sender, EventArgs e)
        {
            SizeF size = this.CreateGraphics().MeasureString(this.txtInput.Text, this.txtInput.Font);
            this.txtInput.Size = Size.Round(size);

            if (this.mindTree.SelectedNode != null)
            {
                this.mindTree.SelectedNode.Text = this.txtInput.Text;
            }
        }

        private void panMindTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            this.mindTree.Draw(e.Graphics);
        }

        private void panMindTree_MouseClick(object sender, MouseEventArgs e)
        {
            this.panMindTree.Controls.Remove(this.txtInput);

            if (e.Button != MouseButtons.Left) return;
            RightLinker rightLinker = this.mindTree.GetGlyphBeHit(e.Location) as RightLinker;
            if (rightLinker == null) return;
            rightLinker.Node.Expanded = !rightLinker.Node.Expanded;
            this.panMindTree.Refresh();
        }

        private void panMindTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            MindNode nodeBeHit = this.mindTree.GetNodeBeHit(e.Location);
            if (nodeBeHit == null) return;
            nodeBeHit.Status = GlyphStatus.Selected;
            this.mindTree.SelectedNode = nodeBeHit;

            this.txtInput.Location = new Point((int)nodeBeHit.Location.X + 2,(int)nodeBeHit.Location.Y + 2);
            this.txtInput.Text = nodeBeHit.Text;
            this.txtInput.Font = StyleSchema.CurrentSchema.TextFont;
            this.txtInput.BorderStyle = BorderStyle.None;
            this.txtInput.Size = new Size((int)nodeBeHit.Bounds.Width - 4, (int)nodeBeHit.Bounds.Height - 4);

            this.panMindTree.Controls.Add(this.txtInput);

            this.panMindTree.Refresh();
        }

        private void panMindTree_MouseMove(object sender, MouseEventArgs e)
        {
            MindNode nodeBeHit = this.mindTree.GetNodeBeHit(e.Location);
            if (nodeBeHit == null) return;
            if(nodeBeHit.Status != GlyphStatus.Selected) nodeBeHit.Status = GlyphStatus.Current;

            this.panMindTree.Refresh();
        }

    }
}
