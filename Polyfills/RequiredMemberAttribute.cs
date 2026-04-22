#if !NET7_0_OR_GREATER

using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[AttributeUsage(
    AttributeTargets.Class |
    AttributeTargets.Field |
    AttributeTargets.Property |
    AttributeTargets.Struct)]
[Embedded]
internal sealed class RequiredMemberAttribute : Attribute;

#endif
