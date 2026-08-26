using System.IO;

namespace Mon2.Cecil.Cil;

public interface ISymbolWriterProvider
{
	ISymbolWriter GetSymbolWriter(ModuleDefinition module, string fileName);

	ISymbolWriter GetSymbolWriter(ModuleDefinition module, Stream symbolStream);
}
