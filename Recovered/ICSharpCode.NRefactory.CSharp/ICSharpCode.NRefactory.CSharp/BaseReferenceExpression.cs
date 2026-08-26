using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class BaseReferenceExpression : Expression
	{
		public TextLocation Location
		{
			get;
			set;
		}

		public override TextLocation StartLocation => Location;

		public override TextLocation EndLocation => new TextLocation(Location.Line, Location.Column + "base".Length);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitBaseReferenceExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitBaseReferenceExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitBaseReferenceExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other is BaseReferenceExpression;
		}
	}
}
