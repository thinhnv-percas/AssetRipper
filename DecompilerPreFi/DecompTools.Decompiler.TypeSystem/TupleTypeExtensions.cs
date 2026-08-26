namespace DecompTools.Decompiler.TypeSystem;

public static class TupleTypeExtensions
{
	public static IType TupleUnderlyingTypeOrSelf(this IType type)
	{
		IType type2 = (type as TupleType)?.UnderlyingType;
		return type2 ?? type;
	}
}
