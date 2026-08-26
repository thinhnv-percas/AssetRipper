#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DecompTools.Decompiler.CSharp.OutputVisitor;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public abstract class AstNode : AbstractAnnotatable, IFreezable, INode, ICloneable
{
	private sealed class NullAstNode : AstNode
	{
		public override NodeType NodeType => NodeType.Unknown;

		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	private sealed class PatternPlaceholder : AstNode, INode
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

	internal static readonly Role<AstNode> RootRole = new Role<AstNode>("Root");

	public static readonly AstNode Null = new NullAstNode();

	private AstNode parent;

	private AstNode prevSibling;

	private AstNode nextSibling;

	private AstNode firstChild;

	private AstNode lastChild;

	protected uint flags = RootRole.Index;

	private const uint roleIndexMask = 511u;

	private const uint frozenBit = 512u;

	protected const int AstNodeFlagsUsedBits = 10;

	public bool IsFrozen => (flags & 0x200) != 0;

	public abstract NodeType NodeType { get; }

	public virtual bool IsNull => false;

	public virtual TextLocation StartLocation => firstChild?.StartLocation ?? TextLocation.Empty;

	public virtual TextLocation EndLocation => lastChild?.EndLocation ?? TextLocation.Empty;

	public AstNode Parent => parent;

	public Role Role
	{
		get
		{
			return Role.GetByIndex(flags & 0x1FF);
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!value.IsValid(this))
			{
				throw new ArgumentException("This node is not valid in the new role.");
			}
			ThrowIfFrozen();
			SetRole(value);
		}
	}

	internal uint RoleIndex => flags & 0x1FF;

	public AstNode NextSibling => nextSibling;

	public AstNode PrevSibling => prevSibling;

	public AstNode FirstChild => firstChild;

	public AstNode LastChild => lastChild;

	public bool HasChildren => firstChild != null;

	public IEnumerable<AstNode> Children
	{
		get
		{
			AstNode cur = firstChild;
			while (cur != null)
			{
				Debug.Assert(cur.parent == this);
				AstNode next = cur.nextSibling;
				yield return cur;
				cur = next;
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

	public IEnumerable<AstNode> AncestorsAndSelf
	{
		get
		{
			for (AstNode cur = this; cur != null; cur = cur.parent)
			{
				yield return cur;
			}
		}
	}

	public IEnumerable<AstNode> Descendants => GetDescendantsImpl(includeSelf: false);

	public IEnumerable<AstNode> DescendantsAndSelf => GetDescendantsImpl(includeSelf: true);

	INode INode.NextSibling => nextSibling;

	INode INode.FirstChild => firstChild;

	public static implicit operator AstNode(Pattern pattern)
	{
		return (pattern != null) ? new PatternPlaceholder(pattern) : null;
	}

	protected AstNode()
	{
		if (IsNull)
		{
			Freeze();
		}
	}

	public void Freeze()
	{
		if (!IsFrozen)
		{
			for (AstNode astNode = firstChild; astNode != null; astNode = astNode.nextSibling)
			{
				astNode.Freeze();
			}
			flags |= 512u;
		}
	}

	protected void ThrowIfFrozen()
	{
		if (IsFrozen)
		{
			throw new InvalidOperationException("Cannot mutate frozen " + GetType().Name);
		}
	}

	private void SetRole(Role role)
	{
		flags = (flags & 0xFFFFFE00u) | role.Index;
	}

	public IEnumerable<AstNode> DescendantNodes(Func<AstNode, bool> descendIntoChildren = null)
	{
		return GetDescendantsImpl(includeSelf: false, descendIntoChildren);
	}

	public IEnumerable<AstNode> DescendantNodesAndSelf(Func<AstNode, bool> descendIntoChildren = null)
	{
		return GetDescendantsImpl(includeSelf: true, descendIntoChildren);
	}

	private IEnumerable<AstNode> GetDescendantsImpl(bool includeSelf, Func<AstNode, bool> descendIntoChildren = null)
	{
		if (includeSelf)
		{
			yield return this;
			if (descendIntoChildren != null && !descendIntoChildren(this))
			{
				yield break;
			}
		}
		Stack<AstNode> nextStack = new Stack<AstNode>();
		nextStack.Push((AstNode)null);
		for (AstNode pos = firstChild; pos != null; pos = ((pos.firstChild == null || !(descendIntoChildren?.Invoke(pos) ?? true)) ? nextStack.Pop() : pos.firstChild))
		{
			if (pos.nextSibling != null)
			{
				nextStack.Push(pos.nextSibling);
			}
			yield return pos;
		}
	}

	public T GetChildByRole<T>(Role<T> role) where T : AstNode
	{
		if (role == null)
		{
			throw new ArgumentNullException("role");
		}
		uint index = role.Index;
		for (AstNode astNode = firstChild; astNode != null; astNode = astNode.nextSibling)
		{
			if ((astNode.flags & 0x1FF) == index)
			{
				return (T)astNode;
			}
		}
		return role.NullObject;
	}

	public T GetParent<T>() where T : AstNode
	{
		return Enumerable.FirstOrDefault<T>(Enumerable.OfType<T>((IEnumerable)Ancestors));
	}

	public AstNode GetParent(Func<AstNode, bool> pred)
	{
		return Enumerable.FirstOrDefault<AstNode>(Ancestors, pred);
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
			ThrowIfFrozen();
			if (child == this)
			{
				throw new ArgumentException("Cannot add a node to itself as a child.", "child");
			}
			if (child.parent != null)
			{
				throw new ArgumentException("Node is already used in another tree.", "child");
			}
			if (child.IsFrozen)
			{
				throw new ArgumentException("Cannot add a frozen node.", "child");
			}
			AddChildUnsafe(child, role);
		}
	}

	public void AddChildWithExistingRole(AstNode child)
	{
		if (child != null && !child.IsNull)
		{
			ThrowIfFrozen();
			if (child == this)
			{
				throw new ArgumentException("Cannot add a node to itself as a child.", "child");
			}
			if (child.parent != null)
			{
				throw new ArgumentException("Node is already used in another tree.", "child");
			}
			if (child.IsFrozen)
			{
				throw new ArgumentException("Cannot add a frozen node.", "child");
			}
			AddChildUnsafe(child, child.Role);
		}
	}

	internal void AddChildUnsafe(AstNode child, Role role)
	{
		child.parent = this;
		child.SetRole(role);
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
			ThrowIfFrozen();
			if (child.parent != null)
			{
				throw new ArgumentException("Node is already used in another tree.", "child");
			}
			if (child.IsFrozen)
			{
				throw new ArgumentException("Cannot add a frozen node.", "child");
			}
			if (nextSibling.parent != this)
			{
				throw new ArgumentException("NextSibling is not a child of this node.", "nextSibling");
			}
			InsertChildBeforeUnsafe(nextSibling, child, role);
		}
	}

	internal void InsertChildBeforeUnsafe(AstNode nextSibling, AstNode child, Role role)
	{
		child.parent = this;
		child.SetRole(role);
		child.nextSibling = nextSibling;
		child.prevSibling = nextSibling.prevSibling;
		if (nextSibling.prevSibling != null)
		{
			Debug.Assert(nextSibling.prevSibling.nextSibling == nextSibling);
			nextSibling.prevSibling.nextSibling = child;
		}
		else
		{
			Debug.Assert(firstChild == nextSibling);
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
			ThrowIfFrozen();
			if (prevSibling != null)
			{
				Debug.Assert(prevSibling.nextSibling == this);
				prevSibling.nextSibling = nextSibling;
			}
			else
			{
				Debug.Assert(parent.firstChild == this);
				parent.firstChild = nextSibling;
			}
			if (nextSibling != null)
			{
				Debug.Assert(nextSibling.prevSibling == this);
				nextSibling.prevSibling = prevSibling;
			}
			else
			{
				Debug.Assert(parent.lastChild == this);
				parent.lastChild = prevSibling;
			}
			parent = null;
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
			ThrowIfFrozen();
			if (!Role.IsValid(newNode))
			{
				throw new ArgumentException($"The new node '{newNode.GetType().Name}' is not valid in the role {Role.ToString()}", "newNode");
			}
			if (newNode.parent != null)
			{
				if (!Enumerable.Contains<AstNode>(newNode.Ancestors, this))
				{
					throw new ArgumentException("Node is already used in another tree.", "newNode");
				}
				newNode.Remove();
			}
			if (newNode.IsFrozen)
			{
				throw new ArgumentException("Cannot add a frozen node.", "newNode");
			}
			newNode.parent = parent;
			newNode.SetRole(Role);
			newNode.prevSibling = prevSibling;
			newNode.nextSibling = nextSibling;
			if (prevSibling != null)
			{
				Debug.Assert(prevSibling.nextSibling == this);
				prevSibling.nextSibling = newNode;
			}
			else
			{
				Debug.Assert(parent.firstChild == this);
				parent.firstChild = newNode;
			}
			if (nextSibling != null)
			{
				Debug.Assert(nextSibling.prevSibling == this);
				nextSibling.prevSibling = newNode;
			}
			else
			{
				Debug.Assert(parent.lastChild == this);
				parent.lastChild = newNode;
			}
			parent = null;
			prevSibling = null;
			nextSibling = null;
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
		Role role = Role;
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
		astNode.firstChild = null;
		astNode.lastChild = null;
		astNode.prevSibling = null;
		astNode.nextSibling = null;
		astNode.flags &= 4294966783u;
		for (AstNode astNode2 = firstChild; astNode2 != null; astNode2 = astNode2.nextSibling)
		{
			astNode.AddChildUnsafe(astNode2.Clone(), astNode2.Role);
		}
		astNode.CloneAnnotations();
		return astNode;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public abstract void AcceptVisitor(IAstVisitor visitor);

	public abstract T AcceptVisitor<T>(IAstVisitor<T> visitor);

	public abstract S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data);

	protected static bool MatchString(string pattern, string text)
	{
		return Pattern.MatchString(pattern, text);
	}

	protected internal abstract bool DoMatch(AstNode other, Match match);

	bool INode.DoMatch(INode other, Match match)
	{
		AstNode astNode = other as AstNode;
		return (other == null || astNode != null) && DoMatch(astNode, match);
	}

	bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
	{
		AstNode astNode = pos as AstNode;
		return (pos == null || astNode != null) && DoMatch(astNode, match);
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

	public AstNode GetNextNode(Func<AstNode, bool> pred)
	{
		AstNode nextNode = GetNextNode();
		while (nextNode != null && !pred(nextNode))
		{
			nextNode = nextNode.GetNextNode();
		}
		return nextNode;
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

	public AstNode GetPrevNode(Func<AstNode, bool> pred)
	{
		AstNode prevNode = GetPrevNode();
		while (prevNode != null && !pred(prevNode))
		{
			prevNode = prevNode.GetPrevNode();
		}
		return prevNode;
	}

	public AstNode GetCSharpNodeBefore(AstNode node)
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

	public AstNode GetNextSibling(Func<AstNode, bool> pred)
	{
		AstNode astNode = NextSibling;
		while (astNode != null && !pred(astNode))
		{
			astNode = astNode.NextSibling;
		}
		return astNode;
	}

	public AstNode GetPrevSibling(Func<AstNode, bool> pred)
	{
		AstNode astNode = PrevSibling;
		while (astNode != null && !pred(astNode))
		{
			astNode = astNode.PrevSibling;
		}
		return astNode;
	}

	public AstNode GetNodeAt(int line, int column, Predicate<AstNode> pred = null)
	{
		return GetNodeAt(new TextLocation(line, column), pred);
	}

	public AstNode GetNodeAt(TextLocation location, Predicate<AstNode> pred = null)
	{
		AstNode result = null;
		AstNode astNode = this;
		while (astNode.LastChild != null)
		{
			AstNode astNode2 = astNode.LastChild;
			while (astNode2 != null && astNode2.StartLocation > location)
			{
				astNode2 = astNode2.prevSibling;
			}
			if (astNode2 != null && location < astNode2.EndLocation)
			{
				if (pred == null || pred(astNode2))
				{
					result = astNode2;
				}
				astNode = astNode2;
				continue;
			}
			break;
		}
		return result;
	}

	public T GetNodeAt<T>(int line, int column) where T : AstNode
	{
		return GetNodeAt<T>(new TextLocation(line, column));
	}

	public T GetNodeAt<T>(TextLocation location) where T : AstNode
	{
		T result = null;
		AstNode astNode = this;
		while (astNode.LastChild != null)
		{
			AstNode astNode2 = astNode.LastChild;
			while (astNode2 != null && astNode2.StartLocation > location)
			{
				astNode2 = astNode2.prevSibling;
			}
			if (astNode2 != null && location < astNode2.EndLocation)
			{
				if (astNode2 is T)
				{
					result = (T)astNode2;
				}
				astNode = astNode2;
				continue;
			}
			break;
		}
		return result;
	}

	public AstNode GetAdjacentNodeAt(int line, int column, Predicate<AstNode> pred = null)
	{
		return GetAdjacentNodeAt(new TextLocation(line, column), pred);
	}

	public AstNode GetAdjacentNodeAt(TextLocation location, Predicate<AstNode> pred = null)
	{
		AstNode result = null;
		AstNode astNode = this;
		while (astNode.LastChild != null)
		{
			AstNode astNode2 = astNode.LastChild;
			while (astNode2 != null && astNode2.StartLocation > location)
			{
				astNode2 = astNode2.prevSibling;
			}
			if (astNode2 != null && location <= astNode2.EndLocation)
			{
				if (pred == null || pred(astNode2))
				{
					result = astNode2;
				}
				astNode = astNode2;
				continue;
			}
			break;
		}
		return result;
	}

	public T GetAdjacentNodeAt<T>(int line, int column) where T : AstNode
	{
		return GetAdjacentNodeAt<T>(new TextLocation(line, column));
	}

	public T GetAdjacentNodeAt<T>(TextLocation location) where T : AstNode
	{
		T result = null;
		AstNode astNode = this;
		while (astNode.LastChild != null)
		{
			AstNode astNode2 = astNode.LastChild;
			while (astNode2 != null && astNode2.StartLocation > location)
			{
				astNode2 = astNode2.prevSibling;
			}
			if (astNode2 != null && location <= astNode2.EndLocation)
			{
				if (astNode2 is T)
				{
					result = (T)astNode2;
				}
				astNode = astNode2;
				continue;
			}
			break;
		}
		return result;
	}

	public AstNode GetNodeContaining(TextLocation startLocation, TextLocation endLocation)
	{
		for (AstNode astNode = firstChild; astNode != null; astNode = astNode.nextSibling)
		{
			if (astNode.StartLocation <= startLocation && endLocation <= astNode.EndLocation)
			{
				return astNode.GetNodeContaining(startLocation, endLocation);
			}
		}
		return this;
	}

	public IEnumerable<AstNode> GetNodesBetween(int startLine, int startColumn, int endLine, int endColumn)
	{
		return GetNodesBetween(new TextLocation(startLine, startColumn), new TextLocation(endLine, endColumn));
	}

	public IEnumerable<AstNode> GetNodesBetween(TextLocation start, TextLocation end)
	{
		AstNode node = this;
		while (node != null)
		{
			AstNode next;
			if (!(start <= node.StartLocation) || !(node.EndLocation <= end))
			{
				next = ((!(node.EndLocation <= start)) ? node.FirstChild : node.GetNextNode());
			}
			else
			{
				next = node.GetNextNode();
				yield return node;
			}
			if (next != null && next.StartLocation > end)
			{
				break;
			}
			node = next;
		}
	}

	public virtual string ToString(CSharpFormattingOptions formattingOptions)
	{
		if (IsNull)
		{
			return "";
		}
		StringWriter stringWriter = new StringWriter();
		AcceptVisitor(new CSharpOutputVisitor(stringWriter, formattingOptions ?? FormattingOptionsFactory.CreateMono()));
		return stringWriter.ToString();
	}

	public sealed override string ToString()
	{
		return ToString(null);
	}

	public bool Contains(int line, int column)
	{
		return Contains(new TextLocation(line, column));
	}

	public bool Contains(TextLocation location)
	{
		return StartLocation <= location && location < EndLocation;
	}

	public bool IsInside(int line, int column)
	{
		return IsInside(new TextLocation(line, column));
	}

	public bool IsInside(TextLocation location)
	{
		return StartLocation <= location && location <= EndLocation;
	}

	public override void AddAnnotation(object annotation)
	{
		if (IsNull)
		{
			throw new InvalidOperationException("Cannot add annotations to the null node");
		}
		base.AddAnnotation(annotation);
	}

	internal string DebugToString()
	{
		if (IsNull)
		{
			return "Null";
		}
		string text = ToString();
		text = text.TrimEnd(Array.Empty<char>()).Replace("\t", "").Replace(Environment.NewLine, " ");
		if (text.Length > 100)
		{
			return text.Substring(0, 97) + "...";
		}
		return text;
	}
}
