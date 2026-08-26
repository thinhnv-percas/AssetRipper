namespace Wasm.Interpret
{
	public interface IImporter
	{
		LinearMemory ImportMemory(ImportedMemory description);

		Variable ImportGlobal(ImportedGlobal description);

		FunctionDefinition ImportFunction(ImportedFunction description, FunctionType signature);

		FunctionTable ImportTable(ImportedTable description);
	}
}
