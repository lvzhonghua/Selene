using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 思维步骤工厂
    /// </summary>
    public class MindStepFactory
    {
        public static MindStep Create(MindStepCategory stepCategory, PointF location)
        {
            MindStep mindStep = Create(stepCategory);
            mindStep.Location = location;

            return mindStep;
        }

        /// <summary>
        /// 创建方法
        /// </summary>
        /// <param name="stepCategory">思维步骤类别</param>
        /// <returns>思维步骤</returns>
        public static MindStep Create(MindStepCategory stepCategory)
        {
            MindStep mindStep = null;

            switch (stepCategory)
            {
                default:
                case MindStepCategory.Normal:
                    mindStep = new NormalStep();
                    break;
                case MindStepCategory.Start:
                    mindStep = new StartStep();
                    break;
                case MindStepCategory.End:
                    mindStep = new EndStep();
                    break;
                case MindStepCategory.Judge:
                    mindStep = new JudgeStep();
                    break;
                case MindStepCategory.Split:
                    mindStep = new SplitStep();
                    break;
                case MindStepCategory.Merge:
                    mindStep = new MergeStep();
                    break;
            }

            return mindStep;
        }
    }
}
