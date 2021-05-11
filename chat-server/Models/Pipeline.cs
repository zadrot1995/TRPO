using chat_server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Models
{
    public class Pipeline
    {
        public List<IPipelinable> ComponentsContainer { get; set; }
    }
}
