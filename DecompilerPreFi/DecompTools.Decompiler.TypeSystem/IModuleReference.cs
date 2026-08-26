namespace DecompTools.Decompiler.TypeSystem;

public interface IModuleReference
{
	IModule Resolve(ITypeResolveContext context);
}
