using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApp
{
    public class Notificacion : Hub
    {
        public static void SendMessage(string name, string msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<Notificacion>();
            hubContext.Clients.All.foo(name, msg);
        }
    }
}