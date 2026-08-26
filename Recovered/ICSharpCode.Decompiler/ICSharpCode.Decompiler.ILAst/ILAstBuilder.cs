using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSharpCode.Decompiler.ILAst
{
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
					array[i] = new StackSlot(new ByteCode[1]
					{
						pushDefinition
					}, null);
				}
				return array;
			}
		}

		private struct VariableSlot
		{
			public readonly ByteCode[] Definitions;

			public readonly bool UnknownDefinition;

			private static readonly VariableSlot UnknownInstance = new VariableSlot(new ByteCode[0], unknownDefinition: true);

			public VariableSlot(ByteCode[] definitions, bool unknownDefinition)
			{
				Definitions = definitions;
				UnknownDefinition = unknownDefinition;
			}

			public static VariableSlot[] CloneVariableState(VariableSlot[] state)
			{
				VariableSlot[] array = new VariableSlot[state.Length];
				Array.Copy(state, array, state.Length);
				return array;
			}

			public static VariableSlot[] MakeUknownState(int varCount)
			{
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

			public int Offset;

			public int EndOffset;

			public ILCode Code;

			public object Operand;

			public int? PopCount;

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
					else if (Operand is Instruction[])
					{
						Instruction[] prefixes = (Instruction[])Operand;
						foreach (Instruction instruction2 in prefixes)
						{
							stringBuilder.Append("IL_" + instruction2.Offset.ToString("X2"));
							stringBuilder.Append(" ");
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
					foreach (StackSlot stackSlot in stackBefore)
					{
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
					foreach (ILVariable item in StoreTo)
					{
						if (!flag3)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(item.Name);
						flag3 = false;
					}
					stringBuilder.Append("}");
				}
				if (VariablesBefore != null)
				{
					stringBuilder.Append(" VarsBefore={");
					bool flag4 = true;
					VariableSlot[] variablesBefore = VariablesBefore;
					foreach (VariableSlot variableSlot in variablesBefore)
					{
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
							ByteCode[] definitions = variableSlot.Definitions;
							foreach (ByteCode byteCode2 in definitions)
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

		private MethodDefinition methodDef;

		private bool optimize;

		private Dictionary<ExceptionHandler, ByteCode> ldexceptions = new Dictionary<ExceptionHandler, ByteCode>();

		private DecompilerContext context;

		public List<ILVariable> Parameters = new List<ILVariable>();

		public List<ILNode> Build(MethodDefinition methodDef, bool optimize, DecompilerContext context)
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

		private List<ByteCode> StackAnalysis(MethodDefinition methodDef)
		{
			Dictionary<Instruction, ByteCode> instrToByteCode = new Dictionary<Instruction, ByteCode>();
			List<ByteCode> body = new List<ByteCode>(methodDef.Body.Instructions.Count);
			List<Instruction> list = null;
			foreach (Instruction instruction in methodDef.Body.Instructions)
			{
				if (instruction.OpCode.OpCodeType == OpCodeType.Prefix)
				{
					if (list == null)
					{
						list = new List<Instruction>(1);
					}
					list.Add(instruction);
				}
				else
				{
					ILCode code = (ILCode)instruction.OpCode.Code;
					object operand = instruction.Operand;
					ILCodeUtil.ExpandMacro(ref code, ref operand, methodDef.Body);
					ByteCode byteCode2 = new ByteCode
					{
						Offset = instruction.Offset,
						EndOffset = ((instruction.Next != null) ? instruction.Next.Offset : methodDef.Body.CodeSize),
						Code = code,
						Operand = operand,
						PopCount = instruction.GetPopDelta(methodDef),
						PushCount = instruction.GetPushDelta()
					};
					if (list != null)
					{
						instrToByteCode[list[0]] = byteCode2;
						byteCode2.Offset = list[0].Offset;
						byteCode2.Prefixes = list.ToArray();
						list = null;
					}
					else
					{
						instrToByteCode[instruction] = byteCode2;
					}
					body.Add(byteCode2);
				}
			}
			for (int i = 0; i < body.Count - 1; i++)
			{
				body[i].Next = body[i + 1];
			}
			Stack<ByteCode> stack = new Stack<ByteCode>();
			int count = methodDef.Body.Variables.Count;
			HashSet<ByteCode> hashSet = new HashSet<ByteCode>(from eh in methodDef.Body.ExceptionHandlers
				select instrToByteCode[eh.HandlerStart]);
			if (methodDef.Body.HasExceptionHandlers)
			{
				foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
				{
					ByteCode byteCode3 = instrToByteCode[exceptionHandler.HandlerStart];
					byteCode3.StackBefore = new StackSlot[0];
					byteCode3.VariablesBefore = VariableSlot.MakeUknownState(count);
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
							new StackSlot(new ByteCode[1]
							{
								byteCode4
							}, null)
						};
					}
					stack.Push(byteCode3);
					if (exceptionHandler.HandlerType == ExceptionHandlerType.Filter)
					{
						ByteCode byteCode5 = instrToByteCode[exceptionHandler.FilterStart];
						ByteCode byteCode6 = new ByteCode
						{
							Code = ILCode.Ldexception,
							Operand = exceptionHandler.CatchType,
							PopCount = 0,
							PushCount = 1
						};
						byteCode5.StackBefore = new StackSlot[1]
						{
							new StackSlot(new ByteCode[1]
							{
								byteCode6
							}, null)
						};
						byteCode5.VariablesBefore = VariableSlot.MakeUknownState(count);
						stack.Push(byteCode5);
					}
				}
			}
			body[0].StackBefore = new StackSlot[0];
			body[0].VariablesBefore = VariableSlot.MakeUknownState(count);
			stack.Push(body[0]);
			while (stack.Count > 0)
			{
				ByteCode byteCode7 = stack.Pop();
				StackSlot[] array = StackSlot.ModifyStack(byteCode7.StackBefore, byteCode7.PopCount ?? byteCode7.StackBefore.Length, byteCode7.PushCount, byteCode7);
				VariableSlot[] array2 = VariableSlot.CloneVariableState(byteCode7.VariablesBefore);
				if (byteCode7.IsVariableDefinition)
				{
					array2[((VariableReference)byteCode7.Operand).Index] = new VariableSlot(new ByteCode[1]
					{
						byteCode7
					}, unknownDefinition: false);
				}
				if (byteCode7.Code == ILCode.Leave)
				{
					array2 = VariableSlot.MakeUknownState(count);
				}
				List<ByteCode> list2 = new List<ByteCode>();
				if (!byteCode7.Code.IsUnconditionalControlFlow() && !hashSet.Contains(byteCode7.Next))
				{
					list2.Add(byteCode7.Next);
				}
				if (byteCode7.Operand is Instruction[])
				{
					Instruction[] array3 = (Instruction[])byteCode7.Operand;
					foreach (Instruction key in array3)
					{
						ByteCode byteCode8 = instrToByteCode[key];
						list2.Add(byteCode8);
						if (byteCode8.Label == null)
						{
							byteCode8.Label = new ILLabel
							{
								Name = byteCode8.Name
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
							Name = byteCode9.Name
						};
					}
				}
				foreach (ByteCode item in list2)
				{
					if (item.StackBefore == null && item.VariablesBefore == null)
					{
						if (list2.Count == 1)
						{
							item.StackBefore = array;
							item.VariablesBefore = array2;
						}
						else
						{
							item.StackBefore = StackSlot.ModifyStack(array, 0, 0, null);
							item.VariablesBefore = VariableSlot.CloneVariableState(array2);
						}
						stack.Push(item);
					}
					else
					{
						if (item.StackBefore.Length != array.Length)
						{
							throw new Exception("Inconsistent stack size at " + byteCode7.Name);
						}
						bool flag = false;
						for (int k = 0; k < array.Length; k++)
						{
							ByteCode[] definitions = item.StackBefore[k].Definitions;
							ByteCode[] array4 = definitions.Union(array[k].Definitions);
							if (array4.Length > definitions.Length)
							{
								item.StackBefore[k] = new StackSlot(array4, null);
								flag = true;
							}
						}
						for (int l = 0; l < array2.Length; l++)
						{
							VariableSlot variableSlot = item.VariablesBefore[l];
							VariableSlot variableSlot2 = array2[l];
							if (!variableSlot.UnknownDefinition)
							{
								if (variableSlot2.UnknownDefinition)
								{
									item.VariablesBefore[l] = variableSlot2;
									flag = true;
								}
								else
								{
									ByteCode[] definitions2 = variableSlot.Definitions;
									ByteCode[] array5 = definitions2.Union(variableSlot2.Definitions);
									if (array5.Length > definitions2.Length)
									{
										item.VariablesBefore[l] = new VariableSlot(array5, unknownDefinition: false);
										flag = true;
									}
								}
							}
						}
						if (flag)
						{
							stack.Push(item);
						}
					}
				}
			}
			body.RemoveAll((ByteCode b) => b.StackBefore == null);
			foreach (ByteCode item2 in body)
			{
				int num = 0;
				int num2 = item2.PopCount ?? item2.StackBefore.Length;
				for (int m = item2.StackBefore.Length - num2; m < item2.StackBefore.Length; m++)
				{
					ILVariable iLVariable = new ILVariable
					{
						Name = $"arg_{item2.Offset:X2}_{num}",
						IsGenerated = true
					};
					item2.StackBefore[m] = new StackSlot(item2.StackBefore[m].Definitions, iLVariable);
					ByteCode[] definitions3 = item2.StackBefore[m].Definitions;
					foreach (ByteCode byteCode10 in definitions3)
					{
						if (byteCode10.StoreTo == null)
						{
							byteCode10.StoreTo = new List<ILVariable>(1);
						}
						byteCode10.StoreTo.Add(iLVariable);
					}
					num++;
				}
			}
			foreach (ByteCode byteCode in body)
			{
				if (byteCode.StoreTo != null && byteCode.StoreTo.Count > 1)
				{
					List<ILVariable> storeTo = byteCode.StoreTo;
					if ((from locVar in storeTo
						select body.SelectMany((ByteCode bc) => bc.StackBefore).Single((StackSlot s) => s.LoadFrom == locVar)).ToList().All((StackSlot slot) => slot.Definitions.Length == 1 && slot.Definitions[0] == byteCode))
					{
						ILVariable iLVariable2 = new ILVariable
						{
							Name = $"expr_{byteCode.Offset:X2}",
							IsGenerated = true
						};
						byteCode.StoreTo = new List<ILVariable>
						{
							iLVariable2
						};
						foreach (ByteCode item3 in body)
						{
							for (int n = 0; n < item3.StackBefore.Length; n++)
							{
								if (storeTo.Contains(item3.StackBefore[n].LoadFrom))
								{
									item3.StackBefore[n] = new StackSlot(item3.StackBefore[n].Definitions, iLVariable2);
								}
							}
						}
					}
				}
			}
			ConvertLocalVariables(body);
			foreach (ByteCode item4 in body)
			{
				if (item4.Operand is Instruction[])
				{
					List<ILLabel> list3 = new List<ILLabel>();
					Instruction[] array3 = (Instruction[])item4.Operand;
					foreach (Instruction key2 in array3)
					{
						list3.Add(instrToByteCode[key2].Label);
					}
					item4.Operand = list3.ToArray();
				}
				else if (item4.Operand is Instruction)
				{
					item4.Operand = instrToByteCode[(Instruction)item4.Operand].Label;
				}
			}
			ConvertParameters(body);
			return body;
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
				if (!b.PopCount.HasValue)
				{
					return false;
				}
				num -= b.PopCount.GetValueOrDefault();
				if (num == 0)
				{
					break;
				}
				if (num < 0)
				{
					return false;
				}
				if (b.Code.IsConditionalControlFlow() || b.Code.IsUnconditionalControlFlow())
				{
					return false;
				}
				switch (b.Code)
				{
				case ILCode.Ldloc:
				case ILCode.Ldloca:
				case ILCode.Stloc:
					if (b.Operand == operand)
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
			if (b.Code == ILCode.Call || b.Code == ILCode.Callvirt)
			{
				return ((MethodReference)b.Operand).HasThis;
			}
			return false;
		}

		private void ConvertLocalVariables(List<ByteCode> body)
		{
			foreach (VariableDefinition varDef in methodDef.Body.Variables)
			{
				List<ByteCode> list = (from b in body
					where b.Operand == varDef && b.IsVariableDefinition
					select b).ToList();
				List<ByteCode> list2 = (from b in body
					where b.Operand == varDef && !b.IsVariableDefinition
					select b).ToList();
				List<VariableInfo> list3;
				if (!optimize || varDef.IsPinned || list2.Any((ByteCode b) => (!b.VariablesBefore[varDef.Index].UnknownDefinition) ? (b.Code == ILCode.Ldloca && !IsDeterministicLdloca(b)) : true))
				{
					list3 = new List<VariableInfo>(1)
					{
						new VariableInfo
						{
							Variable = new ILVariable
							{
								Name = (string.IsNullOrEmpty(varDef.Name) ? ("var_" + varDef.Index) : varDef.Name),
								Type = (varDef.IsPinned ? ((PinnedType)varDef.VariableType).ElementType : varDef.VariableType),
								OriginalVariable = varDef
							},
							Defs = list,
							Uses = list2
						}
					};
				}
				else
				{
					list3 = (from def in list
						select new VariableInfo
						{
							Variable = new ILVariable
							{
								Name = (string.IsNullOrEmpty(varDef.Name) ? ("var_" + varDef.Index) : varDef.Name) + "_" + def.Offset.ToString("X2"),
								Type = varDef.VariableType,
								OriginalVariable = varDef
							},
							Defs = new List<ByteCode>
							{
								def
							},
							Uses = new List<ByteCode>()
						}).ToList();
					foreach (ByteCode item in list2)
					{
						ByteCode[] useDefs = item.VariablesBefore[varDef.Index].Definitions;
						if (useDefs.Length == 1)
						{
							list3.Single((VariableInfo v) => v.Defs.Contains(useDefs[0])).Uses.Add(item);
						}
						else
						{
							List<VariableInfo> list4 = (from v in list3
								where v.Defs.Intersect(useDefs).Any()
								select v).ToList();
							VariableInfo variableInfo = new VariableInfo
							{
								Variable = list4[0].Variable,
								Defs = list4.SelectMany((VariableInfo v) => v.Defs).ToList(),
								Uses = list4.SelectMany((VariableInfo v) => v.Uses).ToList()
							};
							variableInfo.Uses.Add(item);
							list3 = list3.Except(list4).ToList();
							list3.Add(variableInfo);
						}
					}
				}
				foreach (VariableInfo item2 in list3)
				{
					foreach (ByteCode def in item2.Defs)
					{
						def.Operand = item2.Variable;
					}
					foreach (ByteCode use in item2.Uses)
					{
						use.Operand = item2.Variable;
					}
				}
			}
		}

		private void ConvertParameters(List<ByteCode> body)
		{
			ILVariable iLVariable = null;
			if (methodDef.HasThis)
			{
				TypeReference declaringType = methodDef.DeclaringType;
				iLVariable = new ILVariable();
				iLVariable.Type = (declaringType.IsValueType ? new ByReferenceType(declaringType) : declaringType);
				iLVariable.Name = "this";
				iLVariable.OriginalParameter = methodDef.Body.ThisParameter;
			}
			foreach (ParameterDefinition parameter in methodDef.Parameters)
			{
				Parameters.Add(new ILVariable
				{
					Type = parameter.ParameterType,
					Name = parameter.Name,
					OriginalParameter = parameter
				});
			}
			if (Parameters.Count > 0 && (methodDef.IsSetter || methodDef.IsAddOn || methodDef.IsRemoveOn))
			{
				Parameters.Last().Name = "value";
			}
			foreach (ByteCode item in body)
			{
				switch (item.Code)
				{
				case ILCode.__Ldarg:
				{
					ParameterDefinition parameterDefinition = (ParameterDefinition)item.Operand;
					item.Code = ILCode.Ldloc;
					item.Operand = ((parameterDefinition.Index < 0) ? iLVariable : Parameters[parameterDefinition.Index]);
					break;
				}
				case ILCode.__Starg:
				{
					ParameterDefinition parameterDefinition = (ParameterDefinition)item.Operand;
					item.Code = ILCode.Stloc;
					item.Operand = ((parameterDefinition.Index < 0) ? iLVariable : Parameters[parameterDefinition.Index]);
					break;
				}
				case ILCode.__Ldarga:
				{
					ParameterDefinition parameterDefinition = (ParameterDefinition)item.Operand;
					item.Code = ILCode.Ldloca;
					item.Operand = ((parameterDefinition.Index < 0) ? iLVariable : Parameters[parameterDefinition.Index]);
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
			int handlerEndOffset;
			while (ehs.Any())
			{
				ILTryCatchBlock iLTryCatchBlock = new ILTryCatchBlock();
				int tryStart = ehs.Min((ExceptionHandler eh) => eh.TryStart.Offset);
				int tryEnd = (from eh in ehs
					where eh.TryStart.Offset == tryStart
					select eh).Max((ExceptionHandler eh) => eh.TryEnd.Offset);
				List<ExceptionHandler> list2 = (from eh in ehs
					where eh.TryStart.Offset == tryStart && eh.TryEnd.Offset == tryEnd
					select eh).ToList();
				int i;
				for (i = 0; i < body.Count && body[i].Offset < tryStart; i++)
				{
				}
				list.AddRange(ConvertToAst(body.CutRange(0, i)));
				HashSet<ExceptionHandler> hashSet = new HashSet<ExceptionHandler>(from eh in ehs
					where (tryStart > eh.TryStart.Offset || eh.TryEnd.Offset >= tryEnd) ? (tryStart < eh.TryStart.Offset && eh.TryEnd.Offset <= tryEnd) : true
					select eh);
				ehs.ExceptWith(hashSet);
				int j;
				for (j = 0; j < body.Count && body[j].Offset < tryEnd; j++)
				{
				}
				iLTryCatchBlock.TryBlock = new ILBlock(ConvertToAst(body.CutRange(0, j), hashSet));
				iLTryCatchBlock.CatchBlocks = new List<ILTryCatchBlock.CatchBlock>();
				foreach (ExceptionHandler eh2 in list2)
				{
					handlerEndOffset = ((eh2.HandlerEnd == null) ? methodDef.Body.CodeSize : eh2.HandlerEnd.Offset);
					int k;
					for (k = 0; k < body.Count && body[k].Offset < eh2.HandlerStart.Offset; k++)
					{
					}
					int l;
					for (l = 0; l < body.Count && body[l].Offset < handlerEndOffset; l++)
					{
					}
					HashSet<ExceptionHandler> hashSet2 = new HashSet<ExceptionHandler>(from e in ehs
						where (eh2.HandlerStart.Offset > e.TryStart.Offset || e.TryEnd.Offset >= handlerEndOffset) ? (eh2.HandlerStart.Offset < e.TryStart.Offset && e.TryEnd.Offset <= handlerEndOffset) : true
						select e);
					ehs.ExceptWith(hashSet2);
					List<ILNode> body2 = ConvertToAst(body.CutRange(k, l - k), hashSet2);
					if (eh2.HandlerType == ExceptionHandlerType.Catch)
					{
						ILTryCatchBlock.CatchBlock catchBlock = new ILTryCatchBlock.CatchBlock
						{
							ExceptionType = eh2.CatchType,
							Body = body2
						};
						ByteCode byteCode = ldexceptions[eh2];
						if (byteCode.StoreTo == null || byteCode.StoreTo.Count == 0)
						{
							catchBlock.ExceptionVariable = null;
						}
						else if (byteCode.StoreTo.Count == 1)
						{
							ILExpression iLExpression = catchBlock.Body[0] as ILExpression;
							if (iLExpression != null && iLExpression.Code == ILCode.Pop && iLExpression.Arguments[0].Code == ILCode.Ldloc && iLExpression.Arguments[0].Operand == byteCode.StoreTo[0])
							{
								if (context.Settings.AlwaysGenerateExceptionVariableForCatchBlocks)
								{
									catchBlock.ExceptionVariable = new ILVariable
									{
										Name = "ex_" + eh2.HandlerStart.Offset.ToString("X2"),
										IsGenerated = true
									};
								}
								else
								{
									catchBlock.ExceptionVariable = null;
								}
								catchBlock.Body.RemoveAt(0);
							}
							else
							{
								catchBlock.ExceptionVariable = byteCode.StoreTo[0];
							}
						}
						else
						{
							ILVariable operand = catchBlock.ExceptionVariable = new ILVariable
							{
								Name = "ex_" + eh2.HandlerStart.Offset.ToString("X2"),
								IsGenerated = true
							};
							foreach (ILVariable item in byteCode.StoreTo)
							{
								catchBlock.Body.Insert(0, new ILExpression(ILCode.Stloc, item, new ILExpression(ILCode.Ldloc, operand)));
							}
						}
						iLTryCatchBlock.CatchBlocks.Add(catchBlock);
					}
					else if (eh2.HandlerType == ExceptionHandlerType.Finally)
					{
						iLTryCatchBlock.FinallyBlock = new ILBlock(body2);
					}
					else if (eh2.HandlerType == ExceptionHandlerType.Fault)
					{
						iLTryCatchBlock.FaultBlock = new ILBlock(body2);
					}
				}
				ehs.ExceptWith(list2);
				list.Add(iLTryCatchBlock);
			}
			list.AddRange(ConvertToAst(body));
			return list;
		}

		private List<ILNode> ConvertToAst(List<ByteCode> body)
		{
			List<ILNode> list = new List<ILNode>();
			foreach (ByteCode item2 in body)
			{
				ILRange item = new ILRange(item2.Offset, item2.EndOffset);
				if (item2.StackBefore != null)
				{
					ILExpression iLExpression = new ILExpression(item2.Code, item2.Operand);
					iLExpression.ILRanges.Add(item);
					if (item2.Prefixes != null && item2.Prefixes.Length != 0)
					{
						ILExpressionPrefix[] array = new ILExpressionPrefix[item2.Prefixes.Length];
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = new ILExpressionPrefix((ILCode)item2.Prefixes[i].OpCode.Code, item2.Prefixes[i].Operand);
						}
						iLExpression.Prefixes = array;
					}
					if (item2.Label != null)
					{
						list.Add(item2.Label);
					}
					int num = item2.PopCount ?? item2.StackBefore.Length;
					for (int j = item2.StackBefore.Length - num; j < item2.StackBefore.Length; j++)
					{
						StackSlot stackSlot = item2.StackBefore[j];
						iLExpression.Arguments.Add(new ILExpression(ILCode.Ldloc, stackSlot.LoadFrom));
					}
					if (item2.StoreTo == null || item2.StoreTo.Count == 0)
					{
						list.Add(iLExpression);
					}
					else if (item2.StoreTo.Count == 1)
					{
						list.Add(new ILExpression(ILCode.Stloc, item2.StoreTo[0], iLExpression));
					}
					else
					{
						ILVariable operand = new ILVariable
						{
							Name = "expr_" + item2.Offset.ToString("X2"),
							IsGenerated = true
						};
						list.Add(new ILExpression(ILCode.Stloc, operand, iLExpression));
						foreach (ILVariable item3 in item2.StoreTo.AsEnumerable().Reverse())
						{
							list.Add(new ILExpression(ILCode.Stloc, item3, new ILExpression(ILCode.Ldloc, operand)));
						}
					}
				}
			}
			return list;
		}
	}
}
