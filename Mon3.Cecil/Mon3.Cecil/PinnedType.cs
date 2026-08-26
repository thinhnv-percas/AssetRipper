using System;
using Mon3.Cecil.Metadata;

namespace Mon3.Cecil;

public sealed class PinnedType : TypeSpecification
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

	public override bool IsPinned => true;

	public PinnedType(TypeReference type)
		: base(type)
	{
		Mixin.CheckType(type);
		etype = Mon3.Cecil.Metadata.ElementType.Pinned;
	}
}
