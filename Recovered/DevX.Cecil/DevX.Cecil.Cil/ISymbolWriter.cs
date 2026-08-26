using System;

namespace DevX.Cecil.Cil
{
	public interface ISymbolWriter : IDisposable
	{
		void Write(MethodBody body);
	}
}
