using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Common.DTOs
{
    public class PcSpecsDto
    {
        public CpuInfo? CpuInfo { get; set; }
        public OsInfo? OsInfo { get; set; }
        public List<DisplayDevice>? DisplayDeviceInfo { get; set; }
        public RamInfo? RamInfo { get; set; }
        public List<SoundDevice>? SoundDeviceInfo { get; set; }
    }
}
