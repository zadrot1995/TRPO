using chat_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Interfaces
{
    public interface IPipelinable
    {
        abstract void Work(Circuite circuite);
    }
}
