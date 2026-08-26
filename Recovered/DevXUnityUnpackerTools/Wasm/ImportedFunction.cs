using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class ImportedFunction : ImportedValue
	{
		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020;

		public uint TypeIndex
		{
			get;
			set;
		}

		public override ExternalKind Kind => ExternalKind.Function;

		public ImportedFunction(string moduleName, string fieldName, uint typeIndex)
			: base(moduleName, fieldName)
		{
			TypeIndex = typeIndex;
		}

		protected override void DumpContents(TextWriter writer)
		{
			writer.Write("type #{0}", TypeIndex);
		}

		protected override void WriteContentsTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32(TypeIndex);
		}
	}
}
