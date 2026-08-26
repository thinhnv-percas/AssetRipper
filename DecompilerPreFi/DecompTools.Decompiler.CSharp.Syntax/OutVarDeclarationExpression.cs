using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class OutVarDeclarationExpression : Expression
{
	public static readonly TokenRole OutKeywordRole = DirectionExpression.OutKeywordRole;

	public CSharpTokenNode OutKeywordToken => GetChildByRole(OutKeywordRole);

	public AstType Type
	{
		get
		{
			return GetChildByRole(Roles.Type);
		}
		set
		{
			SetChildByRole(Roles.Type, value);
		}
	}

	public VariableInitializer Variable
	{
		get
		{
			return GetChildByRole(Roles.Variable);
		}
		set
		{
			SetChildByRole(Roles.Variable, value);
		}
	}

	public OutVarDeclarationExpression()
	{
	}

	public OutVarDeclarationExpression(AstType type, string name)
	{
		Type = type;
		Variable = new VariableInitializer(name);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitOutVarDeclarationExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitOutVarDeclarationExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitOutVarDeclarationExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is OutVarDeclarationExpression outVarDeclarationExpression && Type.DoMatch(outVarDeclarationExpression.Type, match) && Variable.DoMatch(outVarDeclarationExpression.Variable, match);
	}
}
