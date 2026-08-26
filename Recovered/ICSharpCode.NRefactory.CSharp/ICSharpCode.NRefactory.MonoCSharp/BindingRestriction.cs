using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	[Flags]
	public enum BindingRestriction
	{
		None = 0x0,
		DeclaredOnly = 0x2,
		InstanceOnly = 0x4,
		NoAccessors = 0x8,
		OverrideOnly = 0x10
	}
}
