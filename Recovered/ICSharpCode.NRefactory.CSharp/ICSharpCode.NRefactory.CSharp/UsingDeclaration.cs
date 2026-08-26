using ICSharpCode.NRefactory.PatternMatching;
using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp
{
	public class UsingDeclaration : AstNode
	{
		public static readonly TokenRole UsingKeywordRole = new TokenRole("using");

		public static readonly Role<AstType> ImportRole = new Role<AstType>("Import", AstType.Null);

		public override NodeType NodeType => NodeType.Unknown;

		public CSharpTokenNode UsingToken => GetChildByRole(UsingKeywordRole);

		public AstType Import
		{
			get
			{
				return GetChildByRole(ImportRole);
			}
			set
			{
				SetChildByRole(ImportRole, value);
			}
		}

		public string Namespace => ConstructNamespace(Import);

		public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

		internal static string ConstructNamespace(AstType type)
		{
			Stack<string> stack = new Stack<string>();
			while (type is MemberType)
			{
				MemberType memberType = (MemberType)type;
				stack.Push(memberType.MemberName);
				type = memberType.Target;
				if (memberType.IsDoubleColon)
				{
					stack.Push("::");
				}
				else
				{
					stack.Push(".");
				}
			}
			if (type is SimpleType)
			{
				stack.Push(((SimpleType)type).Identifier);
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (stack.Count > 0)
			{
				stringBuilder.Append(stack.Pop());
			}
			return stringBuilder.ToString();
		}

		public UsingDeclaration()
		{
		}

		public UsingDeclaration(string nameSpace)
		{
			AddChild(AstType.Create(nameSpace), ImportRole);
		}

		public UsingDeclaration(AstType import)
		{
			AddChild(import, ImportRole);
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitUsingDeclaration(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitUsingDeclaration(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitUsingDeclaration(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			UsingDeclaration usingDeclaration = other as UsingDeclaration;
			if (usingDeclaration != null)
			{
				return Import.DoMatch(usingDeclaration.Import, match);
			}
			return false;
		}
	}
}
