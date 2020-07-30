using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindDrafts
{
    public class MindShapeFactory
    {
        public static MindShape Create(MindShapeCategory shapeCategory, PointF location)
        {
            MindShape mindShape = Create(shapeCategory);
            mindShape.Location = location;

            return mindShape;
        }

        public static MindShape Create(MindShapeCategory shapeCategory)
        {
            MindShape mindShape = null;

            switch (shapeCategory)
            {
                default:
                case MindShapeCategory.Rect:
                    mindShape = new RectShape();
                    break;
                case MindShapeCategory.Rhomb:
                    mindShape = new RhombShape();
                    break;
                case MindShapeCategory.Temp:
                    mindShape = new TempShape();
                    break;
            }

            return mindShape;
        }
    }
}
