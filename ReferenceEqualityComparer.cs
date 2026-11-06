using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WpfHotReload.Runtime;

/// <summary>Compares objects by identity while walking overlapping WPF visual and logical trees.</summary>
internal sealed class ReferenceEqualityComparer : IEqualityComparer<object>
{
    internal static ReferenceEqualityComparer Instance { get; } = new();

    public new bool Equals(object? x, object? y) => ReferenceEquals(x, y);

    public int GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
}
