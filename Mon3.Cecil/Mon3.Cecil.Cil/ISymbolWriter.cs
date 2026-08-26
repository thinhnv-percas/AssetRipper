using System;

namespace Mon3.Cecil.Cil;

public interface ISymbolWriter : IDisposable
{
	ISymbolReaderProvider GetReaderProvider();

	ImageDebugHeader GetDebugHeader();

	void Write(MethodDebugInformation info);
}
