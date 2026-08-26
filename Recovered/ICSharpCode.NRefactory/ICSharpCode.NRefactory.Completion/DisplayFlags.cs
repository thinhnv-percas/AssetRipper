using System;

namespace ICSharpCode.NRefactory.Completion
{
	[Flags]
	public enum DisplayFlags
	{
		None = 0x0,
		Hidden = 0x1,
		Obsolete = 0x2,
		DescriptionHasMarkup = 0x4,
		NamedArgument = 0x8,
		IsImportCompletion = 0x10,
		MarkedBold = 0x20
	}
}
