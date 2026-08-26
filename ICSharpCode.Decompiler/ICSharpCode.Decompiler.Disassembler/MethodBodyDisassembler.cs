using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Pdb;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.Disassembler;

internal sealed class MethodBodyDisassembler
{
	private readonly IDecompilerOutput output;

	private readonly bool detectControlStructure;

	private readonly DisassemblerOptions options;

	public MethodBodyDisassembler(IDecompilerOutput output, bool detectControlStructure, DisassemblerOptions options)
	{
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		this.output = output;
		this.detectControlStructure = detectControlStructure;
		this.options = options;
	}

	public void Disassemble(MethodDef method, MethodDebugInfoBuilder builder, InstructionOperandConverter instructionOperandConverter)
	{
		CilBody body = method.Body;
		uint codeSize = (uint)body.GetCodeSize();
		uint rVA = (uint)method.RVA;
		if (options.ShowTokenAndRvaComments)
		{
			output.WriteLine(string.Format("// Header Size: {0} {1}", body.HeaderSize, (body.HeaderSize == 1) ? "byte" : "bytes"), BoxedTextColor.Comment);
			output.WriteLine(string.Format("// Code Size: {0} (0x{0:X}) {1}", codeSize, (codeSize == 1) ? "byte" : "bytes"), BoxedTextColor.Comment);
			if (body.LocalVarSigTok != 0)
			{
				output.Write("// LocalVarSig Token: ", BoxedTextColor.Comment);
				output.Write($"0x{body.LocalVarSigTok:X8}", new TokenReference(method.Module, body.LocalVarSigTok), DecompilerReferenceFlags.None, BoxedTextColor.Comment);
				output.Write($" RID: {body.LocalVarSigTok & 0xFFFFFF}", BoxedTextColor.Comment);
				output.WriteLine();
			}
		}
		output.Write(".maxstack", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		output.WriteLine($"{body.MaxStack}", BoxedTextColor.Number);
		if (method.DeclaringType.Module.EntryPoint == method)
		{
			output.WriteLine(".entrypoint", BoxedTextColor.ILDirective);
		}
		if (body.HasVariables)
		{
			output.Write(".locals", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			if (body.InitLocals)
			{
				output.Write("init", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
			}
			BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
			output.WriteLine();
			output.IncreaseIndent();
			foreach (Local variable in body.Variables)
			{
				SourceLocal sourceLocal = (SourceLocal)instructionOperandConverter.Convert(variable);
				BracePairHelper bracePairHelper2 = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
				bool flag = !string.IsNullOrEmpty(sourceLocal.Local.Name);
				if (flag)
				{
					output.Write(sourceLocal.Local.Index.ToString(), BoxedTextColor.Number);
				}
				else
				{
					output.Write(sourceLocal.Local.Index.ToString(), sourceLocal, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Number);
				}
				bracePairHelper2.Write("]");
				output.Write(" ", BoxedTextColor.Text);
				sourceLocal.Type.WriteTo(output);
				if (flag)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write(DisassemblerHelpers.Escape(sourceLocal.Name), sourceLocal, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Local);
				}
				if (sourceLocal.Local.Index + 1 < body.Variables.Count)
				{
					output.Write(",", BoxedTextColor.Punctuation);
				}
				output.WriteLine();
			}
			output.DecreaseIndent();
			bracePairHelper.Write(")");
			output.WriteLine();
		}
		output.WriteLine();
		uint num = ((rVA != 0) ? (rVA + body.HeaderSize) : 0u);
		long baseOffs = ((num != 0) ? (method.Module.ToFileOffset(num) ?? 0) : 0);
		PdbAsyncMethodCustomDebugInfo pdbAsyncInfo = null;
		if (options.ShowPdbInfo)
		{
			pdbAsyncInfo = method.CustomDebugInfos.OfType<PdbAsyncMethodCustomDebugInfo>().FirstOrDefault();
		}
		IInstructionBytesReader byteReader = ((!options.ShowILBytes || options.CreateInstructionBytesReader == null) ? null : options.CreateInstructionBytesReader(method));
		if (detectControlStructure && body.Instructions.Count > 0)
		{
			int index = 0;
			HashSet<uint> branchTargets = GetBranchTargets(body.Instructions);
			WriteStructureBody(body, new ILStructure(body), branchTargets, ref index, builder, instructionOperandConverter, body.GetCodeSize(), num, baseOffs, byteReader, pdbAsyncInfo, method);
			return;
		}
		IList<Instruction> instructions = body.Instructions;
		for (int i = 0; i < instructions.Count; i++)
		{
			Instruction instruction = instructions[i];
			instruction.WriteTo(output, options, num, baseOffs, byteReader, method, instructionOperandConverter, pdbAsyncInfo, out var startLocation);
			builder?.Add(new SourceStatement(ILSpan.FromBounds(end: (uint)(((int?)((i + 1 < instructions.Count) ? instructions[i + 1] : null)?.Offset) ?? body.GetCodeSize()), start: instruction.Offset), new TextSpan(startLocation, output.NextPosition - startLocation)));
			output.WriteLine();
		}
		if (!body.HasExceptionHandlers)
		{
			return;
		}
		output.WriteLine();
		foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
		{
			exceptionHandler.WriteTo(output, method);
			output.WriteLine();
		}
	}

	private HashSet<uint> GetBranchTargets(IEnumerable<Instruction> instructions)
	{
		HashSet<uint> hashSet = new HashSet<uint>();
		foreach (Instruction instruction2 in instructions)
		{
			if (instruction2.Operand is Instruction instruction)
			{
				hashSet.Add(instruction.Offset);
			}
			if (!(instruction2.Operand is IList<Instruction> list))
			{
				continue;
			}
			foreach (Instruction item in list)
			{
				if (item != null)
				{
					hashSet.Add(item.Offset);
				}
			}
		}
		return hashSet;
	}

	private BracePairHelper WriteStructureHeader(ILStructure s)
	{
		BracePairHelper result;
		switch (s.Type)
		{
		case ILStructureType.Loop:
			output.Write("// loop start", BoxedTextColor.Comment);
			if (s.LoopEntryPoint != null)
			{
				output.Write(" (head: ", BoxedTextColor.Comment);
				DisassemblerHelpers.WriteOffsetReference(output, s.LoopEntryPoint, null, BoxedTextColor.Comment);
				output.Write(")", BoxedTextColor.Comment);
			}
			output.WriteLine();
			result = default(BracePairHelper);
			break;
		case ILStructureType.Try:
			output.WriteLine(".try", BoxedTextColor.ILDirective);
			result = BracePairHelper.Create(output, "{", CodeBracesRangeFlags.TryBraces);
			output.WriteLine();
			break;
		case ILStructureType.Handler:
		{
			CodeBracesRangeFlags flags;
			switch (s.ExceptionHandler.HandlerType)
			{
			case ExceptionHandlerType.Catch:
			case ExceptionHandlerType.Filter:
				output.Write("catch", BoxedTextColor.Keyword);
				if (s.ExceptionHandler.CatchType != null)
				{
					output.Write(" ", BoxedTextColor.Text);
					s.ExceptionHandler.CatchType.WriteTo(output, ILNameSyntax.TypeName);
				}
				output.WriteLine();
				flags = ((s.ExceptionHandler.HandlerType == ExceptionHandlerType.Catch) ? CodeBracesRangeFlags.CatchBraces : CodeBracesRangeFlags.FilterBraces);
				break;
			case ExceptionHandlerType.Finally:
				output.WriteLine("finally", BoxedTextColor.Keyword);
				flags = CodeBracesRangeFlags.FinallyBraces;
				break;
			case ExceptionHandlerType.Fault:
				output.WriteLine("fault", BoxedTextColor.Keyword);
				flags = CodeBracesRangeFlags.FaultBraces;
				break;
			default:
				output.WriteLine(s.ExceptionHandler.HandlerType.ToString(), BoxedTextColor.Keyword);
				flags = CodeBracesRangeFlags.OtherBlockBraces;
				break;
			}
			result = BracePairHelper.Create(output, "{", flags);
			output.WriteLine();
			break;
		}
		case ILStructureType.Filter:
			output.WriteLine("filter", BoxedTextColor.Keyword);
			result = BracePairHelper.Create(output, "{", CodeBracesRangeFlags.FilterBraces);
			output.WriteLine();
			break;
		default:
			throw new NotSupportedException();
		}
		output.IncreaseIndent();
		return result;
	}

	private void WriteStructureBody(CilBody body, ILStructure s, HashSet<uint> branchTargets, ref int index, MethodDebugInfoBuilder builder, InstructionOperandConverter instructionOperandConverter, int codeSize, uint baseRva, long baseOffs, IInstructionBytesReader byteReader, PdbAsyncMethodCustomDebugInfo pdbAsyncInfo, MethodDef method)
	{
		bool flag = true;
		bool flag2 = false;
		int num = 0;
		IList<Instruction> instructions = body.Instructions;
		while (index < instructions.Count)
		{
			Instruction instruction = instructions[index];
			if (instruction.Offset >= s.EndOffset)
			{
				break;
			}
			uint offset = instruction.Offset;
			if (num < s.Children.Count && s.Children[num].StartOffset <= offset && offset < s.Children[num].EndOffset)
			{
				ILStructure s2 = s.Children[num++];
				BracePairHelper bh = WriteStructureHeader(s2);
				WriteStructureBody(body, s2, branchTargets, ref index, builder, instructionOperandConverter, codeSize, baseRva, baseOffs, byteReader, pdbAsyncInfo, method);
				WriteStructureFooter(s2, bh);
			}
			else
			{
				if (!flag && (flag2 || branchTargets.Contains(offset)))
				{
					output.WriteLine();
				}
				instruction.WriteTo(output, options, baseRva, baseOffs, byteReader, method, instructionOperandConverter, pdbAsyncInfo, out var startLocation);
				builder?.Add(new SourceStatement(ILSpan.FromBounds(end: (uint)(((int?)((index + 1 < instructions.Count) ? instructions[index + 1] : null)?.Offset) ?? codeSize), start: instruction.Offset), new TextSpan(startLocation, output.NextPosition - startLocation)));
				output.WriteLine();
				flag2 = instruction.OpCode.FlowControl == FlowControl.Branch || instruction.OpCode.FlowControl == FlowControl.Cond_Branch || instruction.OpCode.FlowControl == FlowControl.Return || instruction.OpCode.FlowControl == FlowControl.Throw;
				index++;
			}
			flag = false;
		}
	}

	private void WriteStructureFooter(ILStructure s, BracePairHelper bh)
	{
		output.DecreaseIndent();
		switch (s.Type)
		{
		case ILStructureType.Loop:
			output.WriteLine("// end loop", BoxedTextColor.Comment);
			break;
		case ILStructureType.Try:
			bh.Write("}");
			output.Write(" ", BoxedTextColor.Text);
			output.WriteLine("// end .try", BoxedTextColor.Comment);
			break;
		case ILStructureType.Handler:
			bh.Write("}");
			output.Write(" ", BoxedTextColor.Text);
			output.WriteLine("// end handler", BoxedTextColor.Comment);
			break;
		case ILStructureType.Filter:
			bh.Write("}");
			output.Write(" ", BoxedTextColor.Text);
			output.WriteLine("// end filter", BoxedTextColor.Comment);
			break;
		default:
			throw new NotSupportedException();
		}
	}
}
