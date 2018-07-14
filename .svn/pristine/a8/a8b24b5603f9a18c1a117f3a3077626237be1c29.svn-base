using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace quickinfo_v2
{
    [SignalR.Hubs.HubName("ChatHub")]
    public class ChatHub : SignalR.Hubs.Hub
    {
        /// <summary>
        /// Broadcast the message to all clients
        /// </summary>
        /// <param name="message">message to be broadcasted</param>
        public void Broadcast(string message)
        {
            this.Clients.showMessage(message);
        }

        public void Broadcast(string message, string from, string to, string id)
        {
            this.Clients.showMessage(message, from, to, id);
        }


        /// <summary>
        /// Return a string with the formate, Hello [current user name]
        /// </summary>
        /// <returns></returns>
        public string SayHello()
        {
            //Context property can be used to retreive HTTP attributes like User
            return "Hello " + Context.User.Identity.Name;
        }

        /// <summary>
        /// Simulates a long running process that updates its progress
        /// </summary>
        public void LongRunningMethod()
        {
            Thread.Sleep(1000);
            this.Caller.showMessage("25% Completed");
            Thread.Sleep(1000);
            this.Caller.showMessage("50% Completed");
            Thread.Sleep(1000);
            this.Caller.showMessage("75% Completed");
            Thread.Sleep(1000);
            this.Caller.showMessage("Done");
        }

        /// <summary>
        /// Subscribe to a given message category
        /// </summary>
        /// <param name="category">the category to subscribe</param>
        public void Subscribe(string category)
        {
            //Add current connection to a connection group with the name 'category'
            this.AddToGroup(category);
        }

        private void AddToGroup(string category)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publish a message to the given mmessage category
        /// </summary>
        /// <param name="category">the category to send the message</param>
        /// <param name="message">the message to be sent</param>
        public void Publish(string category, string message)
        {
            //Broadcast the message to all connections registered under the group 'category'
            this.Clients[category].showMessage(message);
        }
    }
}