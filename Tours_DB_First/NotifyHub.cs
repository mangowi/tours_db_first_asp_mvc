﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Tours_DB_First
{
    public class NotifyHub : Hub
    {
        public void SendNotification(string message)
        {
            Clients.Others.showNotification(message);
        }
    }
}