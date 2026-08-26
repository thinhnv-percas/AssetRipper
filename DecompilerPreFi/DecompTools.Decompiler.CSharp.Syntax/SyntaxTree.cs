using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class SyntaxTree : AstNode
{
	public static readonly Role<AstNode> MemberRole = new Role<AstNode>("Member", AstNode.Null);

	private string fileName;

	private IList<string> conditionalSymbols = null;

	public override NodeType NodeType => NodeType.Unknown;

	public string FileName
	{
		get
		{
			return fileName;
		}
		set
		{
			ThrowIfFrozen();
			fileName = value;
		}
	}

	public AstNodeCollection<AstNode> Members => GetChildrenByRole(MemberRole);

	public IList<string> ConditionalSymbols
	{
		get
		{
			return conditionalSymbols ?? EmptyList<string>.Instance;
		}
		internal set
		{
			conditionalSymbols = value;
		}
	}

	public AstNode TopExpression { get; internal set; }

	public IEnumerable<EntityDeclaration> GetTypes(bool includeInnerTypes = false)
	{
		Stack<AstNode> nodeStack = new Stack<AstNode>();
		nodeStack.Push((AstNode)this);
		while (nodeStack.Count > 0)
		{
			AstNode curNode = nodeStack.Pop();
			if (curNode is TypeDeclaration || curNode is DelegateDeclaration)
			{
				yield return (EntityDeclaration)curNode;
			}
			foreach (AstNode child in curNode.Children)
			{
				if (!(child is Statement) && !(child is Expression) && (child.Role != Roles.TypeMemberRole || ((child is TypeDeclaration || child is DelegateDeclaration) & includeInnerTypes)))
				{
					nodeStack.Push(child);
				}
			}
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is SyntaxTree syntaxTree && Members.DoMatch(syntaxTree.Members, match);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitSyntaxTree(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitSyntaxTree(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitSyntaxTree(this, data);
	}
}
