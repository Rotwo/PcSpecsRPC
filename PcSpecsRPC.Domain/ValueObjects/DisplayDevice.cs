namespace PcSpecsRPC.Domain.ValueObjects
{
    public class DisplayDevice
    {
        public string? Name { get; set; }
        public string? DriverVersion { get; set; }
        public string? Manufacturer { get; set; }
        public string? DedicatedMemory { get; set; }
        public string? VideoProcessor { get; set; }
        public string? DeviceId { get; set; }
        public string? CurrentDisplayMode { get; set; }
        public Monitor? Monitor { get; set; }
    }

    public class Monitor
    {
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? Id { get; set; }
        public string? NativeMode { get; set; }
        public string? OutputType { get; set; }
    }
}
