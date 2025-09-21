using PcSpecsRPC.Client.Common.DTOs;
using PcSpecsRPC.Client.Common.Interfaces;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{
    public class LinuxSystemInfoProvider : ISystemInfoProvider
    {
        public CpuInfo? GetCpuInfo()
        {
            LsCpuService.GenerateOutput();
            LsCpuService.ParseOutput();
            var cpuInfo = LsCpuService.GetCpuInfo();
            return cpuInfo;
        }

        public List<DisplayDevice>? GetDisplayDevices()
        {
            throw new NotImplementedException();
        }

        public OsInfo? GetOsInfo()
        {
            throw new NotImplementedException();
        }

        public PcSpecsDto GetPcSpecs()
        {
            throw new NotImplementedException();
        }

        public RamInfo? GetRamInfo()
        {
            throw new NotImplementedException();
        }

        public List<SoundDevice> GetSoundDevices()
        {
            throw new NotImplementedException();
        }
    }
}
