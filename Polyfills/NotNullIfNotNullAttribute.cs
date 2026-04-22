#if !NETSTANDARD_2_1_OR_GREATER && !NETCOREAPP_3_0_OR_GREATER

using Microsoft.CodeAnalysis;

namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(
    AttributeTargets.Parameter |
    AttributeTargets.Property |
    AttributeTargets.ReturnValue)]
[Embedded]
[ExcludeFromCodeCoverage]
internal sealed class NotNullIfNotNullAttribute(string parameterName) :
    Attribute
{
    public string ParameterName => parameterName;
}

#endif
