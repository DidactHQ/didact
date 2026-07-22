# ADR-001: Module lifecycle ownership

## Status

Proposed

## Context

`ModuleSupervisor` previously owned every module's loop, concurrency, delay, and restart behavior while `IModule.ExecuteAsync` represented either a single polling iteration or an entire blocking lifetime depending on the module. This made the contract ambiguous and forced unrelated module types into the same execution model.

## Decision

- `IModule.RunAsync` represents the complete module lifetime.
- Modules own their internal loops, delays, blocking behavior, and concurrency.
- `ModuleSupervisor` initializes modules in dependency order, starts them, observes their lifetime tasks, and coordinates engine-wide cancellation.
- `IPollingModule` identifies bounded polling modules and exposes a `PollingInterval`.
- `ILongRunningModule` identifies continuously blocking modules.
- Polling failures are fatal by default. Concrete modules may explicitly override transient-failure handling only when they can safely recover.
- Any module that exits before engine cancellation is considered failed.
- A fatal module failure cancels the remaining modules and is rethrown to the host.
- Module startup dependencies are explicit and topologically sorted. Missing, disabled, or circular dependencies fail engine startup.

## Consequences

- The supervisor no longer understands worker counts or polling intervals.
- Worker concurrency belongs to `WorkersModule`.
- Channel readers are modeled as long-running modules instead of polling modules.
- Scheduler and plugin synchronization are modeled as polling modules.
- Graceful stop phases and drain policies can be added later without changing the lifetime meaning of `RunAsync`.
