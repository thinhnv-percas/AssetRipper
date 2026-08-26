namespace DecompTools.Decompiler.Metadata;

public interface IAssemblyResolver
{
	PEFile Resolve(IAssemblyReference reference);

	PEFile ResolveModule(PEFile mainModule, string moduleName);
}
