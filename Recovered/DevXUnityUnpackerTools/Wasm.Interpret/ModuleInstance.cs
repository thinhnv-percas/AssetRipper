using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Wasm.Instructions;

namespace Wasm.Interpret
{
	public sealed class ModuleInstance
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A
		{
			public static readonly _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = new _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A();

			public static Func<ModuleCompiler> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020;

			internal ModuleCompiler _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020()
			{
				return new InterpreterCompiler();
			}
		}

		[CompilerGenerated]
		internal InstructionInterpreter _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A;

		internal List<FunctionType> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A;

		internal List<LinearMemory> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020;

		internal List<Variable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A;

		internal List<FunctionDefinition> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020;

		internal List<FunctionTable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A;

		internal Dictionary<string, LinearMemory> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020;

		internal Dictionary<string, Variable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;

		internal Dictionary<string, FunctionDefinition> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020;

		internal Dictionary<string, FunctionTable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A;

		[CompilerGenerated]
		internal ExecutionPolicy _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020;

		public InstructionInterpreter Interpreter
		{
			get;
			internal set;
		}

		public ExecutionPolicy Policy
		{
			get;
			internal set;
		}

		public IList<FunctionType> Types => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A;

		public IList<LinearMemory> Memories => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020;

		public IList<FunctionDefinition> Functions => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020;

		public IList<Variable> Globals => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A;

		public IList<FunctionTable> Tables => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A;

		public IDictionary<string, LinearMemory> ExportedMemories => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020;

		public IDictionary<string, FunctionDefinition> ExportedFunctions => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020;

		public IDictionary<string, Variable> ExportedGlobals => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;

		public IDictionary<string, FunctionTable> ExportedTables => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A;

		internal ModuleInstance(InstructionInterpreter interpreter, ExecutionPolicy policy)
		{
			Interpreter = interpreter;
			Policy = policy;
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A = new List<FunctionType>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020 = new List<LinearMemory>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A = new List<Variable>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020 = new List<FunctionDefinition>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A = new List<FunctionTable>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = new Dictionary<string, LinearMemory>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = new Dictionary<string, Variable>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020 = new Dictionary<string, FunctionDefinition>();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A = new Dictionary<string, FunctionTable>();
		}

		public object Evaluate(InitializerExpression expression, WasmValueType resultType)
		{
			InterpreterContext interpreterContext = new InterpreterContext(this, new WasmValueType[1]
			{
				resultType
			});
			foreach (Wasm.Instructions.Instruction bodyInstruction in expression.BodyInstructions)
			{
				Interpreter.Interpret(bodyInstruction, interpreterContext);
			}
			object result = interpreterContext.Pop<object>();
			if (interpreterContext.StackDepth > 0)
			{
				throw new WasmException("The stack must contain exactly one value after evaluating an initializer expression. Actual stack depth: " + interpreterContext.StackDepth + ".");
			}
			return result;
		}

		public object Evaluate(InitializerExpression expression, Type resultType)
		{
			return Evaluate(expression, _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A(resultType));
		}

		public T Evaluate<T>(InitializerExpression expression)
		{
			return (T)Evaluate(expression, _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A<T>());
		}

		public IList<object> RunFunction(uint index, IList<object> arguments)
		{
			return _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020[(int)index].Invoke(arguments);
		}

		public static ModuleInstance Instantiate(WasmFile file, IImporter importer, InstructionInterpreter interpreter = null, ExecutionPolicy policy = null, Func<ModuleCompiler> compiler = null)
		{
			if (interpreter == null)
			{
				interpreter = DefaultInstructionInterpreter.Default;
			}
			if (policy == null)
			{
				policy = ExecutionPolicy.Create();
			}
			if (compiler == null)
			{
				compiler = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020;
			}
			ModuleInstance moduleInstance = new ModuleInstance(interpreter, policy);
			List<FunctionType> list = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020(file);
			moduleInstance._0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A.AddRange(list);
			moduleInstance._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020(file, importer, list);
			moduleInstance._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A(file);
			moduleInstance._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020(file, policy.MaxMemorySize);
			moduleInstance._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A(file, compiler(), list);
			moduleInstance._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A(file);
			moduleInstance._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020(file);
			return moduleInstance;
		}

		internal void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020(WasmFile _0020, IImporter _0020_000A, List<FunctionType> _0020_0020)
		{
			IList<ImportSection> sections = _0020.GetSections<ImportSection>();
			for (int i = 0; i < sections.Count; i++)
			{
				foreach (ImportedValue import in sections[i].Imports)
				{
					if (import is ImportedMemory)
					{
						LinearMemory linearMemory = _0020_000A.ImportMemory((ImportedMemory)import);
						if (linearMemory == null)
						{
							_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A(import, "linear memory");
						}
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020.Add(linearMemory);
					}
					else if (import is ImportedGlobal)
					{
						Variable variable = _0020_000A.ImportGlobal((ImportedGlobal)import);
						if (variable == null)
						{
							_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A(import, "global variable");
						}
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A.Add(variable);
					}
					else if (import is ImportedFunction)
					{
						ImportedFunction importedFunction = (ImportedFunction)import;
						FunctionDefinition functionDefinition = _0020_000A.ImportFunction(importedFunction, _0020_0020[(int)importedFunction.TypeIndex]);
						if (functionDefinition == null)
						{
							_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A(import, "function");
						}
						_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020(functionDefinition);
					}
					else
					{
						if (!(import is ImportedTable))
						{
							throw new WasmException("Unknown import type: " + import.ToString());
						}
						FunctionTable functionTable = _0020_000A.ImportTable((ImportedTable)import);
						if (functionTable == null)
						{
							_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A(import, "table");
						}
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A.Add(functionTable);
					}
				}
			}
		}

		internal static void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A(ImportedValue _0020, string _0020_000A)
		{
			throw new WasmException($"Importer cannot resolve {_0020_000A} definition '{_0020.ModuleName}.{_0020.FieldName}'.");
		}

		internal void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020(WasmFile _0020, uint _0020_000A)
		{
			IList<MemorySection> sections = _0020.GetSections<MemorySection>();
			for (int i = 0; i < sections.Count; i++)
			{
				foreach (MemoryType memory in sections[i].Memories)
				{
					if (_0020_000A == 0)
					{
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020.Add(new LinearMemory(memory.Limits));
					}
					else
					{
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020.Add(new LinearMemory(new ResizableLimits(memory.Limits.Initial, memory.Limits.HasMaximum ? Math.Min(memory.Limits.Maximum.Value, _0020_000A) : _0020_000A)));
					}
				}
			}
			IList<DataSection> sections2 = _0020.GetSections<DataSection>();
			for (int j = 0; j < sections2.Count; j++)
			{
				foreach (DataSegment segment in sections2[j].Segments)
				{
					LinearMemoryAsInt8 @int = Memories[(int)segment.MemoryIndex].Int8;
					int num = Evaluate<int>(segment.Offset);
					for (int k = 0; k < segment.Data.Length; k++)
					{
						@int[(uint)(num + k)] = (sbyte)segment.Data[k];
					}
				}
			}
		}

		internal void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A(WasmFile _0020)
		{
			IList<GlobalSection> sections = _0020.GetSections<GlobalSection>();
			for (int i = 0; i < sections.Count; i++)
			{
				foreach (GlobalVariable globalVariable in sections[i].GlobalVariables)
				{
					_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A.Add(Variable.Create(globalVariable.Type.ContentType, globalVariable.Type.IsMutable, Evaluate(globalVariable.InitialValue, globalVariable.Type.ContentType)));
				}
			}
		}

		internal static List<FunctionType> _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020(WasmFile _0020)
		{
			List<FunctionType> list = new List<FunctionType>();
			IList<TypeSection> sections = _0020.GetSections<TypeSection>();
			for (int i = 0; i < sections.Count; i++)
			{
				list.AddRange(sections[i].FunctionTypes);
			}
			return list;
		}

		internal void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A(WasmFile _0020, ModuleCompiler _0020_000A, List<FunctionType> _0020_0020)
		{
			List<FunctionType> list = new List<FunctionType>();
			List<FunctionBody> list2 = new List<FunctionBody>();
			IList<FunctionSection> sections = _0020.GetSections<FunctionSection>();
			for (int i = 0; i < sections.Count; i++)
			{
				foreach (uint functionType in sections[i].FunctionTypes)
				{
					list.Add(_0020_0020[(int)functionType]);
				}
			}
			IList<CodeSection> sections2 = _0020.GetSections<CodeSection>();
			for (int j = 0; j < sections2.Count; j++)
			{
				list2.AddRange(sections2[j].Bodies);
			}
			if (list.Count != list2.Count)
			{
				throw new WasmException("Function declaration/definition count mismatch: module declares " + list.Count + " functions and defines " + list2.Count + ".");
			}
			_0020_000A.Initialize(this, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020.Count, list);
			for (int k = 0; k < list.Count; k++)
			{
				_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020(_0020_000A.Compile(k, list2[k]));
			}
			_0020_000A.Finish();
		}

		internal void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020(FunctionDefinition _0020)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020.Add(_0020);
		}

		internal void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A(WasmFile _0020)
		{
			IList<TableSection> sections = _0020.GetSections<TableSection>();
			for (int i = 0; i < sections.Count; i++)
			{
				foreach (TableType table in sections[i].Tables)
				{
					_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A.Add(new FunctionTable(table.Limits));
				}
			}
			IList<ElementSection> sections2 = _0020.GetSections<ElementSection>();
			for (int j = 0; j < sections2.Count; j++)
			{
				foreach (ElementSegment segment in sections2[j].Segments)
				{
					FunctionTable functionTable = Tables[(int)segment.TableIndex];
					int num = Evaluate<int>(segment.Offset);
					for (int k = 0; k < segment.Elements.Count; k++)
					{
						functionTable[(uint)(num + k)] = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020[(int)segment.Elements[k]];
					}
				}
			}
		}

		internal void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020(WasmFile _0020)
		{
			IList<ExportSection> sections = _0020.GetSections<ExportSection>();
			for (int i = 0; i < sections.Count; i++)
			{
				foreach (ExportedValue export in sections[i].Exports)
				{
					switch (export.Kind)
					{
					case ExternalKind.Memory:
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020[export.Name] = Memories[(int)export.Index];
						break;
					case ExternalKind.Global:
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A[export.Name] = Globals[(int)export.Index];
						break;
					case ExternalKind.Function:
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020[export.Name] = Functions[(int)export.Index];
						break;
					case ExternalKind.Table:
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A[export.Name] = Tables[(int)export.Index];
						break;
					default:
						throw new WasmException("Unknown export kind: " + export.Kind);
					}
				}
			}
		}
	}
}
