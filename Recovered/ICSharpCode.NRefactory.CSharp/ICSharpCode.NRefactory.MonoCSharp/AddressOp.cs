using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	[Flags]
	public enum AddressOp
	{
		Store = 0x1,
		Load = 0x2,
		LoadStore = 0x3
	}
}
