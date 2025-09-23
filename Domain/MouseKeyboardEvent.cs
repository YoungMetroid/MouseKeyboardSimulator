using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SWF = System.Windows.Forms;

namespace MouseKeyBoardSimulation.Domain
{
    public record MouseKeyboardEvent(SWF.MouseEventArgs mouseArgs,MouseEvent mouseEvent, DateTime dateTime);
    
}
