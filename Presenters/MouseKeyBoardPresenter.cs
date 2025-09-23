using MouseKeyBoardSimulation.Views;
using MouseKeyBoardSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using MouseKeyBoardSimulation.Domain;

namespace MouseKeyBoardSimulation.Presenter
{
    internal class MouseKeyBoardPresenter
    {
        private readonly IMouseKeyboardView _view;
        private IMouseKeyboardService? _service;
        private readonly Dictionary<string, IMouseKeyboardService>? _services;
        private string _selectedOption;
        public MouseKeyBoardPresenter(IMouseKeyboardView view
            ,Dictionary<string, IMouseKeyboardService> services) {
            _view = view;
            _service = services.First().Value;
            _services = services;
            _view.StartSimulation += StartRequested;
            _view.StopSimulation += StopRequested;
            _view.RecordSimulation += RecordRequested;
            _selectedOption = _view.SimulationOption;
        }
        private void StartRequested(object sender, EventArgs e)
        {
            _selectedOption = _view.SimulationOption;
            if (_selectedOption.Equals("StaticMousMove"))
            {
                _service = _services.GetValueOrDefault("mouseService", null);
                MouseService mouseService = _service as MouseService;
                mouseService.SetMouseMode(MouseMode.moveMode);
            }
            else if (_selectedOption.Equals("StaticKeyStrokes")) {
                _service = _services.GetValueOrDefault("keyBoardService", null);
                KeyBoardService? keyboardService = _service as KeyBoardService;
                keyboardService.SetText(_view.InputText);
                var inputBox = _view.GetControl("KeyBoardSimulationTextBox") as System.Windows.Forms.TextBox;
                inputBox?.Focus();
            }
            else if (_selectedOption.Equals("Mouse"))
            {
                _service = _services.GetValueOrDefault("mouseService", null);
                MouseService mouseService = _service as MouseService;
                mouseService.SetMouseMode(MouseMode.playMode);
            }
           
            _service.StartSimulation();
        }
        private void StopRequested(object sender, EventArgs e)
        {
           _service.StopSimulation();
        }
        private void RecordRequested(object sender, EventArgs e)
        {
            _selectedOption = _view.SimulationOption;
            if (_selectedOption.Equals("Mouse"))
            {
                _service = _services.GetValueOrDefault("mouseService", null);
                MouseService mouseService = _service as MouseService;
                mouseService.SetMouseMode(MouseMode.recordMode);
            }
            _service.RecordSimulation();
        }

    }
}

