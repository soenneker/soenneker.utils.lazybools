[![](https://img.shields.io/nuget/v/soenneker.utils.lazybools.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.lazybools/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.lazybools/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.lazybools/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.lazybools.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.lazybools/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.lazybools/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.lazybools/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.LazyBools
A tiny, allocation-free, publication-only lazy initializer for bools.

## Installation

```bash
dotnet add package Soenneker.Utils.LazyBools
```

## Quick start

```csharp
using Soenneker.Utils.LazyBools;

public sealed class Feature
{
    private int _isAvailableState;

    public bool IsAvailable => LazyBoolUtil.GetOrInit(
        ref _isAvailableState,
        threadSafe: true,
        this,
        static feature => feature.CheckAvailability());

    private bool CheckAvailability() => /* expensive check */ true;
}
```

Call the static `LazyBoolUtil` methods directly; no dependency-injection registration is required.

## Semantics

`GetOrInit` stores its state in the caller-provided `int`: `0` is uninitialized, `1` is false, and
`2` is true. Initialize the field to zero and do not use or mutate it for anything else.

With `threadSafe: true`, initialization is publication-only. Concurrent callers can run `compute`
more than once, but one result is published and returned to every caller. Use a side-effect-free
or otherwise concurrency-safe delegate. If the delegate throws before a value is published, the
state remains uninitialized and a later call can retry.

Use `threadSafe: false` only when calls are single-threaded or protected by external
synchronization. That path avoids the interlocked publication operation.
