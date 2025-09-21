import { createFileRoute } from '@tanstack/react-router'
import logo from '../logo.svg'
import { useState } from 'react'
import { SignalRContext } from './__root'

export const Route = createFileRoute('/')({
  component: App,
})

function App() {
  const [pcSpecs, setPcSpecs] = useState()
  const [clientId, setClientId] = useState()

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
      console.log(content)
      setPcSpecs(content)
    },
    [],
  )

  return (
    <div className="p-4">
      <h1>Your client id is: {clientId}</h1>
      <p>Data received: {pcSpecs !== undefined ? 'True!' : 'false.'}</p>
      <div>
        <textarea
          name="data"
          id="data"
          className="w-full p-4 h-max bg-gray-300 rounded-lg mt-8"
          value={pcSpecs != undefined ? JSON.stringify(pcSpecs as string) : ''}
        ></textarea>
      </div>
    </div>
  )
}
