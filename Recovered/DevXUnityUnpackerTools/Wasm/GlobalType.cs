using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class GlobalType
	{
		[CompilerGenerated]
		internal WasmValueType _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020;

		public WasmValueType ContentType
		{
			get;
			set;
		}

		public bool IsMutable
		{
			get;
			set;
		}

		public GlobalType(WasmValueType contentType, bool isMutable)
		{
			ContentType = contentType;
			IsMutable = isMutable;
		}

		public static GlobalType ReadFrom(BinaryWasmReader reader)
		{
			return new GlobalType(reader.ReadWasmValueType(), reader.ReadVarUInt1());
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteWasmValueType(ContentType);
			writer.WriteVarUInt1(IsMutable);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("{type: ");
			DumpHelpers.DumpWasmType(ContentType, writer);
			writer.Write(", is_mutable: ");
			writer.Write(IsMutable);
			writer.Write("}");
		}
	}
}
