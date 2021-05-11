using chat_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Factories
{
    public class CircuiteFactory
    {
        public PipelineFactory PipelineFactory { get; set; }
        public CircuiteFactory()
        {
            PipelinesCount = 4;
            PipelineFactory = new PipelineFactory();
        }

        public CircuiteFactory(int countOfPipeline)
        {
            PipelinesCount = countOfPipeline;
        }

        public int PipelinesCount { get; set; }
        public List<Pipeline> GetDefaultCircuitePipelines()
        {
            List<Pipeline> pipelines = new List<Pipeline>();
            for (int i = 0; i < PipelinesCount; i++)
            {
                pipelines.Add(PipelineFactory.GetDefaultPipeline());
            }
            return pipelines;
        }
    }
}
