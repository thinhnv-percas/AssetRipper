using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	[Serializable]
	public sealed class MemberTypeOrNamespaceReference : TypeOrNamespaceReference, ISupportsInterning
	{
		private readonly TypeOrNamespaceReference target;

		private readonly string identifier;

		private readonly IList<ITypeReference> typeArguments;

		private readonly NameLookupMode lookupMode;

		public string Identifier => identifier;

		public TypeOrNamespaceReference Target => target;

		public IList<ITypeReference> TypeArguments => typeArguments;

		public NameLookupMode LookupMode => lookupMode;

		public MemberTypeOrNamespaceReference(TypeOrNamespaceReference target, string identifier, IList<ITypeReference> typeArguments, NameLookupMode lookupMode = NameLookupMode.Type)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (identifier == null)
			{
				throw new ArgumentNullException("identifier");
			}
			this.target = target;
			this.identifier = identifier;
			this.typeArguments = (typeArguments ?? EmptyList<ITypeReference>.Instance);
			this.lookupMode = lookupMode;
		}

		public MemberTypeOrNamespaceReference AddSuffix(string suffix)
		{
			return new MemberTypeOrNamespaceReference(target, identifier + suffix, typeArguments, lookupMode);
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			ResolveResult resolveResult = target.Resolve(resolver);
			if (resolveResult.IsError)
			{
				return resolveResult;
			}
			IList<IType> list = typeArguments.Resolve(resolver.CurrentTypeResolveContext);
			return resolver.ResolveMemberAccess(resolveResult, identifier, list, lookupMode);
		}

		public override IType ResolveType(CSharpResolver resolver)
		{
			TypeResolveResult typeResolveResult = Resolve(resolver) as TypeResolveResult;
			if (typeResolveResult == null)
			{
				return new UnknownType(null, identifier, typeArguments.Count);
			}
			return typeResolveResult.Type;
		}

		public override string ToString()
		{
			if (typeArguments.Count == 0)
			{
				return target.ToString() + "." + identifier;
			}
			return target.ToString() + "." + identifier + "<" + string.Join(",", typeArguments) + ">";
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			return 0 + 1000000007 * target.GetHashCode() + 1000000033 * identifier.GetHashCode() + 1000000087 * typeArguments.GetHashCode() + 1000000021 * (int)lookupMode;
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			MemberTypeOrNamespaceReference memberTypeOrNamespaceReference = other as MemberTypeOrNamespaceReference;
			if (memberTypeOrNamespaceReference != null && target == memberTypeOrNamespaceReference.target && identifier == memberTypeOrNamespaceReference.identifier && typeArguments == memberTypeOrNamespaceReference.typeArguments)
			{
				return lookupMode == memberTypeOrNamespaceReference.lookupMode;
			}
			return false;
		}
	}
}
