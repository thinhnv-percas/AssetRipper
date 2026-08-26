using System;

namespace ICSharpCode.NRefactory.TypeSystem
{
	[Flags]
	public enum GetMemberOptions
	{
		None = 0x0,
		ReturnMemberDefinitions = 0x1,
		IgnoreInheritedMembers = 0x2
	}
}
