import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { Cpu } from 'lucide-react'

export default function CpuInfo() {
  return (
    <Card className="col-span-1">
      <CardHeader className="flex flex-row items-center space-y-0 pb-2">
        <CardTitle className="text-lg font-semibold flex items-center gap-2">
          <Cpu className="size-5 text-primary" />
          CPU
        </CardTitle>
      </CardHeader>
      <CardContent className="space-y-3">
        <div>
          <p
            className="text-sm font-medium text-foreground truncate"
            title={'13th Gen Intel(R) Core(TM) i5-13600KF'}
          >
            13th Gen Intel(R) Core(TM) i5-13600KF
          </p>
        </div>

        <div className="grid grid-cols-2 gap-4 text-sm">
          <div>
            <p className="text-muted-foreground">Cores</p>
            <p className="font-medium">14</p>
          </div>
          <div>
            <p className="text-muted-foreground">Threads</p>
            <p className="font-medium">20</p>
          </div>
          <div>
            <p className="text-muted-foreground">Base Frequency</p>
            <p className="font-medium">3.5 GHz</p>
          </div>
          <div>
            <p></p>
            <p className="text-muted-foreground">Max Frequency</p>
            <p className="font-medium">3.5 GHz</p>
          </div>
        </div>
      </CardContent>
    </Card>
  )
}
