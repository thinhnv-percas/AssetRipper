using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Documentation;

public interface IDocumentationProvider
{
	string GetDocumentation(IEntity entity);
}
