using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tujen.Interfaces;

namespace Tujen.Services
{
    public class HangleService : IHangleService
    {
        private readonly IValuableItemService valuableItemService;
        private readonly CancellationTokenSource cts;
        public HangleService(CancellationTokenSource cts,
            IValuableItemService valuableItemService) 
        {
            this.cts = cts;
            this.valuableItemService = valuableItemService;
        }
        public void ConfirmPrice()
        {
            throw new NotImplementedException();
        }

        public void HangleForItem()
        {
            throw new NotImplementedException();
        }

        public void RerollItems()
        {
            throw new NotImplementedException();
        }
    }
}
