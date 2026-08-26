namespace ICSharpCode.NRefactory.Utils
{
	public class DefaultFormatStringError : IFormatStringError
	{
		public int StartLocation
		{
			get;
			set;
		}

		public int EndLocation
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

		public string OriginalText
		{
			get;
			set;
		}

		public string SuggestedReplacementText
		{
			get;
			set;
		}

		public DefaultFormatStringError()
		{
			Message = "";
			OriginalText = "";
			SuggestedReplacementText = "";
		}

		public override string ToString()
		{
			return $"[DefaultFormatStringError: StartLocation={StartLocation}, EndLocation={EndLocation}, Message={Message}, OriginalText={OriginalText}, SuggestedReplacementText={SuggestedReplacementText}]";
		}
	}
}
