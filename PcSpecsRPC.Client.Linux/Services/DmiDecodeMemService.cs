using System.Diagnostics;
using PcSpecsRPC.Client.Common.Utils;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{

    internal class DmiDecodeMemService
    {
        private static bool _generatedOutput = false;
        private static bool _hasOutputBeenParsed = false;
        private static string _dmiDecodeMemOutput = "";
        private static List<LsCpuRecord> _records = new();

        public static void GenerateOutput()
        {
            if (_generatedOutput is true) return;

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "/bin/bash";
                    process.StartInfo.Arguments = "-c \"dmidecode -t memory\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;

                    process.Start();

                    _dmiDecodeMemOutput = process.StandardOutput.ReadToEnd();
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

            string[] lines = _dmiDecodeMemOutput.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<LsCpuRecord> records = new();

            foreach (var line in lines)
            {
                var split = line.Split(":");
                if (split.Length < 2) continue;
                if (split[1] is null) split[1] = "null";
                split[1] = split[1].TrimStart();
                var record = new LsCpuRecord(split[0], split[1]);
                records.Add(record);
            }

            _records = records;
            _hasOutputBeenParsed = true;
        }

        public static RamInfo GetRamInfo()
        {
            var total = _records
            .FindAll(x => x.key.Trim().Equals("Size") && 
                         !string.IsNullOrEmpty(x.value) && 
                         !x.value.Equals("null", StringComparison.OrdinalIgnoreCase))
            .Select(x => SystemParserUitls.ExtractNumbers(x.value))
            .Where(x => x.HasValue)
            .Sum(x => x.Value);
            
            return new RamInfo
            {
                TotalMemoryGb = total,
                TotalMemoryMb = SystemParserUitls.GbToMb(total)
            };
        }
    }
}