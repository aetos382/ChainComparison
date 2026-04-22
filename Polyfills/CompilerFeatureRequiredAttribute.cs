#if !NET7_0_OR_GREATER

using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[Embedded]
[AttributeUsage(AttributeTargets.All)]
internal sealed class CompilerFeatureRequiredAttribute(string featureName) :
    Attribute
{
    public string FeatureName => featureName;

    public const string RefStructs = nameof(RefStructs);
    public const string RequiredMembers = nameof(RequiredMembers);
}

#endif
