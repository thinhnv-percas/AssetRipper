using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ICSharpCode.Decompiler.Disassembler
{
	public sealed class MethodBodyDisassembler
	{
		private readonly ITextOutput output;

		private readonly bool detectControlStructure;

		private readonly CancellationToken cancellationToken;

		public MethodBodyDisassembler(ITextOutput output, bool detectControlStructure, CancellationToken cancellationToken)
		{
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			this.output = output;
			this.detectControlStructure = detectControlStructure;
			this.cancellationToken = cancellationToken;
		}

		public void Disassemble(MethodBody body, MethodDebugSymbols debugSymbols)
		{
			MethodDefinition method = body.Method;
			output.WriteLine("// Method begins at RVA 0x{0:x4}", method.RVA);
			output.WriteLine("// Code size {0} (0x{0:x})", body.CodeSize);
			output.WriteLine(".maxstack {0}", body.MaxStackSize);
			if (method.DeclaringType.Module.Assembly != null && method.DeclaringType.Module.Assembly.EntryPoint == method)
			{
				output.WriteLine(".entrypoint");
			}
			if (method.Body.HasVariables)
			{
				output.Write(".locals ");
				if (method.Body.InitLocals)
				{
					output.Write("init ");
				}
				output.WriteLine("(");
				output.Indent();
				foreach (VariableDefinition variable in method.Body.Variables)
				{
					output.WriteDefinition("[" + variable.Index + "] ", variable);
					variable.VariableType.WriteTo(output);
					if (!string.IsNullOrEmpty(variable.Name))
					{
						output.Write(' ');
						output.Write(DisassemblerHelpers.Escape(variable.Name));
					}
					if (variable.Index + 1 < method.Body.Variables.Count)
					{
						output.Write(',');
					}
					output.WriteLine();
				}
				output.Unindent();
				output.WriteLine(")");
			}
			output.WriteLine();
			if (detectControlStructure && body.Instructions.Count > 0)
			{
				Instruction inst = body.Instructions[0];
				HashSet<int> branchTargets = GetBranchTargets(body.Instructions);
				WriteStructureBody(new ILStructure(body), branchTargets, ref inst, debugSymbols, method.Body.CodeSize);
				return;
			}
			foreach (Instruction instruction in method.Body.Instructions)
			{
				TextLocation location = output.Location;
				instruction.WriteTo(output);
				debugSymbols?.SequencePoints.Add(new SequencePoint
				{
					StartLocation = output.Location,
					EndLocation = output.Location,
					ILRanges = new ILRange[1]
					{
						new ILRange(instruction.Offset, (instruction.Next == null) ? method.Body.CodeSize : instruction.Next.Offset)
					}
				});
				output.WriteLine();
			}
			if (method.Body.HasExceptionHandlers)
			{
				output.WriteLine();
				foreach (ExceptionHandler exceptionHandler in method.Body.ExceptionHandlers)
				{
					exceptionHandler.WriteTo(output);
					output.WriteLine();
				}
			}
		}

		private HashSet<int> GetBranchTargets(IEnumerable<Instruction> instructions)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (Instruction instruction3 in instructions)
			{
				Instruction instruction = instruction3.Operand as Instruction;
				if (instruction != null)
				{
					hashSet.Add(instruction.Offset);
				}
				Instruction[] array = instruction3.Operand as Instruction[];
				if (array != null)
				{
					Instruction[] array2 = array;
					foreach (Instruction instruction2 in array2)
					{
						hashSet.Add(instruction2.Offset);
					}
				}
			}
			return hashSet;
		}

		private void WriteStructureHeader(ILStructure s)
		{
			switch (s.Type)
			{
			case ILStructureType.Loop:
				output.Write("// loop start");
				if (s.LoopEntryPoint != null)
				{
					output.Write(" (head: ");
					DisassemblerHelpers.WriteOffsetReference(output, s.LoopEntryPoint);
					output.Write(')');
				}
				output.WriteLine();
				break;
			case ILStructureType.Try:
				output.WriteLine(".try");
				output.WriteLine("{");
				break;
			case ILStructureType.Handler:
				switch (s.ExceptionHandler.HandlerType)
				{
				case ExceptionHandlerType.Catch:
				case ExceptionHandlerType.Filter:
					output.Write("catch");
					if (s.ExceptionHandler.CatchType != null)
					{
						output.Write(' ');
						s.ExceptionHandler.CatchType.WriteTo(output, ILNameSyntax.TypeName);
					}
					output.WriteLine();
					break;
				case ExceptionHandlerType.Finally:
					output.WriteLine("finally");
					break;
				case ExceptionHandlerType.Fault:
					output.WriteLine("fault");
					break;
				default:
					throw new NotSupportedException();
				}
				output.WriteLine("{");
				break;
			case ILStructureType.Filter:
				output.WriteLine("filter");
				output.WriteLine("{");
				break;
			default:
				throw new NotSupportedException();
			}
			output.Indent();
		}

		private void WriteStructureBody(ILStructure s, HashSet<int> branchTargets, ref Instruction inst, MethodDebugSymbols debugSymbols, int codeSize)
		{
			bool flag = true;
			bool flag2 = false;
			int num = 0;
			while (inst != null && inst.Offset < s.EndOffset)
			{
				int offset = inst.Offset;
				if (num < s.Children.Count && s.Children[num].StartOffset <= offset && offset < s.Children[num].EndOffset)
				{
					ILStructure s2 = s.Children[num++];
					WriteStructureHeader(s2);
					WriteStructureBody(s2, branchTargets, ref inst, debugSymbols, codeSize);
					WriteStructureFooter(s2);
				}
				else
				{
					if (!flag && (flag2 || branchTargets.Contains(offset)))
					{
						output.WriteLine();
					}
					TextLocation location = output.Location;
					inst.WriteTo(output);
					debugSymbols?.SequencePoints.Add(new SequencePoint
					{
						StartLocation = location,
						EndLocation = output.Location,
						ILRanges = new ILRange[1]
						{
							new ILRange(inst.Offset, (inst.Next == null) ? codeSize : inst.Next.Offset)
						}
					});
					output.WriteLine();
					flag2 = (inst.OpCode.FlowControl == FlowControl.Branch || inst.OpCode.FlowControl == FlowControl.Cond_Branch || inst.OpCode.FlowControl == FlowControl.Return || inst.OpCode.FlowControl == FlowControl.Throw);
					inst = inst.Next;
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
				throw new NotSupportedException();
			}
		}
	}
}
