﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Doit.MindJet.Linkers;
using Doit.MindJet.MindTrees;
using Doit.MindJet.Commands;
using Doit.MindJet.Commands.MindTrees;

namespace Doit.MindJet.Controls
{
    public partial class MindTreeCtrl : UserControl
    {
        private MindTree mindTree = new MindTree();

        private string oldTextOfNode = string.Empty;
        /// <summary>
        /// 脑图
        /// </summary>
        public MindTree MindTree { get { return this.mindTree; } }

        private CommandStack commandStack = new CommandStack();

        /// <summary>
        /// 指令栈
        /// </summary>
        public CommandStack CommandStack { get { return this.commandStack; } }

        private TextBox txtInput = new TextBox() { Multiline = true };
        public MindTreeCtrl()
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

        private void MindTreeCtrl_Load(object sender, EventArgs e)
        {
            this.InitTestData();

            this.txtInput.GotFocus += TxtInput_GotFocus;
            this.txtInput.TextChanged += TxtInput_TextChanged;
            this.txtInput.LostFocus += TxtInput_LostFocus;
        }

        private void TxtInput_GotFocus(object sender, EventArgs e)
        {
            this.txtInput.SelectAll();
        }

        private void TxtInput_LostFocus(object sender, EventArgs e)
        {  
            this.panMindTree.Controls.Remove(this.txtInput);

            NodeTextModifyCommand modifyCommand = new NodeTextModifyCommand(this.mindTree.SelectedNode, this.oldTextOfNode, this.txtInput.Text);
            this.commandStack.AppendAndExecute(modifyCommand);

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
            this.mindTree.Draw(e.Graphics);
        }

        private void panMindTree_MouseClick(object sender, MouseEventArgs e)
        {
            this.panMindTree.Controls.Remove(this.txtInput);

            MindNode mindNode = null;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    Glyph glyph = this.mindTree.GetGlyphBeHit(e.Location);
                    if (glyph is Linker)
                    {
                        Linker linker = glyph as Linker;
                        mindNode = linker.Parent as MindNode;
                        if (linker is MindNodeRightLinker)
                        {
                            mindNode.Expanded = !mindNode.Expanded;
                            this.panMindTree.Refresh();
                        }
                        if (linker is MindNodeLeftLinker) this.contextMenuDo.Show(this.panMindTree, new Point((int)mindNode.Bounds.Right, (int)mindNode.Bounds.Top));
                    }
                    break;
                case MouseButtons.Right:
                    mindNode = this.mindTree.GetNodeBeHit(e.Location);
                    if (mindNode != null)
                    {
                        this.contextMenuDo.Show(this.panMindTree, new Point((int)mindNode.Bounds.Right, (int)mindNode.Bounds.Top));
                    }
                    else
                    {
                        this.contextMenuUndo.Show(this.panMindTree, e.Location);
                    }
                    break;
            }

            if (mindNode == null) return;
            mindNode.Status = GlyphStatus.Selected;
            this.mindTree.SelectedNode = mindNode;
        }

        private void panMindTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            MindNode nodeBeHit = this.mindTree.GetNodeBeHit(e.Location);
            if (nodeBeHit == null) return;
            nodeBeHit.Status = GlyphStatus.Selected;
            this.mindTree.SelectedNode = nodeBeHit;
            this.oldTextOfNode = this.mindTree.SelectedNode.Text;

            this.txtInput.Location = new Point((int)nodeBeHit.Location.X + 2, (int)nodeBeHit.Location.Y + 2);
            this.txtInput.Text = nodeBeHit.Text;
            this.txtInput.Font = StyleSchema.CurrentSchema.TextFont;
            this.txtInput.BorderStyle = BorderStyle.None;
            this.txtInput.Size = new Size((int)nodeBeHit.Bounds.Width - 4, (int)nodeBeHit.Bounds.Height - 4);
            this.panMindTree.Controls.Add(this.txtInput);
            this.txtInput.Focus();

            this.panMindTree.Refresh();
        }

        private void panMindTree_MouseMove(object sender, MouseEventArgs e)
        {
            MindNode nodeBeHit = this.mindTree.GetNodeBeHit(e.Location);
            if (nodeBeHit == null) return;
            if (nodeBeHit.Status != GlyphStatus.Selected) nodeBeHit.Status = GlyphStatus.Current;

            this.panMindTree.Refresh();
        }

        private void menuAddSubNode_Click(object sender, EventArgs e)
        {
            if (this.mindTree.SelectedNode == null) return;

            MindNode mindNode = new MindNode() { Text = "新增节点" };

            NodeAddCommand addCommand = new NodeAddCommand(this.mindTree.SelectedNode, mindNode);
            this.commandStack.AppendAndExecute(addCommand);

            this.panMindTree.Refresh();
        }

        private void menuAddNode_Click(object sender, EventArgs e)
        {
            if (this.mindTree.SelectedNode == null) return;
            if (this.mindTree.SelectedNode.Parent == null) return;

            MindNode mindNode = new MindNode() { Text = "新增节点" };

            NodeAddCommand addCommand = new NodeAddCommand(this.mindTree.SelectedNode.Parent, mindNode);
            this.commandStack.AppendAndExecute(addCommand);

            this.panMindTree.Refresh();
        }

        private void menuDeleteNode_Click(object sender, EventArgs e)
        {
            if (this.mindTree.SelectedNode == null) return;
            if (this.mindTree.SelectedNode.Parent == null) return;

            if (this.mindTree.SelectedNode.Nodes.Count > 0)
            {
                DialogResult dlgResult = MessageBox.Show("确定要删除选定的节点吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No) return;
            }

            NodeRemoveCommand removeCommand = new NodeRemoveCommand(this.mindTree.SelectedNode.Parent,
                                                                                                                                   this.mindTree.SelectedNode);
            this.commandStack.AppendAndExecute(removeCommand);

            this.mindTree.SelectedNode = null;

            this.panMindTree.Refresh();
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            this.commandStack.Undo();

            this.panMindTree.Refresh();
        }

        private void menuRedo_Click(object sender, EventArgs e)
        {
            this.commandStack.Redo();

            this.panMindTree.Refresh();
        }

        private void menuClearCommandStack_Click(object sender, EventArgs e)
        {
            this.commandStack.Clear();
        }
    }
}
