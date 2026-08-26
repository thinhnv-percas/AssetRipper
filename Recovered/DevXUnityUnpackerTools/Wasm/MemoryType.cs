using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class MemoryType
	{
		[CompilerGenerated]
		private ResizableLimits _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A;

		public const uint PageSize = 65536u;

		public ResizableLimits Limits
		{
			get;
			set;
		}

		public MemoryType(ResizableLimits limits)
		{
			Limits = limits;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			Limits.WriteTo(writer);
		}

		public void Dump(TextWriter writer)
		{
			Limits.Dump(writer);
		}

		public static MemoryType ReadFrom(BinaryWasmReader reader)
		{
			return new MemoryType(reader.ReadResizableLimits());
		}
	}
}
