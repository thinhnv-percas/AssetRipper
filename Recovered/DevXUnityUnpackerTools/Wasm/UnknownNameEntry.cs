using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class UnknownNameEntry : NameEntry
	{
		internal NameEntryKind _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020;

		public byte[] Payload
		{
			get;
			set;
		}

		public override NameEntryKind Kind => _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A;

		public UnknownNameEntry(NameEntryKind kind, byte[] payload)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A = kind;
			Payload = payload;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.Writer.Write(Payload);
		}

		public static UnknownNameEntry ReadPayload(BinaryWasmReader reader, NameEntryKind kind, uint length)
		{
			return new UnknownNameEntry(kind, reader.ReadBytes((int)length));
		}
	}
}
