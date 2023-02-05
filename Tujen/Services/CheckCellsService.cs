using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tujen.Interfaces;
using Cursor = System.Windows.Forms.Cursor;
using KeyboardSimulator = Tujen.Input.KeyboardSimulator;
using MouseSimulator = Tujen.Input.MouseSimulator;

namespace Tujen.Services
{
    public class CheckCellsService
    {
        private readonly CancellationTokenSource cts;
        private readonly IValuableItemService valuableItemService;
        private int cellCount=0;
        private Point FIRST_CELL_POINTER = new Point {X=54,Y=190 };
        private const int PIXELS_TO_SKIP= 28;
        private const int MOVE_MOUSE_TIME_MILLISECONDS = 5;
        public CheckCellsService(CancellationTokenSource cts,
            IValuableItemService valuableItemService)
        {
            this.cts = cts;
            this.valuableItemService= valuableItemService;
        }

        public void Run()
        {
            while (!cts.IsCancellationRequested)
            {
                WindowHelper.GetWindowHandle(WindowHelper.WINDOW_NAME);
                CopyToClipboardItem(cts.Token);
                cellCount = 0;
            }
        }

        private void CopyToClipboardItem(CancellationToken ct)
        {
            if (cellCount == 23|| ct.IsCancellationRequested)
            {
                return;
            }
            if(cellCount== 0)
            {
                Thread.Sleep(2000);
            }

            var mousePoint = MoveMouse(FIRST_CELL_POINTER, cellCount);
            Thread.Sleep(MOVE_MOUSE_TIME_MILLISECONDS);

            KeyboardSimulator.PressCtrlDown();
            Thread.Sleep(10);
            KeyboardSimulator.Press_C_Down();
            Thread.Sleep(10);
            KeyboardSimulator.Press_C_Up();
            Thread.Sleep(10);
            KeyboardSimulator.PressCtrlUp();

            string clipboardText = Clipboard.GetText();
            if (clipboardText != null)
            {
                valuableItemService.CreateValuableItem(clipboardText.ToString(), mousePoint);
            }
            cellCount++;
            CopyToClipboardItem(ct);
        }

        private Point MoveMouse(Point mousePoint, int cellCount)
        {
            int columnNumber = cellCount / 11;
            int rowNumber = cellCount % 11;
            if (rowNumber == 0)
            {
                rowNumber = 11;
                columnNumber--;
            }

            mousePoint.X += PIXELS_TO_SKIP * columnNumber;
            mousePoint.Y += PIXELS_TO_SKIP * (rowNumber - 1);
            Cursor.Position = mousePoint;

            return mousePoint;
        }
    }
}
