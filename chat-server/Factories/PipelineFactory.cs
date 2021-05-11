using chat_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Factories
{
    public class PipelineFactory
    {
        public Pipeline GetDefaultPipeline()
        {
            Pipeline pipeline = new Pipeline
            {
                ComponentsContainer = new List<Interfaces.IPipelinable>
                {
                    new FirstMiddleware( 12, 1, 1 ),
                    new SeccondMiddleware( 13, 3, 3),
                    new ThirdMiddleware( 7, 1, 1),
                    new FourthMiddleware( 8, 3, 3)
                }
            };
            return pipeline;
        }
    }
}
