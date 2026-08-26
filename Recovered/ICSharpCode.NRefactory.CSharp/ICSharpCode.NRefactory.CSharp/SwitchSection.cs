using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class SwitchSection : AstNode
	{
		private sealed class PatternPlaceholder : SwitchSection, INode
		{
			private readonly Pattern child;

			public override NodeType NodeType => NodeType.Pattern;

			public PatternPlaceholder(Pattern child)
			{
				this.child = child;
			}

			public override void AcceptVisitor(IAstVisitor visitor)
			{
				visitor.VisitPatternPlaceholder(this, child);
			}

			public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
			{
				return visitor.VisitPatternPlaceholder(this, child);
			}

			public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
			{
				return visitor.VisitPatternPlaceholder(this, child, data);
			}

			protected internal override bool DoMatch(AstNode other, Match match)
			{
				return child.DoMatch(other, match);
			}

			bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
			{
				return child.DoMatchCollection(role, pos, match, backtrackingInfo);
			}
		}

		public static readonly Role<CaseLabel> CaseLabelRole = new Role<CaseLabel>("CaseLabel");

		public override NodeType NodeType => NodeType.Unknown;

		public AstNodeCollection<CaseLabel> CaseLabels => GetChildrenByRole(CaseLabelRole);

		public AstNodeCollection<Statement> Statements => GetChildrenByRole(Roles.EmbeddedStatement);

		public static implicit operator SwitchSection(Pattern pattern)
		{
			if (pattern == null)
			{
				return null;
			}
			return new PatternPlaceholder(pattern);
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitSwitchSection(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitSwitchSection(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitSwitchSection(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			SwitchSection switchSection = other as SwitchSection;
			if (switchSection != null && CaseLabels.DoMatch(switchSection.CaseLabels, match))
			{
				return Statements.DoMatch(switchSection.Statements, match);
			}
			return false;
		}
	}
}
