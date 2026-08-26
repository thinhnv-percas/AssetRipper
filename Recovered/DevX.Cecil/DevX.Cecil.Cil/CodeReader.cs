using DevX.Cecil.Metadata;
using DevX.Cecil.Signatures;
using System;
using System.Collections;
using System.IO;

namespace DevX.Cecil.Cil
{
	internal sealed class CodeReader : BaseCodeVisitor
	{
		private ReflectionReader m_reflectReader;

		private MetadataRoot m_root;

		private IDictionary m_instructions;

		public CodeReader(ReflectionReader reflectReader)
		{
			m_reflectReader = reflectReader;
			m_root = m_reflectReader.MetadataRoot;
			m_instructions = new Hashtable();
		}

		public override void VisitMethodBody(MethodBody body)
		{
			MethodDefinition method = body.Method;
			BinaryReader dataReader = m_reflectReader.Module.ImageReader.MetadataReader.GetDataReader(method.RVA);
			int num = dataReader.ReadByte();
			switch (num & 3)
			{
			case 2:
				body.CodeSize = num >> 2;
				body.MaxStack = 8;
				ReadCilBody(body, dataReader);
				break;
			case 3:
			{
				dataReader.BaseStream.Position--;
				int num2 = dataReader.ReadUInt16();
				body.MaxStack = dataReader.ReadUInt16();
				body.CodeSize = dataReader.ReadInt32();
				body.LocalVarToken = dataReader.ReadInt32();
				body.InitLocals = ((num2 & 0x10) != 0);
				if (body.LocalVarToken != 0)
				{
					VisitVariableDefinitionCollection(body.Variables);
				}
				ReadCilBody(body, dataReader);
				if ((num2 & 8) != 0)
				{
					ReadSection(body, dataReader);
				}
				break;
			}
			}
		}

		public static uint GetRid(int token)
		{
			return (uint)(token & 0xFFFFFF);
		}

		public static ParameterDefinition GetParameter(MethodBody body, int index)
		{
			if (body.Method.HasThis)
			{
				if (index == 0)
				{
					return body.Method.This;
				}
				index--;
			}
			return body.Method.Parameters[index];
		}

		public static VariableDefinition GetVariable(MethodBody body, int index)
		{
			return body.Variables[index];
		}

		private void ReadCilBody(MethodBody body, BinaryReader br)
		{
			long position = br.BaseStream.Position;
			Instruction instruction = null;
			m_instructions.Clear();
			InstructionCollection instructions = body.Instructions;
			GenericContext context = new GenericContext(body.Method);
			while (br.BaseStream.Position < position + body.CodeSize)
			{
				long num = br.BaseStream.Position - position;
				int num2 = br.ReadByte();
				OpCode opCode = (num2 != 254) ? OpCodes.OneByteOpCode[num2] : OpCodes.TwoBytesOpCode[br.ReadByte()];
				Instruction instruction2 = new Instruction((int)num, opCode);
				switch (opCode.OperandType)
				{
				case OperandType.InlineSwitch:
				{
					uint num3 = br.ReadUInt32();
					int[] array = new int[num3];
					int[] array2 = new int[num3];
					for (int i = 0; i < num3; i++)
					{
						array2[i] = br.ReadInt32();
					}
					for (int j = 0; j < num3; j++)
					{
						array[j] = Convert.ToInt32(br.BaseStream.Position - position + array2[j]);
					}
					instruction2.Operand = array;
					break;
				}
				case OperandType.ShortInlineBrTarget:
				{
					sbyte b = br.ReadSByte();
					instruction2.Operand = Convert.ToInt32(br.BaseStream.Position - position + b);
					break;
				}
				case OperandType.InlineBrTarget:
				{
					int num4 = br.ReadInt32();
					instruction2.Operand = Convert.ToInt32(br.BaseStream.Position - position + num4);
					break;
				}
				case OperandType.ShortInlineI:
					if (opCode == OpCodes.Ldc_I4_S)
					{
						instruction2.Operand = br.ReadSByte();
					}
					else
					{
						instruction2.Operand = br.ReadByte();
					}
					break;
				case OperandType.ShortInlineVar:
					instruction2.Operand = GetVariable(body, br.ReadByte());
					break;
				case OperandType.ShortInlineParam:
					instruction2.Operand = GetParameter(body, br.ReadByte());
					break;
				case OperandType.InlineSig:
					instruction2.Operand = GetCallSiteAt(br.ReadInt32(), context);
					break;
				case OperandType.InlineI:
					instruction2.Operand = br.ReadInt32();
					break;
				case OperandType.InlineVar:
					instruction2.Operand = GetVariable(body, br.ReadInt16());
					break;
				case OperandType.InlineParam:
					instruction2.Operand = GetParameter(body, br.ReadInt16());
					break;
				case OperandType.InlineI8:
					instruction2.Operand = br.ReadInt64();
					break;
				case OperandType.ShortInlineR:
					instruction2.Operand = br.ReadSingle();
					break;
				case OperandType.InlineR:
					instruction2.Operand = br.ReadDouble();
					break;
				case OperandType.InlineString:
					instruction2.Operand = m_root.Streams.UserStringsHeap[GetRid(br.ReadInt32())];
					break;
				case OperandType.InlineField:
				case OperandType.InlineMethod:
				case OperandType.InlineTok:
				case OperandType.InlineType:
				{
					MetadataToken metadataToken = new MetadataToken(br.ReadInt32());
					switch (metadataToken.TokenType)
					{
					case TokenType.TypeDef:
						instruction2.Operand = m_reflectReader.GetTypeDefAt(metadataToken.RID);
						break;
					case TokenType.TypeRef:
						instruction2.Operand = m_reflectReader.GetTypeRefAt(metadataToken.RID);
						break;
					case TokenType.TypeSpec:
						instruction2.Operand = m_reflectReader.GetTypeSpecAt(metadataToken.RID, context);
						break;
					case TokenType.Field:
						instruction2.Operand = m_reflectReader.GetFieldDefAt(metadataToken.RID);
						break;
					case TokenType.Method:
						instruction2.Operand = m_reflectReader.GetMethodDefAt(metadataToken.RID);
						break;
					case TokenType.MethodSpec:
						instruction2.Operand = m_reflectReader.GetMethodSpecAt(metadataToken.RID, context);
						break;
					case TokenType.MemberRef:
						instruction2.Operand = m_reflectReader.GetMemberRefAt(metadataToken.RID, context);
						break;
					default:
						throw new ReflectionException("Wrong token: " + metadataToken);
					}
					break;
				}
				}
				m_instructions.Add(instruction2.Offset, instruction2);
				if (instruction != null)
				{
					instruction.Next = instruction2;
					instruction2.Previous = instruction;
				}
				instruction = instruction2;
				instructions.Add(instruction2);
			}
			foreach (Instruction item in instructions)
			{
				switch (item.OpCode.OperandType)
				{
				case OperandType.InlineBrTarget:
				case OperandType.ShortInlineBrTarget:
					item.Operand = GetInstruction(body, (int)item.Operand);
					break;
				case OperandType.InlineSwitch:
				{
					int[] array3 = (int[])item.Operand;
					Instruction[] array4 = new Instruction[array3.Length];
					for (int k = 0; k < array3.Length; k++)
					{
						array4[k] = GetInstruction(body, array3[k]);
					}
					item.Operand = array4;
					break;
				}
				}
			}
			if (m_reflectReader.SymbolReader != null)
			{
				m_reflectReader.SymbolReader.Read(body, m_instructions);
			}
		}

		private Instruction GetInstruction(MethodBody body, int offset)
		{
			Instruction instruction = m_instructions[offset] as Instruction;
			if (instruction != null)
			{
				return instruction;
			}
			return body.Instructions.Outside;
		}

		private void ReadSection(MethodBody body, BinaryReader br)
		{
			br.BaseStream.Position += 3L;
			br.BaseStream.Position &= -4L;
			byte b = br.ReadByte();
			if ((b & 0x40) == 0)
			{
				int num = (int)br.ReadByte() / 12;
				br.ReadBytes(2);
				for (int i = 0; i < num; i++)
				{
					ExceptionHandler exceptionHandler = new ExceptionHandler((ExceptionHandlerType)(br.ReadInt16() & 7));
					exceptionHandler.TryStart = GetInstruction(body, Convert.ToInt32(br.ReadInt16()));
					exceptionHandler.TryEnd = GetInstruction(body, exceptionHandler.TryStart.Offset + Convert.ToInt32(br.ReadByte()));
					exceptionHandler.HandlerStart = GetInstruction(body, Convert.ToInt32(br.ReadInt16()));
					exceptionHandler.HandlerEnd = GetInstruction(body, exceptionHandler.HandlerStart.Offset + Convert.ToInt32(br.ReadByte()));
					ReadExceptionHandlerEnd(exceptionHandler, br, body);
					body.ExceptionHandlers.Add(exceptionHandler);
				}
			}
			else
			{
				br.BaseStream.Position--;
				int num2 = (br.ReadInt32() >> 8) / 24;
				if ((b & 1) == 0)
				{
					br.ReadBytes(num2 * 24);
				}
				for (int j = 0; j < num2; j++)
				{
					ExceptionHandler exceptionHandler2 = new ExceptionHandler((ExceptionHandlerType)(br.ReadInt32() & 7));
					exceptionHandler2.TryStart = GetInstruction(body, br.ReadInt32());
					exceptionHandler2.TryEnd = GetInstruction(body, exceptionHandler2.TryStart.Offset + br.ReadInt32());
					exceptionHandler2.HandlerStart = GetInstruction(body, br.ReadInt32());
					exceptionHandler2.HandlerEnd = GetInstruction(body, exceptionHandler2.HandlerStart.Offset + br.ReadInt32());
					ReadExceptionHandlerEnd(exceptionHandler2, br, body);
					body.ExceptionHandlers.Add(exceptionHandler2);
				}
			}
			if ((b & 0x80) != 0)
			{
				ReadSection(body, br);
			}
		}

		private void ReadExceptionHandlerEnd(ExceptionHandler eh, BinaryReader br, MethodBody body)
		{
			switch (eh.Type)
			{
			case ExceptionHandlerType.Catch:
			{
				MetadataToken token = new MetadataToken(br.ReadInt32());
				eh.CatchType = m_reflectReader.GetTypeDefOrRef(token, new GenericContext(body.Method));
				break;
			}
			case ExceptionHandlerType.Filter:
				eh.FilterStart = GetInstruction(body, br.ReadInt32());
				eh.FilterEnd = GetInstruction(body, eh.HandlerStart.Previous.Offset);
				break;
			default:
				br.ReadInt32();
				break;
			}
		}

		private CallSite GetCallSiteAt(int token, GenericContext context)
		{
			StandAloneSigTable standAloneSigTable = m_reflectReader.TableReader.GetStandAloneSigTable();
			MethodSig standAloneMethodSig = m_reflectReader.SigReader.GetStandAloneMethodSig(standAloneSigTable[(int)(GetRid(token) - 1)].Signature);
			CallSite callSite = new CallSite(standAloneMethodSig.HasThis, standAloneMethodSig.ExplicitThis, standAloneMethodSig.MethCallConv, m_reflectReader.GetMethodReturnType(standAloneMethodSig, context));
			callSite.MetadataToken = new MetadataToken(token);
			for (int i = 0; i < standAloneMethodSig.ParamCount; i++)
			{
				Param psig = standAloneMethodSig.Parameters[i];
				callSite.Parameters.Add(m_reflectReader.BuildParameterDefinition(i, psig, context));
			}
			ReflectionReader.CreateSentinelIfNeeded(callSite, standAloneMethodSig);
			return callSite;
		}

		public override void VisitVariableDefinitionCollection(VariableDefinitionCollection variables)
		{
			MethodBody methodBody = variables.Container as MethodBody;
			if (methodBody == null || methodBody.LocalVarToken == 0)
			{
				return;
			}
			StandAloneSigTable standAloneSigTable = m_reflectReader.TableReader.GetStandAloneSigTable();
			StandAloneSigRow standAloneSigRow = standAloneSigTable[(int)(GetRid(methodBody.LocalVarToken) - 1)];
			LocalVarSig localVarSig = m_reflectReader.SigReader.GetLocalVarSig(standAloneSigRow.Signature);
			for (int i = 0; i < localVarSig.Count; i++)
			{
				LocalVarSig.LocalVariable localVariable = localVarSig.LocalVariables[i];
				TypeReference typeReference = m_reflectReader.GetTypeRefFromSig(localVariable.Type, new GenericContext(methodBody.Method));
				if (localVariable.ByRef)
				{
					typeReference = new ReferenceType(typeReference);
				}
				if ((localVariable.Constraint & Constraint.Pinned) != 0)
				{
					typeReference = new PinnedType(typeReference);
				}
				typeReference = m_reflectReader.GetModifierType(localVariable.CustomMods, typeReference);
				methodBody.Variables.Add(new VariableDefinition("V_" + i, i, methodBody.Method, typeReference));
			}
		}
	}
}
