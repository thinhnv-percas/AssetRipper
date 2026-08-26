using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public interface IFindReferenceSearchScope
{
	ICompilation Compilation { get; }

	string SearchTerm { get; }

	Accessibility Accessibility { get; }

	ITypeDefinition TopLevelTypeDefinition { get; }

	string FileName { get; }

	IResolveVisitorNavigator GetNavigator(ICompilation compilation, FoundReferenceCallback callback);
}
