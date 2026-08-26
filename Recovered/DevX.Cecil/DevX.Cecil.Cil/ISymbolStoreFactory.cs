namespace DevX.Cecil.Cil
{
	public interface ISymbolStoreFactory
	{
		ISymbolReader CreateReader(ModuleDefinition module, string assemblyFileName);

		ISymbolWriter CreateWriter(ModuleDefinition module, string assemblyFileName);
	}
}
