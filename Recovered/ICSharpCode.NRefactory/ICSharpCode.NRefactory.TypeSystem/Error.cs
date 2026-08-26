using System;

namespace ICSharpCode.NRefactory.TypeSystem
{
	[Serializable]
	public class Error
	{
		private readonly ErrorType errorType;

		private readonly string message;

		private readonly DomRegion region;

		public ErrorType ErrorType => errorType;

		public string Message => message;

		public DomRegion Region => region;

		public Error(ErrorType errorType, string message, DomRegion region)
		{
			this.errorType = errorType;
			this.message = message;
			this.region = region;
		}

		public Error(ErrorType errorType, string message, TextLocation location)
		{
			this.errorType = errorType;
			this.message = message;
			region = new DomRegion(location, location);
		}

		public Error(ErrorType errorType, string message, int line, int col)
			: this(errorType, message, new TextLocation(line, col))
		{
		}

		public Error(ErrorType errorType, string message)
		{
			this.errorType = errorType;
			this.message = message;
			region = DomRegion.Empty;
		}
	}
}
