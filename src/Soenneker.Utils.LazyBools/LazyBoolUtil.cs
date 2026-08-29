using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Soenneker.Utils.LazyBools;

/// <summary>
/// Provides allocation-free lazy initialization for boolean values
/// using a tri-state integer field (0 = unknown, 1 = false, 2 = true).
/// </summary>
public static class LazyBoolUtil
{
    /// <summary>
    /// Gets the cached boolean value or computes and publishes it if uninitialized.
    /// </summary>
    /// <returns>The the cached boolean value or computes and publishes it if uninitialized.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool GetOrInit<TState>(ref int state, bool threadSafe, TState arg, Func<TState, bool> compute)
    {
        int s = Volatile.Read(ref state);

        if (s != 0)
            return s == 2;

        bool value = compute(arg);
        int newState = value ? 2 : 1;

        if (!threadSafe)
        {
            state = newState;
            return value;
        }

        Interlocked.CompareExchange(ref state, newState, 0);
        return value;
    }
}