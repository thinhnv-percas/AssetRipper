using System;
using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem;

public sealed class ArrayType : TypeWithElementType, ICompilationProvider
{
	private readonly int dimensions;

	private readonly ICompilation compilation;

	private readonly Nullability nullability;

	public override TypeKind Kind => TypeKind.Array;

	public ICompilation Compilation => compilation;

	public int Dimensions => dimensions;

	public override Nullability Nullability => nullability;

	public override string NameSuffix => "[" + new string(',', checked(dimensions - 1)) + "]";

	public override bool? IsReferenceType => true;

	public override IEnumerable<IType> DirectBaseTypes
	{
		get
		{
			List<IType> list = new List<IType>();
			IType type = compilation.FindType(KnownTypeCode.Array);
			if (type.Kind != TypeKind.Unknown)
			{
				list.Add(type);
			}
			if (dimensions == 1 && elementType.Kind != TypeKind.Pointer)
			{
				if (compilation.FindType(KnownTypeCode.IListOfT) is ITypeDefinition genericType)
				{
					list.Add(new ParameterizedType(genericType, new IType[1] { elementType }));
				}
				if (compilation.FindType(KnownTypeCode.IReadOnlyListOfT) is ITypeDefinition genericType2)
				{
					list.Add(new ParameterizedType(genericType2, new IType[1] { elementType }));
				}
			}
			return list;
		}
	}

	public ArrayType(ICompilation compilation, IType elementType, int dimensions = 1, Nullability nullability = Nullability.Oblivious)
		: base(elementType)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (dimensions <= 0)
		{
			throw new ArgumentOutOfRangeException("dimensions", dimensions, "dimensions must be positive");
		}
		this.compilation = compilation;
		this.dimensions = dimensions;
		this.nullability = nullability;
		if (elementType is ICompilationProvider compilationProvider && compilationProvider.Compilation != compilation)
		{
			throw new InvalidOperationException("Cannot create an array type using a different compilation from the element type.");
		}
	}

	public override IType ChangeNullability(Nullability nullability)
	{
		if (nullability == this.nullability)
		{
			return this;
		}
		return new ArrayType(compilation, elementType, dimensions, nullability);
	}

	public override int GetHashCode()
	{
		return elementType.GetHashCode() * 71681 + dimensions;
	}

	public override bool Equals(IType other)
	{
		return other is ArrayType arrayType && elementType.Equals(arrayType.elementType) && arrayType.dimensions == dimensions && arrayType.nullability == nullability;
	}

	public override string ToString()
	{
		return nullability switch
		{
			Nullability.Nullable => elementType.ToString() + NameSuffix + "?", 
			Nullability.NotNullable => elementType.ToString() + NameSuffix + "!", 
			_ => elementType.ToString() + NameSuffix, 
		};
	}

	public override IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return compilation.FindType(KnownTypeCode.Array).GetMethods(filter, options);
	}

	public override IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return compilation.FindType(KnownTypeCode.Array).GetMethods(typeArguments, filter, options);
	}

	public override IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return compilation.FindType(KnownTypeCode.Array).GetAccessors(filter, options);
	}

	public override IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IProperty>.Instance;
		}
		return compilation.FindType(KnownTypeCode.Array).GetProperties(filter, options);
	}

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitArrayType(this);
	}

	public override IType VisitChildren(TypeVisitor visitor)
	{
		IType type = elementType.AcceptVisitor(visitor);
		if (type == elementType)
		{
			return this;
		}
		return new ArrayType(compilation, type, dimensions, nullability);
	}
}
