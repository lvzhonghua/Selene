using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw.CalcStruct
{
    public class BlockContainer : BaseContainer
    {

        public override void Draw()
        {
            base.Draw();
        }

        public BlockContainer(){}

        public BlockContainer(PointF location,SizeF sizeF)
        {
            this.Location = location;
            this.SizeF = sizeF;
        }
    }
}
