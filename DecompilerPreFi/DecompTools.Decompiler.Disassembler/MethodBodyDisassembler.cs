using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.Disassembler;

public class MethodBodyDisassembler
{
	private readonly ITextOutput output;

	private readonly CancellationToken cancellationToken;

	private IList<DecompTools.Decompiler.DebugInfo.SequencePoint> sequencePoints;

	private int nextSequencePointIndex;

	private PEFile module;

	private MetadataReader metadata;

	private GenericContext genericContext;

	private DisassemblerSignatureProvider signatureDecoder;

	public bool DetectControlStructure { get; set; } = true;

	public bool ShowSequencePoints { get; set; }

	public bool ShowMetadataTokens { get; set; }

	public bool ShowMetadataTokensInBase10 { get; set; }

	public IDebugInfoProvider DebugInfo { get; set; }

	public MethodBodyDisassembler(ITextOutput output, CancellationToken cancellationToken)
	{
		this.output = output ?? throw new ArgumentNullException("output");
		this.cancellationToken = cancellationToken;
	}

	public virtual void Disassemble(PEFile module, MethodDefinitionHandle handle)
	{
		this.module = module ?? throw new ArgumentNullException("module");
		metadata = module.Metadata;
		genericContext = new GenericContext(handle, module);
		signatureDecoder = new DisassemblerSignatureProvider(module, output);
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
		output.WriteLine("// Method begins at RVA 0x{0:x4}", methodDefinition.RelativeVirtualAddress);
		if (methodDefinition.RelativeVirtualAddress == 0)
		{
			output.WriteLine("// Code size {0} (0x{0:x})", 0);
			output.WriteLine(".maxstack {0}", 0);
			output.WriteLine();
			return;
		}
		MethodBodyBlock methodBody;
		try
		{
			methodBody = module.Reader.GetMethodBody(methodDefinition.RelativeVirtualAddress);
		}
		catch (BadImageFormatException ex)
		{
			output.WriteLine("// {0}", ex.Message);
			return;
		}
		BlobReader blob = methodBody.GetILReader();
		output.WriteLine("// Code size {0} (0x{0:x})", blob.Length);
		output.WriteLine(".maxstack {0}", methodBody.MaxStack);
		MethodDefinitionHandle methodDefinitionHandle = MetadataTokens.MethodDefinitionHandle(module.Reader.PEHeaders.CorHeader.EntryPointTokenOrRelativeVirtualAddress);
		if (handle == methodDefinitionHandle)
		{
			output.WriteLine(".entrypoint");
		}
		DisassembleLocalsBlock(handle, methodBody);
		output.WriteLine();
		sequencePoints = DebugInfo?.GetSequencePoints(handle) ?? EmptyList<DecompTools.Decompiler.DebugInfo.SequencePoint>.Instance;
		nextSequencePointIndex = 0;
		if (DetectControlStructure && blob.Length > 0)
		{
			blob.Reset();
			HashSet<int> branchTargets = GetBranchTargets(blob);
			blob.Reset();
			WriteStructureBody(new ILStructure(module, handle, genericContext, methodBody), branchTargets, ref blob);
		}
		else
		{
			while (blob.RemainingBytes > 0)
			{
				WriteInstruction(output, metadata, handle, ref blob);
			}
			WriteExceptionHandlers(module, handle, methodBody);
		}
		sequencePoints = null;
	}

	private void DisassembleLocalsBlock(MethodDefinitionHandle method, MethodBodyBlock body)
	{
		if (body.LocalSignature.IsNil)
		{
			return;
		}
		output.Write(".locals");
		WriteMetadataToken(body.LocalSignature, spaceBefore: true);
		if (body.LocalVariablesInitialized)
		{
			output.Write(" init");
		}
		StandaloneSignature standaloneSignature = metadata.GetStandaloneSignature(body.LocalSignature);
		ImmutableArray<Action<ILNameSyntax>> immutableArray = ImmutableArray<Action<ILNameSyntax>>.Empty;
		try
		{
			if (standaloneSignature.GetKind() == StandaloneSignatureKind.LocalVariables)
			{
				immutableArray = standaloneSignature.DecodeLocalSignature(signatureDecoder, genericContext);
			}
			else
			{
				output.Write(" /* wrong signature kind */");
			}
		}
		catch (BadImageFormatException ex)
		{
			output.Write(" /* " + ex.Message + " */");
		}
		output.Write(' ');
		output.WriteLine("(");
		output.Indent();
		int num = 0;
		checked
		{
			foreach (Action<ILNameSyntax> item in immutableArray)
			{
				output.WriteLocalReference("[" + num + "] ", item, isDefinition: true);
				item(ILNameSyntax.TypeName);
				if (DebugInfo != null && DebugInfo.TryGetName(method, num, out var name))
				{
					output.Write(" " + DisassemblerHelpers.Escape(name));
				}
				if (num + 1 < immutableArray.Length)
				{
					output.Write(',');
				}
				output.WriteLine();
				num++;
			}
			output.Unindent();
			output.WriteLine(")");
		}
	}

	internal void WriteExceptionHandlers(PEFile module, MethodDefinitionHandle handle, MethodBodyBlock body)
	{
		this.module = module;
		metadata = module.Metadata;
		genericContext = new GenericContext(handle, module);
		signatureDecoder = new DisassemblerSignatureProvider(module, output);
		ImmutableArray<ExceptionRegion> exceptionRegions = body.ExceptionRegions;
		if (!exceptionRegions.IsEmpty)
		{
			output.WriteLine();
			foreach (ExceptionRegion item in exceptionRegions)
			{
				item.WriteTo(module, genericContext, output);
				output.WriteLine();
			}
		}
	}

	private HashSet<int> GetBranchTargets(BlobReader blob)
	{
		HashSet<int> val = new HashSet<int>();
		while (blob.RemainingBytes > 0)
		{
			ILOpCode iLOpCode = blob.DecodeOpCode();
			if (iLOpCode == ILOpCode.Switch)
			{
				val.UnionWith((IEnumerable<int>)blob.DecodeSwitchTargets());
			}
			else if (iLOpCode.IsBranch())
			{
				val.Add(blob.DecodeBranchTarget(iLOpCode));
			}
			else
			{
				blob.SkipOperand(iLOpCode);
			}
		}
		return val;
	}

	private void WriteStructureHeader(ILStructure s)
	{
		switch (s.Type)
		{
		case ILStructureType.Loop:
			output.Write("// loop start");
			if (s.LoopEntryPointOffset >= 0)
			{
				output.Write(" (head: ");
				DisassemblerHelpers.WriteOffsetReference(output, s.LoopEntryPointOffset);
				output.Write(')');
			}
			output.WriteLine();
			break;
		case ILStructureType.Try:
			output.WriteLine(".try");
			output.WriteLine("{");
			break;
		case ILStructureType.Handler:
			switch (s.ExceptionHandler.Kind)
			{
			case ExceptionRegionKind.Catch:
			case ExceptionRegionKind.Filter:
				output.Write("catch");
				if (!s.ExceptionHandler.CatchType.IsNil)
				{
					output.Write(' ');
					s.ExceptionHandler.CatchType.WriteTo(s.Module, output, s.GenericContext, ILNameSyntax.TypeName);
				}
				output.WriteLine();
				break;
			case ExceptionRegionKind.Finally:
				output.WriteLine("finally");
				break;
			case ExceptionRegionKind.Fault:
				output.WriteLine("fault");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			output.WriteLine("{");
			break;
		case ILStructureType.Filter:
			output.WriteLine("filter");
			output.WriteLine("{");
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		output.Indent();
	}

	private void WriteStructureBody(ILStructure s, HashSet<int> branchTargets, ref BlobReader body)
	{
		bool flag = true;
		bool flag2 = false;
		int num = 0;
		while (body.RemainingBytes > 0 && body.Offset < s.EndOffset)
		{
			int offset = body.Offset;
			if (num < s.Children.Count && s.Children[num].StartOffset <= offset && offset < s.Children[num].EndOffset)
			{
				ILStructure s2 = s.Children[checked(num++)];
				WriteStructureHeader(s2);
				WriteStructureBody(s2, branchTargets, ref body);
				WriteStructureFooter(s2);
			}
			else
			{
				if (!flag && (flag2 || branchTargets.Contains(offset)))
				{
					output.WriteLine();
				}
				ILOpCode iLOpCode = body.DecodeOpCode();
				body.Offset = offset;
				WriteInstruction(output, metadata, s.MethodHandle, ref body);
				flag2 = iLOpCode.IsBranch() || iLOpCode.IsReturn() || iLOpCode == ILOpCode.Throw || iLOpCode == ILOpCode.Rethrow || iLOpCode == ILOpCode.Switch;
			}
			flag = false;
		}
	}

	private void WriteStructureFooter(ILStructure s)
	{
		output.Unindent();
		switch (s.Type)
		{
		case ILStructureType.Loop:
			output.WriteLine("// end loop");
			break;
		case ILStructureType.Try:
			output.WriteLine("} // end .try");
			break;
		case ILStructureType.Handler:
			output.WriteLine("} // end handler");
			break;
		case ILStructureType.Filter:
			output.WriteLine("} // end filter");
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	protected virtual void WriteInstruction(ITextOutput output, MetadataReader metadata, MethodDefinitionHandle methodDefinition, ref BlobReader blob)
	{
		int offset = blob.Offset;
		checked
		{
			if (ShowSequencePoints && nextSequencePointIndex < sequencePoints?.Count)
			{
				DecompTools.Decompiler.DebugInfo.SequencePoint sequencePoint = sequencePoints[nextSequencePointIndex];
				if (sequencePoint.Offset <= offset)
				{
					output.Write("// sequence point: ");
					if (sequencePoint.Offset != offset)
					{
						output.Write("!! at " + DisassemblerHelpers.OffsetToString(sequencePoint.Offset) + " !!");
					}
					if (sequencePoint.IsHidden)
					{
						output.WriteLine("hidden");
					}
					else
					{
						output.WriteLine($"(line {sequencePoint.StartLine}, col {sequencePoint.StartColumn}) to (line {sequencePoint.EndLine}, col {sequencePoint.EndColumn}) in {sequencePoint.DocumentUrl}");
					}
					nextSequencePointIndex++;
				}
			}
			ILOpCode iLOpCode = blob.DecodeOpCode();
			output.WriteLocalReference(DisassemblerHelpers.OffsetToString(offset), offset, isDefinition: true);
			output.Write(": ");
			if (iLOpCode.IsDefined())
			{
				output.WriteReference(new OpCodeInfo(iLOpCode, iLOpCode.GetDisplayName()));
				switch (iLOpCode.GetOperandType())
				{
				case OperandType.BrTarget:
				case OperandType.ShortBrTarget:
				{
					output.Write(' ');
					int num3 = blob.DecodeBranchTarget(iLOpCode);
					output.WriteLocalReference($"IL_{num3:x4}", num3);
					break;
				}
				case OperandType.Field:
				case OperandType.Method:
				case OperandType.Sig:
				case OperandType.Type:
				{
					output.Write(' ');
					int num2 = blob.ReadInt32();
					EntityHandle? entityHandle = MetadataTokenHelpers.TryAsEntityHandle(num2);
					try
					{
						entityHandle?.WriteTo(module, output, genericContext);
					}
					catch (BadImageFormatException)
					{
						entityHandle = null;
					}
					WriteMetadataToken(entityHandle, num2, spaceBefore: true);
					break;
				}
				case OperandType.Tok:
				{
					output.Write(' ');
					int num2 = blob.ReadInt32();
					EntityHandle? entityHandle = MetadataTokenHelpers.TryAsEntityHandle(num2);
					switch (entityHandle?.Kind)
					{
					case HandleKind.MemberReference:
						switch (metadata.GetMemberReference((MemberReferenceHandle)entityHandle.Value).GetKind())
						{
						case MemberReferenceKind.Method:
							output.Write("method ");
							break;
						case MemberReferenceKind.Field:
							output.Write("field ");
							break;
						}
						break;
					case HandleKind.FieldDefinition:
						output.Write("field ");
						break;
					case HandleKind.MethodDefinition:
						output.Write("method ");
						break;
					}
					try
					{
						entityHandle?.WriteTo(module, output, genericContext);
					}
					catch (BadImageFormatException)
					{
						entityHandle = null;
					}
					WriteMetadataToken(entityHandle, num2, spaceBefore: true);
					break;
				}
				case OperandType.ShortI:
					output.Write(' ');
					DisassemblerHelpers.WriteOperand(output, blob.ReadSByte());
					break;
				case OperandType.I:
					output.Write(' ');
					DisassemblerHelpers.WriteOperand(output, blob.ReadInt32());
					break;
				case OperandType.I8:
					output.Write(' ');
					DisassemblerHelpers.WriteOperand(output, blob.ReadInt64());
					break;
				case OperandType.ShortR:
					output.Write(' ');
					DisassemblerHelpers.WriteOperand(output, blob.ReadSingle());
					break;
				case OperandType.R:
					output.Write(' ');
					DisassemblerHelpers.WriteOperand(output, blob.ReadDouble());
					break;
				case OperandType.String:
				{
					int num2 = blob.ReadInt32();
					output.Write(' ');
					UserStringHandle? userStringHandle;
					string operand;
					try
					{
						userStringHandle = MetadataTokens.UserStringHandle(num2);
						operand = metadata.GetUserString(userStringHandle.Value);
					}
					catch (BadImageFormatException)
					{
						userStringHandle = null;
						operand = null;
					}
					if (userStringHandle.HasValue)
					{
						DisassemblerHelpers.WriteOperand(output, operand);
					}
					WriteMetadataToken(userStringHandle, num2, spaceBefore: true);
					break;
				}
				case OperandType.Switch:
				{
					int[] array = blob.DecodeSwitchTargets();
					output.Write(" (");
					for (int i = 0; i < array.Length; i++)
					{
						if (i > 0)
						{
							output.Write(", ");
						}
						output.WriteLocalReference($"IL_{array[i]:x4}", array[i]);
					}
					output.Write(")");
					break;
				}
				case OperandType.Variable:
				{
					output.Write(' ');
					int num = blob.ReadUInt16();
					if (iLOpCode == ILOpCode.Ldloc || iLOpCode == ILOpCode.Ldloca || iLOpCode == ILOpCode.Stloc)
					{
						DisassemblerHelpers.WriteVariableReference(output, metadata, methodDefinition, num);
					}
					else
					{
						DisassemblerHelpers.WriteParameterReference(output, metadata, methodDefinition, num);
					}
					break;
				}
				case OperandType.ShortVariable:
				{
					output.Write(' ');
					int num = blob.ReadByte();
					if (iLOpCode == ILOpCode.Ldloc_s || iLOpCode == ILOpCode.Ldloca_s || iLOpCode == ILOpCode.Stloc_s)
					{
						DisassemblerHelpers.WriteVariableReference(output, metadata, methodDefinition, num);
					}
					else
					{
						DisassemblerHelpers.WriteParameterReference(output, metadata, methodDefinition, num);
					}
					break;
				}
				}
			}
			else
			{
				ushort num4 = unchecked((ushort)iLOpCode);
				if (num4 > 255)
				{
					output.WriteLine($".emitbyte 0x{(byte)(num4 >> 8):x}");
					output.WriteLocalReference(DisassemblerHelpers.OffsetToString(offset + 1), offset + 1, isDefinition: true);
					output.Write(": ");
					output.Write($".emitbyte 0x{(byte)(num4 & 0xFF):x}");
				}
				else
				{
					output.Write($".emitbyte 0x{(byte)num4:x}");
				}
			}
			output.WriteLine();
		}
	}

	private void WriteMetadataToken(EntityHandle handle, bool spaceBefore)
	{
		WriteMetadataToken(handle, MetadataTokens.GetToken(handle), spaceBefore);
	}

	private void WriteMetadataToken(Handle? handle, int metadataToken, bool spaceBefore)
	{
		if (ShowMetadataTokens || !handle.HasValue)
		{
			if (spaceBefore)
			{
				output.Write(' ');
			}
			if (ShowMetadataTokensInBase10)
			{
				output.Write("/* {0} */", metadataToken);
			}
			else
			{
				output.Write("/* {0:X8} */", metadataToken);
			}
		}
	}
}
