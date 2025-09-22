import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { Badge } from './ui/badge'
import { Monitor } from 'lucide-react'
import type { SystemData } from '@/types'

interface OsInfoProps {
  osInfo?: SystemData['specs']['osInfo']
}

export default function OsInfo({ osInfo }: OsInfoProps) {
  return (
    <Card className="col-span-1">
      <CardHeader className="flex flex-row items-center space-y-0 pb-2">
        <CardTitle className="text-lg font-semibold flex items-center gap-2">
          <Monitor className="size-5 text-accent" />
          OS
        </CardTitle>
      </CardHeader>
      <CardContent className="space-y-3">
        <div>
          <p
            className="text-sm font-medium text-foreground truncate"
            title={osInfo?.name ?? 'Undefined'}
          >
            {osInfo?.name ?? 'Undefined'}
          </p>
        </div>

        <div className="space-y-2">
          <div className="flex justify-between">
            <span className="text-muted-foreground">Version: </span>
            <span className="font-medium">
              {osInfo?.version ?? 'Undefined'}
            </span>
          </div>
          <div className="flex justify-between">
            <span className="text-muted-foreground">Architecture: </span>
            <Badge variant="secondary">{osInfo?.architecture ?? 'Null'}</Badge>
          </div>
          <div className="flex justify-between">
            <span className="text-muted-foreground">Manufacturer: </span>
            <span className="font-medium text-sm">
              {osInfo?.manufacturer ?? 'Undefined'}
            </span>
          </div>
        </div>
      </CardContent>
    </Card>
  )
}
