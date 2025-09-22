import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { ScreenShare } from 'lucide-react'
import { Separator } from './ui/separator'
import type { SystemData } from '@/types'

interface GpuInfoProps {
  gpuInfo?: SystemData['specs']['displayDeviceInfo']
}

export default function GpuInfo({ gpuInfo }: GpuInfoProps) {
  return (
    <Card className="col-span-1 md:col-span-2">
      <CardHeader className="flex flex-row items-center space-y-0 pb-2">
        <CardTitle className="text-lg font-semibold flex items-center gap-2">
          <ScreenShare className="size-5 text-accent" />
          Monitor & GPU
        </CardTitle>
      </CardHeader>
      <CardContent className="space-y-4">
        {/*  */}
        {gpuInfo?.map((gpu) => (
          <div className="space-y-3">
            <div>
              <p className="font-medium text-foreground">
                {gpu.name ?? 'Undefined'}
              </p>
              <p className="text-muted-foreground text-xs">
                {gpu.manufacturer ?? 'null'} • {gpu.dedicatedMemory ?? 0} MB
              </p>
            </div>

            <Separator />

            <div className="grid grid-cols-1 md:grid-cols-2 gap-4 text-sm">
              <div>
                <p className="text-muted-foreground mb-1">Monitor</p>
                <p className="font-medium">HP Display</p>
                <p className="text-xs text-muted-foreground">
                  {gpu.monitor.outputType ?? 'Undefined'}
                </p>
              </div>
              <div>
                <p className="text-muted-foreground mb-1">Actual Resolution</p>
                <p className="font-medium">{gpu.currentDisplayMode}</p>
                <p className="text-xs text-muted-foreground">
                  Native: {gpu.monitor.nativeMode}
                </p>
              </div>
            </div>
            <div className="text-xs text-muted-foreground">
              Driver: v{gpu.driverVersion}
            </div>
          </div>
        ))}

        {/*  */}
      </CardContent>
    </Card>
  )
}
