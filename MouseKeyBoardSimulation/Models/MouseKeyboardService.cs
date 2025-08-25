using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MouseKeyBoardSimulation.Models
{
    internal class MouseKeyboardService : IMouseKeyboardService
    {
        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;

        private Timer _timer;
        private const int Delay = 400;
        private int _textIndex = 0;
        private string _text;


        private void SendChar(char c)
        {
            short vk = VkKeyScan(c);
            byte vkCode = (byte)(vk & 0xFF);

            keybd_event(vkCode, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(vkCode, 0, KEYEVENTF_KEYUP, 0);
        }
        internal MouseKeyboardService()
        {
            _timer = new Timer();
        }
        public void StartKeyboardSimulation(string text)
        {
            _text = text;
            _timer.Interval = Delay;
            _timer.Tick += TypeKey;
            _timer.Start();
        }

        private void TypeKey(object sender, EventArgs e)
        {
            if(_textIndex >= _text.Length) _textIndex = 0;
            SendChar(_text.ElementAt(_textIndex));
            _textIndex++;
        }

        public void StartMouseSimulation()
        {
        }
        public void StopKeyboardSimulation()
        {
            _timer.Stop();
            MessageBox.Show("Stopping Keyboard Simulation");
        }
        public void StopMouseSimulation()
        {
            MessageBox.Show("Stopping Mouse Simulation");
        }
    }
}
