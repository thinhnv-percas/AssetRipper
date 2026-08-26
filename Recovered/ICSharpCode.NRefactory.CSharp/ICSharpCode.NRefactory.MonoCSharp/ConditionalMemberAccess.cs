namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class ConditionalMemberAccess : MemberAccess
	{
		public ConditionalMemberAccess(Expression expr, string identifier, TypeArguments args, Location loc)
			: base(expr, identifier, args, loc)
		{
		}

		public override bool HasConditionalAccess()
		{
			return true;
		}
	}
}
