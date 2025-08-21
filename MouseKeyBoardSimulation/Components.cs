using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseKeyBoardSimulation
{
    class Components
    {

        public static TextBox CreateInput(string placeholder, Point location, Size size)
        {
            var box = new TextBox
            {
                Location = location,
                Size = size,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Text = placeholder
            };
            return box;
        }
        public static Button CreateButton(Point location)
        {
            var button = new Button
            {
                Location = location
               
            };
            return button; 
        }

    }
}
