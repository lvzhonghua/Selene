using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Doit.MindJet.Commands;

namespace Doit.MindJet.Tool
{
    public partial class FormDocument : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        /// <summary>
        /// 脑图
        /// </summary>
        public MindTree MindTree { get { return this.mindTreeCtrl.MindTree; } }

        /// <summary>
        /// 指令栈
        /// </summary>
        public CommandStack CommandStack { get { return this.mindTreeCtrl.CommandStack; } }

        public FormDocument()
        {
            InitializeComponent();
        }

    }
}
