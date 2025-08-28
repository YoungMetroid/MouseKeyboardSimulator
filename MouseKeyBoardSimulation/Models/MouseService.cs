using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace MouseKeyBoardSimulation.Models
{
    internal class MouseService:IMouseKeyboardService
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private int _fiftyPixel = 50;
        private int _pixelMoveCount = 0;
        private bool _left = true;
        private Timer _timer;
        private const int Delay = 1000;
        private MouseMode mode;

        internal MouseService(MouseMode mode = 0) {
            this.mode = mode;
        }
        public void SetMouseMode(MouseMode mode)
        {
            this.mode = mode;
        }

        public void StartSimulation()
        {
            _timer = new Timer();
            if (mode == MouseMode.registerMode)
            {
                SetPoint();
            }
            else if(mode == MouseMode.clickMode)
            {
                
                _timer.Interval = Delay;
                _timer.Tick += ClickMouse;
                _timer.Start();
            }
            else
            {
                _timer.Interval = Delay;
                _timer.Tick += MoveMouse;
                _timer.Start();
            }
        }
        public void SetPoint()
        {
            Console.WriteLine("Saving Mouse Cordinates");

        }
        public void StopSimulation() 
        { 
            _timer.Stop();
            _timer.Dispose();

        }
        private void MoveMouse(object sender, EventArgs e)
        {
            if (_left)
            {
                mouse_event(MOUSEEVENTF_MOVE, unchecked((uint)-1), 0, 0, 0);
                _pixelMoveCount++;
                if (_pixelMoveCount >= _fiftyPixel)
                {
                    _pixelMoveCount = 0;
                    _left = false;
                }
            }
            else
            {
                mouse_event(MOUSEEVENTF_MOVE, unchecked((uint)1), 0, 0, 0);
                _pixelMoveCount++;
                if (_pixelMoveCount >= _fiftyPixel)
                {
                    _pixelMoveCount = 0;
                    _left = true;
                }
            }
        }
        private void ClickMouse(object sender, EventArgs e)
        {
            Console.WriteLine("Clicking Mouse");
        }

    }
}
