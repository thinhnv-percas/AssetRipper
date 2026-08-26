using DevX.Cecil.Binary;
using DevX.Cecil.Metadata;
using DevX.Cecil.Signatures;
using System;
using System.Collections;

namespace DevX.Cecil.Cil
{
	internal sealed class CodeWriter : BaseCodeVisitor
	{
		private ReflectionWriter m_reflectWriter;

		private MemoryBinaryWriter m_binaryWriter;

		private MemoryBinaryWriter m_codeWriter;

		private IDictionary m_localSigCache;

		private IDictionary m_standaloneSigCache;

		private IDictionary m_stackSizes;

		private bool stripped;

		public bool Stripped
		{
			get
			{
				return stripped;
			}
			set
			{
				stripped = value;
			}
		}

		public CodeWriter(ReflectionWriter reflectWriter, MemoryBinaryWriter writer)
		{
			m_reflectWriter = reflectWriter;
			m_binaryWriter = writer;
			m_codeWriter = new MemoryBinaryWriter();
			m_localSigCache = new Hashtable();
			m_standaloneSigCache = new Hashtable();
			m_stackSizes = new Hashtable();
		}

		public RVA WriteMethodBody(MethodDefinition meth)
		{
			if (meth.Body == null)
			{
				return RVA.Zero;
			}
			RVA dataCursor = m_reflectWriter.MetadataWriter.GetDataCursor();
			meth.Body.Accept(this);
			return dataCursor;
		}

		public override void VisitMethodBody(MethodBody body)
		{
			m_codeWriter.Empty();
		}

		private void WriteToken(MetadataToken token)
		{
			if (token.RID == 0)
			{
				m_codeWriter.Write(0);
			}
			else
			{
				m_codeWriter.Write(token.ToUInt());
			}
		}

		private static int GetParameterIndex(MethodBody body, ParameterDefinition p)
		{
			int num = body.Method.Parameters.IndexOf(p);
			if (num == -1 && p == body.Method.This)
			{
				return 0;
			}
			if (body.Method.HasThis)
			{
				num++;
			}
			return num;
		}

		public override void VisitInstructionCollection(InstructionCollection instructions)
		{
			MethodBody container = instructions.Container;
			long position = m_codeWriter.BaseStream.Position;
			ComputeMaxStack(instructions);
			foreach (Instruction instruction4 in instructions)
			{
				instruction4.Offset = (int)(m_codeWriter.BaseStream.Position - position);
				if (instruction4.OpCode.Size == 1)
				{
					m_codeWriter.Write(instruction4.OpCode.Op2);
				}
				else
				{
					m_codeWriter.Write(instruction4.OpCode.Op1);
					m_codeWriter.Write(instruction4.OpCode.Op2);
				}
				if (instruction4.OpCode.OperandType != OperandType.InlineNone && instruction4.Operand == null)
				{
					throw new ReflectionException("OpCode {0} have null operand", instruction4.OpCode.Name);
				}
				switch (instruction4.OpCode.OperandType)
				{
				case OperandType.InlineSwitch:
				{
					Instruction[] array = (Instruction[])instruction4.Operand;
					for (int i = 0; i < array.Length + 1; i++)
					{
						m_codeWriter.Write(0u);
					}
					break;
				}
				case OperandType.ShortInlineBrTarget:
					m_codeWriter.Write((byte)0);
					break;
				case OperandType.InlineBrTarget:
					m_codeWriter.Write(0);
					break;
				case OperandType.ShortInlineI:
					if (instruction4.OpCode == OpCodes.Ldc_I4_S)
					{
						m_codeWriter.Write((sbyte)instruction4.Operand);
					}
					else
					{
						m_codeWriter.Write((byte)instruction4.Operand);
					}
					break;
				case OperandType.ShortInlineVar:
					m_codeWriter.Write((byte)container.Variables.IndexOf((VariableDefinition)instruction4.Operand));
					break;
				case OperandType.ShortInlineParam:
					m_codeWriter.Write((byte)GetParameterIndex(container, (ParameterDefinition)instruction4.Operand));
					break;
				case OperandType.InlineSig:
					WriteToken(GetCallSiteToken((CallSite)instruction4.Operand));
					break;
				case OperandType.InlineI:
					m_codeWriter.Write((int)instruction4.Operand);
					break;
				case OperandType.InlineVar:
					m_codeWriter.Write((short)container.Variables.IndexOf((VariableDefinition)instruction4.Operand));
					break;
				case OperandType.InlineParam:
					m_codeWriter.Write((short)GetParameterIndex(container, (ParameterDefinition)instruction4.Operand));
					break;
				case OperandType.InlineI8:
					m_codeWriter.Write((long)instruction4.Operand);
					break;
				case OperandType.ShortInlineR:
					m_codeWriter.Write((float)instruction4.Operand);
					break;
				case OperandType.InlineR:
					m_codeWriter.Write((double)instruction4.Operand);
					break;
				case OperandType.InlineString:
					WriteToken(new MetadataToken(TokenType.String, m_reflectWriter.MetadataWriter.AddUserString(instruction4.Operand as string)));
					break;
				case OperandType.InlineField:
				case OperandType.InlineMethod:
				case OperandType.InlineTok:
				case OperandType.InlineType:
					if (instruction4.Operand is TypeReference)
					{
						WriteToken(GetTypeToken((TypeReference)instruction4.Operand));
					}
					else if (instruction4.Operand is GenericInstanceMethod)
					{
						WriteToken(m_reflectWriter.GetMethodSpecToken(instruction4.Operand as GenericInstanceMethod));
					}
					else if (instruction4.Operand is MemberReference)
					{
						WriteToken(m_reflectWriter.GetMemberRefToken((MemberReference)instruction4.Operand));
					}
					else
					{
						if (!(instruction4.Operand is IMetadataTokenProvider))
						{
							throw new ReflectionException($"Wrong operand for {instruction4.OpCode.OperandType} OpCode: {instruction4.Operand.GetType().FullName}");
						}
						WriteToken(((IMetadataTokenProvider)instruction4.Operand).MetadataToken);
					}
					break;
				}
			}
			long position2 = m_codeWriter.BaseStream.Position;
			foreach (Instruction instruction5 in instructions)
			{
				switch (instruction5.OpCode.OperandType)
				{
				case OperandType.InlineSwitch:
				{
					m_codeWriter.BaseStream.Position = instruction5.Offset + instruction5.OpCode.Size;
					Instruction[] array2 = (Instruction[])instruction5.Operand;
					m_codeWriter.Write((uint)array2.Length);
					Instruction[] array3 = array2;
					foreach (Instruction instruction3 in array3)
					{
						m_codeWriter.Write(instruction3.Offset - (instruction5.Offset + instruction5.OpCode.Size + 4 * (array2.Length + 1)));
					}
					break;
				}
				case OperandType.ShortInlineBrTarget:
					m_codeWriter.BaseStream.Position = instruction5.Offset + instruction5.OpCode.Size;
					m_codeWriter.Write((byte)(((Instruction)instruction5.Operand).Offset - (instruction5.Offset + instruction5.OpCode.Size + 1)));
					break;
				case OperandType.InlineBrTarget:
					m_codeWriter.BaseStream.Position = instruction5.Offset + instruction5.OpCode.Size;
					m_codeWriter.Write(((Instruction)instruction5.Operand).Offset - (instruction5.Offset + instruction5.OpCode.Size + 4));
					break;
				}
			}
			m_codeWriter.BaseStream.Position = position2;
		}

		private MetadataToken GetTypeToken(TypeReference type)
		{
			return m_reflectWriter.GetTypeDefOrRefToken(type);
		}

		private MetadataToken GetCallSiteToken(CallSite cs)
		{
			int sentinel = cs.GetSentinel();
			uint num = (sentinel <= 0) ? m_reflectWriter.SignatureWriter.AddMethodRefSig(m_reflectWriter.GetMethodRefSig(cs)) : m_reflectWriter.SignatureWriter.AddMethodDefSig(m_reflectWriter.GetMethodDefSig(cs));
			if (m_standaloneSigCache.Contains(num))
			{
				return (MetadataToken)m_standaloneSigCache[num];
			}
			StandAloneSigTable standAloneSigTable = m_reflectWriter.MetadataTableWriter.GetStandAloneSigTable();
			StandAloneSigRow value = m_reflectWriter.MetadataRowWriter.CreateStandAloneSigRow(num);
			standAloneSigTable.Rows.Add(value);
			MetadataToken metadataToken = new MetadataToken(TokenType.Signature, (uint)standAloneSigTable.Rows.Count);
			m_standaloneSigCache[num] = metadataToken;
			return metadataToken;
		}

		private static int GetLength(Instruction start, Instruction end, InstructionCollection instructions)
		{
			Instruction instruction = instructions[instructions.Count - 1];
			return ((end != instructions.Outside) ? end.Offset : (instruction.Offset + instruction.GetSize())) - start.Offset;
		}

		private static bool IsRangeFat(Instruction start, Instruction end, InstructionCollection instructions)
		{
			return GetLength(start, end, instructions) >= 256 || start.Offset >= 65536;
		}

		private static bool IsFat(ExceptionHandlerCollection seh)
		{
			for (int i = 0; i < seh.Count; i++)
			{
				ExceptionHandler exceptionHandler = seh[i];
				if (IsRangeFat(exceptionHandler.TryStart, exceptionHandler.TryEnd, seh.Container.Instructions))
				{
					return true;
				}
				if (IsRangeFat(exceptionHandler.HandlerStart, exceptionHandler.HandlerEnd, seh.Container.Instructions))
				{
					return true;
				}
				ExceptionHandlerType type = exceptionHandler.Type;
				if (type == ExceptionHandlerType.Filter && IsRangeFat(exceptionHandler.FilterStart, exceptionHandler.FilterEnd, seh.Container.Instructions))
				{
					return true;
				}
			}
			return false;
		}

		private void WriteExceptionHandlerCollection(ExceptionHandlerCollection seh)
		{
			m_codeWriter.QuadAlign();
			if (seh.Count < 21 && !IsFat(seh))
			{
				m_codeWriter.Write((byte)1);
				m_codeWriter.Write((byte)(seh.Count * 12 + 4));
				m_codeWriter.Write(new byte[2]);
				foreach (ExceptionHandler item in seh)
				{
					m_codeWriter.Write((ushort)item.Type);
					m_codeWriter.Write((ushort)item.TryStart.Offset);
					m_codeWriter.Write((byte)(item.TryEnd.Offset - item.TryStart.Offset));
					m_codeWriter.Write((ushort)item.HandlerStart.Offset);
					m_codeWriter.Write((byte)GetLength(item.HandlerStart, item.HandlerEnd, seh.Container.Instructions));
					WriteHandlerSpecific(item);
				}
			}
			else
			{
				m_codeWriter.Write((byte)65);
				WriteFatBlockSize(seh);
				foreach (ExceptionHandler item2 in seh)
				{
					m_codeWriter.Write((uint)item2.Type);
					m_codeWriter.Write((uint)item2.TryStart.Offset);
					m_codeWriter.Write((uint)(item2.TryEnd.Offset - item2.TryStart.Offset));
					m_codeWriter.Write((uint)item2.HandlerStart.Offset);
					m_codeWriter.Write((uint)GetLength(item2.HandlerStart, item2.HandlerEnd, seh.Container.Instructions));
					WriteHandlerSpecific(item2);
				}
			}
		}

		private void WriteFatBlockSize(ExceptionHandlerCollection seh)
		{
			int num = seh.Count * 24 + 4;
			m_codeWriter.Write((byte)(num & 0xFF));
			m_codeWriter.Write((byte)((num >> 8) & 0xFF));
			m_codeWriter.Write((byte)((num >> 16) & 0xFF));
		}

		private void WriteHandlerSpecific(ExceptionHandler eh)
		{
			switch (eh.Type)
			{
			case ExceptionHandlerType.Catch:
				WriteToken(GetTypeToken(eh.CatchType));
				break;
			case ExceptionHandlerType.Filter:
				m_codeWriter.Write((uint)eh.FilterStart.Offset);
				break;
			default:
				m_codeWriter.Write(0);
				break;
			}
		}

		public override void VisitVariableDefinitionCollection(VariableDefinitionCollection variables)
		{
			MethodBody methodBody = variables.Container as MethodBody;
			if (methodBody != null && !stripped)
			{
				uint num = m_reflectWriter.SignatureWriter.AddLocalVarSig(GetLocalVarSig(variables));
				if (m_localSigCache.Contains(num))
				{
					methodBody.LocalVarToken = (int)m_localSigCache[num];
					return;
				}
				StandAloneSigTable standAloneSigTable = m_reflectWriter.MetadataTableWriter.GetStandAloneSigTable();
				StandAloneSigRow value = m_reflectWriter.MetadataRowWriter.CreateStandAloneSigRow(num);
				standAloneSigTable.Rows.Add(value);
				methodBody.LocalVarToken = standAloneSigTable.Rows.Count;
				m_localSigCache[num] = methodBody.LocalVarToken;
			}
		}

		public override void TerminateMethodBody(MethodBody body)
		{
			long position = m_binaryWriter.BaseStream.Position;
			if (body.HasVariables || body.HasExceptionHandlers || m_codeWriter.BaseStream.Length >= 64 || body.MaxStack > 8)
			{
				MethodHeader methodHeader = MethodHeader.FatFormat;
				if (body.InitLocals)
				{
					methodHeader |= MethodHeader.InitLocals;
				}
				if (body.HasExceptionHandlers)
				{
					methodHeader |= MethodHeader.MoreSects;
				}
				m_binaryWriter.Write((byte)methodHeader);
				m_binaryWriter.Write((byte)48);
				m_binaryWriter.Write((short)body.MaxStack);
				m_binaryWriter.Write((int)m_codeWriter.BaseStream.Length);
				int value = body.HasVariables ? (0x11000000 | body.LocalVarToken) : 0;
				m_binaryWriter.Write(value);
				if (body.HasExceptionHandlers)
				{
					WriteExceptionHandlerCollection(body.ExceptionHandlers);
				}
			}
			else
			{
				m_binaryWriter.Write((byte)(2 | (m_codeWriter.BaseStream.Length << 2)));
			}
			m_binaryWriter.Write(m_codeWriter);
			m_binaryWriter.QuadAlign();
			m_reflectWriter.MetadataWriter.AddData((int)(m_binaryWriter.BaseStream.Position - position));
		}

		public LocalVarSig.LocalVariable GetLocalVariableSig(VariableDefinition var)
		{
			LocalVarSig.LocalVariable result = default(LocalVarSig.LocalVariable);
			TypeReference typeReference = var.VariableType;
			result.CustomMods = m_reflectWriter.GetCustomMods(typeReference);
			if (typeReference is PinnedType)
			{
				result.Constraint |= Constraint.Pinned;
				typeReference = (typeReference as PinnedType).ElementType;
			}
			if (typeReference is ReferenceType)
			{
				result.ByRef = true;
				typeReference = (typeReference as ReferenceType).ElementType;
			}
			result.Type = m_reflectWriter.GetSigType(typeReference);
			return result;
		}

		public LocalVarSig GetLocalVarSig(VariableDefinitionCollection vars)
		{
			LocalVarSig localVarSig = new LocalVarSig();
			localVarSig.CallingConvention |= 7;
			localVarSig.Count = vars.Count;
			localVarSig.LocalVariables = new LocalVarSig.LocalVariable[localVarSig.Count];
			for (int i = 0; i < localVarSig.Count; i++)
			{
				localVarSig.LocalVariables[i] = GetLocalVariableSig(vars[i]);
			}
			return localVarSig;
		}

		private void ComputeMaxStack(InstructionCollection instructions)
		{
			int num = 0;
			int num2 = 0;
			m_stackSizes.Clear();
			foreach (ExceptionHandler exceptionHandler in instructions.Container.ExceptionHandlers)
			{
				ExceptionHandlerType type = exceptionHandler.Type;
				if (type == ExceptionHandlerType.Catch || type == ExceptionHandlerType.Filter)
				{
					m_stackSizes[exceptionHandler.HandlerStart] = 1;
					num2 = 1;
				}
			}
			foreach (Instruction instruction in instructions)
			{
				object obj = m_stackSizes[instruction];
				if (obj != null)
				{
					num = (int)obj;
				}
				num -= GetPopDelta(instructions.Container.Method, instruction, num);
				if (num < 0)
				{
					num = 0;
				}
				num += GetPushDelta(instruction);
				if (num > num2)
				{
					num2 = num;
				}
				switch (instruction.OpCode.OperandType)
				{
				case OperandType.InlineBrTarget:
				case OperandType.ShortInlineBrTarget:
					m_stackSizes[instruction.Operand] = num;
					break;
				case OperandType.InlineSwitch:
				{
					Instruction[] array = (Instruction[])instruction.Operand;
					foreach (Instruction key in array)
					{
						m_stackSizes[key] = num;
					}
					break;
				}
				}
				FlowControl flowControl = instruction.OpCode.FlowControl;
				if (flowControl == FlowControl.Return || flowControl == FlowControl.Throw || flowControl == FlowControl.Branch)
				{
					num = 0;
				}
			}
			instructions.Container.MaxStack = num2 + 1;
		}

		private static int GetPushDelta(Instruction instruction)
		{
			OpCode opCode = instruction.OpCode;
			switch (opCode.StackBehaviourPush)
			{
			case StackBehaviour.Push0:
				return 0;
			case StackBehaviour.Push1:
			case StackBehaviour.Pushi:
			case StackBehaviour.Pushi8:
			case StackBehaviour.Pushr4:
			case StackBehaviour.Pushr8:
			case StackBehaviour.Pushref:
				return 1;
			case StackBehaviour.Push1_push1:
				return 2;
			case StackBehaviour.Varpush:
			{
				if (opCode.FlowControl != FlowControl.Call)
				{
					break;
				}
				IMethodSignature methodSignature = (IMethodSignature)instruction.Operand;
				return (!IsVoid(methodSignature.ReturnType.ReturnType)) ? 1 : 0;
			}
			}
			throw new NotSupportedException();
		}

		private static int GetPopDelta(MethodDefinition current, Instruction instruction, int height)
		{
			OpCode opCode = instruction.OpCode;
			switch (opCode.StackBehaviourPop)
			{
			case StackBehaviour.Pop0:
				return 0;
			case StackBehaviour.Pop1:
			case StackBehaviour.Popi:
			case StackBehaviour.Popref:
				return 1;
			case StackBehaviour.Pop1_pop1:
			case StackBehaviour.Popi_pop1:
			case StackBehaviour.Popi_popi:
			case StackBehaviour.Popi_popi8:
			case StackBehaviour.Popi_popr4:
			case StackBehaviour.Popi_popr8:
			case StackBehaviour.Popref_pop1:
			case StackBehaviour.Popref_popi:
				return 2;
			case StackBehaviour.Popi_popi_popi:
			case StackBehaviour.Popref_popi_popi:
			case StackBehaviour.Popref_popi_popi8:
			case StackBehaviour.Popref_popi_popr4:
			case StackBehaviour.Popref_popi_popr8:
			case StackBehaviour.Popref_popi_popref:
				return 3;
			case StackBehaviour.PopAll:
				return height;
			case StackBehaviour.Varpop:
			{
				if (opCode == OpCodes.Ret)
				{
					return (!IsVoid(current.ReturnType.ReturnType)) ? 1 : 0;
				}
				if (opCode.FlowControl != FlowControl.Call)
				{
					break;
				}
				IMethodSignature methodSignature = (IMethodSignature)instruction.Operand;
				int num = methodSignature.HasParameters ? methodSignature.Parameters.Count : 0;
				if (methodSignature.HasThis && opCode != OpCodes.Newobj)
				{
					num++;
				}
				return num;
			}
			}
			throw new NotSupportedException();
		}

		private static bool IsVoid(TypeReference type)
		{
			return type.FullName == "System.Void";
		}
	}
}
