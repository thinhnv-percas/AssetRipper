using System;
using System.Runtime.Serialization;

namespace Wasm
{
	[Serializable]
	public class WasmException : Exception
	{
		public WasmException(string message)
			: base(message)
		{
		}

		internal WasmException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
