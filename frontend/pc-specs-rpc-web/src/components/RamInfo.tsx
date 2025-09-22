import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import type { SystemData } from '@/types'
import { Zap } from 'lucide-react'

interface RamInfoProps {
  ramInfo?: SystemData['specs']['ramInfo']
}

export default function RamInfo({ ramInfo }: RamInfoProps) {
  return (
    <Card className="col-span-1">
      <CardHeader className="flex flex-row items-center space-y-0 pb-2">
        <CardTitle className="text-lg font-semibold flex items-center gap-2">
          <Zap className="size-5 text-accent" />
          RAM Memory
        </CardTitle>
      </CardHeader>
      <CardContent className="space-y-3">
        <div className="text-center">
          <p className="text-3xl font-bold text-accent">
            {ramInfo?.totalMemoryGb ?? 0} GB
          </p>
          <p className="text-sm text-muted-foreground">
            ({ramInfo?.totalMemoryMb ?? 0} MB)
          </p>
        </div>
      </CardContent>
    </Card>
  )
}
