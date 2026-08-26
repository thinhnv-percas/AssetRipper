using System.IO;

namespace Mon2.Cecil.Cil;

public interface ISymbolReaderProvider
{
	ISymbolReader GetSymbolReader(ModuleDefinition module, string fileName);

	ISymbolReader GetSymbolReader(ModuleDefinition module, Stream symbolStream);
}
