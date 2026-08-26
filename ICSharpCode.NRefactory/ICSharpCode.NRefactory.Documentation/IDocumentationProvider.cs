using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Documentation;

public interface IDocumentationProvider
{
	DocumentationComment GetDocumentation(IEntity entity);
}
