# Module lifecycle refactor notes

This branch refactors module execution ownership so `ModuleSupervisor` coordinates lifecycle while each module owns its own loop, delay, blocking behavior, and concurrency.

The accompanying ADR contains the durable architectural decision. This note can be removed before merge if the pull request description is sufficient.
