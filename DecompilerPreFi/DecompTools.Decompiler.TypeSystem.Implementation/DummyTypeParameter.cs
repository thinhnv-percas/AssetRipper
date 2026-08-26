using System;
using System.Collections.Generic;
using System.Threading;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public sealed class DummyTypeParameter : AbstractType, ITypeParameter, IType, INamedElement, IEquatable<IType>, ISymbol
{
	private static ITypeParameter[] methodTypeParameters = new ITypeParameter[1]
	{
		new DummyTypeParameter(SymbolKind.Method, 0)
	};

	private static ITypeParameter[] classTypeParameters = new ITypeParameter[1]
	{
		new DummyTypeParameter(SymbolKind.TypeDefinition, 0)
	};

	private static IReadOnlyList<ITypeParameter>[] classTypeParameterLists = new IReadOnlyList<ITypeParameter>[1] { EmptyList<ITypeParameter>.Instance };

	private readonly SymbolKind ownerType;

	private readonly int index;

	SymbolKind ISymbol.SymbolKind => SymbolKind.TypeParameter;

	public override string Name => ((ownerType == SymbolKind.Method) ? "!!" : "!") + index;

	public override string ReflectionName => ((ownerType == SymbolKind.Method) ? "``" : "`") + index;

	public override bool? IsReferenceType => null;

	public override TypeKind Kind => TypeKind.TypeParameter;

	public int Index => index;

	SymbolKind ITypeParameter.OwnerType => ownerType;

	VarianceModifier ITypeParameter.Variance => VarianceModifier.Invariant;

	IEntity ITypeParameter.Owner => null;

	IType ITypeParameter.EffectiveBaseClass => SpecialType.UnknownType;

	IReadOnlyCollection<IType> ITypeParameter.EffectiveInterfaceSet => EmptyList<IType>.Instance;

	bool ITypeParameter.HasDefaultConstructorConstraint => false;

	bool ITypeParameter.HasReferenceTypeConstraint => false;

	bool ITypeParameter.HasValueTypeConstraint => false;

	bool ITypeParameter.HasUnmanagedConstraint => false;

	Nullability ITypeParameter.NullabilityConstraint => Nullability.Oblivious;

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
		checked
		{
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
	}

	internal static IReadOnlyList<ITypeParameter> GetClassTypeParameterList(int length)
	{
		IReadOnlyList<ITypeParameter>[] array = classTypeParameterLists;
		checked
		{
			while (length >= array.Length)
			{
				IReadOnlyList<ITypeParameter>[] array2 = new IReadOnlyList<ITypeParameter>[length + 1];
				array.CopyTo(array2, 0);
				for (int i = array.Length; i < array2.Length; i++)
				{
					ITypeParameter[] array3 = new ITypeParameter[i];
					for (int j = 0; j < array3.Length; j++)
					{
						array3[j] = GetClassTypeParameter(j);
					}
					array2[i] = array3;
				}
				IReadOnlyList<ITypeParameter>[] array4 = Interlocked.CompareExchange(ref classTypeParameterLists, array2, array);
				array = ((array4 != array) ? array4 : array2);
			}
			return array[length];
		}
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

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitTypeParameter(this);
	}

	IEnumerable<IAttribute> ITypeParameter.GetAttributes()
	{
		return EmptyList<IAttribute>.Instance;
	}
}
