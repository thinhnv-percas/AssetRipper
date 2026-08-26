using System;

namespace ICSharpCode.Decompiler.Ast
{
	[Flags]
	public enum ConvertTypeOptions
	{
		None = 0x0,
		IncludeNamespace = 0x1,
		IncludeTypeParameterDefinitions = 0x2,
		DoNotUsePrimitiveTypeNames = 0x4
	}
}
