using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseKeyBoardSimulation.Models
{
    internal interface IMouseKeyboardService
    {
        void StartKeyboardSimulation(string text);
        void StartMouseSimulation();
        void StopKeyboardSimulation();
        void StopMouseSimulation();

    }
}
