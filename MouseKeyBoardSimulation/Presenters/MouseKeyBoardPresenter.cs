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
        private IMouseKeyboardService _service;
        private readonly Dictionary<string, IMouseKeyboardService> _services;
        private string _selectedOption;
        public MouseKeyBoardPresenter(IMouseKeyboardView view, Dictionary<string, IMouseKeyboardService> services) {
            _view = view;
            _service = services.First().Value;
            _services = services;
            _view.StartSimulation += StartRequested;
            _view.StopSimulation += StopRequested;
            _selectedOption = _view.SimulationOption;
        }

       
        private void StartRequested(object sender, EventArgs e)
        {
            _selectedOption = _view.SimulationOption;
            if (_selectedOption.Equals("RegisterClicks"))
            {
                _service = _services.TryGetValue("mouseService", out var service)?service: null;
                MouseService mouseService = _service as MouseService;
                mouseService.SetMouseMode(MouseMode.registerMode);
            }
            else if(_selectedOption.Equals("Move Mouse"))
            {
                _service = _services.TryGetValue("mouseService", out var service) ? service : null;
                MouseService mouseService = _service as MouseService;
                mouseService.SetMouseMode(MouseMode.moveMode);
            }
            else if (_selectedOption.Equals("KeyStrokes")){
                _service = _services.TryGetValue("keyBoardService", out var service) ? service : null;
                KeyBoardService keyboardService = _service as KeyBoardService;
                keyboardService.SetText(_view.InputText);
                var inputBox = _view.GetControl("KeyBoardSimulationTextBox") as System.Windows.Forms.TextBox;
                inputBox?.Focus();
            }
            else if(_selectedOption.Equals("Simulate Human"))
            {

            }
            _service.StartSimulation();
        }
        private void StopRequested(object sender, EventArgs e)
        {
           _service.StopSimulation();
        }

    }
}

