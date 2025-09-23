using MouseKeyBoardSimulation.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace MouseKeyBoardSimulation.Models
{
    internal class MouseService:IMouseKeyboardService
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const int Delay = 10;
        private const int MAXCLICKS = 10;
        private int _fiftyPixel = 50;
        private int _pixelMoveCount = 0;
        private int _maxClicks = 3;
        private int eventPlayed = 0;
        private int _previousX;
        private int _previousY;
        private bool _left = true;
        private bool recordOn = false;
        private List<Point> _mouseCordinates;
        private MouseMode _mode;
        private Timer _timer;
        private MouseHook _mh;
        private ConcurrentQueue<MouseKeyboardEvent> _mouseEvent;
        private List<MouseKeyboardEvent> _mouseEventList;

        public MouseService( ConcurrentQueue<MouseKeyboardEvent> mouseEvent, MouseMode mode = 0) {
            this._mode = mode;
            this._mouseEvent = mouseEvent;
            _mouseEventList = this._mouseEvent.ToList();
            _mh = new MouseHook();
            _mh.SetHook();
            _mh.MouseMoveEvent += MouseMoveEvent;
            _mh.MouseClickEvent += MouseClickEvent;
            _mh.MouseDownEvent += MouseDownEvent;
            _mh.MouseUpEvent += MouseUpEvent;
            _mouseCordinates = new List<Point>();
        }
        public void SetMouseMode(MouseMode mode)
        {
            this._mode = mode;
        }
        public void SetClickLimit(int maxClicks)
        {
            this._maxClicks = maxClicks;
        }
        public void StartSimulation()
        {
            _timer = new Timer();
            if(_mode == MouseMode.playMode)
            {
                _timer.Interval = Delay;
                _timer.Tick += PlayRecording;
                _timer.Start();
            }
            else
            {
                _timer.Interval = Delay;
                _timer.Tick += MoveMouse;
                _timer.Start();
            }
        }
        public void RecordSimulation()
        {
            if (_mode == MouseMode.recordMode)
            {
                RecordMouse();
            }
        }
       
        public void StopSimulation() 
        { 
            _timer.Stop();
            _timer.Dispose();

        }
        public void RecordMouse()
        {
            if (recordOn && _mouseEvent.Count >1)
            {
                _mouseEventList = _mouseEvent.ToList();
                MouseKeyboardEvent mouseEvent = _mouseEventList.ElementAt(0);
                foreach(var e in _mouseEventList)
                {
                    Debug.WriteLine(e.mouseArgs.Location.X + " : " + e.mouseArgs.Location.Y + " : " + e.dateTime);
                }
                _previousX = mouseEvent.mouseArgs.Location.X;
                _previousY = mouseEvent.mouseArgs.Location.Y;
            }
            recordOn = !recordOn;
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
        private void PlayRecording(object sender, EventArgs e)
        {
            if(eventPlayed < _mouseEventList.Count)
            {
                MouseKeyboardEvent mouseEvent = _mouseEventList.ElementAt(eventPlayed);
                int x = mouseEvent.mouseArgs.Location.X;
                int y = mouseEvent.mouseArgs.Location.Y;
                MouseEvent mouseAction = mouseEvent.mouseEvent;
                
                if (eventPlayed == 0) 
                {
                    SetCursorPos(x, y);
                    _previousX = x;
                    _previousY = y;
                    eventPlayed++;
                }
                PlayMouseAction(mouseAction, x, y);
                eventPlayed++;
            }
            else if(eventPlayed >= _mouseEventList.Count)
            {
                eventPlayed = 0;
            }
        }
        private void PlayMouseAction(MouseEvent mouseAction,int x,int y)
        {
            int deltaX = (_previousX < x ? Math.Abs(x - _previousX)
                    : _previousX == x ? 0
                    : Math.Abs(x - _previousX) * -1);

            int deltaY = _previousY < y ? Math.Abs(y - _previousY)
                : _previousY == y ? 0
                : Math.Abs(y - _previousY) * -1;

            Debug.WriteLine($"Deltas X{deltaX} : Y{deltaY} :: Current X ${x} : Y ${y}\n Previous X ${_previousX} : ${_previousY}");
            _previousX = x;
            _previousY = y;
            if (mouseAction.Equals( MouseEvent.move))
            {
                mouse_event(MOUSEEVENTF_MOVE, (uint)deltaX, (uint)deltaY, 0, 0);
            }
            else if (mouseAction.Equals(MouseEvent.leftClick))
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)deltaX, (uint)deltaY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, (uint)deltaX, (uint)deltaY, 0, 0);
            }
        }
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (recordOn)
            {
                _mouseEvent.Enqueue(new MouseKeyboardEvent(e, MouseEvent.move, DateTime.Now));
                Debug.WriteLine(_mouseEvent.Count);
            }
        }
        private void MouseClickEvent(object sender, MouseEventArgs e)
        {

        }
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {

        }
        private void MouseUpEvent(object sender, MouseEventArgs e)
        { 
            if(_mode != MouseMode.recordMode && !recordOn) return;
            if(e.Button == MouseButtons.Left)
            {
                Debug.WriteLine("Saving a click");
                _mouseEvent.Enqueue(new MouseKeyboardEvent(e, MouseEvent.leftClick, DateTime.Now));
            }
        }

    }
}
