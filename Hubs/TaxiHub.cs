using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace Taxi_Backend.Hubs
{
    public class TaxiHub : Hub
    {
        //Not being used
        public Task SendMessage(string connectionID, string trip)
        {

            //await Clients.Client(connectionId: connectionID).SendAsync("Taxi", trip);
            return Clients.All.SendAsync("Taxi", trip);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
