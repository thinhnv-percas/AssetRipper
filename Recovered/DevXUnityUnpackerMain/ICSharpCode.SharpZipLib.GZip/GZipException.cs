using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.GZip
{
	[Serializable]
	internal class GZipException : SharpZipBaseException
	{
		internal GZipException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public GZipException()
		{
		}

		public GZipException(string message)
			: base(message)
		{
		}

		public GZipException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
