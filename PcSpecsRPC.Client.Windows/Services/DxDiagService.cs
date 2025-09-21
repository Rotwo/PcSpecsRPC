using PcSpecsRPC.Client.Windows.Utils;
using PcSpecsRPC.Domain.ValueObjects;
using System.Diagnostics;
using System.Xml.Linq;

namespace PcSpecsRPC.Client.Windows.Services
{
    internal class DxDiagService
    {
		private const string TempFolderName = "pcspecsrpc";
		private const string DiagReportFileName = "diag_result.xml";

        private static bool _generatedDxDiagReport = false;

        private static string GetDiagReportDirectory()
        {
            return Path.Join(Path.GetTempPath(), TempFolderName);
        }

        private static string GetDiagReportFilePath()
        {
            return Path.Join(Path.GetTempPath(), TempFolderName, DiagReportFileName);
        }

        public static void GenerateDiagReport()
        {
            if (_generatedDxDiagReport is true) return;

			try
			{
                var directory = GetDiagReportDirectory();
                var filePath = GetDiagReportFilePath();

                Console.WriteLine(directory);
                Console.WriteLine(filePath);

                if (!Directory.Exists(filePath)) Directory.CreateDirectory(directory);

				using (Process process = new Process())
				{
					process.StartInfo.FileName = "cmd.exe";
					process.StartInfo.Arguments = $"/c dxdiag /x \"{filePath}\"";
                    process.StartInfo.UseShellExecute = false;
					process.StartInfo.CreateNoWindow = true;

					process.Start();
                    process.WaitForExit();
				}


                Console.WriteLine("Waiting for DxDiag file report...");
                do
                {
                    Thread.Sleep(250);
                }
                while (!File.Exists(filePath));


                _generatedDxDiagReport = true;
                Console.WriteLine($"Saved diag report to => {GetDiagReportFilePath()}");
			}
			catch (Exception)
			{

				throw;
			}
        }

        public static List<DisplayDevice> GetDisplayDevicesFromDxDiagXml()
        {
            var doc = XDocument.Load(GetDiagReportFilePath());
            var gpus = new List<DisplayDevice>();

            var displayDevices = doc.Descendants("DisplayDevices").Descendants("DisplayDevice");

            foreach (var device in displayDevices)
            {
                var gpu = new DisplayDevice
                {
                    Name = device.Element("CardName")?.Value,
                    Manufacturer = device.Element("Manufacturer")?.Value,
                    DedicatedMemory = device.Element("DedicatedMemory")?.Value,
                    DriverVersion = device.Element("DriverVersion")?.Value,
                    CurrentDisplayMode = device.Element("CurrentMode")?.Value,
                    DeviceId = device.Element("DeviceIdentifier")?.Value,
                    Monitor = new Domain.ValueObjects.Monitor
                    {
                        Id = device.Element("MonitorId")?.Value,
                        Model = device.Element("MonitorModel")?.Value,
                        Name = device.Element("MonitorName")?.Value,
                        NativeMode = device.Element("NativeMode")?.Value,
                        OutputType = device.Element("OutputType")?.Value
                    }
                };

                if (!string.IsNullOrEmpty(gpu.Name))
                    gpus.Add(gpu);
            }

            return gpus;
        }

        public static List<SoundDevice> GetSoundDevicesFromDxDiagXml()
        {
            var doc = XDocument.Load(GetDiagReportFilePath());
            var devices = new List<SoundDevice>();

            var soundDevices = doc.Descendants("SoundDevices").Descendants("SoundDevice");

            foreach (var device in soundDevices)
            {
                var _device = new SoundDevice
                {
                    Description = device.Element("Description")?.Value,
                    HardwareId = device.Element("HardwareID")?.Value,
                    DriverName = device.Element("DriverName")?.Value,
                    DriverVersion = device.Element("DriverVersion")?.Value,
                    DriverProvider = device.Element("DriverProvider")?.Value,
                    DriverDate = device.Element("DriverDate")?.Value,
                    DefaultSoundPlayback = int.TryParse(device.Element("DefaultSoundPlayback")?.Value, out var dsp) ? dsp : 0,
                    DefaultVoicePlayback = int.TryParse(device.Element("DefaultVoicePlayback")?.Value, out var dvp) ? dvp : 0
                };

                if (!string.IsNullOrEmpty(_device.Description))
                    devices.Add(_device);
            }

            return devices;
        }
    
        public static RamInfo GetDeviceMemoryFromDxDiagXml()
        {
            var doc = XDocument.Load(GetDiagReportFilePath());

            var systemInfo = doc.Descendants("SystemInformation").FirstOrDefault();

            var ramInfo = new RamInfo
            {
                TotalMemoryMb = SystemParserUitls.ExtractNumbers(systemInfo.Element("Memory")?.Value),
                TotalMemoryGb = SystemParserUitls.MbToGb(SystemParserUitls.ExtractNumbers(systemInfo.Element("Memory")?.Value) ?? 0)
            };

            return ramInfo;
        }

    }
}
