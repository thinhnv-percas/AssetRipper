using System;

namespace DevX.Cecil.Binary
{
	public class ImageFormatException : Exception
	{
		internal ImageFormatException()
		{
		}

		internal ImageFormatException(string message)
			: base(message)
		{
		}

		internal ImageFormatException(string message, params string[] parameters)
			: base(string.Format(message, parameters))
		{
		}

		internal ImageFormatException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
