using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 分支步骤
    /// </summary>
    class SplitStep : MindStep
    {
        public SplitStep()
        {
            this.Category = MindStepCategory.Split;
            this.Text = "拆分";
        }
    }
}
