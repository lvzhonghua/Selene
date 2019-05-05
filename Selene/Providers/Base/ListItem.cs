using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Providers.Base
{
    public class ListItem
    {
        public string Text { get; set; }

        public string Value { get; set; }

        public bool Selected { get; set; }

        public ListItem() { }

        public ListItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public ListItem(string text, string value,bool selected)
        {
            this.Text = text;
            this.Value = value;
            this.Selected = selected;
        }
    }
}
