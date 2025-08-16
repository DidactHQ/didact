# Didact
The .NET job orchestrator that we've been missing.

## About

This is the monorepo for Didact and it's primary components, namely:
- Didact CLI 
- Didact Core
- Didact Engine
- Didact UI

Originally, I had anticipated a polyrepo approach, but I have since decided against it. The older component repositories are archived, so please refer to this repository for the main platform components. I do still have some separate repositories such as the dedicated repository for the [Didact docsite](https://docs.didact.dev), please refer to the other repositories as necessary.

## Releases and Artifacts

This repository will contain the platform releases and release artifacts for Didact, namely, the application binaries/executables. The CI/CD automations will also produce the associated NuGet packages and Docker images from here.

## Documentation

Rather than create complex README files, I prefer to keep these shorter for now and instead refer you to the [Didact docsite](https://docs.didact.dev) for learning the platform.