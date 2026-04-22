#if NETSTANDARD || !NETCOREAPP3_0_OR_GREATER

using System.Diagnostics.CodeAnalysis;

using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Parameter)]
[Embedded]
[ExcludeFromCodeCoverage]
internal sealed class CallerArgumentExpressionAttribute(string parameterName) :
    Attribute
{
    public string ParameterName => parameterName;
}

#endif
