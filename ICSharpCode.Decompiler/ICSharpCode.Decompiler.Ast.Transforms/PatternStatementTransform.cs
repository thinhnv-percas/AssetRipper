using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Analysis;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public sealed class PatternStatementTransform : ContextTrackingVisitor<AstNode>, IAstTransformPoolObject, IAstTransform
{
	private readonly StringBuilder stringBuilder;

	private static readonly AstNode variableAssignPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new AnyNode("initializer")));

	private static readonly AstNode usingTryCatchPattern = new Choice
	{
		{
			"c#/vb",
			new TryCatchStatement
			{
				TryBlock = new AnyNode(),
				FinallyBlock = new BlockStatement { new Choice
				{
					{
						"valueType",
						new ExpressionStatement(InvokeDispose(new NamedNode("ident", new IdentifierExpression(Pattern.AnyString))))
					},
					{
						"referenceType",
						new IfElseStatement
						{
							Condition = new BinaryOperatorExpression(new NamedNode("ident", new IdentifierExpression(Pattern.AnyString)), BinaryOperatorType.InEquality, new NullReferenceExpression()),
							TrueStatement = new BlockStatement
							{
								new ExpressionStatement(InvokeDispose(new Backreference("ident")))
							}
						}
					}
				}.ToStatement() }
			}
		},
		{
			"f#",
			new TryCatchStatement
			{
				TryBlock = new AnyNode(),
				FinallyBlock = new BlockStatement
				{
					new ExpressionStatement(new AssignmentExpression(new NamedNode("disposable", new IdentifierExpression(Pattern.AnyString)), new AsExpression(new NamedNode("ident", new IdentifierExpression(Pattern.AnyString)), new TypePattern(typeof(IDisposable))))),
					new IfElseStatement
					{
						Condition = new BinaryOperatorExpression(new Backreference("disposable"), BinaryOperatorType.InEquality, new NullReferenceExpression()),
						TrueStatement = new BlockStatement
						{
							new ExpressionStatement(InvokeDispose(new Backreference("disposable")))
						}
					}
				}
			}
		}
	};

	private static readonly UsingStatement genericForeachPattern = new UsingStatement
	{
		ResourceAcquisition = new VariableDeclarationStatement
		{
			Type = new AnyNode("enumeratorType"),
			Variables = { (VariableInitializer)new NamedNode("enumeratorVariable", new VariableInitializer
			{
				Name = Pattern.AnyString,
				Initializer = new AnyNode("collection").ToExpression().Invoke("GetEnumerator")
			}) }
		},
		EmbeddedStatement = new BlockStatement
		{
			new Repeat(new VariableDeclarationStatement
			{
				Type = new AnyNode(),
				Variables = 
				{
					new VariableInitializer(null, Pattern.AnyString)
				}
			}.WithName("variablesOutsideLoop")).ToStatement(),
			new WhileStatement
			{
				Condition = new IdentifierExpressionBackreference("enumeratorVariable").ToExpression().Invoke("MoveNext"),
				EmbeddedStatement = new BlockStatement
				{
					new Repeat(new VariableDeclarationStatement
					{
						Type = new AnyNode(),
						Variables = 
						{
							new VariableInitializer(null, Pattern.AnyString)
						}
					}.WithName("variablesInsideLoop")).ToStatement(),
					new AssignmentExpression
					{
						Left = new IdentifierExpression(Pattern.AnyString).WithName("itemVariable"),
						Operator = AssignmentOperatorType.Assign,
						Right = new IdentifierExpressionBackreference("enumeratorVariable").ToExpression().Member("Current", BoxedTextColor.InstanceProperty)
					}.WithName("getCurrent"),
					new Repeat(new AnyNode("statement")).ToStatement()
				}
			}.WithName("loop")
		}
	};

	private static readonly ExpressionStatement getEnumeratorPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("left", new IdentifierExpression(Pattern.AnyString)), new AnyNode("collection").ToExpression().Invoke("GetEnumerator")).WithName("getEnumeratorAssignment"));

	private static readonly TryCatchStatement nonGenericForeachPattern = new TryCatchStatement
	{
		TryBlock = new BlockStatement { new WhileStatement
		{
			Condition = new IdentifierExpression(Pattern.AnyString).WithName("enumerator").Invoke("MoveNext"),
			EmbeddedStatement = new BlockStatement
			{
				new AssignmentExpression(new IdentifierExpression(Pattern.AnyString).WithName("itemVar"), new Choice
				{
					new Backreference("enumerator").ToExpression().Member("Current", BoxedTextColor.InstanceProperty),
					new CastExpression
					{
						Type = new AnyNode("castType"),
						Expression = new Backreference("enumerator").ToExpression().Member("Current", BoxedTextColor.InstanceProperty)
					}
				}).WithName("getCurrent"),
				new Repeat(new AnyNode("stmt")).ToStatement()
			}
		}.WithName("loop") },
		FinallyBlock = new BlockStatement
		{
			new AssignmentExpression(new IdentifierExpression(Pattern.AnyString).WithName("disposable"), new Backreference("enumerator").ToExpression().CastAs(new TypePattern(typeof(IDisposable)))),
			new IfElseStatement
			{
				Condition = new BinaryOperatorExpression
				{
					Left = new Backreference("disposable"),
					Operator = BinaryOperatorType.InEquality,
					Right = new NullReferenceExpression()
				},
				TrueStatement = new BlockStatement { new Backreference("disposable").ToExpression().Invoke("Dispose") }
			}
		}
	};

	private static readonly Statement nonGenericForeachPatternNoFinallyBlock = new WhileStatement
	{
		Condition = new IdentifierExpression(Pattern.AnyString).WithName("enumerator").Invoke("MoveNext"),
		EmbeddedStatement = new BlockStatement
		{
			new AssignmentExpression(new IdentifierExpression(Pattern.AnyString).WithName("itemVar"), new Choice
			{
				new Backreference("enumerator").ToExpression().Member("Current", BoxedTextColor.InstanceProperty),
				new CastExpression
				{
					Type = new AnyNode("castType"),
					Expression = new Backreference("enumerator").ToExpression().Member("Current", BoxedTextColor.InstanceProperty)
				}
			}).WithName("getCurrent"),
			new Repeat(new AnyNode("stmt")).ToStatement()
		}
	}.WithName("loop");

	private static readonly AstNode variableZeroAssignPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("initializer", new IdentifierExpression(Pattern.AnyString)), AssignmentOperatorType.Assign, new PrimitiveExpression(0)));

	private static readonly WhileStatement foreachStringOrArrayPattern = new WhileStatement
	{
		Condition = new BinaryOperatorExpression
		{
			Left = new NamedNode("i", new IdentifierExpression(Pattern.AnyString)),
			Operator = BinaryOperatorType.LessThan,
			Right = new NamedNode("endExpr", new MemberReferenceExpression
			{
				Target = new NamedNode("loopArray", new IdentifierExpression(Pattern.AnyString)),
				MemberName = "Length"
			})
		},
		EmbeddedStatement = new BlockStatement
		{
			Statements = 
			{
				(Statement)new NamedNode("variable", new ExpressionStatement(new AssignmentExpression
				{
					Left = new NamedNode("loopVar", new IdentifierExpression(Pattern.AnyString)),
					Operator = AssignmentOperatorType.Assign,
					Right = new Choice
					{
						new IndexerExpression
						{
							Target = new Backreference("loopArray"),
							Arguments = { (Expression)new Backreference("i") }
						},
						new IndexerExpression
						{
							Target = new Backreference("loopArray"),
							Arguments = { (Expression)new Backreference("i") }
						}.CastTo(new AnyNode())
					}
				})),
				(Statement)new Repeat(new AnyNode("statement")),
				(Statement)new NamedNode("increment", new ExpressionStatement(new AssignmentExpression
				{
					Left = new Backreference("i"),
					Operator = AssignmentOperatorType.Assign,
					Right = new BinaryOperatorExpression
					{
						Left = new Backreference("i"),
						Operator = BinaryOperatorType.Add,
						Right = new PrimitiveExpression(1)
					}
				}))
			}
		}
	};

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

	private static readonly WhileStatement whileTrueLoopPattern = new WhileStatement
	{
		Condition = new PrimitiveExpression(true),
		EmbeddedStatement = new BlockStatement
		{
			Statements = { (Statement)new Repeat(new AnyNode("statement")) }
		}
	};

	private static readonly WhileStatement doWhilePattern = new WhileStatement
	{
		Condition = new PrimitiveExpression(true),
		EmbeddedStatement = new BlockStatement
		{
			Statements = 
			{
				(Statement)new Repeat(new AnyNode("statement")),
				(Statement)new IfElseStatement
				{
					Condition = new AnyNode("condition"),
					TrueStatement = new BlockStatement
					{
						new BreakStatement()
					}
				}
			}
		}
	};

	private static readonly AstNode lockFlagInitPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new PrimitiveExpression(false)));

	private static readonly AstNode lockTryCatchPattern = new TryCatchStatement
	{
		TryBlock = new BlockStatement
		{
			new OptionalNode(new VariableDeclarationStatement()).ToStatement(),
			new TypePattern(typeof(Monitor)).ToType().Invoke2(BoxedTextColor.StaticMethod, "Enter", new AnyNode("enter"), new DirectionExpression
			{
				FieldDirection = FieldDirection.Ref,
				Expression = new NamedNode("flag", new IdentifierExpression(Pattern.AnyString))
			}),
			new Repeat(new AnyNode()).ToStatement()
		},
		FinallyBlock = new BlockStatement
		{
			new IfElseStatement
			{
				Condition = new Backreference("flag"),
				TrueStatement = new BlockStatement { new TypePattern(typeof(Monitor)).ToType().Invoke2(BoxedTextColor.StaticMethod, "Exit", new AnyNode("exit")) }
			}
		}
	};

	private static readonly AstNode oldMonitorCallPattern = new ExpressionStatement(new TypePattern(typeof(Monitor)).ToType().Invoke("Enter", new AnyNode("enter")));

	private static readonly AstNode oldLockTryCatchPattern = new TryCatchStatement
	{
		TryBlock = new BlockStatement { new Repeat(new AnyNode()).ToStatement() },
		FinallyBlock = new BlockStatement { new TypePattern(typeof(Monitor)).ToType().Invoke("Exit", new AnyNode("exit")) }
	};

	private static readonly IfElseStatement switchOnStringPattern = new IfElseStatement
	{
		Condition = new BinaryOperatorExpression
		{
			Left = new AnyNode("switchExpr"),
			Operator = BinaryOperatorType.InEquality,
			Right = new NullReferenceExpression()
		},
		TrueStatement = new BlockStatement
		{
			new IfElseStatement
			{
				Condition = new BinaryOperatorExpression
				{
					Left = new AnyNode("cachedDict"),
					Operator = BinaryOperatorType.Equality,
					Right = new NullReferenceExpression()
				},
				TrueStatement = new AnyNode("dictCreation")
			},
			new IfElseStatement
			{
				Condition = new Backreference("cachedDict").ToExpression().Invoke("TryGetValue", new NamedNode("switchVar", new IdentifierExpression(Pattern.AnyString)), new DirectionExpression
				{
					FieldDirection = FieldDirection.Out,
					Expression = new IdentifierExpression(Pattern.AnyString).WithName("intVar")
				}),
				TrueStatement = new BlockStatement
				{
					Statements = { (Statement)new NamedNode("switch", new SwitchStatement
					{
						Expression = new IdentifierExpressionBackreference("intVar"),
						SwitchSections = { (SwitchSection)new Repeat(new AnyNode()) }
					}) }
				}
			},
			new Repeat(new AnyNode("nonNullDefaultStmt")).ToStatement()
		},
		FalseStatement = new OptionalNode("nullStmt", new BlockStatement
		{
			Statements = { (Statement)new Repeat(new AnyNode()) }
		})
	};

	private static readonly Statement assignInitializedDictionary = new ExpressionStatement
	{
		Expression = new AssignmentExpression
		{
			Left = new AnyNode().ToExpression(),
			Right = new ObjectCreateExpression
			{
				Type = new AnyNode(),
				Arguments = { (Expression)new Repeat(new AnyNode()) },
				Initializer = new ArrayInitializerExpression
				{
					Elements = { (Expression)new Repeat(new AnyNode("dictJumpTable")) }
				}
			}
		}
	};

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
					Right = IdentifierExpression.Create("value", BoxedTextColor.Keyword)
				}
			}
		}
	};

	private static readonly PropertyDeclaration automaticReadOnlyPropertyPattern = new PropertyDeclaration
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

	private static readonly UTF8String systemRuntimeCompilerServicesString = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String compilerGeneratedAttributeString = new UTF8String("CompilerGeneratedAttribute");

	private static readonly UTF8String methodImplAttributeString = new UTF8String("MethodImplAttribute");

	private static readonly KeyValuePair<UTF8String, UTF8String>[] compilerGeneratedAttributeNames = new KeyValuePair<UTF8String, UTF8String>[1]
	{
		new KeyValuePair<UTF8String, UTF8String>(systemRuntimeCompilerServicesString, compilerGeneratedAttributeString)
	};

	private static readonly KeyValuePair<UTF8String, UTF8String>[] eventAttributesToRemove = new KeyValuePair<UTF8String, UTF8String>[2]
	{
		new KeyValuePair<UTF8String, UTF8String>(systemRuntimeCompilerServicesString, compilerGeneratedAttributeString),
		new KeyValuePair<UTF8String, UTF8String>(systemRuntimeCompilerServicesString, methodImplAttributeString)
	};

	private static readonly Accessor automaticEventPatternV4 = new Accessor
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Body = new BlockStatement
		{
			new VariableDeclarationStatement
			{
				Type = new AnyNode("type"),
				Variables = { (VariableInitializer)new AnyNode() }
			},
			new VariableDeclarationStatement
			{
				Type = new Backreference("type"),
				Variables = { (VariableInitializer)new AnyNode() }
			},
			new VariableDeclarationStatement
			{
				Type = new Backreference("type"),
				Variables = { (VariableInitializer)new AnyNode() }
			},
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
						Left = new NamedNode("var3", new IdentifierExpression(Pattern.AnyString)),
						Operator = AssignmentOperatorType.Assign,
						Right = new AnyNode("delegateCombine").ToExpression().Invoke(new IdentifierExpressionBackreference("var2"), IdentifierExpression.Create("value", BoxedTextColor.Keyword)).CastTo(new Backreference("type"))
					},
					new AssignmentExpression
					{
						Left = new IdentifierExpressionBackreference("var1"),
						Right = new TypePattern(typeof(Interlocked)).ToType().Invoke(BoxedTextColor.StaticMethod, "CompareExchange", new AstType[1]
						{
							new Backreference("type")
						}, new Expression[3]
						{
							new DirectionExpression
							{
								FieldDirection = FieldDirection.Ref,
								Expression = new Backreference("field")
							},
							new IdentifierExpressionBackreference("var3"),
							new IdentifierExpressionBackreference("var2")
						})
					}
				},
				Condition = new BinaryOperatorExpression
				{
					Left = new IdentifierExpressionBackreference("var1"),
					Operator = BinaryOperatorType.InEquality,
					Right = new IdentifierExpressionBackreference("var2")
				}
			}
		}
	};

	private static readonly Accessor automaticEventPatternMcs46 = new Accessor
	{
		Body = new BlockStatement
		{
			new VariableDeclarationStatement
			{
				Type = new AnyNode("type"),
				Variables = { (VariableInitializer)new AnyNode() }
			},
			new VariableDeclarationStatement
			{
				Type = new Backreference("type"),
				Variables = { (VariableInitializer)new AnyNode() }
			},
			new ExpressionStatement
			{
				Expression = new AssignmentExpression
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
				}
			},
			new DoWhileStatement
			{
				EmbeddedStatement = new BlockStatement
				{
					new AssignmentExpression(new NamedNode("var2", new IdentifierExpression(Pattern.AnyString)), new IdentifierExpressionBackreference("var1")),
					new AssignmentExpression
					{
						Left = new IdentifierExpressionBackreference("var1"),
						Right = new TypePattern(typeof(Interlocked)).ToType().Invoke(BoxedTextColor.StaticMethod, "CompareExchange", new AstType[1]
						{
							new Backreference("type")
						}, new Expression[3]
						{
							new DirectionExpression
							{
								FieldDirection = FieldDirection.Ref,
								Expression = new Backreference("field")
							},
							new AnyNode("delegateCombine").ToExpression().Invoke(new IdentifierExpressionBackreference("var2"), IdentifierExpression.Create("value", BoxedTextColor.Keyword)).CastTo(new Backreference("type")),
							new IdentifierExpressionBackreference("var1")
						})
					}
				},
				Condition = new BinaryOperatorExpression
				{
					Left = new IdentifierExpressionBackreference("var1"),
					Operator = BinaryOperatorType.InEquality,
					Right = new IdentifierExpressionBackreference("var2")
				}
			}
		}
	};

	private static readonly Accessor automaticEventPatternV35 = new Accessor
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Body = new BlockStatement
		{
			new ExpressionStatement
			{
				Expression = new AssignmentExpression
				{
					Left = new NamedNode("field", new MemberReferenceExpression
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
					}),
					Operator = AssignmentOperatorType.Assign,
					Right = new AnyNode("delegateCombine").ToExpression().Invoke(new Backreference("field"), IdentifierExpression.Create("value", BoxedTextColor.Keyword)).CastTo(new AnyNode())
				}
			}
		}
	};

	private static readonly MethodDeclaration destructorPattern = new MethodDeclaration
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Modifiers = Modifiers.Any,
		ReturnType = new PrimitiveType("void"),
		Name = "Finalize",
		Body = new BlockStatement
		{
			new TryCatchStatement
			{
				TryBlock = new AnyNode("body"),
				FinallyBlock = new BlockStatement { new BaseReferenceExpression().Invoke("Finalize") }
			}
		}
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

	public PatternStatementTransform(DecompilerContext context)
		: base(context)
	{
		stringBuilder = new StringBuilder();
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
		base.context = context;
	}

	protected override AstNode VisitChildren(AstNode node, object data)
	{
		for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			AstNode astNode2;
			do
			{
				astNode2 = astNode;
				astNode = astNode.AcceptVisitor(this, data);
			}
			while (astNode != astNode2);
		}
		return node;
	}

	public override AstNode VisitExpressionStatement(ExpressionStatement expressionStatement, object data)
	{
		AstNode astNode;
		if (context.Settings.UsingStatement)
		{
			astNode = TransformNonGenericForEach(expressionStatement);
			if (astNode != null)
			{
				return astNode;
			}
			astNode = TransformUsings(expressionStatement);
			if (astNode != null)
			{
				return astNode;
			}
		}
		astNode = TransformForeachArrayOrString(expressionStatement);
		if (astNode != null)
		{
			return astNode;
		}
		astNode = TransformFor(expressionStatement);
		if (astNode != null)
		{
			return astNode;
		}
		if (context.Settings.LockStatement)
		{
			astNode = TransformLock(expressionStatement);
			if (astNode != null)
			{
				return astNode;
			}
		}
		return base.VisitExpressionStatement(expressionStatement, data);
	}

	public override AstNode VisitUsingStatement(UsingStatement usingStatement, object data)
	{
		if (context.Settings.ForEachStatement)
		{
			AstNode astNode = TransformForeach(usingStatement);
			if (astNode != null)
			{
				return astNode;
			}
		}
		return base.VisitUsingStatement(usingStatement, data);
	}

	public override AstNode VisitWhileStatement(WhileStatement whileStatement, object data)
	{
		return TransformDoWhile(whileStatement) ?? TransformWhileTrueToForLoop(whileStatement) ?? base.VisitWhileStatement(whileStatement, data);
	}

	public override AstNode VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
	{
		if (context.Settings.SwitchStatementOnString)
		{
			AstNode astNode = TransformSwitchOnString(ifElseStatement);
			if (astNode != null)
			{
				return astNode;
			}
		}
		AstNode astNode2 = SimplifyCascadingIfElseStatements(ifElseStatement);
		if (astNode2 != null)
		{
			return astNode2;
		}
		return base.VisitIfElseStatement(ifElseStatement, data);
	}

	public override AstNode VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
	{
		if (context.Settings.AutomaticProperties && !context.Settings.ForceShowAllMembers)
		{
			AstNode astNode = TransformAutomaticProperties(propertyDeclaration);
			if (astNode != null)
			{
				return astNode;
			}
		}
		return base.VisitPropertyDeclaration(propertyDeclaration, data);
	}

	public override AstNode VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration, object data)
	{
		base.VisitCustomEventDeclaration(eventDeclaration, data);
		if (context.Settings.AutomaticEvents && !context.Settings.ForceShowAllMembers)
		{
			AstNode astNode = TransformAutomaticEvents(eventDeclaration);
			if (astNode != null)
			{
				return astNode;
			}
		}
		return eventDeclaration;
	}

	public override AstNode VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
	{
		return TransformDestructor(methodDeclaration) ?? base.VisitMethodDeclaration(methodDeclaration, data);
	}

	public override AstNode VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
	{
		return TransformTryCatchFinally(tryCatchStatement) ?? base.VisitTryCatchStatement(tryCatchStatement, data);
	}

	private static Expression InvokeDispose(Expression identifier)
	{
		Choice choice = new Choice();
		choice.Add(identifier.Invoke("Dispose"));
		choice.Add(identifier.Clone().CastTo(new TypePattern(typeof(IDisposable))).Invoke("Dispose"));
		return choice;
	}

	public UsingStatement TransformUsings(ExpressionStatement node)
	{
		Match match = variableAssignPattern.Match(node);
		if (!match.Success)
		{
			return null;
		}
		TryCatchStatement tryCatchStatement = node.NextSibling as TryCatchStatement;
		Match match2 = usingTryCatchPattern.Match(tryCatchStatement);
		if (!match2.Success)
		{
			return null;
		}
		string variableName = match.Get<IdentifierExpression>("variable").Single().Identifier;
		if (variableName != match2.Get<IdentifierExpression>("ident").Single().Identifier)
		{
			return null;
		}
		if (match2.Has("valueType"))
		{
			ILVariable iLVariable = match.Get<AstNode>("variable").Single().Annotation<ILVariable>();
			if (iLVariable == null || iLVariable.Type == null || !DnlibExtensions.IsValueType(iLVariable.Type))
			{
				return null;
			}
		}
		if (HasAssignment(tryCatchStatement, variableName))
		{
			return null;
		}
		VariableDeclarationStatement variableDeclarationStatement = FindVariableDeclaration(node, variableName);
		if (variableDeclarationStatement == null || !(variableDeclarationStatement.Parent is BlockStatement))
		{
			return null;
		}
		if (!IsVariableValueUnused(variableDeclarationStatement, tryCatchStatement))
		{
			return null;
		}
		if (match2.Has("f#"))
		{
			string identifier = match2.Get<IdentifierExpression>("disposable").Single().Identifier;
			VariableDeclarationStatement variableDeclarationStatement2 = FindVariableDeclaration(node, identifier);
			if (variableDeclarationStatement2 == null || !(variableDeclarationStatement2.Parent is BlockStatement))
			{
				return null;
			}
			if (!IsVariableValueUnused(variableDeclarationStatement2, tryCatchStatement))
			{
				return null;
			}
		}
		node.Remove();
		UsingStatement usingStatement = new UsingStatement();
		tryCatchStatement.TryBlock.HiddenEnd = tryCatchStatement.FinallyBlock.Detach();
		usingStatement.EmbeddedStatement = tryCatchStatement.TryBlock.Detach();
		tryCatchStatement.ReplaceWith(usingStatement);
		tryCatchStatement.AddAllRecursiveILSpansTo(usingStatement);
		if (usingStatement.EmbeddedStatement.Descendants.OfType<IdentifierExpression>().Any((IdentifierExpression ident) => ident.Identifier == variableName))
		{
			usingStatement.ResourceAcquisition = new VariableDeclarationStatement
			{
				Type = variableDeclarationStatement.Type.Clone(),
				Variables = { new VariableInitializer
				{
					NameToken = Identifier.Create(variableName).WithAnnotation(BoxedTextColor.Local),
					Initializer = match.Get<Expression>("initializer").Single().Detach()
				}.CopyAnnotationsFrom(node.Expression).WithAnnotation(match.Get<AstNode>("variable").Single().Annotation<ILVariable>()) }
			}.CopyAnnotationsFrom(node).WithAnnotation(node.Expression.GetAllRecursiveILSpans());
		}
		else
		{
			usingStatement.ResourceAcquisition = match.Get<Expression>("initializer").Single().Detach();
			usingStatement.ResourceAcquisition.AddAnnotation(node.Expression.GetAllRecursiveILSpans());
		}
		return usingStatement;
	}

	internal static VariableDeclarationStatement FindVariableDeclaration(AstNode node, string identifier)
	{
		while (node != null)
		{
			while (node.PrevSibling != null)
			{
				node = node.PrevSibling;
				if (node is VariableDeclarationStatement variableDeclarationStatement && variableDeclarationStatement.Variables.Count == 1 && variableDeclarationStatement.Variables.Single().Name == identifier)
				{
					return variableDeclarationStatement;
				}
			}
			node = node.Parent;
		}
		return null;
	}

	private static AstType GetParameterOrVariableType(AstNode node, string identifier)
	{
		while (node != null)
		{
			while (node.PrevSibling != null)
			{
				node = node.PrevSibling;
				if (node is VariableDeclarationStatement variableDeclarationStatement && variableDeclarationStatement.Variables.Count == 1 && variableDeclarationStatement.Variables.Single().Name == identifier)
				{
					return variableDeclarationStatement.Type;
				}
				if (node is ParameterDeclaration parameterDeclaration && parameterDeclaration.Name == identifier)
				{
					return parameterDeclaration.Type;
				}
			}
			node = node.Parent;
		}
		return null;
	}

	private bool IsVariableValueUnused(VariableDeclarationStatement varDecl, Statement targetStatement)
	{
		BlockStatement blockStatement = (BlockStatement)varDecl.Parent;
		DefiniteAssignmentAnalysis definiteAssignmentAnalysis = new DefiniteAssignmentAnalysis(blockStatement, context.CancellationToken);
		definiteAssignmentAnalysis.SetAnalyzedRange(targetStatement, blockStatement, startInclusive: false);
		definiteAssignmentAnalysis.Analyze(varDecl.Variables.Single().Name, context.CancellationToken);
		return definiteAssignmentAnalysis.UnassignedVariableUses.Count == 0;
	}

	private bool CanMoveVariableDeclarationIntoStatement(VariableDeclarationStatement varDecl, Statement targetStatement, out Statement declarationPoint)
	{
		List<BlockStatement> list = targetStatement.Ancestors.TakeWhile((AstNode block) => block != varDecl.Parent).OfType<BlockStatement>().ToList();
		list.Add((BlockStatement)varDecl.Parent);
		list.Reverse();
		DefiniteAssignmentAnalysis daa = new DefiniteAssignmentAnalysis(list[0], context.CancellationToken);
		declarationPoint = null;
		foreach (BlockStatement item in list)
		{
			if (!DeclareVariables.FindDeclarationPoint(daa, varDecl, item, out declarationPoint, context.CancellationToken))
			{
				return false;
			}
		}
		return true;
	}

	private bool HasAssignment(AstNode root, string variableName)
	{
		foreach (AstNode item in root.DescendantsAndSelf)
		{
			if (item is IdentifierExpression identifierExpression && identifierExpression.Identifier == variableName && ((identifierExpression.Parent is AssignmentExpression && identifierExpression.Role == AssignmentExpression.LeftRole) || identifierExpression.Parent is DirectionExpression))
			{
				return true;
			}
		}
		return false;
	}

	public ForeachStatement TransformForeach(UsingStatement node)
	{
		Match match = genericForeachPattern.Match(node);
		if (!match.Success)
		{
			return null;
		}
		if (!(node.Parent is BlockStatement) && match.Has("variablesOutsideLoop"))
		{
			return null;
		}
		IdentifierExpression identifierExpression = match.Get<IdentifierExpression>("itemVariable").Single();
		WhileStatement whileStatement = match.Get<WhileStatement>("loop").Single();
		VariableDeclarationStatement variableDeclarationStatement = FindVariableDeclaration(whileStatement, identifierExpression.Identifier);
		if (variableDeclarationStatement == null || !(variableDeclarationStatement.Parent is BlockStatement))
		{
			return null;
		}
		CanMoveVariableDeclarationIntoStatement(variableDeclarationStatement, whileStatement, out var declarationPoint);
		if (declarationPoint != whileStatement)
		{
			return null;
		}
		BlockStatement blockStatement = new BlockStatement();
		foreach (Statement item in match.Get<Statement>("variablesInsideLoop"))
		{
			blockStatement.Add(item.Detach());
		}
		foreach (Statement item2 in match.Get<Statement>("statement"))
		{
			blockStatement.Add(item2.Detach());
		}
		if (node.EmbeddedStatement is BlockStatement blockStatement2)
		{
			blockStatement.HiddenStart = blockStatement2.HiddenStart;
			blockStatement.HiddenEnd = blockStatement2.HiddenEnd;
		}
		ForeachStatement foreachStatement = new ForeachStatement
		{
			VariableType = variableDeclarationStatement.Type.Clone(),
			VariableNameToken = (Identifier)identifierExpression.IdentifierToken.Clone(),
			InExpression = match.Get<Expression>("collection").Single().Detach(),
			EmbeddedStatement = blockStatement
		}.WithAnnotation(variableDeclarationStatement.Variables.Single().Annotation<ILVariable>());
		if (foreachStatement.InExpression is BaseReferenceExpression)
		{
			foreachStatement.InExpression = new ThisReferenceExpression().CopyAnnotationsFrom(foreachStatement.InExpression);
		}
		foreachStatement.HiddenGetEnumeratorNode = match.Get<VariableInitializer>("enumeratorVariable").Single();
		foreachStatement.HiddenGetCurrentNode = match.Get<AstNode>("getCurrent").Single();
		foreachStatement.HiddenMoveNextNode = whileStatement.Condition;
		node.ReplaceWith(foreachStatement);
		foreach (Statement item3 in match.Get<Statement>("variablesOutsideLoop"))
		{
			((BlockStatement)foreachStatement.Parent).Statements.InsertAfter(null, item3.Detach());
		}
		return foreachStatement;
	}

	public ForeachStatement TransformNonGenericForEach(ExpressionStatement node)
	{
		Match match = getEnumeratorPattern.Match(node);
		if (!match.Success)
		{
			return null;
		}
		AstNode nextSibling = node.NextSibling;
		Match match2 = nonGenericForeachPattern.Match(nextSibling);
		if (!match2.Success)
		{
			match2 = nonGenericForeachPatternNoFinallyBlock.Match(nextSibling);
		}
		if (!match2.Success)
		{
			return null;
		}
		IdentifierExpression identifierExpression = match2.Get<IdentifierExpression>("enumerator").Single();
		IdentifierExpression identifierExpression2 = match2.Get<IdentifierExpression>("itemVar").Single();
		WhileStatement whileStatement = match2.Get<WhileStatement>("loop").Single();
		if (!identifierExpression.IsMatch(match.Get("left").Single()))
		{
			return null;
		}
		VariableDeclarationStatement variableDeclarationStatement = FindVariableDeclaration(whileStatement, identifierExpression.Identifier);
		if (variableDeclarationStatement == null || !(variableDeclarationStatement.Parent is BlockStatement))
		{
			return null;
		}
		VariableDeclarationStatement variableDeclarationStatement2 = FindVariableDeclaration(whileStatement, identifierExpression2.Identifier);
		if (variableDeclarationStatement2 == null || !(variableDeclarationStatement2.Parent is BlockStatement))
		{
			return null;
		}
		CanMoveVariableDeclarationIntoStatement(variableDeclarationStatement2, whileStatement, out var declarationPoint);
		if (declarationPoint != whileStatement)
		{
			return null;
		}
		ForeachStatement foreachStatement = new ForeachStatement
		{
			VariableType = variableDeclarationStatement2.Type.Clone(),
			VariableNameToken = (Identifier)identifierExpression2.IdentifierToken.Clone()
		}.WithAnnotation(variableDeclarationStatement2.Variables.Single().Annotation<ILVariable>());
		BlockStatement blockStatement = (BlockStatement)(foreachStatement.EmbeddedStatement = new BlockStatement());
		((BlockStatement)node.Parent).Statements.InsertBefore(node, foreachStatement);
		blockStatement.Add(node.Detach());
		blockStatement.Add((Statement)nextSibling.Detach());
		if (!IsVariableValueUnused(variableDeclarationStatement, foreachStatement))
		{
			((BlockStatement)foreachStatement.Parent).Statements.InsertBefore(foreachStatement, node.Detach());
			foreachStatement.ReplaceWith(nextSibling);
			return null;
		}
		TryCatchStatement tryCatchStatement = nextSibling as TryCatchStatement;
		if (tryCatchStatement != null)
		{
			foreachStatement.HiddenGetEnumeratorNode = ((!context.CalculateILSpans) ? tryCatchStatement.TryBlock.HiddenStart : NRefactoryExtensions.CreateHidden(tryCatchStatement.TryBlock.HiddenStart, match.Get<AssignmentExpression>("getEnumeratorAssignment").Single()));
			foreachStatement.HiddenGetEnumeratorNode = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : ILSpan.OrderAndCompactList(tryCatchStatement.TryBlock.GetAllILSpans()), foreachStatement.HiddenGetEnumeratorNode);
		}
		foreachStatement.HiddenMoveNextNode = whileStatement.Condition;
		foreachStatement.HiddenGetCurrentNode = match2.Get<AstNode>("getCurrent").Single();
		if (whileStatement.EmbeddedStatement is BlockStatement blockStatement2)
		{
			blockStatement.HiddenStart = blockStatement2.HiddenStart;
			blockStatement.HiddenEnd = blockStatement2.HiddenEnd;
		}
		if (context.CalculateILSpans && tryCatchStatement != null)
		{
			blockStatement.HiddenEnd = NRefactoryExtensions.CreateHidden(blockStatement.HiddenEnd, tryCatchStatement.TryBlock.HiddenEnd, tryCatchStatement.FinallyBlock);
		}
		foreachStatement.InExpression = match.Get<Expression>("collection").Single().Detach();
		if (foreachStatement.InExpression is BaseReferenceExpression)
		{
			foreachStatement.InExpression = new ThisReferenceExpression().CopyAnnotationsFrom(foreachStatement.InExpression).WithAnnotation(foreachStatement.InExpression.GetAllRecursiveILSpans());
		}
		blockStatement.Statements.Clear();
		blockStatement.Statements.AddRange(from stmt in match2.Get<Statement>("stmt")
			select stmt.Detach());
		return foreachStatement;
	}

	public ForeachStatement TransformForeachArrayOrString(ExpressionStatement node)
	{
		ExpressionStatement expressionStatement = null;
		AstNode astNode = node;
		Match match = variableAssignPattern.Match(astNode);
		if (match.Success)
		{
			expressionStatement = (ExpressionStatement)astNode;
			astNode = astNode.NextSibling;
		}
		Match match2 = variableZeroAssignPattern.Match(astNode);
		if (!match2.Success)
		{
			match2 = variableZeroAssignPattern.Match(expressionStatement);
			if (!match2.Success)
			{
				return null;
			}
			astNode = expressionStatement;
			expressionStatement = null;
			match = default(Match);
		}
		ExpressionStatement expressionStatement2 = (ExpressionStatement)astNode;
		Match match3 = foreachStringOrArrayPattern.Match(expressionStatement2.NextSibling);
		if (!match3.Success)
		{
			return null;
		}
		WhileStatement whileStatement = (WhileStatement)expressionStatement2.NextSibling;
		IdentifierExpression identifierExpression = match3.Get<IdentifierExpression>("loopArray").Single();
		TypeInformation typeInformation = identifierExpression.Annotation<TypeInformation>();
		TypeSig a = (typeInformation?.InferredType ?? typeInformation?.ExpectedType).RemovePinnedAndModifiers();
		if (a.GetElementType() != ElementType.SZArray && a.GetElementType() != ElementType.String)
		{
			return null;
		}
		if (match.Success && !identifierExpression.IsMatch(match.Get("variable").Single()))
		{
			expressionStatement = null;
		}
		IdentifierExpression loopInit = match2.Get<IdentifierExpression>("initializer").Single();
		INode other = match3.Get("i").Single();
		if (!loopInit.IsMatch(other))
		{
			return null;
		}
		VariableDeclarationStatement variableDeclarationStatement = FindVariableDeclaration(node, loopInit.Identifier);
		if (variableDeclarationStatement == null || !IsVariableValueUnused(variableDeclarationStatement, whileStatement))
		{
			return null;
		}
		IEnumerable<INode> source = match3.Get("statement");
		if (expressionStatement != null)
		{
			string id = ((IdentifierExpression)((AssignmentExpression)expressionStatement.Expression).Left).Identifier;
			if (source.Cast<AstNode>().Any((AstNode astNode2) => astNode2.DescendantsAndSelf.OfType<IdentifierExpression>().Any((IdentifierExpression i) => i.Identifier == loopInit.Identifier || i.Identifier == id)))
			{
				return null;
			}
		}
		else if (source.Cast<AstNode>().Any((AstNode astNode2) => astNode2.DescendantsAndSelf.OfType<IdentifierExpression>().Any((IdentifierExpression i) => i.Identifier == loopInit.Identifier)))
		{
			return null;
		}
		AstType parameterOrVariableType = GetParameterOrVariableType(whileStatement, identifierExpression.Identifier);
		AstType astType;
		if (parameterOrVariableType is ComposedType)
		{
			ComposedType composedType = (ComposedType)parameterOrVariableType;
			if (!composedType.ArraySpecifiers.Any())
			{
				return null;
			}
			astType = composedType.BaseType;
		}
		else
		{
			if (!(parameterOrVariableType is PrimitiveType))
			{
				return null;
			}
			PrimitiveType primitiveType = (PrimitiveType)parameterOrVariableType;
			if (primitiveType.KnownTypeCode != KnownTypeCode.String)
			{
				return null;
			}
			astType = new PrimitiveType("char").WithAnnotation(context.CurrentModule.CorLibTypes.Char.TypeDefOrRef);
		}
		ExpressionStatement expressionStatement3 = match3.Get<ExpressionStatement>("variable").Single();
		Expression right = ((AssignmentExpression)expressionStatement3.Expression).Right;
		if (right is CastExpression)
		{
			astType = ((CastExpression)right).Type;
		}
		BlockStatement blockStatement = (BlockStatement)whileStatement.EmbeddedStatement;
		BlockStatement blockStatement2 = new BlockStatement();
		blockStatement2.Statements.AddRange(from Statement node2 in source
			select node2.Detach());
		Expression expression = ((expressionStatement == null) ? identifierExpression.Clone() : ((AssignmentExpression)expressionStatement.Expression).Right.Clone());
		expressionStatement?.Detach();
		expressionStatement2.Detach();
		ForeachStatement foreachStatement = new ForeachStatement
		{
			VariableType = astType.Clone().Detach(),
			VariableNameToken = match3.Get<IdentifierExpression>("loopVar").Single().IdentifierToken.Detach(),
			InExpression = expression,
			EmbeddedStatement = blockStatement2
		};
		foreachStatement.WithAnnotation(((AssignmentExpression)expressionStatement3.Expression).Left.Annotation<ILVariable>());
		if (context.CalculateILSpans)
		{
			ExpressionStatement expressionStatement4 = match3.Get<ExpressionStatement>("increment").Single();
			expression.RemoveAllILSpansRecursive();
			blockStatement2.HiddenStart = blockStatement.HiddenStart;
			blockStatement2.HiddenEnd = blockStatement.HiddenEnd;
			foreachStatement.HiddenInitializer = expressionStatement;
			foreachStatement.HiddenGetEnumeratorNode = expressionStatement2;
			foreachStatement.HiddenMoveNextNode = expressionStatement4;
			whileStatement.Condition.AddAllRecursiveILSpansTo(expressionStatement4);
			foreachStatement.HiddenGetCurrentNode = expressionStatement3;
		}
		whileStatement.ReplaceWith(foreachStatement);
		return foreachStatement;
	}

	public ForStatement TransformFor(ExpressionStatement node)
	{
		Match match = variableAssignPattern.Match(node);
		if (!match.Success)
		{
			return null;
		}
		AstNode nextSibling = node.NextSibling;
		Match match2 = forPattern.Match(nextSibling);
		if (!match2.Success)
		{
			return null;
		}
		if (match.Get<IdentifierExpression>("variable").Single().Identifier != match2.Get<IdentifierExpression>("ident").Single().Identifier)
		{
			return null;
		}
		WhileStatement whileStatement = (WhileStatement)nextSibling;
		node.Remove();
		BlockStatement blockStatement = new BlockStatement();
		foreach (Statement item in match2.Get<Statement>("statement"))
		{
			blockStatement.Add(item.Detach());
		}
		ForStatement forStatement = new ForStatement();
		forStatement.Initializers.Add(node);
		forStatement.Condition = whileStatement.Condition.Detach();
		forStatement.Iterators.Add(match2.Get<Statement>("increment").Single().Detach());
		forStatement.EmbeddedStatement = blockStatement;
		whileStatement.ReplaceWith(forStatement);
		if (whileStatement.EmbeddedStatement is BlockStatement blockStatement2)
		{
			blockStatement.HiddenStart = blockStatement2.HiddenStart;
			blockStatement.HiddenEnd = blockStatement2.HiddenEnd;
		}
		return forStatement;
	}

	private ForStatement TransformWhileTrueToForLoop(WhileStatement whileLoop)
	{
		if (!whileTrueLoopPattern.Match(whileLoop).Success)
		{
			return null;
		}
		ForStatement forStatement = new ForStatement();
		forStatement.EmbeddedStatement = whileLoop.EmbeddedStatement.Detach();
		if (context.CalculateILSpans)
		{
			BlockStatement blockStatement = (BlockStatement)forStatement.EmbeddedStatement;
			if (blockStatement.HiddenStart == null)
			{
				blockStatement.HiddenStart = whileLoop.Condition;
			}
			else
			{
				EmptyStatement emptyStatement = new EmptyStatement();
				blockStatement.HiddenStart.AddAllRecursiveILSpansTo(emptyStatement);
				whileLoop.Condition.AddAllRecursiveILSpansTo(emptyStatement);
				blockStatement.HiddenStart = emptyStatement;
			}
		}
		whileLoop.ReplaceWith(forStatement);
		return forStatement;
	}

	public DoWhileStatement TransformDoWhile(WhileStatement whileLoop)
	{
		Match match = doWhilePattern.Match(whileLoop);
		if (match.Success)
		{
			DoWhileStatement doWhileStatement = new DoWhileStatement();
			doWhileStatement.Condition = new UnaryOperatorExpression(UnaryOperatorType.Not, match.Get<Expression>("condition").Single().Detach());
			doWhileStatement.Condition.AcceptVisitor(new PushNegation(), null);
			BlockStatement blockStatement = (BlockStatement)whileLoop.EmbeddedStatement;
			Statement statement = blockStatement.Statements.Last();
			statement.Remove();
			statement.AddAllRecursiveILSpansTo(doWhileStatement.Condition);
			doWhileStatement.EmbeddedStatement = blockStatement.Detach();
			whileLoop.ReplaceWith(doWhileStatement);
			blockStatement.HiddenStart = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : ILSpan.OrderAndCompactList(whileLoop.Condition.GetAllRecursiveILSpans()), blockStatement.HiddenStart);
			{
				foreach (VariableDeclarationStatement item in blockStatement.Statements.OfType<VariableDeclarationStatement>())
				{
					VariableInitializer v = item.Variables.Single();
					if (doWhileStatement.Condition.DescendantsAndSelf.OfType<IdentifierExpression>().Any((IdentifierExpression i) => i.Identifier == v.Name))
					{
						object obj = null;
						ILVariable iLVariable = v.Annotation<ILVariable>();
						if (iLVariable != null)
						{
							obj = (iLVariable.IsParameter ? BoxedTextColor.Parameter : BoxedTextColor.Local);
						}
						dnlib.DotNet.IVariable variable = v.Annotation<dnlib.DotNet.IVariable>();
						if (obj == null && variable != null)
						{
							obj = context.MetadataTextColorProvider.GetColor(variable);
						}
						AssignmentExpression assignmentExpression = new AssignmentExpression(IdentifierExpression.Create(v.Name, obj ?? BoxedTextColor.Local), v.Initializer.Detach());
						assignmentExpression.CopyAnnotationsFrom(v);
						v.RemoveAnnotations<object>();
						item.ReplaceWith(new ExpressionStatement(assignmentExpression).CopyAnnotationsFrom(item).WithAnnotation(item.GetAllRecursiveILSpans()));
						item.RemoveAnnotations<object>();
						doWhileStatement.Parent.InsertChildBefore(doWhileStatement, item, BlockStatement.StatementRole);
					}
				}
				return doWhileStatement;
			}
		}
		return null;
	}

	private bool AnalyzeLockV2(ExpressionStatement node, out Expression enter, out Expression exit)
	{
		enter = null;
		exit = null;
		Match match = oldMonitorCallPattern.Match(node);
		if (!match.Success)
		{
			return false;
		}
		Match match2 = oldLockTryCatchPattern.Match(node.NextSibling);
		if (!match2.Success)
		{
			return false;
		}
		enter = match.Get<Expression>("enter").Single();
		exit = match2.Get<Expression>("exit").Single();
		return true;
	}

	private bool AnalyzeLockV4(ExpressionStatement node, out Expression enter, out Expression exit)
	{
		enter = null;
		exit = null;
		Match match = lockFlagInitPattern.Match(node);
		if (!match.Success)
		{
			return false;
		}
		Match match2 = lockTryCatchPattern.Match(node.NextSibling);
		if (!match2.Success)
		{
			return false;
		}
		enter = match2.Get<Expression>("enter").Single();
		exit = match2.Get<Expression>("exit").Single();
		return match.Get<IdentifierExpression>("variable").Single().Identifier == match2.Get<IdentifierExpression>("flag").Single().Identifier;
	}

	public LockStatement TransformLock(ExpressionStatement node)
	{
		bool flag = AnalyzeLockV2(node, out var enter, out var exit);
		if (flag || AnalyzeLockV4(node, out enter, out exit))
		{
			TryCatchStatement tryCatchStatement = (TryCatchStatement)node.NextSibling;
			if (!exit.IsMatch(enter))
			{
				if (!(enter is AssignmentExpression assignmentExpression))
				{
					return null;
				}
				if (!exit.IsMatch(assignmentExpression.Left))
				{
					return null;
				}
				enter = assignmentExpression.Right;
			}
			LockStatement lockStatement = new LockStatement();
			lockStatement.Expression = enter.Detach();
			lockStatement.EmbeddedStatement = tryCatchStatement.TryBlock.Detach();
			BlockStatement blockStatement = (BlockStatement)lockStatement.EmbeddedStatement;
			if (blockStatement.HiddenStart != null)
			{
				blockStatement.HiddenStart.AddAllRecursiveILSpansTo(lockStatement.Expression);
				blockStatement.HiddenStart = null;
			}
			if (!flag)
			{
				Statement statement = blockStatement.Statements.First();
				statement.Remove();
				statement.AddAllRecursiveILSpansTo(lockStatement.Expression);
			}
			tryCatchStatement.ReplaceWith(lockStatement);
			if (context.CalculateILSpans)
			{
				blockStatement.HiddenEnd = NRefactoryExtensions.CreateHidden(blockStatement.HiddenEnd, tryCatchStatement.FinallyBlock);
			}
			node.AddAllRecursiveILSpansTo(lockStatement.Expression);
			node.Remove();
			return lockStatement;
		}
		return null;
	}

	public SwitchStatement TransformSwitchOnString(IfElseStatement node)
	{
		Match match = switchOnStringPattern.Match(node);
		if (!match.Success)
		{
			return null;
		}
		if (!match.Get("switchVar").Single().IsMatch(match.Get("switchExpr").Single()) && (!(match.Get("switchExpr").Single() is AssignmentExpression assignmentExpression) || !match.Get("switchVar").Single().IsMatch(assignmentExpression.Left)))
		{
			return null;
		}
		dnlib.DotNet.IField field = match.Get<AstNode>("cachedDict").Single().Annotation<dnlib.DotNet.IField>();
		if (field == null)
		{
			return null;
		}
		List<Statement> dictCreation = match.Get<BlockStatement>("dictCreation").Single().Statements.ToList();
		List<KeyValuePair<string, int>> list = BuildDictionary(dictCreation);
		SwitchStatement switchStatement = match.Get<SwitchStatement>("switch").Single();
		Expression expression = switchStatement.Expression;
		switchStatement.Expression = match.Get<Expression>("switchExpr").Single().Detach();
		expression.AddAllRecursiveILSpansTo(switchStatement.Expression);
		foreach (SwitchSection switchSection3 in switchStatement.SwitchSections)
		{
			List<CaseLabel> list2 = switchSection3.CaseLabels.ToList();
			switchSection3.CaseLabels.Clear();
			foreach (CaseLabel item in list2)
			{
				if (!(item.Expression is PrimitiveExpression primitiveExpression) || !(primitiveExpression.Value is int))
				{
					continue;
				}
				int num = (int)primitiveExpression.Value;
				foreach (KeyValuePair<string, int> item2 in list)
				{
					if (item2.Value == num)
					{
						switchSection3.CaseLabels.Add(new CaseLabel
						{
							Expression = new PrimitiveExpression(item2.Key)
						});
					}
				}
			}
		}
		if (match.Has("nullStmt"))
		{
			SwitchSection switchSection = new SwitchSection();
			switchSection.CaseLabels.Add(new CaseLabel
			{
				Expression = new NullReferenceExpression()
			});
			BlockStatement blockStatement = match.Get<BlockStatement>("nullStmt").Single();
			blockStatement.Statements.Add(new BreakStatement());
			switchSection.Statements.Add(blockStatement.Detach());
			switchStatement.SwitchSections.Add(switchSection);
		}
		else if (match.Has("nonNullDefaultStmt"))
		{
			switchStatement.SwitchSections.Add(new SwitchSection
			{
				CaseLabels = 
				{
					new CaseLabel
					{
						Expression = new NullReferenceExpression()
					}
				},
				Statements = { (Statement)new BlockStatement
				{
					new BreakStatement()
				} }
			});
		}
		if (match.Has("nonNullDefaultStmt"))
		{
			SwitchSection switchSection2 = new SwitchSection();
			switchSection2.CaseLabels.Add(new CaseLabel());
			BlockStatement blockStatement2 = new BlockStatement();
			blockStatement2.Statements.AddRange(from s in match.Get<Statement>("nonNullDefaultStmt")
				select s.Detach());
			blockStatement2.Add(new BreakStatement());
			switchSection2.Statements.Add(blockStatement2);
			switchStatement.SwitchSections.Add(switchSection2);
		}
		node.ReplaceWith(switchStatement);
		node.AddAllRecursiveILSpansTo(switchStatement.Expression);
		return switchStatement;
	}

	private List<KeyValuePair<string, int>> BuildDictionary(List<Statement> dictCreation)
	{
		if (context.Settings.ObjectOrCollectionInitializers && dictCreation.Count == 1)
		{
			return BuildDictionaryFromInitializer(dictCreation[0]);
		}
		return BuildDictionaryFromAddMethodCalls(dictCreation);
	}

	private List<KeyValuePair<string, int>> BuildDictionaryFromInitializer(Statement statement)
	{
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		Match match = assignInitializedDictionary.Match(statement);
		if (!match.Success)
		{
			return list;
		}
		foreach (ArrayInitializerExpression item in match.Get<ArrayInitializerExpression>("dictJumpTable"))
		{
			if (TryGetPairFrom(item.Elements, out var pair))
			{
				list.Add(pair);
			}
		}
		return list;
	}

	private static List<KeyValuePair<string, int>> BuildDictionaryFromAddMethodCalls(List<Statement> dictCreation)
	{
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		for (int i = 0; i < dictCreation.Count; i++)
		{
			if (dictCreation[i] is ExpressionStatement { Expression: InvocationExpression expression } && TryGetPairFrom(expression.Arguments, out var pair))
			{
				list.Add(pair);
			}
		}
		return list;
	}

	private static bool TryGetPairFrom(AstNodeCollection<Expression> expressions, out KeyValuePair<string, int> pair)
	{
		PrimitiveExpression primitiveExpression = expressions.ElementAtOrDefault(0) as PrimitiveExpression;
		PrimitiveExpression primitiveExpression2 = expressions.ElementAtOrDefault(1) as PrimitiveExpression;
		if (primitiveExpression != null && primitiveExpression2 != null && primitiveExpression.Value is string && primitiveExpression2.Value is int)
		{
			pair = new KeyValuePair<string, int>((string)primitiveExpression.Value, (int)primitiveExpression2.Value);
			return true;
		}
		pair = default(KeyValuePair<string, int>);
		return false;
	}

	private PropertyDeclaration TransformAutomaticProperties(PropertyDeclaration property)
	{
		PropertyDef propertyDef = property.Annotation<PropertyDef>();
		if (propertyDef == null || propertyDef.GetMethod == null)
		{
			return null;
		}
		if (!propertyDef.GetMethod.IsCompilerGenerated())
		{
			return null;
		}
		if (propertyDef.SetMethod != null && !propertyDef.SetMethod.IsCompilerGenerated())
		{
			return null;
		}
		Match match = automaticPropertyPattern.Match(property);
		if (!match.Success)
		{
			match = automaticReadOnlyPropertyPattern.Match(property);
		}
		if (match.Success)
		{
			FieldDef fieldDef = match.Get<AstNode>("fieldReference").Single().Annotation<dnlib.DotNet.IField>()
				.ResolveFieldWithinSameModule();
			if (fieldDef != null && fieldDef.IsCompilerGenerated() && fieldDef.DeclaringType == propertyDef.DeclaringType)
			{
				RemoveCompilerGeneratedAttribute(property.Getter.Attributes);
				RemoveCompilerGeneratedAttribute(property.Setter.Attributes);
				MethodDebugInfoBuilder methodDebugInfoBuilder = property.Getter.Body.Annotation<MethodDebugInfoBuilder>();
				MethodDebugInfoBuilder methodDebugInfoBuilder2 = property.Setter.Body.Annotation<MethodDebugInfoBuilder>();
				if (methodDebugInfoBuilder != null)
				{
					property.Getter.AddAnnotation(methodDebugInfoBuilder);
				}
				if (methodDebugInfoBuilder2 != null)
				{
					property.Setter.AddAnnotation(methodDebugInfoBuilder2);
				}
				property.Getter.Body = null;
				property.Setter.Body = null;
				if (propertyDef.GetMethod.Body != null)
				{
					property.Getter.AddAnnotation(new List<ILSpan>
					{
						new ILSpan(0u, (uint)propertyDef.GetMethod.Body.GetCodeSize())
					});
				}
				if (propertyDef.SetMethod?.Body != null)
				{
					property.Setter.AddAnnotation(new List<ILSpan>
					{
						new ILSpan(0u, (uint)propertyDef.SetMethod.Body.GetCodeSize())
					});
				}
			}
		}
		return null;
	}

	private void RemoveCompilerGeneratedAttribute(AstNodeCollection<AttributeSection> attributeSections)
	{
		RemoveAttribuets(attributeSections, compilerGeneratedAttributeNames);
	}

	private void RemoveEventAttributes(AstNodeCollection<AttributeSection> attributeSections)
	{
		RemoveAttribuets(attributeSections, eventAttributesToRemove);
	}

	private void RemoveAttribuets(AstNodeCollection<AttributeSection> attributeSections, KeyValuePair<UTF8String, UTF8String>[] attrNames)
	{
		foreach (AttributeSection attributeSection in attributeSections)
		{
			foreach (ICSharpCode.NRefactory.CSharp.Attribute attribute in attributeSection.Attributes)
			{
				ITypeDefOrRef typeDefOrRef = attribute.Type.Annotation<ITypeDefOrRef>();
				if (typeDefOrRef == null)
				{
					continue;
				}
				for (int i = 0; i < attrNames.Length; i++)
				{
					KeyValuePair<UTF8String, UTF8String> keyValuePair = attrNames[i];
					if (typeDefOrRef.Compare(keyValuePair.Key, keyValuePair.Value))
					{
						attribute.Remove();
						break;
					}
				}
			}
			if (attributeSection.Attributes.Count == 0)
			{
				attributeSection.Remove();
			}
		}
	}

	private bool CheckAutomaticEventV4Match(Match m, CustomEventDeclaration ev, bool isAddAccessor, bool hasType)
	{
		if (!m.Success)
		{
			return false;
		}
		if (!AstBuilder.IsEventBackingFieldName(m.Get<MemberReferenceExpression>("field").Single().MemberName, ev.Name))
		{
			return false;
		}
		if (hasType && !ev.ReturnType.IsMatch(m.Get("type").Single()))
		{
			return false;
		}
		dnlib.DotNet.IMethod method = m.Get<AstNode>("delegateCombine").Single().Parent.Annotation<dnlib.DotNet.IMethod>();
		if (method == null || method.Name != (isAddAccessor ? "Combine" : "Remove"))
		{
			return false;
		}
		if (method.DeclaringType != null)
		{
			return method.DeclaringType.FullName == "System.Delegate";
		}
		return false;
	}

	private EventDeclaration TransformAutomaticEvents(CustomEventDeclaration ev)
	{
		Accessor pattern = automaticEventPatternV4;
		bool hasType = true;
		Match m = pattern.Match(ev.AddAccessor);
		if (!m.Success)
		{
			m = (pattern = automaticEventPatternMcs46).Match(ev.AddAccessor);
		}
		if (!m.Success)
		{
			m = (pattern = automaticEventPatternV35).Match(ev.AddAccessor);
			hasType = false;
		}
		if (!CheckAutomaticEventV4Match(m, ev, isAddAccessor: true, hasType))
		{
			return null;
		}
		Match m2 = pattern.Match(ev.RemoveAccessor);
		if (!CheckAutomaticEventV4Match(m2, ev, isAddAccessor: false, hasType))
		{
			return null;
		}
		EventDeclaration eventDeclaration = new EventDeclaration();
		ev.Attributes.MoveTo(eventDeclaration.Attributes);
		foreach (AttributeSection attribute in ev.AddAccessor.Attributes)
		{
			attribute.AttributeTarget = "method";
			eventDeclaration.Attributes.Add(attribute.Detach());
		}
		eventDeclaration.ReturnType = ev.ReturnType.Detach();
		eventDeclaration.Modifiers = ev.Modifiers;
		eventDeclaration.Variables.Add(new VariableInitializer(context.MetadataTextColorProvider.GetColor(ev.Annotation<EventDef>()), ev.Name));
		eventDeclaration.CopyAnnotationsFrom(ev);
		AstNode[] array = ev.Children.Reverse().ToArray();
		foreach (AstNode astNode in array)
		{
			if (astNode is Comment node)
			{
				eventDeclaration.InsertChildAfter(null, node.Detach(), Roles.Comment);
			}
			else
			{
				if (!(astNode is Accessor accessor))
				{
					continue;
				}
				AstNode[] array2 = accessor.Children.Reverse().ToArray();
				foreach (AstNode astNode2 in array2)
				{
					if (astNode2 is Comment node2)
					{
						eventDeclaration.InsertChildAfter(null, node2.Detach(), Roles.Comment);
					}
				}
			}
		}
		EventDef eventDef = ev.Annotation<EventDef>();
		if (eventDef != null)
		{
			FieldDef fieldDef = eventDef.DeclaringType.Fields.FirstOrDefault((FieldDef f) => f.Name == ev.Name);
			if (fieldDef != null)
			{
				eventDeclaration.AddAnnotation(fieldDef);
				AstBuilder.ConvertAttributes(context.MetadataTextColorProvider, eventDeclaration, fieldDef, context.Settings, stringBuilder, "field");
			}
		}
		RemoveEventAttributes(eventDeclaration.Attributes);
		ev.ReplaceWith(eventDeclaration);
		ev.AddAllRecursiveILSpansTo(ev);
		return eventDeclaration;
	}

	private DestructorDeclaration TransformDestructor(MethodDeclaration methodDef)
	{
		Match match = destructorPattern.Match(methodDef);
		if (match.Success)
		{
			DestructorDeclaration destructorDeclaration = new DestructorDeclaration();
			destructorDeclaration.AddAnnotation(methodDef.Annotation<MethodDef>());
			methodDef.Attributes.MoveTo(destructorDeclaration.Attributes);
			destructorDeclaration.Modifiers = methodDef.Modifiers & ~(Modifiers.Protected | Modifiers.Override);
			destructorDeclaration.Body = match.Get<BlockStatement>("body").Single().Detach();
			destructorDeclaration.AddAnnotation(methodDef.Annotation<MethodDebugInfoBuilder>());
			TryCatchStatement tryCatchStatement = (TryCatchStatement)methodDef.Body.FirstChild;
			if (context.CalculateILSpans)
			{
				destructorDeclaration.Body.HiddenStart = NRefactoryExtensions.CreateHidden(destructorDeclaration.Body.HiddenStart, methodDef.Body.HiddenStart);
				destructorDeclaration.Body.HiddenEnd = NRefactoryExtensions.CreateHidden(destructorDeclaration.Body.HiddenEnd, methodDef.Body.HiddenEnd, tryCatchStatement.FinallyBlock);
			}
			destructorDeclaration.NameToken = Identifier.Create(AstBuilder.CleanName(context.CurrentType.Name)).WithAnnotation(context.CurrentType);
			methodDef.ReplaceWith(destructorDeclaration);
			AstNode[] array = methodDef.Children.Reverse().ToArray();
			foreach (AstNode astNode in array)
			{
				if (astNode is Comment comment)
				{
					comment.Detach();
					destructorDeclaration.InsertChildAfter(null, comment, Roles.Comment);
				}
			}
			return destructorDeclaration;
		}
		return null;
	}

	private TryCatchStatement TransformTryCatchFinally(TryCatchStatement tryFinally)
	{
		if (tryCatchFinallyPattern.IsMatch(tryFinally))
		{
			TryCatchStatement tryCatchStatement = (TryCatchStatement)tryFinally.TryBlock.Statements.Single();
			if (context.CalculateILSpans)
			{
				tryCatchStatement.TryBlock.HiddenStart = NRefactoryExtensions.CreateHidden(tryCatchStatement.TryBlock.HiddenStart, tryFinally.TryBlock.HiddenStart);
				tryCatchStatement.TryBlock.HiddenEnd = NRefactoryExtensions.CreateHidden(tryCatchStatement.TryBlock.HiddenEnd, tryFinally.TryBlock.HiddenEnd);
			}
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
			IfElseStatement ifElseStatement = match.Get<IfElseStatement>("nestedIfStatement").Single();
			BlockStatement blockStatement = (BlockStatement)node.FalseStatement;
			node.FalseStatement = ifElseStatement.Detach();
			blockStatement.HiddenStart.AddAllRecursiveILSpansTo(node.Condition);
			if (blockStatement.HiddenEnd != null)
			{
				Statement statement = (ifElseStatement.FalseStatement.IsNull ? ifElseStatement.TrueStatement : ifElseStatement.FalseStatement);
				if (statement is BlockStatement blockStatement2)
				{
					if (context.CalculateILSpans)
					{
						blockStatement2.HiddenEnd = NRefactoryExtensions.CreateHidden(blockStatement2.HiddenEnd, blockStatement.HiddenEnd);
					}
				}
				else
				{
					blockStatement.HiddenEnd.AddAllRecursiveILSpansTo(statement);
				}
			}
		}
		return null;
	}
}
