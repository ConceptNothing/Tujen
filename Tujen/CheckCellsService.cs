using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tujen.Interfaces;
using Tujen.Models;

namespace Tujen
{
    public class CheckCellsService
    {
        private CancellationTokenSource cts;
        private readonly IValuableItemService valuableItemService;
        public CheckCellsService(CancellationTokenSource cts,
            IValuableItemService valuableItemService)
        {
            this.cts = cts;
            this.valuableItemService= valuableItemService;
        }

        public void Run()
        {
            for (int i = 0; i <= 22; i++)
            {
                if (cts.IsCancellationRequested)
                {
                    break;
                }
                if(Clipboard.GetText()== string.Empty || Clipboard.GetText()==null) 
                {
                    //Code that will be executed if cell is empty
                    //continue;
                }
                else
                {

                }
            }
        }
        private void MoveMouse(Point mousePoint)
        {

        }
    }
}
