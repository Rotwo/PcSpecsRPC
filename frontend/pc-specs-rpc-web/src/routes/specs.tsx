import { SystemInfoDashboard } from '@/components/SystemInfoDashboard'
import { createFileRoute } from '@tanstack/react-router'
import { SignalRContext } from './__root'
import { useState } from 'react'
import type { SystemData } from '@/types'
import ConnectionInstructions from '@/components/ConnectionInstructions'

export const Route = createFileRoute('/specs')({
  component: RouteComponent,
})

function RouteComponent() {
  const [systemData, setSystemData] = useState<SystemData | undefined>()
  const [clientId, setClientId] = useState<string | undefined>()

  SignalRContext.useSignalREffect(
    'ReceiveClientId',
    (id: string) => {
      console.log('My client ID:', id)
      setClientId(id)
    },
    [],
  )

  SignalRContext.useSignalREffect(
    'ReceivePcSpecs',
    (content) => {
      setSystemData(content as SystemData)
    },
    [],
  )

  return (
    <main className="min-h-screen bg-background">
      <div className="container mx-auto px-4 py-8">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-foreground mb-4">
            System Specs Dashboard
          </h1>
          <div className="flex items-center gap-4 text-muted-foreground text-sm">
            <div className="flex items-center gap-2">
              {!systemData && (
                <div className="size-2 rounded-full bg-red-400 animate-pulse" />
              )}
              {systemData && (
                <div className="size-2 rounded-full bg-green-400 animate-pulse" />
              )}

              <span>{!systemData ? 'Waiting connection...' : 'Connected'}</span>
            </div>
          </div>
        </div>
        {systemData && <SystemInfoDashboard data={systemData} />}
        {!systemData && (
          <ConnectionInstructions
            clientId={clientId || 'Error while getting client id'}
          />
        )}
      </div>
    </main>
  )
}
