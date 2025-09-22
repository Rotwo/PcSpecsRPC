import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card'
import { Button } from './ui/button'
import { Clipboard, Download } from 'lucide-react'

interface ConnectionInstructionsProps {
  clientId: string
}

export default function ConnectionInstructions({
  clientId,
}: ConnectionInstructionsProps) {
  return (
    <div className="w-full mt-12 md:mt-24 flex justify-center">
      <Card className="w-full max-w-sm">
        <CardHeader>
          <CardTitle className="text-lg font-semibold flex items-center gap-2">
            Connect to the Dashboard
          </CardTitle>
        </CardHeader>
        <CardContent>
          <p className="mb-4 text-sm text-muted-foreground">
            To connect your PC, copy your Client ID and enter it in the client
            application.
          </p>
          <div className="flex items-center gap-2 w-full">
            <span className="px-2 py-1 rounded bg-muted text-xs font-mono w-full">
              {clientId}
            </span>
          </div>
        </CardContent>
        <CardFooter className="flex-col gap-2">
          <Button
            onClick={() => {
              const link = document.createElement('a')
              link.href = '/PcSpecsRPC.Client.Windows.exe'
              link.download = 'PcSpecsRPC.Client.Windows.exe'
              document.body.appendChild(link)
              link.click()
              document.body.removeChild(link)
            }}
            type="submit"
            className="w-full"
          >
            <Download size={5} />
            Download Client
          </Button>
        </CardFooter>
      </Card>
    </div>
  )
}
