using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Server.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Server
{
    public class HomeController : Controller
    {
        private readonly IHubContext<NotifyHub> _hubContext;

        public HomeController(IHubContext<NotifyHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            await _hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");
            return null;
        }
    }
}
