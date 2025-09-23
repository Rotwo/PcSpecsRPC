using System.Reflection.Metadata.Ecma335;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{
    internal class CpuInfoService
    {
        private const string CpuInfoPath = "/proc/cpuinfo";

        public static string ReadInfo()
        {
            using (StreamReader reader = new(CpuInfoPath))
            {
                var result = reader.ReadToEnd();
                return result;
            }
        }

        private static readonly string[] LineSeparators = { "\r\n", "\r", "\n" };

        public static IEnumerable<KeyValuePair<string, string>> ParseInfo(string readerInfo)
        {
            var lines = readerInfo.Split(LineSeparators, StringSplitOptions.None);
            var pairs = lines.Select((l) => l.Split(":"));
            var keyValuePairs = pairs.Select((x) => new KeyValuePair<string, string>(x[0].Trim(), x.Length > 1 ? x[1].Trim() : string.Empty));
            return keyValuePairs;
        }

        public static CpuInfo GetInfo()
        {
            var readerInfo = ReadInfo();
            var keyValuePairs = ParseInfo(readerInfo);

            Console.WriteLine(keyValuePairs.Where(x => x.Key == "cpu cores").FirstOrDefault().Key);
            
            return new CpuInfo
            {
                Name = keyValuePairs.Where(x => x.Key == "model name").FirstOrDefault().Value,
                Cores = keyValuePairs.Where(x => x.Key == "processor").Count(),
                Threads = int.Parse(keyValuePairs.Where(x => x.Key == "cpu cores").FirstOrDefault().Value),
                BaseClockGHz = -1,
                MaxClockGHz = -1
            };
        }
    }
}