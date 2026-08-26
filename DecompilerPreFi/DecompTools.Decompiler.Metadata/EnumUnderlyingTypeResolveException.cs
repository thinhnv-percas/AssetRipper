using System;
using System.Runtime.Serialization;

namespace DecompTools.Decompiler.Metadata;

[Serializable]
public class EnumUnderlyingTypeResolveException : Exception
{
	public EnumUnderlyingTypeResolveException()
	{
	}

	public EnumUnderlyingTypeResolveException(string message)
		: base(message)
	{
	}

	public EnumUnderlyingTypeResolveException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected EnumUnderlyingTypeResolveException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
