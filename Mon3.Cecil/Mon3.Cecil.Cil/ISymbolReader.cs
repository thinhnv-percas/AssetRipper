using System;

namespace Mon3.Cecil.Cil;

public interface ISymbolReader : IDisposable
{
	ISymbolWriterProvider GetWriterProvider();

	bool ProcessDebugHeader(ImageDebugHeader header);

	MethodDebugInformation Read(MethodDefinition method);
}
