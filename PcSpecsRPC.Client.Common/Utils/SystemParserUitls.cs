namespace PcSpecsRPC.Client.Common.Utils
{
    public static class SystemParserUitls
    {
        public static int? ExtractNumbers(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (input.Equals("None", StringComparison.OrdinalIgnoreCase)) return null;

            string digitsOnly = new string(input.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(digitsOnly)) return null;

            if (int.TryParse(digitsOnly, out int result))
            {
                return result;
            }

            return null;
        }

        public static int? MbToGb(int input)
        {
            return (int)Math.Floor((double)(input / 1024.0));
        }

        public static int GbToMb(int input)
        {
            return input * 1024;
        }

        public static double KilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024.0;
        }
        
        public static int KilobytesToGigabytes(long kilobytes)
        {
            double megabytes = KilobytesToMegabytes(kilobytes);
            int gigabytes = (int)Math.Ceiling(megabytes / 1024.0);
            return gigabytes;
        }
    }
}
