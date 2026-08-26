using System.Collections.Generic;

namespace Wasm.Interpret
{
	public sealed class NamespacedImporter : IImporter
	{
		internal Dictionary<string, IImporter> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A;

		public NamespacedImporter()
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A = new Dictionary<string, IImporter>();
		}

		public void RegisterImporter(string moduleName, IImporter importer)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A[moduleName] = importer;
		}

		public FunctionDefinition ImportFunction(ImportedFunction description, FunctionType signature)
		{
			if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A.TryGetValue(description.ModuleName, out IImporter value))
			{
				return value.ImportFunction(description, signature);
			}
			return null;
		}

		public Variable ImportGlobal(ImportedGlobal description)
		{
			if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A.TryGetValue(description.ModuleName, out IImporter value))
			{
				return value.ImportGlobal(description);
			}
			return null;
		}

		public LinearMemory ImportMemory(ImportedMemory description)
		{
			if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A.TryGetValue(description.ModuleName, out IImporter value))
			{
				return value.ImportMemory(description);
			}
			return null;
		}

		public FunctionTable ImportTable(ImportedTable description)
		{
			if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A.TryGetValue(description.ModuleName, out IImporter value))
			{
				return value.ImportTable(description);
			}
			return null;
		}
	}
}
