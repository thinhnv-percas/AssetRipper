using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	[Serializable]
	public sealed class SimpleTypeOrNamespaceReference : TypeOrNamespaceReference, ISupportsInterning
	{
		private readonly string identifier;

		private readonly IList<ITypeReference> typeArguments;

		private readonly NameLookupMode lookupMode;

		public string Identifier => identifier;

		public IList<ITypeReference> TypeArguments => typeArguments;

		public NameLookupMode LookupMode => lookupMode;

		public SimpleTypeOrNamespaceReference(string identifier, IList<ITypeReference> typeArguments, NameLookupMode lookupMode = NameLookupMode.Type)
		{
			if (identifier == null)
			{
				throw new ArgumentNullException("identifier");
			}
			this.identifier = identifier;
			this.typeArguments = (typeArguments ?? EmptyList<ITypeReference>.Instance);
			this.lookupMode = lookupMode;
		}

		public SimpleTypeOrNamespaceReference AddSuffix(string suffix)
		{
			return new SimpleTypeOrNamespaceReference(identifier + suffix, typeArguments, lookupMode);
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			IList<IType> list = typeArguments.Resolve(resolver.CurrentTypeResolveContext);
			return resolver.LookupSimpleNameOrTypeName(identifier, list, lookupMode);
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
				return identifier;
			}
			return identifier + "<" + string.Join(",", typeArguments) + ">";
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			return 0 + 1000000021 * identifier.GetHashCode() + 1000000033 * typeArguments.GetHashCode() + 1000000087 * (int)lookupMode;
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			SimpleTypeOrNamespaceReference simpleTypeOrNamespaceReference = other as SimpleTypeOrNamespaceReference;
			if (simpleTypeOrNamespaceReference != null && identifier == simpleTypeOrNamespaceReference.identifier && typeArguments == simpleTypeOrNamespaceReference.typeArguments)
			{
				return lookupMode == simpleTypeOrNamespaceReference.lookupMode;
			}
			return false;
		}
	}
}
