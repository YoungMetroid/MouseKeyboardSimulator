using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseKeyBoardSimulation.Views
{
    internal interface IMouseKeyboardView
    {
        string InputText { get; }
        event EventHandler StartKeyBoardMouseSimulation;
        event EventHandler StopKeyBoardMouseSimulation;
        Control GetControl(string name);
    }
}
