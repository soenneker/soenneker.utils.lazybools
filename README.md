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
```

Call the static `LazyBoolUtil` methods directly; no dependency-injection registration is required.

## Common operations

- `GetOrInit()` - Gets the cached boolean value or computes and publishes it if uninitialized.
