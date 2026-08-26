using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public struct ExportedValue
	{
		[CompilerGenerated]
		private string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		private ExternalKind _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private uint _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		public string Name
		{
			get;
			private set;
		}

		public ExternalKind Kind
		{
			get;
			private set;
		}

		public uint Index
		{
			get;
			private set;
		}

		public ExportedValue(string name, ExternalKind kind, uint index)
		{
			Name = name;
			Kind = kind;
			Index = index;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteString(Name);
			writer.Writer.Write((byte)Kind);
			writer.WriteVarUInt32(Index);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("\"");
			writer.Write(Name);
			writer.Write("\", ");
			writer.Write(Kind.ToString().ToLower());
			writer.Write(" #");
			writer.Write(Index);
		}
	}
}
