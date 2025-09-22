import { SystemInfoDashboard } from '@/components/SystemInfoDashboard'
import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/specs')({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <main className="min-h-screen bg-background">
      <div className="container mx-auto px-4 py-8">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-foreground mb-4">
            System Specs Dashboard
          </h1>
          <div className="flex items-center gap-4 text-muted-foreground text-sm">
            <div className="flex items-center gap-2">
              <div className="size-2 rounded-full bg-red-400 animate-pulse" />
              <span>Waiting connection...</span>
            </div>
          </div>
        </div>
        <SystemInfoDashboard data={null} />
      </div>
    </main>
  )
}
