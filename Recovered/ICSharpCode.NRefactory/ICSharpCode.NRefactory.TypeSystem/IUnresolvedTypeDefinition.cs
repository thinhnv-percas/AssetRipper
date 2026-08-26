using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IUnresolvedTypeDefinition : ITypeReference, IUnresolvedEntity, INamedElement, IHasAccessibility
	{
		TypeKind Kind
		{
			get;
		}

		FullTypeName FullTypeName
		{
			get;
		}

		IList<ITypeReference> BaseTypes
		{
			get;
		}

		IList<IUnresolvedTypeParameter> TypeParameters
		{
			get;
		}

		IList<IUnresolvedTypeDefinition> NestedTypes
		{
			get;
		}

		IList<IUnresolvedMember> Members
		{
			get;
		}

		IEnumerable<IUnresolvedMethod> Methods
		{
			get;
		}

		IEnumerable<IUnresolvedProperty> Properties
		{
			get;
		}

		IEnumerable<IUnresolvedField> Fields
		{
			get;
		}

		IEnumerable<IUnresolvedEvent> Events
		{
			get;
		}

		bool? HasExtensionMethods
		{
			get;
		}

		bool IsPartial
		{
			get;
		}

		bool AddDefaultConstructorIfRequired
		{
			get;
		}

		new IType Resolve(ITypeResolveContext context);

		ITypeResolveContext CreateResolveContext(ITypeResolveContext parentContext);
	}
}
