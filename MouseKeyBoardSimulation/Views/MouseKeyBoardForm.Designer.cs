using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MouseKeyBoardSimulation
{
    partial class MouseKeyBoardForm
    {
        private TextBox _userInputTextBox;
        private TextBox _keyboardSimulationTextBox;
        private NumericUpDown _clickLimitNumericUpDown;
        private Button _startButton;
        private Button _stopButton;
        private ComboBox _simulationSelector;

        private const int MaxClickLimit = 10;
        private const int MinClickLimit = 3;
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

            _clickLimitNumericUpDown = new NumericUpDown();
            _clickLimitNumericUpDown.Name = "ClickLimitTextBox";
            _clickLimitNumericUpDown.Location = new Point(420, 300);
            _clickLimitNumericUpDown.Maximum = MaxClickLimit;

            //This is the default value
            _clickLimitNumericUpDown.Minimum = MinClickLimit;


            _startButton = new Button();
            _startButton.Location = new Point(440, 100);
            _startButton.Text = "Start";

            _stopButton = new Button();
            _stopButton.Location = new Point(440, 200);
            _stopButton.Text = "Stop";

            _simulationSelector = new ComboBox();
            _simulationSelector.Location = new Point(420, 20);
            _simulationSelector.Items.AddRange(new object[] {
                "Move Mouse"
                ,"KeyStrokes"
                ,"Register Clicks"
                ,"Simulate Human"
            });
            _simulationSelector.SelectedIndex = 0;


            this.Controls.Add(_userInputTextBox);
            this.Controls.Add(_keyboardSimulationTextBox);
            this.Controls.Add(_startButton);
            this.Controls.Add(_stopButton);
            this.Controls.Add(_simulationSelector);
            this.Controls.Add(_clickLimitNumericUpDown);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 430);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = Properties.Resources.keyboardmouse_icon;
            this.Text = "MouseKeyBoardUtility";   
        }
    }
}

