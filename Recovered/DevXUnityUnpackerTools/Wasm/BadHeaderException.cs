using System.Runtime.CompilerServices;

namespace Wasm
{
	public sealed class BadHeaderException : WasmException
	{
		[CompilerGenerated]
		internal VersionHeader _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020;

		public VersionHeader Header
		{
			get;
			internal set;
		}

		public BadHeaderException(VersionHeader header, string message)
			: base(message)
		{
			Header = header;
		}
	}
}
