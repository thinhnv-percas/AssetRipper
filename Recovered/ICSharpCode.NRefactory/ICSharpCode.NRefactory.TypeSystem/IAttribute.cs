using ICSharpCode.NRefactory.Semantics;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IAttribute
	{
		DomRegion Region
		{
			get;
		}

		IType AttributeType
		{
			get;
		}

		IMethod Constructor
		{
			get;
		}

		IList<ResolveResult> PositionalArguments
		{
			get;
		}

		IList<KeyValuePair<IMember, ResolveResult>> NamedArguments
		{
			get;
		}
	}
}
