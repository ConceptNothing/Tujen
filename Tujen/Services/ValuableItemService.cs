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

        public Task<bool> CreateHangleItem(string itemText,Point itemScreenPoint)
        {
            var itemName = Constants.FILTER_ITEMS.FirstOrDefault(line => itemText.Contains(line));
            if (itemName!=null&&itemName!=string.Empty)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public List<ValuableItem> GetAllItemsFromList()
        {
            return currentRerollValuableItems;
        }
    }
}
