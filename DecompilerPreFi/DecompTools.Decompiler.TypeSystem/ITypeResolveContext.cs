namespace DecompTools.Decompiler.TypeSystem;

public interface ITypeResolveContext : ICompilationProvider
{
	IModule CurrentModule { get; }

	ITypeDefinition CurrentTypeDefinition { get; }

	IMember CurrentMember { get; }

	ITypeResolveContext WithCurrentTypeDefinition(ITypeDefinition typeDefinition);

	ITypeResolveContext WithCurrentMember(IMember member);
}
