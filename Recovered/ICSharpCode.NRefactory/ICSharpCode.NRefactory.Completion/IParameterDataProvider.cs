namespace ICSharpCode.NRefactory.Completion
{
	public interface IParameterDataProvider
	{
		int Count
		{
			get;
		}

		int StartOffset
		{
			get;
		}

		string GetHeading(int overload, string[] parameterDescription, int currentParameter);

		string GetDescription(int overload, int currentParameter);

		string GetParameterDescription(int overload, int paramIndex);

		string GetParameterName(int overload, int currentParameter);

		int GetParameterCount(int overload);

		bool AllowParameterList(int overload);
	}
}
