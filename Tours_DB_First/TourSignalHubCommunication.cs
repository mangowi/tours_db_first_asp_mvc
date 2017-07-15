using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Tours_DB_First
{
    public class TourSignalHubCommunication : Hub
    {
        public void Hello()
        {
            Clients.All.introduce("Hello Tours this is SignalR");
        }
    }
}