using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class UnknownSection : Section
	{
		[CompilerGenerated]
		private SectionCode _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A;

		[CompilerGenerated]
		private byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020;

		public SectionCode Code
		{
			get;
			private set;
		}

		public override SectionName Name => new SectionName(Code);

		public byte[] Payload
		{
			get;
			private set;
		}

		public UnknownSection(SectionCode code, byte[] payload)
		{
			Code = code;
			Payload = payload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.Writer.Write(Payload);
		}
	}
}
