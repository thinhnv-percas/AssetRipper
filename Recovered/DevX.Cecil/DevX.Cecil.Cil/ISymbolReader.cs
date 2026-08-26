using System;
using System.Collections;

namespace DevX.Cecil.Cil
{
	public interface ISymbolReader : IDisposable
	{
		void Read(MethodBody body, IDictionary instructions);
	}
}
