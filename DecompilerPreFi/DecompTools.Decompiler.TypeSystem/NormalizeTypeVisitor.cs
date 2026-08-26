using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

internal sealed class NormalizeTypeVisitor : TypeVisitor
{
	internal static readonly NormalizeTypeVisitor TypeErasure = new NormalizeTypeVisitor
	{
		ReplaceClassTypeParametersWithDummy = false,
		ReplaceMethodTypeParametersWithDummy = false,
		DynamicAndObject = true,
		TupleToUnderlyingType = true,
		RemoveModOpt = true,
		RemoveModReq = true,
		RemoveNullability = true
	};

	public bool RemoveModOpt = true;

	public bool RemoveModReq = true;

	public bool ReplaceClassTypeParametersWithDummy = true;

	public bool ReplaceMethodTypeParametersWithDummy = true;

	public bool DynamicAndObject = true;

	public bool TupleToUnderlyingType = true;

	public bool RemoveNullability = true;

	public bool EquivalentTypes(IType a, IType b)
	{
		a = a.AcceptVisitor(this);
		b = b.AcceptVisitor(this);
		return a.Equals(b);
	}

	public override IType VisitTypeParameter(ITypeParameter type)
	{
		if (type.OwnerType == SymbolKind.Method && ReplaceMethodTypeParametersWithDummy)
		{
			return DummyTypeParameter.GetMethodTypeParameter(type.Index);
		}
		if (type.OwnerType == SymbolKind.TypeDefinition && ReplaceClassTypeParametersWithDummy)
		{
			return DummyTypeParameter.GetClassTypeParameter(type.Index);
		}
		return base.VisitTypeParameter(type);
	}

	public override IType VisitTypeDefinition(ITypeDefinition type)
	{
		if (DynamicAndObject && type.KnownTypeCode == KnownTypeCode.Object)
		{
			if (RemoveNullability)
			{
				return SpecialType.Dynamic;
			}
			return SpecialType.Dynamic.ChangeNullability(type.Nullability);
		}
		return base.VisitTypeDefinition(type);
	}

	public override IType VisitTupleType(TupleType type)
	{
		if (TupleToUnderlyingType)
		{
			return type.UnderlyingType.AcceptVisitor(this);
		}
		return base.VisitTupleType(type);
	}

	public override IType VisitNullabilityAnnotatedType(NullabilityAnnotatedType type)
	{
		if (RemoveNullability)
		{
			return base.VisitNullabilityAnnotatedType(type).ChangeNullability(Nullability.Oblivious);
		}
		return base.VisitNullabilityAnnotatedType(type);
	}

	public override IType VisitArrayType(ArrayType type)
	{
		if (RemoveNullability)
		{
			return base.VisitArrayType(type).ChangeNullability(Nullability.Oblivious);
		}
		return base.VisitArrayType(type);
	}

	public override IType VisitModOpt(ModifiedType type)
	{
		if (RemoveModOpt)
		{
			return type.ElementType.AcceptVisitor(this);
		}
		return base.VisitModOpt(type);
	}

	public override IType VisitModReq(ModifiedType type)
	{
		if (RemoveModReq)
		{
			return type.ElementType.AcceptVisitor(this);
		}
		return base.VisitModReq(type);
	}
}
