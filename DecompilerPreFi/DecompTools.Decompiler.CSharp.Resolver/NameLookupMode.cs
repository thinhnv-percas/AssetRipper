namespace DecompTools.Decompiler.CSharp.Resolver;

public enum NameLookupMode
{
	Expression,
	InvocationTarget,
	Type,
	TypeInUsingDeclaration,
	BaseTypeReference
}
