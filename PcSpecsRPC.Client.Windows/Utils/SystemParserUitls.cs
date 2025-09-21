namespace PcSpecsRPC.Client.Windows.Utils
{
    public static class SystemParserUitls
    {
        public static int? ExtractNumbers(string? input)
        {
            if (input is null) return null;

            string digitsOnly = new string(input.Where(char.IsDigit).ToArray());
            int ramMb = int.Parse(digitsOnly);
            return ramMb;
        }

        public static int? MbToGb(int input)
        {
            return (int)Math.Floor((double)(input / 1024.0));
        }
    }
}
