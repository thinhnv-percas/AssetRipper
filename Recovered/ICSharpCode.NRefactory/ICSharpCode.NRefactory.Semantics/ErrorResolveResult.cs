using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics
{
	public class ErrorResolveResult : ResolveResult
	{
		public static readonly ErrorResolveResult UnknownError = new ErrorResolveResult(SpecialType.UnknownType);

		public override bool IsError => true;

		public string Message
		{
			get;
			private set;
		}

		public TextLocation Location
		{
			get;
			private set;
		}

		public ErrorResolveResult(IType type)
			: base(type)
		{
		}

		public ErrorResolveResult(IType type, string message, TextLocation location)
			: base(type)
		{
			Message = message;
			Location = location;
		}
	}
}
