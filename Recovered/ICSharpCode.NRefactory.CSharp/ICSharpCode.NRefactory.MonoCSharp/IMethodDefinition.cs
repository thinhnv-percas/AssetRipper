using System.Reflection;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IMethodDefinition : IMemberDefinition
	{
		MethodBase Metadata
		{
			get;
		}
	}
}
