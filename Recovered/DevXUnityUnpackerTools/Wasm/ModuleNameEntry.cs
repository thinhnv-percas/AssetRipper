using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class ModuleNameEntry : NameEntry
	{
		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020;

		public override NameEntryKind Kind => NameEntryKind.Module;

		public string ModuleName
		{
			get;
			set;
		}

		public ModuleNameEntry(string moduleName)
		{
			ModuleName = moduleName;
		}

		public override void WritePayloadTo(BinaryWasmWriter writer)
		{
			writer.WriteString(ModuleName);
		}

		public override void Dump(TextWriter writer)
		{
			writer.Write("module name: {0}", ModuleName);
		}

		public static ModuleNameEntry ReadPayload(BinaryWasmReader reader, uint length)
		{
			return new ModuleNameEntry(reader.ReadString());
		}
	}
}
