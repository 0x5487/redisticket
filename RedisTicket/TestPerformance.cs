using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisTicket.Domain;
using StackExchange.Redis;

namespace RedisTicket
{
    public class TestPerformance
    {
        private TicketMachineService _ticketMachineService;
        private Int64 _ticketA = 8990;
        private Int64 _ticketB = 9990;

        public void Test()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();


            List<Task> allTasks = new List<Task>();

            for (int i = 0; i < 20; i++)
            {
                allTasks.Add(BuyTicket());
            }

            foreach (var task in allTasks)
            {
                task.Start();
            }

            
            //Task.WaitAll(task1);
            Task.WaitAll(allTasks.ToArray());
            stopWatch.Stop();

            Console.WriteLine(stopWatch.Elapsed);
        }

        public Task BuyTicket()
        {
            Task task = new Task(() =>
            {
                List<BuyItem> buyItems = new List<BuyItem>();
                buyItems.Add(new BuyItem() { EventId = 2, TicketId = _ticketA, Quantity = 1 });

                string result = "";

                while (result != "NoTicket")
                {
                    result = _ticketMachineService.GetStockItems(buyItems);
                }
            });

            return task;
        }

        public TestPerformance()
        {
            ConfigurationOptions option = new ConfigurationOptions();
            option.ConnectTimeout = 30000;
            //option.AllowAdmin = true;
            option.EndPoints.Add("localhost", 6379);

            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(option);
            _ticketMachineService = new TicketMachineService(conn);
            _ticketMachineService.DeleteTicket(_ticketA);
            _ticketMachineService.DeleteTicket(_ticketB);

            List<string> itemsA = new List<string>();
            for (int i = 0; i < 500000; i++)
            {
                itemsA.Add(Guid.NewGuid().ToString());
            }

            _ticketMachineService.AddStockItems(_ticketA, itemsA.ToArray());

            List<string> itemsB = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                itemsB.Add(Guid.NewGuid().ToString());
            }

            _ticketMachineService.AddStockItems(_ticketB, itemsB.ToArray());

        }
    }
}
