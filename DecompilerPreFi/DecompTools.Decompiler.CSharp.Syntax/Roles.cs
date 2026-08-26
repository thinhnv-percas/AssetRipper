namespace DecompTools.Decompiler.CSharp.Syntax;

public static class Roles
{
	public static readonly Role<AstNode> Root = AstNode.RootRole;

	public static readonly Role<Identifier> Identifier = new Role<Identifier>("Identifier", DecompTools.Decompiler.CSharp.Syntax.Identifier.Null);

	public static readonly Role<BlockStatement> Body = new Role<BlockStatement>("Body", BlockStatement.Null);

	public static readonly Role<ParameterDeclaration> Parameter = new Role<ParameterDeclaration>("Parameter");

	public static readonly Role<Expression> Argument = new Role<Expression>("Argument", DecompTools.Decompiler.CSharp.Syntax.Expression.Null);

	public static readonly Role<AstType> Type = new Role<AstType>("Type", AstType.Null);

	public static readonly Role<Expression> Expression = new Role<Expression>("Expression", DecompTools.Decompiler.CSharp.Syntax.Expression.Null);

	public static readonly Role<Expression> TargetExpression = new Role<Expression>("Target", DecompTools.Decompiler.CSharp.Syntax.Expression.Null);

	public static readonly Role<Expression> Condition = new Role<Expression>("Condition", DecompTools.Decompiler.CSharp.Syntax.Expression.Null);

	public static readonly Role<TypeParameterDeclaration> TypeParameter = new Role<TypeParameterDeclaration>("TypeParameter");

	public static readonly Role<AstType> TypeArgument = new Role<AstType>("TypeArgument", AstType.Null);

	public static readonly Role<Constraint> Constraint = new Role<Constraint>("Constraint");

	public static readonly Role<VariableInitializer> Variable = new Role<VariableInitializer>("Variable", VariableInitializer.Null);

	public static readonly Role<Statement> EmbeddedStatement = new Role<Statement>("EmbeddedStatement", Statement.Null);

	public static readonly Role<EntityDeclaration> TypeMemberRole = new Role<EntityDeclaration>("TypeMember");

	public static readonly TokenRole LPar = new TokenRole("(");

	public static readonly TokenRole RPar = new TokenRole(")");

	public static readonly TokenRole LBracket = new TokenRole("[");

	public static readonly TokenRole RBracket = new TokenRole("]");

	public static readonly TokenRole LBrace = new TokenRole("{");

	public static readonly TokenRole RBrace = new TokenRole("}");

	public static readonly TokenRole LChevron = new TokenRole("<");

	public static readonly TokenRole RChevron = new TokenRole(">");

	public static readonly TokenRole Comma = new TokenRole(",");

	public static readonly TokenRole Dot = new TokenRole(".");

	public static readonly TokenRole Semicolon = new TokenRole(";");

	public static readonly TokenRole Assign = new TokenRole("=");

	public static readonly TokenRole Colon = new TokenRole(":");

	public static readonly TokenRole DoubleColon = new TokenRole("::");

	public static readonly TokenRole Arrow = new TokenRole("=>");

	public static readonly Role<Comment> Comment = new Role<Comment>("Comment");

	public static readonly Role<NewLineNode> NewLine = new Role<NewLineNode>("NewLine");

	public static readonly Role<WhitespaceNode> Whitespace = new Role<WhitespaceNode>("Whitespace");

	public static readonly Role<TextNode> Text = new Role<TextNode>("Text");

	public static readonly Role<PreProcessorDirective> PreProcessorDirective = new Role<PreProcessorDirective>("PreProcessorDirective");

	public static readonly Role<ErrorNode> Error = new Role<ErrorNode>("Error");

	public static readonly Role<AstType> BaseType = new Role<AstType>("BaseType", AstType.Null);

	public static readonly Role<Attribute> Attribute = new Role<Attribute>("Attribute");

	public static readonly Role<CSharpTokenNode> AttributeTargetRole = new Role<CSharpTokenNode>("AttributeTarget", CSharpTokenNode.Null);

	public static readonly TokenRole WhereKeyword = new TokenRole("where");

	public static readonly Role<SimpleType> ConstraintTypeParameter = new Role<SimpleType>("TypeParameter", SimpleType.Null);

	public static readonly TokenRole DelegateKeyword = new TokenRole("delegate");

	public static readonly TokenRole ExternKeyword = new TokenRole("extern");

	public static readonly TokenRole AliasKeyword = new TokenRole("alias");

	public static readonly TokenRole NamespaceKeyword = new TokenRole("namespace");

	public static readonly TokenRole EnumKeyword = new TokenRole("enum");

	public static readonly TokenRole InterfaceKeyword = new TokenRole("interface");

	public static readonly TokenRole StructKeyword = new TokenRole("struct");

	public static readonly TokenRole ClassKeyword = new TokenRole("class");
}
