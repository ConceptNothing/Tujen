using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tujen.Interfaces;
using Tujen.Services;

namespace Tujen
{
    internal class Program
    {
        private static CancellationTokenSource _cts = new CancellationTokenSource();

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Press F9 to stop the program");
            Console.WriteLine("Press any key to start the program");
            Console.ReadLine();

            Task.Run(() => ListenForKeyPress(_cts.Token));

            var serviceProvider = BuildServiceProvider();
            var checkCellsService = serviceProvider.GetService<CheckCellsService>();
            checkCellsService.Run();

            while (!_cts.IsCancellationRequested)
            {
                Task.Run(() => ListenForKeyPress(_cts.Token));
                checkCellsService.Run();
            }
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
            serviceCollection.AddSingleton<IHangleService, HangleService>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
