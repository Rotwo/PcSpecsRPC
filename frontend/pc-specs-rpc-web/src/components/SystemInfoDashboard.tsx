import type { SystemData } from '@/types'
import CpuInfo from './CpuInfo'
import OsInfo from './OsInfo'
import RamInfo from './RamInfo'

interface SystemInfoDashboardProps {
  data: SystemData | null
}

export function SystemInfoDashboard({ data }: SystemInfoDashboardProps) {
  /* const { specs } = data */

  return (
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      <CpuInfo />
      <OsInfo />
      <RamInfo />
    </div>
  )
}
