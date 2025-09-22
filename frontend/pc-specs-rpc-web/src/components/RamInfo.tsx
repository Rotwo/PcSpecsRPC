import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { Zap } from 'lucide-react'

export default function RamInfo() {
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
          <p className="text-3xl font-bold text-accent">32 GB</p>
          <p className="text-sm text-muted-foreground">(32.768 MB)</p>
        </div>
      </CardContent>
    </Card>
  )
}
