namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IParametersMember : IInterfaceMemberSpec
	{
		AParametersCollection Parameters
		{
			get;
		}
	}
}
