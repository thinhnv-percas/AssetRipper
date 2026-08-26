using System.Collections.Generic;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal sealed class ErrorMessage : AbstractMessage
	{
		public override bool IsWarning => false;

		public override string MessageType => "error";

		public ErrorMessage(int code, Location loc, string message, List<string> extraInfo)
			: base(code, loc, message, extraInfo)
		{
		}

		public ErrorMessage(AbstractMessage aMsg)
			: base(aMsg)
		{
		}
	}
}
