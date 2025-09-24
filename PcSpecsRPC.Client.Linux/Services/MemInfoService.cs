using System.Reflection.Metadata.Ecma335;
using PcSpecsRPC.Client.Common.Utils;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{
    internal class MemInfoService
    {
        private const string MemInfoPath = "/proc/meminfo";

        public static string ReadInfo()
        {
            using (StreamReader reader = new(MemInfoPath))
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

        public static RamInfo GetRamInfo()
        {
            var readerInfo = ReadInfo();
            var keyValuePairs = ParseInfo(readerInfo);

            Console.WriteLine(keyValuePairs.Where(x => x.Key == "cpu cores").FirstOrDefault().Key);
            
            return new RamInfo
            {
                TotalMemoryGb = SystemParserUitls.KilobytesToGigabytes(long.Parse(keyValuePairs.Where((x) => x.Key == "MemTotal").Select((x) => x.Value.Split(" ")[0]).FirstOrDefault() ?? "0")),
                TotalMemoryMb = (int)SystemParserUitls.KilobytesToMegabytes(int.Parse(keyValuePairs.Where((x) => x.Key == "MemTotal").Select((x) => x.Value.Split(" ")[0]).FirstOrDefault() ?? "0"))
            };
        }
    }
}