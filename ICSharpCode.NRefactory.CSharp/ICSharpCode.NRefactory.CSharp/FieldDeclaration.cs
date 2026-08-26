using System;
using System.ComponentModel;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class FieldDeclaration : EntityDeclaration
{
	public override SymbolKind SymbolKind => SymbolKind.Field;

	public AstNodeCollection<VariableInitializer> Variables => GetChildrenByRole(Roles.Variable);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string Name
	{
		get
		{
			return string.Empty;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Identifier NameToken
	{
		get
		{
			return Identifier.Null;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitFieldDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitFieldDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitFieldDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is FieldDeclaration fieldDeclaration && MatchAttributesAndModifiers(fieldDeclaration, match) && ReturnType.DoMatch(fieldDeclaration.ReturnType, match))
		{
			return Variables.DoMatch(fieldDeclaration.Variables, match);
		}
		return false;
	}
}
