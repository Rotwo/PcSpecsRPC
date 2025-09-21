using PcSpecsRPC.Client.Linux.Services;

internal class Program
{
    public static bool IsAdministrator => Mono.Unix.Native.Syscall.geteuid() == 0;

    private static void Main(string[] args)
    {
        if (IsAdministrator is not true)
        {
            Console.WriteLine("This program must be runned as root!");
            Console.WriteLine("Please try to run again using sudo.");
            throw new SystemException("Program must be runned as root");
        }

        var systemInfoProvider = new LinuxSystemInfoProvider();
        var cpuInfo = systemInfoProvider.GetCpuInfo();

        if (cpuInfo is null) return;

        Console.WriteLine(cpuInfo.Name);
        Console.WriteLine(cpuInfo.Cores);
        Console.WriteLine(cpuInfo.Threads);
        Console.WriteLine(cpuInfo.BaseClockGHz);
        Console.WriteLine(cpuInfo.MaxClockGHz);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        var ramInfo = systemInfoProvider.GetRamInfo();
        Console.WriteLine(ramInfo.TotalMemoryGb);
        Console.WriteLine(ramInfo.TotalMemoryMb);
    }
}