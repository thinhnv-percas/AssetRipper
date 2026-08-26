namespace DecompTools.Decompiler.TypeSystem;

public static class ComHelper
{
	public static bool IsComImport(ITypeDefinition typeDefinition)
	{
		return typeDefinition != null && typeDefinition.Kind == TypeKind.Interface && typeDefinition.HasAttribute(KnownAttribute.ComImport);
	}

	public static IType GetCoClass(ITypeDefinition typeDefinition)
	{
		if (typeDefinition == null)
		{
			return SpecialType.UnknownType;
		}
		IAttribute attribute = typeDefinition.GetAttribute(KnownAttribute.CoClass);
		if (attribute != null && attribute.FixedArguments.Length == 1 && attribute.FixedArguments[0].Value is IType result)
		{
			return result;
		}
		return SpecialType.UnknownType;
	}
}
