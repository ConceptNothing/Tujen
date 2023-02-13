using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tujen.Input
{
    public static class KeyboardSimulator
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const int VK_CONTROL = 0x11;
        private const int VK_C = 0x43;
        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;

        public static void PressCtrl()
        {
            PressCtrlDown();
            PressCtrlUp();
        }
        public static void PressC() 
        {
            Press_C_Down();
            Press_C_Up();
        }
        public static void PressCtrlUp()
        {
            keybd_event((byte)VK_CONTROL, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
        }
        public static void PressCtrlDown()
        {
            keybd_event((byte)VK_CONTROL, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
        }
        public static void Press_C_Up()
        {
            keybd_event((byte)VK_C, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
        }
        public static void Press_C_Down()
        {
            keybd_event((byte)VK_C, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
        }
    }
}
