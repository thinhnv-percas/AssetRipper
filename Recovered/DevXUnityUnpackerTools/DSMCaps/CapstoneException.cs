using System;

namespace DSMCaps
{
	public sealed class CapstoneException : Exception
	{
		internal CapstoneException(string detailMessage)
			: base(detailMessage)
		{
		}

		internal CapstoneException(string detailMessage, Exception innerException)
			: base(detailMessage, innerException)
		{
		}
	}
}
