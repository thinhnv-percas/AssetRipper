using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public struct ExportedValue
	{
		[CompilerGenerated]
		internal string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal ExternalKind _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		internal uint _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		public string Name
		{
			get;
			internal set;
		}

		public ExternalKind Kind
		{
			get;
			internal set;
		}

		public uint Index
		{
			get;
			internal set;
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
