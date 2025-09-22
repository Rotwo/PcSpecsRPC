using PcSpecsRPC.Client.Common.DTOs;
using PcSpecsRPC.Client.Common.Interfaces;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{
    public class LinuxSystemInfoProvider(bool isRoot = false) : ISystemInfoProvider
    {
        private readonly bool _isRoot = isRoot;

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

        public RamInfo? GetRamInfo()
        {
            DmiDecodeMemService.GenerateOutput();
            DmiDecodeMemService.ParseOutput();
            var ramInfo = DmiDecodeMemService.GetRamInfo();

            return ramInfo;
        }

        public List<SoundDevice> GetSoundDevices()
        {
            throw new NotImplementedException();
        }

        public PcSpecsDto GetPcSpecs()
        {
            return new PcSpecsDto
            {
                CpuInfo = GetCpuInfo(),
                RamInfo = _isRoot ? GetRamInfo() : null,
            };
        }
    }
}
