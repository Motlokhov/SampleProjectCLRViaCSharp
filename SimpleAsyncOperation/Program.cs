using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAsyncOperation
{
    class Program
    {
        async static Task Mais(string[] args)
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");

            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Console.WriteLine("Main thread Id ({0}): Doing other work here ...", Thread.CurrentThread.ManagedThreadId);

            Task.Run(() => 
            {
                for(int i = 0; i < 100; i++)
                {
                    ThreadPool.QueueUserWorkItem(ComputeBoundOp, i);
                    Thread.Sleep(500);
                }
                GC.Collect(2, GCCollectionMode.Forced);                
            });

            Task.Run(() =>
            {
                ComputeThreads();
            });
        }

        private static void ComputeThreads()
        {
            while(true)
            {
                Console.WriteLine();

                int availableWorkerThreads;
                int availablePortThreads;
                ThreadPool.GetAvailableThreads(out availableWorkerThreads, out availablePortThreads);

                Console.WriteLine("AvailableWorkThreads: {0}", availableWorkerThreads);
                Console.WriteLine("AvailablePortThreads: {0}", availablePortThreads);

                int maxWorkerThreads;
                int maxPortThreads;
                ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxPortThreads);

                Console.WriteLine("MaxWorkerThreads: {0}", maxWorkerThreads);
                Console.WriteLine("MaxPortThreads: {0}", maxPortThreads);

                int minWorkerThreads;
                int minPortThreads;
                ThreadPool.GetMinThreads(out minWorkerThreads, out minPortThreads);

                Console.WriteLine("MinWorkerThreads: {0}", minWorkerThreads);
                Console.WriteLine("MinPortThreads: {0}", minPortThreads);

                Thread.Sleep(1000);
            }
            
        }

        private static void ComputeBoundOp(object state)
        {
            Console.WriteLine("In ComputeBoundOp ThreadId {1}: state={0}", state, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
        }

        private static void Main(string[] args)
        {
            Mais(args);
            Console.Read();
        }
    }
}
