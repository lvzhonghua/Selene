using Doit.MindJet.Linkers;
using Doit.MindJet.MindFlows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindDrafts
{
    public abstract class MindShape : Glyph
    {
        protected RectangleF rectOfText = Rectangle.Empty;

        public ShapePadding Padding { get; set; } = new ShapePadding();

        public MindDraft Draft { get; set; }

        public MindShapeCategory Category { get; set; }

        public MindShapeLinker LeftLinker { get; set; } = new MindShapeLinker();

        public MindShapeLinker TopLinker { get; set; } = new MindShapeLinker();

        public MindShapeLinker RightLinker { get; set; } = new MindShapeLinker();

        public MindShapeLinker BottomLinker { get; set; } = new MindShapeLinker();

        public override Glyph HitTest(PointF point)
        {
            Glyph beHit = null;

            beHit = this.LeftLinker.HitTest(point);
            if (beHit != null) return beHit;

            beHit = this.TopLinker.HitTest(point);
            if (beHit != null) return beHit;

            beHit = this.RightLinker.HitTest(point);
            if (beHit != null) return beHit;

            beHit = this.BottomLinker.HitTest(point);
            if (beHit != null) return beHit;

            if (this.Bounds.Contains(point)) beHit = this;

            return beHit;
        }

    }
}
