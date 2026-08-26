using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public sealed class ExplicitInterfaceImplementationMemberReference : IMemberReference, ISymbolReference
	{
		private ITypeReference typeReference;

		private IMemberReference interfaceMemberReference;

		public ITypeReference DeclaringTypeReference => typeReference;

		public ExplicitInterfaceImplementationMemberReference(ITypeReference typeReference, IMemberReference interfaceMemberReference)
		{
			if (typeReference == null)
			{
				throw new ArgumentNullException("typeReference");
			}
			if (interfaceMemberReference == null)
			{
				throw new ArgumentNullException("interfaceMemberReference");
			}
			this.typeReference = typeReference;
			this.interfaceMemberReference = interfaceMemberReference;
		}

		public IMember Resolve(ITypeResolveContext context)
		{
			IType type = typeReference.Resolve(context);
			IMember interfaceMember = interfaceMemberReference.Resolve(context.WithCurrentTypeDefinition(type.GetDefinition()));
			if (interfaceMember == null)
			{
				return null;
			}
			IEnumerable<IMember> source = (interfaceMember.SymbolKind != SymbolKind.Accessor) ? type.GetMembers((IUnresolvedMember m) => m.SymbolKind == interfaceMember.SymbolKind && m.IsExplicitInterfaceImplementation, GetMemberOptions.IgnoreInheritedMembers) : type.GetAccessors((IUnresolvedMethod m) => m.IsExplicitInterfaceImplementation, GetMemberOptions.IgnoreInheritedMembers);
			return source.FirstOrDefault((IMember m) => m.ImplementedInterfaceMembers.Count == 1 && interfaceMember.Equals(m.ImplementedInterfaceMembers[0]));
		}

		ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
		{
			return Resolve(context);
		}
	}
}
