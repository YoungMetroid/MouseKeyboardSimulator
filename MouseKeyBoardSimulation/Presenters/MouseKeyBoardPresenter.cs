using MouseKeyBoardSimulation.Views;
using MouseKeyBoardSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseKeyBoardSimulation.Presenter
{
    internal class MouseKeyBoardPresenter
    {
        private readonly IMouseKeyboardView _view;
        private readonly IMouseKeyboardService _service;
        public MouseKeyBoardPresenter(IMouseKeyboardView view, IMouseKeyboardService service) {
            _view = view;
            _service = service;

            _view.StartKeyBoardMouseSimulation += StartRequested;
            _view.StopKeyBoardMouseSimulation += StopRequested;
        }
        private void StartRequested(object sender, EventArgs e)
        {
            var inputBox = _view.GetControl("KeyBoardSimulationTextBox") as System.Windows.Forms.TextBox;
            inputBox?.Focus();

            var text = _view.InputText;
            _service.StartKeyboardSimulation(text);
            _service.StartMouseSimulation();
        }
        private void StopRequested(object sender, EventArgs e)
        {
            _service.StopKeyboardSimulation();
            _service.StopMouseSimulation();
        }

    }
}

