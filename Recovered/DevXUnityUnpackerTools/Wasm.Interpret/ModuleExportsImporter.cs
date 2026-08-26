using System.Runtime.CompilerServices;
using Wasm.Optimize;

namespace Wasm.Interpret
{
	public sealed class ModuleExportsImporter : IImporter
	{
		[CompilerGenerated]
		internal ModuleInstance _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020;

		public ModuleInstance Module
		{
			get;
			internal set;
		}

		public ModuleExportsImporter(ModuleInstance module)
		{
			Module = module;
		}

		public FunctionDefinition ImportFunction(ImportedFunction description, FunctionType signature)
		{
			if (Module.ExportedFunctions.TryGetValue(description.FieldName, out FunctionDefinition value) && ConstFunctionTypeComparer.Instance.Equals(signature, new FunctionType(value.ParameterTypes, value.ReturnTypes)))
			{
				return value;
			}
			return null;
		}

		public Variable ImportGlobal(ImportedGlobal description)
		{
			Variable value;
			if (Module.ExportedGlobals.TryGetValue(description.FieldName, out value) && description.Global.ContentType == value.Type && description.Global.IsMutable == value.IsMutable)
			{
				return value;
			}
			return null;
		}

		public LinearMemory ImportMemory(ImportedMemory description)
		{
			if (Module.ExportedMemories.TryGetValue(description.FieldName, out LinearMemory value) && value.Limits.Initial >= description.Memory.Limits.Initial)
			{
				return value;
			}
			return null;
		}

		public FunctionTable ImportTable(ImportedTable description)
		{
			if (Module.ExportedTables.TryGetValue(description.FieldName, out FunctionTable value) && value.Limits.Initial >= description.Table.Limits.Initial)
			{
				return value;
			}
			return null;
		}
	}
}
