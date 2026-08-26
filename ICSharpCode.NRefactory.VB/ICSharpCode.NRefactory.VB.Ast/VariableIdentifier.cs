using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class VariableIdentifier : AstNode
{
	private sealed class NullVariableIdentifier : VariableIdentifier
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

	public new static readonly VariableIdentifier Null = new NullVariableIdentifier();

	public static readonly Role<VariableIdentifier> VariableIdentifierRole = new Role<VariableIdentifier>("VariableIdentifier", Null);

	public Identifier Name
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

	public bool HasNullableSpecifier { get; set; }

	public AstNodeCollection<Expression> ArraySizeSpecifiers => GetChildrenByRole(Roles.Argument);

	public AstNodeCollection<ArraySpecifier> ArraySpecifiers => GetChildrenByRole(ComposedType.ArraySpecifierRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitVariableIdentifier(this, data);
	}
}
