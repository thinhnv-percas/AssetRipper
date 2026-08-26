namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IVariableReference : IFixedExpression
	{
		bool IsHoisted
		{
			get;
		}

		string Name
		{
			get;
		}

		VariableInfo VariableInfo
		{
			get;
		}

		void SetHasAddressTaken();
	}
}
