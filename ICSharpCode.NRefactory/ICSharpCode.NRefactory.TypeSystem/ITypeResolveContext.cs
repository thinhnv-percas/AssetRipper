namespace ICSharpCode.NRefactory.TypeSystem;

public interface ITypeResolveContext : ICompilationProvider
{
	IAssembly CurrentAssembly { get; }

	ITypeDefinition CurrentTypeDefinition { get; }

	IMember CurrentMember { get; }

	ITypeResolveContext WithCurrentTypeDefinition(ITypeDefinition typeDefinition);

	ITypeResolveContext WithCurrentMember(IMember member);
}
