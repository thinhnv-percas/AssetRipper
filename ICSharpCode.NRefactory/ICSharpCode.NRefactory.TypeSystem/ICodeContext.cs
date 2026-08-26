using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface ICodeContext : ITypeResolveContext, ICompilationProvider
{
	IEnumerable<IVariable> LocalVariables { get; }

	bool IsWithinLambdaExpression { get; }
}
