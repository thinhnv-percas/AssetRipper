using DevX.Cecil.Metadata;
using System;

namespace DevX.Cecil
{
	public sealed class ReflectionException : MetadataFormatException
	{
		internal ReflectionException()
		{
		}

		internal ReflectionException(string message)
			: base(message)
		{
		}

		internal ReflectionException(string message, params string[] parameters)
			: base(string.Format(message, parameters))
		{
		}

		internal ReflectionException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
