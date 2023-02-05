using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tujen.ItemFilters
{
    public static class Constants
    {
        public static readonly List<string> FILTER_ITEMS;

        static Constants()
        {
            string folderName = "ItemFilters";
            string fileName = "TestFilter";
            string filePath = Path.Combine(Environment.CurrentDirectory, folderName, fileName);

            FILTER_ITEMS = new List<string>();

            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    FILTER_ITEMS.Add(line);
                }
            }
        }
    }
}
