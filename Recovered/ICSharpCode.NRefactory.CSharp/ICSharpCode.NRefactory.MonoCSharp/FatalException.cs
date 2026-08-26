using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal class FatalException : Exception
	{
		public FatalException(string message)
			: base(message)
		{
		}
	}
}
