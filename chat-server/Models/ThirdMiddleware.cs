using chat_server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace chat_server.Models
{
    public class ThirdMiddleware : IPipelinable
    {
        public void Work(Circuite circuite, int time, int positiveDeviationTime, int negativeDeviationTime)
        {
            Random random = new Random();
            time = time + random.Next(negativeDeviationTime, positiveDeviationTime);
            Thread.Sleep(time);
        }
    }
}
