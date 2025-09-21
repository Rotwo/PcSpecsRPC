using PcSpecsRPC.Client.Common.DTOs;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Common.Interfaces
{
    public interface ISystemInfoProvider
    {
        CpuInfo? GetCpuInfo();
        List<DisplayDevice>? GetDisplayDevices();
        RamInfo? GetRamInfo();
        OsInfo? GetOsInfo();
        List<SoundDevice> GetSoundDevices();

        PcSpecsDto GetPcSpecs();
    }
}
