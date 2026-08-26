using System;
using Mon2.Cecil.Metadata;

namespace Mon2.Cecil;

public sealed class PointerType : TypeSpecification
{
	public override string Name => base.Name + "*";

	public override string FullName => base.FullName + "*";

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

	public override bool IsPointer => true;

	public PointerType(TypeReference type)
		: base(type)
	{
		Mixin.CheckType(type);
		etype = Mon2.Cecil.Metadata.ElementType.Ptr;
	}
}
