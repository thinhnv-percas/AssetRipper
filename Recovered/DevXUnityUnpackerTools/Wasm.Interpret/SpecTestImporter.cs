using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class SpecTestImporter : IImporter
	{
		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal TextWriter _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A;

		internal Variable _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020;

		internal Variable _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A;

		internal Variable _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020;

		public string PrintSuffix
		{
			get;
			internal set;
		}

		public TextWriter PrintWriter
		{
			get;
			internal set;
		}

		public SpecTestImporter()
			: this(Environment.NewLine)
		{
		}

		public SpecTestImporter(TextWriter printWriter)
			: this(printWriter.NewLine, printWriter)
		{
		}

		public SpecTestImporter(string printSuffix)
			: this(printSuffix, ConsoleManager._0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020)
		{
		}

		public SpecTestImporter(string printSuffix, TextWriter printWriter)
		{
			PrintSuffix = printSuffix;
			PrintWriter = printWriter;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 = Variable.Create(WasmValueType.Int32, isMutable: false, 666);
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A = Variable.Create(WasmValueType.Float32, isMutable: false, 666f);
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020 = Variable.Create(WasmValueType.Float64, isMutable: false, 666.0);
		}

		public FunctionDefinition ImportFunction(ImportedFunction description, FunctionType signature)
		{
			switch (description.FieldName)
			{
			case "print":
			case "print_i32":
			case "print_i32_f32":
			case "print_f64_f64":
			case "print_f32":
			case "print_f64":
				return new _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020(signature.ParameterTypes, signature.ReturnTypes, PrintSuffix, PrintWriter);
			default:
				return null;
			}
		}

		public Variable ImportGlobal(ImportedGlobal description)
		{
			switch (description.FieldName)
			{
			case "global_i32":
				return _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020;
			case "global_f32":
				return _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A;
			case "global_f64":
				return _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020;
			default:
				return null;
			}
		}

		public LinearMemory ImportMemory(ImportedMemory description)
		{
			if (description.FieldName == "memory")
			{
				return new LinearMemory(new ResizableLimits(1u, 2u));
			}
			return null;
		}

		public FunctionTable ImportTable(ImportedTable description)
		{
			if (description.FieldName == "table")
			{
				return new FunctionTable(new ResizableLimits(10u, 20u));
			}
			return null;
		}
	}
}
