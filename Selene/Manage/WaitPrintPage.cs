using Selene.Draw.CalcStruct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Manage
{
    public class WaitPrintPage
    {

        private List<BaseContainer> controls = new List<BaseContainer>();

        public int PageIndex { get; set; }

        public void AddCtrl(BaseContainer ctrl)
        {
            controls.Add(ctrl);
        }

        public void AddRangeCtrl(List<BaseContainer> ctrls)
        {
            controls.AddRange(ctrls);
        }

        public void DoDraw(Graphics graphics)
        {
            foreach (BaseContainer ctrl in controls)
            {
                ctrl.Graphics = graphics;
                ctrl.Draw();
            }
        }

        public BaseContainer GetCtrl(string name)
        {
            return this.controls.First(c => c.Name.Equals(name));
        }

        public BaseContainer GetCtrl(int id)
        {
            return this.controls.First(c => c.Id == id);
        }

        public TType GetCtrl<TType>(string name) where TType : class
        {
            var ctrl = this.controls.FirstOrDefault(c => name.Equals(c.Name));
            if (ctrl != null)
            {
                return ctrl as TType;
            }
            return default(TType);
        }

        public TType GetCtrl<TType>(int id) where TType : class
        {
            var ctrl = this.controls.FirstOrDefault(c => c.Id == id);
            if (ctrl != null)
            {
                return ctrl as TType;
            }
            return default(TType);
        }
    }
}
