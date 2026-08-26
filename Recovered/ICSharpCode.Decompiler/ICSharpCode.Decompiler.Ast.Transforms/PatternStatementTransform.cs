using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Analysis;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public sealed class PatternStatementTransform : ContextTrackingVisitor<AstNode>, IAstTransform
	{
		private static readonly AstNode variableAssignPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new AnyNode("initializer")));

		private static readonly AstNode usingTryCatchPattern = new Choice
		{
			{
				"c#/vb",
				new TryCatchStatement
				{
					TryBlock = new AnyNode(),
					FinallyBlock = new BlockStatement
					{
						new Choice
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
						}.ToStatement()
					}
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
				Variables = 
				{
					(VariableInitializer)new NamedNode("enumeratorVariable", new VariableInitializer
					{
						Name = Pattern.AnyString,
						Initializer = new AnyNode("collection").ToExpression().Invoke("GetEnumerator")
					})
				}
			},
			EmbeddedStatement = new BlockStatement
			{
				new Repeat(new VariableDeclarationStatement
				{
					Type = new AnyNode(),
					Variables = 
					{
						new VariableInitializer(Pattern.AnyString)
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
								new VariableInitializer(Pattern.AnyString)
							}
						}.WithName("variablesInsideLoop")).ToStatement(),
						new AssignmentExpression
						{
							Left = new IdentifierExpression(Pattern.AnyString).WithName("itemVariable"),
							Operator = AssignmentOperatorType.Assign,
							Right = new IdentifierExpressionBackreference("enumeratorVariable").ToExpression().Member("Current")
						},
						new Repeat(new AnyNode("statement")).ToStatement()
					}
				}.WithName("loop")
			}
		};

		private ExpressionStatement getEnumeratorPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("left", new IdentifierExpression(Pattern.AnyString)), new AnyNode("collection").ToExpression().Invoke("GetEnumerator")));

		private TryCatchStatement nonGenericForeachPattern = new TryCatchStatement
		{
			TryBlock = new BlockStatement
			{
				new WhileStatement
				{
					Condition = new IdentifierExpression(Pattern.AnyString).WithName("enumerator").Invoke("MoveNext"),
					EmbeddedStatement = new BlockStatement
					{
						new AssignmentExpression(new IdentifierExpression(Pattern.AnyString).WithName("itemVar"), new Choice
						{
							new Backreference("enumerator").ToExpression().Member("Current"),
							new CastExpression
							{
								Type = new AnyNode("castType"),
								Expression = new Backreference("enumerator").ToExpression().Member("Current")
							}
						}),
						new Repeat(new AnyNode("stmt")).ToStatement()
					}
				}.WithName("loop")
			},
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
					TrueStatement = new BlockStatement
					{
						new Backreference("disposable").ToExpression().Invoke("Dispose")
					}
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
				new TypePattern(typeof(Monitor)).ToType().Invoke("Enter", new AnyNode("enter"), new DirectionExpression
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
					TrueStatement = new BlockStatement
					{
						new TypePattern(typeof(Monitor)).ToType().Invoke("Exit", new AnyNode("exit"))
					}
				}
			}
		};

		private static readonly AstNode oldMonitorCallPattern = new ExpressionStatement(new TypePattern(typeof(Monitor)).ToType().Invoke("Enter", new AnyNode("enter")));

		private static readonly AstNode oldLockTryCatchPattern = new TryCatchStatement
		{
			TryBlock = new BlockStatement
			{
				new Repeat(new AnyNode()).ToStatement()
			},
			FinallyBlock = new BlockStatement
			{
				new TypePattern(typeof(Monitor)).ToType().Invoke("Exit", new AnyNode("exit"))
			}
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
						Statements = 
						{
							(Statement)new NamedNode("switch", new SwitchStatement
							{
								Expression = new IdentifierExpressionBackreference("intVar"),
								SwitchSections = 
								{
									(SwitchSection)new Repeat(new AnyNode())
								}
							})
						}
					}
				},
				new Repeat(new AnyNode("nonNullDefaultStmt")).ToStatement()
			},
			FalseStatement = new OptionalNode("nullStmt", new BlockStatement
			{
				Statements = 
				{
					(Statement)new Repeat(new AnyNode())
				}
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
					Arguments = 
					{
						(Expression)new Repeat(new AnyNode())
					},
					Initializer = new ArrayInitializerExpression
					{
						Elements = 
						{
							(Expression)new Repeat(new AnyNode("dictJumpTable"))
						}
					}
				}
			}
		};

		private static readonly PropertyDeclaration automaticPropertyPattern = new PropertyDeclaration
		{
			Attributes = 
			{
				(AttributeSection)new Repeat(new AnyNode())
			},
			Modifiers = Modifiers.Any,
			ReturnType = new AnyNode(),
			PrivateImplementationType = new OptionalNode(new AnyNode()),
			Name = Pattern.AnyString,
			Getter = new Accessor
			{
				Attributes = 
				{
					(AttributeSection)new Repeat(new AnyNode())
				},
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
				Attributes = 
				{
					(AttributeSection)new Repeat(new AnyNode())
				},
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

		private static readonly Accessor automaticEventPatternV4 = new Accessor
		{
			Attributes = 
			{
				(AttributeSection)new Repeat(new AnyNode())
			},
			Body = new BlockStatement
			{
				new VariableDeclarationStatement
				{
					Type = new AnyNode("type"),
					Variables = 
					{
						(VariableInitializer)new AnyNode()
					}
				},
				new VariableDeclarationStatement
				{
					Type = new Backreference("type"),
					Variables = 
					{
						(VariableInitializer)new AnyNode()
					}
				},
				new VariableDeclarationStatement
				{
					Type = new Backreference("type"),
					Variables = 
					{
						(VariableInitializer)new AnyNode()
					}
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
							Right = new AnyNode("delegateCombine").ToExpression().Invoke(new IdentifierExpressionBackreference("var2"), new IdentifierExpression("value")).CastTo(new Backreference("type"))
						},
						new AssignmentExpression
						{
							Left = new IdentifierExpressionBackreference("var1"),
							Right = new TypePattern(typeof(Interlocked)).ToType().Invoke("CompareExchange", new AstType[1]
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

		private static readonly MethodDeclaration destructorPattern = new MethodDeclaration
		{
			Attributes = 
			{
				(AttributeSection)new Repeat(new AnyNode())
			},
			Modifiers = Modifiers.Any,
			ReturnType = new PrimitiveType("void"),
			Name = "Finalize",
			Body = new BlockStatement
			{
				new TryCatchStatement
				{
					TryBlock = new AnyNode("body"),
					FinallyBlock = new BlockStatement
					{
						new BaseReferenceExpression().Invoke("Finalize")
					}
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
					CatchClauses = 
					{
						(CatchClause)new Repeat(new AnyNode())
					}
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
				Statements = 
				{
					(Statement)new NamedNode("nestedIfStatement", new IfElseStatement
					{
						Condition = new AnyNode(),
						TrueStatement = new AnyNode(),
						FalseStatement = new OptionalNode(new AnyNode())
					})
				}
			}
		};

		public PatternStatementTransform(DecompilerContext context)
			: base(context)
		{
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
			return TransformDoWhile(whileStatement) ?? base.VisitWhileStatement(whileStatement, data);
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
			if (context.Settings.AutomaticProperties)
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
				if (iLVariable == null || iLVariable.Type == null || !iLVariable.Type.IsValueType)
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
			usingStatement.EmbeddedStatement = tryCatchStatement.TryBlock.Detach();
			tryCatchStatement.ReplaceWith(usingStatement);
			if (usingStatement.EmbeddedStatement.Descendants.OfType<IdentifierExpression>().Any((IdentifierExpression ident) => ident.Identifier == variableName))
			{
				usingStatement.ResourceAcquisition = new VariableDeclarationStatement
				{
					Type = variableDeclarationStatement.Type.Clone(),
					Variables = 
					{
						new VariableInitializer
						{
							Name = variableName,
							Initializer = match.Get<Expression>("initializer").Single().Detach()
						}.CopyAnnotationsFrom(node.Expression).WithAnnotation(match.Get<AstNode>("variable").Single().Annotation<ILVariable>())
					}
				}.CopyAnnotationsFrom(node);
			}
			else
			{
				usingStatement.ResourceAcquisition = match.Get<Expression>("initializer").Single().Detach();
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
					VariableDeclarationStatement variableDeclarationStatement = node as VariableDeclarationStatement;
					if (variableDeclarationStatement != null && variableDeclarationStatement.Variables.Count == 1 && variableDeclarationStatement.Variables.Single().Name == identifier)
					{
						return variableDeclarationStatement;
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
			definiteAssignmentAnalysis.Analyze(varDecl.Variables.Single().Name);
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
				if (!DeclareVariables.FindDeclarationPoint(daa, varDecl, item, out declarationPoint))
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
				IdentifierExpression identifierExpression = item as IdentifierExpression;
				if (identifierExpression != null && identifierExpression.Identifier == variableName && ((identifierExpression.Parent is AssignmentExpression && identifierExpression.Role == AssignmentExpression.LeftRole) || identifierExpression.Parent is DirectionExpression))
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
			VariableInitializer variableInitializer = match.Get<VariableInitializer>("enumeratorVariable").Single();
			IdentifierExpression identifierExpression = match.Get<IdentifierExpression>("itemVariable").Single();
			WhileStatement whileStatement = match.Get<WhileStatement>("loop").Single();
			VariableDeclarationStatement variableDeclarationStatement = FindVariableDeclaration(whileStatement, identifierExpression.Identifier);
			if (variableDeclarationStatement == null || !(variableDeclarationStatement.Parent is BlockStatement))
			{
				return null;
			}
			CanMoveVariableDeclarationIntoStatement(variableDeclarationStatement, whileStatement, out Statement declarationPoint);
			if (declarationPoint != whileStatement)
			{
				return null;
			}
			Identifier enumeratorId = Identifier.Create(variableInitializer.Name);
			foreach (Statement item in match.Get<Statement>("statement"))
			{
				if (item.Descendants.OfType<Identifier>().Any((Identifier id) => enumeratorId.IsMatch(id)))
				{
					return null;
				}
			}
			BlockStatement blockStatement = new BlockStatement();
			foreach (Statement item2 in match.Get<Statement>("variablesInsideLoop"))
			{
				blockStatement.Add(item2.Detach());
			}
			foreach (Statement item3 in match.Get<Statement>("statement"))
			{
				blockStatement.Add(item3.Detach());
			}
			ForeachStatement foreachStatement = new ForeachStatement
			{
				VariableType = variableDeclarationStatement.Type.Clone(),
				VariableName = identifierExpression.Identifier,
				InExpression = match.Get<Expression>("collection").Single().Detach(),
				EmbeddedStatement = blockStatement
			}.WithAnnotation(variableDeclarationStatement.Variables.Single().Annotation<ILVariable>());
			if (foreachStatement.InExpression is BaseReferenceExpression)
			{
				foreachStatement.InExpression = new ThisReferenceExpression().CopyAnnotationsFrom(foreachStatement.InExpression);
			}
			node.ReplaceWith(foreachStatement);
			foreach (Statement item4 in match.Get<Statement>("variablesOutsideLoop"))
			{
				((BlockStatement)foreachStatement.Parent).Statements.InsertAfter(null, item4.Detach());
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
			CanMoveVariableDeclarationIntoStatement(variableDeclarationStatement2, whileStatement, out Statement declarationPoint);
			if (declarationPoint != whileStatement)
			{
				return null;
			}
			ForeachStatement foreachStatement = new ForeachStatement
			{
				VariableType = variableDeclarationStatement2.Type.Clone(),
				VariableName = identifierExpression2.Identifier
			}.WithAnnotation(variableDeclarationStatement2.Variables.Single().Annotation<ILVariable>());
			BlockStatement blockStatement = (BlockStatement)(foreachStatement.EmbeddedStatement = new BlockStatement());
			((BlockStatement)node.Parent).Statements.InsertBefore(node, foreachStatement);
			blockStatement.Add(node.Detach());
			blockStatement.Add((Statement)nextSibling.Detach());
			CanMoveVariableDeclarationIntoStatement(variableDeclarationStatement, foreachStatement, out declarationPoint);
			if (declarationPoint != foreachStatement)
			{
				((BlockStatement)foreachStatement.Parent).Statements.InsertBefore(foreachStatement, node.Detach());
				foreachStatement.ReplaceWith(nextSibling);
				return null;
			}
			foreachStatement.InExpression = match.Get<Expression>("collection").Single().Detach();
			if (foreachStatement.InExpression is BaseReferenceExpression)
			{
				foreachStatement.InExpression = new ThisReferenceExpression().CopyAnnotationsFrom(foreachStatement.InExpression);
			}
			blockStatement.Statements.Clear();
			blockStatement.Statements.AddRange(from stmt in match2.Get<Statement>("stmt")
				select stmt.Detach());
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
				blockStatement.Statements.Last().Remove();
				doWhileStatement.EmbeddedStatement = blockStatement.Detach();
				whileLoop.ReplaceWith(doWhileStatement);
				{
					foreach (VariableDeclarationStatement item in blockStatement.Statements.OfType<VariableDeclarationStatement>())
					{
						VariableInitializer v = item.Variables.Single();
						if (doWhileStatement.Condition.DescendantsAndSelf.OfType<IdentifierExpression>().Any((IdentifierExpression i) => i.Identifier == v.Name))
						{
							AssignmentExpression assignmentExpression = new AssignmentExpression(new IdentifierExpression(v.Name), v.Initializer.Detach());
							assignmentExpression.CopyAnnotationsFrom(v);
							v.RemoveAnnotations<object>();
							item.ReplaceWith(new ExpressionStatement(assignmentExpression).CopyAnnotationsFrom(item));
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
			Expression enter;
			Expression exit;
			bool flag = AnalyzeLockV2(node, out enter, out exit);
			if (flag || AnalyzeLockV4(node, out enter, out exit))
			{
				AstNode nextSibling = node.NextSibling;
				if (!exit.IsMatch(enter))
				{
					AssignmentExpression assignmentExpression = enter as AssignmentExpression;
					if (assignmentExpression == null)
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
				lockStatement.EmbeddedStatement = ((TryCatchStatement)nextSibling).TryBlock.Detach();
				if (!flag)
				{
					((BlockStatement)lockStatement.EmbeddedStatement).Statements.First().Remove();
				}
				nextSibling.ReplaceWith(lockStatement);
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
			if (!match.Get("switchVar").Single().IsMatch(match.Get("switchExpr").Single()))
			{
				AssignmentExpression assignmentExpression = match.Get("switchExpr").Single() as AssignmentExpression;
				if (assignmentExpression == null || !match.Get("switchVar").Single().IsMatch(assignmentExpression.Left))
				{
					return null;
				}
			}
			if (match.Get<AstNode>("cachedDict").Single().Annotation<FieldReference>() == null)
			{
				return null;
			}
			List<Statement> dictCreation = match.Get<BlockStatement>("dictCreation").Single().Statements.ToList();
			List<KeyValuePair<string, int>> list = BuildDictionary(dictCreation);
			SwitchStatement switchStatement = match.Get<SwitchStatement>("switch").Single();
			switchStatement.Expression = match.Get<Expression>("switchExpr").Single().Detach();
			foreach (SwitchSection switchSection3 in switchStatement.SwitchSections)
			{
				List<CaseLabel> list2 = switchSection3.CaseLabels.ToList();
				switchSection3.CaseLabels.Clear();
				foreach (CaseLabel item in list2)
				{
					PrimitiveExpression primitiveExpression = item.Expression as PrimitiveExpression;
					if (primitiveExpression != null && primitiveExpression.Value is int)
					{
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
					Statements = 
					{
						(Statement)new BlockStatement
						{
							new BreakStatement()
						}
					}
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
				if (TryGetPairFrom(item.Elements, out KeyValuePair<string, int> pair))
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
				ExpressionStatement expressionStatement = dictCreation[i] as ExpressionStatement;
				if (expressionStatement != null)
				{
					InvocationExpression invocationExpression = expressionStatement.Expression as InvocationExpression;
					if (invocationExpression != null && TryGetPairFrom(invocationExpression.Arguments, out KeyValuePair<string, int> pair))
					{
						list.Add(pair);
					}
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
			PropertyDefinition propertyDefinition = property.Annotation<PropertyDefinition>();
			if (propertyDefinition == null || propertyDefinition.GetMethod == null || propertyDefinition.SetMethod == null)
			{
				return null;
			}
			if (!propertyDefinition.GetMethod.IsCompilerGenerated() || !propertyDefinition.SetMethod.IsCompilerGenerated())
			{
				return null;
			}
			Match match = automaticPropertyPattern.Match(property);
			if (match.Success)
			{
				FieldDefinition fieldDefinition = match.Get<AstNode>("fieldReference").Single().Annotation<FieldReference>()
					.ResolveWithinSameModule();
				if (fieldDefinition.IsCompilerGenerated() && fieldDefinition.DeclaringType == propertyDefinition.DeclaringType)
				{
					RemoveCompilerGeneratedAttribute(property.Getter.Attributes);
					RemoveCompilerGeneratedAttribute(property.Setter.Attributes);
					property.Getter.Body = null;
					property.Setter.Body = null;
				}
			}
			return null;
		}

		private void RemoveCompilerGeneratedAttribute(AstNodeCollection<AttributeSection> attributeSections)
		{
			foreach (AttributeSection attributeSection in attributeSections)
			{
				foreach (ICSharpCode.NRefactory.CSharp.Attribute attribute in attributeSection.Attributes)
				{
					TypeReference typeReference = attribute.Type.Annotation<TypeReference>();
					if (typeReference != null && typeReference.Namespace == "System.Runtime.CompilerServices" && typeReference.Name == "CompilerGeneratedAttribute")
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

		private bool CheckAutomaticEventV4Match(Match m, CustomEventDeclaration ev, bool isAddAccessor)
		{
			if (!m.Success)
			{
				return false;
			}
			if (m.Get<MemberReferenceExpression>("field").Single().MemberName != ev.Name)
			{
				return false;
			}
			if (!ev.ReturnType.IsMatch(m.Get("type").Single()))
			{
				return false;
			}
			MethodReference methodReference = m.Get<AstNode>("delegateCombine").Single().Parent.Annotation<MethodReference>();
			if (methodReference == null || methodReference.Name != (isAddAccessor ? "Combine" : "Remove"))
			{
				return false;
			}
			return methodReference.DeclaringType.FullName == "System.Delegate";
		}

		private EventDeclaration TransformAutomaticEvents(CustomEventDeclaration ev)
		{
			Match m = automaticEventPatternV4.Match(ev.AddAccessor);
			if (!CheckAutomaticEventV4Match(m, ev, isAddAccessor: true))
			{
				return null;
			}
			Match m2 = automaticEventPatternV4.Match(ev.RemoveAccessor);
			if (!CheckAutomaticEventV4Match(m2, ev, isAddAccessor: false))
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
			eventDeclaration.Variables.Add(new VariableInitializer(ev.Name));
			eventDeclaration.CopyAnnotationsFrom(ev);
			EventDefinition eventDefinition = ev.Annotation<EventDefinition>();
			if (eventDefinition != null)
			{
				FieldDefinition fieldDefinition = eventDefinition.DeclaringType.Fields.FirstOrDefault((FieldDefinition f) => f.Name == ev.Name);
				if (fieldDefinition != null)
				{
					eventDeclaration.AddAnnotation(fieldDefinition);
					AstBuilder.ConvertAttributes(eventDeclaration, fieldDefinition, "field");
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
				destructorDeclaration.Modifiers = (methodDef.Modifiers & ~(Modifiers.Protected | Modifiers.Override));
				destructorDeclaration.Body = match.Get<BlockStatement>("body").Single().Detach();
				destructorDeclaration.Name = AstBuilder.CleanName(context.CurrentType.Name);
				methodDef.ReplaceWith(destructorDeclaration);
				return destructorDeclaration;
			}
			return null;
		}

		private TryCatchStatement TransformTryCatchFinally(TryCatchStatement tryFinally)
		{
			if (tryCatchFinallyPattern.IsMatch(tryFinally))
			{
				TryCatchStatement tryCatchStatement = (TryCatchStatement)tryFinally.TryBlock.Statements.Single();
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
				IfElseStatement node2 = match.Get<IfElseStatement>("nestedIfStatement").Single();
				node.FalseStatement = node2.Detach();
			}
			return null;
		}
	}
}
