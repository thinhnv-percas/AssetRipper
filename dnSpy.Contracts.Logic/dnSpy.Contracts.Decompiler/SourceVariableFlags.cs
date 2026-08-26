using System;

namespace dnSpy.Contracts.Decompiler;

[Flags]
public enum SourceVariableFlags
{
	None = 0,
	DecompilerGenerated = 1,
	ReadOnlyReference = 2
}
