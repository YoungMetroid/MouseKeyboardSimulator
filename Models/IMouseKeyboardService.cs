using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseKeyBoardSimulation.Models
{
    public interface IMouseKeyboardService
    {
        void StartSimulation();
        void StopSimulation();
        void RecordSimulation();
    }
}
