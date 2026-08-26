#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp;

internal struct CallBuilder
{
	private struct ExpectedTargetDetails
	{
		public OpCode CallOpCode;

		public bool NeedsBoxingConversion;
	}

	private struct ArgumentList
	{
		public TranslatedExpression[] Arguments;

		public IParameter[] ExpectedParameters;

		public string[] ParameterNames;

		public string[] ArgumentNames;

		public int FirstOptionalArgumentIndex;

		public BitSet IsPrimitiveValue;

		public IReadOnlyList<int> ArgumentToParameterMap;

		public bool AddNamesToPrimitiveValues;

		public bool IsExpandedForm;

		public int Length => Arguments.Length;

		public IEnumerable<ResolveResult> GetArgumentResolveResults(int skipCount = 0)
		{
			return (FirstOptionalArgumentIndex < 0) ? Enumerable.Select<TranslatedExpression, ResolveResult>(Enumerable.Skip<TranslatedExpression>((IEnumerable<TranslatedExpression>)Arguments, skipCount), (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult)) : Enumerable.Select<TranslatedExpression, ResolveResult>(Enumerable.Take<TranslatedExpression>(Enumerable.Skip<TranslatedExpression>((IEnumerable<TranslatedExpression>)Arguments, skipCount), FirstOptionalArgumentIndex), (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult));
		}

		public IEnumerable<Expression> GetArgumentExpressions(int skipCount = 0)
		{
			if (AddNamesToPrimitiveValues && IsPrimitiveValue.Any() && !IsExpandedForm && !ParameterNames.Any((string p) => string.IsNullOrEmpty(p)))
			{
				Debug.Assert(skipCount == 0);
				if (ArgumentNames == null)
				{
					ArgumentNames = new string[Arguments.Length];
				}
				for (int num = 0; num < Arguments.Length; num = checked(num + 1))
				{
					if (IsPrimitiveValue[num] && ArgumentNames[num] == null)
					{
						ArgumentNames[num] = ParameterNames[num];
					}
				}
			}
			if (ArgumentNames == null)
			{
				if (FirstOptionalArgumentIndex < 0)
				{
					return Enumerable.Select<TranslatedExpression, Expression>(Enumerable.Skip<TranslatedExpression>((IEnumerable<TranslatedExpression>)Arguments, skipCount), (Func<TranslatedExpression, Expression>)((TranslatedExpression arg) => arg.Expression));
				}
				return Enumerable.Select<TranslatedExpression, Expression>(Enumerable.Take<TranslatedExpression>(Enumerable.Skip<TranslatedExpression>((IEnumerable<TranslatedExpression>)Arguments, skipCount), FirstOptionalArgumentIndex), (Func<TranslatedExpression, Expression>)((TranslatedExpression arg) => arg.Expression));
			}
			Debug.Assert(skipCount == 0);
			if (FirstOptionalArgumentIndex < 0)
			{
				return Enumerable.Zip<TranslatedExpression, string, Expression>((IEnumerable<TranslatedExpression>)Arguments, (IEnumerable<string>)ArgumentNames, (Func<TranslatedExpression, string, Expression>)((TranslatedExpression arg, string name) => (name == null) ? arg.Expression : new NamedArgumentExpression(name, arg)));
			}
			return Enumerable.Zip<TranslatedExpression, string, Expression>(Enumerable.Take<TranslatedExpression>((IEnumerable<TranslatedExpression>)Arguments, FirstOptionalArgumentIndex), Enumerable.Take<string>((IEnumerable<string>)ArgumentNames, FirstOptionalArgumentIndex), (Func<TranslatedExpression, string, Expression>)((TranslatedExpression arg, string name) => (name == null) ? arg.Expression : new NamedArgumentExpression(name, arg)));
		}

		public bool CanInferAnonymousTypePropertyNamesFromArguments()
		{
			for (int num = 0; num < Arguments.Length; num = checked(num + 1))
			{
				Expression expression = Arguments[num].Expression;
				Expression expression2 = expression;
				if (expression2 == null)
				{
					goto IL_005b;
				}
				string text;
				if (!(expression2 is IdentifierExpression identifierExpression))
				{
					if (!(expression2 is MemberReferenceExpression memberReferenceExpression))
					{
						goto IL_005b;
					}
					MemberReferenceExpression memberReferenceExpression2 = memberReferenceExpression;
					text = memberReferenceExpression2.MemberName;
				}
				else
				{
					IdentifierExpression identifierExpression2 = identifierExpression;
					text = identifierExpression2.Identifier;
				}
				goto IL_005f;
				IL_005b:
				text = null;
				goto IL_005f;
				IL_005f:
				if (text != ExpectedParameters[num].Name)
				{
					return false;
				}
			}
			return true;
		}

		[Conditional("DEBUG")]
		public void CheckNoNamedOrOptionalArguments()
		{
			Debug.Assert(ArgumentToParameterMap == null && ArgumentNames == null && FirstOptionalArgumentIndex < 0);
		}
	}

	private enum TokenKind
	{
		Error,
		String,
		Argument,
		ArgumentWithFormat
	}

	[Flags]
	private enum CallTransformation
	{
		None = 0,
		RequireTarget = 1,
		RequireTypeArguments = 2,
		NoOptionalArgumentAllowed = 4,
		All = RequireTarget | RequireTypeArguments | NoOptionalArgumentAllowed
	}

	private readonly DecompilerSettings settings;

	private readonly ExpressionBuilder expressionBuilder;

	private readonly CSharpResolver resolver;

	private readonly IDecompilerTypeSystem typeSystem;

	public CallBuilder(ExpressionBuilder expressionBuilder, IDecompilerTypeSystem typeSystem, DecompilerSettings settings)
	{
		this.expressionBuilder = expressionBuilder;
		resolver = expressionBuilder.resolver;
		this.settings = settings;
		this.typeSystem = typeSystem;
	}

	public TranslatedExpression Build(CallInstruction inst)
	{
		if (inst is NewObj inst2 && DelegateConstruction.IsDelegateConstruction(inst2, allowTransformed: true))
		{
			return HandleDelegateConstruction(inst2);
		}
		if (settings.TupleTypes && TupleTransform.MatchTupleConstruction(inst as NewObj, out var arguments) && arguments.Length >= 2)
		{
			ImmutableArray<IType> tupleElementTypes = TupleType.GetTupleElementTypes(inst.Method.DeclaringType);
			Debug.Assert(!tupleElementTypes.IsDefault, "MatchTupleConstruction should not success unless we got a valid tuple type.");
			Debug.Assert(tupleElementTypes.Length == arguments.Length);
			TupleExpression tupleExpression = new TupleExpression();
			List<ResolveResult> list = new List<ResolveResult>();
			foreach (var item3 in arguments.Zip(tupleElementTypes))
			{
				ILInstruction item = item3.Item1;
				IType item2 = item3.Item2;
				TranslatedExpression translatedExpression = expressionBuilder.Translate(item, item2).ConvertTo(item2, expressionBuilder, checkForOverflow: false, allowImplicitConversion: true);
				tupleExpression.Elements.Add(translatedExpression.Expression);
				list.Add(translatedExpression.ResolveResult);
			}
			return tupleExpression.WithRR(new TupleResolveResult(expressionBuilder.compilation, list.ToImmutableArray(), default(ImmutableArray<string>), inst.Method.DeclaringType.GetDefinition()?.ParentModule)).WithILInstruction(inst);
		}
		return Build(inst.OpCode, inst.Method, inst.Arguments, null, inst.ConstrainedTo).WithILInstruction(inst);
	}

	public ExpressionWithResolveResult Build(OpCode callOpCode, IMethod method, IReadOnlyList<ILInstruction> callArguments, IReadOnlyList<int> argumentToParameterMap = null, IType constrainedTo = null)
	{
		ExpectedTargetDetails expectedTargetDetails = new ExpectedTargetDetails
		{
			CallOpCode = callOpCode
		};
		TranslatedExpression target;
		if (callOpCode == OpCode.NewObj)
		{
			target = default(TranslatedExpression);
		}
		else
		{
			target = expressionBuilder.TranslateTarget(Enumerable.FirstOrDefault<ILInstruction>((IEnumerable<ILInstruction>)callArguments), callOpCode == OpCode.Call, method.IsStatic, constrainedTo ?? method.DeclaringType);
			if (constrainedTo == null && target.Expression is CastExpression castExpression && target.ResolveResult is ConversionResolveResult conversionResolveResult && target.Type.IsKnownType(KnownTypeCode.Object) && conversionResolveResult.Conversion.IsBoxingConversion)
			{
				target = target.UnwrapChild(castExpression.Expression);
				expectedTargetDetails.NeedsBoxingConversion = true;
			}
		}
		int num = ((!method.IsStatic && callOpCode != OpCode.NewObj) ? 1 : 0);
		Debug.Assert(num == 0 || argumentToParameterMap == null || argumentToParameterMap[0] == -1);
		ArgumentList argumentList = BuildArgumentList(expectedTargetDetails, target.ResolveResult, method, num, callArguments, argumentToParameterMap);
		bool unpackSingleElementArray;
		checked
		{
			if (method is VarArgInstanceMethod)
			{
				argumentList.FirstOptionalArgumentIndex = -1;
				argumentList.AddNamesToPrimitiveValues = false;
				int regularParameterCount = ((VarArgInstanceMethod)method).RegularParameterCount;
				UndocumentedExpression undocumentedExpression = new UndocumentedExpression();
				undocumentedExpression.UndocumentedExpressionType = UndocumentedExpressionType.ArgList;
				int paramIndex = regularParameterCount;
				ExpressionBuilder builder = expressionBuilder;
				Debug.Assert(argumentToParameterMap == null && argumentList.ArgumentNames == null);
				undocumentedExpression.Arguments.AddRange(Enumerable.Select<TranslatedExpression, Expression>(Enumerable.Skip<TranslatedExpression>((IEnumerable<TranslatedExpression>)argumentList.Arguments, regularParameterCount), (Func<TranslatedExpression, Expression>)((TranslatedExpression arg) => arg.ConvertTo(argumentList.ExpectedParameters[paramIndex++].Type, builder).Expression)));
				ResolveResult resolveResult = new ResolveResult(SpecialType.ArgList);
				argumentList.Arguments = Enumerable.ToArray<TranslatedExpression>(Enumerable.Concat<TranslatedExpression>(Enumerable.Take<TranslatedExpression>((IEnumerable<TranslatedExpression>)argumentList.Arguments, regularParameterCount), (IEnumerable<TranslatedExpression>)new TranslatedExpression[1] { undocumentedExpression.WithoutILInstruction().WithRR(resolveResult) }));
				method = ((VarArgInstanceMethod)method).BaseMethod;
				argumentList.ExpectedParameters = Enumerable.ToArray<IParameter>((IEnumerable<IParameter>)method.Parameters);
			}
			if (callOpCode == OpCode.NewObj)
			{
				return HandleConstructorCall(expectedTargetDetails, target.ResolveResult, method, argumentList);
			}
			if (method.Name == "Invoke" && method.DeclaringType.Kind == TypeKind.Delegate && !IsNullConditional(target))
			{
				return new InvocationExpression(target, argumentList.GetArgumentExpressions()).WithRR(new CSharpInvocationResolveResult(target.ResolveResult, method, Enumerable.ToList<ResolveResult>(argumentList.GetArgumentResolveResults()), OverloadResolutionErrors.None, isExtensionMethodInvocation: false, argumentList.IsExpandedForm, isDelegateInvocation: true));
			}
			if (settings.StringInterpolation && IsInterpolatedStringCreation(method, argumentList) && TryGetStringInterpolationTokens(argumentList, out var format, out var tokens))
			{
				TranslatedExpression[] arguments = argumentList.Arguments;
				List<InterpolatedStringContent> list = new List<InterpolatedStringContent>();
				int num2;
				if (!argumentList.IsExpandedForm && argumentList.Length == 2 && argumentList.Arguments[1].Expression is ArrayCreateExpression arrayCreateExpression)
				{
					ArrayInitializerExpression initializer = arrayCreateExpression.Initializer;
					num2 = ((initializer != null && initializer.Elements.Count == 1) ? 1 : 0);
				}
				else
				{
					num2 = 0;
				}
				unpackSingleElementArray = unchecked((byte)num2) != 0;
				if (tokens.Count > 0)
				{
					foreach (var (tokenKind, num3, text) in tokens)
					{
						switch (tokenKind)
						{
						case TokenKind.String:
							list.Add(new InterpolatedStringText(text));
							break;
						case TokenKind.Argument:
						{
							TranslatedExpression argument = arguments[num3 + 1];
							UnpackSingleElementArray(ref argument);
							list.Add(new Interpolation(argument));
							break;
						}
						case TokenKind.ArgumentWithFormat:
						{
							TranslatedExpression argument = arguments[num3 + 1];
							UnpackSingleElementArray(ref argument);
							list.Add(new Interpolation(argument, text));
							break;
						}
						}
					}
					IType type = expressionBuilder.compilation.FindType(KnownTypeCode.FormattableString);
					InterpolatedStringResolveResult interpolatedStringResolveResult = new InterpolatedStringResolveResult(expressionBuilder.compilation.FindType(KnownTypeCode.String), format, Enumerable.ToArray<ResolveResult>(Enumerable.Skip<ResolveResult>(argumentList.GetArgumentResolveResults(), 1)));
					InterpolatedStringExpression interpolatedStringExpression = new InterpolatedStringExpression();
					interpolatedStringExpression.Content.AddRange(list);
					if (method.Name == "Format")
					{
						return interpolatedStringExpression.WithRR(interpolatedStringResolveResult);
					}
					return new CastExpression(expressionBuilder.ConvertType(type), interpolatedStringExpression.WithRR(interpolatedStringResolveResult)).WithRR(new ConversionResolveResult(type, interpolatedStringResolveResult, Conversion.ImplicitInterpolatedStringConversion));
				}
			}
			int num4 = (method.ReturnType.IsKnownType(KnownTypeCode.Void) ? 1 : 0);
			if (method.IsAccessor && (method.AccessorOwner.SymbolKind == SymbolKind.Indexer || argumentList.ExpectedParameters.Length == num4))
			{
				argumentList.CheckNoNamedOrOptionalArguments();
				return HandleAccessorCall(expectedTargetDetails, method, target, Enumerable.ToList<TranslatedExpression>((IEnumerable<TranslatedExpression>)argumentList.Arguments), argumentList.ArgumentNames);
			}
			if (IsDelegateEqualityComparison(method, argumentList.Arguments))
			{
				argumentList.CheckNoNamedOrOptionalArguments();
				return HandleDelegateEqualityComparison(method, argumentList.Arguments).WithRR(new CSharpInvocationResolveResult(target.ResolveResult, method, Enumerable.ToList<ResolveResult>(argumentList.GetArgumentResolveResults()), OverloadResolutionErrors.None, isExtensionMethodInvocation: false, argumentList.IsExpandedForm));
			}
			if (method.IsOperator && method.Name == "op_Implicit" && argumentList.Length == 1)
			{
				argumentList.CheckNoNamedOrOptionalArguments();
				return HandleImplicitConversion(method, argumentList.Arguments[0]);
			}
			CallTransformation requiredTransformationsForCall = GetRequiredTransformationsForCall(expectedTargetDetails, method, ref target, ref argumentList, CallTransformation.All, out var foundMethod);
			if (!method.Equals(foundMethod) && argumentList.ParameterNames.Length >= foundMethod.Parameters.Count)
			{
				for (int num5 = 0; num5 < foundMethod.Parameters.Count; num5++)
				{
					argumentList.ParameterNames[num5] = foundMethod.Parameters[num5].Name;
				}
			}
			string name = method.Name;
			if ((requiredTransformationsForCall & CallTransformation.NoOptionalArgumentAllowed) != CallTransformation.None)
			{
				argumentList.FirstOptionalArgumentIndex = -1;
			}
			Expression expression;
			AstNodeCollection<AstType> typeArguments;
			if ((requiredTransformationsForCall & CallTransformation.RequireTarget) != CallTransformation.None)
			{
				expression = new MemberReferenceExpression(target.Expression, name);
				typeArguments = ((MemberReferenceExpression)expression).TypeArguments;
				if (method.IsExplicitInterfaceImplementation && (target.Expression is ThisReferenceExpression || settings.AlwaysCastTargetsOfExplicitInterfaceImplementationCalls))
				{
					IMember member = Enumerable.First<IMember>(method.ExplicitlyImplementedInterfaceMembers);
					CastExpression target2 = new CastExpression(expressionBuilder.ConvertType(member.DeclaringType), target.Expression);
					name = member.Name;
					expression = new MemberReferenceExpression(target2, name);
					typeArguments = ((MemberReferenceExpression)expression).TypeArguments;
				}
			}
			else
			{
				expression = new IdentifierExpression(name);
				typeArguments = ((IdentifierExpression)expression).TypeArguments;
			}
			if ((requiredTransformationsForCall & CallTransformation.RequireTypeArguments) != CallTransformation.None && (!settings.AnonymousTypes || !Enumerable.Any<IType>((IEnumerable<IType>)method.TypeArguments, (Func<IType, bool>)((IType a) => a.ContainsAnonymousType()))))
			{
				typeArguments.AddRange(Enumerable.Select<IType, AstType>((IEnumerable<IType>)method.TypeArguments, (Func<IType, AstType>)expressionBuilder.ConvertType));
			}
			return new InvocationExpression(expression, argumentList.GetArgumentExpressions()).WithRR(new CSharpInvocationResolveResult(target.ResolveResult, foundMethod, Enumerable.ToList<ResolveResult>(argumentList.GetArgumentResolveResults()), OverloadResolutionErrors.None, isExtensionMethodInvocation: false, argumentList.IsExpandedForm));
		}
		void UnpackSingleElementArray(ref TranslatedExpression reference)
		{
			if (unpackSingleElementArray)
			{
				ArrayCreateExpression arrayCreateExpression2 = (ArrayCreateExpression)argumentList.Arguments[1].Expression;
				ArrayCreateResolveResult arrayCreateResolveResult = (ArrayCreateResolveResult)argumentList.Arguments[1].ResolveResult;
				Expression expression2 = Enumerable.First<Expression>((IEnumerable<Expression>)arrayCreateExpression2.Initializer.Elements).Detach();
				reference = new TranslatedExpression(expression2, Enumerable.First<ResolveResult>((IEnumerable<ResolveResult>)arrayCreateResolveResult.InitializerElements));
			}
		}
	}

	public ExpressionWithResolveResult BuildCollectionInitializerExpression(OpCode callOpCode, IMethod method, InitializedObjectResolveResult target, IReadOnlyList<ILInstruction> callArguments)
	{
		ExpectedTargetDetails expectedTargetDetails = new ExpectedTargetDetails
		{
			CallOpCode = callOpCode
		};
		TranslatedExpression target2 = new IdentifierExpression("initializedObject").WithRR(target).WithoutILInstruction();
		List<ILInstruction> list = Enumerable.ToList<ILInstruction>((IEnumerable<ILInstruction>)callArguments);
		if (method.IsExtensionMethod)
		{
			list.Insert(0, new Nop());
		}
		ArgumentList argumentList = BuildArgumentList(expectedTargetDetails, target, method, 0, list, null);
		argumentList.ArgumentNames = null;
		argumentList.AddNamesToPrimitiveValues = false;
		CallTransformation requiredTransformationsForCall = GetRequiredTransformationsForCall(expectedTargetDetails, method, ref target2, ref argumentList, CallTransformation.None, out var _);
		Debug.Assert(requiredTransformationsForCall == CallTransformation.None || requiredTransformationsForCall == CallTransformation.NoOptionalArgumentAllowed);
		int skipCount;
		if (method.IsExtensionMethod)
		{
			if (argumentList.Arguments.Length == 2)
			{
				return argumentList.Arguments[1];
			}
			skipCount = 1;
		}
		else
		{
			if (argumentList.Arguments.Length == 1)
			{
				return argumentList.Arguments[0];
			}
			skipCount = 0;
		}
		if ((requiredTransformationsForCall & CallTransformation.NoOptionalArgumentAllowed) != CallTransformation.None)
		{
			argumentList.FirstOptionalArgumentIndex = -1;
		}
		return new ArrayInitializerExpression(argumentList.GetArgumentExpressions(skipCount)).WithRR(new CSharpInvocationResolveResult(target, method, Enumerable.ToArray<ResolveResult>(argumentList.GetArgumentResolveResults(skipCount)), OverloadResolutionErrors.None, method.IsExtensionMethod, argumentList.IsExpandedForm));
	}

	public ExpressionWithResolveResult BuildDictionaryInitializerExpression(OpCode callOpCode, IMethod method, InitializedObjectResolveResult target, IReadOnlyList<ILInstruction> indices, ILInstruction value = null)
	{
		ExpectedTargetDetails expectedTargetDetails = new ExpectedTargetDetails
		{
			CallOpCode = callOpCode
		};
		List<ILInstruction> list = new List<ILInstruction>();
		list.Add(new LdNull());
		list.AddRange(indices);
		list.Add(value ?? new Nop());
		ArgumentList argumentList = BuildArgumentList(expectedTargetDetails, target, method, 1, list, null);
		TranslatedExpression target2 = new IdentifierExpression("initializedObject").WithRR(target).WithoutILInstruction();
		ExpressionWithResolveResult expressionWithResolveResult = HandleAccessorCall(expectedTargetDetails, method, target2, Enumerable.ToList<TranslatedExpression>((IEnumerable<TranslatedExpression>)argumentList.Arguments), argumentList.ArgumentNames);
		if (value != null)
		{
			return expressionWithResolveResult;
		}
		return new ExpressionWithResolveResult(((AssignmentExpression)(Expression)expressionWithResolveResult).Left.Detach());
	}

	private static bool IsInterpolatedStringCreation(IMethod method, ArgumentList argumentList)
	{
		return method.IsStatic && ((method.DeclaringType.IsKnownType(KnownTypeCode.String) && method.Name == "Format") || (method.Name == "Create" && method.DeclaringType.Name == "FormattableStringFactory" && method.DeclaringType.Namespace == "System.Runtime.CompilerServices")) && argumentList.ArgumentNames == null && (argumentList.IsExpandedForm || !Enumerable.Last<IParameter>((IEnumerable<IParameter>)method.Parameters).IsParams || (argumentList.Length == 2 && argumentList.Arguments[1].Expression is ArrayCreateExpression));
	}

	private bool TryGetStringInterpolationTokens(ArgumentList argumentList, out string format, out List<(TokenKind, int, string)> tokens)
	{
		tokens = null;
		format = null;
		TranslatedExpression[] arguments = argumentList.Arguments;
		if (arguments.Length == 0 || argumentList.ArgumentNames != null || argumentList.ArgumentToParameterMap != null)
		{
			return false;
		}
		if (!(arguments[0].ResolveResult is ConstantResolveResult constantResolveResult) || !constantResolveResult.Type.IsKnownType(KnownTypeCode.String))
		{
			return false;
		}
		if (!Enumerable.All<TranslatedExpression>(Enumerable.Skip<TranslatedExpression>((IEnumerable<TranslatedExpression>)arguments, 1), (Func<TranslatedExpression, bool>)((TranslatedExpression a) => !Enumerable.Any<PrimitiveExpression>(Enumerable.OfType<PrimitiveExpression>((IEnumerable)a.Expression.DescendantsAndSelf), (Func<PrimitiveExpression, bool>)((PrimitiveExpression p) => p.Value is string)))))
		{
			return false;
		}
		tokens = new List<(TokenKind, int, string)>();
		int num = 0;
		format = (string)constantResolveResult.ConstantValue;
		checked
		{
			foreach (var (tokenKind, text) in TokenizeFormatString(format))
			{
				int result;
				switch (tokenKind)
				{
				case TokenKind.Error:
					return false;
				case TokenKind.String:
					tokens.Add((tokenKind, -1, text));
					break;
				case TokenKind.Argument:
					if (!int.TryParse(text, out result) || result != num)
					{
						return false;
					}
					num++;
					tokens.Add((tokenKind, result, null));
					break;
				case TokenKind.ArgumentWithFormat:
				{
					string[] array = text.Split(new char[1] { ':' }, 2);
					if (array.Length != 2 || array[1].Length == 0)
					{
						return false;
					}
					if (!int.TryParse(array[0], out result) || result != num)
					{
						return false;
					}
					num++;
					tokens.Add((tokenKind, result, array[1]));
					break;
				}
				default:
					return false;
				}
			}
			return num == arguments.Length - 1;
		}
	}

	private IEnumerable<(TokenKind, string)> TokenizeFormatString(string value)
	{
		int pos = -1;
		TokenKind kind = TokenKind.String;
		StringBuilder sb = new StringBuilder();
		while (true)
		{
			int num;
			int next = (num = Next());
			if (num <= -1)
			{
				break;
			}
			switch ((char)checked((ushort)next))
			{
			case '{':
				if (Peek(1) == 123)
				{
					kind = TokenKind.String;
					sb.Append("{{");
					Next();
					break;
				}
				if (sb.Length > 0)
				{
					yield return (kind, sb.ToString());
				}
				kind = TokenKind.Argument;
				sb.Clear();
				break;
			case '}':
				if (kind != TokenKind.String)
				{
					yield return (kind, sb.ToString());
					sb.Clear();
					kind = TokenKind.String;
				}
				else
				{
					sb.Append((char)checked((ushort)next));
				}
				break;
			case ':':
				if (kind == TokenKind.Argument)
				{
					kind = TokenKind.ArgumentWithFormat;
				}
				sb.Append(':');
				break;
			default:
				sb.Append((char)checked((ushort)next));
				break;
			}
		}
		if (sb.Length > 0)
		{
			if (kind == TokenKind.String)
			{
				yield return (kind, sb.ToString());
			}
			else
			{
				yield return (TokenKind.Error, null);
			}
		}
		int Next()
		{
			int result = Peek(1);
			checked
			{
				pos++;
				return result;
			}
		}
		int Peek(int steps)
		{
			checked
			{
				if (pos + steps < value.Length)
				{
					return value[pos + steps];
				}
				return -1;
			}
		}
	}

	private ArgumentList BuildArgumentList(ExpectedTargetDetails expectedTargetDetails, ResolveResult target, IMethod method, int firstParamIndex, IReadOnlyList<ILInstruction> callArguments, IReadOnlyList<int> argumentToParameterMap)
	{
		ArgumentList result = default(ArgumentList);
		List<TranslatedExpression> arguments = new List<TranslatedExpression>(method.Parameters.Count);
		string[] array = null;
		checked
		{
			Debug.Assert(callArguments.Count == firstParamIndex + method.Parameters.Count);
			List<IParameter> expectedParameters = new List<IParameter>(method.Parameters.Count);
			bool isExpandedForm = false;
			BitSet bitSet = new BitSet(method.Parameters.Count);
			int num = (expressionBuilder.settings.OptionalArguments ? (-2) : (-1));
			for (int i = firstParamIndex; i < callArguments.Count; i++)
			{
				IParameter parameter;
				if (argumentToParameterMap != null)
				{
					if (array == null && argumentToParameterMap[i] != i - firstParamIndex)
					{
						array = new string[method.Parameters.Count];
					}
					parameter = method.Parameters[argumentToParameterMap[i]];
					if (array != null)
					{
						array[arguments.Count] = parameter.Name;
					}
				}
				else
				{
					parameter = method.Parameters[i - firstParamIndex];
				}
				TranslatedExpression arg = expressionBuilder.Translate(callArguments[i], parameter.Type);
				if (IsPrimitiveValueThatShouldBeNamedArgument(arg, method, parameter))
				{
					bitSet.Set(arguments.Count);
				}
				if (IsOptionalArgument(parameter, arg))
				{
					if (num == -2)
					{
						num = i - firstParamIndex;
					}
				}
				else
				{
					num = -2;
				}
				if (parameter.IsParams && i + 1 == callArguments.Count && argumentToParameterMap == null && TransformParamsArgument(expectedTargetDetails, target, method, parameter, arg, ref expectedParameters, ref arguments))
				{
					Debug.Assert(array == null);
					num = -1;
					isExpandedForm = true;
					continue;
				}
				IType targetType = ((parameter.Type.Kind != TypeKind.Dynamic) ? parameter.Type : expressionBuilder.compilation.FindType(KnownTypeCode.Object));
				arg = arg.ConvertTo(targetType, expressionBuilder, checkForOverflow: false, arg.Type.Kind != TypeKind.Dynamic);
				if (parameter.IsOut)
				{
					arg = ExpressionBuilder.ChangeDirectionExpressionToOut(arg);
				}
				arguments.Add(arg);
				expectedParameters.Add(parameter);
			}
			result.ExpectedParameters = expectedParameters.ToArray();
			result.Arguments = arguments.ToArray();
			result.ParameterNames = expectedParameters.SelectArray((IParameter p) => p.Name);
			result.ArgumentNames = array;
			result.ArgumentToParameterMap = argumentToParameterMap;
			result.IsExpandedForm = isExpandedForm;
			result.IsPrimitiveValue = bitSet;
			result.FirstOptionalArgumentIndex = num;
			result.AddNamesToPrimitiveValues = expressionBuilder.settings.NamedArguments && expressionBuilder.settings.NonTrailingNamedArguments;
			return result;
		}
	}

	private bool IsPrimitiveValueThatShouldBeNamedArgument(TranslatedExpression arg, IMethod method, IParameter p)
	{
		if (!arg.ResolveResult.IsCompileTimeConstant || method.DeclaringType.IsKnownType(KnownTypeCode.NullableOfT))
		{
			return false;
		}
		return p.Type.IsKnownType(KnownTypeCode.Boolean);
	}

	private bool TransformParamsArgument(ExpectedTargetDetails expectedTargetDetails, ResolveResult targetResolveResult, IMethod method, IParameter parameter, TranslatedExpression arg, ref List<IParameter> expectedParameters, ref List<TranslatedExpression> arguments)
	{
		if (CheckArgument(out var len, out var t))
		{
			List<IParameter> list = new List<IParameter>(expectedParameters);
			List<TranslatedExpression> list2 = new List<TranslatedExpression>(arguments);
			if (len > 0)
			{
				Expression[] array = Enumerable.ToArray<Expression>((IEnumerable<Expression>)((ArrayCreateExpression)arg.Expression).Initializer.Elements);
				for (int i = 0; i < len; i = checked(i + 1))
				{
					list.Add(new DefaultParameter(t, parameter.Name + i));
					if (i < array.Length)
					{
						list2.Add(new TranslatedExpression(array[i]));
					}
					else
					{
						list2.Add(expressionBuilder.GetDefaultValueExpression(t).WithoutILInstruction());
					}
				}
			}
			if ((IsUnambiguousCall(expectedTargetDetails, method, targetResolveResult, Empty<IType>.Array, list2, null, -1, out var _, out var bestCandidateIsExpandedForm) == OverloadResolutionErrors.None) & bestCandidateIsExpandedForm)
			{
				expectedParameters = list;
				arguments = list2.SelectList((TranslatedExpression a) => new TranslatedExpression(a.Expression.Detach()));
				return true;
			}
		}
		return false;
		bool CheckArgument(out int reference, out IType reference2)
		{
			reference = 0;
			reference2 = null;
			if (arg.ResolveResult is CSharpInvocationResolveResult cSharpInvocationResolveResult && cSharpInvocationResolveResult.Arguments.Count == 0 && cSharpInvocationResolveResult.Member is IMethod { IsStatic: not false } method2 && "System.Array.Empty" == method2.FullName && method2.TypeArguments.Count == 1)
			{
				reference2 = method2.TypeArguments[0];
				return true;
			}
			if (arg.ResolveResult is ArrayCreateResolveResult arrayCreateResolveResult && arrayCreateResolveResult.SizeArguments.Count == 1 && arrayCreateResolveResult.SizeArguments[0].IsCompileTimeConstant && arrayCreateResolveResult.SizeArguments[0].ConstantValue is int num)
			{
				reference = num;
				reference2 = ((ArrayType)arrayCreateResolveResult.Type).ElementType;
				return true;
			}
			return false;
		}
	}

	private bool IsOptionalArgument(IParameter parameter, TranslatedExpression arg)
	{
		if (!parameter.IsOptional || !arg.ResolveResult.IsCompileTimeConstant)
		{
			return false;
		}
		if (Enumerable.Any<IAttribute>(parameter.GetAttributes(), (Func<IAttribute, bool>)((IAttribute a) => a.AttributeType.IsKnownType(KnownAttribute.CallerMemberName) || a.AttributeType.IsKnownType(KnownAttribute.CallerFilePath) || a.AttributeType.IsKnownType(KnownAttribute.CallerLineNumber))))
		{
			return false;
		}
		return object.Equals(parameter.GetConstantValue(), arg.ResolveResult.ConstantValue);
	}

	private CallTransformation GetRequiredTransformationsForCall(ExpectedTargetDetails expectedTargetDetails, IMethod method, ref TranslatedExpression target, ref ArgumentList argumentList, CallTransformation allowedTransforms, out IParameterizedMember foundMethod)
	{
		CallTransformation callTransformation = CallTransformation.None;
		bool flag;
		ResolveResult target2;
		if ((allowedTransforms & CallTransformation.RequireTarget) != CallTransformation.None)
		{
			flag = expressionBuilder.HidesVariableWithName(method.Name) || (method.IsStatic ? (!expressionBuilder.IsCurrentOrContainingType(method.DeclaringTypeDefinition) || method.Name == ".cctor") : (method.Name == ".ctor" || ((!(target.Expression is BaseReferenceExpression)) ? (!(target.Expression is ThisReferenceExpression)) : (expectedTargetDetails.CallOpCode != OpCode.CallVirt && method.IsVirtual))));
			target2 = (flag ? target.ResolveResult : null);
		}
		else
		{
			flag = true;
			target2 = target.ResolveResult;
		}
		bool flag2 = false;
		bool flag3;
		IType[] typeArguments;
		if (method.TypeParameters.Count > 0 && (allowedTransforms & CallTransformation.RequireTypeArguments) != CallTransformation.None && !IsPossibleExtensionMethodCallOnNull(method, argumentList.Arguments))
		{
			if (!CanInferTypeArgumentsFromParameters(method, argumentList.Arguments.SelectArray((TranslatedExpression a) => a.ResolveResult), expressionBuilder.typeInference))
			{
				flag3 = true;
				typeArguments = Enumerable.ToArray<IType>((IEnumerable<IType>)method.TypeArguments);
				flag2 = true;
			}
			else
			{
				flag3 = false;
				typeArguments = Empty<IType>.Array;
			}
		}
		else
		{
			flag3 = false;
			typeArguments = Empty<IType>.Array;
		}
		bool flag4 = false;
		bool flag5 = false;
		OverloadResolutionErrors overloadResolutionErrors;
		bool bestCandidateIsExpandedForm;
		while ((overloadResolutionErrors = IsUnambiguousCall(expectedTargetDetails, method, target2, typeArguments, argumentList.Arguments, argumentList.ArgumentNames, argumentList.FirstOptionalArgumentIndex, out foundMethod, out bestCandidateIsExpandedForm)) != OverloadResolutionErrors.None || bestCandidateIsExpandedForm != argumentList.IsExpandedForm)
		{
			OverloadResolutionErrors overloadResolutionErrors2 = overloadResolutionErrors;
			if (overloadResolutionErrors2 != OverloadResolutionErrors.TypeInferenceFailed)
			{
				if (overloadResolutionErrors2 == OverloadResolutionErrors.WrongNumberOfTypeArguments)
				{
					goto IL_01f8;
				}
				if (overloadResolutionErrors2 == OverloadResolutionErrors.MissingArgumentForRequiredParameter && argumentList.FirstOptionalArgumentIndex != -1)
				{
					argumentList.FirstOptionalArgumentIndex = -1;
					continue;
				}
			}
			else if ((allowedTransforms & CallTransformation.RequireTypeArguments) != CallTransformation.None)
			{
				goto IL_01f8;
			}
			goto IL_0241;
			IL_0241:
			if (argumentList.FirstOptionalArgumentIndex >= 0)
			{
				argumentList.FirstOptionalArgumentIndex = -1;
			}
			else if (!flag5)
			{
				if (flag2)
				{
					flag3 = false;
					typeArguments = Empty<IType>.Array;
					flag2 = false;
				}
				flag5 = true;
				CastArguments(argumentList.Arguments, argumentList.ExpectedParameters);
			}
			else if ((allowedTransforms & CallTransformation.RequireTarget) != CallTransformation.None && !flag)
			{
				flag = true;
				target2 = target.ResolveResult;
			}
			else if ((allowedTransforms & CallTransformation.RequireTarget) != CallTransformation.None && !flag4)
			{
				flag4 = true;
				target = target.ConvertTo(method.DeclaringType, expressionBuilder);
				target2 = target.ResolveResult;
			}
			else
			{
				if ((allowedTransforms & CallTransformation.RequireTypeArguments) == 0 || flag3)
				{
					foundMethod = method;
					break;
				}
				flag3 = true;
				typeArguments = Enumerable.ToArray<IType>((IEnumerable<IType>)method.TypeArguments);
			}
			continue;
			IL_01f8:
			Debug.Assert((allowedTransforms & CallTransformation.RequireTypeArguments) != 0);
			if (flag3)
			{
				goto IL_0241;
			}
			flag3 = true;
			typeArguments = Enumerable.ToArray<IType>((IEnumerable<IType>)method.TypeArguments);
		}
		if (((allowedTransforms & CallTransformation.RequireTarget) != 0) & flag)
		{
			callTransformation |= CallTransformation.RequireTarget;
		}
		if (((allowedTransforms & CallTransformation.RequireTypeArguments) != 0) & flag3)
		{
			callTransformation |= CallTransformation.RequireTypeArguments;
		}
		if (argumentList.FirstOptionalArgumentIndex < 0)
		{
			callTransformation |= CallTransformation.NoOptionalArgumentAllowed;
		}
		return callTransformation;
	}

	private bool IsPossibleExtensionMethodCallOnNull(IMethod method, IList<TranslatedExpression> arguments)
	{
		return method.IsExtensionMethod && arguments.Count > 0 && arguments[0].Expression is NullReferenceExpression;
	}

	public static bool CanInferTypeArgumentsFromParameters(IMethod method, IReadOnlyList<ResolveResult> arguments, TypeInference typeInference)
	{
		if (method.TypeParameters.Count == 0)
		{
			return true;
		}
		method = (IMethod)method.MemberDefinition;
		typeInference.InferTypeArguments(method.TypeParameters, arguments, method.Parameters.SelectReadOnlyArray((IParameter p) => p.Type), out var success);
		return success;
	}

	private void CastArguments(IList<TranslatedExpression> arguments, IList<IParameter> expectedParameters)
	{
		for (int i = 0; i < arguments.Count; i = checked(i + 1))
		{
			if (settings.AnonymousTypes && expectedParameters[i].Type.ContainsAnonymousType())
			{
				if (arguments[i].Expression is LambdaExpression lambda)
				{
					ModifyReturnTypeOfLambda(lambda);
				}
			}
			else
			{
				IType targetType = ((expectedParameters[i].Type.Kind != TypeKind.Dynamic) ? expectedParameters[i].Type : expressionBuilder.compilation.FindType(KnownTypeCode.Object));
				arguments[i] = arguments[i].ConvertTo(targetType, expressionBuilder);
			}
		}
	}

	private static bool IsNullConditional(Expression expr)
	{
		return expr is UnaryOperatorExpression unaryOperatorExpression && unaryOperatorExpression.Operator == UnaryOperatorType.NullConditional;
	}

	private void ModifyReturnTypeOfLambda(LambdaExpression lambda)
	{
		DecompiledLambdaResolveResult decompiledLambdaResolveResult = (DecompiledLambdaResolveResult)lambda.GetResolveResult();
		if (lambda.Body is Expression node)
		{
			lambda.Body = (Expression)new TranslatedExpression(node.Detach()).ConvertTo(decompiledLambdaResolveResult.ReturnType, expressionBuilder);
		}
		else
		{
			ModifyReturnStatementInsideLambda(decompiledLambdaResolveResult.ReturnType, lambda);
		}
		decompiledLambdaResolveResult.InferredReturnType = decompiledLambdaResolveResult.ReturnType;
	}

	private void ModifyReturnStatementInsideLambda(IType returnType, AstNode parent)
	{
		foreach (AstNode child in parent.Children)
		{
			if (!(child is LambdaExpression) && !(child is AnonymousMethodExpression))
			{
				if (child is ReturnStatement returnStatement)
				{
					returnStatement.Expression = new TranslatedExpression(returnStatement.Expression.Detach()).ConvertTo(returnType, expressionBuilder);
				}
				else
				{
					ModifyReturnStatementInsideLambda(returnType, child);
				}
			}
		}
	}

	private bool IsDelegateEqualityComparison(IMethod method, IList<TranslatedExpression> arguments)
	{
		return method.IsOperator && method.DeclaringType.IsKnownType(KnownTypeCode.Delegate) && (method.Name == "op_Equality" || method.Name == "op_Inequality") && arguments.Count == 2 && arguments[0].Type.Kind == TypeKind.Delegate && arguments[1].Type.Equals(arguments[0].Type);
	}

	private Expression HandleDelegateEqualityComparison(IMethod method, IList<TranslatedExpression> arguments)
	{
		return new BinaryOperatorExpression(arguments[0], (method.Name == "op_Equality") ? BinaryOperatorType.Equality : BinaryOperatorType.InEquality, arguments[1]);
	}

	private ExpressionWithResolveResult HandleImplicitConversion(IMethod method, TranslatedExpression argument)
	{
		CSharpConversions cSharpConversions = CSharpConversions.Get(expressionBuilder.compilation);
		IType returnType = method.ReturnType;
		Conversion conversion = cSharpConversions.ImplicitConversion(argument.Type, returnType);
		if (!conversion.IsUserDefined || !conversion.Method.Equals(method))
		{
			argument = argument.ConvertTo(method.Parameters[0].Type, expressionBuilder);
			conversion = cSharpConversions.ImplicitConversion(argument.Type, returnType);
		}
		return new CastExpression(expressionBuilder.ConvertType(returnType), argument.Expression).WithRR(new ConversionResolveResult(returnType, argument.ResolveResult, conversion));
	}

	private OverloadResolutionErrors IsUnambiguousCall(ExpectedTargetDetails expectedTargetDetails, IMethod method, ResolveResult target, IType[] typeArguments, IList<TranslatedExpression> arguments, string[] argumentNames, int firstOptionalArgumentIndex, out IParameterizedMember foundMember, out bool bestCandidateIsExpandedForm)
	{
		foundMember = null;
		bestCandidateIsExpandedForm = false;
		MemberLookup memberLookup = new MemberLookup(resolver.CurrentTypeDefinition, resolver.CurrentTypeDefinition.ParentModule);
		OverloadResolution overloadResolution = new OverloadResolution(resolver.Compilation, (firstOptionalArgumentIndex < 0) ? arguments.SelectArray((TranslatedExpression a) => a.ResolveResult) : Enumerable.ToArray<ResolveResult>(Enumerable.Select<TranslatedExpression, ResolveResult>(Enumerable.Take<TranslatedExpression>((IEnumerable<TranslatedExpression>)arguments, firstOptionalArgumentIndex), (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult))), (firstOptionalArgumentIndex < 0 || argumentNames == null) ? argumentNames : Enumerable.ToArray<string>(Enumerable.Take<string>((IEnumerable<string>)argumentNames, firstOptionalArgumentIndex)), typeArguments, expressionBuilder.resolver.conversions);
		if (expectedTargetDetails.CallOpCode == OpCode.NewObj)
		{
			foreach (IMethod constructor in method.DeclaringType.GetConstructors())
			{
				if (memberLookup.IsAccessible(constructor, resolver.CurrentTypeDefinition == method.DeclaringTypeDefinition))
				{
					overloadResolution.AddCandidate(constructor);
				}
			}
		}
		else if (method.IsOperator)
		{
			IEnumerable<IParameterizedMember> enumerable;
			if (arguments.Count == 1)
			{
				enumerable = resolver.GetUserDefinedOperatorCandidates(arguments[0].Type, method.Name);
			}
			else if (arguments.Count == 2)
			{
				HashSet<IParameterizedMember> val = new HashSet<IParameterizedMember>();
				val.UnionWith(resolver.GetUserDefinedOperatorCandidates(arguments[0].Type, method.Name));
				val.UnionWith(resolver.GetUserDefinedOperatorCandidates(arguments[1].Type, method.Name));
				enumerable = (IEnumerable<IParameterizedMember>)val;
			}
			else
			{
				enumerable = EmptyList<IParameterizedMember>.Instance;
			}
			foreach (IParameterizedMember item in enumerable)
			{
				overloadResolution.AddCandidate(item);
			}
		}
		else if (target == null)
		{
			if (!(resolver.ResolveSimpleName(method.Name, typeArguments, isInvocationTarget: true) is MethodGroupResolveResult methodGroupResolveResult))
			{
				return OverloadResolutionErrors.AmbiguousMatch;
			}
			overloadResolution.AddMethodLists(Enumerable.ToArray<MethodListWithDeclaringType>(methodGroupResolveResult.MethodsGroupedByDeclaringType));
		}
		else
		{
			if (!(memberLookup.Lookup(target, method.Name, typeArguments, isInvocation: true) is MethodGroupResolveResult methodGroupResolveResult2))
			{
				return OverloadResolutionErrors.AmbiguousMatch;
			}
			overloadResolution.AddMethodLists(Enumerable.ToArray<MethodListWithDeclaringType>(methodGroupResolveResult2.MethodsGroupedByDeclaringType));
		}
		bestCandidateIsExpandedForm = overloadResolution.BestCandidateIsExpandedForm;
		if (overloadResolution.BestCandidateErrors != OverloadResolutionErrors.None)
		{
			return overloadResolution.BestCandidateErrors;
		}
		if (overloadResolution.IsAmbiguous)
		{
			return OverloadResolutionErrors.AmbiguousMatch;
		}
		foundMember = overloadResolution.GetBestCandidateWithSubstitutedTypeArguments();
		if (!IsAppropriateCallTarget(expectedTargetDetails, method, foundMember))
		{
			return OverloadResolutionErrors.AmbiguousMatch;
		}
		return OverloadResolutionErrors.None;
	}

	private bool IsUnambiguousAccess(ExpectedTargetDetails expectedTargetDetails, ResolveResult target, IMethod method, IList<TranslatedExpression> arguments, string[] argumentNames, out IMember foundMember)
	{
		foundMember = null;
		if (target == null)
		{
			if (!(resolver.ResolveSimpleName(method.AccessorOwner.Name, EmptyList<IType>.Instance) is MemberResolveResult { IsError: false } memberResolveResult))
			{
				return false;
			}
			foundMember = memberResolveResult.Member;
		}
		else
		{
			MemberLookup memberLookup = new MemberLookup(resolver.CurrentTypeDefinition, resolver.CurrentTypeDefinition.ParentModule);
			if (method.AccessorOwner.SymbolKind == SymbolKind.Indexer)
			{
				OverloadResolution overloadResolution = new OverloadResolution(resolver.Compilation, arguments.SelectArray((TranslatedExpression a) => a.ResolveResult), argumentNames, Empty<IType>.Array, expressionBuilder.resolver.conversions);
				overloadResolution.AddMethodLists(memberLookup.LookupIndexers(target));
				if (overloadResolution.BestCandidateErrors != OverloadResolutionErrors.None)
				{
					return false;
				}
				if (overloadResolution.IsAmbiguous)
				{
					return false;
				}
				foundMember = overloadResolution.GetBestCandidateWithSubstitutedTypeArguments();
			}
			else
			{
				if (!(memberLookup.Lookup(target, method.AccessorOwner.Name, EmptyList<IType>.Instance, isInvocation: false) is MemberResolveResult { IsError: false } memberResolveResult2))
				{
					return false;
				}
				foundMember = memberResolveResult2.Member;
			}
		}
		return foundMember != null && IsAppropriateCallTarget(expectedTargetDetails, method.AccessorOwner, foundMember);
	}

	private ExpressionWithResolveResult HandleAccessorCall(ExpectedTargetDetails expectedTargetDetails, IMethod method, TranslatedExpression target, List<TranslatedExpression> arguments, string[] argumentNames)
	{
		bool flag = method.AccessorOwner.SymbolKind == SymbolKind.Indexer || expressionBuilder.HidesVariableWithName(method.AccessorOwner.Name) || ((!method.IsStatic) ? (!(target.Expression is ThisReferenceExpression)) : (!expressionBuilder.IsCurrentOrContainingType(method.DeclaringTypeDefinition)));
		bool flag2 = false;
		bool flag3 = method.ReturnType.IsKnownType(KnownTypeCode.Void);
		bool flag4 = (flag3 && method.Parameters.Count == 1) || (!flag3 && method.Parameters.Count == 0);
		ResolveResult target2 = (flag ? target.ResolveResult : null);
		TranslatedExpression item = default(TranslatedExpression);
		if (flag3)
		{
			item = arguments.Last();
			arguments.Remove(item);
		}
		IMember foundMember;
		while (!IsUnambiguousAccess(expectedTargetDetails, target2, method, arguments, argumentNames, out foundMember))
		{
			if (!flag4)
			{
				flag4 = true;
				CastArguments(arguments, Enumerable.ToList<IParameter>((IEnumerable<IParameter>)method.Parameters));
				continue;
			}
			if (!flag)
			{
				flag = true;
				target2 = target.ResolveResult;
				continue;
			}
			if (!flag2)
			{
				flag2 = true;
				target = target.ConvertTo(method.AccessorOwner.DeclaringType, expressionBuilder);
				target2 = target.ResolveResult;
				continue;
			}
			foundMember = method.AccessorOwner;
			break;
		}
		MemberResolveResult resolveResult = new MemberResolveResult(target.ResolveResult, foundMember);
		if (flag3)
		{
			TranslatedExpression translatedExpression = ((arguments.Count != 0) ? new IndexerExpression((target.ResolveResult is InitializedObjectResolveResult) ? null : target.Expression, Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)arguments, (Func<TranslatedExpression, Expression>)((TranslatedExpression a) => a.Expression))).WithoutILInstruction().WithRR(resolveResult) : ((!flag) ? new IdentifierExpression(method.AccessorOwner.Name).WithoutILInstruction().WithRR(resolveResult) : new MemberReferenceExpression(target.Expression, method.AccessorOwner.Name).WithoutILInstruction().WithRR(resolveResult)));
			AssignmentOperatorType op = AssignmentOperatorType.Assign;
			if (method.AccessorOwner is IEvent obj)
			{
				if (method.Equals(obj.AddAccessor))
				{
					op = AssignmentOperatorType.Add;
				}
				if (method.Equals(obj.RemoveAccessor))
				{
					op = AssignmentOperatorType.Subtract;
				}
			}
			return new AssignmentExpression(translatedExpression, op, item.Expression).WithRR(new TypeResolveResult(method.AccessorOwner.ReturnType));
		}
		if (arguments.Count != 0)
		{
			return new IndexerExpression(target.Expression, Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)arguments, (Func<TranslatedExpression, Expression>)((TranslatedExpression a) => a.Expression))).WithoutILInstruction().WithRR(resolveResult);
		}
		if (flag)
		{
			return new MemberReferenceExpression(target.Expression, method.AccessorOwner.Name).WithoutILInstruction().WithRR(resolveResult);
		}
		return new IdentifierExpression(method.AccessorOwner.Name).WithoutILInstruction().WithRR(resolveResult);
	}

	private bool IsAppropriateCallTarget(ExpectedTargetDetails expectedTargetDetails, IMember expectedTarget, IMember actualTarget)
	{
		if (expectedTarget.Equals(actualTarget, NormalizeTypeVisitor.TypeErasure))
		{
			return true;
		}
		if (expectedTargetDetails.CallOpCode == OpCode.CallVirt && actualTarget.IsOverride)
		{
			if (expectedTargetDetails.NeedsBoxingConversion && actualTarget.DeclaringType.IsReferenceType != true)
			{
				return false;
			}
			foreach (IMember baseMember in InheritanceHelper.GetBaseMembers(actualTarget, includeImplementedInterfaces: false))
			{
				if (expectedTarget.Equals(baseMember, NormalizeTypeVisitor.TypeErasure))
				{
					return true;
				}
				if (!baseMember.IsOverride)
				{
					break;
				}
			}
		}
		return false;
	}

	private ExpressionWithResolveResult HandleConstructorCall(ExpectedTargetDetails expectedTargetDetails, ResolveResult target, IMethod method, ArgumentList argumentList)
	{
		if (settings.AnonymousTypes && method.DeclaringType.IsAnonymousType())
		{
			Debug.Assert(argumentList.ArgumentToParameterMap == null && argumentList.ArgumentNames == null && argumentList.FirstOptionalArgumentIndex < 0);
			AnonymousTypeCreateExpression anonymousTypeCreateExpression = new AnonymousTypeCreateExpression();
			if (argumentList.CanInferAnonymousTypePropertyNamesFromArguments())
			{
				anonymousTypeCreateExpression.Initializers.AddRange(argumentList.GetArgumentExpressions());
			}
			else
			{
				for (int i = 0; i < argumentList.Length; i = checked(i + 1))
				{
					anonymousTypeCreateExpression.Initializers.Add(new NamedExpression
					{
						Name = argumentList.ExpectedParameters[i].Name,
						Expression = argumentList.Arguments[i].ConvertTo(argumentList.ExpectedParameters[i].Type, expressionBuilder)
					});
				}
			}
			return anonymousTypeCreateExpression.WithRR(new CSharpInvocationResolveResult(target, method, Enumerable.ToList<ResolveResult>(argumentList.GetArgumentResolveResults()), OverloadResolutionErrors.None, isExtensionMethodInvocation: false, argumentList.IsExpandedForm, isDelegateInvocation: false, argumentList.ArgumentToParameterMap));
		}
		IParameterizedMember foundMember;
		bool bestCandidateIsExpandedForm;
		while (IsUnambiguousCall(expectedTargetDetails, method, null, Empty<IType>.Array, argumentList.Arguments, argumentList.ArgumentNames, argumentList.FirstOptionalArgumentIndex, out foundMember, out bestCandidateIsExpandedForm) != OverloadResolutionErrors.None || bestCandidateIsExpandedForm != argumentList.IsExpandedForm)
		{
			if (argumentList.FirstOptionalArgumentIndex >= 0)
			{
				argumentList.FirstOptionalArgumentIndex = -1;
				continue;
			}
			CastArguments(argumentList.Arguments, argumentList.ExpectedParameters);
			break;
		}
		return new ObjectCreateExpression(expressionBuilder.ConvertType(method.DeclaringType), argumentList.GetArgumentExpressions()).WithRR(new CSharpInvocationResolveResult(target, method, Enumerable.ToArray<ResolveResult>(argumentList.GetArgumentResolveResults()), OverloadResolutionErrors.None, isExtensionMethodInvocation: false, argumentList.IsExpandedForm, isDelegateInvocation: false, argumentList.ArgumentToParameterMap));
	}

	private TranslatedExpression HandleDelegateConstruction(CallInstruction inst)
	{
		ILInstruction iLInstruction = inst.Arguments[0];
		ILInstruction iLInstruction2 = inst.Arguments[1];
		IMethod method = iLInstruction2.OpCode switch
		{
			OpCode.LdFtn => ((LdFtn)iLInstruction2).Method, 
			OpCode.LdVirtFtn => ((LdVirtFtn)iLInstruction2).Method, 
			_ => throw new ArgumentException($"Unknown instruction type: {iLInstruction2.OpCode}"), 
		};
		IMethod delegateInvokeMethod = inst.Method.DeclaringType.GetDelegateInvokeMethod();
		IType type;
		TranslatedExpression translatedExpression;
		bool flag;
		if (method.IsExtensionMethod && delegateInvokeMethod != null && checked(method.Parameters.Count - 1) == delegateInvokeMethod.Parameters.Count)
		{
			type = method.Parameters[0].Type;
			if (type.Kind == TypeKind.ByReference && iLInstruction is Box box)
			{
				type = ((ByReferenceType)type).ElementType;
				iLInstruction = box.Argument;
			}
			translatedExpression = expressionBuilder.Translate(iLInstruction, type);
			flag = true;
		}
		else
		{
			type = method.DeclaringType;
			if (type.IsReferenceType == false && iLInstruction is Box box2)
			{
				iLInstruction = ((!(box2.Argument is LdObj ldObj)) ? new AddressOf(box2.Argument) : ldObj.Target);
			}
			translatedExpression = expressionBuilder.TranslateTarget(iLInstruction, iLInstruction2.OpCode == OpCode.LdFtn, method.IsStatic, method.DeclaringType);
			flag = expressionBuilder.HidesVariableWithName(method.Name) || (method.IsStatic ? (!expressionBuilder.IsCurrentOrContainingType(method.DeclaringTypeDefinition)) : (!(translatedExpression.Expression is ThisReferenceExpression)));
		}
		ExpectedTargetDetails expectedTargetDetails = new ExpectedTargetDetails
		{
			CallOpCode = inst.OpCode
		};
		bool flag2 = false;
		ResolveResult resolveResult = null;
		ICompilation compilation = resolver.Compilation;
		ResolveResult[] arguments = method.Parameters.SelectReadOnlyArray((IParameter p) => new TypeResolveResult(p.Type));
		OverloadResolution overloadResolution = new OverloadResolution(compilation, arguments);
		if (!flag)
		{
			resolveResult = resolver.ResolveSimpleName(method.Name, method.TypeArguments);
			if (resolveResult is MethodGroupResolveResult methodGroupResolveResult)
			{
				overloadResolution.AddMethodLists(Enumerable.ToArray<MethodListWithDeclaringType>(methodGroupResolveResult.MethodsGroupedByDeclaringType));
				flag = overloadResolution.BestCandidateErrors != OverloadResolutionErrors.None || !IsAppropriateCallTarget(expectedTargetDetails, method, overloadResolution.BestCandidate);
			}
			else
			{
				flag = true;
			}
		}
		MemberLookup memberLookup = null;
		if (flag)
		{
			memberLookup = new MemberLookup(resolver.CurrentTypeDefinition, resolver.CurrentTypeDefinition.ParentModule);
			ResolveResult resolveResult2 = memberLookup.Lookup(translatedExpression.ResolveResult, method.Name, method.TypeArguments, isInvocation: false);
			flag2 = true;
			resolveResult = resolveResult2;
			if (resolveResult2 is MethodGroupResolveResult methodGroupResolveResult2)
			{
				overloadResolution.AddMethodLists(Enumerable.ToArray<MethodListWithDeclaringType>(methodGroupResolveResult2.MethodsGroupedByDeclaringType));
				flag2 = overloadResolution.BestCandidateErrors != OverloadResolutionErrors.None || !IsAppropriateCallTarget(expectedTargetDetails, method, overloadResolution.BestCandidate);
			}
		}
		if (flag2)
		{
			Debug.Assert(flag);
			translatedExpression = translatedExpression.ConvertTo(type, expressionBuilder);
			resolveResult = memberLookup.Lookup(translatedExpression.ResolveResult, method.Name, method.TypeArguments, isInvocation: false);
		}
		Expression expression;
		if (flag)
		{
			MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(translatedExpression, method.Name);
			memberReferenceExpression.TypeArguments.AddRange(Enumerable.Select<IType, AstType>((IEnumerable<IType>)method.TypeArguments, (Func<IType, AstType>)expressionBuilder.ConvertType));
			memberReferenceExpression.WithRR(resolveResult);
			expression = memberReferenceExpression;
		}
		else
		{
			ExpressionWithResolveResult expressionWithResolveResult = new IdentifierExpression(method.Name).WithRR(resolveResult);
			expression = expressionWithResolveResult;
		}
		return new ObjectCreateExpression(expressionBuilder.ConvertType(inst.Method.DeclaringType), expression).WithILInstruction(inst).WithRR(new ConversionResolveResult(inst.Method.DeclaringType, new MemberResolveResult(translatedExpression.ResolveResult, method), Conversion.MethodGroupConversion(method, iLInstruction2.OpCode == OpCode.LdVirtFtn, delegateCapturesFirstArgument: false)));
	}

	internal TranslatedExpression CallWithNamedArgs(Block block)
	{
		Debug.Assert(block.Kind == BlockKind.CallWithNamedArgs);
		CallInstruction callInstruction = (CallInstruction)block.FinalInstruction;
		ILInstruction[] array = new ILInstruction[callInstruction.Arguments.Count];
		int[] array2 = new int[array.Length];
		int num = (callInstruction.IsInstanceCall ? 1 : 0);
		int num2 = 0;
		checked
		{
			foreach (StLoc instruction in block.Instructions)
			{
				Debug.Assert(Enumerable.Single<LdLoc>((IEnumerable<LdLoc>)instruction.Variable.LoadInstructions).Parent == callInstruction);
				array[num2] = instruction.Value;
				array2[num2] = Enumerable.Single<LdLoc>((IEnumerable<LdLoc>)instruction.Variable.LoadInstructions).ChildIndex - num;
				num2++;
			}
			foreach (ILInstruction argument in callInstruction.Arguments)
			{
				if (!argument.MatchLdLoc(out var variable) || variable.Kind != VariableKind.NamedArgument)
				{
					array[num2] = argument;
					array2[num2] = argument.ChildIndex - num;
					num2++;
				}
			}
			Debug.Assert(num2 == array.Length);
			return Build(callInstruction.OpCode, callInstruction.Method, array, array2, callInstruction.ConstrainedTo).WithILInstruction(callInstruction).WithILInstruction(block);
		}
	}
}
