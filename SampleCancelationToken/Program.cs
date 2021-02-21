using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleCancelationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("At {0}", DateTime.Now)); // second invoke after cancel
            cts.Token.Register(() => Console.Write("Count is canceled. ")); //First invoke after cancel

            ThreadPool.QueueUserWorkItem(_ => Count(cts.Token, 10));
            Console.WriteLine("Tap to stop");
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Tap to exit");
            Console.ReadKey();
        }

        private static void Count(CancellationToken token, int countTo)
        {
            for(int i = 0; i < countTo; i++)
            {
                if(token.IsCancellationRequested)
                    break;

                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("done");
        }
    }
}
