using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Zip
{
	[Serializable]
	internal class ZipException : SharpZipBaseException
	{
		internal ZipException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public ZipException()
		{
		}

		public ZipException(string message)
			: base(message)
		{
		}

		public ZipException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
