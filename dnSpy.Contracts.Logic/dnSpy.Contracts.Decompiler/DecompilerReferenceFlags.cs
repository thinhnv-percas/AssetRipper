using System;

namespace dnSpy.Contracts.Decompiler;

[Flags]
public enum DecompilerReferenceFlags
{
	None = 0,
	Definition = 1,
	Local = 2,
	IsWrite = 4,
	Hidden = 8
}
