using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	[Flags]
	public enum SpecialConstraint
	{
		None = 0x0,
		Constructor = 0x4,
		Class = 0x8,
		Struct = 0x10
	}
}
