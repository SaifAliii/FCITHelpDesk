using Microsoft.AspNetCore.SignalR;
namespace WebApplication1.Hubs
{
    public class MyHub: Hub
    {
        public async Task sendMessage(string message)
        {
            await Clients.All.SendAsync("Recieve Message", message);

        }
    }
}
