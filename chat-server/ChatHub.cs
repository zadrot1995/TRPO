using System;
using System.Threading;
using System.Threading.Tasks;
using chat_server.Dtos;
using chat_server.Models;
using Microsoft.AspNetCore.SignalR;

namespace chat_server
{
    public class ChatHub : Hub<IChatHub>
    {
        public bool Started = false;
        CencelTaskModel cencelTaskModel = new CencelTaskModel(); 
        CancellationTokenSource source = new CancellationTokenSource();



        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();


        //public async Task BroadcastAsync(string message)
        //{
        //    if (message != null)
        //    {
        //        await Clients.All.MessageReceivedFromHub(message);
        //    }

        //}
        public async Task StartAsync(string connection)
        {

            PipelineDto pipelineDto = new PipelineDto();
            CencelHelper.cancelTokenSource = new CancellationTokenSource();

            Task task1 = new Task(() =>
            {
                //if (!CencelHelper.cancelTokenSource.Token.IsCancellationRequested)
                //{
                    int i = 0;
                    while (!CencelHelper.cancelTokenSource.Token.IsCancellationRequested)
                    {
                        pipelineDto.Information = i;

                        Clients.Client(connection).MessageReceivedFromHub(pipelineDto);
                        Thread.Sleep(3000);
                        i++;
                    }
                //}

            });
            task1.Start();











        }
        public void StopAsync()
        {

            CencelHelper.cancelTokenSource.Cancel();
        }
        public override async Task OnConnectedAsync()
        {
           
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
