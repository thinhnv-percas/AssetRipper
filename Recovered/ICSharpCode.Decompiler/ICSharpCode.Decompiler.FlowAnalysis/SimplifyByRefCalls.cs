using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	internal sealed class SimplifyByRefCalls
	{
		private readonly SsaForm ssaForm;

		private bool couldSimplifySomething;

		private readonly List<SsaInstruction> redundantLoadAddressInstructions = new List<SsaInstruction>();

		public static bool MakeByRefCallsSimple(SsaForm ssaForm)
		{
			SimplifyByRefCalls simplifyByRefCalls = new SimplifyByRefCalls(ssaForm);
			foreach (SsaBlock block in ssaForm.Blocks)
			{
				for (int i = 0; i < block.Instructions.Count; i++)
				{
					SsaInstruction ssaInstruction = block.Instructions[i];
					if (ssaInstruction.Instruction != null)
					{
						switch (ssaInstruction.Instruction.OpCode.Code)
						{
						case Code.Call:
						case Code.Callvirt:
							simplifyByRefCalls.MakeByRefCallSimple(block, ref i, (IMethodSignature)ssaInstruction.Instruction.Operand);
							break;
						case Code.Initobj:
							simplifyByRefCalls.MakeInitObjCallSimple(block, ref i);
							break;
						case Code.Ldfld:
							simplifyByRefCalls.MakeLoadFieldCallSimple(block, ref i);
							break;
						}
					}
				}
			}
			simplifyByRefCalls.RemoveRedundantInstructions();
			if (simplifyByRefCalls.couldSimplifySomething)
			{
				ssaForm.ComputeVariableUsage();
			}
			return simplifyByRefCalls.couldSimplifySomething;
		}

		private SimplifyByRefCalls(SsaForm ssaForm)
		{
			this.ssaForm = ssaForm;
		}

		private void MakeByRefCallSimple(SsaBlock block, ref int instructionIndexInBlock, IMethodSignature targetMethod)
		{
			SsaInstruction ssaInstruction = block.Instructions[instructionIndexInBlock];
			for (int i = 0; i < ssaInstruction.Operands.Length; i++)
			{
				SsaVariable ssaVariable = ssaInstruction.Operands[i];
				if (ssaVariable.IsSingleAssignment && ssaVariable.Usage.Count == 1 && IsLoadAddress(ssaVariable.Definition))
				{
					Instruction instruction = ssaVariable.Definition.Instruction;
					bool flag = (i != 0 || !targetMethod.HasThis) && targetMethod.Parameters[i - (targetMethod.HasThis ? 1 : 0)].IsOut;
					SsaVariable variableFromLoadAddressInstruction = GetVariableFromLoadAddressInstruction(instruction);
					SpecialOpCode specialOpCode = flag ? SpecialOpCode.PrepareByOutCall : SpecialOpCode.PrepareByRefCall;
					block.Instructions.Insert(instructionIndexInBlock++, new SsaInstruction(block, null, ssaVariable, new SsaVariable[1]
					{
						variableFromLoadAddressInstruction
					}, null, specialOpCode));
					block.Instructions.Insert(instructionIndexInBlock + 1, new SsaInstruction(block, null, variableFromLoadAddressInstruction, new SsaVariable[1]
					{
						ssaVariable
					}, null, SpecialOpCode.WriteAfterByRefOrOutCall));
					couldSimplifySomething = true;
					redundantLoadAddressInstructions.Add(ssaVariable.Definition);
				}
			}
		}

		private SsaVariable GetVariableFromLoadAddressInstruction(Instruction loadAddressInstruction)
		{
			if (loadAddressInstruction.OpCode == OpCodes.Ldloca)
			{
				return ssaForm.GetOriginalVariable((VariableReference)loadAddressInstruction.Operand);
			}
			return ssaForm.GetOriginalVariable((ParameterReference)loadAddressInstruction.Operand);
		}

		private static bool IsLoadAddress(SsaInstruction inst)
		{
			if (inst.Instruction != null)
			{
				if (!(inst.Instruction.OpCode == OpCodes.Ldloca))
				{
					return inst.Instruction.OpCode == OpCodes.Ldarga;
				}
				return true;
			}
			return false;
		}

		private void MakeInitObjCallSimple(SsaBlock block, ref int instructionIndexInBlock)
		{
			SsaInstruction ssaInstruction = block.Instructions[instructionIndexInBlock];
			SsaVariable ssaVariable = ssaInstruction.Operands[0];
			if (ssaVariable.IsSingleAssignment && ssaVariable.Usage.Count == 1 && IsLoadAddress(ssaVariable.Definition))
			{
				block.Instructions[instructionIndexInBlock] = new SsaInstruction(ssaInstruction.ParentBlock, null, GetVariableFromLoadAddressInstruction(ssaVariable.Definition.Instruction), null, null, SpecialOpCode.InitObj, (TypeReference)ssaInstruction.Instruction.Operand);
				couldSimplifySomething = true;
				redundantLoadAddressInstructions.Add(ssaVariable.Definition);
			}
		}

		private void MakeLoadFieldCallSimple(SsaBlock block, ref int instructionIndexInBlock)
		{
			SsaInstruction ssaInstruction = block.Instructions[instructionIndexInBlock];
			SsaVariable ssaVariable = ssaInstruction.Operands[0];
			if (ssaVariable.IsSingleAssignment && ssaVariable.Usage.Count == 1 && IsLoadAddress(ssaVariable.Definition))
			{
				block.Instructions.Insert(instructionIndexInBlock++, new SsaInstruction(ssaInstruction.ParentBlock, null, ssaVariable, new SsaVariable[1]
				{
					GetVariableFromLoadAddressInstruction(ssaVariable.Definition.Instruction)
				}, null, SpecialOpCode.PrepareForFieldAccess));
				couldSimplifySomething = true;
				redundantLoadAddressInstructions.Add(ssaVariable.Definition);
			}
		}

		private void RemoveRedundantInstructions()
		{
			foreach (SsaInstruction redundantLoadAddressInstruction in redundantLoadAddressInstructions)
			{
				redundantLoadAddressInstruction.ParentBlock.Instructions.Remove(redundantLoadAddressInstruction);
			}
		}
	}
}
