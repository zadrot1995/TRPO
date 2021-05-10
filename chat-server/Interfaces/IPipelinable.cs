using chat_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Interfaces
{
    interface IPipelinable
    {
        abstract void Work(Circuite circuite, int time, int positiveDeviationTime, int negativeDeviationTime);
    }
}
