using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Doit.MindJet.Linkers;

namespace Doit.MindJet.MindFlows
{
    /// <summary>
    /// 合并步骤
    /// </summary>
    class MergeStep : MindStep
    {
        /// <summary>
        /// 右侧三角形
        /// </summary>
        protected GraphicsPath rightTriangle;

        public Linker RightLinker { get; protected set; } = new MindStepLinker() { Radius = StyleSchema.CurrentSchema.LinkerRadius };

        /// <summary>
        /// 左侧矩形集合
        /// </summary>
        protected List<RectangleF> leftRects = new List<RectangleF>();

        /// <summary>
        /// 左侧节点集合
        /// </summary>
        public List<Linker> LeftLinkers { get; protected set; } = new List<Linker>();

        public MergeStep()
        {
            this.Category = MindStepCategory.Merge;
            this.Text = "合并";

            this.LeftLinkers.Add(new MindStepLinker() { Parent = this, Radius = StyleSchema.CurrentSchema.LinkerRadius } );
            this.LeftLinkers.Add(new MindStepLinker() { Parent = this, Radius = StyleSchema.CurrentSchema.LinkerRadius });
        }
    }
}
