using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IParameterizedMember : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		IList<IParameter> Parameters
		{
			get;
		}
	}
}
