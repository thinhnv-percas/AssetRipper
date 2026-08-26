using System.Collections.Generic;
using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IAttribute
{
	DomRegion Region { get; }

	IType AttributeType { get; }

	IMethod Constructor { get; }

	IList<ResolveResult> PositionalArguments { get; }

	IList<KeyValuePair<IMember, ResolveResult>> NamedArguments { get; }
}
