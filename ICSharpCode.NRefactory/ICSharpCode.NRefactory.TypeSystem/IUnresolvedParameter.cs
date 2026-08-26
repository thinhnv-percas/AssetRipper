using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedParameter
{
	string Name { get; }

	DomRegion Region { get; }

	ITypeReference Type { get; }

	IList<IUnresolvedAttribute> Attributes { get; }

	bool IsRef { get; }

	bool IsOut { get; }

	bool IsParams { get; }

	bool IsOptional { get; }

	IParameter CreateResolvedParameter(ITypeResolveContext context);
}
