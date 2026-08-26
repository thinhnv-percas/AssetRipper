using System;

namespace ICSharpCode.NRefactory.TypeSystem;

[Flags]
public enum GetMemberOptions
{
	None = 0,
	ReturnMemberDefinitions = 1,
	IgnoreInheritedMembers = 2
}
