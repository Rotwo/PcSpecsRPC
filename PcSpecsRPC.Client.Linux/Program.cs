using PcSpecsRPC.Client.Linux.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var systemInfoProvider = new LinuxSystemInfoProvider();
        var cpuInfo = systemInfoProvider.GetCpuInfo();

        if (cpuInfo is null) return;

        Console.WriteLine(cpuInfo.Name);
        Console.WriteLine(cpuInfo.Cores);
        Console.WriteLine(cpuInfo.Threads);
        Console.WriteLine(cpuInfo.BaseClockGHz);
        Console.WriteLine(cpuInfo.MaxClockGHz);
    }
}