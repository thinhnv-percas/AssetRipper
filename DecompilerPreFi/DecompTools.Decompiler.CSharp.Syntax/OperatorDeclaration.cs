using System;
using System.ComponentModel;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class OperatorDeclaration : EntityDeclaration
{
	public static readonly TokenRole OperatorKeywordRole;

	public static readonly TokenRole LogicalNotRole;

	public static readonly TokenRole OnesComplementRole;

	public static readonly TokenRole IncrementRole;

	public static readonly TokenRole DecrementRole;

	public static readonly TokenRole TrueRole;

	public static readonly TokenRole FalseRole;

	public static readonly TokenRole AdditionRole;

	public static readonly TokenRole SubtractionRole;

	public static readonly TokenRole MultiplyRole;

	public static readonly TokenRole DivisionRole;

	public static readonly TokenRole ModulusRole;

	public static readonly TokenRole BitwiseAndRole;

	public static readonly TokenRole BitwiseOrRole;

	public static readonly TokenRole ExclusiveOrRole;

	public static readonly TokenRole LeftShiftRole;

	public static readonly TokenRole RightShiftRole;

	public static readonly TokenRole EqualityRole;

	public static readonly TokenRole InequalityRole;

	public static readonly TokenRole GreaterThanRole;

	public static readonly TokenRole LessThanRole;

	public static readonly TokenRole GreaterThanOrEqualRole;

	public static readonly TokenRole LessThanOrEqualRole;

	public static readonly TokenRole ExplicitRole;

	public static readonly TokenRole ImplicitRole;

	private static readonly string[][] names;

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

	static OperatorDeclaration()
	{
		OperatorKeywordRole = new TokenRole("operator");
		LogicalNotRole = new TokenRole("!");
		OnesComplementRole = new TokenRole("~");
		IncrementRole = new TokenRole("++");
		DecrementRole = new TokenRole("--");
		TrueRole = new TokenRole("true");
		FalseRole = new TokenRole("false");
		AdditionRole = new TokenRole("+");
		SubtractionRole = new TokenRole("-");
		MultiplyRole = new TokenRole("*");
		DivisionRole = new TokenRole("/");
		ModulusRole = new TokenRole("%");
		BitwiseAndRole = new TokenRole("&");
		BitwiseOrRole = new TokenRole("|");
		ExclusiveOrRole = new TokenRole("^");
		LeftShiftRole = new TokenRole("<<");
		RightShiftRole = new TokenRole(">>");
		EqualityRole = new TokenRole("==");
		InequalityRole = new TokenRole("!=");
		GreaterThanRole = new TokenRole(">");
		LessThanRole = new TokenRole("<");
		GreaterThanOrEqualRole = new TokenRole(">=");
		LessThanOrEqualRole = new TokenRole("<=");
		ExplicitRole = new TokenRole("explicit");
		ImplicitRole = new TokenRole("implicit");
		names = new string[26][];
		names[0] = new string[2] { "!", "op_LogicalNot" };
		names[1] = new string[2] { "~", "op_OnesComplement" };
		names[2] = new string[2] { "++", "op_Increment" };
		names[3] = new string[2] { "--", "op_Decrement" };
		names[4] = new string[2] { "true", "op_True" };
		names[5] = new string[2] { "false", "op_False" };
		names[6] = new string[2] { "+", "op_Addition" };
		names[7] = new string[2] { "-", "op_Subtraction" };
		names[8] = new string[2] { "+", "op_UnaryPlus" };
		names[9] = new string[2] { "-", "op_UnaryNegation" };
		names[10] = new string[2] { "*", "op_Multiply" };
		names[11] = new string[2] { "/", "op_Division" };
		names[12] = new string[2] { "%", "op_Modulus" };
		names[13] = new string[2] { "&", "op_BitwiseAnd" };
		names[14] = new string[2] { "|", "op_BitwiseOr" };
		names[15] = new string[2] { "^", "op_ExclusiveOr" };
		names[16] = new string[2] { "<<", "op_LeftShift" };
		names[17] = new string[2] { ">>", "op_RightShift" };
		names[18] = new string[2] { "==", "op_Equality" };
		names[19] = new string[2] { "!=", "op_Inequality" };
		names[20] = new string[2] { ">", "op_GreaterThan" };
		names[21] = new string[2] { "<", "op_LessThan" };
		names[22] = new string[2] { ">=", "op_GreaterThanOrEqual" };
		names[23] = new string[2] { "<=", "op_LessThanOrEqual" };
		names[24] = new string[2] { "implicit", "op_Implicit" };
		names[25] = new string[2] { "explicit", "op_Explicit" };
	}

	public static OperatorType? GetOperatorType(string methodName)
	{
		for (int i = 0; i < names.Length; i = checked(i + 1))
		{
			if (names[i][1] == methodName)
			{
				return (OperatorType)i;
			}
		}
		return null;
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

	public static string GetName(OperatorType? type)
	{
		if (!type.HasValue)
		{
			return null;
		}
		return names[(int)type.Value][1];
	}

	public static string GetToken(OperatorType type)
	{
		return names[(int)type][0];
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
		return other is OperatorDeclaration operatorDeclaration && MatchAttributesAndModifiers(operatorDeclaration, match) && OperatorType == operatorDeclaration.OperatorType && ReturnType.DoMatch(operatorDeclaration.ReturnType, match) && Parameters.DoMatch(operatorDeclaration.Parameters, match) && Body.DoMatch(operatorDeclaration.Body, match);
	}
}
