import { Outlet, createRootRoute } from '@tanstack/react-router'
import { TanStackRouterDevtoolsPanel } from '@tanstack/react-router-devtools'
import { TanstackDevtools } from '@tanstack/react-devtools'
import { createSignalRContext } from 'react-signalr/signalr'

export const SignalRContext = createSignalRContext()

export const Route = createRootRoute({
  component: () => (
    <>
      <SignalRContext.Provider
        connectEnabled={true}
        url="http://localhost:5114/pcspecshub"
      >
        <Outlet />
        <TanstackDevtools
          config={{
            position: 'bottom-left',
          }}
          plugins={[
            {
              name: 'Tanstack Router',
              render: <TanStackRouterDevtoolsPanel />,
            },
          ]}
        />
      </SignalRContext.Provider>
    </>
  ),
})
