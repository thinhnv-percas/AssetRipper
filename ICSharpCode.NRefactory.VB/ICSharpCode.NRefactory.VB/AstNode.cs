using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.Utils;
using ICSharpCode.NRefactory.VB.Ast;

namespace ICSharpCode.NRefactory.VB;

public abstract class AstNode : AbstractAnnotatable, INode
{
	private sealed class NullAstNode : AstNode
	{
		public override bool IsNull => true;

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	private sealed class PatternPlaceholder : AstNode, INode
	{
		private readonly Pattern child;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
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

	public static class Roles
	{
		public static readonly Role<AstNode> Root = RootRole;

		public static readonly Role<Identifier> Identifier = new Role<Identifier>("Identifier", ICSharpCode.NRefactory.VB.Ast.Identifier.Null);

		public static readonly Role<XmlIdentifier> XmlIdentifier = new Role<XmlIdentifier>("XmlIdentifier", ICSharpCode.NRefactory.VB.Ast.XmlIdentifier.Null);

		public static readonly Role<XmlLiteralString> XmlLiteralString = new Role<XmlLiteralString>("XmlLiteralString", ICSharpCode.NRefactory.VB.Ast.XmlLiteralString.Null);

		public static readonly Role<BlockStatement> Body = new Role<BlockStatement>("Body", BlockStatement.Null);

		public static readonly Role<ParameterDeclaration> Parameter = new Role<ParameterDeclaration>("Parameter");

		public static readonly Role<Expression> Argument = new Role<Expression>("Argument", ICSharpCode.NRefactory.VB.Ast.Expression.Null);

		public static readonly Role<AstType> Type = new Role<AstType>("Type", AstType.Null);

		public static readonly Role<Expression> Expression = new Role<Expression>("Expression", ICSharpCode.NRefactory.VB.Ast.Expression.Null);

		public static readonly Role<Expression> TargetExpression = new Role<Expression>("Target", ICSharpCode.NRefactory.VB.Ast.Expression.Null);

		public static readonly Role<Expression> Condition = new Role<Expression>("Condition", ICSharpCode.NRefactory.VB.Ast.Expression.Null);

		public static readonly Role<TypeParameterDeclaration> TypeParameter = new Role<TypeParameterDeclaration>("TypeParameter");

		public static readonly Role<AstType> TypeArgument = new Role<AstType>("TypeArgument", AstType.Null);

		public static readonly Role<VBTokenNode> Keyword = new Role<VBTokenNode>("Keyword", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> LPar = new Role<VBTokenNode>("LPar", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> RPar = new Role<VBTokenNode>("RPar", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> LBracket = new Role<VBTokenNode>("LBracket", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> RBracket = new Role<VBTokenNode>("RBracket", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> LBrace = new Role<VBTokenNode>("LBrace", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> RBrace = new Role<VBTokenNode>("RBrace", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> LChevron = new Role<VBTokenNode>("LChevron", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> RChevron = new Role<VBTokenNode>("RChevron", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> Comma = new Role<VBTokenNode>("Comma", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> QuestionMark = new Role<VBTokenNode>("QuestionMark", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> Dot = new Role<VBTokenNode>("Dot", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> Semicolon = new Role<VBTokenNode>("Semicolon", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> Assign = new Role<VBTokenNode>("Assign", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> Colon = new Role<VBTokenNode>("Colon", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> StatementTerminator = new Role<VBTokenNode>("StatementTerminator", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> XmlOpenTag = new Role<VBTokenNode>("XmlOpenTag", VBTokenNode.Null);

		public static readonly Role<VBTokenNode> XmlCloseTag = new Role<VBTokenNode>("XmlOpenTag", VBTokenNode.Null);

		public static readonly Role<Comment> Comment = new Role<Comment>("Comment");
	}

	public static readonly AstNode Null = new NullAstNode();

	private AstNode parent;

	private AstNode prevSibling;

	private AstNode nextSibling;

	private AstNode firstChild;

	private AstNode lastChild;

	private Role role = RootRole;

	private static readonly Role<AstNode> RootRole = new Role<AstNode>("Root");

	public virtual bool IsNull => false;

	public virtual TextLocation StartLocation => firstChild?.StartLocation ?? TextLocation.Empty;

	public virtual TextLocation EndLocation => lastChild?.EndLocation ?? TextLocation.Empty;

	public AstNode Parent => parent;

	public Role Role => role;

	public AstNode NextSibling => nextSibling;

	public AstNode PrevSibling => prevSibling;

	public AstNode FirstChild => firstChild;

	public AstNode LastChild => lastChild;

	public IEnumerable<AstNode> Children
	{
		get
		{
			AstNode astNode = firstChild;
			while (astNode != null)
			{
				AstNode next = astNode.nextSibling;
				yield return astNode;
				astNode = next;
			}
		}
	}

	public IEnumerable<AstNode> Ancestors
	{
		get
		{
			for (AstNode cur = parent; cur != null; cur = cur.parent)
			{
				yield return cur;
			}
		}
	}

	public IEnumerable<AstNode> Descendants => TreeTraversal.PreOrder(Children, (AstNode n) => n.Children);

	public IEnumerable<AstNode> DescendantsAndSelf => TreeTraversal.PreOrder(this, (AstNode n) => n.Children);

	INode INode.NextSibling => nextSibling;

	INode INode.FirstChild => firstChild;

	public static implicit operator AstNode(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public T GetChildByRole<T>(Role<T> role) where T : AstNode
	{
		if (role == null)
		{
			throw new ArgumentNullException("role");
		}
		for (AstNode astNode = firstChild; astNode != null; astNode = astNode.nextSibling)
		{
			if (astNode.role == role)
			{
				return (T)astNode;
			}
		}
		return role.NullObject;
	}

	public AstNodeCollection<T> GetChildrenByRole<T>(Role<T> role) where T : AstNode
	{
		return new AstNodeCollection<T>(this, role);
	}

	protected void SetChildByRole<T>(Role<T> role, T newChild) where T : AstNode
	{
		AstNode childByRole = GetChildByRole(role);
		if (childByRole.IsNull)
		{
			AddChild(newChild, role);
		}
		else
		{
			childByRole.ReplaceWith(newChild);
		}
	}

	public void AddChild<T>(T child, Role<T> role) where T : AstNode
	{
		if (role == null)
		{
			throw new ArgumentNullException("role");
		}
		if (child != null && !child.IsNull)
		{
			if (IsNull)
			{
				throw new InvalidOperationException("Cannot add children to null nodes");
			}
			if (child.parent != null)
			{
				throw new ArgumentException("Node is already used in another tree.", "child");
			}
			AddChildUnsafe(child, role);
		}
	}

	internal void AddChildUntyped(AstNode child, Role role)
	{
		if (role == null)
		{
			throw new ArgumentNullException("role");
		}
		if (child != null && !child.IsNull)
		{
			if (IsNull)
			{
				throw new InvalidOperationException("Cannot add children to null nodes");
			}
			if (child.parent != null)
			{
				throw new ArgumentException("Node is already used in another tree.", "child");
			}
			AddChildUnsafe(child, role);
		}
	}

	private void AddChildUnsafe(AstNode child, Role role)
	{
		child.parent = this;
		child.role = role;
		if (firstChild == null)
		{
			lastChild = (firstChild = child);
			return;
		}
		lastChild.nextSibling = child;
		child.prevSibling = lastChild;
		lastChild = child;
	}

	public void InsertChildBefore<T>(AstNode nextSibling, T child, Role<T> role) where T : AstNode
	{
		if (role == null)
		{
			throw new ArgumentNullException("role");
		}
		if (nextSibling == null || nextSibling.IsNull)
		{
			AddChild(child, role);
		}
		else if (child != null && !child.IsNull)
		{
			if (child.parent != null)
			{
				throw new ArgumentException("Node is already used in another tree.", "child");
			}
			if (nextSibling.parent != this)
			{
				throw new ArgumentException("NextSibling is not a child of this node.", "nextSibling");
			}
			InsertChildBeforeUnsafe(nextSibling, child, role);
		}
	}

	private void InsertChildBeforeUnsafe(AstNode nextSibling, AstNode child, Role role)
	{
		child.parent = this;
		child.role = role;
		child.nextSibling = nextSibling;
		child.prevSibling = nextSibling.prevSibling;
		if (nextSibling.prevSibling != null)
		{
			nextSibling.prevSibling.nextSibling = child;
		}
		else
		{
			firstChild = child;
		}
		nextSibling.prevSibling = child;
	}

	public void InsertChildAfter<T>(AstNode prevSibling, T child, Role<T> role) where T : AstNode
	{
		InsertChildBefore((prevSibling == null || prevSibling.IsNull) ? firstChild : prevSibling.nextSibling, child, role);
	}

	public void Remove()
	{
		if (parent != null)
		{
			if (prevSibling != null)
			{
				prevSibling.nextSibling = nextSibling;
			}
			else
			{
				parent.firstChild = nextSibling;
			}
			if (nextSibling != null)
			{
				nextSibling.prevSibling = prevSibling;
			}
			else
			{
				parent.lastChild = prevSibling;
			}
			parent = null;
			role = Roles.Root;
			prevSibling = null;
			nextSibling = null;
		}
	}

	public void ReplaceWith(AstNode newNode)
	{
		if (newNode == null || newNode.IsNull)
		{
			Remove();
		}
		else
		{
			if (newNode == this)
			{
				return;
			}
			if (parent == null)
			{
				throw new InvalidOperationException(IsNull ? "Cannot replace the null nodes" : "Cannot replace the root node");
			}
			if (!role.IsValid(newNode))
			{
				throw new ArgumentException($"The new node '{newNode.GetType().Name}' is not valid in the role {role.ToString()}", "newNode");
			}
			if (newNode.parent != null)
			{
				if (!newNode.Ancestors.Contains(this))
				{
					throw new ArgumentException("Node is already used in another tree.", "newNode");
				}
				newNode.Remove();
			}
			newNode.parent = parent;
			newNode.role = role;
			newNode.prevSibling = prevSibling;
			newNode.nextSibling = nextSibling;
			if (parent != null)
			{
				if (prevSibling != null)
				{
					prevSibling.nextSibling = newNode;
				}
				else
				{
					parent.firstChild = newNode;
				}
				if (nextSibling != null)
				{
					nextSibling.prevSibling = newNode;
				}
				else
				{
					parent.lastChild = newNode;
				}
				parent = null;
				prevSibling = null;
				nextSibling = null;
				role = Roles.Root;
			}
		}
	}

	public AstNode ReplaceWith(Func<AstNode, AstNode> replaceFunction)
	{
		if (replaceFunction == null)
		{
			throw new ArgumentNullException("replaceFunction");
		}
		if (parent == null)
		{
			throw new InvalidOperationException(IsNull ? "Cannot replace the null nodes" : "Cannot replace the root node");
		}
		AstNode astNode = parent;
		AstNode astNode2 = nextSibling;
		Role role = this.role;
		Remove();
		AstNode astNode3 = replaceFunction(this);
		if (astNode2 != null && astNode2.parent != astNode)
		{
			throw new InvalidOperationException("replace function changed nextSibling of node being replaced?");
		}
		if (astNode3 != null && !astNode3.IsNull)
		{
			if (astNode3.parent != null)
			{
				throw new InvalidOperationException("replace function must return the root of a tree");
			}
			if (!role.IsValid(astNode3))
			{
				throw new InvalidOperationException($"The new node '{astNode3.GetType().Name}' is not valid in the role {role.ToString()}");
			}
			if (astNode2 != null)
			{
				astNode.InsertChildBeforeUnsafe(astNode2, astNode3, role);
			}
			else
			{
				astNode.AddChildUnsafe(astNode3, role);
			}
		}
		return astNode3;
	}

	public AstNode Clone()
	{
		AstNode astNode = (AstNode)MemberwiseClone();
		astNode.parent = null;
		astNode.role = Roles.Root;
		astNode.firstChild = null;
		astNode.lastChild = null;
		astNode.prevSibling = null;
		astNode.nextSibling = null;
		for (AstNode astNode2 = firstChild; astNode2 != null; astNode2 = astNode2.nextSibling)
		{
			astNode.AddChildUnsafe(astNode2.Clone(), astNode2.role);
		}
		astNode.CloneAnnotations();
		return astNode;
	}

	public override void AddAnnotation(object annotation)
	{
		if (!IsNull && annotation != null)
		{
			base.AddAnnotation(annotation);
		}
	}

	public abstract S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data);

	protected static bool MatchString(string name1, string name2)
	{
		if (!string.IsNullOrEmpty(name1))
		{
			return string.Equals(name1, name2, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	protected static bool MatchStringXml(string name1, string name2)
	{
		if (!string.IsNullOrEmpty(name1))
		{
			return string.Equals(name1, name2, StringComparison.Ordinal);
		}
		return true;
	}

	protected internal abstract bool DoMatch(AstNode other, Match match);

	bool INode.DoMatch(INode other, Match match)
	{
		AstNode astNode = other as AstNode;
		if (other == null || astNode != null)
		{
			return DoMatch(astNode, match);
		}
		return false;
	}

	bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
	{
		AstNode astNode = pos as AstNode;
		if (pos == null || astNode != null)
		{
			return DoMatch(astNode, match);
		}
		return false;
	}

	public AstNode GetNextNode()
	{
		if (NextSibling != null)
		{
			return NextSibling;
		}
		if (Parent != null)
		{
			return Parent.GetNextNode();
		}
		return null;
	}

	public AstNode GetPrevNode()
	{
		if (PrevSibling != null)
		{
			return PrevSibling;
		}
		if (Parent != null)
		{
			return Parent.GetPrevNode();
		}
		return null;
	}

	public AstNode GetVBNodeBefore(AstNode node)
	{
		for (AstNode prevNode = node.PrevSibling; prevNode != null; prevNode = prevNode.GetPrevNode())
		{
			if (prevNode.Role != Roles.Comment)
			{
				return prevNode;
			}
		}
		return null;
	}
}
