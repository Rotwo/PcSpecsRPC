using PcSpecsRPC.Client.Common.DTOs;
using PcSpecsRPC.Client.Common.Interfaces;
using PcSpecsRPC.Domain.ValueObjects;
using System.Management;
using System.Runtime.InteropServices;

namespace PcSpecsRPC.Client.Windows.Services
{
    public class WindowsSystemInfoProvider : ISystemInfoProvider
    {

        public CpuInfo? GetCpuInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            CpuInfo? result = null;

            foreach (ManagementObject obj in searcher.Get())
            {
                result = new CpuInfo
                {
                    Name = obj["Name"].ToString(),
                    Cores = int.Parse(obj["NumberOfCores"].ToString()),
                    Threads = int.Parse(obj["NumberOfLogicalProcessors"].ToString()),
                    BaseClockGHz = (double)int.Parse(obj["CurrentClockSpeed"].ToString()) / 1000,
                    MaxClockGHz = (double)int.Parse(obj["MaxClockSpeed"].ToString()) / 1000,
                };
            }

            return result;
        }

        public List<DisplayDevice>? GetDisplayDevices()
        {
            DxDiagService.GenerateDiagReport();
            var displays = DxDiagService.GetDisplayDevicesFromDxDiagXml();

            return displays;
        }

        public OsInfo? GetOsInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            OsInfo? result = null;

            foreach (var obj in searcher.Get())
            {
                result = new OsInfo
                {
                    Name = obj["Caption"].ToString(),
                    Version = obj["Version"].ToString(),
                    Manufacturer = obj["Manufacturer"].ToString(),
                    Architecture = RuntimeInformation.OSArchitecture.ToString(),
                };
                break;
            }

            return result;
        }

        public RamInfo? GetRamInfo()
        {
            DxDiagService.GenerateDiagReport();
            var ram = DxDiagService.GetDeviceMemoryFromDxDiagXml();
            return ram;
        }

        public List<SoundDevice> GetSoundDevices()
        {
            DxDiagService.GenerateDiagReport();
            var soundDevices = DxDiagService.GetSoundDevicesFromDxDiagXml();

            return soundDevices;
        }

        public PcSpecsDto GetPcSpecs()
        {
            try
            {
                return new PcSpecsDto
                {
                    CpuInfo = GetCpuInfo(),
                    DisplayDeviceInfo = GetDisplayDevices(),
                    OsInfo = GetOsInfo(),
                    RamInfo = GetRamInfo(),
                    SoundDeviceInfo = GetSoundDevices()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
