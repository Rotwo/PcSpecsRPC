import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { ScreenShare } from 'lucide-react'
import { Separator } from './ui/separator'

export default function GpuInfo() {
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

        <div className="space-y-3">
          <div>
            <p className="font-medium text-foreground">
              NVIDIA GeForce RTX 4070
            </p>
            <p className="text-muted-foreground text-xs">
              NVIDIA GeForce RTX 4070
            </p>
          </div>

          <Separator />

          <div className="grid grid-cols-1 md:grid-cols-2 gap-4 text-sm">
            <div>
              <p className="text-muted-foreground mb-1">Monitor</p>
              <p className="font-medium">HP Display</p>
              <p className="text-xs text-muted-foreground">
                Displayport external
              </p>
            </div>
            <div>
              <p className="text-muted-foreground mb-1">Actual Resolution</p>
              <p className="font-medium">1920 x 1080 (32 bit) (60Hz)</p>
              <p className="text-xs text-muted-foreground">
                Native: 1920 x 1080(p) (60.000Hz)
              </p>
            </div>
          </div>
          <div className="text-xs text-muted-foreground">
            Driver: v32.0.15.8115
          </div>
        </div>

        {/*  */}
      </CardContent>
    </Card>
  )
}
