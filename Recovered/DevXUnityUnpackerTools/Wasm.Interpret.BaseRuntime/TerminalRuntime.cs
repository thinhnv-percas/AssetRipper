using System.Collections.Generic;
using System.IO;

namespace Wasm.Interpret.BaseRuntime
{
	public sealed class TerminalRuntime
	{
		private Stream _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020;

		private Stream _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A;

		private Stream _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020;

		private readonly PredefinedImporter _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A;

		private TerminalRuntime(Stream inputStream, Stream outputStream, Stream errorStream)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020 = inputStream;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = outputStream;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020 = errorStream;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A = new PredefinedImporter();
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A.DefineFunction("stdin_read", new DelegateFunctionDefinition(new WasmValueType[0], new WasmValueType[1]
			{
				WasmValueType.Int32
			}, _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020));
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A.DefineFunction("stdout_write", new DelegateFunctionDefinition(new WasmValueType[1]
			{
				WasmValueType.Int32
			}, new WasmValueType[0], _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A));
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A.DefineFunction("stderr_write", new DelegateFunctionDefinition(new WasmValueType[1]
			{
				WasmValueType.Int32
			}, new WasmValueType[0], _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020));
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A.DefineFunction("stdin_flush", new DelegateFunctionDefinition(new WasmValueType[0], new WasmValueType[0], _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A));
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A.DefineFunction("stdout_flush", new DelegateFunctionDefinition(new WasmValueType[0], new WasmValueType[0], _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020));
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A.DefineFunction("stderr_flush", new DelegateFunctionDefinition(new WasmValueType[0], new WasmValueType[0], _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A));
		}

		private void _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(PredefinedImporter _0020)
		{
			_0020.IncludeDefinitions(_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A);
		}

		public static void IncludeDefinitionsIn(Stream inputStream, Stream outputStream, Stream errorStream, PredefinedImporter importer)
		{
			new TerminalRuntime(inputStream, outputStream, errorStream)._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(importer);
		}

		private IList<object> _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(IList<object> _0020)
		{
			return new object[1]
			{
				_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020.ReadByte()
			};
		}

		private IList<object> _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A(IList<object> _0020)
		{
			object obj = _0020[0];
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A.WriteByte((byte)(int)obj);
			return new object[0];
		}

		private IList<object> _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020(IList<object> _0020)
		{
			object obj = _0020[0];
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020.WriteByte((byte)(int)obj);
			return new object[0];
		}

		private IList<object> _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A(IList<object> _0020)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020.Flush();
			return new object[0];
		}

		private IList<object> _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020(IList<object> _0020)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020.Flush();
			return new object[0];
		}

		private IList<object> _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A(IList<object> _0020)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020.Flush();
			return new object[0];
		}
	}
}
