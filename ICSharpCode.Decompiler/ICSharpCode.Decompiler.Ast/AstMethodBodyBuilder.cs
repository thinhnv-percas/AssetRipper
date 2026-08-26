using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast;

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

	private StringBuilder stringBuilder;

	private MethodDef methodDef;

	private ICorLibTypes corLib;

	private DecompilerContext context;

	private bool valueParameterIsKeyword;

	private AutoPropertyProvider autoPropertyProvider;

	private readonly HashSet<ILVariable> localVariablesToDefine = new HashSet<ILVariable>();

	private readonly List<ILNode> ILNode_List = new List<ILNode>();

	private readonly List<SourceLocal> sourceLocalsList = new List<SourceLocal>();

	private readonly List<SourceParameter> sourceParametersList = new List<SourceParameter>();

	private IMDTokenProvider Create_SystemArray_get_Length_result;

	private bool Create_SystemArray_get_Length_result_initd;

	private IMDTokenProvider Create_SystemType_get_TypeHandle_result;

	private bool Create_SystemType_get_TypeHandle_initd;

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
			TypeArguments = { (AstType)new Repeat(new AnyNode()) },
			MemberName = "Add"
		},
		Arguments = { (Expression)new Repeat(new AnyNode("arg")) }
	};

	private static readonly AstNode staticCollectionInitializerPattern = new InvocationExpression
	{
		Target = new MemberReferenceExpression
		{
			Target = new TypeReferenceExpression
			{
				Type = new AnyNode()
			},
			TypeArguments = { (AstType)new Repeat(new AnyNode()) },
			MemberName = "Add"
		},
		Arguments = 
		{
			(Expression)new AnyNode(),
			(Expression)new Repeat(new AnyNode("arg"))
		}
	};

	private static readonly UTF8String nameInvoke = new UTF8String("Invoke");

	private static readonly UTF8String systemReflectionString = new UTF8String("System.Reflection");

	private static readonly UTF8String defaultMemberAttributeString = new UTF8String("DefaultMemberAttribute");

	private static readonly char[] newLineChars = new char[5] { '\r', '\n', '\u0085', '\u2028', '\u2029' };

	public void Reset()
	{
		autoPropertyProvider = null;
		localVariablesToDefine.Clear();
		ILNode_List.Clear();
	}

	internal static BlockStatement CreateMethodBody(MethodDef methodDef, DecompilerContext context, AutoPropertyProvider autoPropertyProvider, IEnumerable<ParameterDeclaration> parameters, bool valueParameterIsKeyword, StringBuilder sb, out MethodDebugInfoBuilder stmtsBuilder)
	{
		MethodDef currentMethod = context.CurrentMethod;
		context.CurrentMethod = methodDef;
		context.CurrentMethodIsAsync = false;
		context.CurrentMethodIsYieldReturn = false;
		AstMethodBodyBuilder astMethodBodyBuilder = context.Cache.GetAstMethodBodyBuilder();
		try
		{
			astMethodBodyBuilder.stringBuilder = sb;
			astMethodBodyBuilder.methodDef = methodDef;
			astMethodBodyBuilder.context = context;
			astMethodBodyBuilder.corLib = methodDef.Module.CorLibTypes;
			astMethodBodyBuilder.valueParameterIsKeyword = valueParameterIsKeyword;
			astMethodBodyBuilder.autoPropertyProvider = autoPropertyProvider;
			if (Debugger.IsAttached)
			{
				return astMethodBodyBuilder.CreateMethodBody(parameters, out stmtsBuilder);
			}
			try
			{
				return astMethodBodyBuilder.CreateMethodBody(parameters, out stmtsBuilder);
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
		finally
		{
			context.CurrentMethod = currentMethod;
			context.Cache.Return(astMethodBodyBuilder);
		}
	}

	private BlockStatement CreateMethodBody(IEnumerable<ParameterDeclaration> parameters, out MethodDebugInfoBuilder builder)
	{
		if (methodDef.Body == null)
		{
			builder = null;
			return null;
		}
		context.CancellationToken.ThrowIfCancellationRequested();
		ILBlock iLBlock = new ILBlock(CodeBracesRangeFlags.MethodBraces);
		ILAstBuilder iLAstBuilder = context.Cache.GetILAstBuilder();
		MethodDef inlinedMethod = null;
		StateMachineKind stateMachineKind;
		AsyncMethodDebugInfo asyncInfo;
		string compilerName;
		HashSet<ILVariable> variables;
		try
		{
			iLBlock.Body = iLAstBuilder.Build(methodDef, optimize: true, context);
			context.CancellationToken.ThrowIfCancellationRequested();
			ILAstOptimizer iLAstOptimizer = context.Cache.GetILAstOptimizer();
			try
			{
				int num = context.variableMap?.Version ?? (-1);
				iLAstOptimizer.Optimize(context, iLBlock, autoPropertyProvider, out stateMachineKind, out inlinedMethod, out asyncInfo);
				if (context.variableMap != null && context.variableMap.Version == num)
				{
					YieldReturnDecompiler.TranslateFieldsToLocalAccess(iLBlock.Body, context.variableMap, null, context.CalculateILSpans, fixLocals: false);
				}
				compilerName = iLAstOptimizer.CompilerName;
			}
			finally
			{
				context.Cache.Return(iLAstOptimizer);
			}
			context.CancellationToken.ThrowIfCancellationRequested();
			variables = new HashSet<ILVariable>(GetVariables(iLBlock));
			NameVariables.AssignNamesToVariables(context, iLAstBuilder.Parameters, variables, iLBlock, stringBuilder);
			if (parameters != null)
			{
				foreach (var item in from p in parameters
					join v in iLAstBuilder.Parameters on p.Annotation<Parameter>() equals v.OriginalParameter
					select new { p, v })
				{
					item.p.NameToken = Identifier.Create(item.v.Name).WithAnnotation(GetParameterColor(item.v)).WithAnnotation(item.v);
				}
			}
		}
		finally
		{
			context.Cache.Return(iLAstBuilder);
		}
		context.CancellationToken.ThrowIfCancellationRequested();
		BlockStatement blockStatement = TransformBlock(iLBlock);
		CommentStatement.ReplaceAll(blockStatement);
		Statement existingItem = blockStatement.Statements.FirstOrDefault();
		foreach (ILVariable item2 in localVariablesToDefine)
		{
			if (!item2.Declared)
			{
				item2.Declared = true;
				AstType type = ((!item2.Type.ContainsAnonymousType()) ? AstBuilder.ConvertType(item2.Type, stringBuilder) : new SimpleType("var").WithAnnotation(BoxedTextColor.Keyword));
				bool flag = item2.Type.RemovePinnedAndModifiers().GetElementType() == ElementType.ByRef && AstBuilder.UndoByRefToPointer(type);
				VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement(GetParameterColor(item2), type, item2.Name);
				if (flag)
				{
					variableDeclarationStatement.Modifiers |= Modifiers.Ref;
				}
				variableDeclarationStatement.Variables.Single().AddAnnotation(item2);
				blockStatement.Statements.InsertBefore(existingItem, variableDeclarationStatement);
			}
		}
		builder = new MethodDebugInfoBuilder(context.SettingsVersion, stateMachineKind, inlinedMethod ?? methodDef, (inlinedMethod != null) ? methodDef : null, CreateSourceLocals(variables), CreateSourceParameters(variables), asyncInfo);
		builder.CompilerName = compilerName;
		return blockStatement;
	}

	private IEnumerable<ILVariable> GetVariables(ILBlock ilMethod)
	{
		foreach (ILNode item in ilMethod.GetSelfAndChildrenRecursive(ILNode_List))
		{
			if (item is ILExpression iLExpression)
			{
				if (iLExpression.Operand is ILVariable { IsParameter: false } iLVariable)
				{
					yield return iLVariable;
				}
			}
			else if (item is ILTryCatchBlock.CatchBlockBase { ExceptionVariable: not null } catchBlockBase)
			{
				yield return catchBlockBase.ExceptionVariable;
			}
		}
	}

	private SourceLocal[] CreateSourceLocals(HashSet<ILVariable> variables)
	{
		foreach (ILVariable variable in variables)
		{
			if (!variable.IsParameter)
			{
				sourceLocalsList.Add(variable.GetSourceLocal());
			}
		}
		SourceLocal[] result = sourceLocalsList.ToArray();
		sourceLocalsList.Clear();
		return result;
	}

	private SourceParameter[] CreateSourceParameters(HashSet<ILVariable> variables)
	{
		foreach (ILVariable variable in variables)
		{
			if (variable.IsParameter)
			{
				sourceParametersList.Add(variable.GetSourceParameter());
			}
		}
		SourceParameter[] result = sourceParametersList.ToArray();
		sourceParametersList.Clear();
		return result;
	}

	private Expression TransformBlockExpression(ILTryCatchBlock.FilterILBlock block)
	{
		if (block == null)
		{
			return null;
		}
		Expression expression = TryTransformBlockExpression(block);
		if (expression != null)
		{
			if (context.CalculateILSpans && block.StlocILSpans.Count != 0)
			{
				expression.AddAnnotation(block.StlocILSpans);
			}
			return expression;
		}
		BlockStatement blockStatement = TransformBlock(block);
		blockStatement.InsertChildAfter(null, new Comment(" Failed to create a 'catch-when' expression"), Roles.Comment);
		return new AnonymousMethodExpression
		{
			Body = blockStatement
		};
	}

	private Expression TryTransformBlockExpression(ILTryCatchBlock.FilterILBlock block)
	{
		List<ILNode> body = block.Body;
		if (body.Count != 1)
		{
			return null;
		}
		if (!(body[0] is ILExpression iLExpression))
		{
			return null;
		}
		if (context.CalculateILSpans)
		{
			iLExpression.ILSpans.AddRange(body[0].ILSpans);
		}
		return TransformExpression(iLExpression) as Expression;
	}

	private BlockStatement TransformBlock(ILBlock block)
	{
		BlockStatement blockStatement = new BlockStatement();
		if (block != null)
		{
			blockStatement.HiddenStart = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : ILSpan.OrderAndCompact(block.ILSpans), blockStatement.HiddenStart);
			blockStatement.HiddenEnd = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : ILSpan.OrderAndCompact(block.EndILSpans), blockStatement.HiddenEnd);
			foreach (ILNode child in block.GetChildren())
			{
				Statement statement = TransformNode(child);
				if (statement != null)
				{
					blockStatement.Statements.Add(statement);
				}
			}
		}
		return blockStatement;
	}

	private Statement TransformNode(ILNode node)
	{
		if (node is ILLabel)
		{
			LabelStatement labelStatement = new LabelStatement
			{
				Label = ((ILLabel)node).Name
			};
			if (context.CalculateILSpans)
			{
				labelStatement.AddAnnotation(node.ILSpans);
			}
			return labelStatement;
		}
		if (node is ILExpression)
		{
			AstNode astNode = TransformExpression((ILExpression)node);
			if (astNode != null)
			{
				if (astNode is Expression)
				{
					return new ExpressionStatement
					{
						Expression = (Expression)astNode
					};
				}
				if (astNode is Statement)
				{
					return (Statement)astNode;
				}
				throw new Exception();
			}
			return null;
		}
		if (node is ILWhileLoop)
		{
			ILWhileLoop iLWhileLoop = (ILWhileLoop)node;
			WhileStatement whileStatement = new WhileStatement();
			Expression expression = (whileStatement.Condition = ((iLWhileLoop.Condition != null) ? ((Expression)TransformExpression(iLWhileLoop.Condition)) : new PrimitiveExpression(true)));
			whileStatement.EmbeddedStatement = TransformBlock(iLWhileLoop.BodyBlock);
			WhileStatement result = whileStatement;
			if (context.CalculateILSpans)
			{
				expression.AddAnnotation(iLWhileLoop.ILSpans);
			}
			return result;
		}
		if (node is ILCondition)
		{
			ILCondition iLCondition = (ILCondition)node;
			bool flag = iLCondition.FalseBlock.EntryGoto != null || iLCondition.FalseBlock.Body.Count > 0;
			IfElseStatement obj = new IfElseStatement
			{
				Condition = (Expression)TransformExpression(iLCondition.Condition)
			};
			BlockStatement blockStatement = (BlockStatement)(obj.TrueStatement = TransformBlock(iLCondition.TrueBlock));
			obj.FalseStatement = (flag ? TransformBlock(iLCondition.FalseBlock) : null);
			IfElseStatement ifElseStatement = obj;
			if (context.CalculateILSpans)
			{
				ifElseStatement.Condition.AddAnnotation(iLCondition.ILSpans);
			}
			if (ifElseStatement.FalseStatement == null)
			{
				blockStatement.HiddenEnd = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : iLCondition.FalseBlock.GetSelfAndChildrenRecursiveILSpans_OrderAndJoin(), blockStatement.HiddenEnd);
			}
			return ifElseStatement;
		}
		if (node is ILSwitch)
		{
			ILSwitch ilSwitch = (ILSwitch)node;
			if (ilSwitch.Condition.InferredType.GetElementType() == ElementType.Boolean && (from cb in ilSwitch.CaseBlocks
				where cb.Values != null
				from val in cb.Values
				select val).Any((int val) => val != 0 && val != 1))
			{
				ilSwitch.Condition.ExpectedType = corLib.Int32;
			}
			SwitchStatement switchStatement = new SwitchStatement
			{
				Expression = (Expression)TransformExpression(ilSwitch.Condition)
			};
			if (context.CalculateILSpans)
			{
				switchStatement.Expression.AddAnnotation(ilSwitch.ILSpans);
			}
			switchStatement.HiddenEnd = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : ILSpan.OrderAndCompact(ilSwitch.EndILSpans), switchStatement.HiddenEnd);
			{
				foreach (ILSwitch.CaseBlock caseBlock in ilSwitch.CaseBlocks)
				{
					SwitchSection switchSection = new SwitchSection();
					if (caseBlock.Values != null)
					{
						switchSection.CaseLabels.AddRange(caseBlock.Values.Select((int i) => new CaseLabel
						{
							Expression = AstBuilder.MakePrimitive(i, (ilSwitch.Condition.ExpectedType ?? ilSwitch.Condition.InferredType).ToTypeDefOrRef(), stringBuilder)
						}));
					}
					else
					{
						switchSection.CaseLabels.Add(new CaseLabel());
					}
					switchSection.Statements.Add(TransformBlock(caseBlock));
					switchStatement.SwitchSections.Add(switchSection);
				}
				return switchStatement;
			}
		}
		if (node is ILTryCatchBlock)
		{
			ILTryCatchBlock iLTryCatchBlock = (ILTryCatchBlock)node;
			TryCatchStatement tryCatchStatement = new TryCatchStatement();
			tryCatchStatement.TryBlock = TransformBlock(iLTryCatchBlock.TryBlock);
			tryCatchStatement.TryBlock.HiddenStart = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : ILSpan.OrderAndCompact(iLTryCatchBlock.ILSpans), tryCatchStatement.TryBlock.HiddenStart);
			foreach (ILTryCatchBlock.CatchBlock catchBlock in iLTryCatchBlock.CatchBlocks)
			{
				if (catchBlock.ExceptionVariable == null && (catchBlock.ExceptionType == null || catchBlock.ExceptionType.GetElementType() == ElementType.Object))
				{
					tryCatchStatement.CatchClauses.Add(new CatchClause
					{
						Body = TransformBlock(catchBlock),
						Condition = TransformBlockExpression(catchBlock.FilterBlock)
					}.WithAnnotation((!context.CalculateILSpans) ? null : catchBlock.StlocILSpans));
				}
				else
				{
					tryCatchStatement.CatchClauses.Add(new CatchClause
					{
						Type = AstBuilder.ConvertType(catchBlock.ExceptionType, stringBuilder),
						VariableNameToken = ((catchBlock.ExceptionVariable == null) ? null : Identifier.Create(catchBlock.ExceptionVariable.Name).WithAnnotation(GetParameterColor(catchBlock.ExceptionVariable))),
						Body = TransformBlock(catchBlock),
						Condition = TransformBlockExpression(catchBlock.FilterBlock)
					}.WithAnnotation(catchBlock.ExceptionVariable).WithAnnotation((!context.CalculateILSpans) ? null : catchBlock.StlocILSpans));
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
				catchClause.InsertChildAfter(new Comment(" This is a fault block"), null, Roles.Comment);
				tryCatchStatement.CatchClauses.Add(catchClause);
			}
			return tryCatchStatement;
		}
		if (node is ILFixedStatement)
		{
			ILFixedStatement iLFixedStatement = (ILFixedStatement)node;
			FixedStatement fixedStatement = new FixedStatement();
			for (int num = 0; num < iLFixedStatement.Initializers.Count; num++)
			{
				ILExpression iLExpression = iLFixedStatement.Initializers[num];
				ILVariable iLVariable = (ILVariable)iLExpression.Operand;
				VariableInitializer variableInitializer;
				fixedStatement.Variables.Add(variableInitializer = new VariableInitializer
				{
					NameToken = Identifier.Create(iLVariable.Name).WithAnnotation(GetParameterColor(iLVariable)),
					Initializer = (Expression)TransformExpression(iLExpression.Arguments[0])
				}.WithAnnotation(iLVariable));
				if (context.CalculateILSpans)
				{
					variableInitializer.AddAnnotation(iLExpression.GetSelfAndChildrenRecursiveILSpans_OrderAndJoin());
					if (num == 0)
					{
						variableInitializer.AddAnnotation(ILSpan.OrderAndCompact(iLFixedStatement.ILSpans));
					}
				}
			}
			fixedStatement.Type = AstBuilder.ConvertType(((ILVariable)iLFixedStatement.Initializers[0].Operand).Type, stringBuilder);
			fixedStatement.EmbeddedStatement = TransformBlock(iLFixedStatement.BodyBlock);
			return fixedStatement;
		}
		if (node is ILBlock)
		{
			return TransformBlock((ILBlock)node);
		}
		throw new Exception("Unknown node type");
	}

	private AstNode TransformExpression(ILExpression expr)
	{
		List<ILSpan> annotation = ((!context.CalculateILSpans) ? null : expr.GetSelfAndChildrenRecursiveILSpans_OrderAndJoin());
		AstNode astNode = TransformByteCode(expr);
		AstNode astNode2 = ((!(astNode is Expression expr2)) ? astNode : Convert(expr2, expr.InferredType, expr.ExpectedType));
		if (astNode2 != null)
		{
			astNode2 = astNode2.WithAnnotation(new TypeInformation(expr.InferredType, expr.ExpectedType));
		}
		if (context.CalculateILSpans && astNode2 != null)
		{
			return astNode2.WithAnnotation(annotation);
		}
		return astNode2;
	}

	private IMDTokenProvider Create_SystemArray_get_Length()
	{
		if (Create_SystemArray_get_Length_result_initd)
		{
			return Create_SystemArray_get_Length_result;
		}
		Create_SystemArray_get_Length_result_initd = true;
		TypeRef typeRef = corLib.GetTypeRef("System", "Array");
		CorLibTypeSig @int = corLib.Int32;
		MemberRefUser memberRefUser = (MemberRefUser)(Create_SystemArray_get_Length_result = new MemberRefUser(this.methodDef.Module, "get_Length", MethodSig.CreateInstance(@int), typeRef));
		MethodDef methodDef = memberRefUser.ResolveMethod();
		if (methodDef == null || methodDef.DeclaringType == null)
		{
			return memberRefUser;
		}
		PropertyDef propertyDef = methodDef.DeclaringType.FindProperty("Length");
		if (propertyDef == null)
		{
			return memberRefUser;
		}
		Create_SystemArray_get_Length_result = propertyDef;
		return propertyDef;
	}

	private IMDTokenProvider Create_SystemType_get_TypeHandle()
	{
		if (Create_SystemType_get_TypeHandle_initd)
		{
			return Create_SystemType_get_TypeHandle_result;
		}
		Create_SystemType_get_TypeHandle_initd = true;
		TypeRef typeRef = corLib.GetTypeRef("System", "Type");
		ValueTypeSig retType = new ValueTypeSig(corLib.GetTypeRef("System", "RuntimeTypeHandle"));
		MemberRefUser memberRefUser = (MemberRefUser)(Create_SystemType_get_TypeHandle_result = new MemberRefUser(this.methodDef.Module, "get_TypeHandle", MethodSig.CreateInstance(retType), typeRef));
		MethodDef methodDef = memberRefUser.ResolveMethod();
		if (methodDef == null || methodDef.DeclaringType == null)
		{
			return memberRefUser;
		}
		PropertyDef propertyDef = methodDef.DeclaringType.FindProperty("TypeHandle");
		if (propertyDef == null)
		{
			return memberRefUser;
		}
		Create_SystemType_get_TypeHandle_result = propertyDef;
		return propertyDef;
	}

	private object GetParameterColor(ILVariable ilv)
	{
		if (valueParameterIsKeyword && ilv.OriginalParameter?.Name == "value" && methodDef.Parameters.Count > 0 && methodDef.Parameters[methodDef.Parameters.Count - 1] == ilv.OriginalParameter)
		{
			return BoxedTextColor.Keyword;
		}
		if (!ilv.IsParameter)
		{
			return BoxedTextColor.Local;
		}
		return BoxedTextColor.Parameter;
	}

	private AstNode TransformByteCode(ILExpression byteCode)
	{
		object operand = byteCode.Operand;
		AstType astType = AstBuilder.ConvertType(operand as ITypeDefOrRef, stringBuilder);
		List<Expression> list = new List<Expression>();
		foreach (ILExpression argument in byteCode.Arguments)
		{
			list.Add((Expression)TransformExpression(argument));
		}
		Expression expression = ((list.Count >= 1) ? list[0] : null);
		Expression expression2 = ((list.Count >= 2) ? list[1] : null);
		Expression expression3 = ((list.Count >= 3) ? list[2] : null);
		switch (byteCode.Code)
		{
		case ILCode.Add:
		case ILCode.Add_Ovf:
		case ILCode.Add_Ovf_Un:
		{
			BinaryOperatorExpression binaryOperatorExpression;
			if (byteCode.InferredType is PtrSig)
			{
				binaryOperatorExpression = new BinaryOperatorExpression(expression, BinaryOperatorType.Add, expression2);
				if (byteCode.Arguments[0].ExpectedType is PtrSig || byteCode.Arguments[1].ExpectedType is PtrSig)
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
			if (byteCode.InferredType is PtrSig)
			{
				binaryOperatorExpression2 = new BinaryOperatorExpression(expression, BinaryOperatorType.Subtract, expression2);
				if (byteCode.Arguments[0].ExpectedType is PtrSig)
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
		case ILCode.And:
			if (IsBooleanLocalOrParam(byteCode.Arguments[1]))
			{
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ConditionalAnd, expression2);
			}
			return new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseAnd, expression2);
		case ILCode.Or:
			if (IsBooleanLocalOrParam(byteCode.Arguments[1]))
			{
				return new BinaryOperatorExpression(expression, BinaryOperatorType.ConditionalOr, expression2);
			}
			return new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseOr, expression2);
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
			if (astType is ComposedType composedType3)
			{
				composedType3.ArraySpecifiers.MoveTo(arrayCreateExpression3.AdditionalArraySpecifiers);
			}
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
			if (astType is ComposedType composedType2)
			{
				composedType2.ArraySpecifiers.MoveTo(arrayCreateExpression2.AdditionalArraySpecifiers);
				arrayCreateExpression2.Initializer = new ArrayInitializerExpression();
			}
			if (((TypeSpec)operand).TypeSig.RemovePinnedAndModifiers() is ArraySigBase arraySigBase)
			{
				if (arraySigBase.IsSingleDimensional)
				{
					arrayCreateExpression2.Initializer.Elements.AddRange(list);
				}
				else
				{
					List<Expression> list2 = new List<Expression>();
					foreach (int item in arraySigBase.GetLengths().Skip(1).Reverse())
					{
						for (int k = 0; k < list.Count; k += item)
						{
							ArrayInitializerExpression arrayInitializerExpression3 = new ArrayInitializerExpression();
							arrayInitializerExpression3.Elements.AddRange(list.GetRange(k, item));
							list2.Add(arrayInitializerExpression3);
						}
						List<Expression> list3 = list;
						list = list2;
						list2 = list3;
						list2.Clear();
					}
					arrayCreateExpression2.Initializer.Elements.AddRange(list);
				}
			}
			return arrayCreateExpression2;
		}
		case ILCode.Ldlen:
			return expression.Member("Length", BoxedTextColor.InstanceProperty).WithAnnotation(Create_SystemArray_get_Length());
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
		case ILCode.Ldelem:
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
		case ILCode.Stelem:
			return new AssignmentExpression(expression.Indexer(expression2), expression3);
		case ILCode.CompoundAssignment:
		{
			CastExpression castExpression3 = expression as CastExpression;
			BinaryOperatorExpression binaryOperatorExpression3 = ((castExpression3 != null) ? ((BinaryOperatorExpression)castExpression3.Expression) : (expression as BinaryOperatorExpression));
			if (binaryOperatorExpression3 == null)
			{
				ParenthesizedExpression parenthesizedExpression = new ParenthesizedExpression(expression);
				ReplaceMethodCallsWithOperators.ProcessInvocationExpression((InvocationExpression)expression, stringBuilder);
				binaryOperatorExpression3 = (BinaryOperatorExpression)parenthesizedExpression.Expression;
			}
			AssignmentExpression assignmentExpression = new AssignmentExpression
			{
				Left = binaryOperatorExpression3.Left.Detach(),
				Operator = ReplaceMethodCallsWithOperators.GetAssignmentOperatorForBinaryOperator(binaryOperatorExpression3.Operator),
				Right = binaryOperatorExpression3.Right.Detach()
			}.CopyAnnotationsFrom(binaryOperatorExpression3);
			if (castExpression3 != null)
			{
				castExpression3.Expression = assignmentExpression;
				return castExpression3;
			}
			return assignmentExpression;
		}
		case ILCode.Cnull:
			return new BinaryOperatorExpression(UnpackDirectionExpression(expression), BinaryOperatorType.Equality, new NullReferenceExpression());
		case ILCode.Cnotnull:
			return new BinaryOperatorExpression(UnpackDirectionExpression(expression), BinaryOperatorType.InEquality, new NullReferenceExpression());
		case ILCode.Ceq:
			return new BinaryOperatorExpression(expression, BinaryOperatorType.Equality, expression2);
		case ILCode.Cne:
			return new BinaryOperatorExpression(expression, BinaryOperatorType.InEquality, expression2);
		case ILCode.Cgt:
			return new BinaryOperatorExpression(expression, BinaryOperatorType.GreaterThan, expression2);
		case ILCode.Cgt_Un:
		{
			TypeSig inferredType2 = byteCode.Arguments[0].InferredType;
			if ((inferredType2 != null && !DnlibExtensions.IsValueType(inferredType2)) || (inferredType2.IsSignedIntegralType() && expression2 is PrimitiveExpression primitiveExpression2 && primitiveExpression2.Value.IsZero()))
			{
				goto case ILCode.Cne;
			}
			goto case ILCode.Cgt;
		}
		case ILCode.Cle_Un:
		{
			TypeSig inferredType = byteCode.Arguments[0].InferredType;
			if ((inferredType != null && !DnlibExtensions.IsValueType(inferredType)) || (inferredType.IsSignedIntegralType() && expression2 is PrimitiveExpression primitiveExpression && primitiveExpression.Value.IsZero()))
			{
				goto case ILCode.Ceq;
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
			if (expression is CastExpression castExpression2)
			{
				castExpression2.AddAnnotation(AddCheckedBlocks.UncheckedAnnotation);
			}
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
			if (expression is CastExpression castExpression)
			{
				castExpression.AddAnnotation(AddCheckedBlocks.CheckedAnnotation);
			}
			return expression;
		case ILCode.Unbox_Any:
			if (expression is AsExpression && byteCode.Arguments[0].Code == ILCode.Isinst && TypeAnalysis.IsSameType(operand as ITypeDefOrRef, byteCode.Arguments[0].Operand as ITypeDefOrRef))
			{
				return expression;
			}
			goto case ILCode.Castclass;
		case ILCode.Castclass:
			if ((byteCode.Arguments[0].InferredType != null && byteCode.Arguments[0].InferredType.IsGenericParameter) || (operand as ITypeDefOrRef).TryGetGenericSig() != null)
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
		case ILCode.CallReadOnlySetter:
			return TransformCall(isVirtual: false, byteCode, list, MethodSemanticsAttributes.Setter);
		case ILCode.Callvirt:
		case ILCode.CallvirtGetter:
		case ILCode.CallvirtSetter:
			return TransformCall(isVirtual: true, byteCode, list);
		case ILCode.Ldftn:
		{
			IMethod method3 = (IMethod)operand;
			IdentifierExpression identifierExpression6 = IdentifierExpression.Create(method3.Name, method3);
			identifierExpression6.TypeArguments.AddRange(ConvertTypeArguments(method3));
			identifierExpression6.AddAnnotation(method3);
			return IdentifierExpression.Create("ldftn", BoxedTextColor.OpCode).Invoke(identifierExpression6).WithAnnotation(DelegateConstruction.Annotation.False);
		}
		case ILCode.Ldvirtftn:
		{
			IMethod method2 = (IMethod)operand;
			IdentifierExpression identifierExpression5 = IdentifierExpression.Create(method2.Name, method2);
			identifierExpression5.TypeArguments.AddRange(ConvertTypeArguments(method2));
			identifierExpression5.AddAnnotation(method2);
			return IdentifierExpression.Create("ldvirtftn", BoxedTextColor.OpCode).Invoke(identifierExpression5).WithAnnotation(DelegateConstruction.Annotation.True);
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
			return MakeDefaultValue((operand as ITypeDefOrRef).ToTypeSig());
		case ILCode.Jmp:
			return InlineAssembly(byteCode, list);
		case ILCode.Ldc_I4:
			return AstBuilder.MakePrimitive((int)operand, byteCode.InferredType.ToTypeDefOrRef(), stringBuilder);
		case ILCode.Ldc_I8:
			return AstBuilder.MakePrimitive((long)operand, byteCode.InferredType.ToTypeDefOrRef(), stringBuilder);
		case ILCode.Ldc_R4:
		case ILCode.Ldc_R8:
		case ILCode.Ldc_Decimal:
			return new PrimitiveExpression(operand);
		case ILCode.Ldfld:
			if (expression is DirectionExpression)
			{
				expression = ((DirectionExpression)expression).Expression.Detach();
			}
			return expression.Member(((IField)operand).Name, operand).WithAnnotation(operand);
		case ILCode.Ldsfld:
			return AstBuilder.ConvertType(((IField)operand).DeclaringType, stringBuilder).Member(((IField)operand).Name, operand).WithAnnotation(operand);
		case ILCode.Stfld:
			if (expression is DirectionExpression)
			{
				expression = ((DirectionExpression)expression).Expression.Detach();
			}
			return new AssignmentExpression(expression.Member(((IField)operand).Name, operand).WithAnnotation(operand), expression2);
		case ILCode.Stsfld:
			return new AssignmentExpression(AstBuilder.ConvertType(((IField)operand).DeclaringType, stringBuilder).Member(((IField)operand).Name, operand).WithAnnotation(operand), expression);
		case ILCode.Ldflda:
			if (expression is DirectionExpression)
			{
				expression = ((DirectionExpression)expression).Expression.Detach();
			}
			return MakeRef(expression.Member(((IField)operand).Name, operand).WithAnnotation(operand));
		case ILCode.Ldsflda:
			return MakeRef(AstBuilder.ConvertType(((IField)operand).DeclaringType, stringBuilder).Member(((IField)operand).Name, operand).WithAnnotation(operand));
		case ILCode.Ldloc:
		{
			ILVariable iLVariable3 = (ILVariable)operand;
			if (!iLVariable3.IsParameter)
			{
				localVariablesToDefine.Add((ILVariable)operand);
			}
			Expression expression5;
			if (iLVariable3.IsParameter && iLVariable3.OriginalParameter.IsHiddenThisParameter)
			{
				expression5 = new ThisReferenceExpression().WithAnnotation(this.methodDef.DeclaringType);
			}
			else
			{
				IdentifierExpression identifierExpression4 = IdentifierExpression.Create(((ILVariable)operand).Name, GetParameterColor((ILVariable)operand)).WithAnnotation(operand);
				identifierExpression4.IdentifierToken.AddAnnotation(operand);
				expression5 = identifierExpression4;
			}
			if (!(iLVariable3.Type.RemovePinnedAndModifiers() is ByRefSig))
			{
				return expression5;
			}
			return MakeRef(expression5);
		}
		case ILCode.Ldloca:
		{
			ILVariable iLVariable2 = (ILVariable)operand;
			if (iLVariable2.IsParameter && iLVariable2.OriginalParameter.IsHiddenThisParameter)
			{
				return MakeRef(new ThisReferenceExpression().WithAnnotation(this.methodDef.DeclaringType));
			}
			if (!iLVariable2.IsParameter)
			{
				localVariablesToDefine.Add((ILVariable)operand);
			}
			IdentifierExpression identifierExpression3 = IdentifierExpression.Create(((ILVariable)operand).Name, GetParameterColor((ILVariable)operand)).WithAnnotation(operand);
			identifierExpression3.IdentifierToken.AddAnnotation(operand);
			return MakeRef(identifierExpression3);
		}
		case ILCode.Ldnull:
			return new NullReferenceExpression();
		case ILCode.Ldstr:
			return new PrimitiveExpression(operand);
		case ILCode.Ldtoken:
		{
			if (operand is ITypeDefOrRef)
			{
				IMDTokenProvider annotation = Create_SystemType_get_TypeHandle();
				return AstBuilder.CreateTypeOfExpression((ITypeDefOrRef)operand, stringBuilder).Member("TypeHandle", BoxedTextColor.InstanceProperty).WithAnnotation(annotation);
			}
			string identifier;
			string memberName;
			Expression expression4;
			if (operand is IField && ((IField)operand).FieldSig != null)
			{
				identifier = "fieldof";
				memberName = "FieldHandle";
				IField field = (IField)operand;
				expression4 = AstBuilder.ConvertType(field.DeclaringType, stringBuilder).Member(field.Name, field).WithAnnotation(field);
			}
			else if (operand is IMethod)
			{
				identifier = "methodof";
				memberName = "MethodHandle";
				IMethod method = (IMethod)operand;
				IEnumerable<TypeReferenceExpression> arguments = from p in method.MethodSig.GetParameters()
					select new TypeReferenceExpression(AstBuilder.ConvertType(p, stringBuilder));
				expression4 = AstBuilder.ConvertType(method.DeclaringType, stringBuilder).Invoke(method, method.Name, arguments).WithAnnotation(method);
			}
			else
			{
				identifier = "ldtoken";
				memberName = "Handle";
				IdentifierExpression identifierExpression2 = IdentifierExpression.Create(FormatByteCodeOperand(byteCode.Operand), byteCode.Operand);
				identifierExpression2.IdentifierToken.AddAnnotation(IdentifierFormatted.Instance);
				expression4 = identifierExpression2;
			}
			return IdentifierExpression.Create(identifier, BoxedTextColor.Keyword).Invoke(expression4).WithAnnotation(new LdTokenAnnotation())
				.Member(memberName, BoxedTextColor.InstanceProperty);
		}
		case ILCode.Leave:
			return new GotoStatement
			{
				Label = ((ILLabel)operand).Name
			};
		case ILCode.Localloc:
		{
			TypeSig type = ((!(byteCode.InferredType is PtrSig ptrSig) || ptrSig.Next.GetElementType() == ElementType.Void) ? corLib.Byte : ptrSig.Next);
			return new StackAllocExpression
			{
				Type = AstBuilder.ConvertType(type, stringBuilder),
				CountExpression = expression
			};
		}
		case ILCode.Mkrefany:
			if (expression is DirectionExpression directionExpression)
			{
				return new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.MakeRef,
					Arguments = { directionExpression.Expression.Detach() }
				};
			}
			return InlineAssembly(byteCode, list);
		case ILCode.Refanytype:
			return new UndocumentedExpression
			{
				UndocumentedExpressionType = UndocumentedExpressionType.RefType,
				Arguments = { expression }
			}.Member("TypeHandle", BoxedTextColor.InstanceProperty).WithAnnotation(Create_SystemType_get_TypeHandle());
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
			ITypeDefOrRef declaringType = ((IMethod)operand).DeclaringType;
			if ((declaringType as TypeSpec)?.TypeSig.RemovePinnedAndModifiers() is ArraySigBase && AstBuilder.ConvertType(declaringType, stringBuilder) is ComposedType composedType && composedType.ArraySpecifiers.Count >= 1)
			{
				ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression();
				composedType.ArraySpecifiers.First().Remove();
				composedType.ArraySpecifiers.MoveTo(arrayCreateExpression.AdditionalArraySpecifiers);
				arrayCreateExpression.Type = composedType;
				arrayCreateExpression.Arguments.AddRange(list);
				return arrayCreateExpression;
			}
			if (declaringType.IsAnonymousType())
			{
				MethodDef methodDef = ((IMethod)operand).Resolve();
				if (methodDef != null)
				{
					AnonymousTypeCreateExpression anonymousTypeCreateExpression = new AnonymousTypeCreateExpression();
					if (CanInferAnonymousTypePropertyNamesFromArguments(list, methodDef.Parameters))
					{
						anonymousTypeCreateExpression.Initializers.AddRange(list);
					}
					else
					{
						int parametersSkip = methodDef.Parameters.GetParametersSkip();
						for (int j = 0; j < list.Count; j++)
						{
							anonymousTypeCreateExpression.Initializers.Add(new NamedExpression
							{
								NameToken = Identifier.Create(methodDef.Parameters[j + parametersSkip].Name).WithAnnotation(methodDef.Parameters[j + parametersSkip]),
								Expression = list[j]
							});
						}
					}
					return anonymousTypeCreateExpression;
				}
			}
			ObjectCreateExpression objectCreateExpression3 = new ObjectCreateExpression();
			objectCreateExpression3.Type = AstBuilder.ConvertType(declaringType, stringBuilder);
			objectCreateExpression3.Arguments.AddRange(list);
			return objectCreateExpression3.WithAnnotation(operand);
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
			if (this.methodDef.ReturnType.RemovePinnedAndModifiers().GetElementType() != ElementType.Void)
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
			IdentifierExpression identifierExpression = IdentifierExpression.Create(iLVariable.Name, GetParameterColor(iLVariable)).WithAnnotation(iLVariable);
			identifierExpression.IdentifierToken.AddAnnotation(iLVariable);
			return new AssignmentExpression(identifierExpression, expression);
		}
		case ILCode.Switch:
			return InlineAssembly(byteCode, list);
		case ILCode.Tailcall:
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
						NameToken = (Identifier)memberReferenceExpression.MemberNameToken.Clone(),
						Expression = match.Get<Expression>("right").Single().Detach()
					}.CopyAnnotationsFrom(memberReferenceExpression));
					continue;
				}
				match = collectionInitializerPattern.Match(list[i]);
				if (!match.Success)
				{
					match = staticCollectionInitializerPattern.Match(list[i]);
				}
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
			if (expression is ObjectCreateExpression objectCreateExpression)
			{
				objectCreateExpression.Initializer = arrayInitializerExpression;
				return objectCreateExpression;
			}
			if (expression is DefaultValueExpression defaultValueExpression)
			{
				ObjectCreateExpression objectCreateExpression2 = new ObjectCreateExpression(defaultValueExpression.Type.Detach());
				objectCreateExpression2.CopyAnnotationsFrom(defaultValueExpression);
				objectCreateExpression2.Initializer = arrayInitializerExpression;
				return objectCreateExpression2;
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
			list[list.Count - 1].AddAnnotation(new ParameterDeclarationAnnotation(byteCode, stringBuilder));
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

	private bool IsBooleanLocalOrParam(ILExpression expr)
	{
		if (expr.Code != ILCode.Ldloc)
		{
			return false;
		}
		if (expr.ExpectedType != null)
		{
			return expr.ExpectedType.GetElementType() == ElementType.Boolean;
		}
		ILVariable iLVariable = (ILVariable)expr.Operand;
		return (iLVariable.Type ?? iLVariable.OriginalParameter?.Type ?? iLVariable.OriginalVariable?.Type).GetElementType() == ElementType.Boolean;
	}

	internal static bool CanInferAnonymousTypePropertyNamesFromArguments(IList<Expression> args, IList<Parameter> parameters)
	{
		int parametersSkip = parameters.GetParametersSkip();
		for (int i = 0; i < args.Count; i++)
		{
			string text = ((args[i] is IdentifierExpression) ? ((IdentifierExpression)args[i]).Identifier : ((!(args[i] is MemberReferenceExpression)) ? null : ((MemberReferenceExpression)args[i]).MemberName));
			if (i + parametersSkip >= parameters.Count || text != parameters[i + parametersSkip].Name)
			{
				return false;
			}
		}
		return true;
	}

	private Expression MakeDefaultValue(TypeSig type)
	{
		TypeDef typeDef = dnSpy.Contracts.Decompiler.Extensions.Resolve(type);
		if (typeDef != null)
		{
			if (TypeAnalysis.IsIntegerOrEnum(type))
			{
				return AstBuilder.MakePrimitive(0L, typeDef, stringBuilder);
			}
			if (!DnlibExtensions.IsValueType(typeDef))
			{
				return new NullReferenceExpression();
			}
			switch (typeDef.FullName)
			{
			case "System.Nullable`1":
				return new NullReferenceExpression();
			case "System.Single":
				return new PrimitiveExpression(0f);
			case "System.Double":
				return new PrimitiveExpression(0.0);
			case "System.Decimal":
				return new PrimitiveExpression(0m);
			}
		}
		return new DefaultValueExpression
		{
			Type = AstBuilder.ConvertType(type, stringBuilder)
		};
	}

	private AstNode TransformCall(bool isVirtual, ILExpression byteCode, List<Expression> args, MethodSemanticsAttributes? forceSemAttr = null)
	{
		IMethod method = (IMethod)byteCode.Operand;
		MethodDef methodDef = method.Resolve();
		List<Expression> list = new List<Expression>(args);
		Expression target;
		if (method.MethodSig != null && method.MethodSig.HasThis)
		{
			target = list[0];
			list.RemoveAt(0);
			target = UnpackDirectionExpression(target);
			if (methodDef != null)
			{
				if (target is NullReferenceExpression)
				{
					target = target.CastTo(AstBuilder.ConvertType(method.DeclaringType, stringBuilder));
				}
				if (methodDef.DeclaringType.IsInterface)
				{
					TypeSig inferredType = byteCode.Arguments[0].InferredType;
					if (inferredType != null)
					{
						TypeDef typeDef = dnSpy.Contracts.Decompiler.Extensions.Resolve(inferredType);
						if (typeDef != null && !typeDef.IsInterface)
						{
							target = target.CastTo(AstBuilder.ConvertType(method.DeclaringType, stringBuilder));
						}
					}
				}
			}
		}
		else
		{
			target = new TypeReferenceExpression
			{
				Type = AstBuilder.ConvertType(method.DeclaringType, stringBuilder)
			};
		}
		if (target is ThisReferenceExpression && !isVirtual && method.DeclaringType != null && method.DeclaringType.ScopeType.ResolveTypeDef() != context.CurrentType)
		{
			target = new BaseReferenceExpression();
			target.AddAnnotation(method.DeclaringType);
		}
		if (method.Name == ".ctor" && DnlibExtensions.IsValueType(method.DeclaringType))
		{
			ObjectCreateExpression objectCreateExpression = new ObjectCreateExpression();
			objectCreateExpression.Type = AstBuilder.ConvertType(method.DeclaringType, stringBuilder);
			objectCreateExpression.AddAnnotation(method);
			AdjustArgumentsForMethodCall(method, list);
			objectCreateExpression.Arguments.AddRange(list);
			return new AssignmentExpression(target, objectCreateExpression);
		}
		if (method.Name == "Get" && (method.DeclaringType.TryGetArraySig() != null || method.DeclaringType.TryGetSZArraySig() != null) && list.Count > 1)
		{
			return target.Indexer(list);
		}
		if (method.Name == "Set" && (method.DeclaringType.TryGetArraySig() != null || method.DeclaringType.TryGetSZArraySig() != null) && list.Count > 2)
		{
			return new AssignmentExpression(target.Indexer(list.GetRange(0, list.Count - 1)), list.Last());
		}
		MethodSemanticsAttributes methodSemanticsAttributes = forceSemAttr ?? methodDef?.SemanticsAttributes ?? GetMethodSemanticsAttributes(method);
		if (methodSemanticsAttributes != MethodSemanticsAttributes.None)
		{
			if (list.Count == 0 && (methodSemanticsAttributes & MethodSemanticsAttributes.Getter) != MethodSemanticsAttributes.None)
			{
				if (methodDef == null)
				{
					return target.Member(method.Name.Substring(4), method).WithAnnotation(method);
				}
				foreach (PropertyDef property in methodDef.DeclaringType.Properties)
				{
					if (property.GetMethod == methodDef)
					{
						return target.Member(property.Name, property).WithAnnotation(property).WithAnnotation(method);
					}
				}
			}
			else if ((methodSemanticsAttributes & MethodSemanticsAttributes.Getter) != MethodSemanticsAttributes.None)
			{
				if (methodDef == null && method.Name == "get_Item")
				{
					return target.Indexer(list).WithAnnotation(method);
				}
				PropertyDef indexer = GetIndexer(methodDef);
				if (indexer != null)
				{
					return target.Indexer(list).WithAnnotation(indexer).WithAnnotation(method);
				}
			}
			else if (list.Count == 1 && (methodSemanticsAttributes & MethodSemanticsAttributes.Setter) != MethodSemanticsAttributes.None)
			{
				if (methodDef == null)
				{
					return new AssignmentExpression(target.Member(method.Name.Substring(4), method).WithAnnotation(method), list[0]);
				}
				if (forceSemAttr.HasValue)
				{
					foreach (PropertyDef property2 in methodDef.DeclaringType.Properties)
					{
						if (property2.GetMethod == methodDef)
						{
							return new AssignmentExpression(target.Member(property2.Name, property2).WithAnnotation(property2).WithAnnotation(method), list[0]);
						}
					}
				}
				else
				{
					foreach (PropertyDef property3 in methodDef.DeclaringType.Properties)
					{
						if (property3.SetMethod == methodDef)
						{
							return new AssignmentExpression(target.Member(property3.Name, property3).WithAnnotation(property3).WithAnnotation(method), list[0]);
						}
					}
				}
			}
			else if (list.Count > 1 && (methodSemanticsAttributes & MethodSemanticsAttributes.Setter) != MethodSemanticsAttributes.None)
			{
				PropertyDef indexer2 = GetIndexer(methodDef);
				if (indexer2 != null || (methodDef == null && method.Name == "set_Item"))
				{
					return new AssignmentExpression(target.Indexer(list.GetRange(0, list.Count - 1)).WithAnnotation(indexer2).WithAnnotation(method), list[list.Count - 1]);
				}
			}
			else if (list.Count == 1 && (methodSemanticsAttributes & MethodSemanticsAttributes.AddOn) != MethodSemanticsAttributes.None)
			{
				if (methodDef == null)
				{
					return new AssignmentExpression
					{
						Left = target.Member(method.Name.Substring(4), method).WithAnnotation(method),
						Operator = AssignmentOperatorType.Add,
						Right = list[0]
					};
				}
				foreach (EventDef @event in methodDef.DeclaringType.Events)
				{
					if (@event.AddMethod == methodDef)
					{
						return new AssignmentExpression
						{
							Left = target.Member(@event.Name, @event).WithAnnotation(@event).WithAnnotation(method),
							Operator = AssignmentOperatorType.Add,
							Right = list[0]
						};
					}
				}
			}
			else if (list.Count == 1 && (methodSemanticsAttributes & MethodSemanticsAttributes.RemoveOn) != MethodSemanticsAttributes.None)
			{
				if (methodDef == null)
				{
					return new AssignmentExpression
					{
						Left = target.Member(method.Name.Substring(7), method).WithAnnotation(method),
						Operator = AssignmentOperatorType.Subtract,
						Right = list[0]
					};
				}
				foreach (EventDef event2 in methodDef.DeclaringType.Events)
				{
					if (event2.RemoveMethod == methodDef)
					{
						return new AssignmentExpression
						{
							Left = target.Member(event2.Name, event2).WithAnnotation(event2).WithAnnotation(method),
							Operator = AssignmentOperatorType.Subtract,
							Right = list[0]
						};
					}
				}
			}
		}
		else if (methodDef != null && methodDef.Name == nameInvoke && methodDef.DeclaringType.BaseType != null && methodDef.DeclaringType.BaseType.FullName == "System.MulticastDelegate")
		{
			AdjustArgumentsForMethodCall(method, list);
			return target.Invoke(list).WithAnnotation(method);
		}
		IMethod method2 = methodDef;
		AdjustArgumentsForMethodCall(method2 ?? method, list);
		Expression expression = target;
		method2 = methodDef;
		return expression.Invoke(method2 ?? method, method.Name, ConvertTypeArguments(method), list).WithAnnotation(method);
	}

	private static MethodSemanticsAttributes GetMethodSemanticsAttributes(IMethod method)
	{
		if (method == null)
		{
			return MethodSemanticsAttributes.None;
		}
		string text = method.Name;
		if (text.StartsWith("get_"))
		{
			return MethodSemanticsAttributes.Getter;
		}
		if (text.StartsWith("set_"))
		{
			return MethodSemanticsAttributes.Setter;
		}
		if (text.StartsWith("add_"))
		{
			return MethodSemanticsAttributes.AddOn;
		}
		if (text.StartsWith("remove_"))
		{
			return MethodSemanticsAttributes.RemoveOn;
		}
		return MethodSemanticsAttributes.None;
	}

	private Expression UnpackDirectionExpression(Expression target)
	{
		if (target is DirectionExpression)
		{
			Expression expression = ((DirectionExpression)target).Expression.Detach();
			if (context.CalculateILSpans)
			{
				target.AddAllRecursiveILSpansTo(expression);
			}
			return expression;
		}
		return target;
	}

	private static void AdjustArgumentsForMethodCall(IMethod method, List<Expression> methodArgs)
	{
		MethodDef methodDef = method.Resolve();
		if (methodDef == null)
		{
			return;
		}
		int parametersSkip = methodDef.Parameters.GetParametersSkip();
		for (int i = 0; i < methodArgs.Count && i < methodDef.Parameters.Count - parametersSkip; i++)
		{
			DirectionExpression directionExpression = methodArgs[i] as DirectionExpression;
			Parameter parameter = methodDef.Parameters[i + parametersSkip];
			if (directionExpression != null && parameter.HasParamDef)
			{
				if (parameter.ParamDef.IsOut && !parameter.ParamDef.IsIn)
				{
					directionExpression.FieldDirection = FieldDirection.Out;
				}
				else if (DnlibExtensions.HasIsReadOnlyAttribute(parameter.ParamDef))
				{
					directionExpression.FieldDirection = FieldDirection.In;
				}
			}
		}
	}

	internal static PropertyDef GetIndexer(MethodDef method)
	{
		if (method == null)
		{
			return null;
		}
		TypeDef declaringType = method.DeclaringType;
		UTF8String uTF8String = null;
		foreach (CustomAttribute customAttribute in declaringType.CustomAttributes)
		{
			if (customAttribute.ConstructorArguments.Count != 1)
			{
				continue;
			}
			ICustomAttributeType constructor = customAttribute.Constructor;
			if (constructor == null)
			{
				continue;
			}
			MethodSig methodSig = constructor.MethodSig;
			if (methodSig == null || methodSig.Params.Count != 1 || methodSig.Params[0].GetElementType() != ElementType.String)
			{
				continue;
			}
			ITypeDefOrRef declaringType2 = constructor.DeclaringType;
			if (declaringType2.Compare(systemReflectionString, defaultMemberAttributeString))
			{
				uTF8String = customAttribute.ConstructorArguments[0].Value as UTF8String;
				if (!UTF8String.IsNull(uTF8String))
				{
					break;
				}
			}
		}
		if (UTF8String.IsNull(uTF8String))
		{
			return null;
		}
		foreach (PropertyDef property in declaringType.Properties)
		{
			if (property.Name == uTF8String && (property.GetMethod == method || property.SetMethod == method))
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
			IdentifierExpression identifierExpression = IdentifierExpression.Create(FormatByteCodeOperand(byteCode.Operand), byteCode.Operand);
			identifierExpression.IdentifierToken.AddAnnotation(IdentifierFormatted.Instance);
			args.Insert(0, identifierExpression);
		}
		return IdentifierExpression.Create(byteCode.Code.GetName(), BoxedTextColor.OpCode).Invoke(args);
	}

	private static string FormatByteCodeOperand(object operand)
	{
		if (operand == null)
		{
			return string.Empty;
		}
		if (operand is IMethod && ((IMethod)operand).MethodSig != null)
		{
			return IdentifierEscaper.Escape(((IMethod)operand).Name) + "()";
		}
		if (operand is ITypeDefOrRef)
		{
			return IdentifierEscaper.Escape(((ITypeDefOrRef)operand).FullName);
		}
		if (operand is Local)
		{
			return IdentifierEscaper.Escape(((Local)operand).Name);
		}
		if (operand is Parameter)
		{
			return IdentifierEscaper.Escape(((Parameter)operand).Name);
		}
		if (operand is IField)
		{
			return IdentifierEscaper.Escape(((IField)operand).Name);
		}
		if (operand is string)
		{
			return "\"" + Escape((string)operand) + "\"";
		}
		if (operand is int)
		{
			return operand.ToString();
		}
		if (operand is MethodSig)
		{
			MethodSig methodSig = (MethodSig)operand;
			return Escape(DnlibExtensions.GetMethodSigFullName(methodSig));
		}
		return Escape(operand.ToString());
	}

	private static string Escape(string s)
	{
		if (s.IndexOfAny(newLineChars) < 0)
		{
			return s;
		}
		s = s.Replace("\r", "\\u000D");
		s = s.Replace("\n", "\\u000A");
		s = s.Replace("\u0085", "\\u0085");
		s = s.Replace("\u2028", "\\u2028");
		s = s.Replace("\u2029", "\\u2029");
		return s;
	}

	private IEnumerable<AstType> ConvertTypeArguments(IMethod method)
	{
		if (!(method is MethodSpec { GenericInstMethodSig: not null } methodSpec))
		{
			return null;
		}
		if (methodSpec.GenericInstMethodSig.GenericArguments.Any((TypeSig ta) => ta.ContainsAnonymousType()))
		{
			return null;
		}
		return methodSpec.GenericInstMethodSig.GenericArguments.Select((TypeSig t) => AstBuilder.ConvertType(t, stringBuilder));
	}

	private static DirectionExpression MakeRef(Expression expr)
	{
		return new DirectionExpression
		{
			Expression = expr,
			FieldDirection = FieldDirection.Ref
		};
	}

	private Expression Convert(Expression expr, TypeSig actualType, TypeSig reqType)
	{
		if (actualType == null || reqType == null || TypeAnalysis.IsSameType(actualType, reqType))
		{
			return expr;
		}
		if (actualType is ByRefSig && reqType is PtrSig && expr is DirectionExpression)
		{
			return Convert(new UnaryOperatorExpression(UnaryOperatorType.AddressOf, ((DirectionExpression)expr).Expression.Detach()), new PtrSig(((ByRefSig)actualType).Next), reqType);
		}
		if (actualType is PtrSig && reqType is ByRefSig)
		{
			expr = Convert(expr, actualType, new PtrSig(reqType.Next));
			return new DirectionExpression
			{
				FieldDirection = FieldDirection.Ref,
				Expression = new UnaryOperatorExpression(UnaryOperatorType.Dereference, expr)
			};
		}
		if (actualType is PtrSig && reqType is PtrSig)
		{
			if (actualType.FullName != reqType.FullName)
			{
				return expr.CastTo(AstBuilder.ConvertType(reqType, stringBuilder));
			}
			return expr;
		}
		if (reqType.GetElementType() == ElementType.Boolean)
		{
			if (actualType.GetElementType() == ElementType.Boolean)
			{
				return expr;
			}
			if (TypeAnalysis.IsIntegerOrEnum(actualType))
			{
				return new BinaryOperatorExpression(expr, BinaryOperatorType.InEquality, AstBuilder.MakePrimitive(0L, actualType.ToTypeDefOrRef(), stringBuilder));
			}
			return new BinaryOperatorExpression(expr, BinaryOperatorType.InEquality, new NullReferenceExpression());
		}
		bool flag = TypeAnalysis.IsIntegerOrEnum(reqType);
		if ((actualType.GetElementType() == ElementType.Boolean) & flag)
		{
			return new ConditionalExpression
			{
				Condition = expr,
				TrueExpression = AstBuilder.MakePrimitive(1L, reqType.ToTypeDefOrRef(), stringBuilder),
				FalseExpression = AstBuilder.MakePrimitive(0L, reqType.ToTypeDefOrRef(), stringBuilder)
			};
		}
		if (expr is PrimitiveExpression && !flag && TypeAnalysis.IsEnum(actualType))
		{
			return expr.CastTo(AstBuilder.ConvertType(actualType, stringBuilder));
		}
		bool flag2 = TypeAnalysis.IsIntegerOrEnum(actualType) || actualType.GetElementType() == ElementType.R4 || actualType.GetElementType() == ElementType.R8;
		bool flag3 = flag || reqType.GetElementType() == ElementType.R4 || reqType.GetElementType() == ElementType.R8;
		if (flag2 & flag3)
		{
			return expr.CastTo(AstBuilder.ConvertType(reqType, stringBuilder));
		}
		return expr;
	}
}
