interface SystemData {
  clientId: string
  specs: {
    cpuInfo: {
      name: string
      cores: number
      threads: number
      baseClockGHz: number
      maxClockGHz: number
    }
    osInfo: {
      name: string
      version: string
      manufacturer: string
      architecture: string
    }
    displayDeviceInfo: Array<{
      name: string
      driverVersion: string
      manufacturer: string
      dedicatedMemory: string
      currentDisplayMode: string
      monitor: {
        name: string
        model: string
        nativeMode: string
        outputType: string
      }
    }>
    ramInfo: {
      totalMemoryMb: number
      totalMemoryGb: number
    }
    soundDeviceInfo: Array<{
      description: string
      driverVersion: string
      driverProvider: string
      defaultSoundPlayback: number
      defaultVoicePlayback: number
    }>
  }
}
