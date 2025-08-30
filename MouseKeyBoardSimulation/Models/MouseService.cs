using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MouseKeyBoardSimulation.Models
{
    internal class MouseService:IMouseKeyboardService
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const int Delay = 1000;
        private int _fiftyPixel = 50;
        private int _pixelMoveCount = 0;
        private int _maxClicks = 3;
        private bool _left = true;
        private List<Point> _mouseCordinates;
        private MouseMode _mode;
        private Timer _timer;
        private MouseHook _mh;
        


        internal MouseService(MouseMode mode = 0) {
            this._mode = mode;
            _mh = new MouseHook();
            _mouseCordinates = new List<Point>();
            _mh.MouseUpEvent += MouseUpEvent;
        }
        public void SetMouseMode(MouseMode mode)
        {
            this._mode = mode;
        }
        public void SetClickLimit(int maxClicks)
        {
            _maxClicks = maxClicks;
        }

        public void StartSimulation()
        {
            _timer = new Timer();
            if (_mode == MouseMode.registerMode)
            {
            }
            else if(_mode == MouseMode.clickMode)
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
        public void SetClickPoint(object sender, EventArgs e)
        {
           

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
        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (_mode != MouseMode.registerMode) return;

            if(e.Button == MouseButtons.Left)
            {
                _mouseCordinates.Add(new Point(e.Location.X, e.Location.Y));
            }
        }

    }
}
