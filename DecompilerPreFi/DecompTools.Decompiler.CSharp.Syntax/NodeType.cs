namespace DecompTools.Decompiler.CSharp.Syntax;

public enum NodeType
{
	Unknown,
	TypeReference,
	TypeDeclaration,
	Member,
	Statement,
	Expression,
	Token,
	QueryClause,
	Whitespace,
	Pattern
}
