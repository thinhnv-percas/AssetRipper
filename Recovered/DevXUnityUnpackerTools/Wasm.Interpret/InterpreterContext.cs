using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class InterpreterContext
	{
		public struct EvaluationStack
		{
			internal Stack<object> _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A;
		}

		[CompilerGenerated]
		internal ModuleInstance _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		internal IList<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal IList<Variable> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		internal ExecutionPolicy _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020;

		internal Stack<object> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal IList<object> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		internal int _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A;

		public ModuleInstance Module
		{
			get;
			internal set;
		}

		public IList<WasmValueType> ReturnTypes
		{
			get;
			internal set;
		}

		public IList<Variable> Locals
		{
			get;
			internal set;
		}

		public ExecutionPolicy Policy
		{
			get;
			internal set;
		}

		public uint CallStackDepth
		{
			get;
			internal set;
		}

		public EvaluationStack Stack
		{
			get
			{
				EvaluationStack result = default(EvaluationStack);
				result._0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A;
				return result;
			}
			set
			{
				_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A = value._0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A;
			}
		}

		public IList<object> ReturnValues
		{
			get;
			internal set;
		}

		public int StackDepth => _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A.Count;

		public bool HasReturned => ReturnValues != null;

		public int BreakDepth
		{
			get;
			set;
		}

		public bool BreakRequested => BreakDepth >= 0;

		public InterpreterContext(ModuleInstance module, IList<WasmValueType> returnTypes)
			: this(module, returnTypes, new Variable[0])
		{
		}

		public InterpreterContext(ModuleInstance module, IList<WasmValueType> returnTypes, IList<Variable> locals)
			: this(module, returnTypes, locals, ExecutionPolicy.Create())
		{
		}

		public InterpreterContext(ModuleInstance module, IList<WasmValueType> returnTypes, IList<Variable> locals, ExecutionPolicy policy, uint callStackDepth = 0u)
		{
			Module = module;
			ReturnTypes = returnTypes;
			Locals = locals;
			Policy = policy;
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A = new Stack<object>();
			ReturnValues = null;
			BreakDepth = -1;
			CallStackDepth = callStackDepth;
		}

		public T Pop<T>()
		{
			if (StackDepth == 0)
			{
				throw new WasmException("Cannot pop an element from an empty stack.");
			}
			return (T)_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A.Pop();
		}

		public T[] Pop<T>(int count)
		{
			T[] array = new T[count];
			for (int num = count - 1; num >= 0; num--)
			{
				array[num] = Pop<T>();
			}
			return array;
		}

		public bool Return()
		{
			if (HasReturned)
			{
				return false;
			}
			ReturnValues = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A.ToArray();
			return true;
		}

		public T Peek<T>()
		{
			if (StackDepth == 0)
			{
				throw new WasmException("Cannot peek an element from an empty stack.");
			}
			return (T)_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A.Peek();
		}

		public void Push<T>(T value)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A.Push(value);
		}

		public void Push<T>(IEnumerable<T> values)
		{
			foreach (T value in values)
			{
				Push(value);
			}
		}

		public void Push(EvaluationStack stack)
		{
			Push(stack._0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A.Reverse());
		}

		public void Push(EvaluationStack stack, int count)
		{
			Push(stack._0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A.Take(count).Reverse());
		}

		public EvaluationStack CreateStack()
		{
			EvaluationStack result = default(EvaluationStack);
			result._0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A = new Stack<object>();
			return result;
		}
	}
}
