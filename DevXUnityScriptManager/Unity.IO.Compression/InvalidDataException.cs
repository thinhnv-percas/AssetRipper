using System;
using System.Runtime.Serialization;

namespace Unity.IO.Compression;

[Serializable]
public sealed class InvalidDataException : SystemException
{
	public InvalidDataException()
		: base(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_0020_0020_0020))
	{
	}

	public InvalidDataException(string message)
		: base(message)
	{
	}

	public InvalidDataException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	internal InvalidDataException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
