using System.Diagnostics;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{
    public record OsInfoRecord(string key, string value);

    internal class OsInfoService
    {
        private const string Cmd = "grep -E '^(VERSION|NAME)=' /etc/os-release";

        private static bool _generatedOutput = false;
        private static bool _hasOutputBeenParsed = false;
        private static string _cmdOutput = "";
        private static List<OsInfoRecord> _records = new();

        public static void GenerateOutput()
        {
            if (_generatedOutput is true) return;

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "/bin/bash";
                    process.StartInfo.Arguments = $"-c \"{Cmd}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;

                    process.Start();

                    _cmdOutput = process.StandardOutput.ReadToEnd();
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

            string[] lines = _cmdOutput.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<OsInfoRecord> records = new();

            foreach (var line in lines)
            {
                var split = line.Split("=");
                if (split.Length < 2) continue;
                split[1] = split[1].TrimStart().Trim('"');
                var record = new OsInfoRecord(split[0], split[1]);
                records.Add(record);
            }

            _records = records;
            _hasOutputBeenParsed = true;
        }

        public static OsInfo GetOsInfo()
        {
            return new OsInfo
            {
                Name = _records.Find((x) => x.key.Equals("NAME")).value,
                Version = _records.Find((x) => x.key.Equals("VERSION")).value,
                Architecture = Environment.Is64BitOperatingSystem ? "X64" : "X32"
            };
        }
    }
}