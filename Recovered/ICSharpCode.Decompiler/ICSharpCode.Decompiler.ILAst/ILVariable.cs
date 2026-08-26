using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILVariable
	{
		public string Name;

		public bool IsGenerated;

		public TypeReference Type;

		public VariableDefinition OriginalVariable;

		public ParameterDefinition OriginalParameter;

		public bool IsPinned
		{
			get
			{
				if (OriginalVariable != null)
				{
					return OriginalVariable.IsPinned;
				}
				return false;
			}
		}

		public bool IsParameter => OriginalParameter != null;

		public override string ToString()
		{
			return Name;
		}
	}
}
