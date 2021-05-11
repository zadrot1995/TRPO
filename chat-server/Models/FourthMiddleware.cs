using chat_server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace chat_server.Models
{
    public class FourthMiddleware : IPipelinable
    {
        public FourthMiddleware(int time, int positiveDeviationTime, int negativeDeviationTime)
        {
            Time = time;
            this.positiveDeviationTime = positiveDeviationTime;
            this.negativeDeviationTime = negativeDeviationTime;
        }

        public int Time { get; set; }
        public int positiveDeviationTime { get; set; }
        public int negativeDeviationTime { get; set; }

        public void Work(Circuite circuite)
        {
            Random random = new Random();
            var time = Time + random.Next(negativeDeviationTime, positiveDeviationTime);
            Thread.Sleep(time*1000);
        }
    }
}
