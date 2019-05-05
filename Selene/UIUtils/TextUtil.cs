using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.UIUtils
{
    public class TextUtil
    {
        public static RectangleF MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new RectangleF();
            }
            StringFormat format = new StringFormat();
            RectangleF rect = new RectangleF(0, 0, 1000, 1000);
            var ranges = new CharacterRange(0, text.Length);
            Region[] regions = new Region[1];

            format.SetMeasurableCharacterRanges(new CharacterRange[] { ranges });

            regions = graphics.MeasureCharacterRanges(text, font, rect, format);
            rect = regions[0].GetBounds(graphics);

            return rect;
        }
    }
}
