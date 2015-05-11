using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RedisTicket.Domain;
using RedisTicket.Tests;

namespace RedisTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            int worker;
            int ioCompletion;
            ThreadPool.GetMaxThreads(out worker, out ioCompletion);
            Console.WriteLine("{0} / {1}", worker, ioCompletion);

            OrderTest testCase = new OrderTest();
            testCase.CreateOrderTest();


            Console.Write("finish");
            Console.ReadLine();

        }
    }
}
