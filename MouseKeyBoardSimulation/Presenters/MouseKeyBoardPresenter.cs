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
                _service = _services.TryGetValue("keyBoardService", out var service)?service: null;
                _service.
            }
            var inputBox = _view.GetControl("KeyBoardSimulationTextBox") as System.Windows.Forms.TextBox;
            inputBox?.Focus();
            //var text = _view.InputText;
            //_service.StartSimulation();
        }
        private void StopRequested(object sender, EventArgs e)
        {
           _service.StopSimulation();
        }

    }
}

