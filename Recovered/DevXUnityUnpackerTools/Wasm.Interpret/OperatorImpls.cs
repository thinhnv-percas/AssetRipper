using System;
using System.Collections.Generic;
using Wasm.Instructions;
using Wasm.Optimize;

namespace Wasm.Interpret
{
	public static class OperatorImpls
	{
		public static void Unreachable(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			throw new TrapException("An 'unreachable' instruction was reached.", "unreachable");
		}

		public static void Nop(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
		}

		public static void Block(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			BlockInstruction blockInstruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.CastInstruction(value);
			List<Wasm.Instructions.Instruction> contents = blockInstruction.Contents;
			InstructionInterpreter interpreter = context.Module.Interpreter;
			InterpreterContext.EvaluationStack stack = context.Stack;
			InterpreterContext.EvaluationStack evaluationStack2 = context.Stack = context.CreateStack();
			InterpreterContext.EvaluationStack stack2 = evaluationStack2;
			for (int i = 0; i < contents.Count; i++)
			{
				interpreter.Interpret(contents[i], context);
				if (context.BreakRequested)
				{
					context.Stack = stack;
					if (context.BreakDepth == 0)
					{
						context.Push(stack2, blockInstruction.Arity);
					}
					else
					{
						context.Push(stack2);
					}
					context.BreakDepth--;
					return;
				}
			}
			context.Stack = stack;
			context.Push(stack2);
		}

		public static void Loop(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			List<Wasm.Instructions.Instruction> contents = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020.CastInstruction(value).Contents;
			InstructionInterpreter interpreter = context.Module.Interpreter;
			int num = 0;
			while (true)
			{
				if (num >= contents.Count)
				{
					return;
				}
				interpreter.Interpret(contents[num], context);
				if (context.BreakRequested)
				{
					if (context.BreakDepth != 0)
					{
						break;
					}
					context.BreakDepth--;
					num = 0;
				}
				else
				{
					num++;
				}
			}
			context.BreakDepth--;
		}

		public static void If(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			IfElseInstruction ifElseInstruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A.CastInstruction(value);
			List<Wasm.Instructions.Instruction> list = (context.Pop<int>() != 0) ? ifElseInstruction.IfBranch : ifElseInstruction.ElseBranch;
			if (list != null)
			{
				Block(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Create(ifElseInstruction.Type, list), context);
			}
		}

		public static void Br(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020.CastInstruction(value);
			context.BreakDepth = (int)varUInt32Instruction.Immediate;
		}

		public static void BrIf(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A.CastInstruction(value);
			if (context.Pop<int>() != 0)
			{
				context.BreakDepth = (int)varUInt32Instruction.Immediate;
			}
		}

		public static void BrTable(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			BrTableInstruction brTableInstruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020.CastInstruction(value);
			int num = context.Pop<int>();
			if (num < 0 || num >= brTableInstruction.TargetTable.Count)
			{
				context.BreakDepth = (int)brTableInstruction.DefaultTarget;
			}
			else
			{
				context.BreakDepth = (int)brTableInstruction.TargetTable[num];
			}
		}

		public static void Return(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			Return(context);
		}

		public static void Return(InterpreterContext context)
		{
			InterpreterContext.EvaluationStack stack = context.Stack;
			context.Stack = context.CreateStack();
			context.Push(stack, context.ReturnTypes.Count);
			context.Return();
		}

		public static void Drop(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Pop<object>();
		}

		public static void Select(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			object obj = context.Pop<object>();
			object obj2 = context.Pop<object>();
			context.Push((num != 0) ? obj2 : obj);
		}

		public static void Call(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020.CastInstruction(value);
			FunctionDefinition functionDefinition = context.Module.Functions[(int)varUInt32Instruction.Immediate];
			object[] arguments = context.Pop<object>(functionDefinition.ParameterTypes.Count);
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(context);
			IList<object> values = functionDefinition.Invoke(arguments, context.CallStackDepth);
			context.Push((IEnumerable<object>)values);
		}

		private static void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(InterpreterContext _0020)
		{
			if (_0020.CallStackDepth >= _0020.Policy.MaxCallStackDepth)
			{
				throw new TrapException("A stack overflow occurred: the max call stack depth was exceeded.", "call stack exhausted");
			}
		}

		public static void CallIndirect(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int index = context.Pop<int>();
			FunctionDefinition functionDefinition = context.Module.Tables[0][(uint)index];
			if (!(functionDefinition is ThrowFunctionDefinition))
			{
				FunctionType functionType = new FunctionType(functionDefinition.ParameterTypes, functionDefinition.ReturnTypes);
				_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020 _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020(value);
				FunctionType functionType2 = context.Module.Types[(int)_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020.TypeIndex];
				if (!ConstFunctionTypeComparer.Instance.Equals(functionType, functionType2))
				{
					throw new TrapException($"Indirect function call expected to refer to a function with signature '{functionType}' but " + $"instead found a function with signature '{functionType2}'", "indirect call type mismatch");
				}
			}
			object[] arguments = context.Pop<object>(functionDefinition.ParameterTypes.Count);
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(context);
			IList<object> values = functionDefinition.Invoke(arguments, context.CallStackDepth);
			context.Push((IEnumerable<object>)values);
		}

		public static void GetLocal(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020.CastInstruction(value);
			context.Push(context.Locals[(int)varUInt32Instruction.Immediate].Get<object>());
		}

		public static void SetLocal(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A.CastInstruction(value);
			context.Locals[(int)varUInt32Instruction.Immediate].Set(context.Pop<object>());
		}

		public static void TeeLocal(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020.CastInstruction(value);
			context.Locals[(int)varUInt32Instruction.Immediate].Set(context.Peek<object>());
		}

		public static void GetGlobal(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A.CastInstruction(value);
			context.Push(context.Module.Globals[(int)varUInt32Instruction.Immediate].Get<object>());
		}

		public static void SetGlobal(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020.CastInstruction(value);
			context.Module.Globals[(int)varUInt32Instruction.Immediate].Set(context.Pop<object>());
		}

		public static void Int32Load(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A.CastInstruction(value), context);
			int value2 = context.Module.Memories[0].Int32[offset];
			context.Push(value2);
		}

		public static void Int64Load(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020.CastInstruction(value), context);
			long value2 = context.Module.Memories[0].Int64[offset];
			context.Push(value2);
		}

		public static void Int32Load8S(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A.CastInstruction(value), context);
			sbyte value2 = context.Module.Memories[0].Int8[offset];
			context.Push((int)value2);
		}

		public static void Int32Load8U(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020.CastInstruction(value), context);
			byte value2 = (byte)context.Module.Memories[0].Int8[offset];
			context.Push((int)value2);
		}

		public static void Int32Load16S(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A.CastInstruction(value), context);
			short value2 = context.Module.Memories[0].Int16[offset];
			context.Push((int)value2);
		}

		public static void Int32Load16U(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020.CastInstruction(value), context);
			ushort value2 = (ushort)context.Module.Memories[0].Int16[offset];
			context.Push((int)value2);
		}

		public static void Int64Load8S(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A.CastInstruction(value), context);
			sbyte b = context.Module.Memories[0].Int8[offset];
			context.Push((long)b);
		}

		public static void Int64Load8U(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020.CastInstruction(value), context);
			byte b = (byte)context.Module.Memories[0].Int8[offset];
			context.Push((long)b);
		}

		public static void Int64Load16S(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A.CastInstruction(value), context);
			short num = context.Module.Memories[0].Int16[offset];
			context.Push((long)num);
		}

		public static void Int64Load16U(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020.CastInstruction(value), context);
			ushort num = (ushort)context.Module.Memories[0].Int16[offset];
			context.Push((long)num);
		}

		public static void Int64Load32S(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A.CastInstruction(value), context);
			int num = context.Module.Memories[0].Int32[offset];
			context.Push((long)num);
		}

		public static void Int64Load32U(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020.CastInstruction(value), context);
			uint num = (uint)context.Module.Memories[0].Int32[offset];
			context.Push((long)num);
		}

		public static void Float32Load(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A.CastInstruction(value), context);
			float value2 = context.Module.Memories[0].Float32[offset];
			context.Push(value2);
		}

		public static void Float64Load(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020.CastInstruction(value), context);
			double value2 = context.Module.Memories[0].Float64[offset];
			context.Push(value2);
		}

		public static void Int32Store8(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A.CastInstruction(value);
			int num = context.Pop<int>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Int8[offset] = (sbyte)num;
		}

		public static void Int32Store16(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.CastInstruction(value);
			int num = context.Pop<int>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Int16[offset] = (short)num;
		}

		public static void Int32Store(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A.CastInstruction(value);
			int value2 = context.Pop<int>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Int32[offset] = value2;
		}

		public static void Int64Store8(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A.CastInstruction(value);
			long num = context.Pop<long>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Int8[offset] = (sbyte)num;
		}

		public static void Int64Store16(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020.CastInstruction(value);
			long num = context.Pop<long>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Int16[offset] = (short)num;
		}

		public static void Int64Store32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A.CastInstruction(value);
			long num = context.Pop<long>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Int32[offset] = (int)num;
		}

		public static void Int64Store(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020.CastInstruction(value);
			long value2 = context.Pop<long>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Int64[offset] = value2;
		}

		public static void Float32Store(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A.CastInstruction(value);
			float value2 = context.Pop<float>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Float32[offset] = value2;
		}

		public static void Float64Store(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			MemoryInstruction _0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020.CastInstruction(value);
			double value2 = context.Pop<double>();
			uint offset = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(_0020, context);
			context.Module.Memories[0].Float64[offset] = value2;
		}

		private static uint _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(MemoryInstruction _0020, InterpreterContext _0020_000A)
		{
			long num = (long)(uint)_0020_000A.Pop<int>() + (long)_0020.Offset;
			if ((ulong)num > 4294967295uL)
			{
				throw new TrapException("Memory address overflow.", "out of bounds memory access");
			}
			uint num2 = (uint)num;
			if (_0020_000A.Policy.EnforceAlignment)
			{
				_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A(num2, _0020);
			}
			return num2;
		}

		private static void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A(uint _0020, MemoryInstruction _0020_000A)
		{
			if (_0020 % _0020_000A.Alignment != 0)
			{
				throw new TrapException($"Misaligned memory access at {DumpHelpers.FormatHex(_0020)}. (alignment: {_0020_000A.Alignment})", "misaligned memory access");
			}
		}

		public static void CurrentMemory(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020.CastInstruction(value);
			uint size = context.Module.Memories[(int)varUInt32Instruction.Immediate].Size;
			context.Push((int)size);
		}

		public static void GrowMemory(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarUInt32Instruction varUInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020.CastInstruction(value);
			uint numberOfPages = (uint)context.Pop<int>();
			int value2 = context.Module.Memories[(int)varUInt32Instruction.Immediate].Grow(numberOfPages);
			context.Push(value2);
		}

		public static void Int32Const(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarInt32Instruction varInt32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020.CastInstruction(value);
			context.Push(varInt32Instruction.Immediate);
		}

		public static void Int64Const(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			VarInt64Instruction varInt64Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A.CastInstruction(value);
			context.Push(varInt64Instruction.Immediate);
		}

		public static void Float32Const(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			Float32Instruction float32Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020.CastInstruction(value);
			context.Push(float32Instruction.Immediate);
		}

		public static void Float64Const(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			Float64Instruction float64Instruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.CastInstruction(value);
			context.Push(float64Instruction.Immediate);
		}

		public static void Int32Add(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 + num);
		}

		public static void Int32Sub(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 - num);
		}

		public static void Int32Mul(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 * num);
		}

		public static void Int32DivS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 / num);
		}

		public static void Int32DivU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint num = (uint)context.Pop<int>();
			uint num2 = (uint)context.Pop<int>();
			context.Push((int)(num2 / num));
		}

		public static void Int32RemS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int _0020_000A = context.Pop<int>();
			int _0020 = context.Pop<int>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020(_0020, _0020_000A));
		}

		public static void Int32RemU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint num = (uint)context.Pop<int>();
			uint num2 = (uint)context.Pop<int>();
			context.Push((int)(num2 % num));
		}

		public static void Int32And(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 & num);
		}

		public static void Int32Or(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 | num);
		}

		public static void Int32Xor(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 ^ num);
		}

		public static void Int32ShrS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 >> num);
		}

		public static void Int32ShrU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			uint num2 = (uint)context.Pop<int>();
			context.Push((int)(num2 >> num));
		}

		public static void Int32Shl(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push(num2 << num);
		}

		public static void Int32Rotl(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int _0020_000A = context.Pop<int>();
			int _0020 = context.Pop<int>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020(_0020, _0020_000A));
		}

		public static void Int32Rotr(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int _0020_000A = context.Pop<int>();
			int _0020 = context.Pop<int>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A(_0020, _0020_000A));
		}

		public static void Int32Clz(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020(context.Pop<int>()));
		}

		public static void Int32Ctz(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A(context.Pop<int>()));
		}

		public static void Int32Popcnt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020(context.Pop<int>()));
		}

		public static void Int32Eq(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push((num2 == num) ? 1 : 0);
		}

		public static void Int32Ne(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push((num2 != num) ? 1 : 0);
		}

		public static void Int32LtS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push((num2 < num) ? 1 : 0);
		}

		public static void Int32LtU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint num = (uint)context.Pop<int>();
			uint num2 = (uint)context.Pop<int>();
			context.Push((num2 < num) ? 1 : 0);
		}

		public static void Int32LeS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push((num2 <= num) ? 1 : 0);
		}

		public static void Int32LeU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint num = (uint)context.Pop<int>();
			uint num2 = (uint)context.Pop<int>();
			context.Push((num2 <= num) ? 1 : 0);
		}

		public static void Int32GtS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push((num2 > num) ? 1 : 0);
		}

		public static void Int32GtU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint num = (uint)context.Pop<int>();
			uint num2 = (uint)context.Pop<int>();
			context.Push((num2 > num) ? 1 : 0);
		}

		public static void Int32GeS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = context.Pop<int>();
			int num2 = context.Pop<int>();
			context.Push((num2 >= num) ? 1 : 0);
		}

		public static void Int32GeU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			uint num = (uint)context.Pop<int>();
			uint num2 = (uint)context.Pop<int>();
			context.Push((num2 >= num) ? 1 : 0);
		}

		public static void Int32Eqz(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((context.Pop<int>() == 0) ? 1 : 0);
		}

		public static void Int32TruncSFloat32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020(context.Pop<float>()));
		}

		public static void Int32TruncUFloat32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((int)_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A(context.Pop<float>()));
		}

		public static void Int32TruncSFloat64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020(context.Pop<double>()));
		}

		public static void Int32TruncUFloat64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((int)_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A(context.Pop<double>()));
		}

		public static void Int32WrapInt64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((int)context.Pop<long>());
		}

		public static void Int32ReinterpretFloat32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A(context.Pop<float>()));
		}

		public static void Int64Add(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 + num);
		}

		public static void Int64Sub(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 - num);
		}

		public static void Int64Mul(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 * num);
		}

		public static void Int64DivS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 / num);
		}

		public static void Int64DivU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			ulong num = (ulong)context.Pop<long>();
			ulong num2 = (ulong)context.Pop<long>();
			context.Push((long)(num2 / num));
		}

		public static void Int64RemS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long _0020_000A = context.Pop<long>();
			long _0020 = context.Pop<long>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020(_0020, _0020_000A));
		}

		public static void Int64RemU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			ulong num = (ulong)context.Pop<long>();
			ulong num2 = (ulong)context.Pop<long>();
			context.Push((long)(num2 % num));
		}

		public static void Int64And(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 & num);
		}

		public static void Int64Or(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 | num);
		}

		public static void Int64Xor(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 ^ num);
		}

		public static void Int64ShrS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = (int)context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 >> num);
		}

		public static void Int64ShrU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = (int)context.Pop<long>();
			ulong num2 = (ulong)context.Pop<long>();
			context.Push((long)(num2 >> num));
		}

		public static void Int64Shl(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			int num = (int)context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push(num2 << num);
		}

		public static void Int64Rotl(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long _0020_000A = context.Pop<long>();
			long _0020 = context.Pop<long>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020(_0020, _0020_000A));
		}

		public static void Int64Rotr(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long _0020_000A = context.Pop<long>();
			long _0020 = context.Pop<long>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A(_0020, _0020_000A));
		}

		public static void Int64Clz(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((long)_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020(context.Pop<long>()));
		}

		public static void Int64Ctz(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((long)_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A(context.Pop<long>()));
		}

		public static void Int64Popcnt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((long)_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020(context.Pop<long>()));
		}

		public static void Int64Eq(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push((num2 == num) ? 1 : 0);
		}

		public static void Int64Ne(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push((num2 != num) ? 1 : 0);
		}

		public static void Int64LtS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push((num2 < num) ? 1 : 0);
		}

		public static void Int64LtU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			ulong num = (ulong)context.Pop<long>();
			ulong num2 = (ulong)context.Pop<long>();
			context.Push((num2 < num) ? 1 : 0);
		}

		public static void Int64LeS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push((num2 <= num) ? 1 : 0);
		}

		public static void Int64LeU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			ulong num = (ulong)context.Pop<long>();
			ulong num2 = (ulong)context.Pop<long>();
			context.Push((num2 <= num) ? 1 : 0);
		}

		public static void Int64GtS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push((num2 > num) ? 1 : 0);
		}

		public static void Int64GtU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			ulong num = (ulong)context.Pop<long>();
			ulong num2 = (ulong)context.Pop<long>();
			context.Push((num2 > num) ? 1 : 0);
		}

		public static void Int64GeS(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			long num = context.Pop<long>();
			long num2 = context.Pop<long>();
			context.Push((num2 >= num) ? 1 : 0);
		}

		public static void Int64GeU(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			ulong num = (ulong)context.Pop<long>();
			ulong num2 = (ulong)context.Pop<long>();
			context.Push((num2 >= num) ? 1 : 0);
		}

		public static void Int64Eqz(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((context.Pop<long>() == 0L) ? 1 : 0);
		}

		public static void Int64TruncSFloat32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020(context.Pop<float>()));
		}

		public static void Int64TruncUFloat32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((long)_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A(context.Pop<float>()));
		}

		public static void Int64TruncSFloat64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020(context.Pop<double>()));
		}

		public static void Int64TruncUFloat64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((long)_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A(context.Pop<double>()));
		}

		public static void Int64ReinterpretFloat64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A(context.Pop<double>()));
		}

		public static void Int64ExtendSInt32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((long)context.Pop<int>());
		}

		public static void Int64ExtendUInt32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((long)(uint)context.Pop<int>());
		}

		public static void Float32Abs(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(Math.Abs(context.Pop<float>()));
		}

		public static void Float32Add(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push(num2 + num);
		}

		public static void Float32Ceil(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)Math.Ceiling(context.Pop<float>()));
		}

		public static void Float32Copysign(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float _0020_000A = context.Pop<float>();
			float _0020 = context.Pop<float>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020(_0020, _0020_000A));
		}

		public static void Float32Div(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push(num2 / num);
		}

		public static void Float32Eq(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push((num2 == num) ? 1 : 0);
		}

		public static void Float32Floor(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)Math.Floor(context.Pop<float>()));
		}

		public static void Float32Ge(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push((num2 >= num) ? 1 : 0);
		}

		public static void Float32Gt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push((num2 > num) ? 1 : 0);
		}

		public static void Float32Le(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push((num2 <= num) ? 1 : 0);
		}

		public static void Float32Lt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push((num2 < num) ? 1 : 0);
		}

		public static void Float32Max(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float val = context.Pop<float>();
			float val2 = context.Pop<float>();
			context.Push(Math.Max(val2, val));
		}

		public static void Float32Min(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float val = context.Pop<float>();
			float val2 = context.Pop<float>();
			context.Push(Math.Min(val2, val));
		}

		public static void Float32Mul(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push(num2 * num);
		}

		public static void Float32Ne(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push((num2 != num) ? 1 : 0);
		}

		public static void Float32Nearest(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)Math.Round(context.Pop<float>(), MidpointRounding.ToEven));
		}

		public static void Float32Neg(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(0f - context.Pop<float>());
		}

		public static void Float32Sub(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			float num = context.Pop<float>();
			float num2 = context.Pop<float>();
			context.Push(num2 - num);
		}

		public static void Float32Sqrt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)Math.Sqrt(context.Pop<float>()));
		}

		public static void Float32Trunc(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)Math.Truncate(context.Pop<float>()));
		}

		public static void Float32ConvertSInt32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)context.Pop<int>());
		}

		public static void Float32ConvertUInt32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)(double)(uint)context.Pop<int>());
		}

		public static void Float32ConvertSInt64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)context.Pop<long>());
		}

		public static void Float32ConvertUInt64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)(double)(ulong)context.Pop<long>());
		}

		public static void Float32DemoteFloat64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((float)context.Pop<double>());
		}

		public static void Float32ReinterpretInt32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020(context.Pop<int>()));
		}

		public static void Float64Abs(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(Math.Abs(context.Pop<double>()));
		}

		public static void Float64Add(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push(num2 + num);
		}

		public static void Float64Ceil(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(Math.Ceiling(context.Pop<double>()));
		}

		public static void Float64Copysign(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double _0020_000A = context.Pop<double>();
			double _0020 = context.Pop<double>();
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020(_0020, _0020_000A));
		}

		public static void Float64Div(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push(num2 / num);
		}

		public static void Float64Eq(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push((num2 == num) ? 1 : 0);
		}

		public static void Float64Floor(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(Math.Floor(context.Pop<double>()));
		}

		public static void Float64Ge(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push((num2 >= num) ? 1 : 0);
		}

		public static void Float64Gt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push((num2 > num) ? 1 : 0);
		}

		public static void Float64Le(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push((num2 <= num) ? 1 : 0);
		}

		public static void Float64Lt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push((num2 < num) ? 1 : 0);
		}

		public static void Float64Max(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double val = context.Pop<double>();
			double val2 = context.Pop<double>();
			context.Push(Math.Max(val2, val));
		}

		public static void Float64Min(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double val = context.Pop<double>();
			double val2 = context.Pop<double>();
			context.Push(Math.Min(val2, val));
		}

		public static void Float64Mul(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push(num2 * num);
		}

		public static void Float64Ne(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push((num2 != num) ? 1 : 0);
		}

		public static void Float64Nearest(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(Math.Round(context.Pop<double>(), MidpointRounding.ToEven));
		}

		public static void Float64Neg(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(0.0 - context.Pop<double>());
		}

		public static void Float64Sub(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			double num = context.Pop<double>();
			double num2 = context.Pop<double>();
			context.Push(num2 - num);
		}

		public static void Float64Sqrt(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(Math.Sqrt(context.Pop<double>()));
		}

		public static void Float64Trunc(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(Math.Truncate(context.Pop<double>()));
		}

		public static void Float64ConvertSInt32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((double)context.Pop<int>());
		}

		public static void Float64ConvertUInt32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((double)(uint)context.Pop<int>());
		}

		public static void Float64ConvertSInt64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((double)context.Pop<long>());
		}

		public static void Float64ConvertUInt64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((double)(ulong)context.Pop<long>());
		}

		public static void Float64PromoteFloat32(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push((double)context.Pop<float>());
		}

		public static void Float64ReinterpretInt64(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			context.Push(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020(context.Pop<long>()));
		}
	}
}
