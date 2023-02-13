using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tujen.Input;
using Tujen.Interfaces;
using Tujen.Bot;

namespace Tujen.Services
{
    public class HangleService : IHangleService
    {
        private readonly IValuableItemService valuableItemService;
        private readonly CancellationTokenSource cts;
        private Point confirmButtonPoint;
        public HangleService(CancellationTokenSource cts,
            IValuableItemService valuableItemService)
        {
            this.cts = cts;
            this.valuableItemService = valuableItemService;
            //This should be point configuration from config file in the future.
            confirmButtonPoint= new Point { X=215,Y=510};
        }
        public void ConfirmPrice()
        {

        }

        public void HangleForItem()
        {
            var items = valuableItemService.GetAllItems();
            foreach(var item in items)
            {
                MoveMouse(item.CellPosition);
                MouseSimulator.LeftClick();
                MoveMouse(confirmButtonPoint);
                for (int i = 0; i < 11; i++)
                {
                    MouseSimulator.MouseWheelDown();
                    Thread.Sleep(5);
                }
                MouseSimulator.LeftClick();
                if (PixelBot.ContainsImage())
                {
                    for (int i = 0; i < 11; i++)
                    {
                        MouseSimulator.MouseWheelDown();
                        Thread.Sleep(5);
                    }
                    if(PixelBot.ContainsImage())
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            MouseSimulator.MouseWheelDown();
                            Thread.Sleep(5);
                        }
                    }
                }
            }
        }

        public void RerollItems()
        {
            throw new NotImplementedException();
        }
        private void MoveMouse(Point itemPoint)
        {

        }
    }
}
