using Microsoft.AspNetCore.SignalR;
using SignalR_Chat_App.Helpers;

namespace SignalR_Chat_App.Hubs
{
    public class ChatHub : Hub
    {
        private readonly DataHandler _dataHandler;

        public ChatHub(DataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public async Task SendMessage(string user, string message, DateTime sent)
        {
            DateTime recieved = DateTime.UtcNow;
            Console.WriteLine($"server forwarding message at: {(long)recieved.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds}");
            _dataHandler.AddDataItem(new DataItem
            {
                Id = Guid.NewGuid(),
                Sent = sent,
                ServerRecieved = recieved,
            });
            await Clients.All.SendAsync("ReceiveMessage", user, message, sent);
        }
    }
}
