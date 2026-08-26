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
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp;

internal class StatementBuilder : ILVisitor<Statement>
{
	private enum RequiredGetCurrentTransformation
	{
		NoForeach,
		UseExistingVariable,
		IntroduceNewVariable,
		IntroduceNewVariableAndLocalCopy
	}

	internal readonly ExpressionBuilder exprBuilder;

	private readonly ILFunction currentFunction;

	private readonly IDecompilerTypeSystem typeSystem;

	private readonly DecompilerSettings settings;

	private readonly CancellationToken cancellationToken;

	private Block continueTarget;

	private int continueCount;

	private Dictionary<Block, ConstantResolveResult> caseLabelMapping;

	private BlockContainer breakTarget;

	private readonly Dictionary<BlockContainer, string> endContainerLabels = new Dictionary<BlockContainer, string>();

	private static readonly InvocationExpression getEnumeratorPattern = new InvocationExpression(new MemberReferenceExpression(new AnyNode("collection").ToExpression(), "GetEnumerator"));

	private static readonly InvocationExpression moveNextConditionPattern = new InvocationExpression(new MemberReferenceExpression(new NamedNode("enumerator", new IdentifierExpression(Pattern.AnyString)), "MoveNext"));

	public StatementBuilder(IDecompilerTypeSystem typeSystem, ITypeResolveContext decompilationContext, ILFunction currentFunction, DecompilerSettings settings, CancellationToken cancellationToken)
	{
		Debug.Assert(typeSystem != null && decompilationContext != null);
		exprBuilder = new ExpressionBuilder(typeSystem, decompilationContext, currentFunction, settings, cancellationToken);
		this.currentFunction = currentFunction;
		this.typeSystem = typeSystem;
		this.settings = settings;
		this.cancellationToken = cancellationToken;
	}

	public Statement Convert(ILInstruction inst)
	{
		CancellationToken cancellationToken = this.cancellationToken;
		cancellationToken.ThrowIfCancellationRequested();
		return inst.AcceptVisitor(this);
	}

	public BlockStatement ConvertAsBlock(ILInstruction inst)
	{
		Statement statement = Convert(inst);
		return (statement as BlockStatement) ?? new BlockStatement { statement };
	}

	protected override Statement Default(ILInstruction inst)
	{
		return new ExpressionStatement(exprBuilder.Translate(inst));
	}

	protected internal override Statement VisitIsInst(IsInst inst)
	{
		TranslatedExpression arg = exprBuilder.Translate(inst.Argument);
		arg = ExpressionBuilder.UnwrapBoxingConversion(arg);
		return new ExpressionStatement(new IsExpression(arg, exprBuilder.ConvertType(inst.Type)).WithRR(new ResolveResult(exprBuilder.compilation.FindType(KnownTypeCode.Boolean))).WithILInstruction(inst));
	}

	protected internal override Statement VisitStLoc(StLoc inst)
	{
		TranslatedExpression translatedExpression = exprBuilder.Translate(inst);
		if (translatedExpression.Expression is DirectionExpression directionExpression)
		{
			translatedExpression = translatedExpression.UnwrapChild(directionExpression.Expression);
		}
		return new ExpressionStatement(translatedExpression);
	}

	protected internal override Statement VisitNop(Nop inst)
	{
		EmptyStatement emptyStatement = new EmptyStatement();
		if (inst.Comment != null)
		{
			emptyStatement.AddChild(new Comment(inst.Comment), Roles.Comment);
		}
		return emptyStatement;
	}

	protected internal override Statement VisitIfInstruction(IfInstruction inst)
	{
		TranslatedExpression translatedExpression = exprBuilder.TranslateCondition(inst.Condition);
		Statement trueStatement = Convert(inst.TrueInst);
		Statement falseStatement = ((inst.FalseInst.OpCode == OpCode.Nop) ? null : Convert(inst.FalseInst));
		return new IfElseStatement(translatedExpression, trueStatement, falseStatement);
	}

	private IEnumerable<ConstantResolveResult> CreateTypedCaseLabel(long i, IType type, List<(string Key, int Value)> map = null)
	{
		type = NullableType.GetUnderlyingType(type);
		object value;
		if (type.IsKnownType(KnownTypeCode.Boolean))
		{
			value = i != 0;
		}
		else
		{
			if (type.IsKnownType(KnownTypeCode.String) && map != null)
			{
				IEnumerable<string> keys = Enumerable.Select<(string, int), string>(Enumerable.Where<(string, int)>((IEnumerable<(string, int)>)map, (Func<(string, int), bool>)(((string Key, int Value) entry) => entry.Value == i)), (Func<(string, int), string>)(((string Key, int Value) entry) => entry.Key));
				foreach (string key in keys)
				{
					yield return new ConstantResolveResult(type, key);
				}
				yield break;
			}
			if (type.Kind == TypeKind.Enum)
			{
				IType enumType = type.GetDefinition().EnumUnderlyingType;
				TypeCode typeCode = enumType.GetTypeCode();
				value = ((typeCode == TypeCode.Empty) ? ((object)i) : CSharpPrimitiveCast.Cast(typeCode, i, checkForOverflow: false));
			}
			else
			{
				TypeCode typeCode2 = type.GetTypeCode();
				value = ((typeCode2 == TypeCode.Empty) ? ((object)i) : CSharpPrimitiveCast.Cast(typeCode2, i, checkForOverflow: false));
			}
		}
		yield return new ConstantResolveResult(type, value);
	}

	protected internal override Statement VisitSwitchInstruction(SwitchInstruction inst)
	{
		return TranslateSwitch(null, inst);
	}

	private SwitchStatement TranslateSwitch(BlockContainer switchContainer, SwitchInstruction inst)
	{
		BlockContainer blockContainer = breakTarget;
		breakTarget = switchContainer;
		Dictionary<Block, ConstantResolveResult> dictionary = caseLabelMapping;
		caseLabelMapping = new Dictionary<Block, ConstantResolveResult>();
		StringToInt strToInt = inst.Value as StringToInt;
		TranslatedExpression value;
		if (strToInt != null)
		{
			value = exprBuilder.Translate(strToInt.Argument);
		}
		else
		{
			value = exprBuilder.Translate(inst.Value);
		}
		DecompTools.Decompiler.IL.SwitchSection switchSection = inst.Sections.First();
		foreach (DecompTools.Decompiler.IL.SwitchSection section in inst.Sections)
		{
			if (section.Labels.Count() > switchSection.Labels.Count())
			{
				switchSection = section;
			}
		}
		SwitchStatement switchStatement = new SwitchStatement
		{
			Expression = value
		};
		Dictionary<DecompTools.Decompiler.IL.SwitchSection, DecompTools.Decompiler.CSharp.Syntax.SwitchSection> dictionary2 = new Dictionary<DecompTools.Decompiler.IL.SwitchSection, DecompTools.Decompiler.CSharp.Syntax.SwitchSection>();
		foreach (DecompTools.Decompiler.IL.SwitchSection section2 in inst.Sections)
		{
			DecompTools.Decompiler.CSharp.Syntax.SwitchSection switchSection2 = new DecompTools.Decompiler.CSharp.Syntax.SwitchSection();
			ConstantResolveResult value2;
			if (section2 == switchSection)
			{
				switchSection2.CaseLabels.Add(new CaseLabel());
				value2 = null;
			}
			else
			{
				ConstantResolveResult[] array = Enumerable.ToArray<ConstantResolveResult>(Enumerable.SelectMany<long, ConstantResolveResult>(section2.Labels.Values, (Func<long, IEnumerable<ConstantResolveResult>>)((long i) => CreateTypedCaseLabel(i, value.Type, strToInt?.Map))));
				if (section2.HasNullLabel)
				{
					switchSection2.CaseLabels.Add(new CaseLabel(new NullReferenceExpression()));
					value2 = new ConstantResolveResult(SpecialType.NullType, null);
				}
				else
				{
					Debug.Assert(array.Length != 0);
					value2 = array[0];
				}
				switchSection2.CaseLabels.AddRange(Enumerable.Select<ConstantResolveResult, CaseLabel>((IEnumerable<ConstantResolveResult>)array, (Func<ConstantResolveResult, CaseLabel>)((ConstantResolveResult label) => new CaseLabel(exprBuilder.ConvertConstantValue(label, allowImplicitConversion: true)))));
			}
			ILInstruction body = section2.Body;
			ILInstruction iLInstruction = body;
			if (iLInstruction != null && iLInstruction is Branch branch)
			{
				Branch branch2 = branch;
				if (branch2.TargetContainer == switchContainer && Enumerable.All<Branch>(Enumerable.Where<Branch>(Enumerable.OfType<Branch>((IEnumerable)switchContainer.Descendants), (Func<Branch, bool>)((Branch b) => b.TargetBlock == branch2.TargetBlock)), (Func<Branch, bool>)((Branch b) => BlockContainer.FindClosestSwitchContainer(b) == switchContainer)))
				{
					caseLabelMapping.Add(branch2.TargetBlock, value2);
				}
			}
			dictionary2.Add(section2, switchSection2);
			switchStatement.SwitchSections.Add(switchSection2);
		}
		foreach (DecompTools.Decompiler.IL.SwitchSection section3 in inst.Sections)
		{
			DecompTools.Decompiler.CSharp.Syntax.SwitchSection switchSection3 = dictionary2[section3];
			ILInstruction body2 = section3.Body;
			ILInstruction iLInstruction2 = body2;
			if (iLInstruction2 != null)
			{
				if (iLInstruction2 is Branch branch3)
				{
					Branch branch4 = branch3;
					if (branch4.TargetContainer == switchContainer && Enumerable.All<Branch>(Enumerable.Where<Branch>(Enumerable.OfType<Branch>((IEnumerable)switchContainer.Descendants), (Func<Branch, bool>)((Branch b) => b.TargetBlock == branch4.TargetBlock)), (Func<Branch, bool>)((Branch b) => BlockContainer.FindClosestSwitchContainer(b) == switchContainer)))
					{
						ConvertSwitchSectionBody(switchSection3, branch4.TargetBlock);
					}
					else
					{
						ConvertSwitchSectionBody(switchSection3, section3.Body);
					}
					continue;
				}
				if (iLInstruction2 is Leave leave)
				{
					Leave leave2 = leave;
					if (switchSection3.CaseLabels.Count == 1 && Enumerable.First<CaseLabel>((IEnumerable<CaseLabel>)switchSection3.CaseLabels).Expression.IsNull && leave2.TargetContainer == switchContainer)
					{
						switchStatement.SwitchSections.Remove(switchSection3);
						continue;
					}
				}
			}
			ConvertSwitchSectionBody(switchSection3, section3.Body);
		}
		if (switchContainer != null && switchStatement.SwitchSections.Count > 0)
		{
			AstNodeCollection<Statement> statements = Enumerable.Last<DecompTools.Decompiler.CSharp.Syntax.SwitchSection>((IEnumerable<DecompTools.Decompiler.CSharp.Syntax.SwitchSection>)switchStatement.SwitchSections).Statements;
			foreach (Block item in Enumerable.Skip<Block>((IEnumerable<Block>)switchContainer.Blocks, 1))
			{
				if (caseLabelMapping.ContainsKey(item))
				{
					continue;
				}
				statements.Add(new LabelStatement
				{
					Label = item.Label
				});
				foreach (ILInstruction instruction in item.Instructions)
				{
					Statement statement = Convert(instruction);
					if (statement is BlockStatement blockStatement)
					{
						foreach (Statement statement2 in blockStatement.Statements)
						{
							statements.Add(statement2.Detach());
						}
					}
					else
					{
						statements.Add(statement);
					}
				}
				Debug.Assert(item.FinalInstruction.OpCode == OpCode.Nop);
			}
			if (endContainerLabels.TryGetValue(switchContainer, out var value3))
			{
				statements.Add(new LabelStatement
				{
					Label = value3
				});
				statements.Add(new BreakStatement());
			}
		}
		breakTarget = blockContainer;
		caseLabelMapping = dictionary;
		return switchStatement;
	}

	private void ConvertSwitchSectionBody(DecompTools.Decompiler.CSharp.Syntax.SwitchSection astSection, ILInstruction bodyInst)
	{
		Statement statement = Convert(bodyInst);
		astSection.Statements.Add(statement);
		if (!bodyInst.HasFlag(InstructionFlags.EndPointUnreachable))
		{
			if (statement is BlockStatement blockStatement)
			{
				blockStatement.Add(new BreakStatement());
			}
			else
			{
				astSection.Statements.Add(new BreakStatement());
			}
		}
	}

	protected internal override Statement VisitBranch(Branch inst)
	{
		checked
		{
			if (inst.TargetBlock == continueTarget)
			{
				continueCount++;
				return new ContinueStatement();
			}
			if (caseLabelMapping != null && caseLabelMapping.TryGetValue(inst.TargetBlock, out var value))
			{
				if (value == null)
				{
					return new GotoDefaultStatement();
				}
				return new GotoCaseStatement
				{
					LabelExpression = exprBuilder.ConvertConstantValue(value, allowImplicitConversion: true)
				};
			}
			return new GotoStatement(inst.TargetLabel);
		}
	}

	protected internal override Statement VisitLeave(Leave inst)
	{
		if (inst.TargetContainer == breakTarget)
		{
			return new BreakStatement();
		}
		if (inst.IsLeavingFunction)
		{
			if (currentFunction.IsIterator)
			{
				return new YieldBreakStatement();
			}
			if (!inst.Value.MatchNop())
			{
				IType type = (currentFunction.IsAsync ? currentFunction.AsyncReturnType : currentFunction.ReturnType);
				TranslatedExpression translatedExpression = exprBuilder.Translate(inst.Value, type).ConvertTo(type, exprBuilder, checkForOverflow: false, allowImplicitConversion: true);
				return new ReturnStatement(translatedExpression);
			}
			return new ReturnStatement();
		}
		if (!endContainerLabels.TryGetValue(inst.TargetContainer, out var value))
		{
			value = "end_" + inst.TargetLabel;
			endContainerLabels.Add(inst.TargetContainer, value);
		}
		return new GotoStatement(value);
	}

	protected internal override Statement VisitThrow(Throw inst)
	{
		return new ThrowStatement(exprBuilder.Translate(inst.Argument));
	}

	protected internal override Statement VisitRethrow(Rethrow inst)
	{
		return new ThrowStatement();
	}

	protected internal override Statement VisitYieldReturn(YieldReturn inst)
	{
		IType elementTypeFromIEnumerable = currentFunction.ReturnType.GetElementTypeFromIEnumerable(typeSystem, allowIEnumerator: true, out var _);
		TranslatedExpression translatedExpression = exprBuilder.Translate(inst.Value, elementTypeFromIEnumerable).ConvertTo(elementTypeFromIEnumerable, exprBuilder, checkForOverflow: false, allowImplicitConversion: true);
		return new YieldReturnStatement
		{
			Expression = translatedExpression
		};
	}

	private TryCatchStatement MakeTryCatch(ILInstruction tryBlock)
	{
		Statement statement = Convert(tryBlock);
		if (statement is TryCatchStatement tryCatchStatement && tryCatchStatement.FinallyBlock.IsNull)
		{
			return tryCatchStatement;
		}
		TryCatchStatement tryCatchStatement2 = new TryCatchStatement();
		tryCatchStatement2.TryBlock = (statement as BlockStatement) ?? new BlockStatement { statement };
		return tryCatchStatement2;
	}

	protected internal override Statement VisitTryCatch(TryCatch inst)
	{
		TryCatchStatement tryCatchStatement = new TryCatchStatement();
		tryCatchStatement.TryBlock = ConvertAsBlock(inst.TryBlock);
		foreach (TryCatchHandler handler in inst.Handlers)
		{
			CatchClause catchClause = new CatchClause();
			ILVariable variable = handler.Variable;
			catchClause.AddAnnotation(new ILVariableResolveResult(variable, variable.Type));
			if (variable != null)
			{
				if (variable.StoreCount > 1 || variable.LoadCount > 0 || variable.AddressCount > 0)
				{
					catchClause.VariableName = variable.Name;
					catchClause.Type = exprBuilder.ConvertType(variable.Type);
				}
				else if (!variable.Type.IsKnownType(KnownTypeCode.Object))
				{
					catchClause.Type = exprBuilder.ConvertType(variable.Type);
				}
			}
			if (!handler.Filter.MatchLdcI4(1))
			{
				catchClause.Condition = exprBuilder.TranslateCondition(handler.Filter);
			}
			catchClause.Body = ConvertAsBlock(handler.Body);
			tryCatchStatement.CatchClauses.Add(catchClause);
		}
		return tryCatchStatement;
	}

	protected internal override Statement VisitTryFinally(TryFinally inst)
	{
		TryCatchStatement tryCatchStatement = MakeTryCatch(inst.TryBlock);
		tryCatchStatement.FinallyBlock = ConvertAsBlock(inst.FinallyBlock);
		return tryCatchStatement;
	}

	protected internal override Statement VisitTryFault(TryFault inst)
	{
		TryCatchStatement tryCatchStatement = new TryCatchStatement();
		tryCatchStatement.TryBlock = ConvertAsBlock(inst.TryBlock);
		BlockStatement blockStatement = ConvertAsBlock(inst.FaultBlock);
		blockStatement.InsertChildAfter(null, new Comment("try-fault"), Roles.Comment);
		blockStatement.Add(new ThrowStatement());
		tryCatchStatement.CatchClauses.Add(new CatchClause
		{
			Body = blockStatement
		});
		return tryCatchStatement;
	}

	protected internal override Statement VisitLockInstruction(LockInstruction inst)
	{
		return new LockStatement
		{
			Expression = exprBuilder.Translate(inst.OnExpression),
			EmbeddedStatement = ConvertAsBlock(inst.Body)
		};
	}

	protected internal override Statement VisitUsingInstruction(UsingInstruction inst)
	{
		Statement statement = TransformToForeach(inst, out var resource);
		if (statement != null)
		{
			return statement;
		}
		AstNode resourceAcquisition = resource;
		ILVariable variable = inst.Variable;
		if (!inst.ResourceExpression.MatchLdNull() && !Enumerable.Any<IType>(NullableType.GetUnderlyingType(variable.Type).GetAllBaseTypes(), (Func<IType, bool>)((IType b) => b.IsKnownType(KnownTypeCode.IDisposable))))
		{
			variable.Kind = VariableKind.Local;
			IType type = exprBuilder.compilation.FindType(KnownTypeCode.IDisposable);
			ILVariable variable2 = currentFunction.RegisterVariable(VariableKind.Local, type, AssignVariableNames.GenerateVariableName(currentFunction, type));
			return new BlockStatement
			{
				new ExpressionStatement(new AssignmentExpression(exprBuilder.ConvertVariable(variable).Expression, resource.Detach())),
				new TryCatchStatement
				{
					TryBlock = ConvertAsBlock(inst.Body),
					FinallyBlock = new BlockStatement
					{
						new ExpressionStatement(new AssignmentExpression(exprBuilder.ConvertVariable(variable2).Expression, new AsExpression(exprBuilder.ConvertVariable(variable).Expression, exprBuilder.ConvertType(type)))),
						new IfElseStatement
						{
							Condition = new BinaryOperatorExpression(exprBuilder.ConvertVariable(variable2), BinaryOperatorType.InEquality, new NullReferenceExpression()),
							TrueStatement = new ExpressionStatement(new InvocationExpression(new MemberReferenceExpression(exprBuilder.ConvertVariable(variable2).Expression, "Dispose")))
						}
					}
				}
			};
		}
		if (variable.LoadCount > 0 || variable.AddressCount > 0)
		{
			AstType type2 = ((settings.AnonymousTypes && variable.Type.ContainsAnonymousType()) ? new SimpleType("var") : exprBuilder.ConvertType(variable.Type));
			VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement(type2, variable.Name, resource);
			Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)variableDeclarationStatement.Variables).AddAnnotation(new ILVariableResolveResult(variable, variable.Type));
			resourceAcquisition = variableDeclarationStatement;
		}
		return new UsingStatement
		{
			ResourceAcquisition = resourceAcquisition,
			EmbeddedStatement = ConvertAsBlock(inst.Body)
		};
	}

	private Statement TransformToForeach(UsingInstruction inst, out Expression resource)
	{
		if (!settings.ForEachStatement)
		{
			resource = null;
			return null;
		}
		resource = exprBuilder.Translate(inst.ResourceExpression);
		Match match = getEnumeratorPattern.Match(resource);
		if (!(inst.Body is BlockContainer blockContainer) || !match.Success)
		{
			return null;
		}
		ILVariable variable = inst.Variable;
		BlockContainer blockContainer2 = UnwrapNestedContainerIfPossible(blockContainer, out var optionalReturnInst);
		if (blockContainer2.Kind != ContainerKind.While)
		{
			return null;
		}
		if (!blockContainer2.MatchConditionBlock(blockContainer2.EntryPoint, out var condition, out var bodyStartBlock))
		{
			return null;
		}
		TranslatedExpression translatedExpression = exprBuilder.TranslateCondition(condition);
		Match match2 = moveNextConditionPattern.Match(translatedExpression.Expression);
		if (!match2.Success)
		{
			return null;
		}
		ILVariable iLVariable = Enumerable.Single<IdentifierExpression>(match2.Get<IdentifierExpression>("enumerator")).GetILVariable();
		if (iLVariable != variable)
		{
			return null;
		}
		RequiredGetCurrentTransformation requiredGetCurrentTransformation = DetectGetCurrentTransformation(blockContainer, bodyStartBlock, variable, condition, out var singleGetter, out var foreachVariable);
		if (requiredGetCurrentTransformation == RequiredGetCurrentTransformation.NoForeach)
		{
			return null;
		}
		if (foreachVariable != null && foreachVariable.CaptureScope != null && foreachVariable.CaptureScope != blockContainer2)
		{
			return null;
		}
		Expression expression = Enumerable.Single<Expression>(match.Get<Expression>("collection"));
		Expression dynamicExpr;
		if (expression is BaseReferenceExpression)
		{
			expression = new ThisReferenceExpression().CopyAnnotationsFrom(expression);
		}
		else if (IsDynamicCastToIEnumerable(expression, out dynamicExpr))
		{
			expression = dynamicExpr.Detach();
		}
		IType type = singleGetter.Method.ReturnType;
		ILInstruction iLInstruction = singleGetter;
		bool flag = false;
		ILInstruction parent = iLInstruction.Parent;
		ILInstruction iLInstruction2 = parent;
		if (iLInstruction2 == null)
		{
			goto IL_0239;
		}
		if (!(iLInstruction2 is CastClass castClass))
		{
			if (!(iLInstruction2 is UnboxAny unboxAny))
			{
				goto IL_0239;
			}
			UnboxAny unboxAny2 = unboxAny;
			type = unboxAny2.Type;
			iLInstruction = unboxAny2;
		}
		else
		{
			CastClass castClass2 = castClass;
			type = castClass2.Type;
			iLInstruction = castClass2;
		}
		goto IL_0287;
		IL_0287:
		switch (requiredGetCurrentTransformation)
		{
		case RequiredGetCurrentTransformation.UseExistingVariable:
			if (foreachVariable.Type.Kind != TypeKind.Dynamic)
			{
				foreachVariable.Type = type;
			}
			foreachVariable.Kind = VariableKind.ForeachLocal;
			foreachVariable.Name = AssignVariableNames.GenerateForeachVariableName(currentFunction, expression.Annotation<ILInstruction>(), foreachVariable);
			break;
		case RequiredGetCurrentTransformation.IntroduceNewVariable:
			foreachVariable = currentFunction.RegisterVariable(VariableKind.ForeachLocal, type, AssignVariableNames.GenerateForeachVariableName(currentFunction, expression.Annotation<ILInstruction>()));
			iLInstruction.ReplaceWith(new LdLoc(foreachVariable));
			bodyStartBlock.Instructions.Insert(0, new StLoc(foreachVariable, iLInstruction));
			break;
		case RequiredGetCurrentTransformation.IntroduceNewVariableAndLocalCopy:
		{
			foreachVariable = currentFunction.RegisterVariable(VariableKind.ForeachLocal, type, AssignVariableNames.GenerateForeachVariableName(currentFunction, expression.Annotation<ILInstruction>()));
			ILVariable variable2 = currentFunction.RegisterVariable(VariableKind.Local, type, AssignVariableNames.GenerateVariableName(currentFunction, type));
			iLInstruction.Parent.ReplaceWith(new LdLoca(variable2));
			bodyStartBlock.Instructions.Insert(0, new StLoc(variable2, new LdLoc(foreachVariable)));
			bodyStartBlock.Instructions.Insert(0, new StLoc(foreachVariable, iLInstruction));
			break;
		}
		}
		WhileStatement whileStatement = (WhileStatement)Enumerable.First<Statement>((IEnumerable<Statement>)ConvertAsBlock(blockContainer));
		BlockStatement blockStatement = (BlockStatement)whileStatement.EmbeddedStatement.Detach();
		Statement statement = Enumerable.First<Statement>((IEnumerable<Statement>)blockStatement.Statements);
		if (statement is LabelStatement)
		{
			statement = statement.GetNextStatement();
		}
		Debug.Assert(statement is ExpressionStatement);
		statement.Remove();
		if (settings.AnonymousTypes && type.ContainsAnonymousType())
		{
			flag = true;
		}
		ForeachStatement foreachStatement = new ForeachStatement
		{
			VariableType = (flag ? new SimpleType("var") : exprBuilder.ConvertType(foreachVariable.Type)),
			VariableName = foreachVariable.Name,
			InExpression = expression.Detach(),
			EmbeddedStatement = blockStatement
		};
		foreachStatement.AddAnnotation(new ILVariableResolveResult(foreachVariable, foreachVariable.Type));
		foreachStatement.AddAnnotation(new ForeachAnnotation(inst.ResourceExpression, condition, singleGetter));
		if (optionalReturnInst != null)
		{
			return new BlockStatement
			{
				Statements = 
				{
					(Statement)foreachStatement,
					optionalReturnInst.AcceptVisitor(this)
				}
			};
		}
		return foreachStatement;
		IL_0239:
		if (TupleType.IsTupleCompatible(type, out var _))
		{
			ForEachResolveResult forEachResolveResult = exprBuilder.resolver.ResolveForeach(expression.GetResolveResult());
			if (EqualErasedType(type, forEachResolveResult.ElementType))
			{
				type = forEachResolveResult.ElementType;
				flag = true;
			}
		}
		goto IL_0287;
	}

	private static bool EqualErasedType(IType a, IType b)
	{
		return NormalizeTypeVisitor.TypeErasure.EquivalentTypes(a, b);
	}

	private bool IsDynamicCastToIEnumerable(Expression expr, out Expression dynamicExpr)
	{
		if (!(expr is CastExpression castExpression))
		{
			dynamicExpr = null;
			return false;
		}
		dynamicExpr = castExpression.Expression;
		if (!(expr.GetResolveResult() is ConversionResolveResult conversionResolveResult))
		{
			return false;
		}
		if (!conversionResolveResult.Type.IsKnownType(KnownTypeCode.IEnumerable))
		{
			return false;
		}
		return conversionResolveResult.Input.Type.Kind == TypeKind.Dynamic;
	}

	private BlockContainer UnwrapNestedContainerIfPossible(BlockContainer container, out Leave optionalReturnInst)
	{
		optionalReturnInst = null;
		if (container.Blocks.Count != 1)
		{
			return container;
		}
		Block block = container.Blocks[0];
		if (block.Instructions.Count != 2 || !(block.Instructions[0] is BlockContainer result) || !(block.Instructions[1] is Leave leave))
		{
			return container;
		}
		if (leave.MatchLeave(container))
		{
			return result;
		}
		if (leave.IsLeavingFunction && SemanticHelper.IsPure(leave.Value.Flags))
		{
			optionalReturnInst = leave;
			return result;
		}
		return container;
	}

	private RequiredGetCurrentTransformation DetectGetCurrentTransformation(BlockContainer usingContainer, Block loopBody, ILVariable enumerator, ILInstruction moveNextUsage, out CallInstruction singleGetter, out ILVariable foreachVariable)
	{
		singleGetter = null;
		foreachVariable = null;
		ILInstruction[] array = Enumerable.ToArray<ILInstruction>(Enumerable.Where<ILInstruction>(Enumerable.Concat<ILInstruction>(Enumerable.OfType<ILInstruction>((IEnumerable)enumerator.LoadInstructions), Enumerable.OfType<ILInstruction>((IEnumerable)enumerator.AddressInstructions)), (Func<ILInstruction, bool>)((ILInstruction ld) => !ld.IsDescendantOf(moveNextUsage))));
		if (array.Length != 1 || !ParentIsCurrentGetter(array[0]))
		{
			return RequiredGetCurrentTransformation.NoForeach;
		}
		singleGetter = (CallInstruction)array[0].Parent;
		if (!singleGetter.IsDescendantOf(loopBody.Instructions[0]) || !ILInlining.CanUninline(singleGetter, loopBody.Instructions[0]))
		{
			return RequiredGetCurrentTransformation.NoForeach;
		}
		ILInstruction iLInstruction = singleGetter;
		while (iLInstruction.Parent is UnboxAny || iLInstruction.Parent is CastClass)
		{
			iLInstruction = iLInstruction.Parent;
		}
		if (iLInstruction.Parent is StLoc stLoc && stLoc.Parent == loopBody && VariableIsOnlyUsedInBlock(stLoc, usingContainer))
		{
			foreachVariable = stLoc.Variable;
			return RequiredGetCurrentTransformation.UseExistingVariable;
		}
		if (CurrentIsStructSetterTarget(iLInstruction, singleGetter))
		{
			return RequiredGetCurrentTransformation.IntroduceNewVariableAndLocalCopy;
		}
		return RequiredGetCurrentTransformation.IntroduceNewVariable;
	}

	private bool VariableIsOnlyUsedInBlock(StLoc storeInst, BlockContainer usingContainer)
	{
		if (Enumerable.Any<LdLoc>((IEnumerable<LdLoc>)storeInst.Variable.LoadInstructions, (Func<LdLoc, bool>)((LdLoc ld) => !ld.IsDescendantOf(usingContainer))))
		{
			return false;
		}
		if (Enumerable.Any<LdLoca>((IEnumerable<LdLoca>)storeInst.Variable.AddressInstructions, (Func<LdLoca, bool>)((LdLoca la) => !la.IsDescendantOf(usingContainer) || !ILInlining.IsUsedAsThisPointerInCall(la) || IsTargetOfSetterCall(la, la.Variable.Type))))
		{
			return false;
		}
		if (Enumerable.Any<ILInstruction>(Enumerable.OfType<ILInstruction>((IEnumerable)storeInst.Variable.StoreInstructions), (Func<ILInstruction, bool>)((ILInstruction st) => st != storeInst)))
		{
			return false;
		}
		return true;
	}

	private bool CurrentIsStructSetterTarget(ILInstruction inst, CallInstruction singleGetter)
	{
		if (!(inst.Parent is AddressOf inst2))
		{
			return false;
		}
		return IsTargetOfSetterCall(inst2, singleGetter.Method.ReturnType);
	}

	private bool IsTargetOfSetterCall(ILInstruction inst, IType targetType)
	{
		if (inst.ChildIndex != 0)
		{
			return false;
		}
		if (targetType.IsReferenceType ?? false)
		{
			return false;
		}
		OpCode opCode = inst.Parent.OpCode;
		if (opCode - 27 <= OpCode.InvalidExpression)
		{
			IMethod method = ((CallInstruction)inst.Parent).Method;
			if (!method.IsAccessor || method.IsStatic)
			{
				return false;
			}
			IMember accessorOwner = method.AccessorOwner;
			IMember member = accessorOwner;
			if (member != null && member is IProperty property)
			{
				IProperty property2 = property;
				return property2.Setter == method;
			}
			return true;
		}
		return false;
	}

	private bool ParentIsCurrentGetter(ILInstruction inst)
	{
		return inst.Parent is CallInstruction callInstruction && callInstruction.Method.IsAccessor && callInstruction.Method.AccessorOwner is IProperty property && property.Getter.Equals(callInstruction.Method);
	}

	protected internal override Statement VisitPinnedRegion(PinnedRegion inst)
	{
		FixedStatement fixedStatement = new FixedStatement();
		fixedStatement.Type = exprBuilder.ConvertType(inst.Variable.Type);
		Expression initializer = ((inst.Init.OpCode != OpCode.ArrayToPointer) ? ((Expression)exprBuilder.Translate(inst.Init, inst.Variable.Type).ConvertTo(inst.Variable.Type, exprBuilder)) : ((Expression)exprBuilder.Translate(((ArrayToPointer)inst.Init).Array)));
		fixedStatement.Variables.Add(new VariableInitializer(inst.Variable.Name, initializer).WithILVariable(inst.Variable));
		fixedStatement.EmbeddedStatement = Convert(inst.Body);
		return fixedStatement;
	}

	protected internal override Statement VisitBlock(Block block)
	{
		if (block.Kind != BlockKind.ControlFlow)
		{
			return Default(block);
		}
		BlockStatement blockStatement = new BlockStatement();
		foreach (ILInstruction instruction in block.Instructions)
		{
			blockStatement.Add(Convert(instruction));
		}
		if (block.FinalInstruction.OpCode != OpCode.Nop)
		{
			blockStatement.Add(Convert(block.FinalInstruction));
		}
		return blockStatement;
	}

	protected internal override Statement VisitBlockContainer(BlockContainer container)
	{
		if (container.Kind != ContainerKind.Normal && container.EntryPoint.IncomingEdgeCount > 1)
		{
			Block block = continueTarget;
			int num = continueCount;
			BlockContainer blockContainer = breakTarget;
			Statement statement = ConvertLoop(container);
			statement.AddAnnotation(container);
			continueTarget = block;
			continueCount = num;
			breakTarget = blockContainer;
			return statement;
		}
		if (container.EntryPoint.Instructions.Count == 1 && container.EntryPoint.Instructions[0] is SwitchInstruction inst)
		{
			return TranslateSwitch(container, inst);
		}
		BlockStatement blockStatement = ConvertBlockContainer(container, isLoop: false);
		blockStatement.AddAnnotation(container);
		return blockStatement;
	}

	private Statement ConvertLoop(BlockContainer container)
	{
		continueCount = 0;
		breakTarget = container;
		checked
		{
			ILInstruction condition;
			Block bodyStartBlock;
			switch (container.Kind)
			{
			case ContainerKind.Loop:
			{
				continueTarget = container.EntryPoint;
				BlockStatement blockStatement = ConvertBlockContainer(container, isLoop: true);
				Debug.Assert(continueCount < container.EntryPoint.IncomingEdgeCount);
				Debug.Assert(Enumerable.First<Statement>((IEnumerable<Statement>)blockStatement.Statements) is LabelStatement);
				if (container.EntryPoint.IncomingEdgeCount == continueCount + 1)
				{
					Enumerable.First<Statement>((IEnumerable<Statement>)blockStatement.Statements).Remove();
				}
				if (Enumerable.LastOrDefault<Statement>((IEnumerable<Statement>)blockStatement) is ContinueStatement continueStatement2)
				{
					continueStatement2.Remove();
				}
				return new WhileStatement(new PrimitiveExpression(true), blockStatement);
			}
			case ContainerKind.While:
			{
				continueTarget = container.EntryPoint;
				if (!container.MatchConditionBlock(continueTarget, out condition, out bodyStartBlock))
				{
					throw new NotSupportedException("Invalid condition block in while loop.");
				}
				BlockStatement blockStatement = ConvertAsBlock(bodyStartBlock);
				if (!bodyStartBlock.HasFlag(InstructionFlags.EndPointUnreachable))
				{
					blockStatement.Add(new BreakStatement());
				}
				blockStatement = ConvertBlockContainer(blockStatement, container, Enumerable.Except<Block>(Enumerable.Skip<Block>((IEnumerable<Block>)container.Blocks, 1), (IEnumerable<Block>)new Block[1] { bodyStartBlock }), isLoop: true);
				Debug.Assert(continueCount < container.EntryPoint.IncomingEdgeCount);
				if (continueCount + 1 < container.EntryPoint.IncomingEdgeCount)
				{
					if (Enumerable.LastOrDefault<Statement>((IEnumerable<Statement>)blockStatement) is ContinueStatement)
					{
						Enumerable.Last<Statement>((IEnumerable<Statement>)blockStatement).Remove();
					}
					blockStatement.Add(new LabelStatement
					{
						Label = container.EntryPoint.Label
					});
				}
				if (Enumerable.LastOrDefault<Statement>((IEnumerable<Statement>)blockStatement) is ContinueStatement continueStatement4)
				{
					continueStatement4.Remove();
				}
				return new WhileStatement(exprBuilder.TranslateCondition(condition), blockStatement);
			}
			case ContainerKind.DoWhile:
			{
				continueTarget = container.Blocks.Last();
				if (!container.MatchConditionBlock(continueTarget, out condition, out var _))
				{
					throw new NotSupportedException("Invalid condition block in do-while loop.");
				}
				BlockStatement blockStatement = ConvertBlockContainer(new BlockStatement(), container, container.Blocks.SkipLast(1), isLoop: true);
				if (container.EntryPoint.IncomingEdgeCount == 2)
				{
					Enumerable.First<Statement>((IEnumerable<Statement>)blockStatement.Statements).Remove();
				}
				if (Enumerable.LastOrDefault<Statement>((IEnumerable<Statement>)blockStatement) is ContinueStatement continueStatement3)
				{
					continueStatement3.Remove();
				}
				if (continueTarget.IncomingEdgeCount > continueCount)
				{
					blockStatement.Add(new LabelStatement
					{
						Label = continueTarget.Label
					});
				}
				if (blockStatement.Statements.Count == 0)
				{
					return new WhileStatement
					{
						Condition = exprBuilder.TranslateCondition(condition),
						EmbeddedStatement = blockStatement
					};
				}
				return new DoWhileStatement
				{
					EmbeddedStatement = blockStatement,
					Condition = exprBuilder.TranslateCondition(condition)
				};
			}
			case ContainerKind.For:
			{
				continueTarget = container.Blocks.Last();
				if (!container.MatchConditionBlock(container.EntryPoint, out condition, out bodyStartBlock))
				{
					throw new NotSupportedException("Invalid condition block in for loop.");
				}
				BlockStatement blockStatement = ConvertAsBlock(bodyStartBlock);
				if (!bodyStartBlock.HasFlag(InstructionFlags.EndPointUnreachable))
				{
					blockStatement.Add(new BreakStatement());
				}
				if (!container.MatchIncrementBlock(continueTarget))
				{
					throw new NotSupportedException("Invalid increment block in for loop.");
				}
				blockStatement = ConvertBlockContainer(blockStatement, container, Enumerable.Except<Block>(Enumerable.Skip<Block>(container.Blocks.SkipLast(1), 1), (IEnumerable<Block>)new Block[1] { bodyStartBlock }), isLoop: true);
				ForStatement forStatement = new ForStatement
				{
					Condition = exprBuilder.TranslateCondition(condition),
					EmbeddedStatement = blockStatement
				};
				if (Enumerable.LastOrDefault<Statement>((IEnumerable<Statement>)blockStatement) is ContinueStatement continueStatement)
				{
					continueStatement.Remove();
				}
				for (int i = 0; i < continueTarget.Instructions.Count - 1; i++)
				{
					forStatement.Iterators.Add(Convert(continueTarget.Instructions[i]));
				}
				if (continueTarget.IncomingEdgeCount > continueCount)
				{
					blockStatement.Add(new LabelStatement
					{
						Label = continueTarget.Label
					});
				}
				return forStatement;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	private BlockStatement ConvertBlockContainer(BlockContainer container, bool isLoop)
	{
		return ConvertBlockContainer(new BlockStatement(), container, container.Blocks, isLoop);
	}

	private BlockStatement ConvertBlockContainer(BlockStatement blockStatement, BlockContainer container, IEnumerable<Block> blocks, bool isLoop)
	{
		foreach (Block block in blocks)
		{
			if (block.IncomingEdgeCount > 1 || block != container.EntryPoint)
			{
				blockStatement.Add(new LabelStatement
				{
					Label = block.Label
				});
			}
			foreach (ILInstruction instruction in block.Instructions)
			{
				if (!isLoop && instruction is Leave leave && IsFinalLeave(leave))
				{
					blockStatement.AddAnnotation(new ImplicitReturnAnnotation(leave));
					continue;
				}
				Statement statement = Convert(instruction);
				if (statement is BlockStatement blockStatement2)
				{
					foreach (Statement statement2 in blockStatement2.Statements)
					{
						blockStatement.Add(statement2.Detach());
					}
				}
				else
				{
					blockStatement.Add(statement);
				}
			}
			if (block.FinalInstruction.OpCode != OpCode.Nop)
			{
				blockStatement.Add(Convert(block.FinalInstruction));
			}
		}
		if (endContainerLabels.TryGetValue(container, out var value))
		{
			if (isLoop && !(Enumerable.LastOrDefault<Statement>((IEnumerable<Statement>)blockStatement) is ContinueStatement))
			{
				blockStatement.Add(new ContinueStatement());
			}
			blockStatement.Add(new LabelStatement
			{
				Label = value
			});
			if (isLoop)
			{
				blockStatement.Add(new BreakStatement());
			}
		}
		return blockStatement;
	}

	private static bool IsFinalLeave(Leave leave)
	{
		if (!leave.Value.MatchNop())
		{
			return false;
		}
		Block block = (Block)leave.Parent;
		checked
		{
			if (leave.ChildIndex != block.Instructions.Count - 1 || block.FinalInstruction.OpCode != OpCode.Nop)
			{
				return false;
			}
			BlockContainer blockContainer = (BlockContainer)block.Parent;
			return block.ChildIndex == blockContainer.Blocks.Count - 1 && blockContainer == leave.TargetContainer;
		}
	}

	protected internal override Statement VisitInitblk(Initblk inst)
	{
		ExpressionStatement expressionStatement = new ExpressionStatement(new InvocationExpression
		{
			Target = new IdentifierExpression("memset"),
			Arguments = 
			{
				(Expression)exprBuilder.Translate(inst.Address),
				(Expression)exprBuilder.Translate(inst.Value),
				(Expression)exprBuilder.Translate(inst.Size)
			}
		});
		expressionStatement.InsertChildAfter(null, new Comment(" IL initblk instruction"), Roles.Comment);
		return expressionStatement;
	}

	protected internal override Statement VisitCpblk(Cpblk inst)
	{
		ExpressionStatement expressionStatement = new ExpressionStatement(new InvocationExpression
		{
			Target = new IdentifierExpression("memcpy"),
			Arguments = 
			{
				(Expression)exprBuilder.Translate(inst.DestAddress),
				(Expression)exprBuilder.Translate(inst.SourceAddress),
				(Expression)exprBuilder.Translate(inst.Size)
			}
		});
		expressionStatement.InsertChildAfter(null, new Comment(" IL cpblk instruction"), Roles.Comment);
		return expressionStatement;
	}
}
