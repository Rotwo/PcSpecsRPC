import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/specs')({
  component: RouteComponent,
})

function RouteComponent() {
  return <div>Hello "/specs"!</div>
}
