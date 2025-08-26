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
        event EventHandler StartSimulation;
        event EventHandler StopSimulation;
        event EventHandler SetSimulation;
        Control GetControl(string name);
    }
}
