using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.Enums
{
    public enum ContainsRegion
    {
        None = 0,
        Top = 2,
        Left = 4,
        Bottom = 8,
        Right = 16,
        LeftTop = 6,
        LeftBottom = 12,
        RightBottom = 24,
        RightTop = 18,
        LeftTopRight = 22,
        LeftTopBottom = 14,
        LeftBottomRight = 28,
        RightTopBottom = 26,
        All = 30
    }
}
