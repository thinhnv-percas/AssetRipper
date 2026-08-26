using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.Documentation
{
	[Serializable]
	internal class IdStringMemberReference : IMemberReference, ISymbolReference
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

		private bool CanMatch(IUnresolvedMember member)
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
			foreach (IMember member in declaringTypeReference.Resolve(context).GetMembers(CanMatch, GetMemberOptions.IgnoreInheritedMembers))
			{
				if (member.GetIdString() == memberIdString)
				{
					return member;
				}
			}
			return null;
		}

		ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
		{
			return Resolve(context);
		}
	}
}
