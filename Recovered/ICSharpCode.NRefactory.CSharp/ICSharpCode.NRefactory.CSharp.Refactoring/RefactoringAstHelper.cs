using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class RefactoringAstHelper
	{
		public static IdentifierExpression RemoveTarget(MemberReferenceExpression mre)
		{
			IdentifierExpression identifierExpression = new IdentifierExpression(mre.MemberName);
			identifierExpression.TypeArguments.AddRange(from t in mre.TypeArguments
				select t.Clone());
			return identifierExpression;
		}

		public static SimpleType RemoveTarget(MemberType memberType)
		{
			return new SimpleType(memberType.MemberName, from t in memberType.TypeArguments
				select t.Clone());
		}
	}
}
