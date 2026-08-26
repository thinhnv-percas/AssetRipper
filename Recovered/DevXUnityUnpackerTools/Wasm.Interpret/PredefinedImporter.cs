using System.Collections.Generic;

namespace Wasm.Interpret
{
	public sealed class PredefinedImporter : IImporter
	{
		internal Dictionary<string, FunctionDefinition> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A;

		internal Dictionary<string, Variable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020;

		internal Dictionary<string, LinearMemory> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A;

		internal Dictionary<string, FunctionTable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020;

		public IDictionary<string, FunctionDefinition> FunctionDefinitions => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A;

		public IDictionary<string, Variable> VariableDefinitions => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020;

		public IDictionary<string, LinearMemory> MemoryDefinitions => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A;

		public IDictionary<string, FunctionTable> TableDefinitions => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020;

		public PredefinedImporter()
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A = new Dictionary<string, FunctionDefinition>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 = new Dictionary<string, Variable>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A = new Dictionary<string, LinearMemory>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 = new Dictionary<string, FunctionTable>();
		}

		public void DefineFunction(string name, FunctionDefinition definition)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A[name] = definition;
		}

		public void DefineVariable(string name, Variable definition)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020[name] = definition;
		}

		public void DefineMemory(string name, LinearMemory definition)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A[name] = definition;
		}

		public void DefineTable(string name, FunctionTable definition)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020[name] = definition;
		}

		public void IncludeDefinitions(PredefinedImporter importer)
		{
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_00601(importer._0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A);
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_00601(importer._0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020);
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_00601(importer._0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A);
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_00601(importer._0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020);
		}

		internal static void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_00601<_0020_0020>(Dictionary<string, _0020_0020> _0020, Dictionary<string, _0020_0020> _0020_000A)
		{
			foreach (KeyValuePair<string, _0020_0020> item in _0020)
			{
				_0020_000A[item.Key] = item.Value;
			}
		}

		internal static _0020_0020 _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_00601<_0020_0020>(ImportedValue _0020, Dictionary<string, _0020_0020> _0020_000A)
		{
			if (_0020_000A.TryGetValue(_0020.FieldName, out _0020_0020 value))
			{
				return value;
			}
			return default(_0020_0020);
		}

		public FunctionDefinition ImportFunction(ImportedFunction description, FunctionType signature)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_00601(description, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A);
		}

		public Variable ImportGlobal(ImportedGlobal description)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_00601(description, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020);
		}

		public LinearMemory ImportMemory(ImportedMemory description)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_00601(description, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A);
		}

		public FunctionTable ImportTable(ImportedTable description)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_00601(description, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020);
		}
	}
}
