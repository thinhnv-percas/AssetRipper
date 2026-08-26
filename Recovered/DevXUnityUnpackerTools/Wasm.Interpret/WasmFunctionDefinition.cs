using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Wasm.Instructions;

namespace Wasm.Interpret
{
	public sealed class WasmFunctionDefinition : FunctionDefinition
	{
		[CompilerGenerated]
		internal FunctionType _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020;

		internal FunctionBody _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A;

		[CompilerGenerated]
		internal ModuleInstance _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020;

		public FunctionType Signature
		{
			get;
			internal set;
		}

		public ModuleInstance Module
		{
			get;
			internal set;
		}

		public override IList<WasmValueType> ParameterTypes => Signature.ParameterTypes;

		public override IList<WasmValueType> ReturnTypes => Signature.ReturnTypes;

		public WasmFunctionDefinition(FunctionType signature, FunctionBody body, ModuleInstance module)
		{
			Signature = signature;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A = body;
			Module = module;
		}

		public override IList<object> Invoke(IList<object> arguments, uint callStackDepth = 0u)
		{
			List<Variable> list = new List<Variable>();
			if (Signature.ParameterTypes.Count != arguments.Count)
			{
				throw new WasmException("Function arity mismatch: function has " + Signature.ParameterTypes.Count + " parameters and is given " + arguments.Count + " arguments.");
			}
			for (int i = 0; i < Signature.ParameterTypes.Count; i++)
			{
				list.Add(Variable.Create(Signature.ParameterTypes[i], isMutable: true, arguments[i]));
			}
			foreach (LocalEntry local in _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A.Locals)
			{
				for (int j = 0; j < local.LocalCount; j++)
				{
					list.Add(Variable.CreateDefault(local.LocalType, isMutable: true));
				}
			}
			IList<object> returnValues = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020(callStackDepth, list).ReturnValues;
			if (returnValues.Count != Signature.ReturnTypes.Count)
			{
				throw new WasmException("Return value arity mismatch: function expects " + Signature.ReturnTypes.Count + " return values but is given " + returnValues.Count + " return values.");
			}
			for (int k = 0; k < returnValues.Count; k++)
			{
				if (!Variable.IsInstanceOf(returnValues[k], Signature.ReturnTypes[k]))
				{
					throw new WasmException("Return type mismatch: function has return type '" + Signature.ReturnTypes[k].ToString() + " but is given a return value of type '" + returnValues[k].GetType().Name + "'.");
				}
			}
			return returnValues;
		}

		internal InterpreterContext _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020(uint _0020, List<Variable> _0020_000A)
		{
			if (Module.Policy.TranslateExceptions)
			{
				try
				{
					return _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A(_0020, _0020_000A);
				}
				catch (DivideByZeroException ex)
				{
					throw new TrapException(ex.Message, "integer divide by zero");
				}
				catch (OverflowException ex2)
				{
					throw new TrapException(ex2.Message, "integer overflow");
				}
			}
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A(_0020, _0020_000A);
		}

		internal InterpreterContext _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A(uint _0020, List<Variable> _0020_000A)
		{
			InterpreterContext interpreterContext = new InterpreterContext(Module, ReturnTypes, _0020_000A, Module.Policy, _0020 + 1);
			InstructionInterpreter interpreter = Module.Interpreter;
			foreach (Wasm.Instructions.Instruction bodyInstruction in _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A.BodyInstructions)
			{
				interpreter.Interpret(bodyInstruction, interpreterContext);
				if (interpreterContext.BreakRequested)
				{
					OperatorImpls.Return(interpreterContext);
					break;
				}
			}
			interpreterContext.Return();
			return interpreterContext;
		}
	}
}
