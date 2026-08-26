using System;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public sealed class SpecialType : AbstractType, ITypeReference
{
	public static readonly SpecialType UnknownType = new SpecialType(TypeKind.Unknown, "?", null);

	public static readonly SpecialType NullType = new SpecialType(TypeKind.Null, "null", true);

	public static readonly SpecialType NoType = new SpecialType(TypeKind.None, "?", null);

	public static readonly SpecialType Dynamic = new SpecialType(TypeKind.Dynamic, "dynamic", true);

	public static readonly SpecialType ArgList = new SpecialType(TypeKind.ArgList, "__arglist", null);

	public static readonly SpecialType UnboundTypeArgument = new SpecialType(TypeKind.UnboundTypeArgument, "", null);

	private readonly TypeKind kind;

	private readonly string name;

	private readonly bool? isReferenceType;

	public override string Name => name;

	public override TypeKind Kind => kind;

	public override bool? IsReferenceType => isReferenceType;

	private SpecialType(TypeKind kind, string name, bool? isReferenceType)
	{
		this.kind = kind;
		this.name = name;
		this.isReferenceType = isReferenceType;
	}

	IType ITypeReference.Resolve(ITypeResolveContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return this;
	}

	[Obsolete("Please compare special types using the kind property instead.")]
	public override bool Equals(IType other)
	{
		return other is SpecialType && other.Kind == kind;
	}

	public override int GetHashCode()
	{
		return 0x4DD8215 ^ (int)kind;
	}
}
