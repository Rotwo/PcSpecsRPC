using PcSpecsRPC.Client.Common.Requests;
using PcSpecsRPC.Client.Common.Services;
using PcSpecsRPC.Client.Linux.Services;

internal class Program
{
    public static bool IsAdministrator => Mono.Unix.Native.Syscall.geteuid() == 0;

    private async static Task Main(string[] args)
    {
        var systemInfoProvider = new LinuxSystemInfoProvider(isRoot: IsAdministrator);

        Console.WriteLine("Welcome to the Client of PcSpecsRPC WEB UI\n");

        var output = AskClientId();
        var specs = systemInfoProvider.GetPcSpecs();

        var request = new SendSpecRequest
        {
            ClientId = output,
            Specs = specs
        };

        var api = new ApiClient("http://localhost:5114");
        var response = await api.SendSpecsAsync(request);

        Console.WriteLine($"Success: {response.Success}, Msg: {response.Message}");
    }

    private static string AskClientId()
    {
        Console.WriteLine("Please enter your unique session id");

        string? output;

        do
        {
            Console.Write("> ");
            output = Console.ReadLine();
        }
        while (string.IsNullOrEmpty(output));

        return output;
    }
}