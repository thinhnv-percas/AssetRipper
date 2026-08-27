using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class ImportedMemory : ImportedValue
	{
		[CompilerGenerated]
		internal MemoryType _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		public MemoryType Memory
		{
			get;
			set;
		}

		public override ExternalKind Kind => ExternalKind.Memory;

		public ImportedMemory(string moduleName, string fieldName, MemoryType memory)
			: base(moduleName, fieldName)
		{
			Memory = memory;
		}

		internal override void DumpContents(TextWriter writer)
		{
			Memory.Dump(writer);
		}

		internal override void WriteContentsTo(BinaryWasmWriter writer)
		{
			Memory.WriteTo(writer);
		}
	}
}
