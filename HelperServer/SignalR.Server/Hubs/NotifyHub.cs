using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Server.Hubs
{
    public class NotifyHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Client("").SendAsync("ReceiveMessage", user, message);
        }
        //------------------------Server侧接口---------------------------
        private static string CommanderID = "";
        public async Task RegisterCommander()
        {
        }
        //------------------------Client侧接口---------------------------

        public async Task RegisterDevice()
        {

        }
    }
}
