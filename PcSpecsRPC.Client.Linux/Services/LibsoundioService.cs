using SoundIOSharp;

namespace PcSpecsRPC.Client.Linux.Services
{
    internal class LibsoundioService
    {
        private static SoundIO api;

        public LibsoundioService()
        {
            Setup();
        }

        static void Setup()
        {
            api = new SoundIO();
            SoundIOBackend be = SoundIOBackend.None;

            if (be == SoundIOBackend.None)
                api.Connect();
            else
                api.ConnectBackend(be);

            api.FlushEvents();
        }

        public static SoundIODevice[] ListOutputAudioDevices()
        {
            if (api == null) Setup();

            var soundDevices = new SoundIODevice[api.OutputDeviceCount];

            for (int i = 0; i < api.OutputDeviceCount; i++)
                soundDevices[i] = api.GetOutputDevice(i);

            return soundDevices;     
        }

		static void PrintDevice (SoundIODevice dev)
		{
			Console.WriteLine ($"  {dev.Id} - {dev.Name}");
			foreach (var pi in typeof (SoundIODevice).GetProperties ())
				Console.WriteLine ($"    {pi.Name}: {pi.GetValue (dev)}");
		}

    }
}