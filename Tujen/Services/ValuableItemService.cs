using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tujen.Interfaces;
using Tujen.ItemFilters;
using Tujen.Models;

namespace Tujen.Services
{
    internal class ValuableItemService : IValuableItemService
    {
        private static List<ValuableItem> currentRerollValuableItems=new List<ValuableItem>();
        public void AddToList(ValuableItem item)
        {
            currentRerollValuableItems.Add(item);
        }

        public void CleanList()
        {
            currentRerollValuableItems.Clear();
        }

        public Task<bool> CreateValuableItem(string itemText,Point itemScreenPoint)
        {
            if (itemText == null || itemText == string.Empty)
            {
                return Task.FromResult(false);
            }

            var str = itemText.ToLower();

            var itemName = Constants.FILTER_ITEMS.FirstOrDefault(line => str.Contains(line));
            if (itemName!=null&&itemName!=string.Empty)
            {
                var item = new ValuableItem { Name=itemName,CellPosition=itemScreenPoint };
                AddToList(item);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public List<ValuableItem> GetAllItems()
        {
            return currentRerollValuableItems;
        }
    }
}
