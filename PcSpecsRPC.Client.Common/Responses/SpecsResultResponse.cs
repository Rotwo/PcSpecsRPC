namespace PcSpecsRPC.Client.Common.Responses
{
    public class SpecResultResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
