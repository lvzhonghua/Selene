using Selene.BaseControl;
using Selene.Forms.PartVolume.PartVolumeManage;
using Selene.Logical;
using Selene.Logical.Message;
using Selene.Logical.Utils;
using Selene.Logical.ViewModel;
using Selene.Providers;
using Selene.UIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Forms.GenealogyInfo
{
    public partial class ClansmanAddForm : DataFormBase
    {
        private ClansmanBLL clansmanBLL;
        private VolumeProvider volumeProvider;

        public ClansmanAddForm()
        {
            InitializeComponent();

            new GenealogyNoteKeyHandler(this.rtxtGenealogyNote, this.cbkNumberToChina, this.cbkWriteSpace);

            clansmanBLL = new ClansmanBLL();
            volumeProvider = new VolumeProvider();
        }

        private void GenealogyAddForm_Load(object sender, EventArgs e)
        {
            InitFormProperty();

            InitFamilyTree();

            dcboVolume.DataSource = volumeProvider.GetDataList();
            dcboPartVolumeParent.DataSource = volumeProvider.GetDataList();

            //TreeViewExpand(15);
        }

        public void ReloadFamilyTree()
        {
            InitFamilyTree();
            //原来的展开格式和选择样式


            //TreeViewExpand(15);
        }

        #region 初始化树控件
        private void InitFamilyTree()
        {
            tvFamily.Nodes.Clear();

            var clansmanTreeList = clansmanBLL.GetAllTreeList();
            List<TreeNode> treeNodeList = new List<TreeNode>();

            TreeNode treeNode = null;
            foreach (var clansmanTree in clansmanTreeList)
            {
                treeNode = new TreeNode();
                treeNode.Text = clansmanTree.Name + string.Format("【第{0}世】", clansmanTree.RelativeWorldNumber);
                treeNode.Tag = clansmanTree;
                treeNode.Expand();

                treeNodeList.Add(treeNode);

                RecursionTreeNode(treeNode, clansmanTree.Childrens);
            }

            tvFamily.Nodes.AddRange(treeNodeList.ToArray());
        }

        private void RecursionTreeNode(TreeNode parentTreeNode, List<ClansmanTree> clansmanTreeList)
        {
            if (clansmanTreeList == null || clansmanTreeList.Count() == 0)
            {
                return;
            }
            TreeNode treeNode = null;
            foreach (var clansmanTree in clansmanTreeList)
            {
                treeNode = new TreeNode();
                treeNode.Text = clansmanTree.Name + string.Format("【第{0}世】", clansmanTree.RelativeWorldNumber);
                treeNode.Tag = clansmanTree;
                treeNode.Expand();

                parentTreeNode.Nodes.Add(treeNode);

                RecursionTreeNode(treeNode, clansmanTree.Childrens);
            }
        }
        #endregion


        private void InitFormProperty()
        {
            this.WindowState = FormWindowState.Maximized;
            this.rtxtGenealogyNote.AcceptsTab = true;
        }

        private void TreeViewExpand(int hierarchy)
        {
            if (hierarchy == 0)
            {
                this.tvFamily.CollapseAll();
            }
            int index = 1;

            TreeNodeCollection treeNodes = this.tvFamily.Nodes;
            while (index < hierarchy && treeNodes != null && treeNodes.Count > 0)
            {
                TreeNodeCollection childrenTreeNodes = null;
                foreach (TreeNode treeNode in treeNodes)
                {
                    treeNode.Expand();

                    if (childrenTreeNodes == null)
                    {
                        childrenTreeNodes = treeNode.Nodes;
                    }
                    else
                    {
                        TreeNode[] dest = new TreeNode[treeNode.Nodes.Count];
                        treeNode.Nodes.CopyTo(dest, 0);
                        childrenTreeNodes.AddRange(dest);
                    }
                    treeNodes = childrenTreeNodes;
                }
                index++;
            }
        }

        private void rtxtGenealogyNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.rtxtGenealogyNote.AppendText("※");
                if (SaveClansman())
                {
                    this.rtxtGenealogyNote.Clear();
                    ReloadFamilyTree();
                }
                e.Handled = true;
            }
        }

        private bool SaveClansman()
        {
            string genealogyNote = this.rtxtGenealogyNote.Text;
            if (string.IsNullOrEmpty(genealogyNote))
            {
                return false;
            }

            ReturnMessage rm = clansmanBLL.SaveClansman(this.rtxtGenealogyNote.Text);
            if (!rm.Ok)
            {
                UICommonUtil.MessageBoxShow(rm.Message);
            }
            return rm.Ok;
        }

        protected override bool ProcessTabKey(bool forward)
        {
            return false;
        }

        private void rtxtGenealogyNote_TextChanged(object sender, EventArgs e)
        {
            UICommonUtil.CheckBirthBody(this.rtxtGenealogyNote);
        }


        private void tvFamily_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenClansmanDetailedForm(e.Node);
        }

        private void tvFamily_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ClansmanTree clansmanTree = (ClansmanTree)e.Node.Tag;
            this.txtGenealogyNoteSel.Text = clansmanTree.GenealogyNote;
        }

        private void cbShowWorldNumber_CheckedChanged(object sender, EventArgs e)
        {
            EditTreeNodeTextByWorldNumber();
        }

        private void EditTreeNodeTextByWorldNumber()
        {
            List<TreeNode> treeNodeList = new List<TreeNode>();
            GetAllTreeNode(this.tvFamily.Nodes, treeNodeList);

            foreach (var treeNode in treeNodeList)
            {
                ClansmanTree clansmanTree = (ClansmanTree)treeNode.Tag;
                if (cbShowWorldNumber.Checked)
                {
                    treeNode.Text = clansmanTree.Name + string.Format("【第{0}世】", clansmanTree.RelativeWorldNumber);
                }
                else
                {
                    treeNode.Text = clansmanTree.Name;
                }
            }
        }

        private void GetAllTreeNode(TreeNodeCollection treeNodeCollection, List<TreeNode> treeNodeList)
        {
            if (treeNodeCollection == null || treeNodeCollection.Count == 0)
            {
                return;
            }
            foreach (TreeNode treeNode in treeNodeCollection)
            {
                treeNodeList.Add(treeNode);

                GetAllTreeNode(treeNode.Nodes, treeNodeList);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tvFamily.SelectedNode == null)
            {
                UICommonUtil.MessageBoxShow("请先选择要修改的记录");
                return;
            }
            OpenClansmanDetailedForm(tvFamily.SelectedNode);
        }

        private void OpenClansmanDetailedForm(TreeNode treeNode)
        {
            ClansmanTree clansmanTree = treeNode.Tag as ClansmanTree;

            ClansmanDetailedForm clansmanDetailedForm = new ClansmanDetailedForm(clansmanTree);
            clansmanDetailedForm.SetGenealogyAddForm(this);
            clansmanDetailedForm.ShowDialog();
        }

        private void btnPartVolumeManage_Click(object sender, EventArgs e)
        {
            PartVolumeManageForm partVolumeManageForm = new PartVolumeManageForm();
            partVolumeManageForm.ShowDialog();
        }
    }
}
