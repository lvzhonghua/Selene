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

        public List<MindShapeLinker> Linkers { get; protected set; } = new List<MindShapeLinker>();
    }
}
