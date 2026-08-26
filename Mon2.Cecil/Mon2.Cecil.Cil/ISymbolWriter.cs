using System;

namespace Mon2.Cecil.Cil;

public interface ISymbolWriter : IDisposable
{
	bool GetDebugHeader(out ImageDebugDirectory directory, out byte[] header);

	void Write(MethodBody body);

	void Write(MethodSymbols symbols);
}
