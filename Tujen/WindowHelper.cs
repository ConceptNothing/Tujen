using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tujen
{
    public static class WindowHelper
    {
        public const string WINDOW_NAME = "Path of Exile";
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        public static IntPtr GetWindowHandle(string windowName)
        {
            return FindWindow(null, windowName);
        }
    }
}
