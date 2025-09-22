import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { Volume2 } from 'lucide-react'
import { Separator } from './ui/separator'

export default function AudioInfo() {
  return (
    <Card className="col-span-1">
      <CardHeader className="flex flex-row items-center space-y-0 pb-2">
        <CardTitle className="text-lg font-semibold flex items-center gap-2">
          <Volume2 className="size-5 text-accent" />
          Audio Devices
        </CardTitle>
      </CardHeader>
      <CardContent className="space-y-3">
        {/*  */}
        <div>
          <p className="font-medium">Altavoces (Steam Streaming Microphone)</p>
          <p className="text-xs text-muted-foreground">Valve Corporation</p>
        </div>
        <Separator />
        <div>
          <p className="font-medium">Auriculares (HUAWEI FreeBuds 4i)</p>
          <p className="text-xs text-muted-foreground">Microsoft</p>
        </div>
        <Separator />
        <div>
          <p className="font-medium">
            Realtek Digital Output (Realtek(R) Audio)
          </p>
          <p className="text-xs text-muted-foreground">
            Realtek Semiconductor Corp.
          </p>
        </div>

        {/*  */}
      </CardContent>
    </Card>
  )
}
