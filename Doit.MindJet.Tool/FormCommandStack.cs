using Doit.MindJet.Commands;
using Doit.MindJet.Controls;
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
    public partial class FormCommandStack : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        /// <summary>
        /// 指令栈
        /// </summary>
        public CommandStack CommandStack 
        {
            get { return this.commandStackInfoCtrl.CommandStack; }
            set 
            {
                this.commandStackInfoCtrl.CommandStack = value;
            }
        }

        public FormCommandStack()
        {
            InitializeComponent();
        }
    }
}
