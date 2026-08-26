using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast
{
	public class AstMethodBodyBuilder
	{
		private sealed class InitializedObjectExpression : IdentifierExpression
		{
			public InitializedObjectExpression()
				: base("__initialized_object__")
			{
			}

			protected override bool DoMatch(AstNode other, Match match)
			{
				return other is InitializedObjectExpression;
			}
		}

		private MethodDefinition methodDef;

		private TypeSystem typeSystem;

		private DecompilerContext context;

		private HashSet<ILVariable> localVariablesToDefine = new HashSet<ILVariable>();

		private static readonly AstNode objectInitializerPattern = new AssignmentExpression(new MemberReferenceExpression
		{
			Target = new InitializedObjectExpression(),
			MemberName = Pattern.AnyString
		}.WithName("left"), new AnyNode("right"));

		private static readonly AstNode collectionInitializerPattern = new InvocationExpression
		{
			Target = new MemberReferenceExpression
			{
				Target = new InitializedObjectExpression(),
				MemberName = "Add"
			},
			Arguments = 
			{
				(Expression)new Repeat(new AnyNode("arg"))
			}
		};

		public static BlockStatement CreateMethodBody(MethodDefinition methodDef, DecompilerContext context, IEnumerable<ParameterDeclaration> parameters = null)
		{
			MethodDefinition currentMethod = context.CurrentMethod;
			context.CurrentMethod = methodDef;
			context.CurrentMethodIsAsync = false;
			try
			{
				AstMethodBodyBuilder astMethodBodyBuilder = new AstMethodBodyBuilder();
				astMethodBodyBuilder.methodDef = methodDef;
				astMethodBodyBuilder.context = context;
				astMethodBodyBuilder.typeSystem = methodDef.Module.TypeSystem;
				if (!Debugger.IsAttached)
				{
					try
					{
						return astMethodBodyBuilder.CreateMethodBody(parameters);
					}
					catch (OperationCanceledException)
					{
						throw;
					}
					catch (Exception innerException)
					{
						throw new DecompilerException(methodDef, innerException);
					}
				}
				return astMethodBodyBuilder.CreateMethodBody(parameters);
			}
			finally
			{
				context.CurrentMethod = currentMethod;
			}
		}

		public BlockStatement CreateMethodBody(IEnumerable<ParameterDeclaration> parameters)
		{
			if (methodDef.Body == null)
			{
				return null;
			}
			context.CancellationToken.ThrowIfCancellationRequested();
			ILBlock iLBlock = new ILBlock();
			ILAstBuilder iLAstBuilder = new ILAstBuilder();
			iLBlock.Body = iLAstBuilder.Build(methodDef, optimize: true, context);
			context.CancellationToken.ThrowIfCancellationRequested();
			new ILAstOptimizer().Optimize(context, iLBlock);
			context.CancellationToken.ThrowIfCancellationRequested();
			IEnumerable<ILVariable> enumerable = (from e in iLBlock.GetSelfAndChildrenRecursive<ILExpression>()
				select e.Operand as ILVariable into v
				where v != null && !v.IsParameter
				select v).Distinct();
			NameVariables.AssignNamesToVariables(context, iLAstBuilder.Parameters, enumerable, iLBlock);
			if (parameters != null)
			{
				foreach (var item in from p in parameters
					join v in iLAstBuilder.Parameters on p.Annotation<ParameterDefinition>() equals v.OriginalParameter
					select new
					{
						p,
						v.Name
					})
				{
					item.p.Name = item.Name;
				}
			}
			context.CancellationToken.ThrowIfCancellationRequested();
			BlockStatement blockStatement = TransformBlock(iLBlock);
			CommentStatement.ReplaceAll(blockStatement);
			Statement existingItem = blockStatement.Statements.FirstOrDefault();
			foreach (ILVariable item2 in localVariablesToDefine)
			{
				AstType type = (!item2.Type.ContainsAnonymousType()) ? AstBuilder.ConvertType(item2.Type) : new SimpleType("var");
				VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement(type, item2.Name);
				variableDeclarationStatement.Variables.Single().AddAnnotation(item2);
				blockStatement.Statements.InsertBefore(existingItem, variableDeclarationStatement);
			}
			blockStatement.AddAnnotation(new MethodDebugSymbols(methodDef)
			{
				LocalVariables = enumerable.ToList()
			});
			return blockStatement;
		}

		private BlockStatement TransformBlock(ILBlock block)
		{
			BlockStatement blockStatement = new BlockStatement();
			if (block != null)
			{
				foreach (ILNode child in block.GetChildren())
				{
					blockStatement.Statements.AddRange(TransformNode(child));
				}
				return blockStatement;
			}
			return blockStatement;
		}

		private IEnumerable<Statement> TransformNode(ILNode node)
		{
			if (node is ILLabel)
			{
				yield return new LabelStatement
				{
					Label = ((ILLabel)node).Name
				};
			}
			else if (node is ILExpression)
			{
				List<ILRange> annotation = ILRange.OrderAndJoin(node.GetSelfAndChildrenRecursive<ILExpression>().SelectMany((ILExpression e) => e.ILRanges));
				AstNode codeExpr = TransformExpression((ILExpression)node);
				if (codeExpr == null)
				{
					yield break;
				}
				codeExpr = codeExpr.WithAnnotation(annotation);
				if (codeExpr is Expression)
				{
					yield return new ExpressionStatement
					{
						Expression = (Expression)codeExpr
					};
					yield break;
				}
				if (!(codeExpr is Statement))
				{
					throw new Exception();
				}
				yield return (Statement)codeExpr;
			}
			else if (node is ILWhileLoop)
			{
				ILWhileLoop iLWhileLoop = (ILWhileLoop)node;
				yield return new WhileStatement
				{
					Condition = ((iLWhileLoop.Condition != null) ? ((Expression)TransformExpression(iLWhileLoop.Condition)) : new PrimitiveExpression(true)),
					EmbeddedStatement = TransformBlock(iLWhileLoop.BodyBlock)
				};
			}
			else if (node is ILCondition)
			{
				ILCondition iLCondition = (ILCondition)node;
				bool flag = iLCondition.FalseBlock.EntryGoto != null || iLCondition.FalseBlock.Body.Count > 0;
				yield return new IfElseStatement
				{
					Condition = (Expression)TransformExpression(iLCondition.Condition),
					TrueStatement = TransformBlock(iLCondition.TrueBlock),
					FalseStatement = (flag ? TransformBlock(iLCondition.FalseBlock) : null)
				};
			}
			else if (node is ILSwitch)
			{
				ILSwitch ilSwitch = (ILSwitch)node;
				if (TypeAnalysis.IsBoolean(ilSwitch.Condition.InferredType) && (from cb in ilSwitch.CaseBlocks
					where cb.Values != null
					from val in cb.Values
					select val).Any((int val) => val != 0 && val != 1))
				{
					ilSwitch.Condition.ExpectedType = typeSystem.Int32;
				}
				SwitchStatement switchStatement = new SwitchStatement
				{
					Expression = (Expression)TransformExpression(ilSwitch.Condition)
				};
				foreach (ILSwitch.CaseBlock caseBlock in ilSwitch.CaseBlocks)
				{
					SwitchSection switchSection = new SwitchSection();
					if (caseBlock.Values != null)
					{
						switchSection.CaseLabels.AddRange(from i in caseBlock.Values
							select new CaseLabel
							{
								Expression = AstBuilder.MakePrimitive(i, ilSwitch.Condition.ExpectedType ?? ilSwitch.Condition.InferredType)
							});
					}
					else
					{
						switchSection.CaseLabels.Add(new CaseLabel());
					}
					switchSection.Statements.Add(TransformBlock(caseBlock));
					switchStatement.SwitchSections.Add(switchSection);
				}
				yield return switchStatement;
			}
			else if (node is ILTryCatchBlock)
			{
				ILTryCatchBlock iLTryCatchBlock = (ILTryCatchBlock)node;
				TryCatchStatement tryCatchStatement = new TryCatchStatement();
				tryCatchStatement.TryBlock = TransformBlock(iLTryCatchBlock.TryBlock);
				foreach (ILTryCatchBlock.CatchBlock catchBlock in iLTryCatchBlock.CatchBlocks)
				{
					if (catchBlock.ExceptionVariable == null && (catchBlock.ExceptionType == null || catchBlock.ExceptionType.MetadataType == MetadataType.Object))
					{
						tryCatchStatement.CatchClauses.Add(new CatchClause
						{
							Body = TransformBlock(catchBlock)
						});
					}
					else
					{
						tryCatchStatement.CatchClauses.Add(new CatchClause
						{
							Type = AstBuilder.ConvertType(catchBlock.ExceptionType),
							VariableName = ((catchBlock.ExceptionVariable == null) ? null : catchBlock.ExceptionVariable.Name),
							Body = TransformBlock(catchBlock)
						}.WithAnnotation(catchBlock.ExceptionVariable));
					}
				}
				if (iLTryCatchBlock.FinallyBlock != null)
				{
					tryCatchStatement.FinallyBlock = TransformBlock(iLTryCatchBlock.FinallyBlock);
				}
				if (iLTryCatchBlock.FaultBlock != null)
				{
					CatchClause catchClause = new CatchClause();
					catchClause.Body = TransformBlock(iLTryCatchBlock.FaultBlock);
					catchClause.Body.Add(new ThrowStatement());
					tryCatchStatement.CatchClauses.Add(catchClause);
				}
				yield return tryCatchStatement;
			}
			else if (node is ILFixedStatement)
			{
				ILFixedStatement iLFixedStatement = (ILFixedStatement)node;
				FixedStatement fixedStatement = new FixedStatement();
				foreach (ILExpression initializer in iLFixedStatement.Initializers)
				{
					ILVariable iLVariable = (ILVariable)initializer.Operand;
					fixedStatement.Variables.Add(new VariableInitializer
					{
						Name = iLVariable.Name,
						Initializer = (Expression)TransformExpression(initializer.Arguments[0])
					}.WithAnnotation(iLVariable));
				}
				fixedStatement.Type = AstBuilder.ConvertType(((ILVariable)iLFixedStatement.Initializers[0].Operand).Type);
				fixedStatement.EmbeddedStatement = TransformBlock(iLFixedStatement.BodyBlock);
				yield return fixedStatement;
			}
			else
			{
				if (!(node is ILBlock))
				{
					throw new Exception("Unknown node type");
				}
				yield return TransformBlock((ILBlock)node);
			}
		}

		private AstNode TransformExpression(ILExpression expr)
		{
			AstNode astNode = TransformByteCode(expr);
			Expression expression = astNode as Expression;
			List<ILRange> annotation = ILRange.OrderAndJoin(expr.GetSelfAndChildrenRecursive<ILExpression>().SelectMany((ILExpression e) => e.ILRanges));
			AstNode astNode2 = (expression == null) ? astNode : Convert(expression, expr.InferredType, expr.ExpectedType);
			if (astNode2 != null)
			{
				astNode2 = astNode2.WithAnnotation(new TypeInformation(expr.InferredType, expr.ExpectedType));
			}
			if (astNode2 != null)
			{
				return astNode2.WithAnnotation(annotation);
			}
			return astNode2;
		}

		private AstNode TransformByteCode(ILExpression byteCode)
		{
			object operand = byteCode.Operand;
			AstType astType = AstBuilder.ConvertType(operand as TypeReference);
			List<Expression> list = new List<Expression>();
			foreach (ILExpression argument in byteCode.Arguments)
			{
				list.Add((Expression)TransformExpression(argument));
			}
			Expression expression = (list.Count >= 1) ? list[0] : null;
			Expression expression2 = (list.Count >= 2) ? list[1] : null;
			Expression expression3 = (list.Count >= 3) ? list[2] : null;
			switch (byteCode.Code)
			{
			case ILCode.Add:
			case ILCode.Add_Ovf:
			case ILCode.Add_Ovf_Un:
			{
				BinaryOperatorExpression binaryOperatorExpression;
				if (byteCode.InferredType is PointerType)
				{
					binaryOperatorExpression = new BinaryOperatorExpression(expression, BinaryOperatorType.Add, expression2);
					if (byteCode.Arguments[0].ExpectedType is PointerType || byteCode.Arguments[1].ExpectedType is PointerType)
					{
						binaryOperatorExpression.AddAnnotation(IntroduceUnsafeModifier.PointerArithmeticAnnotation);
					}
				}
				else
				{
					binaryOperatorExpression = new BinaryOperatorExpression(expression, BinaryOperatorType.Add, expression2);
				}
				binaryOperatorExpression.AddAnnotation((byteCode.Code == ILCode.Add) ? AddCheckedBlocks.UncheckedAnnotation : AddCheckedBlocks.CheckedAnnotation);
				return binaryOperatorExpression;
			}
			case ILCode.Sub:
			case ILCode.Sub_Ovf:
			case ILCode.Sub_Ovf_Un:
			{
				BinaryOperatorExpression binaryOperatorExpression2;
				if (byteCode.InferredType is PointerType)
				{
					binaryOperatorExpression2 = new BinaryOperatorExpression(expression, BinaryOperatorType.Subtract, expression2);
					if (byteCode.Arguments[0].ExpectedType is PointerType)
					{
						binaryOperatorExpression2.WithAnnotation(IntroduceUnsafeModifier.PointerArithmeticAnnotation);
					}
				}
				else
				{
					binaryOperatorExpression2 = new BinaryOperatorExpression(expression, BinaryOperatorType.Subtract, expression2);
				}
				binaryOperatorExpression2.AddAnnotation((byteCode.Code == ILCode.Sub) ? AddCheckedBlocks.UncheckedAnnotation : AddCheckedBlocks.CheckedAnnotation);
				return binaryOperatorExpression2;
			}
			case ILCode.Div:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Divide, expression2);
			case ILCode.Div_Un:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Divide, expression2);
			case ILCode.Mul:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Multiply, expression2).WithAnnotation(AddCheckedBlocks.UncheckedAnnotation);
			case ILCode.Mul_Ovf:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Multiply, expression2).WithAnnotation(AddCheckedBlocks.CheckedAnnotation);
			case ILCode.Mul_Ovf_Un:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Multiply, expression2).WithAnnotation(AddCheckedBlocks.CheckedAnnotation);
			case ILCode.Rem:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Modulus, expression2);
			case ILCode.Rem_Un:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Modulus, expression2);
			case ILCode.And:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseAnd, expression2);
			case ILCode.Or:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseOr, expression2);
			case ILCode.Xor:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ExclusiveOr, expression2);
			case ILCode.Shl:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ShiftLeft, expression2);
			case ILCode.Shr:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ShiftRight, expression2);
			case ILCode.Shr_Un:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ShiftRight, expression2);
			case ILCode.Neg:
				return new UnaryOperatorExpression(UnaryOperatorType.Minus, expression).WithAnnotation(AddCheckedBlocks.UncheckedAnnotation);
			case ILCode.Not:
				return new UnaryOperatorExpression(UnaryOperatorType.BitNot, expression);
			case ILCode.PostIncrement:
			case ILCode.PostIncrement_Ovf:
			case ILCode.PostIncrement_Ovf_Un:
			{
				if (expression is DirectionExpression)
				{
					expression = ((DirectionExpression)expression).Expression.Detach();
				}
				UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression(((int)byteCode.Operand > 0) ? UnaryOperatorType.PostIncrement : UnaryOperatorType.PostDecrement, expression);
				unaryOperatorExpression.AddAnnotation((byteCode.Code == ILCode.PostIncrement) ? AddCheckedBlocks.UncheckedAnnotation : AddCheckedBlocks.CheckedAnnotation);
				return unaryOperatorExpression;
			}
			case ILCode.Newarr:
			{
				ArrayCreateExpression arrayCreateExpression3 = new ArrayCreateExpression();
				arrayCreateExpression3.Type = astType;
				(astType as ComposedType)?.ArraySpecifiers.MoveTo(arrayCreateExpression3.AdditionalArraySpecifiers);
				if (byteCode.Code == ILCode.InitArray)
				{
					arrayCreateExpression3.Initializer = new ArrayInitializerExpression();
					arrayCreateExpression3.Initializer.Elements.AddRange(list);
				}
				else
				{
					arrayCreateExpression3.Arguments.Add(expression);
				}
				return arrayCreateExpression3;
			}
			case ILCode.InitArray:
			{
				ArrayCreateExpression arrayCreateExpression2 = new ArrayCreateExpression();
				arrayCreateExpression2.Type = astType;
				ComposedType composedType2 = astType as ComposedType;
				ArrayType obj2 = (ArrayType)operand;
				if (composedType2 != null)
				{
					composedType2.ArraySpecifiers.MoveTo(arrayCreateExpression2.AdditionalArraySpecifiers);
					arrayCreateExpression2.Initializer = new ArrayInitializerExpression();
				}
				List<Expression> list2 = new List<Expression>();
				foreach (ArrayDimension item in obj2.Dimensions.Skip(1).Reverse())
				{
					int num = item.UpperBound.Value - item.LowerBound.Value;
					for (int k = 0; k < list.Count; k += num)
					{
						ArrayInitializerExpression arrayInitializerExpression3 = new ArrayInitializerExpression();
						arrayInitializerExpression3.Elements.AddRange(list.GetRange(k, num));
						list2.Add(arrayInitializerExpression3);
					}
					List<Expression> list3 = list;
					list = list2;
					list2 = list3;
					list2.Clear();
				}
				arrayCreateExpression2.Initializer.Elements.AddRange(list);
				return arrayCreateExpression2;
			}
			case ILCode.Ldlen:
				return expression.Member("Length");
			case ILCode.Ldelem_I1:
			case ILCode.Ldelem_U1:
			case ILCode.Ldelem_I2:
			case ILCode.Ldelem_U2:
			case ILCode.Ldelem_I4:
			case ILCode.Ldelem_U4:
			case ILCode.Ldelem_I8:
			case ILCode.Ldelem_I:
			case ILCode.Ldelem_R4:
			case ILCode.Ldelem_R8:
			case ILCode.Ldelem_Ref:
			case ILCode.Ldelem_Any:
				return expression.Indexer(expression2);
			case ILCode.Ldelema:
				return MakeRef(expression.Indexer(expression2));
			case ILCode.Stelem_I:
			case ILCode.Stelem_I1:
			case ILCode.Stelem_I2:
			case ILCode.Stelem_I4:
			case ILCode.Stelem_I8:
			case ILCode.Stelem_R4:
			case ILCode.Stelem_R8:
			case ILCode.Stelem_Ref:
			case ILCode.Stelem_Any:
				return new AssignmentExpression(expression.Indexer(expression2), expression3);
			case ILCode.CompoundAssignment:
			{
				CastExpression castExpression = expression as CastExpression;
				BinaryOperatorExpression binaryOperatorExpression3 = (castExpression != null) ? ((BinaryOperatorExpression)castExpression.Expression) : (expression as BinaryOperatorExpression);
				if (binaryOperatorExpression3 == null)
				{
					ParenthesizedExpression parenthesizedExpression = new ParenthesizedExpression(expression);
					ReplaceMethodCallsWithOperators.ProcessInvocationExpression((InvocationExpression)expression);
					binaryOperatorExpression3 = (BinaryOperatorExpression)parenthesizedExpression.Expression;
				}
				AssignmentExpression assignmentExpression = new AssignmentExpression
				{
					Left = binaryOperatorExpression3.Left.Detach(),
					Operator = ReplaceMethodCallsWithOperators.GetAssignmentOperatorForBinaryOperator(binaryOperatorExpression3.Operator),
					Right = binaryOperatorExpression3.Right.Detach()
				}.CopyAnnotationsFrom(binaryOperatorExpression3);
				if (castExpression != null)
				{
					castExpression.Expression = assignmentExpression;
					return castExpression;
				}
				return assignmentExpression;
			}
			case ILCode.Ceq:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.Equality, expression2);
			case ILCode.Cne:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.InEquality, expression2);
			case ILCode.Cgt:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.GreaterThan, expression2);
			case ILCode.Cgt_Un:
			{
				TypeReference inferredType2 = byteCode.Arguments[0].InferredType;
				if (inferredType2 != null && !inferredType2.IsValueType)
				{
					goto case ILCode.Cne;
				}
				if (inferredType2.IsSignedIntegralType())
				{
					PrimitiveExpression primitiveExpression2 = expression2 as PrimitiveExpression;
					if (primitiveExpression2 != null && primitiveExpression2.Value.IsZero())
					{
						goto case ILCode.Cne;
					}
				}
				goto case ILCode.Cgt;
			}
			case ILCode.Cle_Un:
			{
				TypeReference inferredType = byteCode.Arguments[0].InferredType;
				if (inferredType != null && !inferredType.IsValueType)
				{
					goto case ILCode.Ceq;
				}
				if (inferredType.IsSignedIntegralType())
				{
					PrimitiveExpression primitiveExpression = expression2 as PrimitiveExpression;
					if (primitiveExpression != null && primitiveExpression.Value.IsZero())
					{
						goto case ILCode.Ceq;
					}
				}
				goto case ILCode.Cle;
			}
			case ILCode.Cle:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.LessThanOrEqual, expression2);
			case ILCode.Cge:
			case ILCode.Cge_Un:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.GreaterThanOrEqual, expression2);
			case ILCode.Clt:
			case ILCode.Clt_Un:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.LessThan, expression2);
			case ILCode.LogicNot:
				return new UnaryOperatorExpression(UnaryOperatorType.Not, expression);
			case ILCode.LogicAnd:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ConditionalAnd, expression2);
			case ILCode.LogicOr:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ConditionalOr, expression2);
			case ILCode.TernaryOp:
				return new ConditionalExpression
				{
					Condition = expression,
					TrueExpression = expression2,
					FalseExpression = expression3
				};
			case ILCode.NullCoalescing:
				return new BinaryOperatorExpression(expression, BinaryOperatorType.NullCoalescing, expression2);
			case ILCode.Br:
				return new GotoStatement(((ILLabel)byteCode.Operand).Name);
			case ILCode.Brtrue:
				return new IfElseStatement
				{
					Condition = expression,
					TrueStatement = new BlockStatement
					{
						new GotoStatement(((ILLabel)byteCode.Operand).Name)
					}
				};
			case ILCode.LoopOrSwitchBreak:
				return new BreakStatement();
			case ILCode.LoopContinue:
				return new ContinueStatement();
			case ILCode.Conv_I1:
			case ILCode.Conv_I2:
			case ILCode.Conv_I4:
			case ILCode.Conv_I8:
			case ILCode.Conv_U4:
			case ILCode.Conv_U8:
			case ILCode.Conv_U2:
			case ILCode.Conv_U1:
			case ILCode.Conv_I:
			case ILCode.Conv_U:
				(expression as CastExpression)?.AddAnnotation(AddCheckedBlocks.UncheckedAnnotation);
				return expression;
			case ILCode.Conv_R4:
			case ILCode.Conv_R8:
			case ILCode.Conv_R_Un:
				return expression;
			case ILCode.Conv_Ovf_I1_Un:
			case ILCode.Conv_Ovf_I2_Un:
			case ILCode.Conv_Ovf_I4_Un:
			case ILCode.Conv_Ovf_I8_Un:
			case ILCode.Conv_Ovf_U1_Un:
			case ILCode.Conv_Ovf_U2_Un:
			case ILCode.Conv_Ovf_U4_Un:
			case ILCode.Conv_Ovf_U8_Un:
			case ILCode.Conv_Ovf_I_Un:
			case ILCode.Conv_Ovf_U_Un:
			case ILCode.Conv_Ovf_I1:
			case ILCode.Conv_Ovf_U1:
			case ILCode.Conv_Ovf_I2:
			case ILCode.Conv_Ovf_U2:
			case ILCode.Conv_Ovf_I4:
			case ILCode.Conv_Ovf_U4:
			case ILCode.Conv_Ovf_I8:
			case ILCode.Conv_Ovf_U8:
			case ILCode.Conv_Ovf_I:
			case ILCode.Conv_Ovf_U:
				(expression as CastExpression)?.AddAnnotation(AddCheckedBlocks.CheckedAnnotation);
				return expression;
			case ILCode.Unbox_Any:
				if (expression is AsExpression && byteCode.Arguments[0].Code == ILCode.Isinst && TypeAnalysis.IsSameType(operand as TypeReference, byteCode.Arguments[0].Operand as TypeReference))
				{
					return expression;
				}
				goto case ILCode.Castclass;
			case ILCode.Castclass:
				if ((byteCode.Arguments[0].InferredType != null && byteCode.Arguments[0].InferredType.IsGenericParameter) || ((TypeReference)operand).IsGenericParameter)
				{
					return expression.CastTo(new PrimitiveType("object")).CastTo(astType);
				}
				return expression.CastTo(astType);
			case ILCode.Isinst:
				return expression.CastAs(astType);
			case ILCode.Box:
				return expression;
			case ILCode.Unbox:
				return MakeRef(expression.CastTo(astType));
			case ILCode.Ldind_Ref:
			case ILCode.Ldobj:
				if (expression is DirectionExpression)
				{
					return ((DirectionExpression)expression).Expression.Detach();
				}
				return new UnaryOperatorExpression(UnaryOperatorType.Dereference, expression);
			case ILCode.Stind_Ref:
			case ILCode.Stobj:
				if (expression is DirectionExpression)
				{
					return new AssignmentExpression(((DirectionExpression)expression).Expression.Detach(), expression2);
				}
				return new AssignmentExpression(new UnaryOperatorExpression(UnaryOperatorType.Dereference, expression), expression2);
			case ILCode.Arglist:
				return new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.ArgListAccess
				};
			case ILCode.Break:
				return InlineAssembly(byteCode, list);
			case ILCode.Call:
			case ILCode.CallGetter:
			case ILCode.CallSetter:
				return TransformCall(isVirtual: false, byteCode, list);
			case ILCode.Callvirt:
			case ILCode.CallvirtGetter:
			case ILCode.CallvirtSetter:
				return TransformCall(isVirtual: true, byteCode, list);
			case ILCode.Ldftn:
			{
				MethodReference methodReference = (MethodReference)operand;
				IdentifierExpression identifierExpression = new IdentifierExpression(methodReference.Name);
				identifierExpression.TypeArguments.AddRange(ConvertTypeArguments(methodReference));
				identifierExpression.AddAnnotation(methodReference);
				return new IdentifierExpression("ldftn").Invoke(identifierExpression).WithAnnotation(new DelegateConstruction.Annotation(isVirtual: false));
			}
			case ILCode.Ldvirtftn:
			{
				MethodReference methodReference3 = (MethodReference)operand;
				IdentifierExpression identifierExpression2 = new IdentifierExpression(methodReference3.Name);
				identifierExpression2.TypeArguments.AddRange(ConvertTypeArguments(methodReference3));
				identifierExpression2.AddAnnotation(methodReference3);
				return new IdentifierExpression("ldvirtftn").Invoke(identifierExpression2).WithAnnotation(new DelegateConstruction.Annotation(isVirtual: true));
			}
			case ILCode.Calli:
				return InlineAssembly(byteCode, list);
			case ILCode.Ckfinite:
				return InlineAssembly(byteCode, list);
			case ILCode.Constrained:
				return InlineAssembly(byteCode, list);
			case ILCode.Cpblk:
				return InlineAssembly(byteCode, list);
			case ILCode.Cpobj:
				return InlineAssembly(byteCode, list);
			case ILCode.Dup:
				return expression;
			case ILCode.Endfilter:
				return InlineAssembly(byteCode, list);
			case ILCode.Endfinally:
				return null;
			case ILCode.Initblk:
				return InlineAssembly(byteCode, list);
			case ILCode.Initobj:
				return InlineAssembly(byteCode, list);
			case ILCode.DefaultValue:
				return MakeDefaultValue((TypeReference)operand);
			case ILCode.Jmp:
				return InlineAssembly(byteCode, list);
			case ILCode.Ldc_I4:
				return AstBuilder.MakePrimitive((int)operand, byteCode.InferredType);
			case ILCode.Ldc_I8:
				return AstBuilder.MakePrimitive((long)operand, byteCode.InferredType);
			case ILCode.Ldc_R4:
			case ILCode.Ldc_R8:
			case ILCode.Ldc_Decimal:
				return new PrimitiveExpression(operand);
			case ILCode.Ldfld:
				if (expression is DirectionExpression)
				{
					expression = ((DirectionExpression)expression).Expression.Detach();
				}
				return expression.Member(((FieldReference)operand).Name).WithAnnotation(operand);
			case ILCode.Ldsfld:
				return AstBuilder.ConvertType(((FieldReference)operand).DeclaringType).Member(((FieldReference)operand).Name).WithAnnotation(operand);
			case ILCode.Stfld:
				if (expression is DirectionExpression)
				{
					expression = ((DirectionExpression)expression).Expression.Detach();
				}
				return new AssignmentExpression(expression.Member(((FieldReference)operand).Name).WithAnnotation(operand), expression2);
			case ILCode.Stsfld:
				return new AssignmentExpression(AstBuilder.ConvertType(((FieldReference)operand).DeclaringType).Member(((FieldReference)operand).Name).WithAnnotation(operand), expression);
			case ILCode.Ldflda:
				if (expression is DirectionExpression)
				{
					expression = ((DirectionExpression)expression).Expression.Detach();
				}
				return MakeRef(expression.Member(((FieldReference)operand).Name).WithAnnotation(operand));
			case ILCode.Ldsflda:
				return MakeRef(AstBuilder.ConvertType(((FieldReference)operand).DeclaringType).Member(((FieldReference)operand).Name).WithAnnotation(operand));
			case ILCode.Ldloc:
			{
				ILVariable iLVariable3 = (ILVariable)operand;
				if (!iLVariable3.IsParameter)
				{
					localVariablesToDefine.Add((ILVariable)operand);
				}
				Expression expression5 = (!iLVariable3.IsParameter || iLVariable3.OriginalParameter.Index >= 0) ? ((Expression)new IdentifierExpression(((ILVariable)operand).Name).WithAnnotation(operand)) : ((Expression)new ThisReferenceExpression());
				if (!iLVariable3.IsParameter || !(iLVariable3.Type is ByReferenceType))
				{
					return expression5;
				}
				return MakeRef(expression5);
			}
			case ILCode.Ldloca:
			{
				ILVariable iLVariable2 = (ILVariable)operand;
				if (iLVariable2.IsParameter && iLVariable2.OriginalParameter.Index < 0)
				{
					return MakeRef(new ThisReferenceExpression());
				}
				if (!iLVariable2.IsParameter)
				{
					localVariablesToDefine.Add((ILVariable)operand);
				}
				return MakeRef(new IdentifierExpression(((ILVariable)operand).Name).WithAnnotation(operand));
			}
			case ILCode.Ldnull:
				return new NullReferenceExpression();
			case ILCode.Ldstr:
				return new PrimitiveExpression(operand);
			case ILCode.Ldtoken:
			{
				if (operand is TypeReference)
				{
					return AstBuilder.CreateTypeOfExpression((TypeReference)operand).Member("TypeHandle");
				}
				string identifier;
				string memberName;
				Expression expression4;
				if (operand is FieldReference)
				{
					identifier = "fieldof";
					memberName = "FieldHandle";
					FieldReference fieldReference = (FieldReference)operand;
					expression4 = AstBuilder.ConvertType(fieldReference.DeclaringType).Member(fieldReference.Name).WithAnnotation(fieldReference);
				}
				else if (operand is MethodReference)
				{
					identifier = "methodof";
					memberName = "MethodHandle";
					MethodReference methodReference2 = (MethodReference)operand;
					IEnumerable<TypeReferenceExpression> arguments = from p in methodReference2.Parameters
						select new TypeReferenceExpression(AstBuilder.ConvertType(p.ParameterType));
					expression4 = AstBuilder.ConvertType(methodReference2.DeclaringType).Invoke(methodReference2.Name, arguments).WithAnnotation(methodReference2);
				}
				else
				{
					identifier = "ldtoken";
					memberName = "Handle";
					expression4 = new IdentifierExpression(FormatByteCodeOperand(byteCode.Operand));
				}
				return new IdentifierExpression(identifier).Invoke(expression4).WithAnnotation(new LdTokenAnnotation()).Member(memberName);
			}
			case ILCode.Leave:
				return new GotoStatement
				{
					Label = ((ILLabel)operand).Name
				};
			case ILCode.Localloc:
			{
				PointerType pointerType = byteCode.InferredType as PointerType;
				TypeReference type = (pointerType == null) ? typeSystem.Byte : pointerType.ElementType;
				return new StackAllocExpression
				{
					Type = AstBuilder.ConvertType(type),
					CountExpression = expression
				};
			}
			case ILCode.Mkrefany:
			{
				DirectionExpression directionExpression = expression as DirectionExpression;
				if (directionExpression != null)
				{
					return new UndocumentedExpression
					{
						UndocumentedExpressionType = UndocumentedExpressionType.MakeRef,
						Arguments = 
						{
							directionExpression.Expression.Detach()
						}
					};
				}
				return InlineAssembly(byteCode, list);
			}
			case ILCode.Refanytype:
				return new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.RefType,
					Arguments = 
					{
						expression
					}
				}.Member("TypeHandle");
			case ILCode.Refanyval:
				return MakeRef(new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.RefValue,
					Arguments = 
					{
						expression,
						(Expression)new TypeReferenceExpression(astType)
					}
				});
			case ILCode.Newobj:
			{
				TypeReference declaringType = ((MethodReference)operand).DeclaringType;
				if (declaringType is ArrayType)
				{
					ComposedType composedType = AstBuilder.ConvertType((ArrayType)declaringType) as ComposedType;
					if (composedType != null && composedType.ArraySpecifiers.Count >= 1)
					{
						ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression();
						composedType.ArraySpecifiers.First().Remove();
						composedType.ArraySpecifiers.MoveTo(arrayCreateExpression.AdditionalArraySpecifiers);
						arrayCreateExpression.Type = composedType;
						arrayCreateExpression.Arguments.AddRange(list);
						return arrayCreateExpression;
					}
				}
				MethodDefinition methodDefinition = ((MethodReference)operand).Resolve();
				if (declaringType.IsAnonymousType() && methodDef != null)
				{
					AnonymousTypeCreateExpression anonymousTypeCreateExpression = new AnonymousTypeCreateExpression();
					if (CanInferAnonymousTypePropertyNamesFromArguments(list, methodDefinition.Parameters))
					{
						anonymousTypeCreateExpression.Initializers.AddRange(list);
					}
					else
					{
						for (int j = 0; j < list.Count; j++)
						{
							anonymousTypeCreateExpression.Initializers.Add(new NamedExpression
							{
								Name = methodDefinition.Parameters[j].Name,
								Expression = list[j]
							});
						}
					}
					return anonymousTypeCreateExpression;
				}
				ObjectCreateExpression obj = new ObjectCreateExpression
				{
					Type = AstBuilder.ConvertType(declaringType)
				};
				if (methodDefinition != null)
				{
					AdjustArgumentsForMethodCall(methodDefinition, list);
				}
				obj.Arguments.AddRange(list);
				return obj.WithAnnotation(operand);
			}
			case ILCode.No:
				return InlineAssembly(byteCode, list);
			case ILCode.Nop:
				return null;
			case ILCode.Pop:
				return expression;
			case ILCode.Readonly:
				return InlineAssembly(byteCode, list);
			case ILCode.Ret:
				if (methodDef.ReturnType.FullName != "System.Void")
				{
					return new ReturnStatement
					{
						Expression = expression
					};
				}
				return new ReturnStatement();
			case ILCode.Rethrow:
				return new ThrowStatement();
			case ILCode.Sizeof:
				return new SizeOfExpression
				{
					Type = astType
				};
			case ILCode.Stloc:
			{
				ILVariable iLVariable = (ILVariable)operand;
				if (!iLVariable.IsParameter)
				{
					localVariablesToDefine.Add(iLVariable);
				}
				return new AssignmentExpression(new IdentifierExpression(iLVariable.Name).WithAnnotation(iLVariable), expression);
			}
			case ILCode.Switch:
				return InlineAssembly(byteCode, list);
			case ILCode.Tail:
				return InlineAssembly(byteCode, list);
			case ILCode.Throw:
				return new ThrowStatement
				{
					Expression = expression
				};
			case ILCode.Unaligned:
				return InlineAssembly(byteCode, list);
			case ILCode.Volatile:
				return InlineAssembly(byteCode, list);
			case ILCode.YieldBreak:
				return new YieldBreakStatement();
			case ILCode.YieldReturn:
				return new YieldReturnStatement
				{
					Expression = expression
				};
			case ILCode.InitObject:
			case ILCode.InitCollection:
			{
				ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
				for (int i = 1; i < list.Count; i++)
				{
					Match match = objectInitializerPattern.Match(list[i]);
					if (match.Success)
					{
						MemberReferenceExpression memberReferenceExpression = match.Get<MemberReferenceExpression>("left").Single();
						arrayInitializerExpression.Elements.Add(new NamedExpression
						{
							Name = memberReferenceExpression.MemberName,
							Expression = match.Get<Expression>("right").Single().Detach()
						}.CopyAnnotationsFrom(memberReferenceExpression));
						continue;
					}
					match = collectionInitializerPattern.Match(list[i]);
					if (match.Success)
					{
						if (match.Get("arg").Count() == 1)
						{
							arrayInitializerExpression.Elements.Add(match.Get<Expression>("arg").Single().Detach());
							continue;
						}
						ArrayInitializerExpression arrayInitializerExpression2 = new ArrayInitializerExpression();
						foreach (Expression item2 in match.Get<Expression>("arg"))
						{
							arrayInitializerExpression2.Elements.Add(item2.Detach());
						}
						arrayInitializerExpression.Elements.Add(arrayInitializerExpression2);
					}
					else
					{
						arrayInitializerExpression.Elements.Add(list[i]);
					}
				}
				ObjectCreateExpression objectCreateExpression = expression as ObjectCreateExpression;
				DefaultValueExpression defaultValueExpression = expression as DefaultValueExpression;
				if (objectCreateExpression != null)
				{
					objectCreateExpression.Initializer = arrayInitializerExpression;
					return objectCreateExpression;
				}
				if (defaultValueExpression != null)
				{
					objectCreateExpression = new ObjectCreateExpression(defaultValueExpression.Type.Detach());
					objectCreateExpression.CopyAnnotationsFrom(defaultValueExpression);
					objectCreateExpression.Initializer = arrayInitializerExpression;
					return objectCreateExpression;
				}
				return new AssignmentExpression(expression, arrayInitializerExpression);
			}
			case ILCode.InitializedObject:
				return new InitializedObjectExpression();
			case ILCode.Wrap:
				return expression.WithAnnotation(PushNegation.LiftedOperatorAnnotation);
			case ILCode.AddressOf:
				return MakeRef(expression);
			case ILCode.ExpressionTreeParameterDeclarations:
				list[list.Count - 1].AddAnnotation(new ParameterDeclarationAnnotation(byteCode));
				return list[list.Count - 1];
			case ILCode.Await:
				return new UnaryOperatorExpression(UnaryOperatorType.Await, UnpackDirectionExpression(expression));
			case ILCode.ValueOf:
			case ILCode.NullableOf:
				return expression;
			default:
				throw new Exception("Unknown OpCode: " + byteCode.Code);
			}
		}

		internal static bool CanInferAnonymousTypePropertyNamesFromArguments(IList<Expression> args, IList<ParameterDefinition> parameters)
		{
			for (int i = 0; i < args.Count; i++)
			{
				string a = (args[i] is IdentifierExpression) ? ((IdentifierExpression)args[i]).Identifier : ((!(args[i] is MemberReferenceExpression)) ? null : ((MemberReferenceExpression)args[i]).MemberName);
				if (a != parameters[i].Name)
				{
					return false;
				}
			}
			return true;
		}

		private Expression MakeDefaultValue(TypeReference type)
		{
			TypeDefinition typeDefinition = type.Resolve();
			if (typeDefinition != null)
			{
				if (TypeAnalysis.IsIntegerOrEnum(typeDefinition))
				{
					return AstBuilder.MakePrimitive(0L, typeDefinition);
				}
				if (!typeDefinition.IsValueType)
				{
					return new NullReferenceExpression();
				}
				switch (typeDefinition.FullName)
				{
				case "System.Nullable`1":
					return new NullReferenceExpression();
				case "System.Single":
					return new PrimitiveExpression(0f);
				case "System.Double":
					return new PrimitiveExpression(0.0);
				case "System.Decimal":
					return new PrimitiveExpression(decimal.Zero);
				}
			}
			return new DefaultValueExpression
			{
				Type = AstBuilder.ConvertType(type)
			};
		}

		private AstNode TransformCall(bool isVirtual, ILExpression byteCode, List<Expression> args)
		{
			MethodReference methodReference = (MethodReference)byteCode.Operand;
			MethodDefinition methodDefinition = methodReference.Resolve();
			List<Expression> list = new List<Expression>(args);
			Expression target;
			if (methodReference.HasThis)
			{
				target = list[0];
				list.RemoveAt(0);
				target = UnpackDirectionExpression(target);
				if (methodDefinition != null)
				{
					if (target is NullReferenceExpression)
					{
						target = target.CastTo(AstBuilder.ConvertType(methodReference.DeclaringType));
					}
					if (methodDefinition.DeclaringType.IsInterface)
					{
						TypeReference inferredType = byteCode.Arguments[0].InferredType;
						if (inferredType != null)
						{
							TypeDefinition typeDefinition = inferredType.Resolve();
							if (typeDefinition != null && !typeDefinition.IsInterface)
							{
								target = target.CastTo(AstBuilder.ConvertType(methodReference.DeclaringType));
							}
						}
					}
				}
			}
			else
			{
				target = new TypeReferenceExpression
				{
					Type = AstBuilder.ConvertType(methodReference.DeclaringType)
				};
			}
			if (target is ThisReferenceExpression && !isVirtual && methodReference.DeclaringType.GetElementType() != methodDef.DeclaringType)
			{
				target = new BaseReferenceExpression();
			}
			if (methodReference.Name == ".ctor" && methodReference.DeclaringType.IsValueType)
			{
				ObjectCreateExpression objectCreateExpression = new ObjectCreateExpression();
				objectCreateExpression.Type = AstBuilder.ConvertType(methodReference.DeclaringType);
				objectCreateExpression.AddAnnotation(methodReference);
				AdjustArgumentsForMethodCall(methodReference, list);
				objectCreateExpression.Arguments.AddRange(list);
				return new AssignmentExpression(target, objectCreateExpression);
			}
			if (methodReference.Name == "Get" && methodReference.DeclaringType is ArrayType && list.Count > 1)
			{
				return target.Indexer(list);
			}
			if (methodReference.Name == "Set" && methodReference.DeclaringType is ArrayType && list.Count > 2)
			{
				return new AssignmentExpression(target.Indexer(list.GetRange(0, list.Count - 1)), list.Last());
			}
			if (methodDefinition != null)
			{
				if (methodDefinition.IsGetter && list.Count == 0)
				{
					foreach (PropertyDefinition property in methodDefinition.DeclaringType.Properties)
					{
						if (property.GetMethod == methodDefinition)
						{
							return target.Member(property.Name).WithAnnotation(property).WithAnnotation(methodReference);
						}
					}
				}
				else if (methodDefinition.IsGetter)
				{
					PropertyDefinition indexer = GetIndexer(methodDefinition);
					if (indexer != null)
					{
						return target.Indexer(list).WithAnnotation(indexer).WithAnnotation(methodReference);
					}
				}
				else if (methodDefinition.IsSetter && list.Count == 1)
				{
					foreach (PropertyDefinition property2 in methodDefinition.DeclaringType.Properties)
					{
						if (property2.SetMethod == methodDefinition)
						{
							return new AssignmentExpression(target.Member(property2.Name).WithAnnotation(property2).WithAnnotation(methodReference), list[0]);
						}
					}
				}
				else if (methodDefinition.IsSetter && list.Count > 1)
				{
					PropertyDefinition indexer2 = GetIndexer(methodDefinition);
					if (indexer2 != null)
					{
						return new AssignmentExpression(target.Indexer(list.GetRange(0, list.Count - 1)).WithAnnotation(indexer2).WithAnnotation(methodReference), list[list.Count - 1]);
					}
				}
				else if (methodDefinition.IsAddOn && list.Count == 1)
				{
					foreach (EventDefinition @event in methodDefinition.DeclaringType.Events)
					{
						if (@event.AddMethod == methodDefinition)
						{
							return new AssignmentExpression
							{
								Left = target.Member(@event.Name).WithAnnotation(@event).WithAnnotation(methodReference),
								Operator = AssignmentOperatorType.Add,
								Right = list[0]
							};
						}
					}
				}
				else if (methodDefinition.IsRemoveOn && list.Count == 1)
				{
					foreach (EventDefinition event2 in methodDefinition.DeclaringType.Events)
					{
						if (event2.RemoveMethod == methodDefinition)
						{
							return new AssignmentExpression
							{
								Left = target.Member(event2.Name).WithAnnotation(event2).WithAnnotation(methodReference),
								Operator = AssignmentOperatorType.Subtract,
								Right = list[0]
							};
						}
					}
				}
				else if (methodDefinition.Name == "Invoke" && methodDefinition.DeclaringType.BaseType != null && methodDefinition.DeclaringType.BaseType.FullName == "System.MulticastDelegate")
				{
					AdjustArgumentsForMethodCall(methodReference, list);
					return target.Invoke(list).WithAnnotation(methodReference);
				}
			}
			AdjustArgumentsForMethodCall(methodDefinition ?? methodReference, list);
			return target.Invoke(methodReference.Name, ConvertTypeArguments(methodReference), list).WithAnnotation(methodReference);
		}

		private static Expression UnpackDirectionExpression(Expression target)
		{
			if (target is DirectionExpression)
			{
				return ((DirectionExpression)target).Expression.Detach();
			}
			return target;
		}

		private static void AdjustArgumentsForMethodCall(MethodReference cecilMethod, List<Expression> methodArgs)
		{
			for (int i = 0; i < methodArgs.Count && i < cecilMethod.Parameters.Count; i++)
			{
				DirectionExpression directionExpression = methodArgs[i] as DirectionExpression;
				ParameterDefinition parameterDefinition = cecilMethod.Parameters[i];
				if (directionExpression != null && parameterDefinition.IsOut && !parameterDefinition.IsIn)
				{
					directionExpression.FieldDirection = FieldDirection.Out;
				}
			}
		}

		internal static PropertyDefinition GetIndexer(MethodDefinition cecilMethodDef)
		{
			TypeDefinition declaringType = cecilMethodDef.DeclaringType;
			string text = null;
			foreach (CustomAttribute customAttribute in declaringType.CustomAttributes)
			{
				if (customAttribute.Constructor.FullName == "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)")
				{
					text = (customAttribute.ConstructorArguments.Single().Value as string);
					break;
				}
			}
			if (text == null)
			{
				return null;
			}
			foreach (PropertyDefinition property in declaringType.Properties)
			{
				if (property.Name == text && (property.GetMethod == cecilMethodDef || property.SetMethod == cecilMethodDef))
				{
					return property;
				}
			}
			return null;
		}

		[Conditional("DEBUG")]
		public static void ClearUnhandledOpcodes()
		{
		}

		[Conditional("DEBUG")]
		public static void PrintNumberOfUnhandledOpcodes()
		{
		}

		private static Expression InlineAssembly(ILExpression byteCode, List<Expression> args)
		{
			if (byteCode.Operand != null)
			{
				args.Insert(0, new IdentifierExpression(FormatByteCodeOperand(byteCode.Operand)));
			}
			return new IdentifierExpression(byteCode.Code.GetName()).Invoke(args);
		}

		private static string FormatByteCodeOperand(object operand)
		{
			if (operand == null)
			{
				return string.Empty;
			}
			if (operand is MethodReference)
			{
				return ((MethodReference)operand).Name + "()";
			}
			if (operand is TypeReference)
			{
				return ((TypeReference)operand).FullName;
			}
			if (operand is VariableDefinition)
			{
				return ((VariableDefinition)operand).Name;
			}
			if (operand is ParameterDefinition)
			{
				return ((ParameterDefinition)operand).Name;
			}
			if (operand is FieldReference)
			{
				return ((FieldReference)operand).Name;
			}
			if (operand is string)
			{
				return "\"" + operand + "\"";
			}
			return operand.ToString();
		}

		private static IEnumerable<AstType> ConvertTypeArguments(MethodReference cecilMethod)
		{
			GenericInstanceMethod genericInstanceMethod = cecilMethod as GenericInstanceMethod;
			if (genericInstanceMethod == null)
			{
				return null;
			}
			if (genericInstanceMethod.GenericArguments.Any((TypeReference ta) => ta.ContainsAnonymousType()))
			{
				return null;
			}
			return from t in genericInstanceMethod.GenericArguments
				select AstBuilder.ConvertType(t);
		}

		private static DirectionExpression MakeRef(Expression expr)
		{
			return new DirectionExpression
			{
				Expression = expr,
				FieldDirection = FieldDirection.Ref
			};
		}

		private Expression Convert(Expression expr, TypeReference actualType, TypeReference reqType)
		{
			if (actualType == null || reqType == null || TypeAnalysis.IsSameType(actualType, reqType))
			{
				return expr;
			}
			if (actualType is ByReferenceType && reqType is PointerType && expr is DirectionExpression)
			{
				return Convert(new UnaryOperatorExpression(UnaryOperatorType.AddressOf, ((DirectionExpression)expr).Expression.Detach()), new PointerType(((ByReferenceType)actualType).ElementType), reqType);
			}
			if (actualType is PointerType && reqType is ByReferenceType)
			{
				expr = Convert(expr, actualType, new PointerType(((ByReferenceType)reqType).ElementType));
				return new DirectionExpression
				{
					FieldDirection = FieldDirection.Ref,
					Expression = new UnaryOperatorExpression(UnaryOperatorType.Dereference, expr)
				};
			}
			if (actualType is PointerType && reqType is PointerType)
			{
				if (actualType.FullName != reqType.FullName)
				{
					return expr.CastTo(AstBuilder.ConvertType(reqType));
				}
				return expr;
			}
			bool flag = TypeAnalysis.IsIntegerOrEnum(actualType);
			bool flag2 = TypeAnalysis.IsIntegerOrEnum(reqType);
			if (TypeAnalysis.IsBoolean(reqType))
			{
				if (TypeAnalysis.IsBoolean(actualType))
				{
					return expr;
				}
				if (flag)
				{
					return new BinaryOperatorExpression(expr, BinaryOperatorType.InEquality, AstBuilder.MakePrimitive(0L, actualType));
				}
				return new BinaryOperatorExpression(expr, BinaryOperatorType.InEquality, new NullReferenceExpression());
			}
			if (TypeAnalysis.IsBoolean(actualType) && flag2)
			{
				return new ConditionalExpression
				{
					Condition = expr,
					TrueExpression = AstBuilder.MakePrimitive(1L, reqType),
					FalseExpression = AstBuilder.MakePrimitive(0L, reqType)
				};
			}
			if (expr is PrimitiveExpression && !flag2 && TypeAnalysis.IsEnum(actualType))
			{
				return expr.CastTo(AstBuilder.ConvertType(actualType));
			}
			bool num = flag || actualType.MetadataType == MetadataType.Single || actualType.MetadataType == MetadataType.Double;
			bool flag3 = flag2 || reqType.MetadataType == MetadataType.Single || reqType.MetadataType == MetadataType.Double;
			if (num & flag3)
			{
				return expr.CastTo(AstBuilder.ConvertType(reqType));
			}
			return expr;
		}
	}
}
