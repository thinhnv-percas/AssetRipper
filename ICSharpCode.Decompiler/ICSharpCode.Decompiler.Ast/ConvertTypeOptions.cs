using System;

namespace ICSharpCode.Decompiler.Ast;

[Flags]
public enum ConvertTypeOptions
{
	None = 0,
	IncludeNamespace = 1,
	IncludeTypeParameterDefinitions = 2,
	DoNotUsePrimitiveTypeNames = 4,
	DoNotIncludeEnclosingType = 8
}
