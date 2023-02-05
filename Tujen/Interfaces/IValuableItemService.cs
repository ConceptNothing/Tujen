using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tujen.Models;

namespace Tujen.Interfaces
{
    public interface IValuableItemService
    {
        void AddToList(ValuableItem item);
        void CleanList();
        List<ValuableItem> GetAllItemsFromList();
        Task<bool> CreateValuableItem(string itemText,Point itemPoint);
    }
}
