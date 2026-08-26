using ICSharpCode.NRefactory.Documentation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IEntity : ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		[Obsolete("Use the SymbolKind property instead.")]
		EntityType EntityType
		{
			get;
		}

		new string Name
		{
			get;
		}

		DomRegion Region
		{
			get;
		}

		DomRegion BodyRegion
		{
			get;
		}

		ITypeDefinition DeclaringTypeDefinition
		{
			get;
		}

		IType DeclaringType
		{
			get;
		}

		IAssembly ParentAssembly
		{
			get;
		}

		IList<IAttribute> Attributes
		{
			get;
		}

		DocumentationComment Documentation
		{
			get;
		}

		bool IsStatic
		{
			get;
		}

		bool IsAbstract
		{
			get;
		}

		bool IsSealed
		{
			get;
		}

		bool IsShadowing
		{
			get;
		}

		bool IsSynthetic
		{
			get;
		}
	}
}
