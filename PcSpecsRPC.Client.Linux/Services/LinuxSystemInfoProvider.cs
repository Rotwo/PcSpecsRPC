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
            /* LsCpuService.GenerateOutput();
            LsCpuService.ParseOutput();
            var cpuInfo = LsCpuService.GetCpuInfo();
            return cpuInfo; */
            return CpuInfoService.GetInfo();
        }

        public List<DisplayDevice>? GetDisplayDevices()
        {
            var output = GlxService.GenerateOutput();
            var keyValuePairs = GlxService.ParseOutput(output);

            var gpus = new List<DisplayDevice>();
            var gpu = new DisplayDevice()
            {
                Manufacturer = keyValuePairs.Where(x => x.Key.Contains("OpenGL vendor")).FirstOrDefault().Value,
                DriverVersion = keyValuePairs.Where(x => x.Key.Contains("OpenGL version")).FirstOrDefault().Value,
                Name = keyValuePairs.Where(x => x.Key.Contains("OpenGL renderer")).FirstOrDefault().Value,
                CurrentDisplayMode = "Undefined",
                DedicatedMemory = "Undefined",
                DeviceId = "Undefined",
                Monitor = new Domain.ValueObjects.Monitor()
                {
                    Id = "Undefined",
                    Model = "Undefined",
                    Name = "Undefined",
                    NativeMode = "Undefined",
                    OutputType = "Undefined",
                },
                VideoProcessor = "Undefined"
            };

            gpus.Add(gpu);
            return gpus;
        }

        public OsInfo? GetOsInfo()
        {
            OsInfoService.GenerateOutput();
            OsInfoService.ParseOutput();
            var osInfo = OsInfoService.GetOsInfo();
            return osInfo;
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
                OsInfo = GetOsInfo(),
                DisplayDeviceInfo = GetDisplayDevices()
            };
        }
    }
}
