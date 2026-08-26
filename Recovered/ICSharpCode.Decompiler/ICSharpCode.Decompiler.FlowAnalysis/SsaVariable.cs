using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public sealed class SsaVariable
	{
		public int OriginalVariableIndex;

		public readonly string Name;

		public readonly bool IsStackLocation;

		public readonly ParameterDefinition Parameter;

		public readonly VariableDefinition Variable;

		public bool IsSingleAssignment;

		public SsaInstruction Definition;

		public List<SsaInstruction> Usage;

		public SsaVariable(ParameterDefinition p)
		{
			Name = (string.IsNullOrEmpty(p.Name) ? ("param" + p.Index) : p.Name);
			Parameter = p;
		}

		public SsaVariable(VariableDefinition v)
		{
			Name = (string.IsNullOrEmpty(v.Name) ? ("V_" + v.Index) : v.Name);
			Variable = v;
		}

		public SsaVariable(int stackLocation)
		{
			Name = "stack" + stackLocation;
			IsStackLocation = true;
		}

		public SsaVariable(SsaVariable original, string newName)
		{
			Name = newName;
			IsStackLocation = original.IsStackLocation;
			OriginalVariableIndex = original.OriginalVariableIndex;
			Parameter = original.Parameter;
			Variable = original.Variable;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
