using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface ICodeContext : ITypeResolveContext, ICompilationProvider
{
	IEnumerable<IVariable> LocalVariables { get; }

	bool IsWithinLambdaExpression { get; }
}
