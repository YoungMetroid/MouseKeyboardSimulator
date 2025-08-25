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

        public event EventHandler StartKeyBoardMouseSimulation;
        public event EventHandler StopKeyBoardMouseSimulation;
        public MouseKeyBoardForm()
        {
            InitializeComponent();
            _startButton.Click +=(s,e)=> StartKeyBoardMouseSimulation?.Invoke(this,EventArgs.Empty);
            _stopButton.Click +=(s,e)=> StopKeyBoardMouseSimulation?.Invoke(this, EventArgs.Empty); ;
        }
        public Control GetControl(string name)
        {
            return this.Controls.Find(name,true).FirstOrDefault();
        }

    }
}
