using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using chat_server.Dtos;
using chat_server.Factories;
using chat_server.Models;
using Microsoft.AspNetCore.SignalR;

namespace chat_server
{
    public class ChatHub : Hub<IChatHub>
    {
        public bool Started = false;
        CencelTaskModel cencelTaskModel = new CencelTaskModel();
        CancellationTokenSource source = new CancellationTokenSource();
        private CircuiteFactory circuiteFactory = new CircuiteFactory();
        private List<Pipeline> pipelines;

        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();


        //public async Task BroadcastAsync(string message)
        //{
        //    if (message != null)
        //    {
        //        await Clients.All.MessageReceivedFromHub(message);
        //    }

        //}
        public override Task OnDisconnectedAsync(Exception exception)
        {
            CencelHelper.cancelTokenSource.Cancel();
            return base.OnDisconnectedAsync(exception);
        }

        public async Task StartAsync(string connection)
        {
            pipelines = circuiteFactory.GetDefaultCircuitePipelines();
            CencelHelper.cancelTokenSource = new CancellationTokenSource();

            Task task1 = new Task(() =>
            {

                while (!CencelHelper.cancelTokenSource.Token.IsCancellationRequested)
                {
                    Task pipeline1Work = new Task(() =>
                    {
                        startPipeline(0, connection);
                    });
                    Task pipeline2Work = new Task(() =>
                    {
                        startPipeline(1, connection);
                    });
                    Task pipeline3Work = new Task(() =>
                    {
                        startPipeline(2, connection);
                    });
                    Task pipeline4Work = new Task(() =>
                    {
                        startPipeline(3, connection);
                    });

                    pipeline1Work.Start();
                    pipeline2Work.Start();
                    pipeline3Work.Start();
                    pipeline4Work.Start();

                    pipeline1Work.Wait();
                    pipeline2Work.Wait();
                    pipeline3Work.Wait();
                    pipeline4Work.Wait();


                }
            });
            task1.Start();
            task1.Wait();
        }
        public void StopAsync()
        {

            CencelHelper.cancelTokenSource.Cancel();
        }
        public override async Task OnConnectedAsync()
        {

        }

        private void startPipeline(int pipelineId, string connection)
        {
            

                if (!CencelHelper.cancelTokenSource.Token.IsCancellationRequested)
                {
                    for (int componentId = 0; componentId < pipelines[pipelineId].ComponentsContainer.Count; componentId++)
                    {
                        if (!CencelHelper.cancelTokenSource.Token.IsCancellationRequested)
                        {

                        
                        Clients.Client(connection).MessageReceivedFromHub(new PipelineDto { piplineId = pipelineId, componentId = componentId });
                            Circuite circuite = new Circuite();
                            pipelines[pipelineId].ComponentsContainer[componentId].Work(circuite);
                        }

                    }
                }
            
           
        }


    }

    public interface IChatHub
    {
        Task MessageReceivedFromHub(PipelineDto message);

        Task NewUserConnected(string message);
    }
    public static class CencelHelper
    {
        public static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

    }
}
