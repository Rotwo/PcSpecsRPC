using Microsoft.AspNetCore.SignalR;
using PcSpecsRPC.Domain.Entities;

namespace PcSpecsRPC.Api.Hubs
{
    public class PcSpecsHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveClientId", Context.ConnectionId);
        }

        public async Task SendPcSpecs(PcSpecs specs)
        {
            await Clients.All.SendAsync("ReceivePcSpecs", specs);
        }
    }
}
