using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tujen.Input
{
    public static class InputState
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public static bool IsRightMouseButtonDown()
        {
            short state = GetAsyncKeyState(System.Windows.Forms.Keys.RButton);
            return (state & 0x8000) != 0;
        }
        public static bool IsLeftMouseButtonDown()
        {
            short state = GetAsyncKeyState(System.Windows.Forms.Keys.RButton);
            return (state & 0x2000) != 0;
        }
    }
}
