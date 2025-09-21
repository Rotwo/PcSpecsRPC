namespace PcSpecsRPC.Domain.ValueObjects
{
    public class SoundDevice
    {
        public string? Description { get; set; }
        public string? HardwareId { get; set; }
        public string? DriverName { get; set; }
        public string? DriverVersion { get; set; }
        public string? DriverProvider { get; set; }
        public string? DriverDate { get; set; }
        public int DefaultSoundPlayback { get; set; }
        public int DefaultVoicePlayback { get; set; }
    }
}
