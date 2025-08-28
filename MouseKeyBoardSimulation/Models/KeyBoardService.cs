using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Timer = System.Windows.Forms.Timer;

namespace MouseKeyBoardSimulation.Models
{
    internal class KeyBoardService : IMouseKeyboardService
    {
        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private Timer _timer;
        private const int Delay = 1000;
        private int _textIndex = 0;
        private string _text;
        private void SendChar(char c)
        {
            short vk = VkKeyScan(c);
            byte vkCode = (byte)(vk & 0xFF);

            keybd_event(vkCode, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(vkCode, 0, KEYEVENTF_KEYUP, 0);
        }
        private void TypeKey(object sender, EventArgs e)
        {
            if (_textIndex >= _text.Length) _textIndex = 0;
            SendChar(_text.ElementAt(_textIndex));
            _textIndex++;
        }
        internal KeyBoardService()
        {
            _timer = new Timer();
        }

        public void StartSimulation()
        {
            _timer.Interval = Delay;
            _timer.Tick += TypeKey;
            _timer.Start();
        }
        public void StopSimulation()
        {
            _timer.Stop();
            _timer.Tick -= TypeKey;
        }
        internal void SetText(string text)
        {
            _text = text;
        }
    }
}
