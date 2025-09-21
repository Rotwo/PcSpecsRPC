using PcSpecsRPC.Client.Common.DTOs;

namespace PcSpecsRPC.Client.Common.Requests
{
    public class SendSpecRequest
    {
        public string ClientId { get; set; }
        public PcSpecsDto Specs { get; set; }
    }
}
