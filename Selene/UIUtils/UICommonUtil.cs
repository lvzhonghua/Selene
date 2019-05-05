using Selene.BaseControl;
using Selene.Logical;
using Selene.Logical.Message;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.UIUtils
{
   public class UICommonUtil
    {
        //检测生子信息
        public static bool CheckBirthBody(DataRichTextBox richTextBox)
        {
            bool result = true;
            var content = richTextBox.Text;

            int currSelectionStart = richTextBox.SelectionStart;

            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = Color.Transparent;

            
            CommonBLLMessage.GenealogyChildren.ToList().ForEach(checkBody =>
            {
                CheckBirthResult birthResult = GenealogyNoteResolve.CheckBirth(content, checkBody);
                if (!birthResult.Legal)
                {
                    richTextBox.Select(content.IndexOf(birthResult.BodyInfo), birthResult.BodyInfo.Length);
                    richTextBox.SelectionBackColor = Color.Red;
                    
                    result = false;
                }
            });

            richTextBox.Select(currSelectionStart, 0);

            return result;
        }

        public static void MessageBoxShow(string content,string title="炎黄谱业")
        {
            MessageBox.Show(content, title);
        }
    }
}
