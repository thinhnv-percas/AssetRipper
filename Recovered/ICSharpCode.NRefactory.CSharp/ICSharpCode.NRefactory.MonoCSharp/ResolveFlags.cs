using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	[Flags]
	public enum ResolveFlags
	{
		VariableOrValue = 0x1,
		Type = 0x2,
		MethodGroup = 0x4,
		TypeParameter = 0x8,
		MaskExprClass = 0xF
	}
}
