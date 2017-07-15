using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Tours_DB_First
{
    public class LiveHelpTour : Hub
    {
        public void SendMessage(string username, SemaphoreRights message)
        {
            Clients.All.showMessage(username, message);
            Groups.Add(Context.ConnectionId, "Employees");
            Clients.Group("Employees").showMessage(username, "Message for Employees: This is how to send message to specifc users");

            Clients.Caller.showMessage("System", "Yout message was sent at " + DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}