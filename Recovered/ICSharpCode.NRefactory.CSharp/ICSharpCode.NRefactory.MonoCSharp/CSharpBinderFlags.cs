using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	[Flags]
	public enum CSharpBinderFlags
	{
		None = 0x0,
		CheckedContext = 0x1,
		InvokeSimpleName = 0x2,
		InvokeSpecialName = 0x4,
		BinaryOperationLogical = 0x8,
		ConvertExplicit = 0x10,
		ConvertArrayIndex = 0x20,
		ResultIndexed = 0x40,
		ValueFromCompoundAssignment = 0x80,
		ResultDiscarded = 0x100
	}
}
