using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class ValidatedNotNullAttribute : Attribute
{
}
