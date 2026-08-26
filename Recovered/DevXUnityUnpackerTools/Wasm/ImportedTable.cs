using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class ImportedTable : ImportedValue
	{
		[CompilerGenerated]
		private TableType _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020;

		public TableType Table
		{
			get;
			set;
		}

		public override ExternalKind Kind => ExternalKind.Table;

		public ImportedTable(string moduleName, string fieldName, TableType table)
			: base(moduleName, fieldName)
		{
			Table = table;
		}

		protected override void DumpContents(TextWriter writer)
		{
			Table.Dump(writer);
		}

		protected override void WriteContentsTo(BinaryWasmWriter writer)
		{
			Table.WriteTo(writer);
		}
	}
}
