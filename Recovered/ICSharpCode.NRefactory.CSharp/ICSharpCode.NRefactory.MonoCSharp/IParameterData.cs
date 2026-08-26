namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IParameterData
	{
		Expression DefaultValue
		{
			get;
		}

		bool HasExtensionMethodModifier
		{
			get;
		}

		bool HasDefaultValue
		{
			get;
		}

		Parameter.Modifier ModFlags
		{
			get;
		}

		string Name
		{
			get;
		}
	}
}
