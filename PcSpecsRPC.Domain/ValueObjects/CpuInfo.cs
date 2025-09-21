namespace PcSpecsRPC.Domain.ValueObjects
{
    public class CpuInfo
    {
        public string? Name { get; set; }
        public int? Cores { get; set; }
        public int? Threads { get; set; }
        public double? BaseClockGHz { get; set; }
        public double? MaxClockGHz { get; set; }
    }
}
