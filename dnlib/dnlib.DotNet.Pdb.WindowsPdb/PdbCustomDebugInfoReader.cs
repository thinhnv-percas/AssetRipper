#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using dnlib.DotNet.Emit;
using dnlib.IO;

namespace dnlib.DotNet.Pdb.WindowsPdb;

internal struct PdbCustomDebugInfoReader
{
	private readonly ModuleDef module;

	private readonly TypeDef typeOpt;

	private readonly CilBody bodyOpt;

	private readonly GenericParamContext gpContext;

	private DataReader reader;

	public static void Read(MethodDef method, CilBody body, IList<PdbCustomDebugInfo> result, byte[] data)
	{
		try
		{
			DataReader dataReader = ByteArrayDataReaderFactory.CreateReader(data);
			new PdbCustomDebugInfoReader(method, body, ref dataReader).Read(result);
		}
		catch (ArgumentException)
		{
		}
		catch (OutOfMemoryException)
		{
		}
		catch (IOException)
		{
		}
	}

	private PdbCustomDebugInfoReader(MethodDef method, CilBody body, ref DataReader reader)
	{
		module = method.Module;
		typeOpt = method.DeclaringType;
		bodyOpt = body;
		gpContext = GenericParamContext.Create(method);
		this.reader = reader;
	}

	private void Read(IList<PdbCustomDebugInfo> result)
	{
		if (reader.Length < 4)
		{
			return;
		}
		int num = reader.ReadByte();
		Debug.Assert(num == 4);
		if (num != 4)
		{
			return;
		}
		int num2 = reader.ReadByte();
		reader.Position += 2u;
		while (reader.CanRead(8u))
		{
			int num3 = reader.ReadByte();
			Debug.Assert(num3 == 4);
			PdbCustomDebugInfoKind pdbCustomDebugInfoKind = (PdbCustomDebugInfoKind)reader.ReadByte();
			reader.Position++;
			int num4 = reader.ReadByte();
			int num5 = reader.ReadInt32();
			if (num5 < 8 || (ulong)((long)reader.Position - 8L + (uint)num5) > (ulong)reader.Length)
			{
				break;
			}
			if (pdbCustomDebugInfoKind <= PdbCustomDebugInfoKind.DynamicLocals)
			{
				num4 = 0;
			}
			if (num4 > 3)
			{
				break;
			}
			uint position = reader.Position - 8 + (uint)num5;
			if (num3 == 4)
			{
				ulong num6 = (ulong)((long)reader.Position - 8L + (uint)num5 - (uint)num4);
				PdbCustomDebugInfo pdbCustomDebugInfo = ReadRecord(pdbCustomDebugInfoKind, num6);
				Debug.Assert(pdbCustomDebugInfo != null);
				Debug.Assert(reader.Position <= num6);
				if (reader.Position > num6)
				{
					break;
				}
				if (pdbCustomDebugInfo != null)
				{
					Debug.Assert(pdbCustomDebugInfo.Kind == pdbCustomDebugInfoKind);
					result.Add(pdbCustomDebugInfo);
				}
			}
			reader.Position = position;
		}
	}

	private PdbCustomDebugInfo ReadRecord(PdbCustomDebugInfoKind recKind, ulong recPosEnd)
	{
		switch (recKind)
		{
		case PdbCustomDebugInfoKind.UsingGroups:
		{
			int num2 = reader.ReadUInt16();
			if (num2 < 0)
			{
				return null;
			}
			PdbUsingGroupsCustomDebugInfo pdbUsingGroupsCustomDebugInfo = new PdbUsingGroupsCustomDebugInfo(num2);
			for (int m = 0; m < num2; m++)
			{
				pdbUsingGroupsCustomDebugInfo.UsingCounts.Add(reader.ReadUInt16());
			}
			return pdbUsingGroupsCustomDebugInfo;
		}
		case PdbCustomDebugInfoKind.ForwardMethodInfo:
			if (!(module.ResolveToken(reader.ReadUInt32(), gpContext) is IMethodDefOrRef method2))
			{
				return null;
			}
			return new PdbForwardMethodInfoCustomDebugInfo(method2);
		case PdbCustomDebugInfoKind.ForwardModuleInfo:
			if (!(module.ResolveToken(reader.ReadUInt32(), gpContext) is IMethodDefOrRef method))
			{
				return null;
			}
			return new PdbForwardModuleInfoCustomDebugInfo(method);
		case PdbCustomDebugInfoKind.StateMachineHoistedLocalScopes:
		{
			if (bodyOpt == null)
			{
				return null;
			}
			int num2 = reader.ReadInt32();
			if (num2 < 0)
			{
				return null;
			}
			PdbStateMachineHoistedLocalScopesCustomDebugInfo pdbStateMachineHoistedLocalScopesCustomDebugInfo = new PdbStateMachineHoistedLocalScopesCustomDebugInfo(num2);
			for (int n = 0; n < num2; n++)
			{
				uint num9 = reader.ReadUInt32();
				uint num10 = reader.ReadUInt32();
				if (num9 > num10)
				{
					return null;
				}
				if (num10 == 0)
				{
					pdbStateMachineHoistedLocalScopesCustomDebugInfo.Scopes.Add(default(StateMachineHoistedLocalScope));
					continue;
				}
				Instruction instruction = GetInstruction(num9);
				Instruction instruction2 = GetInstruction(num10 + 1);
				if (instruction == null)
				{
					return null;
				}
				pdbStateMachineHoistedLocalScopesCustomDebugInfo.Scopes.Add(new StateMachineHoistedLocalScope(instruction, instruction2));
			}
			return pdbStateMachineHoistedLocalScopesCustomDebugInfo;
		}
		case PdbCustomDebugInfoKind.StateMachineTypeName:
		{
			string text2 = ReadUnicodeZ(recPosEnd, needZeroChar: true);
			if (text2 == null)
			{
				return null;
			}
			TypeDef nestedType = GetNestedType(text2);
			if (nestedType == null)
			{
				return null;
			}
			return new PdbStateMachineTypeNameCustomDebugInfo(nestedType);
		}
		case PdbCustomDebugInfoKind.DynamicLocals:
		{
			if (bodyOpt == null)
			{
				return null;
			}
			int num2 = reader.ReadInt32();
			if ((ulong)(reader.Position + (long)(uint)num2 * 200L) > recPosEnd)
			{
				return null;
			}
			PdbDynamicLocalsCustomDebugInfo pdbDynamicLocalsCustomDebugInfo = new PdbDynamicLocalsCustomDebugInfo(num2);
			for (int k = 0; k < num2; k++)
			{
				reader.Position += 64u;
				int num7 = reader.ReadInt32();
				if ((uint)num7 > 64u)
				{
					return null;
				}
				PdbDynamicLocal pdbDynamicLocal = new PdbDynamicLocal(num7);
				uint position = reader.Position;
				reader.Position -= 68u;
				for (int l = 0; l < num7; l++)
				{
					pdbDynamicLocal.Flags.Add(reader.ReadByte());
				}
				reader.Position = position;
				int num4 = reader.ReadInt32();
				if (num4 != 0 && (uint)num4 >= (uint)bodyOpt.Variables.Count)
				{
					return null;
				}
				uint num8 = reader.Position + 128;
				string text2 = ReadUnicodeZ(num8, needZeroChar: false);
				reader.Position = num8;
				Local local = ((num4 < bodyOpt.Variables.Count) ? bodyOpt.Variables[num4] : null);
				if (num4 == 0 && local != null && local.Name != text2)
				{
					local = null;
				}
				if (local != null && local.Name == text2)
				{
					text2 = null;
				}
				pdbDynamicLocal.Name = text2;
				pdbDynamicLocal.Local = local;
				pdbDynamicLocalsCustomDebugInfo.Locals.Add(pdbDynamicLocal);
			}
			return pdbDynamicLocalsCustomDebugInfo;
		}
		case PdbCustomDebugInfoKind.EditAndContinueLocalSlotMap:
		{
			byte[] data = reader.ReadBytes((int)(recPosEnd - reader.Position));
			return new PdbEditAndContinueLocalSlotMapCustomDebugInfo(data);
		}
		case PdbCustomDebugInfoKind.EditAndContinueLambdaMap:
		{
			byte[] data = reader.ReadBytes((int)(recPosEnd - reader.Position));
			return new PdbEditAndContinueLambdaMapCustomDebugInfo(data);
		}
		case PdbCustomDebugInfoKind.TupleElementNames:
		{
			if (bodyOpt == null)
			{
				return null;
			}
			int num2 = reader.ReadInt32();
			if (num2 < 0)
			{
				return null;
			}
			PdbTupleElementNamesCustomDebugInfo pdbTupleElementNamesCustomDebugInfo = new PdbTupleElementNamesCustomDebugInfo(num2);
			for (int i = 0; i < num2; i++)
			{
				int num3 = reader.ReadInt32();
				if ((uint)num3 >= 10000u)
				{
					return null;
				}
				PdbTupleElementNames pdbTupleElementNames = new PdbTupleElementNames(num3);
				for (int j = 0; j < num3; j++)
				{
					string text = ReadUTF8Z(recPosEnd);
					if (text == null)
					{
						return null;
					}
					pdbTupleElementNames.TupleElementNames.Add(text);
				}
				int num4 = reader.ReadInt32();
				uint num5 = reader.ReadUInt32();
				uint num6 = reader.ReadUInt32();
				string text2 = ReadUTF8Z(recPosEnd);
				if (text2 == null)
				{
					return null;
				}
				Debug.Assert(num4 >= -1);
				Debug.Assert((num4 == -1) ^ (num5 == 0 && num6 == 0));
				Local local;
				if (num4 == -1)
				{
					local = null;
					pdbTupleElementNames.ScopeStart = GetInstruction(num5);
					pdbTupleElementNames.ScopeEnd = GetInstruction(num6);
					if (pdbTupleElementNames.ScopeStart == null)
					{
						return null;
					}
				}
				else
				{
					if ((uint)num4 >= (uint)bodyOpt.Variables.Count)
					{
						return null;
					}
					local = bodyOpt.Variables[num4];
				}
				if (local != null && local.Name == text2)
				{
					text2 = null;
				}
				pdbTupleElementNames.Local = local;
				pdbTupleElementNames.Name = text2;
				pdbTupleElementNamesCustomDebugInfo.Names.Add(pdbTupleElementNames);
			}
			return pdbTupleElementNamesCustomDebugInfo;
		}
		default:
		{
			int num = (int)recKind;
			Debug.Fail("Unknown custom debug info kind: 0x" + num.ToString("X"));
			byte[] data = reader.ReadBytes((int)(recPosEnd - reader.Position));
			return new PdbUnknownCustomDebugInfo(recKind, data);
		}
		}
	}

	private TypeDef GetNestedType(string name)
	{
		if (typeOpt == null)
		{
			return null;
		}
		IList<TypeDef> nestedTypes = typeOpt.NestedTypes;
		int count = nestedTypes.Count;
		for (int i = 0; i < count; i++)
		{
			TypeDef typeDef = nestedTypes[i];
			if (!UTF8String.IsNullOrEmpty(typeDef.Namespace))
			{
				continue;
			}
			if (typeDef.Name == name)
			{
				return typeDef;
			}
			string text = typeDef.Name.String;
			if (!text.StartsWith(name) || text.Length < name.Length + 2)
			{
				continue;
			}
			int length = name.Length;
			if (text[length] != '`')
			{
				continue;
			}
			Debug.Assert(length + 1 < text.Length);
			bool flag = true;
			for (length++; length < text.Length; length++)
			{
				if (!char.IsDigit(text[length]))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return typeDef;
			}
		}
		return null;
	}

	private string ReadUnicodeZ(ulong recPosEnd, bool needZeroChar)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (true)
		{
			if (reader.Position >= recPosEnd)
			{
				return needZeroChar ? null : stringBuilder.ToString();
			}
			char c = reader.ReadChar();
			if (c == '\0')
			{
				break;
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	private string ReadUTF8Z(ulong recPosEnd)
	{
		if (reader.Position > recPosEnd)
		{
			return null;
		}
		return reader.TryReadZeroTerminatedUtf8String();
	}

	private Instruction GetInstruction(uint offset)
	{
		IList<Instruction> instructions = bodyOpt.Instructions;
		int num = 0;
		int num2 = instructions.Count - 1;
		while (num <= num2 && num2 != -1)
		{
			int num3 = (num + num2) / 2;
			Instruction instruction = instructions[num3];
			if (instruction.Offset == offset)
			{
				return instruction;
			}
			if (offset < instruction.Offset)
			{
				num2 = num3 - 1;
			}
			else
			{
				num = num3 + 1;
			}
		}
		return null;
	}
}
