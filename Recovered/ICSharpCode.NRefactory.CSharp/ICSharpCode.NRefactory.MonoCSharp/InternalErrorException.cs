using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class InternalErrorException : Exception
	{
		public InternalErrorException(MemberCore mc, Exception e)
			: base(mc.Location + " " + mc.GetSignatureForError(), e)
		{
		}

		public InternalErrorException()
			: base("Internal error")
		{
		}

		public InternalErrorException(string message)
			: base(message)
		{
		}

		public InternalErrorException(string message, params object[] args)
			: base(string.Format(message, args))
		{
		}

		public InternalErrorException(Exception exception, string message, params object[] args)
			: base(string.Format(message, args), exception)
		{
		}

		public InternalErrorException(Exception e, Location loc)
			: base(loc.ToString(), e)
		{
		}
	}
}
