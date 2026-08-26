using System;
using System.Collections.Generic;
using System.Threading;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public sealed class DummyTypeParameter : AbstractType, ITypeParameter, IType, INamedElement, IEquatable<IType>, ISymbol
{
	private sealed class NormalizeMethodTypeParametersVisitor : TypeVisitor
	{
		public override IType VisitTypeParameter(ITypeParameter type)
		{
			if (type.OwnerType == SymbolKind.Method)
			{
				return GetMethodTypeParameter(type.Index);
			}
			return base.VisitTypeParameter(type);
		}
	}

	private sealed class NormalizeClassTypeParametersVisitor : TypeVisitor
	{
		public override IType VisitTypeParameter(ITypeParameter type)
		{
			if (type.OwnerType == SymbolKind.TypeDefinition)
			{
				return GetClassTypeParameter(type.Index);
			}
			return base.VisitTypeParameter(type);
		}
	}

	private static ITypeParameter[] methodTypeParameters = new ITypeParameter[1]
	{
		new DummyTypeParameter(SymbolKind.Method, 0)
	};

	private static ITypeParameter[] classTypeParameters = new ITypeParameter[1]
	{
		new DummyTypeParameter(SymbolKind.TypeDefinition, 0)
	};

	private static readonly NormalizeMethodTypeParametersVisitor normalizeMethodTypeParameters = new NormalizeMethodTypeParametersVisitor();

	private static readonly NormalizeClassTypeParametersVisitor normalizeClassTypeParameters = new NormalizeClassTypeParametersVisitor();

	private readonly SymbolKind ownerType;

	private readonly int index;

	SymbolKind ISymbol.SymbolKind => SymbolKind.TypeParameter;

	public override string Name => ((ownerType == SymbolKind.Method) ? "!!" : "!") + index;

	public override string ReflectionName => ((ownerType == SymbolKind.Method) ? "``" : "`") + index;

	public override bool? IsReferenceType => null;

	public override TypeKind Kind => TypeKind.TypeParameter;

	public int Index => index;

	IList<IAttribute> ITypeParameter.Attributes => EmptyList<IAttribute>.Instance;

	SymbolKind ITypeParameter.OwnerType => ownerType;

	VarianceModifier ITypeParameter.Variance => VarianceModifier.Invariant;

	DomRegion ITypeParameter.Region => DomRegion.Empty;

	IEntity ITypeParameter.Owner => null;

	IType ITypeParameter.EffectiveBaseClass => SpecialType.UnknownType;

	ICollection<IType> ITypeParameter.EffectiveInterfaceSet => EmptyList<IType>.Instance;

	bool ITypeParameter.HasDefaultConstructorConstraint => false;

	bool ITypeParameter.HasReferenceTypeConstraint => false;

	bool ITypeParameter.HasValueTypeConstraint => false;

	public static ITypeParameter GetMethodTypeParameter(int index)
	{
		return GetTypeParameter(ref methodTypeParameters, SymbolKind.Method, index);
	}

	public static ITypeParameter GetClassTypeParameter(int index)
	{
		return GetTypeParameter(ref classTypeParameters, SymbolKind.TypeDefinition, index);
	}

	private static ITypeParameter GetTypeParameter(ref ITypeParameter[] typeParameters, SymbolKind symbolKind, int index)
	{
		ITypeParameter[] array = typeParameters;
		while (index >= array.Length)
		{
			ITypeParameter[] array2 = new ITypeParameter[index + 1];
			array.CopyTo(array2, 0);
			for (int i = array.Length; i < array2.Length; i++)
			{
				array2[i] = new DummyTypeParameter(symbolKind, i);
			}
			ITypeParameter[] array3 = Interlocked.CompareExchange(ref typeParameters, array2, array);
			array = ((array3 != array) ? array3 : array2);
		}
		return array[index];
	}

	public static IType NormalizeMethodTypeParameters(IType type)
	{
		return type.AcceptVisitor(normalizeMethodTypeParameters);
	}

	public static IType NormalizeClassTypeParameters(IType type)
	{
		return type.AcceptVisitor(normalizeClassTypeParameters);
	}

	public static IType NormalizeAllTypeParameters(IType type)
	{
		return type.AcceptVisitor(normalizeClassTypeParameters).AcceptVisitor(normalizeMethodTypeParameters);
	}

	private DummyTypeParameter(SymbolKind ownerType, int index)
	{
		this.ownerType = ownerType;
		this.index = index;
	}

	public override string ToString()
	{
		return ReflectionName + " (dummy)";
	}

	public override ITypeReference ToTypeReference()
	{
		return TypeParameterReference.Create(ownerType, index);
	}

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitTypeParameter(this);
	}

	public ISymbolReference ToReference()
	{
		return new TypeParameterReference(ownerType, index);
	}
}
