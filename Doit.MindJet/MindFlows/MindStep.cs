using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 思维流程步骤
    /// </summary>
    public abstract class MindStep : Glyph
    {
        /// <summary>
        /// 文字所在的矩形
        /// </summary>
        protected RectangleF rectOfText = Rectangle.Empty;

        /// <summary>
        /// 所属的思维流程
        /// </summary>
        public MindFlow Flow { get; set; }

        /// <summary>
        /// 步骤类别
        /// </summary>
        public MindStepCategory Category { get; set; }

    }
}
