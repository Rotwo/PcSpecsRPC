import { createFileRoute } from '@tanstack/react-router'
import logo from '../logo.svg'
import { useState } from 'react'
import { SignalRContext } from './__root'

export const Route = createFileRoute('/')({
  component: App,
})

interface PcSpecs {
  clientId: string
  specs: {
    cpuInfo: {
      name: string
      cores: number
      threads: number
      baseClockGHz: number
      maxClockGHz: number
    }
    osInfo: {
      name: string
      version: string
      manufacturer: string
      architecture: string
    }
    displayDeviceInfo: Array<{
      name: string
      driverVersion: string
      manufacturer: string
      dedicatedMemory: string
      videoProcessor: string | null
      deviceId: string
      currentDisplayMode: string
      monitor: {
        name: string
        model: string
        id: string
        nativeMode: string
        outputType: string
      }
    }>
    ramInfo: {
      totalMemoryMb: number
      totalMemoryGb: number
    }
    soundDeviceInfo: Array<{
      description: string
      hardwareId: string
      driverName: string
      driverVersion: string
      driverProvider: string
      driverDate: string
      defaultSoundPlayback: number
      defaultVoicePlayback: number
    }>
  }
}

function App() {
  const [pcSpecs, setPcSpecs] = useState<PcSpecs | undefined>()
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
      console.log(content as PcSpecs)
      setPcSpecs(content as PcSpecs)
    },
    [],
  )

  return (
    <div className="p-4">
      <h1>Your client id is: {clientId}</h1>
      <p>Data received: {pcSpecs?.clientId != null ? 'Ready!' : 'Not'}</p>
      <div>
        {pcSpecs && (
          <pre
            lang="json"
            style={{
              textAlign: 'left',
              background: '#f4f4f4',
              padding: '1em',
              borderRadius: '8px',
              overflowX: 'auto',
            }}
          >
            {JSON.stringify(pcSpecs, null, 2)}
          </pre>
        )}
      </div>
    </div>
  )
}
