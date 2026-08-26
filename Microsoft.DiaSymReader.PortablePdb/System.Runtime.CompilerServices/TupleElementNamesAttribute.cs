using System.Collections.Generic;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
internal sealed class TupleElementNamesAttribute : Attribute
{
	public IList<string> TransformNames { get; }

	public TupleElementNamesAttribute(string[] transformNames)
	{
		TransformNames = transformNames;
	}
}
