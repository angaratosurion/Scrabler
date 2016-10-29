using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
namespace Scrabler.Tools.Helpers.Hardware
{
    /// <summary>
    /// PC Monitor(win32 api) helper class
    /// </summary>
   public  class Monitor
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool LockWorkStation();
       /// <summary>
       /// Turns off the pc monitor
       /// </summary>
       /// <param name="hwnd"></param>
        public void TurnOffMonitor(int hwnd)
        {
            try
            {
                Monitor.LockWorkStation();
                Monitor.SendMessage(hwnd, 0x0112, 0xF170, 2);
            }
            catch (Exception ex)
            {


            }
        }
       /// <summary>
       /// Turns on the monitor
       /// </summary>
       /// <param name="hwnd"></param>
        public void TurnOnMonitor(int hwnd)
        {
            try
            {
                Monitor.LockWorkStation();
                Monitor.SendMessage(hwnd, 0x0112, 0xF170, -1);
            }
            catch (Exception ex)
            {


            }



        }

    }
}
