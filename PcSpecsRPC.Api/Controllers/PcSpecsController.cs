using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PcSpecsRPC.Api.Hubs;
using PcSpecsRPC.Client.Common.Requests;
using PcSpecsRPC.Client.Common.Responses;
using PcSpecsRPC.Domain.Entities;

namespace PcSpecsRPC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PcSpecsController
    {
        private readonly IHubContext<PcSpecsHub> _context;

        public PcSpecsController(IHubContext<PcSpecsHub> context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<SpecResultResponse> Post([FromBody] SendSpecRequest pcSpecs)
        {
            await _context.Clients.Client(pcSpecs.ClientId).SendAsync("ReceivePcSpecs", pcSpecs);
            return new SpecResultResponse
            {
                Message = "Sended!",
                Success = true,
                ReceivedAt = DateTime.UtcNow,
            };
        }
    }
}
