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
        string SimulationOption { get; }
        int MaxClicks { get; }
        event EventHandler StartSimulation;
        event EventHandler StopSimulation;
        Control GetControl(string name);
    }
}
