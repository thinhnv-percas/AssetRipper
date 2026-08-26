using System;
using System.ComponentModel;
using ICSharpCode.NRefactory.MonoCSharp;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class OperatorDeclaration : EntityDeclaration
{
	public static readonly TokenRole OperatorKeywordRole = new TokenRole("operator");

	public static readonly TokenRole LogicalNotRole = new TokenRole("!");

	public static readonly TokenRole OnesComplementRole = new TokenRole("~");

	public static readonly TokenRole IncrementRole = new TokenRole("++");

	public static readonly TokenRole DecrementRole = new TokenRole("--");

	public static readonly TokenRole TrueRole = new TokenRole("true");

	public static readonly TokenRole FalseRole = new TokenRole("false");

	public static readonly TokenRole AdditionRole = new TokenRole("+");

	public static readonly TokenRole SubtractionRole = new TokenRole("-");

	public static readonly TokenRole MultiplyRole = new TokenRole("*");

	public static readonly TokenRole DivisionRole = new TokenRole("/");

	public static readonly TokenRole ModulusRole = new TokenRole("%");

	public static readonly TokenRole BitwiseAndRole = new TokenRole("&");

	public static readonly TokenRole BitwiseOrRole = new TokenRole("|");

	public static readonly TokenRole ExclusiveOrRole = new TokenRole("^");

	public static readonly TokenRole LeftShiftRole = new TokenRole("<<");

	public static readonly TokenRole RightShiftRole = new TokenRole(">>");

	public static readonly TokenRole EqualityRole = new TokenRole("==");

	public static readonly TokenRole InequalityRole = new TokenRole("!=");

	public static readonly TokenRole GreaterThanRole = new TokenRole(">");

	public static readonly TokenRole LessThanRole = new TokenRole("<");

	public static readonly TokenRole GreaterThanOrEqualRole = new TokenRole(">=");

	public static readonly TokenRole LessThanOrEqualRole = new TokenRole("<=");

	public static readonly TokenRole ExplicitRole = new TokenRole("explicit");

	public static readonly TokenRole ImplicitRole = new TokenRole("implicit");

	private OperatorType operatorType;

	public override SymbolKind SymbolKind => SymbolKind.Operator;

	public OperatorType OperatorType
	{
		get
		{
			return operatorType;
		}
		set
		{
			ThrowIfFrozen();
			operatorType = value;
		}
	}

	public CSharpTokenNode OperatorToken => GetChildByRole(OperatorKeywordRole);

	public CSharpTokenNode OperatorTypeToken => GetChildByRole(GetRole(OperatorType));

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public BlockStatement Body
	{
		get
		{
			return GetChildByRole(Roles.Body);
		}
		set
		{
			SetChildByRole(Roles.Body, value);
		}
	}

	public override string Name
	{
		get
		{
			return GetName(OperatorType);
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

	public static OperatorType? GetOperatorType(string methodName)
	{
		return (OperatorType?)Operator.GetType(methodName);
	}

	public static TokenRole GetRole(OperatorType type)
	{
		switch (type)
		{
		case OperatorType.LogicalNot:
			return LogicalNotRole;
		case OperatorType.OnesComplement:
			return OnesComplementRole;
		case OperatorType.Increment:
			return IncrementRole;
		case OperatorType.Decrement:
			return DecrementRole;
		case OperatorType.True:
			return TrueRole;
		case OperatorType.False:
			return FalseRole;
		case OperatorType.Addition:
		case OperatorType.UnaryPlus:
			return AdditionRole;
		case OperatorType.Subtraction:
		case OperatorType.UnaryNegation:
			return SubtractionRole;
		case OperatorType.Multiply:
			return MultiplyRole;
		case OperatorType.Division:
			return DivisionRole;
		case OperatorType.Modulus:
			return ModulusRole;
		case OperatorType.BitwiseAnd:
			return BitwiseAndRole;
		case OperatorType.BitwiseOr:
			return BitwiseOrRole;
		case OperatorType.ExclusiveOr:
			return ExclusiveOrRole;
		case OperatorType.LeftShift:
			return LeftShiftRole;
		case OperatorType.RightShift:
			return RightShiftRole;
		case OperatorType.Equality:
			return EqualityRole;
		case OperatorType.Inequality:
			return InequalityRole;
		case OperatorType.GreaterThan:
			return GreaterThanRole;
		case OperatorType.LessThan:
			return LessThanRole;
		case OperatorType.GreaterThanOrEqual:
			return GreaterThanOrEqualRole;
		case OperatorType.LessThanOrEqual:
			return LessThanOrEqualRole;
		case OperatorType.Implicit:
			return ImplicitRole;
		case OperatorType.Explicit:
			return ExplicitRole;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public static string GetName(OperatorType type)
	{
		return Operator.GetMetadataName((Operator.OpType)type);
	}

	public static string GetToken(OperatorType type)
	{
		return Operator.GetName((Operator.OpType)type);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitOperatorDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitOperatorDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitOperatorDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is OperatorDeclaration operatorDeclaration && MatchAttributesAndModifiers(operatorDeclaration, match) && OperatorType == operatorDeclaration.OperatorType && ReturnType.DoMatch(operatorDeclaration.ReturnType, match) && Parameters.DoMatch(operatorDeclaration.Parameters, match))
		{
			return Body.DoMatch(operatorDeclaration.Body, match);
		}
		return false;
	}
}
