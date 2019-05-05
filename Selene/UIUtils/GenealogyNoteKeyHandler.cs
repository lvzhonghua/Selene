using Selene.BaseControl;
using Selene.Logical.Message;
using Selene.Logical.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.UIUtils
{
    public class GenealogyNoteKeyHandler
    {
        private CheckBox cbkNumberToChina;

        private CheckBox cbkWriteSpace;

        private DataRichTextBox richTextBox;

        public GenealogyNoteKeyHandler(DataRichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;

            BindEvent();
        }
        public GenealogyNoteKeyHandler(DataRichTextBox richTextBox, CheckBox cbkNumberToChina, CheckBox cbkWriteSpace)
        {
            this.richTextBox = richTextBox;
            this.cbkNumberToChina = cbkNumberToChina;
            this.cbkWriteSpace = cbkWriteSpace;

            BindEvent();
        }

        private void BindEvent()
        {
            richTextBox.KeyPress += richTextBox_KeyPress;
        }

        void richTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (this.cbkNumberToChina!=null&&cbkNumberToChina.Checked)
            {
                int num = 0;
                if (int.TryParse(e.KeyChar.ToString(), out num))
                {
                    this.richTextBox.AppendText(CommonUtil.NumberToChina(num));
                    e.Handled = true;
                }
            }
            if (this.cbkWriteSpace!=null&&cbkWriteSpace.Checked)
            {
                if (e.KeyChar == 32 || e.KeyChar == 9)
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == 44)
            {
                this.richTextBox.AppendText(CommonBLLMessage.Comma);
                e.Handled = true;
            }   
        }
    }
}
