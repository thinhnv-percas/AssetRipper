using System;
using Mon2.Cecil.Metadata;

namespace Mon2.Cecil;

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
		etype = Mon2.Cecil.Metadata.ElementType.Pinned;
	}
}
