using System;
using System.Collections.Generic;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class Identifier : AstNode
{
	private class NullIdentifier : Identifier
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

	public new static readonly Identifier Null = new NullIdentifier();

	private string name;

	private TextLocation startLocation;

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
			name = value;
		}
	}

	public TypeCode TypeCharacter { get; set; }

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => new TextLocation(StartLocation.Line, StartLocation.Column + Name.Length);

	private Identifier()
	{
		name = string.Empty;
	}

	public Identifier(object annotation, string name, TextLocation location)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		Name = name;
		if (annotation != null)
		{
			AddAnnotation(annotation);
		}
		startLocation = location;
	}

	public static Identifier Create(object annotation, string name)
	{
		return new Identifier(annotation, name, TextLocation.Empty);
	}

	public static Identifier Create(IEnumerable<object> annotations, string name)
	{
		return Create(annotations, name, TextLocation.Empty);
	}

	public static Identifier Create(IEnumerable<object> annotations, string name, TextLocation textLoc)
	{
		Identifier identifier = new Identifier(null, name, textLoc);
		if (annotations != null)
		{
			foreach (object annotation in annotations)
			{
				identifier.AddAnnotation(annotation);
			}
		}
		return identifier;
	}

	public static Identifier CreateLiteralField(string name)
	{
		return new Identifier(BoxedTextColor.LiteralField, name, TextLocation.Empty);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is Identifier identifier && AstNode.MatchString(identifier.name, name))
		{
			return identifier.TypeCharacter == TypeCharacter;
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitIdentifier(this, data);
	}

	public override string ToString()
	{
		return $"{name}";
	}
}
