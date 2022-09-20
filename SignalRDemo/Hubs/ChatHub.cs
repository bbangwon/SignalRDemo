using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Hubs
{
    [Authorize] //채팅은 로그인한 사용자만
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendAction", Context.User?.Identity?.Name, "Joined");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("SendAction", Context.User?.Identity?.Name, "left");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("SendMessage", Context.User?.Identity?.Name, message);
        }
    }
}
