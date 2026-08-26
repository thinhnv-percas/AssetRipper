using System;
using System.Runtime.Serialization;

namespace DecompTools.Decompiler.Metadata;

[Serializable]
public class PEFileNotSupportedException : Exception
{
	public PEFileNotSupportedException()
	{
	}

	public PEFileNotSupportedException(string message)
		: base(message)
	{
	}

	public PEFileNotSupportedException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected PEFileNotSupportedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
