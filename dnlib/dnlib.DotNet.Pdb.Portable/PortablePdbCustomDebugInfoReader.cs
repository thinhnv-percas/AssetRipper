#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using dnlib.DotNet.Emit;
using dnlib.DotNet.MD;
using dnlib.IO;

namespace dnlib.DotNet.Pdb.Portable;

internal struct PortablePdbCustomDebugInfoReader
{
	private readonly ModuleDef module;

	private readonly TypeDef typeOpt;

	private readonly CilBody bodyOpt;

	private readonly GenericParamContext gpContext;

	private DataReader reader;

	public static PdbCustomDebugInfo Read(ModuleDef module, TypeDef typeOpt, CilBody bodyOpt, GenericParamContext gpContext, Guid kind, ref DataReader reader)
	{
		try
		{
			PortablePdbCustomDebugInfoReader portablePdbCustomDebugInfoReader = new PortablePdbCustomDebugInfoReader(module, typeOpt, bodyOpt, gpContext, ref reader);
			PdbCustomDebugInfo result = portablePdbCustomDebugInfoReader.Read(kind);
			Debug.Assert(portablePdbCustomDebugInfoReader.reader.Position == portablePdbCustomDebugInfoReader.reader.Length);
			return result;
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
		return null;
	}

	private PortablePdbCustomDebugInfoReader(ModuleDef module, TypeDef typeOpt, CilBody bodyOpt, GenericParamContext gpContext, ref DataReader reader)
	{
		this.module = module;
		this.typeOpt = typeOpt;
		this.bodyOpt = bodyOpt;
		this.gpContext = gpContext;
		this.reader = reader;
	}

	private PdbCustomDebugInfo Read(Guid kind)
	{
		if (kind == CustomDebugInfoGuids.AsyncMethodSteppingInformationBlob)
		{
			return ReadAsyncMethodSteppingInformationBlob();
		}
		if (kind == CustomDebugInfoGuids.DefaultNamespace)
		{
			return ReadDefaultNamespace();
		}
		if (kind == CustomDebugInfoGuids.DynamicLocalVariables)
		{
			return ReadDynamicLocalVariables(reader.Length);
		}
		if (kind == CustomDebugInfoGuids.EmbeddedSource)
		{
			return ReadEmbeddedSource();
		}
		if (kind == CustomDebugInfoGuids.EncLambdaAndClosureMap)
		{
			return ReadEncLambdaAndClosureMap(reader.Length);
		}
		if (kind == CustomDebugInfoGuids.EncLocalSlotMap)
		{
			return ReadEncLocalSlotMap(reader.Length);
		}
		if (kind == CustomDebugInfoGuids.SourceLink)
		{
			return ReadSourceLink();
		}
		if (kind == CustomDebugInfoGuids.StateMachineHoistedLocalScopes)
		{
			return ReadStateMachineHoistedLocalScopes();
		}
		if (kind == CustomDebugInfoGuids.TupleElementNames)
		{
			return ReadTupleElementNames();
		}
		Debug.Fail("Unknown custom debug info guid: " + kind.ToString());
		return new PdbUnknownCustomDebugInfo(kind, reader.ReadRemainingBytes());
	}

	private PdbCustomDebugInfo ReadAsyncMethodSteppingInformationBlob()
	{
		if (bodyOpt == null)
		{
			return null;
		}
		uint num = reader.ReadUInt32() - 1;
		Instruction instruction;
		if (num == uint.MaxValue)
		{
			instruction = null;
		}
		else
		{
			instruction = GetInstruction(num);
			Debug.Assert(instruction != null);
			if (instruction == null)
			{
				return null;
			}
		}
		PdbAsyncMethodSteppingInformationCustomDebugInfo pdbAsyncMethodSteppingInformationCustomDebugInfo = new PdbAsyncMethodSteppingInformationCustomDebugInfo();
		pdbAsyncMethodSteppingInformationCustomDebugInfo.CatchHandler = instruction;
		while (reader.Position < reader.Length)
		{
			Instruction instruction2 = GetInstruction(reader.ReadUInt32());
			Debug.Assert(instruction2 != null);
			if (instruction2 == null)
			{
				return null;
			}
			uint offset = reader.ReadUInt32();
			uint rid = reader.ReadCompressedUInt32();
			MDToken mDToken = new MDToken(Table.Method, rid);
			MethodDef methodDef;
			Instruction instruction3;
			if (gpContext.Method != null && mDToken == gpContext.Method.MDToken)
			{
				methodDef = gpContext.Method;
				instruction3 = GetInstruction(offset);
			}
			else
			{
				methodDef = module.ResolveToken(mDToken, gpContext) as MethodDef;
				Debug.Assert(methodDef != null);
				if (methodDef == null)
				{
					return null;
				}
				instruction3 = GetInstruction(methodDef, offset);
			}
			Debug.Assert(instruction3 != null);
			if (instruction3 == null)
			{
				return null;
			}
			pdbAsyncMethodSteppingInformationCustomDebugInfo.AsyncStepInfos.Add(new PdbAsyncStepInfo(instruction2, methodDef, instruction3));
		}
		return pdbAsyncMethodSteppingInformationCustomDebugInfo;
	}

	private PdbCustomDebugInfo ReadDefaultNamespace()
	{
		string defaultNamespace = reader.ReadUtf8String((int)reader.BytesLeft);
		return new PdbDefaultNamespaceCustomDebugInfo(defaultNamespace);
	}

	private PdbCustomDebugInfo ReadDynamicLocalVariables(long recPosEnd)
	{
		bool[] array = new bool[reader.Length * 8];
		int num = 0;
		while (reader.Position < reader.Length)
		{
			int num2 = reader.ReadByte();
			for (int num3 = 1; num3 < 256; num3 <<= 1)
			{
				array[num++] = (num2 & num3) != 0;
			}
		}
		return new PdbDynamicLocalVariablesCustomDebugInfo(array);
	}

	private PdbCustomDebugInfo ReadEmbeddedSource()
	{
		return new PdbEmbeddedSourceCustomDebugInfo(reader.ReadRemainingBytes());
	}

	private PdbCustomDebugInfo ReadEncLambdaAndClosureMap(long recPosEnd)
	{
		byte[] data = reader.ReadBytes((int)(recPosEnd - reader.Position));
		return new PdbEditAndContinueLambdaMapCustomDebugInfo(data);
	}

	private PdbCustomDebugInfo ReadEncLocalSlotMap(long recPosEnd)
	{
		byte[] data = reader.ReadBytes((int)(recPosEnd - reader.Position));
		return new PdbEditAndContinueLocalSlotMapCustomDebugInfo(data);
	}

	private PdbCustomDebugInfo ReadSourceLink()
	{
		return new PdbSourceLinkCustomDebugInfo(reader.ReadRemainingBytes());
	}

	private PdbCustomDebugInfo ReadStateMachineHoistedLocalScopes()
	{
		if (bodyOpt == null)
		{
			return null;
		}
		int num = (int)(reader.Length / 8);
		PdbStateMachineHoistedLocalScopesCustomDebugInfo pdbStateMachineHoistedLocalScopesCustomDebugInfo = new PdbStateMachineHoistedLocalScopesCustomDebugInfo(num);
		for (int i = 0; i < num; i++)
		{
			uint num2 = reader.ReadUInt32();
			uint num3 = reader.ReadUInt32();
			if (num2 == 0 && num3 == 0)
			{
				pdbStateMachineHoistedLocalScopesCustomDebugInfo.Scopes.Add(default(StateMachineHoistedLocalScope));
				continue;
			}
			Instruction instruction = GetInstruction(num2);
			Instruction instruction2 = GetInstruction(num2 + num3);
			Debug.Assert(instruction != null);
			if (instruction == null)
			{
				return null;
			}
			pdbStateMachineHoistedLocalScopesCustomDebugInfo.Scopes.Add(new StateMachineHoistedLocalScope(instruction, instruction2));
		}
		return pdbStateMachineHoistedLocalScopesCustomDebugInfo;
	}

	private PdbCustomDebugInfo ReadTupleElementNames()
	{
		PortablePdbTupleElementNamesCustomDebugInfo portablePdbTupleElementNamesCustomDebugInfo = new PortablePdbTupleElementNamesCustomDebugInfo();
		while (reader.Position < reader.Length)
		{
			string item = ReadUTF8Z(reader.Length);
			portablePdbTupleElementNamesCustomDebugInfo.Names.Add(item);
		}
		return portablePdbTupleElementNamesCustomDebugInfo;
	}

	private string ReadUTF8Z(long recPosEnd)
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

	private static Instruction GetInstruction(MethodDef method, uint offset)
	{
		if (method == null)
		{
			return null;
		}
		CilBody body = method.Body;
		if (body == null)
		{
			return null;
		}
		IList<Instruction> instructions = body.Instructions;
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
