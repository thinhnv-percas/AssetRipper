#define STEP
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class TransformExpressionTrees : IStatementTransform
{
	private StatementTransformContext context;

	private Dictionary<ILVariable, (IType, string)> parameters;

	private Dictionary<ILVariable, ILVariable> parameterMapping;

	private List<ILInstruction> instructionsToRemove;

	private Stack<ILFunction> lambdaStack;

	private CSharpConversions conversions;

	private CSharpResolver resolver;

	private static bool MightBeExpressionTree(ILInstruction inst, ILInstruction stmt)
	{
		if (!(inst is CallInstruction callInstruction) || !callInstruction.Method.FullNameIs("System.Linq.Expressions.Expression", "Lambda") || callInstruction.Arguments.Count != 2)
		{
			return false;
		}
		if (!IsEmptyParameterList(callInstruction.Arguments[1]) && !(callInstruction.Arguments[1] is Block { Kind: BlockKind.ArrayInitializer }))
		{
			return false;
		}
		return true;
	}

	private static bool IsEmptyParameterList(ILInstruction inst)
	{
		if (inst is CallInstruction callInstruction && callInstruction.Method.FullNameIs("System.Array", "Empty") && callInstruction.Arguments.Count == 0)
		{
			return true;
		}
		if (inst.MatchNewArr(out var type) && type.FullName == "System.Linq.Expressions.ParameterExpression")
		{
			return true;
		}
		if (inst.MatchNewArr(out type) && type.FullName == "System.Linq.Expressions.Expression")
		{
			return true;
		}
		return false;
	}

	private bool MatchParameterVariableAssignment(ILInstruction expr, out ILVariable parameterReferenceVar, out IType type, out string name)
	{
		type = null;
		name = null;
		if (!expr.MatchStLoc(out parameterReferenceVar, out var value))
		{
			return false;
		}
		if (!parameterReferenceVar.IsSingleDefinition)
		{
			return false;
		}
		if (parameterReferenceVar.Kind != VariableKind.Local && parameterReferenceVar.Kind != VariableKind.StackSlot)
		{
			return false;
		}
		if (parameterReferenceVar.Type == null || parameterReferenceVar.Type.FullName != "System.Linq.Expressions.ParameterExpression")
		{
			return false;
		}
		if (!(value is CallInstruction callInstruction) || callInstruction.Arguments.Count != 2)
		{
			return false;
		}
		if (!callInstruction.Method.FullNameIs("System.Linq.Expressions.Expression", "Parameter"))
		{
			return false;
		}
		if (!(callInstruction.Arguments[0] is CallInstruction callInstruction2) || callInstruction2.Arguments.Count != 1)
		{
			return false;
		}
		if (!callInstruction2.Method.FullNameIs("System.Type", "GetTypeFromHandle"))
		{
			return false;
		}
		return callInstruction2.Arguments[0].MatchLdTypeToken(out type) && callInstruction.Arguments[1].MatchLdStr(out name);
	}

	public void Run(Block block, int pos, StatementTransformContext context)
	{
		if (!context.Settings.ExpressionTrees)
		{
			return;
		}
		this.context = context;
		conversions = CSharpConversions.Get(context.TypeSystem);
		resolver = new CSharpResolver(context.TypeSystem);
		parameters = new Dictionary<ILVariable, (IType, string)>();
		parameterMapping = new Dictionary<ILVariable, ILVariable>();
		instructionsToRemove = new List<ILInstruction>();
		lambdaStack = new Stack<ILFunction>();
		for (int i = pos; i < block.Instructions.Count; i = checked(i + 1))
		{
			if (MatchParameterVariableAssignment(block.Instructions[i], out var parameterReferenceVar, out var type, out var name))
			{
				parameters.Add(parameterReferenceVar, (type, name));
				continue;
			}
			if (!TryConvertExpressionTree(block.Instructions[i], block.Instructions[i]))
			{
				break;
			}
			foreach (ILInstruction item in instructionsToRemove)
			{
				block.Instructions.Remove(item);
			}
			instructionsToRemove.Clear();
			break;
		}
	}

	private bool TryConvertExpressionTree(ILInstruction instruction, ILInstruction statement)
	{
		if (MightBeExpressionTree(instruction, statement))
		{
			var (iLInstruction, type) = ConvertLambda((CallInstruction)instruction);
			if (iLInstruction != null)
			{
				SetExpressionTreeFlag((ILFunction)iLInstruction, (CallInstruction)instruction);
				context.Step("Convert Expression Tree", instruction);
				instruction.ReplaceWith(iLInstruction);
				return true;
			}
			return false;
		}
		if (instruction is Block { Kind: BlockKind.ControlFlow })
		{
			return false;
		}
		foreach (ILInstruction child in instruction.Children)
		{
			if (TryConvertExpressionTree(child, statement))
			{
				return true;
			}
		}
		return false;
	}

	private (ILInstruction, IType) ConvertLambda(CallInstruction instruction)
	{
		if (instruction.Method.Name != "Lambda" || instruction.Arguments.Count != 2 || instruction.Method.ReturnType.FullName != "System.Linq.Expressions.Expression" || instruction.Method.ReturnType.TypeArguments.Count != 1)
		{
			return (null, SpecialType.UnknownType);
		}
		List<IParameter> list = new List<IParameter>();
		List<ILVariable> list2 = new List<ILVariable>();
		if (!ReadParameters(instruction.Arguments[1], list, list2, new SimpleTypeResolveContext(context.Function.Method)))
		{
			return (null, SpecialType.UnknownType);
		}
		BlockContainer blockContainer = new BlockContainer();
		blockContainer.AddILRange(instruction);
		IType type = instruction.Method.ReturnType.TypeArguments[0];
		IType returnType = type.GetDelegateInvokeMethod()?.ReturnType;
		ILFunction iLFunction = new ILFunction(returnType, list, context.Function.GenericContext, blockContainer);
		iLFunction.DelegateType = type;
		iLFunction.Variables.AddRange(list2);
		iLFunction.AddILRange(instruction);
		lambdaStack.Push(iLFunction);
		var (iLInstruction, type2) = ConvertInstruction(instruction.Arguments[0]);
		lambdaStack.Pop();
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		blockContainer.ExpectedResultType = iLInstruction.ResultType;
		blockContainer.Blocks.Add(new Block
		{
			Instructions = { (ILInstruction)new Leave(blockContainer, iLInstruction) }
		});
		foreach (KeyValuePair<ILVariable, ILVariable> item in parameterMapping)
		{
			LdLoc[] array = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)item.Key.LoadInstructions);
			foreach (LdLoc ldLoc in array)
			{
				if (!ldLoc.IsDescendantOf(instruction))
				{
					ldLoc.ReplaceWith(new LdLoc(item.Value));
				}
			}
		}
		return (iLFunction, iLFunction.DelegateType);
	}

	private (ILInstruction, IType) ConvertQuote(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 1)
		{
			return (null, SpecialType.UnknownType);
		}
		ILInstruction iLInstruction = Enumerable.Single<ILInstruction>((IEnumerable<ILInstruction>)invocation.Arguments);
		if (iLInstruction is ILFunction iLFunction)
		{
			return (iLFunction, iLFunction.DelegateType);
		}
		(ILInstruction, IType) result = ConvertInstruction(iLInstruction);
		if (result.Item1 is ILFunction lambda && iLInstruction is CallInstruction call)
		{
			SetExpressionTreeFlag(lambda, call);
		}
		return result;
	}

	private void SetExpressionTreeFlag(ILFunction lambda, CallInstruction call)
	{
		lambda.DelegateType = call.Method.ReturnType;
	}

	private bool ReadParameters(ILInstruction initializer, IList<IParameter> parameters, IList<ILVariable> parameterVariables, ITypeResolveContext resolveContext)
	{
		if (initializer != null && initializer is Block block)
		{
			Block block2 = block;
			if (block2.Kind != BlockKind.ArrayInitializer)
			{
				return false;
			}
			int num = 0;
			foreach (StObj item in Enumerable.OfType<StObj>((IEnumerable)block2.Instructions))
			{
				if (num >= this.parameters.Count)
				{
					return false;
				}
				if (!item.Value.MatchLdLoc(out var variable))
				{
					return false;
				}
				if (!this.parameters.TryGetValue(variable, out var value))
				{
					return false;
				}
				if (parameterMapping.ContainsKey(variable))
				{
					return false;
				}
				ILVariable iLVariable = new ILVariable(VariableKind.Parameter, value.Item1, num)
				{
					Name = value.Item2
				};
				parameterMapping.Add(variable, iLVariable);
				parameterVariables.Add(iLVariable);
				parameters.Add(new DefaultParameter(value.Item1, value.Item2));
				instructionsToRemove.Add((ILInstruction)variable.StoreInstructions[0]);
				num = checked(num + 1);
			}
			return true;
		}
		return IsEmptyParameterList(initializer);
	}

	private (ILInstruction, IType) ConvertInstruction(ILInstruction instruction, IType typeHint = null)
	{
		(ILInstruction, IType) result = Convert();
		if (result.Item1 != null)
		{
			Debug.Assert(result.Item2 != null, "IType must be non-null!");
			Debug.Assert(result.Item1.ResultType == result.Item2.GetStackType(), "StackTypes must match!");
		}
		return result;
		(ILInstruction, IType) Convert()
		{
			ILInstruction iLInstruction = instruction;
			ILInstruction iLInstruction2 = iLInstruction;
			if (iLInstruction2 != null)
			{
				if (iLInstruction2 is CallInstruction callInstruction)
				{
					CallInstruction callInstruction2 = callInstruction;
					if (!(callInstruction2.Method.DeclaringType.FullName != "System.Linq.Expressions.Expression"))
					{
						switch (callInstruction2.Method.Name)
						{
						case "Add":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Add, false);
						case "AddChecked":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Add, true);
						case "And":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.BitAnd);
						case "AndAlso":
							return ConvertLogicOperator(callInstruction2, and: true);
						case "ArrayAccess":
						case "ArrayIndex":
							return ConvertArrayIndex(callInstruction2);
						case "ArrayLength":
							return ConvertArrayLength(callInstruction2);
						case "Call":
							return ConvertCall(callInstruction2);
						case "Coalesce":
							return ConvertCoalesce(callInstruction2);
						case "Condition":
							return ConvertCondition(callInstruction2);
						case "Constant":
							return ConvertConstant(callInstruction2);
						case "Convert":
							return ConvertCast(callInstruction2, isChecked: false);
						case "ConvertChecked":
							return ConvertCast(callInstruction2, isChecked: true);
						case "Divide":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Div);
						case "Equal":
							return ConvertComparison(callInstruction2, ComparisonKind.Equality);
						case "ExclusiveOr":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.BitXor);
						case "Field":
							return ConvertField(callInstruction2, typeHint);
						case "GreaterThan":
							return ConvertComparison(callInstruction2, ComparisonKind.GreaterThan);
						case "GreaterThanOrEqual":
							return ConvertComparison(callInstruction2, ComparisonKind.GreaterThanOrEqual);
						case "Invoke":
							return ConvertInvoke(callInstruction2);
						case "Lambda":
							return ConvertLambda(callInstruction2);
						case "LeftShift":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.ShiftLeft);
						case "LessThan":
							return ConvertComparison(callInstruction2, ComparisonKind.LessThan);
						case "LessThanOrEqual":
							return ConvertComparison(callInstruction2, ComparisonKind.LessThanOrEqual);
						case "ListInit":
							return ConvertListInit(callInstruction2);
						case "MemberInit":
							return ConvertMemberInit(callInstruction2);
						case "Modulo":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Rem);
						case "Multiply":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Mul, false);
						case "MultiplyChecked":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Mul, true);
						case "Negate":
							return ConvertUnaryNumericOperator(callInstruction2, BinaryNumericOperator.Sub, false);
						case "NegateChecked":
							return ConvertUnaryNumericOperator(callInstruction2, BinaryNumericOperator.Sub, true);
						case "New":
							return ConvertNewObject(callInstruction2);
						case "NewArrayBounds":
							return ConvertNewArrayBounds(callInstruction2);
						case "NewArrayInit":
							return ConvertNewArrayInit(callInstruction2);
						case "Not":
							return ConvertNotOperator(callInstruction2);
						case "NotEqual":
							return ConvertComparison(callInstruction2, ComparisonKind.Inequality);
						case "OnesComplement":
							return ConvertNotOperator(callInstruction2);
						case "Or":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.BitOr);
						case "OrElse":
							return ConvertLogicOperator(callInstruction2, and: false);
						case "Property":
							return ConvertProperty(callInstruction2);
						case "Quote":
							return ConvertQuote(callInstruction2);
						case "RightShift":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.ShiftRight);
						case "Subtract":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Sub, false);
						case "SubtractChecked":
							return ConvertBinaryNumericOperator(callInstruction2, BinaryNumericOperator.Sub, true);
						case "TypeAs":
							return ConvertTypeAs(callInstruction2);
						case "TypeIs":
							return ConvertTypeIs(callInstruction2);
						default:
							return (null, SpecialType.UnknownType);
						}
					}
					return (null, SpecialType.UnknownType);
				}
				if (iLInstruction2 is ILFunction iLFunction)
				{
					ILFunction iLFunction2 = iLFunction;
					if (iLFunction2.IsExpressionTree)
					{
						iLFunction2.DelegateType = UnwrapExpressionTree(iLFunction2.DelegateType);
					}
					return (iLFunction2, iLFunction2.DelegateType);
				}
				if (iLInstruction2 is LdLoc ldLoc)
				{
					LdLoc ldLoc2 = ldLoc;
					if (IsExpressionTreeParameter(ldLoc2.Variable))
					{
						if (parameterMapping.TryGetValue(ldLoc2.Variable, out var value))
						{
							if (typeHint.SkipModifiers() is ByReferenceType && !value.Type.IsByRefLike)
							{
								return (new LdLoca(value), typeHint);
							}
							return (new LdLoc(value), value.Type);
						}
						if (ldLoc2.Variable.IsSingleDefinition && ldLoc2.Variable.StoreInstructions[0] is ILInstruction expr && MatchParameterVariableAssignment(expr, out var _, out var type, out var _))
						{
							return (ldLoc2, type);
						}
					}
					return (null, SpecialType.UnknownType);
				}
			}
			return (null, SpecialType.UnknownType);
		}
	}

	private IType UnwrapExpressionTree(IType delegateType)
	{
		if (delegateType is ParameterizedType { FullName: "System.Linq.Expressions.Expression" } parameterizedType && parameterizedType.TypeArguments.Count == 1)
		{
			return parameterizedType.TypeArguments[0];
		}
		return delegateType;
	}

	private (ILInstruction, IType) ConvertArrayIndex(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!(type is ArrayType arrayType))
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchArgumentList(invocation.Arguments[1], out var arguments))
		{
			arguments = new ILInstruction[1] { invocation.Arguments[1] };
		}
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			var (iLInstruction2, type2) = ConvertInstruction(arguments[i]);
			if (iLInstruction2 == null)
			{
				return (null, SpecialType.UnknownType);
			}
			arguments[i] = iLInstruction2;
		}
		return (new LdObj(new LdElema(arrayType.ElementType, iLInstruction, Enumerable.ToArray<ILInstruction>((IEnumerable<ILInstruction>)arguments)), arrayType.ElementType), arrayType.ElementType);
	}

	private (ILInstruction, IType) ConvertArrayLength(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 1)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		return (new LdLen(StackType.I4, iLInstruction), context.TypeSystem.FindType(KnownTypeCode.Int32));
	}

	private (ILInstruction, IType) ConvertBinaryNumericOperator(CallInstruction invocation, BinaryNumericOperator op, bool? isChecked = null)
	{
		if (invocation.Arguments.Count < 2)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction2, type2) = ConvertInstruction(invocation.Arguments[1]);
		if (iLInstruction2 == null)
		{
			return (null, SpecialType.UnknownType);
		}
		IMember member;
		switch (invocation.Arguments.Count)
		{
		case 2:
			if (op == BinaryNumericOperator.ShiftLeft || op == BinaryNumericOperator.ShiftRight)
			{
				if (!type2.IsKnownType(KnownTypeCode.Int32))
				{
					return (null, SpecialType.UnknownType);
				}
			}
			else if (!type2.Equals(type))
			{
				return (null, SpecialType.UnknownType);
			}
			return (new BinaryNumericInstruction(op, iLInstruction, iLInstruction2, isChecked == true, type.GetSign()), type);
		case 3:
			if (!MatchGetMethodFromHandle(invocation.Arguments[2], out member))
			{
				return (null, SpecialType.UnknownType);
			}
			return (new Call((IMethod)member)
			{
				Arguments = { iLInstruction, iLInstruction2 }
			}, member.ReturnType);
		case 4:
		{
			if (!invocation.Arguments[2].MatchLdcI4(out var value))
			{
				return (null, SpecialType.UnknownType);
			}
			if (!MatchGetMethodFromHandle(invocation.Arguments[3], out member))
			{
				return (null, SpecialType.UnknownType);
			}
			if (value != 0)
			{
				member = CSharpOperators.LiftUserDefinedOperator((IMethod)member);
			}
			return (new Call((IMethod)member)
			{
				Arguments = { iLInstruction, iLInstruction2 }
			}, member.ReturnType);
		}
		default:
			return (null, SpecialType.UnknownType);
		}
	}

	private (ILInstruction, IType) ConvertBind(CallInstruction invocation, ILVariable targetVariable)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[1]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchGetMethodFromHandle(invocation.Arguments[0], out var member) && !MatchGetFieldFromHandle(invocation.Arguments[0], out member))
		{
			return (null, SpecialType.UnknownType);
		}
		IMember member2 = member;
		IMember member3 = member2;
		if (member3 != null)
		{
			if (member3 is IMethod method)
			{
				IMethod method2 = method;
				return (new Call(method2)
				{
					Arguments = 
					{
						(ILInstruction)new LdLoc(targetVariable),
						iLInstruction
					}
				}, method2.ReturnType);
			}
			if (member3 is IField field)
			{
				IField field2 = field;
				return (new StObj(new LdFlda(new LdLoc(targetVariable), (IField)member), iLInstruction, member.ReturnType), field2.ReturnType);
			}
		}
		return (null, SpecialType.UnknownType);
	}

	private (ILInstruction, IType) ConvertCall(CallInstruction invocation)
	{
		if (invocation.Arguments.Count < 2)
		{
			return (null, SpecialType.UnknownType);
		}
		IList<ILInstruction> arguments = null;
		ILInstruction iLInstruction = null;
		IType targetType = null;
		if (MatchGetMethodFromHandle(invocation.Arguments[0], out var member))
		{
			if (invocation.Arguments.Count != 2 || !MatchArgumentList(invocation.Arguments[1], out arguments))
			{
				arguments = new List<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)invocation.Arguments, 1));
			}
		}
		else if (MatchGetMethodFromHandle(invocation.Arguments[1], out member))
		{
			if (invocation.Arguments.Count != 3 || !MatchArgumentList(invocation.Arguments[2], out arguments))
			{
				arguments = new List<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)invocation.Arguments, 2));
			}
			if (!invocation.Arguments[0].MatchLdNull())
			{
				(iLInstruction, targetType) = ConvertInstruction(invocation.Arguments[0]);
				if (iLInstruction == null)
				{
					return (null, SpecialType.UnknownType);
				}
			}
		}
		if (arguments == null)
		{
			return (null, SpecialType.UnknownType);
		}
		IMethod method = (IMethod)member;
		Debug.Assert(arguments.Count == method.Parameters.Count);
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			IType type = method.Parameters[i].Type;
			var (iLInstruction2, type2) = ConvertInstruction(arguments[i], type);
			if (iLInstruction2 == null)
			{
				return (null, SpecialType.UnknownType);
			}
			arguments[i] = iLInstruction2;
		}
		if (method.FullName == "System.Reflection.MethodInfo.CreateDelegate" && method.Parameters.Count == 2)
		{
			if (!MatchGetMethodFromHandle(iLInstruction, out var member2))
			{
				return (null, SpecialType.UnknownType);
			}
			if (!MatchGetTypeFromHandle(arguments[0], out var type3))
			{
				return (null, SpecialType.UnknownType);
			}
			return (new NewObj(Enumerable.Single<IMethod>(type3.GetConstructors()))
			{
				Arguments = 
				{
					arguments[1],
					(ILInstruction)new LdFtn((IMethod)member2)
				}
			}, type3);
		}
		CallInstruction callInstruction = ((!method.IsAbstract && !method.IsVirtual && !method.IsOverride) ? ((CallInstruction)new Call(method)) : ((CallInstruction)new CallVirt(method)));
		if (iLInstruction != null)
		{
			callInstruction.Arguments.Add(PrepareCallTarget(method.DeclaringType, iLInstruction, targetType));
		}
		callInstruction.Arguments.AddRange(arguments);
		return (callInstruction, method.ReturnType);
	}

	private ILInstruction PrepareCallTarget(IType expectedType, ILInstruction target, IType targetType)
	{
		switch (CallInstruction.ExpectedTypeForThisPointer(expectedType))
		{
		case StackType.Ref:
			if (target.ResultType == StackType.Ref)
			{
				return target;
			}
			return new AddressOf(target);
		case StackType.O:
			if (targetType.IsReferenceType == false)
			{
				return new Box(target, targetType);
			}
			return target;
		default:
			return target;
		}
	}

	private (ILInstruction, IType) ConvertCast(CallInstruction invocation, bool isChecked)
	{
		if (invocation.Arguments.Count < 2)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchGetTypeFromHandle(invocation.Arguments[1], out var type))
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type2) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		if (type2.IsSmallIntegerType() && type.IsKnownType(KnownTypeCode.Int32))
		{
			return (iLInstruction, type);
		}
		return (new ExpressionTreeCast(type, iLInstruction, isChecked), type);
	}

	private (ILInstruction, IType) ConvertCoalesce(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction2, type2) = ConvertInstruction(invocation.Arguments[1]);
		if (iLInstruction2 == null)
		{
			return (null, SpecialType.UnknownType);
		}
		NullCoalescingKind kind = NullCoalescingKind.Ref;
		IType underlyingType = NullableType.GetUnderlyingType(type);
		IType item;
		if (!NullableType.IsNullable(type) || !conversions.ImplicitConversion(type2, underlyingType).IsValid)
		{
			item = ((!conversions.ImplicitConversion(type2, type).IsValid) ? type2 : type);
		}
		else
		{
			item = underlyingType;
			kind = (NullableType.IsNullable(type2) ? NullCoalescingKind.Nullable : NullCoalescingKind.NullableWithValueFallback);
		}
		return (new NullCoalescingInstruction(kind, iLInstruction, iLInstruction2), item);
	}

	private (ILInstruction, IType) ConvertComparison(CallInstruction invocation, ComparisonKind kind)
	{
		if (invocation.Arguments.Count < 2)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction2, type2) = ConvertInstruction(invocation.Arguments[1]);
		if (iLInstruction2 == null)
		{
			return (null, SpecialType.UnknownType);
		}
		if (invocation.Arguments.Count == 4 && invocation.Arguments[2].MatchLdcI4(out var value) && MatchGetMethodFromHandle(invocation.Arguments[3], out var member))
		{
			if (value != 0)
			{
				member = CSharpOperators.LiftUserDefinedOperator((IMethod)member);
			}
			return (new Call((IMethod)member)
			{
				Arguments = { iLInstruction, iLInstruction2 }
			}, member.ReturnType);
		}
		if (resolver.ResolveBinaryOperator(kind.ToBinaryOperatorType(), new ResolveResult(type), new ResolveResult(type2)) is OperatorResolveResult { IsError: false, UserDefinedOperatorMethod: not null } operatorResolveResult)
		{
			return (new Call(operatorResolveResult.UserDefinedOperatorMethod)
			{
				Arguments = { iLInstruction, iLInstruction2 }
			}, operatorResolveResult.UserDefinedOperatorMethod.ReturnType);
		}
		if (type.IsKnownType(KnownTypeCode.String) && type2.IsKnownType(KnownTypeCode.String))
		{
			IMethod method;
			switch (kind)
			{
			case ComparisonKind.Equality:
				method = Enumerable.FirstOrDefault<IMethod>(type.GetMethods((IMethod m) => m.IsOperator && m.Name == "op_Equality" && m.Parameters.Count == 2), (Func<IMethod, bool>)((IMethod m) => m.Parameters[0].Type.IsKnownType(KnownTypeCode.String) && m.Parameters[1].Type.IsKnownType(KnownTypeCode.String)));
				if (method == null)
				{
					return (null, SpecialType.UnknownType);
				}
				break;
			case ComparisonKind.Inequality:
				method = Enumerable.FirstOrDefault<IMethod>(type.GetMethods((IMethod m) => m.IsOperator && m.Name == "op_Inequality" && m.Parameters.Count == 2), (Func<IMethod, bool>)((IMethod m) => m.Parameters[0].Type.IsKnownType(KnownTypeCode.String) && m.Parameters[1].Type.IsKnownType(KnownTypeCode.String)));
				if (method == null)
				{
					return (null, SpecialType.UnknownType);
				}
				break;
			default:
				return (null, SpecialType.UnknownType);
			}
			return (new Call(method)
			{
				Arguments = { iLInstruction, iLInstruction2 }
			}, method.ReturnType);
		}
		IType item = context.TypeSystem.FindType(KnownTypeCode.Boolean);
		ComparisonLiftingKind lifting = (NullableType.IsNullable(type) ? ComparisonLiftingKind.CSharp : ComparisonLiftingKind.None);
		IType underlyingType = NullableType.GetUnderlyingType(type);
		return (new Comp(kind, lifting, underlyingType.GetStackType(), underlyingType.GetSign(), iLInstruction, iLInstruction2), item);
	}

	private (ILInstruction, IType) ConvertCondition(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 3)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null || !type.IsKnownType(KnownTypeCode.Boolean))
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction2, type2) = ConvertInstruction(invocation.Arguments[1]);
		if (iLInstruction2 == null)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction3, other) = ConvertInstruction(invocation.Arguments[2]);
		if (iLInstruction3 == null)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!type2.Equals(other))
		{
			return (null, SpecialType.UnknownType);
		}
		return (new IfInstruction(iLInstruction, iLInstruction2, iLInstruction3), type2);
	}

	private (ILInstruction, IType) ConvertConstant(CallInstruction invocation)
	{
		if (!MatchConstantCall(invocation, out var value, out var type))
		{
			return (null, SpecialType.UnknownType);
		}
		if (value.MatchBox(out var argument, out var type2))
		{
			if (type2.Kind == TypeKind.Enum || type2.IsKnownType(KnownTypeCode.Boolean))
			{
				return (new ExpressionTreeCast(type2, ConvertValue(argument, invocation), isChecked: false), type2);
			}
			value = ConvertValue(argument, invocation);
			return (value, type);
		}
		return (ConvertValue(value, invocation), type);
	}

	private (ILInstruction, IType) ConvertElementInit(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchGetMethodFromHandle(invocation.Arguments[0], out var member))
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchArgumentList(invocation.Arguments[1], out var arguments))
		{
			return (null, SpecialType.UnknownType);
		}
		CallInstruction callInstruction = new Call((IMethod)member);
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			ILInstruction item = ConvertInstruction(arguments[i]).Item1;
			if (item == null)
			{
				return (null, SpecialType.UnknownType);
			}
			arguments[i] = item;
		}
		callInstruction.Arguments.AddRange(arguments);
		return (callInstruction, member.ReturnType);
	}

	private (ILInstruction, IType) ConvertField(CallInstruction invocation, IType typeHint)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		ILInstruction iLInstruction = null;
		if (!invocation.Arguments[0].MatchLdNull())
		{
			iLInstruction = ConvertInstruction(invocation.Arguments[0]).Item1;
			if (iLInstruction == null)
			{
				return (null, SpecialType.UnknownType);
			}
		}
		if (!MatchGetFieldFromHandle(invocation.Arguments[1], out var member))
		{
			return (null, SpecialType.UnknownType);
		}
		IType item = member.ReturnType;
		ILInstruction iLInstruction2 = ((iLInstruction == null) ? ((ILInstruction)new LdsFlda((IField)member)) : ((ILInstruction)((member.DeclaringType.IsReferenceType != true) ? new LdFlda(new AddressOf(iLInstruction), (IField)member) : new LdFlda(iLInstruction, (IField)member))));
		if (typeHint.SkipModifiers() is ByReferenceType && !member.ReturnType.IsByRefLike)
		{
			item = typeHint;
		}
		else
		{
			iLInstruction2 = new LdObj(iLInstruction2, member.ReturnType);
		}
		return (iLInstruction2, item);
	}

	private (ILInstruction, IType) ConvertInvoke(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		IMethod delegateInvokeMethod = type.GetDelegateInvokeMethod();
		if (delegateInvokeMethod == null)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchArgumentList(invocation.Arguments[1], out var arguments))
		{
			return (null, SpecialType.UnknownType);
		}
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			ILInstruction item = ConvertInstruction(arguments[i]).Item1;
			if (item == null)
			{
				return (null, SpecialType.UnknownType);
			}
			arguments[i] = item;
		}
		CallVirt callVirt = new CallVirt(delegateInvokeMethod);
		callVirt.Arguments.Add(iLInstruction);
		callVirt.Arguments.AddRange(arguments);
		return (callVirt, delegateInvokeMethod.ReturnType);
	}

	private (ILInstruction, IType) ConvertListInit(CallInstruction invocation)
	{
		if (invocation.Arguments.Count < 2)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!(ConvertInstruction(invocation.Arguments[0]).Item1 is NewObj newObj))
		{
			return (null, SpecialType.UnknownType);
		}
		IList<ILInstruction> arguments = null;
		ILFunction iLFunction = lambdaStack.Peek();
		if (!MatchGetMethodFromHandle(invocation.Arguments[1], out var _))
		{
			if (!MatchArgumentList(invocation.Arguments[1], out arguments))
			{
				return (null, SpecialType.UnknownType);
			}
		}
		else if (invocation.Arguments.Count != 3 || !MatchArgumentList(invocation.Arguments[2], out arguments))
		{
			return (null, SpecialType.UnknownType);
		}
		if (arguments == null || arguments.Count == 0)
		{
			return (null, SpecialType.UnknownType);
		}
		ILVariable iLVariable = iLFunction.RegisterVariable(VariableKind.InitializerTarget, newObj.Method.DeclaringType);
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			ILInstruction item;
			if (arguments[i] is CallInstruction callInstruction && callInstruction.Method.FullName == "System.Linq.Expressions.Expression.ElementInit")
			{
				item = ConvertElementInit(callInstruction).Item1;
				if (item == null)
				{
					return (null, SpecialType.UnknownType);
				}
				((CallInstruction)item).Arguments.Insert(0, new LdLoc(iLVariable));
			}
			else
			{
				item = ConvertInstruction(arguments[i]).Item1;
				if (item == null)
				{
					return (null, SpecialType.UnknownType);
				}
			}
			arguments[i] = item;
		}
		Block block = new Block(BlockKind.CollectionInitializer);
		block.FinalInstruction = new LdLoc(iLVariable);
		block.Instructions.Add(new StLoc(iLVariable, newObj));
		block.Instructions.AddRange(arguments);
		return (block, iLVariable.Type);
	}

	private (ILInstruction, IType) ConvertLogicOperator(CallInstruction invocation, bool and)
	{
		if (invocation.Arguments.Count < 2)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction2, type2) = ConvertInstruction(invocation.Arguments[1]);
		if (iLInstruction2 == null)
		{
			return (null, SpecialType.UnknownType);
		}
		IMember member;
		switch (invocation.Arguments.Count)
		{
		case 2:
		{
			IType item = context.TypeSystem.FindType(KnownTypeCode.Boolean);
			return (and ? IfInstruction.LogicAnd(iLInstruction, iLInstruction2) : IfInstruction.LogicOr(iLInstruction, iLInstruction2), item);
		}
		case 3:
			if (!MatchGetMethodFromHandle(invocation.Arguments[2], out member))
			{
				return (null, SpecialType.UnknownType);
			}
			return (new Call((IMethod)member)
			{
				Arguments = { iLInstruction, iLInstruction2 }
			}, member.ReturnType);
		case 4:
		{
			if (!invocation.Arguments[2].MatchLdcI4(out var value))
			{
				return (null, SpecialType.UnknownType);
			}
			if (!MatchGetMethodFromHandle(invocation.Arguments[3], out member))
			{
				return (null, SpecialType.UnknownType);
			}
			if (value != 0)
			{
				member = CSharpOperators.LiftUserDefinedOperator((IMethod)member);
			}
			return (new Call((IMethod)member)
			{
				Arguments = { iLInstruction, iLInstruction2 }
			}, member.ReturnType);
		}
		default:
			return (null, SpecialType.UnknownType);
		}
	}

	private (ILInstruction, IType) ConvertMemberInit(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!(ConvertInstruction(invocation.Arguments[0]).Item1 is NewObj newObj))
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchArgumentList(invocation.Arguments[1], out var arguments))
		{
			return (null, SpecialType.UnknownType);
		}
		if (arguments == null || arguments.Count == 0)
		{
			return (null, SpecialType.UnknownType);
		}
		ILFunction iLFunction = lambdaStack.Peek();
		ILVariable iLVariable = iLFunction.RegisterVariable(VariableKind.InitializerTarget, newObj.Method.DeclaringType);
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			if (arguments[i] is CallInstruction callInstruction && callInstruction.Method.FullName == "System.Linq.Expressions.Expression.Bind")
			{
				ILInstruction item = ConvertBind(callInstruction, iLVariable).Item1;
				if (item == null)
				{
					return (null, SpecialType.UnknownType);
				}
				arguments[i] = item;
				continue;
			}
			return (null, SpecialType.UnknownType);
		}
		Block block = new Block(BlockKind.CollectionInitializer);
		block.FinalInstruction = new LdLoc(iLVariable);
		block.Instructions.Add(new StLoc(iLVariable, newObj));
		block.Instructions.AddRange(arguments);
		return (block, iLVariable.Type);
	}

	private (ILInstruction, IType) ConvertNewArrayBounds(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchGetTypeFromHandle(invocation.Arguments[0], out var type))
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchArgumentList(invocation.Arguments[1], out var arguments))
		{
			return (null, SpecialType.UnknownType);
		}
		if (arguments.Count == 0)
		{
			return (null, SpecialType.UnknownType);
		}
		ILInstruction[] array = new ILInstruction[arguments.Count];
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			ILInstruction item = ConvertInstruction(arguments[i]).Item1;
			if (item == null)
			{
				return (null, SpecialType.UnknownType);
			}
			array[i] = item;
		}
		return (new NewArr(type, array), new ArrayType(context.TypeSystem, type, arguments.Count));
	}

	private (ILInstruction, IType) ConvertNewArrayInit(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchGetTypeFromHandle(invocation.Arguments[0], out var type))
		{
			return (null, SpecialType.UnknownType);
		}
		if (!MatchArgumentList(invocation.Arguments[1], out var arguments))
		{
			return (null, SpecialType.UnknownType);
		}
		ArrayType arrayType = new ArrayType(context.BlockContext.TypeSystem, type);
		if (arguments.Count == 0)
		{
			return (new NewArr(type, new LdcI4(0)), arrayType);
		}
		Block block = (Block)invocation.Arguments[1];
		ILFunction iLFunction = lambdaStack.Peek();
		ILVariable iLVariable = iLFunction.RegisterVariable(VariableKind.InitializerTarget, arrayType);
		Block block2 = new Block(BlockKind.ArrayInitializer);
		int value = 0;
		block2.Instructions.Add(new StLoc(iLVariable, new NewArr(type, new LdcI4(arguments.Count))));
		foreach (ILInstruction item2 in arguments)
		{
			ILInstruction item = ConvertInstruction(item2).Item1;
			if (item == null)
			{
				return (null, SpecialType.UnknownType);
			}
			block2.Instructions.Add(new StObj(new LdElema(type, new LdLoc(iLVariable), new LdcI4(value)), item, type));
		}
		block2.FinalInstruction = new LdLoc(iLVariable);
		return (block2, iLVariable.Type);
	}

	private (ILInstruction, IType) ConvertNewObject(CallInstruction invocation)
	{
		IMember member;
		IList<ILInstruction> arguments;
		switch (invocation.Arguments.Count)
		{
		case 1:
		{
			if (MatchGetTypeFromHandle(invocation.Arguments[0], out var type))
			{
				IMethod method = Enumerable.FirstOrDefault<IMethod>(type.GetConstructors((IMethod c) => c.Parameters.Count == 0));
				if (method == null)
				{
					return (null, SpecialType.UnknownType);
				}
				return (new NewObj(method), type);
			}
			if (MatchGetConstructorFromHandle(invocation.Arguments[0], out member))
			{
				return (new NewObj((IMethod)member), member.DeclaringType);
			}
			return (null, SpecialType.UnknownType);
		}
		case 2:
		{
			if (!MatchGetConstructorFromHandle(invocation.Arguments[0], out member))
			{
				return (null, SpecialType.UnknownType);
			}
			if (!MatchArgumentList(invocation.Arguments[1], out arguments))
			{
				return (null, SpecialType.UnknownType);
			}
			ILInstruction[] array2 = arguments.SelectArray((ILInstruction arg) => ConvertInstruction(arg).Item1);
			if (array2.Any((ILInstruction a) => a == null))
			{
				return (null, SpecialType.UnknownType);
			}
			NewObj newObj = new NewObj((IMethod)member);
			newObj.Arguments.AddRange(array2);
			return (newObj, member.DeclaringType);
		}
		case 3:
		{
			if (!MatchGetConstructorFromHandle(invocation.Arguments[0], out member))
			{
				return (null, SpecialType.UnknownType);
			}
			if (!MatchArgumentList(invocation.Arguments[1], out arguments))
			{
				return (null, SpecialType.UnknownType);
			}
			ILInstruction[] array = arguments.SelectArray((ILInstruction arg) => ConvertInstruction(arg).Item1);
			if (array.Any((ILInstruction a) => a == null))
			{
				return (null, SpecialType.UnknownType);
			}
			NewObj newObj = new NewObj((IMethod)member);
			newObj.Arguments.AddRange(array);
			return (newObj, member.DeclaringType);
		}
		default:
			return (null, SpecialType.UnknownType);
		}
	}

	private (ILInstruction, IType) ConvertNotOperator(CallInstruction invocation)
	{
		if (invocation.Arguments.Count < 1)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		switch (invocation.Arguments.Count)
		{
		case 1:
			return (type.IsKnownType(KnownTypeCode.Boolean) ? ((ILInstruction)Comp.LogicNot(iLInstruction)) : ((ILInstruction)new BitNot(iLInstruction)), type);
		case 2:
		{
			if (!MatchGetMethodFromHandle(invocation.Arguments[1], out var member))
			{
				return (null, SpecialType.UnknownType);
			}
			return (new Call((IMethod)member)
			{
				Arguments = { iLInstruction }
			}, member.ReturnType);
		}
		default:
			return (null, SpecialType.UnknownType);
		}
	}

	private (ILInstruction, IType) ConvertProperty(CallInstruction invocation)
	{
		if (invocation.Arguments.Count < 2)
		{
			return (null, SpecialType.UnknownType);
		}
		ILInstruction iLInstruction = null;
		IType targetType = null;
		if (!invocation.Arguments[0].MatchLdNull())
		{
			(iLInstruction, targetType) = ConvertInstruction(invocation.Arguments[0]);
			if (iLInstruction == null)
			{
				return (null, SpecialType.UnknownType);
			}
		}
		if (!MatchGetMethodFromHandle(invocation.Arguments[1], out var member))
		{
			return (null, SpecialType.UnknownType);
		}
		if (invocation.Arguments.Count != 3 || !MatchArgumentList(invocation.Arguments[2], out var arguments))
		{
			arguments = new List<ILInstruction>();
		}
		else
		{
			for (int i = 0; i < arguments.Count; i = checked(i + 1))
			{
				arguments[i] = ConvertInstruction(arguments[i]).Item1;
				if (arguments[i] == null)
				{
					return (null, SpecialType.UnknownType);
				}
			}
		}
		CallInstruction callInstruction = ((!member.IsAbstract && !member.IsVirtual && !member.IsOverride) ? ((CallInstruction)new Call((IMethod)member)) : ((CallInstruction)new CallVirt((IMethod)member)));
		if (iLInstruction != null)
		{
			callInstruction.Arguments.Add(PrepareCallTarget(member.DeclaringType, iLInstruction, targetType));
		}
		callInstruction.Arguments.AddRange(arguments);
		return (callInstruction, member.ReturnType);
	}

	private (ILInstruction, IType) ConvertTypeAs(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		ILInstruction item = ConvertInstruction(invocation.Arguments[0]).Item1;
		if (!MatchGetTypeFromHandle(invocation.Arguments[1], out var type))
		{
			return (null, SpecialType.UnknownType);
		}
		if (item != null)
		{
			return (new IsInst(item, type), type);
		}
		return (null, SpecialType.UnknownType);
	}

	private (ILInstruction, IType) ConvertTypeIs(CallInstruction invocation)
	{
		if (invocation.Arguments.Count != 2)
		{
			return (null, SpecialType.UnknownType);
		}
		ILInstruction item = ConvertInstruction(invocation.Arguments[0]).Item1;
		if (!MatchGetTypeFromHandle(invocation.Arguments[1], out var type))
		{
			return (null, SpecialType.UnknownType);
		}
		IType item2 = context.TypeSystem.FindType(KnownTypeCode.Boolean);
		if (item != null)
		{
			return (new Comp(ComparisonKind.Inequality, Sign.None, new IsInst(item, type), new LdNull()), item2);
		}
		return (null, SpecialType.UnknownType);
	}

	private (ILInstruction, IType) ConvertUnaryNumericOperator(CallInstruction invocation, BinaryNumericOperator op, bool? isChecked = null)
	{
		if (invocation.Arguments.Count < 1)
		{
			return (null, SpecialType.UnknownType);
		}
		var (iLInstruction, type) = ConvertInstruction(invocation.Arguments[0]);
		if (iLInstruction == null)
		{
			return (null, SpecialType.UnknownType);
		}
		switch (invocation.Arguments.Count)
		{
		case 1:
		{
			ILInstruction left;
			switch (iLInstruction.ResultType)
			{
			case StackType.I4:
				left = new LdcI4(0);
				break;
			case StackType.I8:
				left = new LdcI8(0L);
				break;
			case StackType.I:
				left = new Conv(new LdcI4(0), PrimitiveType.I, checkForOverflow: false, Sign.None);
				break;
			case StackType.F4:
				left = new LdcF4(0f);
				break;
			case StackType.F8:
				left = new LdcF8(0.0);
				break;
			default:
				return (null, SpecialType.UnknownType);
			}
			return (new BinaryNumericInstruction(op, left, iLInstruction, isChecked == true, type.GetSign()), type);
		}
		case 2:
		{
			if (!MatchGetMethodFromHandle(invocation.Arguments[1], out var member))
			{
				return (null, SpecialType.UnknownType);
			}
			return (new Call((IMethod)member)
			{
				Arguments = { iLInstruction }
			}, member.ReturnType);
		}
		default:
			return (null, SpecialType.UnknownType);
		}
	}

	private ILInstruction ConvertValue(ILInstruction value, ILInstruction context)
	{
		if (value != null && value is LdLoc ldLoc)
		{
			LdLoc ldLoc2 = ldLoc;
			if (IsExpressionTreeParameter(ldLoc2.Variable))
			{
				if (!parameterMapping.TryGetValue(ldLoc2.Variable, out var value2))
				{
					return ldLoc2;
				}
				if (context is CallInstruction callInstruction && callInstruction.Method.FullName == "System.Linq.Expressions.Expression.Call" && value2.StackType.IsIntegerType())
				{
					return new LdLoca(value2);
				}
				return null;
			}
			if (ldLoc2.Variable.Kind != VariableKind.StackSlot)
			{
				return ldLoc2;
			}
			return null;
		}
		return value.Clone();
	}

	private bool IsExpressionTreeParameter(ILVariable variable)
	{
		return variable.Type.FullName == "System.Linq.Expressions.ParameterExpression";
	}

	private bool MatchConstantCall(ILInstruction inst, out ILInstruction value, out IType type)
	{
		value = null;
		type = null;
		if (inst is CallInstruction callInstruction && callInstruction.Method.FullName == "System.Linq.Expressions.Expression.Constant")
		{
			value = callInstruction.Arguments[0];
			if (callInstruction.Arguments.Count == 2)
			{
				return MatchGetTypeFromHandle(callInstruction.Arguments[1], out type);
			}
			type = value.InferType(context.TypeSystem);
			return true;
		}
		return false;
	}

	internal static bool MatchGetTypeFromHandle(ILInstruction inst, out IType type)
	{
		type = null;
		return inst is CallInstruction callInstruction && callInstruction.Method.FullName == "System.Type.GetTypeFromHandle" && callInstruction.Arguments.Count == 1 && callInstruction.Arguments[0].MatchLdTypeToken(out type);
	}

	private bool MatchGetMethodFromHandle(ILInstruction inst, out IMember member)
	{
		member = null;
		if (!inst.MatchCastClass(out var argument, out var type))
		{
			return false;
		}
		if (!type.Equals(context.TypeSystem.FindType(new FullTypeName("System.Reflection.MethodInfo"))))
		{
			return false;
		}
		if (!(argument is CallInstruction callInstruction) || !(callInstruction.Method.FullName == "System.Reflection.MethodBase.GetMethodFromHandle"))
		{
			return false;
		}
		switch (callInstruction.Arguments.Count)
		{
		case 1:
			if (!callInstruction.Arguments[0].MatchLdMemberToken(out member))
			{
				return false;
			}
			break;
		case 2:
		{
			if (!callInstruction.Arguments[0].MatchLdMemberToken(out member))
			{
				return false;
			}
			if (!callInstruction.Arguments[1].MatchLdTypeToken(out var _))
			{
				return false;
			}
			break;
		}
		}
		return true;
	}

	private bool MatchGetConstructorFromHandle(ILInstruction inst, out IMember member)
	{
		member = null;
		if (!inst.MatchCastClass(out var argument, out var type))
		{
			return false;
		}
		if (!type.Equals(context.TypeSystem.FindType(new FullTypeName("System.Reflection.ConstructorInfo"))))
		{
			return false;
		}
		if (!(argument is CallInstruction callInstruction) || !(callInstruction.Method.FullName == "System.Reflection.MethodBase.GetMethodFromHandle"))
		{
			return false;
		}
		switch (callInstruction.Arguments.Count)
		{
		case 1:
			if (!callInstruction.Arguments[0].MatchLdMemberToken(out member))
			{
				return false;
			}
			break;
		case 2:
		{
			if (!callInstruction.Arguments[0].MatchLdMemberToken(out member))
			{
				return false;
			}
			if (!callInstruction.Arguments[1].MatchLdTypeToken(out var _))
			{
				return false;
			}
			break;
		}
		}
		return true;
	}

	private bool MatchGetFieldFromHandle(ILInstruction inst, out IMember member)
	{
		member = null;
		if (!(inst is CallInstruction callInstruction) || !(callInstruction.Method.FullName == "System.Reflection.FieldInfo.GetFieldFromHandle"))
		{
			return false;
		}
		switch (callInstruction.Arguments.Count)
		{
		case 1:
			if (!callInstruction.Arguments[0].MatchLdMemberToken(out member))
			{
				return false;
			}
			break;
		case 2:
		{
			if (!callInstruction.Arguments[0].MatchLdMemberToken(out member))
			{
				return false;
			}
			if (!callInstruction.Arguments[1].MatchLdTypeToken(out var _))
			{
				return false;
			}
			break;
		}
		}
		return true;
	}

	private bool MatchArgumentList(ILInstruction inst, out IList<ILInstruction> arguments)
	{
		arguments = null;
		if (!(inst is Block { Kind: BlockKind.ArrayInitializer } block))
		{
			if (IsEmptyParameterList(inst))
			{
				arguments = new List<ILInstruction>();
				return true;
			}
			return false;
		}
		int num = 0;
		arguments = new List<ILInstruction>();
		foreach (StObj item in Enumerable.OfType<StObj>((IEnumerable)block.Instructions))
		{
			if (!(item.Target is LdElema ldElema) || !Enumerable.Single<ILInstruction>((IEnumerable<ILInstruction>)ldElema.Indices).MatchLdcI4(num))
			{
				return false;
			}
			arguments.Add(item.Value);
			num = checked(num + 1);
		}
		return true;
	}
}
