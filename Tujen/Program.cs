using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tujen.Interfaces;
using Tujen.Services;

namespace Tujen
{
    internal class Program
    {
        private static CancellationTokenSource _cts = new CancellationTokenSource();

        [MTAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Press F9 to stop the program");

            Task.Run(() => ListenForKeyPress(_cts.Token));

            var serviceProvider = BuildServiceProvider();
            var anotherClass = serviceProvider.GetService<CheckCellsService>();
            anotherClass.Run();

            Console.WriteLine("Program stopped");
        }

        private static void ListenForKeyPress(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.F9)
                {
                    _cts.Cancel();
                    break;
                }
            }
        }
        private static IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(typeof(CancellationTokenSource), _cts);
            serviceCollection.AddSingleton<CheckCellsService>();
            serviceCollection.AddSingleton<IValuableItemService, ValuableItemService>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
