namespace DecompTools.Decompiler.TypeSystem;

public interface ITypeReference
{
	IType Resolve(ITypeResolveContext context);
}
