using DevX.Cecil.Binary;
using System;

namespace DevX.Cecil.Metadata
{
	public class MetadataFormatException : ImageFormatException
	{
		internal MetadataFormatException()
		{
		}

		internal MetadataFormatException(string message)
			: base(message)
		{
		}

		internal MetadataFormatException(string message, params string[] parameters)
			: base(string.Format(message, parameters))
		{
		}

		internal MetadataFormatException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
