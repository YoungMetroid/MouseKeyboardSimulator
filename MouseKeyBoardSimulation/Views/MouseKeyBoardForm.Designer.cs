using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseKeyBoardSimulation
{
    partial class MouseKeyBoardForm
    {
        private TextBox _userInputTextBox;
        private TextBox _keyboardSimulationTextBox;
        private Button _startButton;
        private Button _stopButton;
       
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            _userInputTextBox = new TextBox();
            _userInputTextBox.Name = "UserInputTextBox";
            _userInputTextBox.Location = new Point(20, 20);
            _userInputTextBox.Text = "Enter Text Here";
            _userInputTextBox.Size = new Size(400, 200);
            _userInputTextBox.Multiline = true;
            _userInputTextBox.ScrollBars = ScrollBars.Vertical;

            _keyboardSimulationTextBox = new TextBox();
            _keyboardSimulationTextBox.Name = "KeyBoardSimulationTextBox";
            _keyboardSimulationTextBox.Location = new Point(20, 220);
            _keyboardSimulationTextBox.Size = new Size(400, 200);
            _keyboardSimulationTextBox.Multiline = true;
            _keyboardSimulationTextBox.ScrollBars = ScrollBars.Vertical;
            _keyboardSimulationTextBox.Text = "Simulated Key Presses will appear here";

            _startButton = new Button();
            _startButton.Location = new Point(440, 100);
            _startButton.Text = "Start";

            _stopButton = new Button();
            _stopButton.Location = new Point(440, 200);
            _stopButton.Text = "Stop";
           

            this.Controls.Add(_userInputTextBox);
            this.Controls.Add(_keyboardSimulationTextBox);
            this.Controls.Add(_startButton);
            this.Controls.Add(_stopButton);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";   
        }
    }
}

