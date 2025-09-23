using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using PcSpecsRPC.Domain.ValueObjects;

namespace PcSpecsRPC.Client.Linux.Services
{
    internal class GlxService
    {
        private const string Command = "glxinfo | grep -e \"OpenGL vendor\" -e \"OpenGL renderer\" -e \"OpenGL version\"";

        public static string GenerateOutput()
        {
            var output = "";
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{Command}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();

                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }

            return output;
        }

        private static readonly string[] LineSeparators = { "\r\n", "\r", "\n" };

        public static IEnumerable<KeyValuePair<string, string>> ParseOutput(string readerInfo)
        {
            var lines = readerInfo.Split(LineSeparators, StringSplitOptions.None);
            var pairs = lines.Select((l) => l.Split(":"));
            var keyValuePairs = pairs.Select((x) => new KeyValuePair<string, string>(x[0].Trim(), x.Length > 1 ? x[1].Trim() : string.Empty));
            return keyValuePairs;
        }
    }
}