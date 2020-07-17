﻿using System;
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
        private MindTree tree = new MindTree();

        public FormDocument()
        {
            InitializeComponent();
        }

        private void InitTestData()
        {
            MindNode root = new MindNode() { Text = "微软公司", Level = 0 };

            this.tree.AddNode(root);

            MindNode usa = new MindNode() { Text = "美国总部" };
            MindNode global_YJ = new MindNode() { Text = "研究院" };
            MindNode global_DV = new MindNode() { Text = "工程院" };
            MindNode ocean = new MindNode() { Text = "亚太总部" };

            MindNode china = new MindNode() { Text = "中国公司" };
            MindNode china_RD = new MindNode() { Text = "研发中心" };
            MindNode china_COM = new MindNode() { Text = "微软中国" };
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

            this.tree.AddNode(root, usa);
            this.tree.AddNode(usa, global_YJ);
            this.tree.AddNode(usa, global_DV);

            this.tree.AddNode(root, ocean);
            this.tree.AddNode(ocean, china);
            this.tree.AddNode(china, china_RD);
            this.tree.AddNode(china, china_COM);
            this.tree.AddNode(china_COM, china_DSZ);
            this.tree.AddNode(china_COM, china_CEO);
            this.tree.AddNode(china_COM, china_CTO);
            this.tree.AddNode(china, ocean_YJ);
            this.tree.AddNode(china, ocean_DV);
            this.tree.AddNode(china, china_TK);
            this.tree.AddNode(china_TK, china_TK_01);
            this.tree.AddNode(china_TK, china_TK_02);
            this.tree.AddNode(china_TK, china_TK_03);
            this.tree.AddNode(china_TK, china_TK_04);

            this.tree.AddNode(ocean, jp);
            this.tree.AddNode(jp, jp_BZ);
            this.tree.AddNode(jp, jp_YF);
        }

        private void FormDocument_Load(object sender, EventArgs e)
        {
            this.InitTestData();
        }

        private void panMindTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            this.tree.Draw(e.Graphics);
        }

        private void ListTree()
        {
            this.tvTest.Nodes.Clear();

            foreach (var node in this.tree.Nodes)
            {
                TreeNode tvNode = this.tvTest.Nodes.Add($"{node.Text} - {node.Level}");
                tvNode.Tag = node;
                this.ListNodes(tvNode, node);
            }

            this.tvTest.ExpandAll();
        }

        private void ListNodes(TreeNode tvNode, MindNode node)
        {
            foreach (var subNode in node.Nodes)
            {
                TreeNode tvSubNode = tvNode.Nodes.Add($"{subNode.Name} - {subNode.Level}");
                tvSubNode.Tag = subNode;

                this.ListNodes(tvSubNode, subNode);
            }
        }
    }
}
