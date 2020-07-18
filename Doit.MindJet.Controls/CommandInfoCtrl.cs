using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Doit.MindJet.Commands;

namespace Doit.MindJet.Controls
{
    public partial class CommandInfoCtrl: UserControl
    {
        private ICommand command;

        /// <summary>
        /// 指令
        /// </summary>
        public ICommand Command 
        {
            get { return this.command; }
            set 
            {
                this.command = value;
                if (this.command == null)
                {
                    this.picImage.Image = null;
                    this.lblDescription.Text = "";
                    this.lblExecuteTime.Text = "";
                }
                else
                {
                    this.picImage.Image = this.command.Image;
                    this.lblDescription.Text = this.command.Description;
                    this.lblExecuteTime.Text = this.command.ExecuteTime.ToLongTimeString();
                }
            }
        }
        public CommandInfoCtrl()
        {
            InitializeComponent();
        }
    }
}
