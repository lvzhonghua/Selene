using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

using Doit.Print.Models;

namespace Doit.Print.Controls
{
    public partial class CellStyleDesignerCtrl: UserControl
    {
        private string assemblyFileName = "";

        private Type currentTypeOfAssociated = null;
        private CellStyle currentCellStyle = null;

        public CellStyleDesignerCtrl()
        {
            InitializeComponent();
        }

        private void btnLoadAssembly_Click(object sender, EventArgs e)
        {
            this.assemblyFileName = Doit.UI.UIHelper.GetOpenFileName(this.assemblyFileName, "Dll文件(*.dll)|*.dll");
            if (string.IsNullOrEmpty(this.assemblyFileName)) return;

            List<Type> typesOfAssociated = AssemblyAnalyzer.GetTypesAssociatedByCellStyle(this.assemblyFileName);

            this.ListTypesOfAssociated(typesOfAssociated);
        }

        private void ListTypesOfAssociated(List<Type> types)
        {
            this.tvTypeList.Nodes.Clear();

            foreach (Type type in types)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                TreeNode nodeType = this.tvTypeList.Nodes.Add(type.Name);
                nodeType.ImageKey = nodeType.SelectedImageKey = "类型_16.png";
                nodeType.Tag = type;

                foreach (PropertyInfo propertyInfo in typeInfo.DeclaredProperties)
                {
                    string info = $"{propertyInfo.Name} : {propertyInfo.PropertyType.Name}";
                    TreeNode nodeProperty = nodeType.Nodes.Add(info);
                    nodeProperty.Tag = propertyInfo;

                    switch (propertyInfo.PropertyType.Name.ToLower())
                    {
                        case "int32":
                        case "double":
                        case "single":
                        case "long":
                            nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "数字_16.png";
                            break;
                        case "string":
                            nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "字符串_16.png";
                            break;
                        case "datetime":
                            nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "日期_16.png";
                            break;
                        default:
                            nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "成员_16.png";
                            break;
                    }

                }
            }
            
        }

        private void tvTypeAssociate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Type typeOfAssociated = null;
            if (e.Node.Level == 0) typeOfAssociated = e.Node.Tag as Type;

            if (e.Node.Level == 1) typeOfAssociated = e.Node.Parent.Tag as Type;

            if (typeOfAssociated == null) return;

            this.pGridAssociate.SelectedObject = Activator.CreateInstance(typeOfAssociated);
        }

        private void tvTypeList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode tvNode = e.Item as TreeNode;
            if (tvNode == null) return;
            if (tvNode.Level != 0) return;
            Type type = tvNode.Tag as Type;
            if (type == null) return;

            this.tvTypeList.DoDragDrop(type, DragDropEffects.Copy);
        }

        private void ListProperies(Type typeToAssociated)
        {
            this.tvTypeToAssociated.Nodes.Clear();

            TypeInfo typeInfo = typeToAssociated.GetTypeInfo();
            foreach (PropertyInfo propertyInfo in typeInfo.DeclaredProperties)
            {
                string info = $"{propertyInfo.Name} : {propertyInfo.PropertyType.Name}";
                TreeNode nodeProperty = this.tvTypeToAssociated.Nodes.Add(info);
                nodeProperty.Tag = propertyInfo;

                switch (propertyInfo.PropertyType.Name.ToLower())
                {
                    case "int32":
                    case "double":
                    case "single":
                    case "long":
                        nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "数字_48.png";
                        break;
                    case "string":
                        nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "字符串_48.png";
                        break;
                    case "datetime":
                        nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "日期_48.png";
                        break;
                    default:
                        nodeProperty.ImageKey = nodeProperty.SelectedImageKey = "成员_48.png";
                        break;
                }

            }
        }

        private void lblTypeToAssociated_DragDrop(object sender, DragEventArgs e)
        {
            this.lblTypeToAssociated.BackColor = SystemColors.ControlDark;
            Type typeToAssociated = e.Data.GetData(e.Data.GetFormats()[0]) as Type;
            if (typeToAssociated == null) return;
            this.lblTypeToAssociated.Text = $"要关联的类型({typeToAssociated.Name})";

            this.ListProperies(typeToAssociated);

            this.currentTypeOfAssociated = typeToAssociated;
            this.currentCellStyle = new CellStyle();
            this.currentCellStyle.AssociateType = this.currentTypeOfAssociated;
        }

        private void lblTypeToAssociated_DragEnter(object sender, DragEventArgs e)
        {
            Type typeToAssociated = e.Data.GetData(e.Data.GetFormats()[0]) as Type;
            if (typeToAssociated == null) return;

            e.Effect = DragDropEffects.Copy;
        }

        private void lblTypeToAssociated_DragLeave(object sender, EventArgs e)
        {
            this.lblTypeToAssociated.BackColor = SystemColors.ControlDark;
        }

        private void lblTypeToAssociated_DragOver(object sender, DragEventArgs e)
        {
            this.lblTypeToAssociated.BackColor = Color.Red;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            if (this.PopMessageOfNullCellStyle() == false) return;

            this.panDesigner.Cursor = Cursors.Cross;
        }

        private bool PopMessageOfNullCellStyle()
        {
            if (this.currentCellStyle == null)
            {
                MessageBox.Show("未关联单元格类型，无法进行此操作。","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void tvTypeToAssociated_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode tvNode = e.Item as TreeNode;
            if (tvNode == null) return;
            if (tvNode.Level != 0) return;
            PropertyInfo propertyInfo = tvNode.Tag as PropertyInfo;
            if (propertyInfo == null) return;

            this.tvTypeToAssociated.DoDragDrop(propertyInfo, DragDropEffects.Copy);
        }

        private void panDesigner_DragDrop(object sender, DragEventArgs e)
        {
            this.panDesigner.BackColor = Color.White;

            PropertyInfo propertyInfo = e.Data.GetData(e.Data.GetFormats()[0]) as PropertyInfo;
            if (propertyInfo == null) return;

            this.panDesigner.Cursor = Cursors.Default;

            for (int index = this.tvTypeToAssociated.Nodes.Count - 1; index >= 0; index--)
            {
                PropertyInfo propertyInfoTemp = this.tvTypeToAssociated.Nodes[index].Tag as PropertyInfo;
                if (propertyInfoTemp == null) continue;

                if (propertyInfoTemp.Name == propertyInfo.Name)
                {
                    this.tvTypeToAssociated.Nodes.RemoveAt(index);
                    break;
                }
            }
        }

        private void panDesigner_DragEnter(object sender, DragEventArgs e)
        {
            PropertyInfo propertyInfo = e.Data.GetData(e.Data.GetFormats()[0]) as PropertyInfo;
            if (propertyInfo == null) return;

            e.Effect = DragDropEffects.Copy;

        }

        private void panDesigner_DragLeave(object sender, EventArgs e)
        {
            this.panDesigner.BackColor = Color.White;
        }

        private void panDesigner_DragOver(object sender, DragEventArgs e)
        {
            this.panDesigner.BackColor = SystemColors.Control;
        }
    }
}
