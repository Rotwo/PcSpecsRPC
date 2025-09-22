import type { SystemData } from '@/types'
import CpuInfo from './CpuInfo'
import OsInfo from './OsInfo'
import RamInfo from './RamInfo'
import GpuInfo from './GpuInfo'
import AudioInfo from './AudioInfo'

interface SystemInfoDashboardProps {
  data: SystemData
}

export function SystemInfoDashboard({ data }: SystemInfoDashboardProps) {
  /* const { specs } = data */

  return (
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      <CpuInfo cpuInfo={data.specs.cpuInfo} />
      <OsInfo osInfo={data.specs.osInfo} />
      <RamInfo ramInfo={data.specs.ramInfo} />
      <GpuInfo gpuInfo={data.specs.displayDeviceInfo} />
      <AudioInfo audioInfo={data.specs.soundDeviceInfo} />
    </div>
  )
}
