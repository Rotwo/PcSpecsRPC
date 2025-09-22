import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import type { SystemData } from '@/types'
import { Cpu } from 'lucide-react'

interface CpuInfoProps {
  cpuInfo?: SystemData['specs']['cpuInfo']
}

export default function CpuInfo({ cpuInfo }: CpuInfoProps) {
  return (
    <Card className="col-span-1">
      <CardHeader className="flex flex-row items-center space-y-0 pb-2">
        <CardTitle className="text-lg font-semibold flex items-center gap-2">
          <Cpu className="size-5 text-accent" />
          CPU
        </CardTitle>
      </CardHeader>
      <CardContent className="space-y-3">
        <div>
          <p
            className="text-sm font-medium text-foreground truncate"
            title={cpuInfo?.name ?? 'Undefined'}
          >
            {cpuInfo?.name ?? 'Undefined'}
          </p>
        </div>

        <div className="grid grid-cols-2 gap-4 text-sm">
          <div>
            <p className="text-muted-foreground">Cores</p>
            <p className="font-medium">{cpuInfo?.cores ?? 'Undefined'}</p>
          </div>
          <div>
            <p className="text-muted-foreground">Threads</p>
            <p className="font-medium">{cpuInfo?.threads ?? 'Undefined'}</p>
          </div>
          <div>
            <p className="text-muted-foreground">Base Frequency</p>
            <p className="font-medium">
              {cpuInfo?.baseClockGHz ?? 'Undefined'}
            </p>
          </div>
          <div>
            <p></p>
            <p className="text-muted-foreground">Max Frequency</p>
            <p className="font-medium">{cpuInfo?.maxClockGHz ?? 'Undefined'}</p>
          </div>
        </div>
      </CardContent>
    </Card>
  )
}
