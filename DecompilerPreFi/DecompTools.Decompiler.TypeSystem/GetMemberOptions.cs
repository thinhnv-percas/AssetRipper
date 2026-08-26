using System;

namespace DecompTools.Decompiler.TypeSystem;

[Flags]
public enum GetMemberOptions
{
	None = 0,
	ReturnMemberDefinitions = 1,
	IgnoreInheritedMembers = 2
}
