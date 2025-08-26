using MouseKeyBoardSimulation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseKeyBoardSimulation
{
    public partial class MouseKeyBoardForm : Form, IMouseKeyboardView
    {
        public string InputText => _userInputTextBox.Text;
        public string SimulationOption => _simulationSelector.SelectedItem as string;
        public event EventHandler StartSimulation;
        public event EventHandler StopSimulation;
        public event EventHandler SetSimulation;
        public MouseKeyBoardForm()
        {
            InitializeComponent();
            _startButton.Click +=(s,e)=> StartSimulation?.Invoke(this,EventArgs.Empty);
            _stopButton.Click +=(s,e)=> StopSimulation?.Invoke(this, EventArgs.Empty);
            _simulationSelector.SelectedIndexChanged += (s, e) => SetSimulation?.Invoke(this, EventArgs.Empty);
        }
        public Control GetControl(string name)
        {
            return this.Controls.Find(name,true).FirstOrDefault();
        }

    }
}
