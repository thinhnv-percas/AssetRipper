using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public interface IParameterCompletionDataFactory
	{
		IParameterDataProvider CreateConstructorProvider(int startOffset, IType type);

		IParameterDataProvider CreateConstructorProvider(int startOffset, IType type, AstNode thisInitializer);

		IParameterDataProvider CreateMethodDataProvider(int startOffset, IEnumerable<IMethod> methods);

		IParameterDataProvider CreateDelegateDataProvider(int startOffset, IType type);

		IParameterDataProvider CreateIndexerParameterDataProvider(int startOffset, IType type, IEnumerable<IProperty> accessibleIndexers, AstNode resolvedNode);

		IParameterDataProvider CreateTypeParameterDataProvider(int startOffset, IEnumerable<IType> types);

		IParameterDataProvider CreateTypeParameterDataProvider(int startOffset, IEnumerable<IMethod> methods);
	}
}
