namespace DecompTools.Decompiler.TypeSystem;

public interface IMemberReference
{
	ITypeReference DeclaringTypeReference { get; }

	IMember Resolve(ITypeResolveContext context);
}
