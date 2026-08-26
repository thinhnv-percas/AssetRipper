using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class CustomSection : Section
	{
		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020;

		public string CustomName
		{
			get;
			internal set;
		}

		public override SectionName Name => new SectionName(CustomName);

		public byte[] Payload
		{
			get;
			internal set;
		}

		public CustomSection(string customName, byte[] payload)
		{
			CustomName = customName;
			Payload = payload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.Writer.Write(Payload);
		}
	}
}
