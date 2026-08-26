using System;

namespace Mon3.Cecil.Cil;

[Flags]
public enum VariableAttributes : ushort
{
	None = 0,
	DebuggerHidden = 1
}
