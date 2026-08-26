using System;
using System.Runtime.Serialization;

namespace Mon3.Cecil.Cil;

[Serializable]
public sealed class SymbolsNotMatchingException : InvalidOperationException
{
	public SymbolsNotMatchingException(string message)
		: base(message)
	{
	}

	private SymbolsNotMatchingException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
