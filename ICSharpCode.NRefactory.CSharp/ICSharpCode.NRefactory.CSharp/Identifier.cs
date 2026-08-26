using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class Identifier : AstNode
{
	private sealed class NullIdentifier : Identifier
	{
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

	public new static readonly Identifier Null = new NullIdentifier();

	private string name;

	private TextLocation startLocation;

	private const uint verbatimBit = 1024u;

	public override NodeType NodeType => NodeType.Token;

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			ThrowIfFrozen();
			name = value;
		}
	}

	public override TextLocation StartLocation => startLocation;

	public bool IsVerbatim
	{
		get
		{
			return (flags & 0x400) != 0;
		}
		set
		{
			ThrowIfFrozen();
			if (value)
			{
				flags |= 1024u;
			}
			else
			{
				flags &= 4294966271u;
			}
		}
	}

	public override TextLocation EndLocation => new TextLocation(StartLocation.Line, StartLocation.Column + (Name ?? "").Length + (IsVerbatim ? 1 : 0));

	internal void SetStartLocation(TextLocation value)
	{
		ThrowIfFrozen();
		startLocation = value;
	}

	private Identifier()
	{
		name = string.Empty;
	}

	protected Identifier(string name, TextLocation location)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		Name = name;
		startLocation = location;
	}

	public static Identifier Create(string name)
	{
		return Create(name, TextLocation.Empty);
	}

	public static Identifier Create(string name, TextLocation location)
	{
		if (name == null)
		{
			return Null;
		}
		if (name.Length > 0 && name[0] == '@')
		{
			return new Identifier(name.Substring(1), new TextLocation(location.Line, location.Column + 1))
			{
				IsVerbatim = true
			};
		}
		return new Identifier(name, location);
	}

	public static Identifier Create(string name, TextLocation location, bool isVerbatim)
	{
		if (name == null)
		{
			return Null;
		}
		if (isVerbatim)
		{
			return new Identifier(name, location)
			{
				IsVerbatim = true
			};
		}
		return new Identifier(name, location);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitIdentifier(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitIdentifier(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitIdentifier(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is Identifier { IsNull: false } identifier)
		{
			return AstNode.MatchString(Name, identifier.Name);
		}
		return false;
	}
}
