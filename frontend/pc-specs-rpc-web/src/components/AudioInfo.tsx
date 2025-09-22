import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { Volume2 } from 'lucide-react'
import { Separator } from './ui/separator'
import type { SystemData } from '@/types'

interface AudioInfoProps {
  audioInfo?: SystemData['specs']['soundDeviceInfo']
}

export default function AudioInfo({ audioInfo }: AudioInfoProps) {
  return (
    <Card className="col-span-1">
      <CardHeader className="flex flex-row items-center space-y-0 pb-2">
        <CardTitle className="text-lg font-semibold flex items-center gap-2">
          <Volume2 className="size-5 text-accent" />
          Audio Devices
        </CardTitle>
      </CardHeader>
      <CardContent className="space-y-3">
        {audioInfo?.map((audioDevice, index) => (
          <>
            <div>
              <p className="font-medium">{audioDevice.description}</p>
              <p className="text-xs text-muted-foreground">
                {audioDevice.driverProvider}
              </p>
            </div>

            {index < audioInfo.length - 1 && <Separator />}
          </>
        ))}
      </CardContent>
    </Card>
  )
}
