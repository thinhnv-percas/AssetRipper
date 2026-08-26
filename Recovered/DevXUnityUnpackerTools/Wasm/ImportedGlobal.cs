using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class ImportedGlobal : ImportedValue
	{
		[CompilerGenerated]
		private GlobalType _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020;

		public GlobalType Global
		{
			get;
			set;
		}

		public override ExternalKind Kind => ExternalKind.Global;

		public ImportedGlobal(string moduleName, string fieldName, GlobalType global)
			: base(moduleName, fieldName)
		{
			Global = global;
		}

		protected override void DumpContents(TextWriter writer)
		{
			Global.Dump(writer);
		}

		protected override void WriteContentsTo(BinaryWasmWriter writer)
		{
			Global.WriteTo(writer);
		}
	}
}
