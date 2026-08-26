using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

public class ILAstBuilder
{
	private struct StackSlot
	{
		public readonly ByteCode[] Definitions;

		public readonly ILVariable LoadFrom;

		public StackSlot(ByteCode[] definitions, ILVariable loadFrom)
		{
			Definitions = definitions;
			LoadFrom = loadFrom;
		}

		public static StackSlot[] ModifyStack(StackSlot[] stack, int popCount, int pushCount, ByteCode pushDefinition)
		{
			StackSlot[] array = new StackSlot[stack.Length - popCount + pushCount];
			Array.Copy(stack, array, stack.Length - popCount);
			for (int i = stack.Length - popCount; i < array.Length; i++)
			{
				array[i] = new StackSlot(new ByteCode[1] { pushDefinition }, null);
			}
			return array;
		}
	}

	private struct VariableSlot
	{
		public readonly ByteCode[] Definitions;

		public readonly bool UnknownDefinition;

		private static readonly VariableSlot UnknownInstance = new VariableSlot(Array.Empty<ByteCode>(), unknownDefinition: true);

		public VariableSlot(ByteCode[] definitions, bool unknownDefinition)
		{
			Definitions = definitions;
			UnknownDefinition = unknownDefinition;
		}

		public static VariableSlot[] CloneVariableState(VariableSlot[] state)
		{
			if (state.Length == 0)
			{
				return state;
			}
			VariableSlot[] array = new VariableSlot[state.Length];
			Array.Copy(state, array, state.Length);
			return array;
		}

		public static VariableSlot[] MakeUknownState(int varCount)
		{
			if (varCount == 0)
			{
				return Array.Empty<VariableSlot>();
			}
			VariableSlot[] array = new VariableSlot[varCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = UnknownInstance;
			}
			return array;
		}
	}

	private sealed class ByteCode
	{
		public ILLabel Label;

		public uint Offset;

		public uint EndOffset;

		public ILCode Code;

		public object Operand;

		public int PopCount;

		public int PushCount;

		public ByteCode Next;

		public Instruction[] Prefixes;

		public StackSlot[] StackBefore;

		public VariableSlot[] VariablesBefore;

		public List<ILVariable> StoreTo;

		public string Name => "IL_" + Offset.ToString("X2");

		public bool IsVariableDefinition
		{
			get
			{
				if (Code != ILCode.Stloc)
				{
					if (Code == ILCode.Ldloca && Next != null)
					{
						return Next.Code == ILCode.Initobj;
					}
					return false;
				}
				return true;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Name);
			stringBuilder.Append(':');
			if (Label != null)
			{
				stringBuilder.Append('*');
			}
			stringBuilder.Append(' ');
			if (Prefixes != null)
			{
				Instruction[] prefixes = Prefixes;
				foreach (Instruction instruction in prefixes)
				{
					stringBuilder.Append(instruction.OpCode.Name);
					stringBuilder.Append(' ');
				}
			}
			stringBuilder.Append(Code.GetName());
			if (Operand != null)
			{
				stringBuilder.Append(' ');
				if (Operand is Instruction)
				{
					stringBuilder.Append("IL_" + ((Instruction)Operand).Offset.ToString("X2"));
				}
				else if (Operand is IList<Instruction>)
				{
					foreach (Instruction item in (IList<Instruction>)Operand)
					{
						if (item != null)
						{
							stringBuilder.Append("IL_" + item.Offset.ToString("X2"));
							stringBuilder.Append(" ");
						}
					}
				}
				else if (Operand is ILLabel)
				{
					stringBuilder.Append(((ILLabel)Operand).Name);
				}
				else if (Operand is ILLabel[])
				{
					ILLabel[] array = (ILLabel[])Operand;
					foreach (ILLabel iLLabel in array)
					{
						stringBuilder.Append(iLLabel.Name);
						stringBuilder.Append(" ");
					}
				}
				else
				{
					stringBuilder.Append(Operand.ToString());
				}
			}
			if (StackBefore != null)
			{
				stringBuilder.Append(" StackBefore={");
				bool flag = true;
				StackSlot[] stackBefore = StackBefore;
				for (int k = 0; k < stackBefore.Length; k++)
				{
					StackSlot stackSlot = stackBefore[k];
					if (!flag)
					{
						stringBuilder.Append(",");
					}
					bool flag2 = true;
					ByteCode[] definitions = stackSlot.Definitions;
					foreach (ByteCode byteCode in definitions)
					{
						if (!flag2)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.AppendFormat("IL_{0:X2}", byteCode.Offset);
						flag2 = false;
					}
					flag = false;
				}
				stringBuilder.Append("}");
			}
			if (StoreTo != null && StoreTo.Count > 0)
			{
				stringBuilder.Append(" StoreTo={");
				bool flag3 = true;
				foreach (ILVariable item2 in StoreTo)
				{
					if (!flag3)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(item2.Name);
					flag3 = false;
				}
				stringBuilder.Append("}");
			}
			if (VariablesBefore != null)
			{
				stringBuilder.Append(" VarsBefore={");
				bool flag4 = true;
				VariableSlot[] variablesBefore = VariablesBefore;
				for (int m = 0; m < variablesBefore.Length; m++)
				{
					VariableSlot variableSlot = variablesBefore[m];
					if (!flag4)
					{
						stringBuilder.Append(",");
					}
					if (variableSlot.UnknownDefinition)
					{
						stringBuilder.Append("?");
					}
					else
					{
						bool flag5 = true;
						ByteCode[] definitions2 = variableSlot.Definitions;
						foreach (ByteCode byteCode2 in definitions2)
						{
							if (!flag5)
							{
								stringBuilder.Append("|");
							}
							stringBuilder.AppendFormat("IL_{0:X2}", byteCode2.Offset);
							flag5 = false;
						}
					}
					flag4 = false;
				}
				stringBuilder.Append("}");
			}
			return stringBuilder.ToString();
		}
	}

	private sealed class VariableInfo
	{
		public ILVariable Variable;

		public List<ByteCode> Defs;

		public List<ByteCode> Uses;
	}

	private MethodDef methodDef;

	private bool optimize;

	private readonly Dictionary<ExceptionHandler, ByteCode> ldexceptions = new Dictionary<ExceptionHandler, ByteCode>();

	private readonly Dictionary<ExceptionHandler, ByteCode> ldfilters = new Dictionary<ExceptionHandler, ByteCode>();

	public List<ILVariable> Parameters = new List<ILVariable>();

	private DecompilerContext context;

	private readonly Dictionary<Instruction, ByteCode> instrToByteCode = new Dictionary<Instruction, ByteCode>();

	private readonly List<ByteCode> StackAnalysis_body = new List<ByteCode>();

	private readonly List<ILLabel> StackAnalysis_List_ILLabel = new List<ILLabel>();

	private readonly Dictionary<ILVariable, bool> StackAnalysis_Dict_ILVariable_Boolean = new Dictionary<ILVariable, bool>();

	private readonly HashSet<ByteCode> StackAnalysis_HashSet_ByteCode = new HashSet<ByteCode>();

	private readonly List<Instruction> StackAnalysis_cachedPrefixes = new List<Instruction>(1);

	private readonly Dictionary<ILVariable, StackSlot?> StackAnalysis_ILVariable_StackSlot_dict = new Dictionary<ILVariable, StackSlot?>();

	private readonly HashSet<ILVariable> StackAnalysis_ILVariables_hash = new HashSet<ILVariable>();

	private static readonly Dictionary<Code, ILCode> ilCodeTranslation = (from opCode in OpCodes.OneByteOpCodes.Concat(OpCodes.TwoByteOpCodes)
		group opCode by opCode.Code into @group
		select @group.First() into opCode
		select new
		{
			Code = opCode.Code,
			ILCode = ((opCode.OpCodeType != OpCodeType.Nternal) ? ((ILCode)Enum.Parse(typeof(ILCode), opCode.Code.ToString())) : ILCode.Nop)
		}).ToDictionary(translation => translation.Code, translation => translation.ILCode);

	private readonly ByteCode nullByteCodeDummy = new ByteCode();

	public void Reset()
	{
		methodDef = null;
		optimize = false;
		ldexceptions.Clear();
		ldfilters.Clear();
		Parameters.Clear();
		context = null;
		instrToByteCode.Clear();
		StackAnalysis_List_ILLabel.Clear();
		StackAnalysis_Dict_ILVariable_Boolean.Clear();
		StackAnalysis_HashSet_ByteCode.Clear();
		StackAnalysis_cachedPrefixes.Clear();
		StackAnalysis_ILVariable_StackSlot_dict.Clear();
		StackAnalysis_ILVariables_hash.Clear();
		nullByteCodeDummy.Next = null;
	}

	public List<ILNode> Build(MethodDef methodDef, bool optimize, DecompilerContext context)
	{
		this.methodDef = methodDef;
		this.optimize = optimize;
		this.context = context;
		if (methodDef.Body.Instructions.Count == 0)
		{
			return new List<ILNode>();
		}
		List<ByteCode> body = StackAnalysis(methodDef);
		return ConvertToAst(body, new HashSet<ExceptionHandler>(methodDef.Body.ExceptionHandlers));
	}

	private List<ByteCode> StackAnalysis(MethodDef methodDef)
	{
		instrToByteCode.Clear();
		StackAnalysis_body.Clear();
		List<Instruction> list = null;
		IList<Instruction> instructions = methodDef.Body.Instructions;
		int count = instructions.Count;
		Instruction instruction = ((0 < count) ? instructions[0] : null);
		ByteCode byteCode = nullByteCodeDummy;
		for (int i = 0; i < count; i++)
		{
			Instruction instruction2 = ((i + 1 < count) ? instructions[i + 1] : null);
			if (instruction.OpCode.OpCodeType == OpCodeType.Prefix)
			{
				if (list == null)
				{
					list = StackAnalysis_cachedPrefixes;
				}
				list.Add(instruction);
				instruction = instruction2;
				continue;
			}
			ILCode code = ilCodeTranslation[instruction.OpCode.Code];
			object operand = instruction.Operand;
			ILCodeUtil.ExpandMacro(ref code, ref operand, methodDef);
			ByteCode byteCode2 = new ByteCode
			{
				Offset = instruction.Offset,
				EndOffset = (uint)(((int?)instruction2?.Offset) ?? methodDef.Body.GetCodeSize()),
				Code = code,
				Operand = operand,
				PopCount = instruction.GetPopDelta(methodDef),
				PushCount = instruction.GetPushDelta(methodDef)
			};
			if (list != null)
			{
				instrToByteCode[list[0]] = byteCode2;
				byteCode2.Offset = list[0].Offset;
				byteCode2.Prefixes = list.ToArray();
				list = null;
				StackAnalysis_cachedPrefixes.Clear();
			}
			else
			{
				instrToByteCode[instruction] = byteCode2;
			}
			StackAnalysis_body.Add(byteCode2);
			byteCode.Next = byteCode2;
			byteCode = byteCode2;
			instruction = instruction2;
		}
		Stack<ByteCode> stack = new Stack<ByteCode>();
		int count2 = methodDef.Body.Variables.Count;
		HashSet<ByteCode> hashSet = new HashSet<ByteCode>(methodDef.Body.ExceptionHandlers.Select((ExceptionHandler eh) => (eh.HandlerStart != null) ? instrToByteCode[eh.HandlerStart] : null));
		hashSet.Remove(null);
		if (StackAnalysis_body.Count == 1 && StackAnalysis_body[0].Code == ILCode.Ret)
		{
			StackAnalysis_body[0].PopCount = 0;
		}
		if (methodDef.Body.HasExceptionHandlers)
		{
			foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
			{
				if (exceptionHandler.HandlerStart != null)
				{
					ByteCode byteCode3 = instrToByteCode[exceptionHandler.HandlerStart];
					byteCode3.StackBefore = Array.Empty<StackSlot>();
					byteCode3.VariablesBefore = VariableSlot.MakeUknownState(count2);
					if (exceptionHandler.HandlerType == ExceptionHandlerType.Catch || exceptionHandler.HandlerType == ExceptionHandlerType.Filter)
					{
						ByteCode byteCode4 = new ByteCode
						{
							Code = ILCode.Ldexception,
							Operand = exceptionHandler.CatchType,
							PopCount = 0,
							PushCount = 1
						};
						ldexceptions[exceptionHandler] = byteCode4;
						byteCode3.StackBefore = new StackSlot[1]
						{
							new StackSlot(new ByteCode[1] { byteCode4 }, null)
						};
					}
					stack.Push(byteCode3);
					if (exceptionHandler.HandlerType == ExceptionHandlerType.Filter && exceptionHandler.FilterStart != null)
					{
						ByteCode byteCode5 = instrToByteCode[exceptionHandler.FilterStart];
						ByteCode byteCode6 = new ByteCode
						{
							Code = ILCode.Ldexception,
							Operand = exceptionHandler.CatchType,
							PopCount = 0,
							PushCount = 1
						};
						ldfilters[exceptionHandler] = byteCode6;
						byteCode5.StackBefore = new StackSlot[1]
						{
							new StackSlot(new ByteCode[1] { byteCode6 }, null)
						};
						byteCode5.VariablesBefore = VariableSlot.MakeUknownState(count2);
						stack.Push(byteCode5);
					}
				}
			}
		}
		StackAnalysis_body[0].StackBefore = Array.Empty<StackSlot>();
		StackAnalysis_body[0].VariablesBefore = VariableSlot.MakeUknownState(count2);
		stack.Push(StackAnalysis_body[0]);
		while (stack.Count > 0)
		{
			context.CancellationToken.ThrowIfCancellationRequested();
			ByteCode byteCode7 = stack.Pop();
			StackSlot[] array = StackSlot.ModifyStack(byteCode7.StackBefore, (byteCode7.PopCount >= 0) ? byteCode7.PopCount : byteCode7.StackBefore.Length, byteCode7.PushCount, byteCode7);
			VariableSlot[] array2 = VariableSlot.CloneVariableState(byteCode7.VariablesBefore);
			if (byteCode7.IsVariableDefinition && byteCode7.Operand is Local)
			{
				array2[((Local)byteCode7.Operand).Index] = new VariableSlot(new ByteCode[1] { byteCode7 }, unknownDefinition: false);
			}
			else if (byteCode7.Code == ILCode.Leave)
			{
				array2 = VariableSlot.MakeUknownState(count2);
			}
			List<ByteCode> list2 = new List<ByteCode>();
			if (!byteCode7.Code.IsUnconditionalControlFlow() && !hashSet.Contains(byteCode7.Next))
			{
				list2.Add(byteCode7.Next);
			}
			if (byteCode7.Operand is IList<Instruction>)
			{
				foreach (Instruction item in (IList<Instruction>)byteCode7.Operand)
				{
					ByteCode byteCode8 = instrToByteCode[item];
					list2.Add(byteCode8);
					if (byteCode8.Label == null)
					{
						byteCode8.Label = new ILLabel
						{
							Name = byteCode8.Name,
							Offset = byteCode8.Offset
						};
					}
				}
			}
			else if (byteCode7.Operand is Instruction)
			{
				ByteCode byteCode9 = instrToByteCode[(Instruction)byteCode7.Operand];
				list2.Add(byteCode9);
				if (byteCode9.Label == null)
				{
					byteCode9.Label = new ILLabel
					{
						Name = byteCode9.Name,
						Offset = byteCode9.Offset
					};
				}
			}
			foreach (ByteCode item2 in list2)
			{
				if (item2 == null)
				{
					continue;
				}
				if (item2.StackBefore == null && item2.VariablesBefore == null)
				{
					if (list2.Count == 1)
					{
						item2.StackBefore = array;
						item2.VariablesBefore = array2;
					}
					else
					{
						item2.StackBefore = StackSlot.ModifyStack(array, 0, 0, null);
						item2.VariablesBefore = VariableSlot.CloneVariableState(array2);
					}
					stack.Push(item2);
					continue;
				}
				if (item2.StackBefore.Length != array.Length)
				{
					throw new Exception("Inconsistent stack size at " + byteCode7.Name);
				}
				bool flag = false;
				for (int num = 0; num < array.Length; num++)
				{
					ByteCode[] definitions = item2.StackBefore[num].Definitions;
					ByteCode[] array3 = Union(definitions, array[num].Definitions);
					if (array3.Length > definitions.Length)
					{
						item2.StackBefore[num] = new StackSlot(array3, null);
						flag = true;
					}
				}
				for (int num2 = 0; num2 < array2.Length; num2++)
				{
					VariableSlot variableSlot = item2.VariablesBefore[num2];
					if (variableSlot.UnknownDefinition)
					{
						continue;
					}
					VariableSlot variableSlot2 = array2[num2];
					if (variableSlot2.UnknownDefinition)
					{
						item2.VariablesBefore[num2] = variableSlot2;
						flag = true;
						continue;
					}
					ByteCode[] definitions2 = variableSlot.Definitions;
					ByteCode[] array4 = Union(definitions2, variableSlot2.Definitions);
					if (array4.Length > definitions2.Length)
					{
						item2.VariablesBefore[num2] = new VariableSlot(array4, unknownDefinition: false);
						flag = true;
					}
				}
				if (flag)
				{
					stack.Push(item2);
				}
			}
		}
		StackAnalysis_body.RemoveAll((ByteCode b) => b.StackBefore == null);
		foreach (ByteCode item3 in StackAnalysis_body)
		{
			int num3 = 0;
			int num4 = ((item3.PopCount >= 0) ? item3.PopCount : item3.StackBefore.Length);
			for (int num5 = item3.StackBefore.Length - num4; num5 < item3.StackBefore.Length; num5++)
			{
				ILVariable iLVariable = new ILVariable("arg_" + item3.Offset.ToString("X2") + "_" + num3)
				{
					GeneratedByDecompiler = true
				};
				item3.StackBefore[num5] = new StackSlot(item3.StackBefore[num5].Definitions, iLVariable);
				ByteCode[] definitions3 = item3.StackBefore[num5].Definitions;
				foreach (ByteCode byteCode10 in definitions3)
				{
					if (byteCode10.StoreTo == null)
					{
						byteCode10.StoreTo = new List<ILVariable>(1);
					}
					byteCode10.StoreTo.Add(iLVariable);
				}
				num3++;
			}
		}
		StackAnalysis_ILVariable_StackSlot_dict.Clear();
		StackAnalysis_ILVariables_hash.Clear();
		bool flag2 = false;
		foreach (ByteCode item4 in StackAnalysis_body)
		{
			if (item4.StoreTo == null || item4.StoreTo.Count <= 1)
			{
				continue;
			}
			List<ILVariable> storeTo = item4.StoreTo;
			if (!flag2)
			{
				flag2 = true;
				foreach (ByteCode item5 in StackAnalysis_body)
				{
					List<ILVariable> storeTo2 = item4.StoreTo;
					if (storeTo2 == null)
					{
						continue;
					}
					foreach (ILVariable item6 in storeTo2)
					{
						StackAnalysis_ILVariables_hash.Add(item6);
					}
				}
				foreach (ByteCode item7 in StackAnalysis_body)
				{
					StackSlot[] stackBefore = item7.StackBefore;
					for (int num7 = 0; num7 < stackBefore.Length; num7++)
					{
						StackSlot value = stackBefore[num7];
						ILVariable loadFrom = value.LoadFrom;
						if (loadFrom != null && StackAnalysis_ILVariables_hash.Contains(loadFrom))
						{
							if (StackAnalysis_ILVariable_StackSlot_dict.ContainsKey(loadFrom))
							{
								StackAnalysis_ILVariable_StackSlot_dict[loadFrom] = null;
							}
							else
							{
								StackAnalysis_ILVariable_StackSlot_dict[loadFrom] = value;
							}
						}
					}
				}
			}
			StackAnalysis_Dict_ILVariable_Boolean.Clear();
			bool flag3 = true;
			for (int num8 = 0; num8 < storeTo.Count; num8++)
			{
				ILVariable key = storeTo[num8];
				StackAnalysis_Dict_ILVariable_Boolean[key] = true;
				if (!StackAnalysis_ILVariable_StackSlot_dict.TryGetValue(key, out var value2) || !value2.HasValue || value2.Value.Definitions.Length != 1 || value2.Value.Definitions[0] != item4)
				{
					flag3 = false;
					break;
				}
			}
			if (!flag3)
			{
				continue;
			}
			ILVariable iLVariable2 = new ILVariable("expr_" + item4.Offset.ToString("X2"))
			{
				GeneratedByDecompiler = true
			};
			storeTo.Clear();
			storeTo.Add(iLVariable2);
			foreach (ByteCode item8 in StackAnalysis_body)
			{
				for (int num9 = 0; num9 < item8.StackBefore.Length; num9++)
				{
					ILVariable loadFrom2 = item8.StackBefore[num9].LoadFrom;
					if (loadFrom2 != null && StackAnalysis_Dict_ILVariable_Boolean.ContainsKey(loadFrom2))
					{
						item8.StackBefore[num9] = new StackSlot(item8.StackBefore[num9].Definitions, iLVariable2);
					}
				}
			}
		}
		ConvertLocalVariables(StackAnalysis_body);
		foreach (ByteCode item9 in StackAnalysis_body)
		{
			if (item9.Operand is IList<Instruction>)
			{
				StackAnalysis_List_ILLabel.Clear();
				IList<Instruction> list3 = (IList<Instruction>)item9.Operand;
				for (int num10 = 0; num10 < list3.Count; num10++)
				{
					StackAnalysis_List_ILLabel.Add(instrToByteCode[list3[num10]].Label);
				}
				item9.Operand = StackAnalysis_List_ILLabel.ToArray();
			}
			else if (item9.Operand is Instruction)
			{
				item9.Operand = instrToByteCode[(Instruction)item9.Operand].Label;
			}
		}
		ConvertParameters(StackAnalysis_body);
		return StackAnalysis_body;
	}

	private ByteCode[] Union(ByteCode[] a, ByteCode[] b)
	{
		if (a == b)
		{
			return a;
		}
		if (a.Length == 0)
		{
			return b;
		}
		if (b.Length == 0)
		{
			return a;
		}
		if (a.Length == 1)
		{
			if (b.Length == 1)
			{
				if (a[0] != b[0])
				{
					return new ByteCode[2]
					{
						a[0],
						b[0]
					};
				}
				return a;
			}
		}
		else if (a.Length == 2 && b.Length == 2 && ((a[0] == b[0] && a[1] == b[1]) || (a[0] == b[1] && a[1] == b[0])))
		{
			return a;
		}
		StackAnalysis_HashSet_ByteCode.Clear();
		foreach (ByteCode item in a)
		{
			StackAnalysis_HashSet_ByteCode.Add(item);
		}
		foreach (ByteCode item2 in b)
		{
			StackAnalysis_HashSet_ByteCode.Add(item2);
		}
		if (a.Length == b.Length && a.Length == StackAnalysis_HashSet_ByteCode.Count)
		{
			return a;
		}
		ByteCode[] array = new ByteCode[StackAnalysis_HashSet_ByteCode.Count];
		int num = 0;
		foreach (ByteCode item3 in StackAnalysis_HashSet_ByteCode)
		{
			array[num++] = item3;
		}
		return array;
	}

	private static bool IsDeterministicLdloca(ByteCode b)
	{
		object operand = b.Operand;
		b = b.Next;
		if (b.Code == ILCode.Initobj)
		{
			return true;
		}
		int num = 1;
		while (true)
		{
			if (b.PopCount < 0)
			{
				return false;
			}
			num -= b.PopCount;
			if (num == 0)
			{
				break;
			}
			if (num < 0)
			{
				return false;
			}
			switch (b.Code)
			{
			case ILCode.Jmp:
			case ILCode.Ret:
			case ILCode.Br_S:
			case ILCode.Brfalse_S:
			case ILCode.Brtrue_S:
			case ILCode.Beq_S:
			case ILCode.Bge_S:
			case ILCode.Bgt_S:
			case ILCode.Ble_S:
			case ILCode.Blt_S:
			case ILCode.Bne_Un_S:
			case ILCode.Bge_Un_S:
			case ILCode.Bgt_Un_S:
			case ILCode.Ble_Un_S:
			case ILCode.Blt_Un_S:
			case ILCode.Br:
			case ILCode.Brfalse:
			case ILCode.Brtrue:
			case ILCode.Beq:
			case ILCode.Bge:
			case ILCode.Bgt:
			case ILCode.Ble:
			case ILCode.Blt:
			case ILCode.Bne_Un:
			case ILCode.Bge_Un:
			case ILCode.Bgt_Un:
			case ILCode.Ble_Un:
			case ILCode.Blt_Un:
			case ILCode.Switch:
			case ILCode.Throw:
			case ILCode.Endfinally:
			case ILCode.Leave:
			case ILCode.Leave_S:
			case ILCode.Endfilter:
			case ILCode.Rethrow:
			case ILCode.LoopOrSwitchBreak:
			case ILCode.LoopContinue:
			case ILCode.YieldBreak:
				return false;
			case ILCode.Ldloc:
			case ILCode.Ldloca:
			case ILCode.Stloc:
				if (operand != null && b.Operand == operand)
				{
					return false;
				}
				break;
			}
			num += b.PushCount;
			b = b.Next;
			if (b == null)
			{
				return false;
			}
		}
		if (b.Code == ILCode.Ldfld || b.Code == ILCode.Stfld)
		{
			return true;
		}
		if ((b.Code == ILCode.Call || b.Code == ILCode.Callvirt) && b.Operand is IMethod && ((IMethod)b.Operand).MethodSig != null)
		{
			return ((IMethod)b.Operand).MethodSig.HasThis;
		}
		return false;
	}

	private void ConvertLocalVariables(List<ByteCode> body)
	{
		foreach (Local varDef in methodDef.Body.Variables)
		{
			List<ByteCode> list = new List<ByteCode>();
			List<ByteCode> list2 = new List<ByteCode>();
			foreach (ByteCode item in body)
			{
				if (item.Operand == varDef)
				{
					if (item.IsVariableDefinition)
					{
						list.Add(item);
					}
					else
					{
						list2.Add(item);
					}
				}
			}
			List<VariableInfo> list4;
			if (!optimize || varDef.Type is PinnedSig || list2.Any((ByteCode b) => b.VariablesBefore[varDef.Index].UnknownDefinition || (b.Code == ILCode.Ldloca && !IsDeterministicLdloca(b))))
			{
				List<VariableInfo> list3 = new List<VariableInfo>(1);
				list3.Add(new VariableInfo
				{
					Variable = new ILVariable(string.IsNullOrEmpty(varDef.Name) ? ("var_" + varDef.Index) : varDef.Name)
					{
						Type = ((varDef.Type is PinnedSig) ? ((PinnedSig)varDef.Type).Next : varDef.Type),
						OriginalVariable = varDef
					},
					Defs = list,
					Uses = list2
				});
				list4 = list3;
			}
			else
			{
				list4 = list.Select((ByteCode def) => new VariableInfo
				{
					Variable = new ILVariable((string.IsNullOrEmpty(varDef.Name) ? ("var_" + varDef.Index) : varDef.Name) + "_" + def.Offset.ToString("X2"))
					{
						Type = varDef.Type,
						OriginalVariable = varDef
					},
					Defs = new List<ByteCode> { def },
					Uses = new List<ByteCode>()
				}).ToList();
				foreach (ByteCode item2 in list2)
				{
					ByteCode[] useDefs = item2.VariablesBefore[varDef.Index].Definitions;
					if (useDefs.Length == 1)
					{
						VariableInfo variableInfo = list4.Single((VariableInfo v) => v.Defs.Contains(useDefs[0]));
						variableInfo.Uses.Add(item2);
						continue;
					}
					List<VariableInfo> list5 = list4.Where((VariableInfo v) => v.Defs.Intersect(useDefs).Any()).ToList();
					VariableInfo variableInfo2 = new VariableInfo
					{
						Variable = list5[0].Variable,
						Defs = list5.SelectMany((VariableInfo v) => v.Defs).ToList(),
						Uses = list5.SelectMany((VariableInfo v) => v.Uses).ToList()
					};
					variableInfo2.Uses.Add(item2);
					list4 = list4.Except(list5).ToList();
					list4.Add(variableInfo2);
				}
			}
			foreach (VariableInfo item3 in list4)
			{
				foreach (ByteCode def in item3.Defs)
				{
					def.Operand = item3.Variable;
				}
				foreach (ByteCode use in item3.Uses)
				{
					use.Operand = item3.Variable;
				}
			}
		}
	}

	private void ConvertParameters(List<ByteCode> body)
	{
		ILVariable iLVariable = null;
		if (methodDef.HasThis)
		{
			TypeDef declaringType = methodDef.DeclaringType;
			iLVariable = new ILVariable("this");
			iLVariable.Type = (DnlibExtensions.IsValueType(declaringType) ? new ByRefSig(declaringType.ToTypeSig()) : declaringType.ToTypeSig());
			iLVariable.OriginalParameter = methodDef.Parameters[0];
		}
		foreach (Parameter item in methodDef.Parameters.SkipNonNormal())
		{
			Parameters.Add(new ILVariable(string.IsNullOrEmpty(item.Name) ? ("A_" + item.Index) : item.Name)
			{
				Type = item.Type,
				OriginalParameter = item
			});
		}
		if (Parameters.Count > 0 && (methodDef.SemanticsAttributes & (MethodSemanticsAttributes.Setter | MethodSemanticsAttributes.AddOn | MethodSemanticsAttributes.RemoveOn)) != MethodSemanticsAttributes.None)
		{
			Parameters.Last().Name = "value";
		}
		foreach (ByteCode item2 in body)
		{
			switch (item2.Code)
			{
			case ILCode.Ldarg:
			{
				Parameter parameter = item2.Operand as Parameter;
				item2.Code = ILCode.Ldloc;
				item2.Operand = ((parameter == null) ? null : (parameter.IsHiddenThisParameter ? iLVariable : Parameters[parameter.MethodSigIndex]));
				break;
			}
			case ILCode.Starg:
			{
				Parameter parameter = item2.Operand as Parameter;
				item2.Code = ILCode.Stloc;
				item2.Operand = ((parameter == null) ? null : (parameter.IsHiddenThisParameter ? iLVariable : Parameters[parameter.MethodSigIndex]));
				break;
			}
			case ILCode.Ldarga:
			{
				Parameter parameter = item2.Operand as Parameter;
				item2.Code = ILCode.Ldloca;
				item2.Operand = ((parameter == null) ? null : (parameter.IsHiddenThisParameter ? iLVariable : Parameters[parameter.MethodSigIndex]));
				break;
			}
			}
		}
		if (iLVariable != null)
		{
			Parameters.Add(iLVariable);
		}
	}

	private List<ILNode> ConvertToAst(List<ByteCode> body, HashSet<ExceptionHandler> ehs)
	{
		List<ILNode> list = new List<ILNode>();
		uint codeSize = (uint)methodDef.Body.GetCodeSize();
		while (ehs.Any())
		{
			ILTryCatchBlock iLTryCatchBlock = new ILTryCatchBlock();
			uint tryStart = ehs.Min((ExceptionHandler exceptionHandler) => exceptionHandler.TryStart.GetOffset());
			uint tryEnd = ehs.Where((ExceptionHandler exceptionHandler) => exceptionHandler.TryStart.GetOffset() == tryStart).Max((ExceptionHandler exceptionHandler) => exceptionHandler.TryEnd?.Offset ?? codeSize);
			List<ExceptionHandler> list2 = ehs.Where((ExceptionHandler exceptionHandler) => exceptionHandler.TryStart.GetOffset() == tryStart && (exceptionHandler.TryEnd?.Offset ?? codeSize) == tryEnd).ToList();
			int num;
			for (num = 0; num < body.Count && body[num].Offset < tryStart; num++)
			{
			}
			list.AddRange(ConvertToAst(body.CutRange(0, num)));
			HashSet<ExceptionHandler> hashSet = new HashSet<ExceptionHandler>(ehs.Where((ExceptionHandler exceptionHandler) => (tryStart <= exceptionHandler.TryStart.GetOffset() && (exceptionHandler.TryEnd?.Offset ?? codeSize) < tryEnd) || (tryStart < exceptionHandler.TryStart.GetOffset() && (exceptionHandler.TryEnd?.Offset ?? codeSize) <= tryEnd)));
			ehs.ExceptWith(hashSet);
			int num2;
			for (num2 = 0; num2 < body.Count && body[num2].Offset < tryEnd; num2++)
			{
			}
			iLTryCatchBlock.TryBlock = new ILBlock(ConvertToAst(body.CutRange(0, num2), hashSet), CodeBracesRangeFlags.TryBraces);
			iLTryCatchBlock.CatchBlocks = new List<ILTryCatchBlock.CatchBlock>();
			foreach (ExceptionHandler eh in list2)
			{
				uint handlerEndOffset = eh.HandlerEnd?.Offset ?? codeSize;
				int num3;
				for (num3 = 0; num3 < body.Count && body[num3].Offset < eh.HandlerStart.GetOffset(); num3++)
				{
				}
				int num4;
				for (num4 = num3; num4 < body.Count && body[num4].Offset < handlerEndOffset; num4++)
				{
				}
				HashSet<ExceptionHandler> hashSet2 = new HashSet<ExceptionHandler>(ehs.Where((ExceptionHandler e) => (eh.HandlerStart.GetOffset() <= e.TryStart.GetOffset() && (e.TryEnd?.Offset ?? codeSize) < handlerEndOffset) || (eh.HandlerStart.GetOffset() < e.TryStart.GetOffset() && (e.TryEnd?.Offset ?? codeSize) <= handlerEndOffset)));
				ehs.ExceptWith(hashSet2);
				List<ILNode> body2 = ConvertToAst(body.CutRange(num3, num4 - num3), hashSet2);
				if (eh.HandlerType == ExceptionHandlerType.Catch)
				{
					ILTryCatchBlock.CatchBlock catchBlock = new ILTryCatchBlock.CatchBlock(context.CalculateILSpans, body2)
					{
						ExceptionType = eh.CatchType.ToTypeSig()
					};
					ByteCode ldexception = ldexceptions[eh];
					ConvertExceptionVariable(eh, catchBlock, ldexception);
					iLTryCatchBlock.CatchBlocks.Add(catchBlock);
				}
				else if (eh.HandlerType == ExceptionHandlerType.Finally)
				{
					iLTryCatchBlock.FinallyBlock = new ILBlock(body2, CodeBracesRangeFlags.FinallyBraces);
				}
				else if (eh.HandlerType == ExceptionHandlerType.Fault)
				{
					iLTryCatchBlock.FaultBlock = new ILBlock(body2, CodeBracesRangeFlags.FaultBraces);
				}
				else if (eh.HandlerType == ExceptionHandlerType.Filter)
				{
					ILTryCatchBlock.CatchBlock catchBlock2 = new ILTryCatchBlock.CatchBlock(context.CalculateILSpans, body2)
					{
						ExceptionType = eh.CatchType.ToTypeSig()
					};
					ByteCode ldexception2 = ldexceptions[eh];
					ConvertExceptionVariable(eh, catchBlock2, ldexception2);
					iLTryCatchBlock.CatchBlocks.Add(catchBlock2);
					for (num3 = 0; num3 < body.Count && body[num3].Offset < eh.FilterStart.GetOffset(); num3++)
					{
					}
					num4 = num3;
					uint ehHandlerStart;
					for (ehHandlerStart = eh.HandlerStart.GetOffset(); num4 < body.Count && body[num4].Offset < ehHandlerStart; num4++)
					{
					}
					hashSet2 = new HashSet<ExceptionHandler>(ehs.Where((ExceptionHandler e) => (eh.FilterStart.GetOffset() <= e.TryStart.GetOffset() && (e.TryEnd?.Offset ?? codeSize) < ehHandlerStart) || (eh.FilterStart.GetOffset() < e.TryStart.GetOffset() && (e.TryEnd?.Offset ?? codeSize) <= ehHandlerStart)));
					ehs.ExceptWith(hashSet2);
					List<ILNode> body3 = ConvertToAst(body.CutRange(num3, num4 - num3), hashSet2);
					ILTryCatchBlock.FilterILBlock filterILBlock = new ILTryCatchBlock.FilterILBlock(context.CalculateILSpans, body3)
					{
						ExceptionType = null
					};
					ByteCode ldexception3 = ldfilters[eh];
					ConvertExceptionVariable(eh, filterILBlock, ldexception3);
					catchBlock2.FilterBlock = filterILBlock;
				}
			}
			ehs.ExceptWith(list2);
			list.Add(iLTryCatchBlock);
		}
		list.AddRange(ConvertToAst(body));
		return list;
	}

	private void ConvertExceptionVariable(ExceptionHandler eh, ILTryCatchBlock.CatchBlockBase catchBlock, ByteCode ldexception)
	{
		List<ILVariable> storeTo = ldexception.StoreTo;
		if (storeTo == null || storeTo.Count == 0)
		{
			catchBlock.ExceptionVariable = null;
			return;
		}
		if (ldexception.StoreTo.Count == 1)
		{
			if (catchBlock.Body[0] is ILExpression { Code: ILCode.Pop } iLExpression && iLExpression.Arguments[0].Code == ILCode.Ldloc && iLExpression.Arguments[0].Operand == ldexception.StoreTo[0])
			{
				if (context.Settings.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject && eh.CatchType != null && !eh.CatchType.IsSystemObject())
				{
					catchBlock.ExceptionVariable = new ILVariable("ex_" + eh.HandlerStart.GetOffset().ToString("X2"))
					{
						GeneratedByDecompiler = true
					};
				}
				else
				{
					catchBlock.ExceptionVariable = null;
				}
				if (context.CalculateILSpans)
				{
					catchBlock.Body[0].AddSelfAndChildrenRecursiveILSpans(catchBlock.StlocILSpans);
				}
				catchBlock.Body.RemoveAt(0);
			}
			else
			{
				catchBlock.ExceptionVariable = ldexception.StoreTo[0];
			}
			return;
		}
		ILVariable operand = (catchBlock.ExceptionVariable = new ILVariable("ex_" + eh.HandlerStart.GetOffset().ToString("X2"))
		{
			GeneratedByDecompiler = true
		});
		foreach (ILVariable item in ldexception.StoreTo)
		{
			catchBlock.Body.Insert(0, new ILExpression(ILCode.Stloc, item, new ILExpression(ILCode.Ldloc, operand)));
		}
	}

	private List<ILNode> ConvertToAst(List<ByteCode> body)
	{
		List<ILNode> list = new List<ILNode>();
		int num = -1;
		foreach (ByteCode item in body)
		{
			if (item.StackBefore == null)
			{
				continue;
			}
			ILExpression iLExpression = new ILExpression(item.Code, item.Operand);
			if (context.CalculateILSpans)
			{
				if (item.Code == ILCode.Dup)
				{
					if (num < 0)
					{
						num = (int)item.Offset;
					}
				}
				else if (num < 0)
				{
					iLExpression.ILSpans.Add(new ILSpan(item.Offset, item.EndOffset - item.Offset));
				}
				else
				{
					iLExpression.ILSpans.Add(new ILSpan((uint)num, item.EndOffset - (uint)num));
					num = -1;
				}
			}
			if (item.Prefixes != null && item.Prefixes.Length != 0)
			{
				ILExpressionPrefix[] array = new ILExpressionPrefix[item.Prefixes.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new ILExpressionPrefix(ilCodeTranslation[item.Prefixes[i].OpCode.Code], item.Prefixes[i].Operand);
				}
				iLExpression.Prefixes = array;
			}
			if (item.Label != null)
			{
				list.Add(item.Label);
			}
			int num2 = ((item.PopCount >= 0) ? item.PopCount : item.StackBefore.Length);
			for (int j = item.StackBefore.Length - num2; j < item.StackBefore.Length; j++)
			{
				StackSlot stackSlot = item.StackBefore[j];
				iLExpression.Arguments.Add(new ILExpression(ILCode.Ldloc, stackSlot.LoadFrom));
			}
			List<ILVariable> storeTo = item.StoreTo;
			if (storeTo == null || storeTo.Count == 0)
			{
				list.Add(iLExpression);
				continue;
			}
			if (item.StoreTo.Count == 1)
			{
				list.Add(new ILExpression(ILCode.Stloc, item.StoreTo[0], iLExpression));
				continue;
			}
			ILVariable operand = new ILVariable("expr_" + item.Offset.ToString("X2"))
			{
				GeneratedByDecompiler = true
			};
			list.Add(new ILExpression(ILCode.Stloc, operand, iLExpression));
			foreach (ILVariable item2 in item.StoreTo.AsEnumerable().Reverse())
			{
				list.Add(new ILExpression(ILCode.Stloc, item2, new ILExpression(ILCode.Ldloc, operand)));
			}
		}
		return list;
	}
}
