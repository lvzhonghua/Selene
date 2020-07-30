using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Doit.MindJet.MindDrafts
{
    public class MindDraft : Glyph
    {
        public MindShapeConnection TempConnection { get; set; } = null;
        private List<MindShapeConnection> connections = new List<MindShapeConnection>();
        public List<MindShapeConnection> Connections { get { return this.connections; } }

        public void AddConnection(MindShapeConnection shapeConnection)
        {
            this.connections.Add(shapeConnection);
        }

        private List<MindShape> shapes = new List<MindShape>();

        public List<MindShape> Shapes { get { return this.shapes; } }

        public void AddShape(MindShape shape)
        {
            this.shapes.Add(shape);
        }

        public void RemoveShape(MindShape shape)
        {
            this.Shapes.Remove(shape);
        }

        public override void Draw(Graphics graphics)
        {
            foreach (var shape in this.shapes)
            {
                shape.Draw(graphics);
            }

            foreach (var connection in this.connections)
            {
                connection.Draw(graphics);
            }

            if (this.TempConnection != null)
            {
                this.TempConnection.Draw(graphics);
                if (this.TempConnection.To != null) this.TempConnection.To.Draw(graphics);
            }
        }

        public override Glyph HitTest(PointF point)
        {
            Glyph glyph = null;

            foreach (var shape in this.shapes)
            {
                shape.Status = GlyphStatus.Normal;
                glyph = shape.HitTest(point);
                if (glyph != null) break;
            }

            return glyph;
        }
    }
}
