using System;
using Mon3.Cecil.Metadata;

namespace Mon3.Cecil;

public sealed class SentinelType : TypeSpecification
{
	public override bool IsValueType
	{
		get
		{
			return false;
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	public override bool IsSentinel => true;

	public SentinelType(TypeReference type)
		: base(type)
	{
		Mixin.CheckType(type);
		etype = Mon3.Cecil.Metadata.ElementType.Sentinel;
	}
}
