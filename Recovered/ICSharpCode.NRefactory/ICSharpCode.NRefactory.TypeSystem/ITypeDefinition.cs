using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface ITypeDefinition : IType, INamedElement, IEquatable<IType>, IEntity, ISymbol, ICompilationProvider, IHasAccessibility
	{
		IList<IUnresolvedTypeDefinition> Parts
		{
			get;
		}

		IList<ITypeParameter> TypeParameters
		{
			get;
		}

		IList<ITypeDefinition> NestedTypes
		{
			get;
		}

		IList<IMember> Members
		{
			get;
		}

		IEnumerable<IField> Fields
		{
			get;
		}

		IEnumerable<IMethod> Methods
		{
			get;
		}

		IEnumerable<IProperty> Properties
		{
			get;
		}

		IEnumerable<IEvent> Events
		{
			get;
		}

		KnownTypeCode KnownTypeCode
		{
			get;
		}

		IType EnumUnderlyingType
		{
			get;
		}

		FullTypeName FullTypeName
		{
			get;
		}

		new IType DeclaringType
		{
			get;
		}

		bool HasExtensionMethods
		{
			get;
		}

		bool IsPartial
		{
			get;
		}

		IMember GetInterfaceImplementation(IMember interfaceMember);

		IList<IMember> GetInterfaceImplementation(IList<IMember> interfaceMembers);
	}
}
