using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Domain.Entities
{
    public class PcSpecs
    {
        public CpuInfo CpuInfo { get; set; }
        public OsInfo OsInfo { get; set; }
        public List<DisplayDevice> DisplayDeviceInfo { get; set; }
        public RamInfo RamInfo { get; set; }
        public List<SoundDevice> SoundDeviceInfo { get; set; }
    }
}
