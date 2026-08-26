using ICSharpCode.NRefactory.PatternMatching;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public class MemberReferenceExpression : Expression
	{
		public Expression Target
		{
			get
			{
				return GetChildByRole(Roles.TargetExpression);
			}
			set
			{
				SetChildByRole(Roles.TargetExpression, value);
			}
		}

		public CSharpTokenNode DotToken => GetChildByRole(Roles.Dot);

		public string MemberName
		{
			get
			{
				return GetChildByRole(Roles.Identifier).Name;
			}
			set
			{
				SetChildByRole(Roles.Identifier, Identifier.Create(value));
			}
		}

		public Identifier MemberNameToken
		{
			get
			{
				return GetChildByRole(Roles.Identifier);
			}
			set
			{
				SetChildByRole(Roles.Identifier, value);
			}
		}

		public CSharpTokenNode LChevronToken => GetChildByRole(Roles.LChevron);

		public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

		public CSharpTokenNode RChevronToken => GetChildByRole(Roles.RChevron);

		public MemberReferenceExpression()
		{
		}

		public MemberReferenceExpression(Expression target, string memberName, IEnumerable<AstType> arguments = null)
		{
			AddChild(target, Roles.TargetExpression);
			MemberName = memberName;
			if (arguments != null)
			{
				foreach (AstType argument in arguments)
				{
					AddChild(argument, Roles.TypeArgument);
				}
			}
		}

		public MemberReferenceExpression(Expression target, string memberName, params AstType[] arguments)
			: this(target, memberName, (IEnumerable<AstType>)arguments)
		{
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitMemberReferenceExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitMemberReferenceExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitMemberReferenceExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			MemberReferenceExpression memberReferenceExpression = other as MemberReferenceExpression;
			if (memberReferenceExpression != null && Target.DoMatch(memberReferenceExpression.Target, match) && AstNode.MatchString(MemberName, memberReferenceExpression.MemberName))
			{
				return TypeArguments.DoMatch(memberReferenceExpression.TypeArguments, match);
			}
			return false;
		}
	}
}
