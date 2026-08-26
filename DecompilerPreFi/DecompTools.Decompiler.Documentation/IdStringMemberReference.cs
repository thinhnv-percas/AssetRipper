using System;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Documentation;

[Serializable]
internal class IdStringMemberReference : IMemberReference
{
	private readonly ITypeReference declaringTypeReference;

	private readonly char memberType;

	private readonly string memberIdString;

	public ITypeReference DeclaringTypeReference => declaringTypeReference;

	public IdStringMemberReference(ITypeReference declaringTypeReference, char memberType, string memberIdString)
	{
		this.declaringTypeReference = declaringTypeReference;
		this.memberType = memberType;
		this.memberIdString = memberIdString;
	}

	private bool CanMatch(IMember member)
	{
		switch (member.SymbolKind)
		{
		case SymbolKind.Field:
			return memberType == 'F';
		case SymbolKind.Property:
		case SymbolKind.Indexer:
			return memberType == 'P';
		case SymbolKind.Event:
			return memberType == 'E';
		case SymbolKind.Method:
		case SymbolKind.Operator:
		case SymbolKind.Constructor:
		case SymbolKind.Destructor:
			return memberType == 'M';
		default:
			throw new NotSupportedException(member.SymbolKind.ToString());
		}
	}

	public IMember Resolve(ITypeResolveContext context)
	{
		IType type = declaringTypeReference.Resolve(context);
		foreach (IMember member in type.GetMembers(CanMatch, GetMemberOptions.IgnoreInheritedMembers))
		{
			if (member.GetIdString() == memberIdString)
			{
				return member;
			}
		}
		return null;
	}
}
