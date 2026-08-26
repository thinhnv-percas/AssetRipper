using System;
using System.Runtime.Serialization;

namespace Wasm.Interpret
{
	[Serializable]
	public class TrapException : WasmException
	{
		public static class SpecMessages
		{
			public const string OutOfBoundsMemoryAccess = "out of bounds memory access";

			public const string Unreachable = "unreachable";

			public const string CallStackExhausted = "call stack exhausted";

			public const string IntegerOverflow = "integer overflow";

			public const string InvalidConversionToInteger = "invalid conversion to integer";

			public const string MisalignedMemoryAccess = "misaligned memory access";

			public const string IndirectCallTypeMismatch = "indirect call type mismatch";

			public const string IntegerDivideByZero = "integer divide by zero";

			public const string UndefinedElement = "undefined element";

			public const string UninitializedElement = "uninitialized element";
		}

		public string SpecMessage
		{
			get;
			private set;
		}

		public TrapException(string message, string specMessage)
			: base(message)
		{
			SpecMessage = specMessage;
		}

		protected TrapException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
