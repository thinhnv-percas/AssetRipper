using System;
using System.Runtime.Serialization;

namespace ICSharpCode.Decompiler
{
	[Serializable]
	public class ReferenceResolvingException : Exception
	{
		public ReferenceResolvingException()
		{
		}

		public ReferenceResolvingException(string message)
			: base(message)
		{
		}

		public ReferenceResolvingException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected ReferenceResolvingException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
