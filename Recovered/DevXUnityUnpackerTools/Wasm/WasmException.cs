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

		protected WasmException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
