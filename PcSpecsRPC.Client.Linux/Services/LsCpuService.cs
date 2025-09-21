using System.Diagnostics;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{
    public record LsCpuRecord(string key, string value);

    internal class LsCpuService
    {
        private static bool _generatedOutput = false;
        private static bool _hasOutputBeenParsed = false;
        private static string _lsCpuOutput = "";
        private static List<LsCpuRecord> _records = new();

        public static void GenerateOutput()
        {
            if (_generatedOutput is true) return;

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "/bin/bash";
                    process.StartInfo.Arguments = "-c \"lscpu\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;

                    process.Start();

                    _lsCpuOutput = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                }

                _generatedOutput = true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static void ParseOutput()
        {
            if (_hasOutputBeenParsed is true) return;

            string[] lines = _lsCpuOutput.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<LsCpuRecord> records = new();

            foreach (var line in lines)
            {
                var split = line.Split(":");
                if (split.Length < 2) continue;
                split[1] = split[1].TrimStart();
                var record = new LsCpuRecord(split[0], split[1]);
                records.Add(record);
            }

            _records = records;
            _hasOutputBeenParsed = true;
        }

        public static CpuInfo GetCpuInfo()
        {
            return new CpuInfo
            {
                Name = _records.Find((x) => x.key.Contains("Model name")).value,
                Cores = int.Parse(_records.Find((x) => x.key.Contains("Core(s) per socket")).value),
                Threads = int.Parse(_records.Find((x) => x.key.Contains("CPU(s)")).value),
                BaseClockGHz = double.Parse(_records.Find((x) => x.key.Contains("CPU min MHz")).value),
                MaxClockGHz = double.Parse(_records.Find((x) => x.key.Contains("CPU max MHz")).value)
            };
        }
    }
}