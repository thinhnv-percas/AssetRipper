using System;

namespace DecompTools.Decompiler.IL;

[Flags]
public enum InstructionFlags
{
	None = 0,
	MayReadLocals = 0x10,
	MayWriteLocals = 0x20,
	SideEffect = 0x40,
	MayThrow = 0x100,
	MayBranch = 0x200,
	MayUnwrapNull = 0x400,
	EndPointUnreachable = 0x800,
	ControlFlow = 0x1000
}
