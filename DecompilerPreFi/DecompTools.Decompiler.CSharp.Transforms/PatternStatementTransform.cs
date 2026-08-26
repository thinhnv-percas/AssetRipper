#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public sealed class PatternStatementTransform : ContextTrackingVisitor<AstNode>, IAstTransform
{
	private readonly DeclareVariables declareVariables = new DeclareVariables();

	private TransformContext context;

	private static readonly AstNode variableAssignPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new AnyNode("initializer")));

	private static readonly WhileStatement forPattern = new WhileStatement
	{
		Condition = new BinaryOperatorExpression
		{
			Left = new NamedNode("ident", new IdentifierExpression(Pattern.AnyString)),
			Operator = BinaryOperatorType.Any,
			Right = new AnyNode("endExpr")
		},
		EmbeddedStatement = new BlockStatement
		{
			Statements = 
			{
				(Statement)new Repeat(new AnyNode("statement")),
				(Statement)new NamedNode("increment", new ExpressionStatement(new AssignmentExpression
				{
					Left = new Backreference("ident"),
					Operator = AssignmentOperatorType.Any,
					Right = new AnyNode()
				}))
			}
		}
	};

	private static readonly ForStatement forOnArrayPattern = new ForStatement
	{
		Initializers = { (Statement)new ExpressionStatement(new AssignmentExpression(new NamedNode("indexVariable", new IdentifierExpression(Pattern.AnyString)), new PrimitiveExpression(0))) },
		Condition = new BinaryOperatorExpression(new IdentifierExpressionBackreference("indexVariable"), BinaryOperatorType.LessThan, new MemberReferenceExpression(new NamedNode("arrayVariable", new IdentifierExpression(Pattern.AnyString)), "Length")),
		Iterators = { (Statement)new ExpressionStatement(new AssignmentExpression(new IdentifierExpressionBackreference("indexVariable"), new BinaryOperatorExpression(new IdentifierExpressionBackreference("indexVariable"), BinaryOperatorType.Add, new PrimitiveExpression(1)))) },
		EmbeddedStatement = new BlockStatement
		{
			Statements = 
			{
				(Statement)new ExpressionStatement(new AssignmentExpression(new NamedNode("itemVariable", new IdentifierExpression(Pattern.AnyString)), new IndexerExpression(new IdentifierExpressionBackreference("arrayVariable"), new IdentifierExpressionBackreference("indexVariable")))),
				(Statement)new Repeat(new AnyNode("statements"))
			}
		}
	};

	private static readonly ForStatement forOnArrayMultiDimPattern = new ForStatement
	{
		Condition = new BinaryOperatorExpression(new NamedNode("indexVariable", new IdentifierExpression(Pattern.AnyString)), BinaryOperatorType.LessThanOrEqual, new NamedNode("upperBoundVariable", new IdentifierExpression(Pattern.AnyString))),
		Iterators = { (Statement)new ExpressionStatement(new AssignmentExpression(new IdentifierExpressionBackreference("indexVariable"), new BinaryOperatorExpression(new IdentifierExpressionBackreference("indexVariable"), BinaryOperatorType.Add, new PrimitiveExpression(1)))) },
		EmbeddedStatement = new BlockStatement
		{
			Statements = 
			{
				(Statement)new AnyNode("lowerBoundAssign"),
				(Statement)new Repeat(new AnyNode("statements"))
			}
		}
	};

	private static readonly AstNode variableAssignUpperBoundPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new InvocationExpression(new MemberReferenceExpression(new NamedNode("collection", new IdentifierExpression(Pattern.AnyString)), "GetUpperBound"), new NamedNode("index", new PrimitiveExpression(PrimitiveExpression.AnyValue)))));

	private static readonly ExpressionStatement variableAssignLowerBoundPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new InvocationExpression(new MemberReferenceExpression(new NamedNode("collection", new IdentifierExpression(Pattern.AnyString)), "GetLowerBound"), new NamedNode("index", new PrimitiveExpression(PrimitiveExpression.AnyValue)))));

	private static readonly ExpressionStatement foreachVariableOnMultArrayAssignPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new IndexerExpression(new NamedNode("collection", new IdentifierExpression(Pattern.AnyString)), new Repeat(new NamedNode("index", new IdentifierExpression(Pattern.AnyString))))));

	private static readonly PropertyDeclaration automaticPropertyPattern = new PropertyDeclaration
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Modifiers = Modifiers.Any,
		ReturnType = new AnyNode(),
		PrivateImplementationType = new OptionalNode(new AnyNode()),
		Name = Pattern.AnyString,
		Getter = new Accessor
		{
			Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
			Modifiers = Modifiers.Any,
			Body = new BlockStatement
			{
				new ReturnStatement
				{
					Expression = new AnyNode("fieldReference")
				}
			}
		},
		Setter = new Accessor
		{
			Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
			Modifiers = Modifiers.Any,
			Body = new BlockStatement
			{
				new AssignmentExpression
				{
					Left = new Backreference("fieldReference"),
					Right = new IdentifierExpression("value")
				}
			}
		}
	};

	private static readonly PropertyDeclaration automaticReadonlyPropertyPattern = new PropertyDeclaration
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Modifiers = Modifiers.Any,
		ReturnType = new AnyNode(),
		PrivateImplementationType = new OptionalNode(new AnyNode()),
		Name = Pattern.AnyString,
		Getter = new Accessor
		{
			Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
			Modifiers = Modifiers.Any,
			Body = new BlockStatement
			{
				new ReturnStatement
				{
					Expression = new AnyNode("fieldReference")
				}
			}
		}
	};

	private static readonly Expression fieldReferencePattern = new Choice
	{
		new IdentifierExpression(Pattern.AnyString),
		new MemberReferenceExpression
		{
			Target = new Choice
			{
				new ThisReferenceExpression(),
				new TypeReferenceExpression
				{
					Type = new AnyNode()
				}
			},
			MemberName = Pattern.AnyString
		}
	};

	private static readonly Accessor automaticEventPatternV2 = new Accessor
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Body = new BlockStatement
		{
			new AssignmentExpression
			{
				Left = new NamedNode("field", fieldReferencePattern),
				Operator = AssignmentOperatorType.Assign,
				Right = new CastExpression(new AnyNode("type"), new InvocationExpression(new AnyNode("delegateCombine").ToExpression(), new Backreference("field"), new IdentifierExpression("value")))
			}
		}
	};

	private static readonly Accessor automaticEventPatternV4 = new Accessor
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Body = new BlockStatement
		{
			new AssignmentExpression
			{
				Left = new NamedNode("var1", new IdentifierExpression(Pattern.AnyString)),
				Operator = AssignmentOperatorType.Assign,
				Right = new NamedNode("field", fieldReferencePattern)
			},
			new DoWhileStatement
			{
				EmbeddedStatement = new BlockStatement
				{
					new AssignmentExpression(new NamedNode("var2", new IdentifierExpression(Pattern.AnyString)), new IdentifierExpressionBackreference("var1")),
					new AssignmentExpression
					{
						Left = new NamedNode("var3", new IdentifierExpression(Pattern.AnyString)),
						Operator = AssignmentOperatorType.Assign,
						Right = new CastExpression(new AnyNode("type"), new InvocationExpression(new AnyNode("delegateCombine").ToExpression(), new IdentifierExpressionBackreference("var2"), new IdentifierExpression("value")))
					},
					new AssignmentExpression
					{
						Left = new IdentifierExpressionBackreference("var1"),
						Right = new InvocationExpression(new MemberReferenceExpression(new TypeReferenceExpression(new TypePattern(typeof(Interlocked)).ToType()), "CompareExchange"), new DirectionExpression
						{
							FieldDirection = FieldDirection.Ref,
							Expression = new Backreference("field")
						}, new IdentifierExpressionBackreference("var3"), new IdentifierExpressionBackreference("var2"))
					}
				},
				Condition = new BinaryOperatorExpression
				{
					Left = new CastExpression(new TypePattern(typeof(object)), new IdentifierExpressionBackreference("var1")),
					Operator = BinaryOperatorType.InEquality,
					Right = new IdentifierExpressionBackreference("var2")
				}
			}
		}
	};

	private static readonly Accessor automaticEventPatternV4MCS = new Accessor
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Body = new BlockStatement
		{
			new AssignmentExpression
			{
				Left = new NamedNode("var1", new IdentifierExpression(Pattern.AnyString)),
				Operator = AssignmentOperatorType.Assign,
				Right = new NamedNode("field", new MemberReferenceExpression
				{
					Target = new Choice
					{
						new ThisReferenceExpression(),
						new TypeReferenceExpression
						{
							Type = new AnyNode()
						}
					},
					MemberName = Pattern.AnyString
				})
			},
			new DoWhileStatement
			{
				EmbeddedStatement = new BlockStatement
				{
					new AssignmentExpression(new NamedNode("var2", new IdentifierExpression(Pattern.AnyString)), new IdentifierExpressionBackreference("var1")),
					new AssignmentExpression
					{
						Left = new IdentifierExpressionBackreference("var1"),
						Right = new InvocationExpression(new MemberReferenceExpression(new TypeReferenceExpression(new TypePattern(typeof(Interlocked)).ToType()), "CompareExchange", new Repeat(new AnyNode())), new DirectionExpression
						{
							FieldDirection = FieldDirection.Ref,
							Expression = new Backreference("field")
						}, new CastExpression(new AnyNode("type"), new InvocationExpression(new AnyNode("delegateCombine").ToExpression(), new IdentifierExpressionBackreference("var2"), new IdentifierExpression("value"))), new IdentifierExpressionBackreference("var1"))
					}
				},
				Condition = new BinaryOperatorExpression
				{
					Left = new CastExpression(new TypePattern(typeof(object)), new IdentifierExpressionBackreference("var1")),
					Operator = BinaryOperatorType.InEquality,
					Right = new IdentifierExpressionBackreference("var2")
				}
			}
		}
	};

	private static readonly string[] attributeTypesToRemoveFromAutoEvents = new string[3] { "System.Runtime.CompilerServices.CompilerGeneratedAttribute", "System.Diagnostics.DebuggerBrowsableAttribute", "System.Runtime.CompilerServices.MethodImplAttribute" };

	private static readonly string[] attributeTypesToRemoveFromAutoProperties = new string[2] { "System.Runtime.CompilerServices.CompilerGeneratedAttribute", "System.Diagnostics.DebuggerBrowsableAttribute" };

	private static readonly BlockStatement destructorBodyPattern = new BlockStatement
	{
		new TryCatchStatement
		{
			TryBlock = new AnyNode("body"),
			FinallyBlock = new BlockStatement
			{
				new InvocationExpression(new MemberReferenceExpression(new BaseReferenceExpression(), "Finalize"))
			}
		}
	};

	private static readonly MethodDeclaration destructorPattern = new MethodDeclaration
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Modifiers = Modifiers.Any,
		ReturnType = new DecompTools.Decompiler.CSharp.Syntax.PrimitiveType("void"),
		Name = "Finalize",
		Body = destructorBodyPattern
	};

	private static readonly TryCatchStatement tryCatchFinallyPattern = new TryCatchStatement
	{
		TryBlock = new BlockStatement
		{
			new TryCatchStatement
			{
				TryBlock = new AnyNode(),
				CatchClauses = { (CatchClause)new Repeat(new AnyNode()) }
			}
		},
		FinallyBlock = new AnyNode()
	};

	private static readonly IfElseStatement cascadingIfElsePattern = new IfElseStatement
	{
		Condition = new AnyNode(),
		TrueStatement = new AnyNode(),
		FalseStatement = new BlockStatement
		{
			Statements = { (Statement)new NamedNode("nestedIfStatement", new IfElseStatement
			{
				Condition = new AnyNode(),
				TrueStatement = new AnyNode(),
				FalseStatement = new OptionalNode(new AnyNode())
			}) }
		}
	};

	public void Run(AstNode rootNode, TransformContext context)
	{
		if (this.context != null)
		{
			throw new InvalidOperationException("Reentrancy in PatternStatementTransform.Run?");
		}
		try
		{
			this.context = context;
			Initialize(context);
			declareVariables.Analyze(rootNode);
			rootNode.AcceptVisitor(this);
		}
		finally
		{
			this.context = null;
			Uninitialize();
			declareVariables.ClearAnalysisResults();
		}
	}

	protected override AstNode VisitChildren(AstNode node)
	{
		for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			AstNode astNode2;
			do
			{
				astNode2 = astNode;
				astNode = astNode.AcceptVisitor(this);
				Debug.Assert(astNode != null && astNode.Parent == node);
			}
			while (astNode != astNode2);
		}
		return node;
	}

	public override AstNode VisitExpressionStatement(ExpressionStatement expressionStatement)
	{
		AstNode astNode = TransformForeachOnMultiDimArray(expressionStatement);
		if (astNode != null)
		{
			return astNode;
		}
		astNode = TransformFor(expressionStatement);
		if (astNode != null)
		{
			return astNode;
		}
		return base.VisitExpressionStatement(expressionStatement);
	}

	public override AstNode VisitForStatement(ForStatement forStatement)
	{
		AstNode astNode = TransformForeachOnArray(forStatement);
		if (astNode != null)
		{
			return astNode;
		}
		return base.VisitForStatement(forStatement);
	}

	public override AstNode VisitIfElseStatement(IfElseStatement ifElseStatement)
	{
		AstNode astNode = SimplifyCascadingIfElseStatements(ifElseStatement);
		if (astNode != null)
		{
			return astNode;
		}
		return base.VisitIfElseStatement(ifElseStatement);
	}

	public override AstNode VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
	{
		if (context.Settings.AutomaticProperties)
		{
			AstNode astNode = TransformAutomaticProperties(propertyDeclaration);
			if (astNode != null)
			{
				return astNode;
			}
		}
		return base.VisitPropertyDeclaration(propertyDeclaration);
	}

	public override AstNode VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration)
	{
		base.VisitCustomEventDeclaration(eventDeclaration);
		if (context.Settings.AutomaticEvents)
		{
			AstNode astNode = TransformAutomaticEvents(eventDeclaration);
			if (astNode != null)
			{
				return astNode;
			}
		}
		return eventDeclaration;
	}

	public override AstNode VisitMethodDeclaration(MethodDeclaration methodDeclaration)
	{
		return TransformDestructor(methodDeclaration) ?? base.VisitMethodDeclaration(methodDeclaration);
	}

	public override AstNode VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
	{
		return TransformDestructorBody(destructorDeclaration) ?? base.VisitDestructorDeclaration(destructorDeclaration);
	}

	public override AstNode VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
	{
		return TransformTryCatchFinally(tryCatchStatement) ?? base.VisitTryCatchStatement(tryCatchStatement);
	}

	public ForStatement TransformFor(ExpressionStatement node)
	{
		Match match = variableAssignPattern.Match(node);
		if (!match.Success)
		{
			return null;
		}
		ILVariable iLVariable = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("variable")).GetILVariable();
		AstNode nextSibling = node.NextSibling;
		if (nextSibling is ForStatement statement && ForStatementUsesVariable(statement, iLVariable))
		{
			node.Remove();
			nextSibling.InsertChildAfter(null, node, ForStatement.InitializerRole);
			return (ForStatement)nextSibling;
		}
		Match match2 = forPattern.Match(nextSibling);
		if (!match2.Success)
		{
			return null;
		}
		if (iLVariable != Enumerable.Single<IdentifierExpression>(match2.Get<IdentifierExpression>("ident")).GetILVariable())
		{
			return null;
		}
		WhileStatement whileStatement = (WhileStatement)nextSibling;
		if (Enumerable.Any<Statement>(Enumerable.OfType<Statement>((IEnumerable)whileStatement.DescendantNodes(DescendIntoStatement)), (Func<Statement, bool>)((Statement s) => s is ContinueStatement)))
		{
			return null;
		}
		node.Remove();
		BlockStatement blockStatement = new BlockStatement();
		foreach (Statement item in match2.Get<Statement>("statement"))
		{
			blockStatement.Add(item.Detach());
		}
		ForStatement forStatement = new ForStatement();
		forStatement.CopyAnnotationsFrom(whileStatement);
		forStatement.Initializers.Add(node);
		forStatement.Condition = whileStatement.Condition.Detach();
		forStatement.Iterators.Add(Enumerable.Single<Statement>(match2.Get<Statement>("increment")).Detach());
		forStatement.EmbeddedStatement = blockStatement;
		whileStatement.ReplaceWith(forStatement);
		return forStatement;
	}

	private bool DescendIntoStatement(AstNode node)
	{
		if (node is Expression || node is ExpressionStatement)
		{
			return false;
		}
		if (node is WhileStatement || node is ForeachStatement || node is DoWhileStatement || node is ForStatement)
		{
			return false;
		}
		return true;
	}

	private bool ForStatementUsesVariable(ForStatement statement, ILVariable variable)
	{
		if (Enumerable.Any<IdentifierExpression>(Enumerable.OfType<IdentifierExpression>((IEnumerable)statement.Condition.DescendantsAndSelf), (Func<IdentifierExpression, bool>)((IdentifierExpression ie) => ie.GetILVariable() == variable)))
		{
			return true;
		}
		if (Enumerable.Any<Statement>((IEnumerable<Statement>)statement.Iterators, (Func<Statement, bool>)((Statement i) => Enumerable.Any<IdentifierExpression>(Enumerable.OfType<IdentifierExpression>((IEnumerable)i.DescendantsAndSelf), (Func<IdentifierExpression, bool>)((IdentifierExpression ie) => ie.GetILVariable() == variable)))))
		{
			return true;
		}
		return false;
	}

	private Statement TransformForeachOnArray(ForStatement forStatement)
	{
		if (!context.Settings.ForEachStatement)
		{
			return null;
		}
		Match match = forOnArrayPattern.Match(forStatement);
		if (!match.Success)
		{
			return null;
		}
		ILVariable iLVariable = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("itemVariable")).GetILVariable();
		ILVariable iLVariable2 = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("indexVariable")).GetILVariable();
		ILVariable iLVariable3 = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("arrayVariable")).GetILVariable();
		BlockContainer blockContainer = forStatement.Annotation<BlockContainer>();
		if (iLVariable == null || iLVariable2 == null || iLVariable3 == null)
		{
			return null;
		}
		if (!iLVariable.IsSingleDefinition || (iLVariable.CaptureScope != null && iLVariable.CaptureScope != blockContainer))
		{
			return null;
		}
		if (iLVariable2.StoreCount != 2 || iLVariable2.LoadCount != 3 || iLVariable2.AddressCount != 0)
		{
			return null;
		}
		BlockStatement blockStatement = new BlockStatement();
		foreach (Statement item in match.Get<Statement>("statements"))
		{
			blockStatement.Statements.Add(item.Detach());
		}
		ForeachStatement foreachStatement = new ForeachStatement
		{
			VariableType = ((context.Settings.AnonymousTypes && iLVariable.Type.ContainsAnonymousType()) ? new SimpleType("var") : context.TypeSystemAstBuilder.ConvertType(iLVariable.Type)),
			VariableName = iLVariable.Name,
			InExpression = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("arrayVariable")).Detach(),
			EmbeddedStatement = blockStatement
		};
		foreachStatement.CopyAnnotationsFrom(forStatement);
		iLVariable.Kind = VariableKind.ForeachLocal;
		foreachStatement.AddAnnotation(new ILVariableResolveResult(iLVariable, iLVariable.Type));
		forStatement.ReplaceWith(foreachStatement);
		return foreachStatement;
	}

	private bool MatchLowerBound(int indexNum, out ILVariable index, ILVariable collection, Statement statement)
	{
		index = null;
		Match match = variableAssignLowerBoundPattern.Match(statement);
		if (!match.Success)
		{
			return false;
		}
		if (!int.TryParse(Enumerable.Single<PrimitiveExpression>(match.Get<PrimitiveExpression>("index")).Value.ToString(), out var result) || indexNum != result)
		{
			return false;
		}
		index = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("variable")).GetILVariable();
		return Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("collection")).GetILVariable() == collection;
	}

	private bool MatchForeachOnMultiDimArray(ILVariable[] upperBounds, ILVariable collection, Statement firstInitializerStatement, out IdentifierExpression foreachVariable, out IList<Statement> statements, out ILVariable[] lowerBounds)
	{
		int i = 0;
		foreachVariable = null;
		statements = null;
		lowerBounds = new ILVariable[upperBounds.Length];
		Statement statement = firstInitializerStatement;
		Match match = default(Match);
		ILVariable index;
		for (; i < upperBounds.Length && MatchLowerBound(i, out index, collection, statement); i = checked(i + 1))
		{
			match = forOnArrayMultiDimPattern.Match(statement.GetNextStatement());
			if (!match.Success)
			{
				return false;
			}
			ILVariable iLVariable = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("upperBoundVariable")).GetILVariable();
			if (upperBounds[i] != iLVariable)
			{
				return false;
			}
			statement = Enumerable.Single<Statement>(match.Get<Statement>("lowerBoundAssign"));
			lowerBounds[i] = index;
		}
		Match match2 = foreachVariableOnMultArrayAssignPattern.Match(statement);
		if (!match2.Success)
		{
			return false;
		}
		ILVariable iLVariable2 = Enumerable.Single<IdentifierExpression>(match2.Get<IdentifierExpression>("collection")).GetILVariable();
		if (iLVariable2 != collection)
		{
			return false;
		}
		foreachVariable = Enumerable.Single<IdentifierExpression>(match2.Get<IdentifierExpression>("variable"));
		statements = Enumerable.ToList<Statement>(match.Get<Statement>("statements"));
		return true;
	}

	private Statement TransformForeachOnMultiDimArray(ExpressionStatement expressionStatement)
	{
		if (!context.Settings.ForEachStatement)
		{
			return null;
		}
		Statement statement = expressionStatement;
		ILVariable iLVariable = null;
		ILVariable[] array = null;
		List<Statement> list = new List<Statement>();
		int num = 0;
		Match match;
		do
		{
			match = variableAssignUpperBoundPattern.Match(statement);
			if (!match.Success)
			{
				break;
			}
			if (array == null)
			{
				iLVariable = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("collection")).GetILVariable();
				if (!(iLVariable?.Type is ArrayType arrayType))
				{
					break;
				}
				array = new ILVariable[arrayType.Dimensions];
			}
			else
			{
				list.Add(statement);
			}
			ILVariable iLVariable2 = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("collection")).GetILVariable();
			if (iLVariable2 != iLVariable || !int.TryParse(Enumerable.Single<PrimitiveExpression>(match.Get<PrimitiveExpression>("index")).Value?.ToString() ?? "", out var result) || result != num)
			{
				break;
			}
			array[num] = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("variable")).GetILVariable();
			statement = statement.GetNextStatement();
			num = checked(num + 1);
		}
		while (statement != null && num < array.Length);
		if (((array != null) ? Enumerable.LastOrDefault<ILVariable>((IEnumerable<ILVariable>)array) : null) == null || iLVariable == null)
		{
			return null;
		}
		if (!MatchForeachOnMultiDimArray(array, iLVariable, statement, out var foreachVariable, out var statements, out var lowerBounds))
		{
			return null;
		}
		list.Add(statement);
		list.Add(statement.GetNextStatement());
		ILVariable iLVariable3 = foreachVariable.GetILVariable();
		if (iLVariable3 == null || !iLVariable3.IsSingleDefinition || !Enumerable.All<ILVariable>((IEnumerable<ILVariable>)array, (Func<ILVariable, bool>)((ILVariable ub) => ub.IsSingleDefinition && ub.LoadCount == 1)) || !Enumerable.All<ILVariable>((IEnumerable<ILVariable>)lowerBounds, (Func<ILVariable, bool>)((ILVariable lb) => lb.StoreCount == 2 && lb.LoadCount == 3 && lb.AddressCount == 0)))
		{
			return null;
		}
		BlockStatement blockStatement = new BlockStatement();
		foreach (Statement item in statements)
		{
			blockStatement.Statements.Add(item.Detach());
		}
		ForeachStatement foreachStatement = new ForeachStatement
		{
			VariableType = ((context.Settings.AnonymousTypes && iLVariable3.Type.ContainsAnonymousType()) ? new SimpleType("var") : context.TypeSystemAstBuilder.ConvertType(iLVariable3.Type)),
			VariableName = iLVariable3.Name,
			InExpression = Enumerable.Single<IdentifierExpression>(match.Get<IdentifierExpression>("collection")).Detach(),
			EmbeddedStatement = blockStatement
		};
		foreach (Statement item2 in list)
		{
			item2.Detach();
		}
		iLVariable3.Kind = VariableKind.ForeachLocal;
		foreachStatement.AddAnnotation(new ILVariableResolveResult(iLVariable3, iLVariable3.Type));
		expressionStatement.ReplaceWith(foreachStatement);
		return foreachStatement;
	}

	private PropertyDeclaration TransformAutomaticProperties(PropertyDeclaration propertyDeclaration)
	{
		IProperty property = propertyDeclaration.GetSymbol() as IProperty;
		if (property.CanGet)
		{
			if (!property.Getter.IsCompilerGenerated())
			{
				IMethod setter = property.Setter;
				if (setter != null && !setter.IsCompilerGenerated())
				{
					goto IL_0041;
				}
			}
			IField field = null;
			Match match = automaticPropertyPattern.Match(propertyDeclaration);
			if (match.Success)
			{
				field = Enumerable.Single<AstNode>(match.Get<AstNode>("fieldReference")).GetSymbol() as IField;
			}
			else
			{
				Match match2 = automaticReadonlyPropertyPattern.Match(propertyDeclaration);
				if (match2.Success)
				{
					field = Enumerable.Single<AstNode>(match2.Get<AstNode>("fieldReference")).GetSymbol() as IField;
				}
			}
			if (field == null)
			{
				return null;
			}
			if (field.IsCompilerGenerated() && field.DeclaringTypeDefinition == property.DeclaringTypeDefinition)
			{
				RemoveCompilerGeneratedAttribute(propertyDeclaration.Getter.Attributes);
				RemoveCompilerGeneratedAttribute(propertyDeclaration.Setter.Attributes);
				propertyDeclaration.Getter.Body = null;
				propertyDeclaration.Setter.Body = null;
				DecompTools.Decompiler.CSharp.Syntax.Attribute[] array = Enumerable.ToArray<DecompTools.Decompiler.CSharp.Syntax.Attribute>(Enumerable.Select<IAttribute, DecompTools.Decompiler.CSharp.Syntax.Attribute>(Enumerable.Where<IAttribute>(field.GetAttributes(), (Func<IAttribute, bool>)((IAttribute a) => !Enumerable.Contains<string>((IEnumerable<string>)attributeTypesToRemoveFromAutoProperties, a.AttributeType.FullName))), (Func<IAttribute, DecompTools.Decompiler.CSharp.Syntax.Attribute>)context.TypeSystemAstBuilder.ConvertAttribute));
				if (array.Length != 0)
				{
					AttributeSection attributeSection = new AttributeSection
					{
						AttributeTarget = "field"
					};
					attributeSection.Attributes.AddRange(array);
					propertyDeclaration.Attributes.Add(attributeSection);
				}
			}
			return null;
		}
		goto IL_0041;
		IL_0041:
		return null;
	}

	private void RemoveCompilerGeneratedAttribute(AstNodeCollection<AttributeSection> attributeSections)
	{
		RemoveCompilerGeneratedAttribute(attributeSections, "System.Runtime.CompilerServices.CompilerGeneratedAttribute");
	}

	private void RemoveCompilerGeneratedAttribute(AstNodeCollection<AttributeSection> attributeSections, params string[] attributesToRemove)
	{
		foreach (AttributeSection attributeSection in attributeSections)
		{
			foreach (DecompTools.Decompiler.CSharp.Syntax.Attribute attribute in attributeSection.Attributes)
			{
				if (attribute.Type.GetSymbol() is IType type && Enumerable.Contains<string>((IEnumerable<string>)attributesToRemove, type.FullName))
				{
					attribute.Remove();
				}
			}
			if (attributeSection.Attributes.Count == 0)
			{
				attributeSection.Remove();
			}
		}
	}

	public override AstNode VisitIdentifier(Identifier identifier)
	{
		if (context.Settings.AutomaticProperties)
		{
			Identifier identifier2 = ReplaceBackingFieldUsage(identifier);
			if (identifier2 != null)
			{
				identifier.ReplaceWith(identifier2);
				return identifier2;
			}
		}
		if (context.Settings.AutomaticEvents)
		{
			Identifier identifier3 = ReplaceEventFieldAnnotation(identifier);
			if (identifier3 != null)
			{
				return identifier3;
			}
		}
		return base.VisitIdentifier(identifier);
	}

	internal static bool IsBackingFieldOfAutomaticProperty(IField field, out IProperty property)
	{
		property = null;
		if (!field.Name.StartsWith("<") || !field.Name.EndsWith(">k__BackingField"))
		{
			return false;
		}
		if (!field.IsCompilerGenerated())
		{
			return false;
		}
		string propertyName = field.Name.Substring(1, checked(field.Name.Length - 1 - ">k__BackingField".Length));
		property = Enumerable.FirstOrDefault<IProperty>(field.DeclaringTypeDefinition.GetProperties((IProperty p) => p.Name == propertyName, GetMemberOptions.IgnoreInheritedMembers));
		return property != null;
	}

	private Identifier ReplaceBackingFieldUsage(Identifier identifier)
	{
		if (identifier.Name.StartsWith("<") && identifier.Name.EndsWith(">k__BackingField"))
		{
			AstNode parent = identifier.Parent;
			MemberResolveResult memberResolveResult = parent.Annotation<MemberResolveResult>();
			if (memberResolveResult?.Member is IField field && field.IsCompilerGenerated())
			{
				string propertyName = identifier.Name.Substring(1, checked(identifier.Name.Length - 1 - ">k__BackingField".Length));
				IProperty property = Enumerable.FirstOrDefault<IProperty>(field.DeclaringTypeDefinition.GetProperties((IProperty p) => p.Name == propertyName, GetMemberOptions.IgnoreInheritedMembers));
				if (property != null)
				{
					parent.RemoveAnnotations<MemberResolveResult>();
					parent.AddAnnotation(new MemberResolveResult(memberResolveResult.TargetResult, property));
					return Identifier.Create(propertyName);
				}
			}
		}
		return null;
	}

	private Identifier ReplaceEventFieldAnnotation(Identifier identifier)
	{
		AstNode parent = identifier.Parent;
		MemberResolveResult memberResolveResult = parent.Annotation<MemberResolveResult>();
		IField field = memberResolveResult?.Member as IField;
		if (field == null)
		{
			return null;
		}
		IEvent obj = Enumerable.SingleOrDefault<IEvent>(field.DeclaringType.GetEvents((IEvent ev) => ev.Name == field.Name, GetMemberOptions.IgnoreInheritedMembers));
		if (obj != null)
		{
			parent.RemoveAnnotations<MemberResolveResult>();
			parent.AddAnnotation(new MemberResolveResult(memberResolveResult.TargetResult, obj));
			return identifier;
		}
		return null;
	}

	private bool CheckAutomaticEventMatch(Match m, CustomEventDeclaration ev, bool isAddAccessor)
	{
		if (!m.Success)
		{
			return false;
		}
		Expression expression = Enumerable.Single<Expression>(m.Get<Expression>("field"));
		Expression expression2 = expression;
		Expression expression3 = expression2;
		if (expression3 == null)
		{
			goto IL_00a1;
		}
		if (!(expression3 is IdentifierExpression identifierExpression))
		{
			if (!(expression3 is MemberReferenceExpression memberReferenceExpression))
			{
				goto IL_00a1;
			}
			MemberReferenceExpression memberReferenceExpression2 = memberReferenceExpression;
			if (memberReferenceExpression2.MemberName != ev.Name)
			{
				return false;
			}
		}
		else
		{
			IdentifierExpression identifierExpression2 = identifierExpression;
			if (identifierExpression2.Identifier != ev.Name)
			{
				return false;
			}
		}
		if (!ev.ReturnType.IsMatch(Enumerable.Single<INode>(m.Get("type"))))
		{
			return false;
		}
		if (!(Enumerable.Single<AstNode>(m.Get<AstNode>("delegateCombine")).Parent.GetSymbol() is IMethod method) || method.Name != (isAddAccessor ? "Combine" : "Remove"))
		{
			return false;
		}
		return method.DeclaringType.FullName == "System.Delegate";
		IL_00a1:
		return false;
	}

	private bool CheckAutomaticEventV4(CustomEventDeclaration ev)
	{
		Match m = automaticEventPatternV4.Match(ev.AddAccessor);
		if (!CheckAutomaticEventMatch(m, ev, isAddAccessor: true))
		{
			return false;
		}
		Match m2 = automaticEventPatternV4.Match(ev.RemoveAccessor);
		if (!CheckAutomaticEventMatch(m2, ev, isAddAccessor: false))
		{
			return false;
		}
		return true;
	}

	private bool CheckAutomaticEventV2(CustomEventDeclaration ev)
	{
		Match m = automaticEventPatternV2.Match(ev.AddAccessor);
		if (!CheckAutomaticEventMatch(m, ev, isAddAccessor: true))
		{
			return false;
		}
		Match m2 = automaticEventPatternV2.Match(ev.RemoveAccessor);
		if (!CheckAutomaticEventMatch(m2, ev, isAddAccessor: false))
		{
			return false;
		}
		return true;
	}

	private bool CheckAutomaticEventV4MCS(CustomEventDeclaration ev)
	{
		Match m = automaticEventPatternV4MCS.Match(ev.AddAccessor);
		if (!CheckAutomaticEventMatch(m, ev, isAddAccessor: true))
		{
			return false;
		}
		Match m2 = automaticEventPatternV4MCS.Match(ev.RemoveAccessor);
		if (!CheckAutomaticEventMatch(m2, ev, isAddAccessor: false))
		{
			return false;
		}
		return true;
	}

	private EventDeclaration TransformAutomaticEvents(CustomEventDeclaration ev)
	{
		if (!ev.PrivateImplementationType.IsNull)
		{
			return null;
		}
		if (!ev.Modifiers.HasFlag(Modifiers.Abstract) && !CheckAutomaticEventV4(ev) && !CheckAutomaticEventV2(ev) && !CheckAutomaticEventV4MCS(ev))
		{
			return null;
		}
		RemoveCompilerGeneratedAttribute(ev.AddAccessor.Attributes, attributeTypesToRemoveFromAutoEvents);
		EventDeclaration eventDeclaration = new EventDeclaration();
		ev.Attributes.MoveTo(eventDeclaration.Attributes);
		foreach (AttributeSection attribute in ev.AddAccessor.Attributes)
		{
			attribute.AttributeTarget = "method";
			eventDeclaration.Attributes.Add(attribute.Detach());
		}
		eventDeclaration.ReturnType = ev.ReturnType.Detach();
		eventDeclaration.Modifiers = ev.Modifiers;
		eventDeclaration.Variables.Add(new VariableInitializer(ev.Name));
		eventDeclaration.CopyAnnotationsFrom(ev);
		if (ev.GetSymbol() is IEvent obj)
		{
			IField field = Enumerable.SingleOrDefault<IField>(obj.DeclaringType.GetFields((IField f) => f.Name == ev.Name, GetMemberOptions.IgnoreInheritedMembers));
			if (field != null)
			{
				eventDeclaration.AddAnnotation(field);
				DecompTools.Decompiler.CSharp.Syntax.Attribute[] array = Enumerable.ToArray<DecompTools.Decompiler.CSharp.Syntax.Attribute>(Enumerable.Select<IAttribute, DecompTools.Decompiler.CSharp.Syntax.Attribute>(Enumerable.Where<IAttribute>(field.GetAttributes(), (Func<IAttribute, bool>)((IAttribute a) => !Enumerable.Contains<string>((IEnumerable<string>)attributeTypesToRemoveFromAutoEvents, a.AttributeType.FullName))), (Func<IAttribute, DecompTools.Decompiler.CSharp.Syntax.Attribute>)context.TypeSystemAstBuilder.ConvertAttribute));
				if (array.Length != 0)
				{
					AttributeSection attributeSection = new AttributeSection
					{
						AttributeTarget = "field"
					};
					attributeSection.Attributes.AddRange(array);
					eventDeclaration.Attributes.Add(attributeSection);
				}
			}
		}
		ev.ReplaceWith(eventDeclaration);
		return eventDeclaration;
	}

	private DestructorDeclaration TransformDestructor(MethodDeclaration methodDef)
	{
		Match match = destructorPattern.Match(methodDef);
		if (match.Success)
		{
			DestructorDeclaration destructorDeclaration = new DestructorDeclaration();
			methodDef.Attributes.MoveTo(destructorDeclaration.Attributes);
			destructorDeclaration.CopyAnnotationsFrom(methodDef);
			destructorDeclaration.Modifiers = methodDef.Modifiers & ~(Modifiers.Protected | Modifiers.Override);
			destructorDeclaration.Body = Enumerable.Single<BlockStatement>(match.Get<BlockStatement>("body")).Detach();
			destructorDeclaration.Name = currentTypeDefinition?.Name;
			methodDef.ReplaceWith(destructorDeclaration);
			return destructorDeclaration;
		}
		return null;
	}

	private DestructorDeclaration TransformDestructorBody(DestructorDeclaration dtorDef)
	{
		Match match = destructorBodyPattern.Match(dtorDef.Body);
		if (match.Success)
		{
			dtorDef.Body = Enumerable.Single<BlockStatement>(match.Get<BlockStatement>("body")).Detach();
			return dtorDef;
		}
		return null;
	}

	private TryCatchStatement TransformTryCatchFinally(TryCatchStatement tryFinally)
	{
		if (tryCatchFinallyPattern.IsMatch(tryFinally))
		{
			TryCatchStatement tryCatchStatement = (TryCatchStatement)Enumerable.Single<Statement>((IEnumerable<Statement>)tryFinally.TryBlock.Statements);
			tryFinally.TryBlock = tryCatchStatement.TryBlock.Detach();
			tryCatchStatement.CatchClauses.MoveTo(tryFinally.CatchClauses);
		}
		return null;
	}

	private AstNode SimplifyCascadingIfElseStatements(IfElseStatement node)
	{
		Match match = cascadingIfElsePattern.Match(node);
		if (match.Success)
		{
			IfElseStatement node2 = Enumerable.Single<IfElseStatement>(match.Get<IfElseStatement>("nestedIfStatement"));
			node.FalseStatement = node2.Detach();
		}
		return null;
	}

	public override AstNode VisitBinaryOperatorExpression(BinaryOperatorExpression boe1)
	{
		BinaryOperatorType binaryOperatorType = boe1.Operator;
		if ((uint)(binaryOperatorType - 3) <= 1u && boe1.Right is BinaryOperatorExpression binaryOperatorExpression && binaryOperatorExpression.Operator == boe1.Operator)
		{
			Expression right = binaryOperatorExpression.Left.Detach();
			boe1.ReplaceWith(binaryOperatorExpression.Detach());
			binaryOperatorExpression.Left = boe1;
			boe1.Right = right;
			return base.VisitBinaryOperatorExpression(binaryOperatorExpression);
		}
		return base.VisitBinaryOperatorExpression(boe1);
	}
}
