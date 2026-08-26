using System;
using Mon2.Cecil.Metadata;

namespace Mon2.Cecil;

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
		etype = Mon2.Cecil.Metadata.ElementType.Sentinel;
	}
}
