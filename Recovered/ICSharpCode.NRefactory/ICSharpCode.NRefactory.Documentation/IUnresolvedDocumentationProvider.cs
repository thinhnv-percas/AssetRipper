using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Documentation
{
	public interface IUnresolvedDocumentationProvider
	{
		string GetDocumentation(IUnresolvedEntity entity);

		DocumentationComment GetDocumentation(IUnresolvedEntity entity, IEntity resolvedEntity);
	}
}
