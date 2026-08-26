namespace DevX.Cecil
{
	public interface IAssemblyResolver
	{
		AssemblyDefinition Resolve(string fullName);

		AssemblyDefinition Resolve(AssemblyNameReference name);
	}
}
