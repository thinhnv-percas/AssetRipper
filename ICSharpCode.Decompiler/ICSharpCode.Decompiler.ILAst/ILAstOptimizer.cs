using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.Decompiler.ILAst;

public class ILAstOptimizer
{
	private sealed class PatternMatcher
	{
		private abstract class Pattern
		{
			public readonly Pattern[] Arguments;

			protected Pattern(Pattern[] arguments)
			{
				Arguments = arguments;
			}

			public virtual bool Match(PatternMatcher pm, ILExpression e)
			{
				if (e.Arguments.Count != Arguments.Length || e.Prefixes != null)
				{
					return false;
				}
				for (int i = 0; i < Arguments.Length; i++)
				{
					if (!Arguments[i].Match(pm, e.Arguments[i]))
					{
						return false;
					}
				}
				return true;
			}

			public virtual ILExpression BuildNew(PatternMatcher pm)
			{
				throw new NotSupportedException();
			}

			public static Pattern operator &(Pattern a, Pattern b)
			{
				return new ILPattern(ILCode.LogicAnd, a, b);
			}

			public static Pattern operator |(Pattern a, Pattern b)
			{
				return new ILPattern(ILCode.LogicOr, a, b);
			}

			public static Pattern operator !(Pattern a)
			{
				if (a is ILPattern iLPattern)
				{
					if (iLPattern.code == ILCode.Cnull)
					{
						return new ILPattern(ILCode.Cnotnull, a.Arguments);
					}
					if (iLPattern.code == ILCode.Cnotnull)
					{
						return new ILPattern(ILCode.Cnull, a.Arguments);
					}
				}
				return new ILPattern(ILCode.LogicNot, a);
			}
		}

		private sealed class ILPattern : Pattern
		{
			internal readonly ILCode code;

			public ILPattern(ILCode code, params Pattern[] arguments)
				: base(arguments)
			{
				this.code = code;
			}

			public override bool Match(PatternMatcher pm, ILExpression e)
			{
				if (e.Code == code)
				{
					return base.Match(pm, e);
				}
				return false;
			}

			public override ILExpression BuildNew(PatternMatcher pm)
			{
				ILExpression[] array = new ILExpression[Arguments.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Arguments[i].BuildNew(pm);
				}
				TypeSig inferredType = null;
				switch (code)
				{
				case ILCode.Ceq:
				case ILCode.Cne:
					inferredType = pm.corLib.Boolean;
					break;
				case ILCode.NullCoalescing:
					inferredType = array[1].InferredType;
					break;
				}
				return new ILExpression(code, null, array)
				{
					InferredType = inferredType
				};
			}
		}

		private sealed class MethodPattern : Pattern
		{
			private readonly ILCode code;

			private readonly string method;

			public MethodPattern(ILCode code, string method, params Pattern[] arguments)
				: base(arguments)
			{
				this.code = code;
				this.method = method;
			}

			public override bool Match(PatternMatcher pm, ILExpression e)
			{
				if (e.Code != code)
				{
					return false;
				}
				IMethod method = (IMethod)e.Operand;
				if (method.Name == this.method && TypeAnalysis.IsNullableType(method.DeclaringType.ToTypeSig()))
				{
					return base.Match(pm, e);
				}
				return false;
			}
		}

		private enum OperatorType
		{
			Equality,
			InEquality,
			Comparison,
			Other
		}

		private sealed class OperatorPattern : Pattern
		{
			private OperatorType type;

			private bool simple;

			public OperatorPattern()
				: base(null)
			{
			}

			public OperatorPattern(OperatorType type, bool simple)
				: this()
			{
				this.type = type;
				this.simple = simple;
			}

			public override bool Match(PatternMatcher pm, ILExpression e)
			{
				switch (e.Code)
				{
				case ILCode.Ceq:
					if (type != OperatorType.Equality)
					{
						return false;
					}
					break;
				case ILCode.Cne:
					if (type != OperatorType.InEquality)
					{
						return false;
					}
					break;
				case ILCode.Cgt:
				case ILCode.Cgt_Un:
				case ILCode.Clt:
				case ILCode.Clt_Un:
				case ILCode.Cge:
				case ILCode.Cge_Un:
				case ILCode.Cle:
				case ILCode.Cle_Un:
					if (type != OperatorType.Comparison)
					{
						return false;
					}
					break;
				case ILCode.Add:
				case ILCode.Sub:
				case ILCode.Mul:
				case ILCode.Div:
				case ILCode.Div_Un:
				case ILCode.Rem:
				case ILCode.Rem_Un:
				case ILCode.And:
				case ILCode.Or:
				case ILCode.Xor:
				case ILCode.Shl:
				case ILCode.Shr:
				case ILCode.Shr_Un:
				case ILCode.Neg:
				case ILCode.Not:
				case ILCode.Add_Ovf:
				case ILCode.Add_Ovf_Un:
				case ILCode.Mul_Ovf:
				case ILCode.Mul_Ovf_Un:
				case ILCode.Sub_Ovf:
				case ILCode.Sub_Ovf_Un:
				case ILCode.LogicNot:
					if (type != OperatorType.Other)
					{
						return false;
					}
					break;
				case ILCode.Call:
					if (!(e.Operand is IMethod { MethodSig: not null } method) || method.MethodSig.HasThis || method.MethodSig.Params.Count == 0 || e.Arguments.Count > 2 || !IsCustomOperator(method.Name))
					{
						return false;
					}
					break;
				default:
					return false;
				}
				if (pm.Operator != null)
				{
					throw new InvalidOperationException();
				}
				pm.Operator = e;
				ILExpression iLExpression = e.Arguments[0];
				if (!simple)
				{
					if (VariableAGetValueOrDefault.Match(pm, iLExpression))
					{
						return VariableBGetValueOrDefault.Match(pm, e.Arguments[1]);
					}
					return false;
				}
				if (e.Arguments.Count == 1)
				{
					return VariableAGetValueOrDefault.Match(pm, iLExpression);
				}
				if (VariableAGetValueOrDefault.Match(pm, iLExpression))
				{
					pm.SimpleOperand = e.Arguments[1];
					pm.SimpleLeftOperand = false;
					return true;
				}
				if (VariableAGetValueOrDefault.Match(pm, e.Arguments[1]))
				{
					pm.SimpleOperand = iLExpression;
					pm.SimpleLeftOperand = true;
					return true;
				}
				return false;
			}

			private bool IsCustomOperator(string s)
			{
				switch (type)
				{
				case OperatorType.Equality:
					return s == "op_Equality";
				case OperatorType.InEquality:
					return s == "op_Inequality";
				case OperatorType.Comparison:
					if (s.Length < 11 || !s.StartsWith("op_", StringComparison.Ordinal))
					{
						return false;
					}
					switch (s)
					{
					case "op_GreaterThan":
					case "op_GreaterThanOrEqual":
					case "op_LessThan":
					case "op_LessThanOrEqual":
						return true;
					default:
						return false;
					}
				default:
					if (s.Length < 10 || !s.StartsWith("op_", StringComparison.Ordinal))
					{
						return false;
					}
					switch (s)
					{
					case "op_Addition":
					case "op_Subtraction":
					case "op_Multiply":
					case "op_Division":
					case "op_Modulus":
					case "op_BitwiseAnd":
					case "op_BitwiseOr":
					case "op_ExclusiveOr":
					case "op_LeftShift":
					case "op_RightShift":
					case "op_UnaryNegation":
					case "op_UnaryPlus":
					case "op_LogicalNot":
					case "op_OnesComplement":
					case "op_Increment":
					case "op_Decrement":
						return true;
					default:
						return false;
					}
				}
			}

			public override ILExpression BuildNew(PatternMatcher pm)
			{
				ILExpression iLExpression = pm.Operator;
				iLExpression.Arguments.Clear();
				if (pm.SimpleLeftOperand)
				{
					iLExpression.Arguments.Add(pm.SimpleOperand);
				}
				iLExpression.Arguments.Add(VariableA.BuildNew(pm));
				if (pm.B != null)
				{
					iLExpression.Arguments.Add(VariableB.BuildNew(pm));
				}
				else if (pm.SimpleOperand != null && !pm.SimpleLeftOperand)
				{
					iLExpression.Arguments.Add(pm.SimpleOperand);
				}
				return iLExpression;
			}
		}

		private sealed class AnyPattern : Pattern
		{
			public AnyPattern()
				: base(null)
			{
			}

			public override bool Match(PatternMatcher pm, ILExpression e)
			{
				if (pm.SimpleOperand != null)
				{
					throw new InvalidOperationException();
				}
				pm.SimpleOperand = e;
				return true;
			}

			public override ILExpression BuildNew(PatternMatcher pm)
			{
				return pm.SimpleOperand;
			}
		}

		private sealed class VariablePattern : Pattern
		{
			private readonly ILCode code;

			private readonly bool b;

			public VariablePattern(ILCode code, bool b)
				: base(null)
			{
				this.code = code;
				this.b = b;
			}

			public override bool Match(PatternMatcher pm, ILExpression e)
			{
				if (e.Code != code)
				{
					return false;
				}
				if (e.Operand is ILVariable v)
				{
					if (!b)
					{
						return Capture(ref pm.A, v);
					}
					return Capture(ref pm.B, v);
				}
				return false;
			}

			private static bool Capture(ref ILVariable pmvar, ILVariable v)
			{
				if (pmvar != null)
				{
					return pmvar == v;
				}
				pmvar = v;
				return true;
			}

			public override ILExpression BuildNew(PatternMatcher pm)
			{
				ILVariable iLVariable = (b ? pm.B : pm.A);
				ILExpression iLExpression = new ILExpression(ILCode.Ldloc, iLVariable);
				if (TypeAnalysis.IsNullableType(iLVariable.Type))
				{
					iLExpression = new ILExpression(ILCode.ValueOf, null, iLExpression);
				}
				return iLExpression;
			}
		}

		private sealed class BooleanPattern : Pattern
		{
			public static readonly Pattern False = new BooleanPattern(value: false);

			public static readonly Pattern True = new BooleanPattern(value: true);

			private readonly object value;

			private BooleanPattern(bool value)
				: base(null)
			{
				this.value = Convert.ToInt32(value);
			}

			public override bool Match(PatternMatcher pm, ILExpression e)
			{
				if (e.Code == ILCode.Ldc_I4 && e.InferredType.GetElementType() == ElementType.Boolean)
				{
					return object.Equals(e.Operand, value);
				}
				return false;
			}

			public override ILExpression BuildNew(PatternMatcher pm)
			{
				return new ILExpression(ILCode.Wrap, null, new ILExpression(ILCode.Ldc_I4, value));
			}
		}

		private ICorLibTypes corLib;

		private ILVariable A;

		private ILVariable B;

		private ILExpression Operator;

		private ILExpression SimpleOperand;

		private bool SimpleLeftOperand;

		private readonly DecompilerContext context;

		private static readonly Pattern VariableRefA = new VariablePattern(ILCode.Ldloca, b: false);

		private static readonly Pattern VariableRefB = new VariablePattern(ILCode.Ldloca, b: true);

		private static readonly Pattern VariableA = new VariablePattern(ILCode.Ldloc, b: false);

		private static readonly Pattern VariableB = new VariablePattern(ILCode.Ldloc, b: true);

		private static readonly Pattern VariableAHasValue = new ILPattern(ILCode.Cnotnull, VariableRefA);

		private static readonly Pattern VariableAGetValueOrDefault = new MethodPattern(ILCode.Call, "GetValueOrDefault", VariableRefA);

		private static readonly Pattern VariableBHasValue = new ILPattern(ILCode.Cnotnull, VariableRefB);

		private static readonly Pattern VariableBGetValueOrDefault = new MethodPattern(ILCode.Call, "GetValueOrDefault", VariableRefB);

		private static readonly Pattern CeqHasValue = new ILPattern(ILCode.Ceq, VariableAHasValue, VariableBHasValue);

		private static readonly Pattern CneHasValue = new ILPattern(ILCode.Cne, VariableAHasValue, VariableBHasValue);

		private static readonly Pattern AndHasValue = new ILPattern(ILCode.And, VariableAHasValue, VariableBHasValue);

		private static readonly Pattern Any = new AnyPattern();

		private static readonly Pattern OperatorVariableAB = new OperatorPattern();

		private static readonly Pattern[] Comparisons = new Pattern[12]
		{
			OperatorNN(OperatorType.Equality) & CeqHasValue,
			CeqHasValue & (!VariableAHasValue | OperatorNN(OperatorType.Equality)),
			OperatorNN(OperatorType.InEquality) | CneHasValue,
			CneHasValue | (VariableAHasValue & OperatorNN(OperatorType.InEquality)),
			OperatorNN(OperatorType.Comparison) & AndHasValue,
			AndHasValue & OperatorNN(OperatorType.Comparison),
			OperatorNV(OperatorType.Equality) & VariableAHasValue,
			VariableAHasValue & OperatorNV(OperatorType.Equality),
			OperatorNV(OperatorType.InEquality) | !VariableAHasValue,
			!VariableAHasValue | OperatorNV(OperatorType.InEquality),
			OperatorNV(OperatorType.Comparison) & VariableAHasValue,
			VariableAHasValue & OperatorNV(OperatorType.Comparison)
		};

		private static readonly Pattern[] Other = new Pattern[28]
		{
			new ILPattern(ILCode.TernaryOp, VariableAGetValueOrDefault | (!VariableBGetValueOrDefault & !VariableAHasValue), VariableB, VariableA),
			new ILPattern(ILCode.And, VariableA, VariableB),
			new ILPattern(ILCode.TernaryOp, VariableAGetValueOrDefault | (!VariableBGetValueOrDefault & !VariableAHasValue), VariableA, VariableB),
			new ILPattern(ILCode.Or, VariableA, VariableB),
			new ILPattern(ILCode.TernaryOp, VariableAHasValue, NewObj(VariableAGetValueOrDefault), VariableB),
			new ILPattern(ILCode.NullCoalescing, VariableA, VariableB),
			new ILPattern(ILCode.TernaryOp, AndHasValue, NewObj(OperatorNN(OperatorType.Other)), new ILPattern(ILCode.DefaultValue)),
			OperatorVariableAB,
			new ILPattern(ILCode.TernaryOp, Any, VariableA, NewObj(BooleanPattern.False)),
			new ILPattern(ILCode.And, VariableA, Any),
			new ILPattern(ILCode.TernaryOp, Any, NewObj(BooleanPattern.True), VariableA),
			new ILPattern(ILCode.Or, VariableA, Any),
			VariableAGetValueOrDefault & VariableAHasValue,
			new ILPattern(ILCode.Ceq, VariableA, BooleanPattern.True),
			!VariableAGetValueOrDefault | !VariableAHasValue,
			new ILPattern(ILCode.Cne, VariableA, BooleanPattern.True),
			!VariableAGetValueOrDefault & VariableAHasValue,
			new ILPattern(ILCode.Ceq, VariableA, BooleanPattern.False),
			VariableAGetValueOrDefault | !VariableAHasValue,
			new ILPattern(ILCode.Cne, VariableA, BooleanPattern.False),
			!VariableAHasValue | VariableAGetValueOrDefault,
			new ILPattern(ILCode.NullCoalescing, VariableA, BooleanPattern.True),
			VariableAHasValue & VariableAGetValueOrDefault,
			new ILPattern(ILCode.NullCoalescing, VariableA, BooleanPattern.False),
			new ILPattern(ILCode.TernaryOp, VariableAHasValue, VariableAGetValueOrDefault, Any),
			new ILPattern(ILCode.NullCoalescing, VariableA, Any),
			new ILPattern(ILCode.TernaryOp, VariableAHasValue, NewObj(OperatorNV(OperatorType.Other)), new ILPattern(ILCode.DefaultValue)),
			OperatorVariableAB
		};

		public PatternMatcher(DecompilerContext context, ICorLibTypes corLib)
		{
			this.context = context;
			this.corLib = corLib;
		}

		public void Initialize(ICorLibTypes corLib)
		{
			this.corLib = corLib;
			Reset();
		}

		public bool SimplifyLiftedOperators(ILExpression expr)
		{
			if (Simplify(expr))
			{
				return true;
			}
			bool flag = false;
			foreach (ILExpression argument in expr.Arguments)
			{
				flag |= SimplifyLiftedOperators(argument);
			}
			return flag;
		}

		private static OperatorPattern OperatorNN(OperatorType type)
		{
			return new OperatorPattern(type, simple: false);
		}

		private static OperatorPattern OperatorNV(OperatorType type)
		{
			return new OperatorPattern(type, simple: true);
		}

		private static Pattern NewObj(Pattern p)
		{
			return new MethodPattern(ILCode.Newobj, ".ctor", p);
		}

		private void Reset()
		{
			A = null;
			B = null;
			Operator = null;
			SimpleOperand = null;
			SimpleLeftOperand = false;
		}

		private bool Simplify(ILExpression expr)
		{
			if (expr.Code == ILCode.TernaryOp || expr.Code == ILCode.LogicAnd || expr.Code == ILCode.LogicOr)
			{
				Pattern[] comparisons;
				if (expr.Code != ILCode.TernaryOp)
				{
					comparisons = Comparisons;
					for (int i = 0; i < comparisons.Length; i++)
					{
						Reset();
						if (comparisons[i].Match(this, expr))
						{
							SetResult(expr, OperatorVariableAB.BuildNew(this));
							return true;
						}
					}
				}
				comparisons = Other;
				for (int j = 0; j < comparisons.Length; j += 2)
				{
					Reset();
					if (!comparisons[j].Match(this, expr))
					{
						continue;
					}
					ILExpression iLExpression = comparisons[j + 1].BuildNew(this);
					SetResult(expr, iLExpression);
					if (iLExpression.Code == ILCode.NullCoalescing)
					{
						if (iLExpression.Arguments[1].Code == ILCode.ValueOf)
						{
							if (context.CalculateILSpans)
							{
								iLExpression.Arguments[0].Arguments[0].ILSpans.AddRange(iLExpression.Arguments[0].ILSpans);
							}
							iLExpression.Arguments[0] = iLExpression.Arguments[0].Arguments[0];
							if (context.CalculateILSpans)
							{
								iLExpression.Arguments[1].Arguments[0].ILSpans.AddRange(iLExpression.Arguments[1].ILSpans);
							}
							iLExpression.Arguments[1] = iLExpression.Arguments[1].Arguments[0];
						}
					}
					else if (iLExpression.Code != ILCode.Ceq && iLExpression.Code != ILCode.Cne)
					{
						expr.Code = ILCode.NullableOf;
						TypeSig inferredType = (expr.ExpectedType = null);
						expr.InferredType = inferredType;
					}
					return true;
				}
			}
			return false;
		}

		private void SetResult(ILExpression expr, ILExpression n)
		{
			if (context.CalculateILSpans)
			{
				IEnumerable<ILExpression> source = expr.GetSelfAndChildrenRecursive<ILExpression>().Except(n.GetSelfAndChildrenRecursive<ILExpression>());
				n.ILSpans.AddRange(source.SelectMany((ILExpression el) => el.ILSpans));
				expr.ILSpans.Clear();
			}
			expr.Code = ILCode.Wrap;
			expr.Arguments.Clear();
			expr.Arguments.Add(n);
			expr.InferredType = n.InferredType;
		}
	}

	private static readonly UTF8String nameInitializeArray = new UTF8String("InitializeArray");

	private static readonly UTF8String nameCtor = new UTF8String(".ctor");

	private static readonly UTF8String nameIEnumerable = new UTF8String("IEnumerable");

	private static readonly UTF8String nameSystemCollections = new UTF8String("System.Collections");

	private int nextLabelIndex;

	private DecompilerContext context;

	private ICorLibTypes corLib;

	private ILBlock method;

	private readonly List<ILTryCatchBlock.CatchBlockBase> Optimize_List_CatchBlockBase;

	private readonly List<ILTryCatchBlock.CatchBlock> Optimize_List_CatchBlocks;

	private readonly List<ILWhileLoop> Optimize_List_ILWhileLoop;

	private readonly List<ILBlock> Optimize_List_ILBlock;

	private readonly List<ILNode> Optimize_List_ILNode;

	private readonly List<ILExpression> Optimize_List_ILExpression;

	private readonly List<ILExpression> Optimize_List_ILExpression2;

	private readonly Dictionary<ILLabel, int> Optimize_Dict_ILLabel_Int32;

	private readonly Dictionary<Local, ILVariable> Optimize_Dict_Local_ILVariable;

	private readonly Dictionary<ILLabel, ILNode> Optimize_Dict_ILLabel_ILNode;

	private readonly List<KeyValuePair<ILExpression, ILExpression>> Optimize_List_ILExpressionx2;

	private bool hasFilters;

	public string CompilerName;

	private TypeAnalysis cached_TypeAnalysis;

	private SimpleControlFlow cached_SimpleControlFlow;

	private ILInlining cached_ILInlining;

	private PatternMatcher cached_PatternMatcher;

	private LoopsAndConditions cached_LoopsAndConditions;

	private readonly Func<ILBlock, ILInlining> del_getILInlining;

	private static readonly UTF8String nameSystem = "System";

	private static readonly UTF8String nameMoveNext = new UTF8String("MoveNext");

	private static readonly UTF8String name_get_Current = new UTF8String("get_Current");

	private int readOnlyPropTempLocalNameCounter;

	private int tmpLocalCounter;

	private static readonly UTF8String nameEmbedded = new UTF8String("Embedded");

	private static readonly UTF8String nameAssemblyVisualBasic = new UTF8String("Microsoft.VisualBasic");

	private static readonly UTF8String nameClearProjectError = new UTF8String("ClearProjectError");

	private static readonly UTF8String nameSetProjectError = new UTF8String("SetProjectError");

	private static readonly UTF8String nameProjectData = new UTF8String("ProjectData");

	private static readonly UTF8String name_get_HasValue = new UTF8String("get_HasValue");

	private static readonly UTF8String systemString = new UTF8String("System");

	private static readonly UTF8String decimalString = new UTF8String("Decimal");

	private bool SimplifyLiftedOperators(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		if (!GetPatternMatcher(corLib).SimplifyLiftedOperators(expr))
		{
			return false;
		}
		ILInlining iLInlining = GetILInlining(method);
		while (--pos >= 0 && iLInlining.InlineIfPossible(block, body, ref pos))
		{
		}
		return true;
	}

	private bool TransformArrayInitializers(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		if (((ILNode)expr).Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && ((ILNode)arg).Match(ILCode.Newarr, out ITypeDefOrRef operand2, out ILExpression arg2) && ((ILNode)arg2).Match(ILCode.Ldc_I4, out int operand3) && operand3 > 0)
		{
			if (ForwardScanInitializeArrayRuntimeHelper(body, pos + 1, operand, new SZArraySig(operand2.ToTypeSig()), operand3, out var values, out var foundPos))
			{
				ArraySig arraySig = new ArraySig(operand2.ToTypeSig(), 1, new uint[1], new int[1]);
				operand3 = values.Length;
				arraySig.Sizes[0] = (uint)(operand3 + 1);
				ILExpression iLExpression = new ILExpression(ILCode.Stloc, operand, new ILExpression(ILCode.InitArray, arraySig.ToTypeDefOrRef(), values));
				if (context.CalculateILSpans)
				{
					body[pos].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
					body[foundPos].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
				}
				body[pos] = iLExpression;
				body.RemoveAt(foundPos);
			}
			List<ILExpression> list = new List<ILExpression>();
			int num = 0;
			for (int i = pos + 1; i < body.Count && body[i] is ILExpression iLExpression2; i++)
			{
				if (!iLExpression2.Code.IsStoreToArray())
				{
					break;
				}
				if (!((ILNode)iLExpression2.Arguments[0]).Match(ILCode.Ldloc, out ILVariable operand4))
				{
					break;
				}
				if (operand != operand4)
				{
					break;
				}
				if (!((ILNode)iLExpression2.Arguments[1]).Match(ILCode.Ldc_I4, out int operand5))
				{
					break;
				}
				if (operand5 < list.Count)
				{
					break;
				}
				if (operand5 > list.Count + 300)
				{
					break;
				}
				if (iLExpression2.Arguments[2].ContainsReferenceTo(operand4))
				{
					break;
				}
				while (list.Count < operand5)
				{
					list.Add(new ILExpression(ILCode.DefaultValue, operand2));
				}
				list.Add(iLExpression2.Arguments[2]);
				num++;
			}
			if (list.Count == operand3)
			{
				ArraySig arraySig2 = new ArraySig(operand2.ToTypeSig(), 1, new uint[1], new int[1]);
				arraySig2.Sizes[0] = (uint)(operand3 + 1);
				expr.Arguments[0] = new ILExpression(ILCode.InitArray, arraySig2.ToTypeDefOrRef(), list);
				if (context.CalculateILSpans)
				{
					arg.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
					for (int j = 0; j < num; j++)
					{
						body[pos + 1 + j].AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
					}
				}
				body.RemoveRange(pos + 1, num);
				GetILInlining(method).InlineIfPossible(block, body, ref pos);
				return true;
			}
		}
		return false;
	}

	private bool TransformMultidimensionalArrayInitializers(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		if (((ILNode)expr).Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && ((ILNode)arg).Match(ILCode.Newobj, out IMethod operand2, out List<ILExpression> args) && operand2.DeclaringType is TypeSpec typeSpec && typeSpec.TypeSig.RemovePinnedAndModifiers() is ArraySig arraySig && arraySig.Rank == args.Count)
		{
			ArraySig arraySig2 = new ArraySig(arraySig.Next, arraySig.Rank, new uint[arraySig.Rank], new int[arraySig.Rank]);
			int[] array = new int[arraySig2.Rank];
			for (int i = 0; i < arraySig2.Rank; i++)
			{
				if (!((ILNode)args[i]).Match(ILCode.Ldc_I4, out array[i]))
				{
					return false;
				}
				if (array[i] <= 0)
				{
					return false;
				}
				arraySig2.Sizes[i] = (uint)(array[i] + 1);
				arraySig2.LowerBounds[i] = 0;
			}
			int arrayLength = array.Aggregate(1, (int t, int l) => t * l);
			if (ForwardScanInitializeArrayRuntimeHelper(body, pos + 1, operand, arraySig2, arrayLength, out var values, out var foundPos))
			{
				ILExpression iLExpression = new ILExpression(ILCode.Stloc, operand, new ILExpression(ILCode.InitArray, arraySig2.ToTypeDefOrRef(), values));
				if (context.CalculateILSpans)
				{
					body[pos].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
					body[foundPos].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
				}
				body[pos] = iLExpression;
				body.RemoveAt(foundPos);
				return true;
			}
		}
		return false;
	}

	private bool ForwardScanInitializeArrayRuntimeHelper(List<ILNode> body, int pos, ILVariable array, TypeSig arrayType, int arrayLength, out ILExpression[] values, out int foundPos)
	{
		if (body.ElementAtOrDefault(pos).Match<IMethod>(ILCode.Call, out var operand, out var arg, out var arg2) && operand.Name == nameInitializeArray && operand.DeclaringType != null && operand.DeclaringType.FullName == "System.Runtime.CompilerServices.RuntimeHelpers" && ((ILNode)arg).Match(ILCode.Ldloc, out ILVariable operand2) && array == operand2 && ((ILNode)arg2).Match(ILCode.Ldtoken, out IField operand3))
		{
			FieldDef fieldDef = operand3.ResolveFieldWithinSameModule();
			if (fieldDef != null && fieldDef.InitialValue != null)
			{
				ILExpression[] array2 = new ILExpression[Math.Min(context.Settings.MaxArrayElements, arrayLength)];
				if (DecodeArrayInitializer(arrayType.Next, fieldDef.InitialValue, array2))
				{
					if (arrayLength != array2.Length && array2.Length != 0)
					{
						array2[array2.Length - 1] = new ILExpression(ILCode.Ldstr, $"Not showing all elements because this array is too big ({arrayLength} elements)");
					}
					values = array2;
					foundPos = pos;
					return true;
				}
			}
		}
		values = null;
		foundPos = -1;
		return false;
	}

	private static bool DecodeArrayInitializer(TypeSig elementTypeRef, byte[] initialValue, ILExpression[] output)
	{
		elementTypeRef = elementTypeRef.RemovePinnedAndModifiers();
		TypeCode typeCode = TypeAnalysis.GetTypeCode(elementTypeRef);
		switch (typeCode)
		{
		case TypeCode.Boolean:
		case TypeCode.Byte:
			return DecodeArrayInitializer(initialValue, output, typeCode, (Func<byte[], int, int>)((byte[] d, int i) => d[i]));
		case TypeCode.SByte:
			return DecodeArrayInitializer(initialValue, output, typeCode, (Func<byte[], int, int>)((byte[] d, int i) => (sbyte)d[i]));
		case TypeCode.Int16:
			return DecodeArrayInitializer(initialValue, output, typeCode, (Func<byte[], int, int>)((byte[] d, int i) => BitConverter.ToInt16(d, i)));
		case TypeCode.Char:
		case TypeCode.UInt16:
			return DecodeArrayInitializer(initialValue, output, typeCode, (Func<byte[], int, int>)((byte[] d, int i) => BitConverter.ToUInt16(d, i)));
		case TypeCode.Int32:
		case TypeCode.UInt32:
			return DecodeArrayInitializer(initialValue, output, typeCode, BitConverter.ToInt32);
		case TypeCode.Int64:
		case TypeCode.UInt64:
			return DecodeArrayInitializer(initialValue, output, typeCode, BitConverter.ToInt64);
		case TypeCode.Single:
			return DecodeArrayInitializer(initialValue, output, typeCode, BitConverter.ToSingle);
		case TypeCode.Double:
			return DecodeArrayInitializer(initialValue, output, typeCode, BitConverter.ToDouble);
		case TypeCode.Object:
		{
			TypeDef typeDef = elementTypeRef.ToTypeDefOrRef().ResolveWithinSameModule();
			if (typeDef != null && typeDef.IsEnum)
			{
				return DecodeArrayInitializer(typeDef.GetEnumUnderlyingType(), initialValue, output);
			}
			return false;
		}
		default:
			return false;
		}
	}

	private static bool DecodeArrayInitializer<T>(byte[] initialValue, ILExpression[] output, TypeCode elementType, Func<byte[], int, T> decoder)
	{
		int num = ElementSizeOf(elementType);
		if (initialValue.Length < output.Length * num)
		{
			return false;
		}
		ILCode code = LoadCodeFor(elementType);
		for (int i = 0; i < output.Length; i++)
		{
			output[i] = new ILExpression(code, decoder(initialValue, i * num));
		}
		return true;
	}

	private static ILCode LoadCodeFor(TypeCode elementType)
	{
		switch (elementType)
		{
		case TypeCode.Boolean:
		case TypeCode.Char:
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
			return ILCode.Ldc_I4;
		case TypeCode.Int64:
		case TypeCode.UInt64:
			return ILCode.Ldc_I8;
		case TypeCode.Single:
			return ILCode.Ldc_R4;
		case TypeCode.Double:
			return ILCode.Ldc_R8;
		default:
			throw new ArgumentOutOfRangeException("elementType");
		}
	}

	private static int ElementSizeOf(TypeCode elementType)
	{
		switch (elementType)
		{
		case TypeCode.Boolean:
		case TypeCode.SByte:
		case TypeCode.Byte:
			return 1;
		case TypeCode.Char:
		case TypeCode.Int16:
		case TypeCode.UInt16:
			return 2;
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Single:
			return 4;
		case TypeCode.Int64:
		case TypeCode.UInt64:
		case TypeCode.Double:
			return 8;
		default:
			throw new ArgumentOutOfRangeException("elementType");
		}
	}

	private bool TransformObjectInitializers(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		if (!context.Settings.ObjectOrCollectionInitializers)
		{
			return false;
		}
		IMethod operand2;
		ITypeDefOrRef operand3;
		bool flag;
		List<ILExpression> args;
		if (((ILNode)expr).Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
		{
			if (((ILNode)arg).Match(ILCode.Newobj, out operand2, out args))
			{
				operand3 = operand2.DeclaringType;
				flag = DnlibExtensions.IsValueType(operand3);
			}
			else
			{
				if (!((ILNode)arg).Match(ILCode.DefaultValue, out operand3))
				{
					return false;
				}
				flag = true;
			}
		}
		else
		{
			if (!((ILNode)expr).Match(ILCode.Call, out operand2, out args))
			{
				return false;
			}
			if (!(operand2.Name == nameCtor) || args.Count <= 0 || !((ILNode)args[0]).Match(ILCode.Ldloca, out operand))
			{
				return false;
			}
			flag = true;
			operand3 = operand2.DeclaringType;
			args = new List<ILExpression>(args);
			ILExpression iLExpression = args[0];
			args.RemoveAt(0);
			arg = new ILExpression(ILCode.Newobj, operand2, args);
			if (context.CalculateILSpans)
			{
				iLExpression.AddSelfAndChildrenRecursiveILSpans(arg.ILSpans);
			}
		}
		if (DnlibExtensions.IsValueType(operand3) != flag)
		{
			return false;
		}
		int pos2 = pos;
		if (DelegateConstruction.IsPotentialClosure(context, operand3.ResolveWithinSameModule()))
		{
			return false;
		}
		ILExpression iLExpression2 = ParseObjectInitializer(body, ref pos, operand, arg, IsCollectionType(operand3.ToTypeSig()), flag);
		if (iLExpression2.Arguments.Count == 1)
		{
			return false;
		}
		int num = pos - pos2 - 1;
		if (pos >= body.Count)
		{
			return false;
		}
		ILInlining iLInlining = (flag ? GetILInlining(body, pos2, pos - pos2 + 1) : GetILInlining(method));
		bool flag2 = true;
		if (flag)
		{
			flag2 = iLInlining.numLdloc.GetOrDefault(operand) != 1 || iLInlining.numLdloca.GetOrDefault(operand) != num + ((expr.Code == ILCode.Call) ? 1 : 0) || iLInlining.numStloc.GetOrDefault(operand) != ((expr.Code != ILCode.Call) ? 1 : 0);
		}
		if (flag2)
		{
			if (iLInlining.numLdloc.GetOrDefault(operand) != num + 1)
			{
				return false;
			}
			if (iLInlining.numStloc.GetOrDefault(operand) != 1 || iLInlining.numLdloca.GetOrDefault(operand) != 0)
			{
				return false;
			}
		}
		ILExpression expr2 = body[pos] as ILExpression;
		if (!iLInlining.CanInlineInto(expr2, operand, iLExpression2))
		{
			return false;
		}
		if (expr.Code == ILCode.Stloc)
		{
			if (context.CalculateILSpans)
			{
				expr.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			}
			expr.Arguments[0] = iLExpression2;
		}
		else
		{
			expr.Code = ILCode.Stloc;
			expr.Operand = operand;
			if (context.CalculateILSpans)
			{
				foreach (ILExpression argument in expr.Arguments)
				{
					argument.AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
				}
			}
			expr.Arguments.Clear();
			expr.Arguments.Add(iLExpression2);
		}
		if (context.CalculateILSpans)
		{
			for (int i = pos2 + 1; i < pos; i++)
			{
				body[i].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			}
		}
		body.RemoveRange(pos2 + 1, pos - pos2 - 1);
		ChangeFirstArgumentToInitializedObject(iLExpression2);
		iLInlining = GetILInlining(method);
		iLInlining.InlineIfPossible(block, body, ref pos2);
		return true;
	}

	private static bool IsCollectionType(TypeSig tr)
	{
		if (tr == null)
		{
			return false;
		}
		for (TypeDef typeDef = tr.Resolve(); typeDef != null; typeDef = ((typeDef.BaseType != null) ? typeDef.BaseType.ResolveTypeDef() : null))
		{
			foreach (InterfaceImpl @interface in typeDef.Interfaces)
			{
				ITypeDefOrRef typeDefOrRef = @interface.Interface;
				if (typeDefOrRef.Name == nameIEnumerable && typeDefOrRef.Namespace == nameSystemCollections)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool IsSetterInObjectInitializer(ILExpression expr)
	{
		if (expr == null)
		{
			return false;
		}
		if (expr.Code == ILCode.CallvirtSetter || expr.Code == ILCode.CallSetter || expr.Code == ILCode.Stfld)
		{
			return expr.Arguments.Count == 2;
		}
		return false;
	}

	private static bool IsAddMethodCall(ILExpression expr)
	{
		if ((((ILNode)expr).Match(ILCode.Callvirt, out IMethod operand, out List<ILExpression> args) || ((ILNode)expr).Match(ILCode.Call, out operand, out args)) && operand.Name == "Add")
		{
			return args.Count >= 2;
		}
		return false;
	}

	private ILExpression ParseObjectInitializer(List<ILNode> body, ref int pos, ILVariable v, ILExpression newObjExpr, bool isCollection, bool isValueType)
	{
		ILExpression iLExpression = new ILExpression(isCollection ? ILCode.InitCollection : ILCode.InitObject, null, newObjExpr);
		Optimize_List_ILExpression.Clear();
		Optimize_List_ILExpression.Add(iLExpression);
		while (++pos < body.Count)
		{
			ILExpression iLExpression2 = body[pos] as ILExpression;
			if (IsSetterInObjectInitializer(iLExpression2))
			{
				if (!AdjustInitializerStack(Optimize_List_ILExpression, Optimize_List_ILExpression2, iLExpression2.Arguments[0], v, isCollection: false, isValueType))
				{
					CleanupInitializerStackAfterFailedAdjustment(Optimize_List_ILExpression);
					break;
				}
				Optimize_List_ILExpression[Optimize_List_ILExpression.Count - 1].Arguments.Add(iLExpression2);
				continue;
			}
			if (!IsAddMethodCall(iLExpression2))
			{
				break;
			}
			if (!AdjustInitializerStack(Optimize_List_ILExpression, Optimize_List_ILExpression2, iLExpression2.Arguments[0], v, isCollection: true, isValueType))
			{
				CleanupInitializerStackAfterFailedAdjustment(Optimize_List_ILExpression);
				break;
			}
			Optimize_List_ILExpression[Optimize_List_ILExpression.Count - 1].Arguments.Add(iLExpression2);
		}
		return iLExpression;
	}

	private bool AdjustInitializerStack(List<ILExpression> initializerStack, List<ILExpression> getters, ILExpression argument, ILVariable v, bool isCollection, bool isValueType)
	{
		getters.Clear();
		while (argument.Code == ILCode.CallvirtGetter || argument.Code == ILCode.CallGetter || argument.Code == ILCode.Ldfld)
		{
			getters.Add(argument);
			if (argument.Arguments.Count != 1)
			{
				return false;
			}
			argument = argument.Arguments[0];
		}
		if (isValueType)
		{
			if (((ILNode)argument).Match(ILCode.Ldloca, out ILVariable operand))
			{
				if (operand != v)
				{
					return false;
				}
			}
			else if (!argument.MatchLdloc(v))
			{
				return false;
			}
		}
		else if (!argument.MatchLdloc(v))
		{
			return false;
		}
		int i;
		for (i = 1; i <= Math.Min(getters.Count, initializerStack.Count - 1); i++)
		{
			ILExpression iLExpression = initializerStack[i].Arguments[0];
			ILExpression iLExpression2 = getters[getters.Count - i];
			if (iLExpression.Operand != iLExpression2.Operand)
			{
				break;
			}
		}
		initializerStack.RemoveRange(i, initializerStack.Count - i);
		for (; i <= getters.Count; i++)
		{
			ILExpression iLExpression3 = getters[getters.Count - i];
			IMemberRef memberRef = iLExpression3.Operand as IMemberRef;
			TypeSig tr = ((memberRef != null && !memberRef.IsField) ? TypeAnalysis.SubstituteTypeArgs(((IMethod)memberRef).MethodSig.GetRetType(), null, (IMethod)memberRef) : TypeAnalysis.GetFieldType((IField)memberRef));
			ILExpression item = new ILExpression(IsCollectionType(tr) ? ILCode.InitCollection : ILCode.InitObject, null, iLExpression3);
			ILExpression iLExpression4 = initializerStack[initializerStack.Count - 1];
			if (iLExpression4.Code == ILCode.InitCollection)
			{
				if (iLExpression4.Arguments.Count != 1)
				{
					return false;
				}
				iLExpression4.Code = ILCode.InitObject;
			}
			iLExpression4.Arguments.Add(item);
			initializerStack.Add(item);
		}
		ILExpression iLExpression5 = initializerStack[initializerStack.Count - 1];
		if (isCollection)
		{
			return iLExpression5.Code == ILCode.InitCollection;
		}
		if (iLExpression5.Code == ILCode.InitCollection)
		{
			if (iLExpression5.Arguments.Count == 1)
			{
				iLExpression5.Code = ILCode.InitObject;
				return true;
			}
			return false;
		}
		return true;
	}

	private void CleanupInitializerStackAfterFailedAdjustment(List<ILExpression> initializerStack)
	{
		while (initializerStack.Count > 1 && initializerStack[initializerStack.Count - 1].Arguments.Count == 1)
		{
			ILExpression iLExpression = initializerStack[initializerStack.Count - 2];
			if (context.CalculateILSpans)
			{
				iLExpression.Arguments[iLExpression.Arguments.Count - 1].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
			}
			iLExpression.Arguments.RemoveAt(iLExpression.Arguments.Count - 1);
			initializerStack.RemoveAt(initializerStack.Count - 1);
		}
	}

	private void ChangeFirstArgumentToInitializedObject(ILExpression initializer)
	{
		for (int i = 1; i < initializer.Arguments.Count; i++)
		{
			ILExpression iLExpression = initializer.Arguments[i];
			if (iLExpression.Code == ILCode.InitCollection || iLExpression.Code == ILCode.InitObject)
			{
				ILExpression iLExpression2 = iLExpression.Arguments[0];
				ILExpression iLExpression3 = new ILExpression(ILCode.InitializedObject, null);
				if (context.CalculateILSpans)
				{
					iLExpression2.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression3.ILSpans);
				}
				iLExpression2.Arguments[0] = iLExpression3;
				ChangeFirstArgumentToInitializedObject(iLExpression);
			}
			else
			{
				ILExpression iLExpression4 = new ILExpression(ILCode.InitializedObject, null);
				if (context.CalculateILSpans)
				{
					iLExpression.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression4.ILSpans);
				}
				iLExpression.Arguments[0] = iLExpression4;
			}
		}
	}

	public ILAstOptimizer()
	{
		del_getILInlining = GetILInlining;
		Optimize_List_CatchBlockBase = new List<ILTryCatchBlock.CatchBlockBase>();
		Optimize_List_CatchBlocks = new List<ILTryCatchBlock.CatchBlock>();
		Optimize_List_ILWhileLoop = new List<ILWhileLoop>();
		Optimize_List_ILBlock = new List<ILBlock>();
		Optimize_List_ILNode = new List<ILNode>();
		Optimize_List_ILExpression = new List<ILExpression>();
		Optimize_List_ILExpression2 = new List<ILExpression>();
		Optimize_Dict_ILLabel_Int32 = new Dictionary<ILLabel, int>();
		Optimize_Dict_Local_ILVariable = new Dictionary<Local, ILVariable>();
		Optimize_Dict_ILLabel_ILNode = new Dictionary<ILLabel, ILNode>();
		Optimize_List_ILExpressionx2 = new List<KeyValuePair<ILExpression, ILExpression>>();
	}

	public void Reset()
	{
		context = null;
		corLib = null;
		method = null;
		nextLabelIndex = 0;
		Optimize_List_CatchBlockBase.Clear();
		Optimize_List_CatchBlocks.Clear();
		Optimize_List_ILWhileLoop.Clear();
		Optimize_List_ILBlock.Clear();
		Optimize_List_ILNode.Clear();
		Optimize_List_ILExpression.Clear();
		Optimize_List_ILExpression2.Clear();
		Optimize_Dict_ILLabel_Int32.Clear();
		Optimize_Dict_Local_ILVariable.Clear();
		Optimize_Dict_ILLabel_ILNode.Clear();
		Optimize_List_ILExpressionx2.Clear();
		hasFilters = false;
		readOnlyPropTempLocalNameCounter = 0;
		tmpLocalCounter = 0;
		CompilerName = null;
	}

	private TypeAnalysis GetTypeAnalysis()
	{
		if (cached_TypeAnalysis == null)
		{
			cached_TypeAnalysis = new TypeAnalysis();
		}
		return cached_TypeAnalysis;
	}

	private SimpleControlFlow GetSimpleControlFlow(DecompilerContext context, ILBlock method)
	{
		if (cached_SimpleControlFlow == null)
		{
			cached_SimpleControlFlow = new SimpleControlFlow(context, method);
		}
		else
		{
			cached_SimpleControlFlow.Initialize(context, method);
		}
		return cached_SimpleControlFlow;
	}

	private ILInlining GetILInlining(ILBlock method)
	{
		if (cached_ILInlining == null)
		{
			cached_ILInlining = new ILInlining(context);
		}
		cached_ILInlining.Initialize(method);
		return cached_ILInlining;
	}

	private ILInlining GetILInlining(List<ILNode> body, int start, int count)
	{
		if (cached_ILInlining == null)
		{
			cached_ILInlining = new ILInlining(context);
		}
		cached_ILInlining.Initialize(body, start, count);
		return cached_ILInlining;
	}

	private PatternMatcher GetPatternMatcher(ICorLibTypes corLib)
	{
		if (cached_PatternMatcher == null)
		{
			cached_PatternMatcher = new PatternMatcher(context, corLib);
		}
		else
		{
			cached_PatternMatcher.Initialize(corLib);
		}
		return cached_PatternMatcher;
	}

	private LoopsAndConditions GetLoopsAndConditions(DecompilerContext context)
	{
		if (cached_LoopsAndConditions == null)
		{
			cached_LoopsAndConditions = new LoopsAndConditions(context);
		}
		else
		{
			cached_LoopsAndConditions.Initialize(context);
		}
		return cached_LoopsAndConditions;
	}

	public void Optimize(DecompilerContext context, ILBlock method, out StateMachineKind stateMachineKind, out MethodDef inlinedMethod, out AsyncMethodDebugInfo asyncInfo, ILAstOptimizationStep abortBeforeStep = ILAstOptimizationStep.None)
	{
		Optimize(context, method, null, out stateMachineKind, out inlinedMethod, out asyncInfo, abortBeforeStep);
	}

	internal void Optimize(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider, out StateMachineKind stateMachineKind, out MethodDef inlinedMethod, out AsyncMethodDebugInfo asyncInfo, ILAstOptimizationStep abortBeforeStep = ILAstOptimizationStep.None)
	{
		this.context = context;
		corLib = context.CurrentMethod.Module.CorLibTypes;
		this.method = method;
		stateMachineKind = StateMachineKind.None;
		inlinedMethod = null;
		asyncInfo = null;
		try
		{
			if (abortBeforeStep == ILAstOptimizationStep.RemoveVisualBasicCompilerCode)
			{
				return;
			}
			if (IsVisualBasicModule())
			{
				RemoveVisualBasicCompilerCode(method);
			}
			if (abortBeforeStep == ILAstOptimizationStep.RemoveRedundantCode)
			{
				return;
			}
			RemoveRedundantCode(context, method, Optimize_List_ILExpression, Optimize_List_ILBlock, Optimize_Dict_ILLabel_Int32);
			if (abortBeforeStep == ILAstOptimizationStep.ReduceBranchInstructionSet)
			{
				return;
			}
			foreach (ILBlock item in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
			{
				ReduceBranchInstructionSet(item);
			}
			if (abortBeforeStep == ILAstOptimizationStep.InlineVariables)
			{
				return;
			}
			ILInlining iLInlining = GetILInlining(method);
			iLInlining.InlineAllVariables();
			if (abortBeforeStep == ILAstOptimizationStep.ConvertFieldAccessesToPropertyMethodCalls)
			{
				return;
			}
			if (context.CurrentMethod.IsConstructor)
			{
				ConvertFieldAccessesToPropertyMethodCalls(method, autoPropertyProvider);
			}
			if (abortBeforeStep == ILAstOptimizationStep.CopyPropagation)
			{
				return;
			}
			iLInlining.CopyPropagation(Optimize_List_ILNode);
			if (abortBeforeStep == ILAstOptimizationStep.YieldReturn)
			{
				return;
			}
			YieldReturnDecompiler.Run(context, method, autoPropertyProvider, ref stateMachineKind, ref inlinedMethod, ref CompilerName, Optimize_List_ILNode, del_getILInlining, Optimize_List_ILExpression, Optimize_List_ILBlock, Optimize_Dict_ILLabel_Int32);
			AsyncDecompiler asyncDecompiler = AsyncDecompiler.RunStep1(context, method, autoPropertyProvider, ref stateMachineKind, ref inlinedMethod, ref CompilerName, Optimize_List_ILExpression, Optimize_List_ILBlock, Optimize_Dict_ILLabel_Int32);
			if (abortBeforeStep == ILAstOptimizationStep.AsyncAwait)
			{
				return;
			}
			asyncDecompiler?.RunStep2(context, method, out asyncInfo, Optimize_List_ILExpression, Optimize_List_ILBlock, Optimize_Dict_ILLabel_Int32, Optimize_List_ILNode, del_getILInlining);
			if (abortBeforeStep == ILAstOptimizationStep.PropertyAccessInstructions)
			{
				return;
			}
			IntroducePropertyAccessInstructions(method);
			if (abortBeforeStep == ILAstOptimizationStep.SplitToMovableBlocks)
			{
				return;
			}
			foreach (ILBlock item2 in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
			{
				SplitToBasicBlocks(item2);
			}
			if (abortBeforeStep == ILAstOptimizationStep.TypeInference)
			{
				return;
			}
			GetTypeAnalysis().Run(context, method);
			if (abortBeforeStep == ILAstOptimizationStep.HandlePointerArithmetic)
			{
				return;
			}
			HandlePointerArithmetic(method);
			foreach (ILBlock item3 in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
			{
				bool flag;
				do
				{
					flag = false;
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyShortCircuit)
					{
						return;
					}
					flag |= item3.RunOptimization(GetSimpleControlFlow(context, method).SimplifyShortCircuit);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyTernaryOperator)
					{
						return;
					}
					flag |= item3.RunOptimization(GetSimpleControlFlow(context, method).SimplifyTernaryOperator);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyNullCoalescing)
					{
						return;
					}
					flag |= item3.RunOptimization(GetSimpleControlFlow(context, method).SimplifyNullCoalescing);
					if (abortBeforeStep == ILAstOptimizationStep.JoinBasicBlocks)
					{
						return;
					}
					flag |= item3.RunOptimization(GetSimpleControlFlow(context, method).JoinBasicBlocks);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyLogicNot)
					{
						return;
					}
					flag |= item3.RunOptimization(SimplifyLogicNot);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyShiftOperators)
					{
						return;
					}
					flag |= item3.RunOptimization(SimplifyShiftOperators);
					if (abortBeforeStep == ILAstOptimizationStep.TypeConversionSimplifications)
					{
						return;
					}
					flag |= item3.RunOptimization(TypeConversionSimplifications);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyLdObjAndStObj)
					{
						return;
					}
					flag |= item3.RunOptimization(SimplifyLdObjAndStObj);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyCustomShortCircuit)
					{
						return;
					}
					flag |= item3.RunOptimization(GetSimpleControlFlow(context, method).SimplifyCustomShortCircuit);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyLiftedOperators)
					{
						return;
					}
					flag |= item3.RunOptimization(SimplifyLiftedOperators);
					if (abortBeforeStep == ILAstOptimizationStep.TransformArrayInitializers)
					{
						return;
					}
					flag |= item3.RunOptimization(TransformArrayInitializers);
					if (abortBeforeStep == ILAstOptimizationStep.TransformMultidimensionalArrayInitializers)
					{
						return;
					}
					flag |= item3.RunOptimization(TransformMultidimensionalArrayInitializers);
					if (abortBeforeStep == ILAstOptimizationStep.TransformObjectInitializers)
					{
						return;
					}
					flag |= item3.RunOptimization(TransformObjectInitializers);
					if (abortBeforeStep == ILAstOptimizationStep.MakeAssignmentExpression)
					{
						return;
					}
					if (context.Settings.MakeAssignmentExpressions)
					{
						flag |= item3.RunOptimization(MakeAssignmentExpression);
					}
					flag |= item3.RunOptimization(MakeCompoundAssignments);
					if (abortBeforeStep == ILAstOptimizationStep.IntroducePostIncrement)
					{
						return;
					}
					if (context.Settings.IntroduceIncrementAndDecrement)
					{
						flag |= item3.RunOptimization(IntroducePostIncrement);
					}
					if (abortBeforeStep == ILAstOptimizationStep.InlineExpressionTreeParameterDeclarations)
					{
						return;
					}
					if (context.Settings.ExpressionTrees)
					{
						flag |= item3.RunOptimization(InlineExpressionTreeParameterDeclarations);
					}
					if (abortBeforeStep == ILAstOptimizationStep.InlineVariables2)
					{
						return;
					}
					flag |= GetILInlining(method).InlineAllInBlock(item3);
					GetILInlining(method).CopyPropagation(Optimize_List_ILNode);
				}
				while (flag);
			}
			if (abortBeforeStep == ILAstOptimizationStep.FindLoops)
			{
				return;
			}
			foreach (ILBlock item4 in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
			{
				GetLoopsAndConditions(context).FindLoops(item4);
			}
			if (abortBeforeStep == ILAstOptimizationStep.FindConditions)
			{
				return;
			}
			foreach (ILBlock item5 in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
			{
				if (item5 is ILTryCatchBlock.FilterILBlock)
				{
					hasFilters = true;
				}
				GetLoopsAndConditions(context).FindConditions(item5);
			}
			if (abortBeforeStep == ILAstOptimizationStep.FlattenNestedMovableBlocks)
			{
				return;
			}
			FlattenBasicBlocks(method);
			if (abortBeforeStep == ILAstOptimizationStep.RemoveEndFinally)
			{
				return;
			}
			RemoveEndFinally(method);
			if (abortBeforeStep == ILAstOptimizationStep.RemoveRedundantCode2)
			{
				return;
			}
			RemoveRedundantCode(context, method, Optimize_List_ILExpression, Optimize_List_ILBlock, Optimize_Dict_ILLabel_Int32);
			if (abortBeforeStep == ILAstOptimizationStep.GotoRemoval)
			{
				return;
			}
			GotoRemoval.RemoveGotos(context, method);
			if (abortBeforeStep == ILAstOptimizationStep.FixRoslynStaticDelegates)
			{
				return;
			}
			FixRoslynStaticDelegates(method);
			if (abortBeforeStep == ILAstOptimizationStep.FixFilters)
			{
				return;
			}
			FixFilterBlocks(method);
			if (abortBeforeStep == ILAstOptimizationStep.CreateLoopLocal)
			{
				return;
			}
			CreateLoopLocal(method);
			if (abortBeforeStep == ILAstOptimizationStep.DuplicateReturns)
			{
				return;
			}
			DuplicateReturnStatements(method);
			if (abortBeforeStep == ILAstOptimizationStep.GotoRemoval2)
			{
				return;
			}
			GotoRemoval.RemoveGotos(context, method);
			if (abortBeforeStep == ILAstOptimizationStep.ReduceIfNesting)
			{
				return;
			}
			ReduceIfNesting(method);
			if (abortBeforeStep == ILAstOptimizationStep.InlineVariables3)
			{
				return;
			}
			GetILInlining(method).InlineAllVariables();
			if (abortBeforeStep == ILAstOptimizationStep.CachedDelegateInitialization)
			{
				return;
			}
			if (context.Settings.AnonymousMethods)
			{
				foreach (ILBlock item6 in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
				{
					for (int i = 0; i < item6.Body.Count; i++)
					{
						CachedDelegateInitializationWithField(item6, ref i);
						CachedDelegateInitializationWithLocal(item6, ref i);
					}
				}
			}
			if (abortBeforeStep == ILAstOptimizationStep.IntroduceFixedStatements)
			{
				return;
			}
			foreach (ILBlock item7 in TreeTraversal.PostOrder(method, (ILNode n) => n.GetChildren()).OfType<ILBlock>())
			{
				for (int num = item7.Body.Count - 1; num >= 0; num--)
				{
					if (num < item7.Body.Count)
					{
						IntroduceFixedStatements(item7, item7.Body, num);
					}
				}
			}
			if (abortBeforeStep == ILAstOptimizationStep.RecombineVariables)
			{
				return;
			}
			RecombineVariables(method);
			if (abortBeforeStep == ILAstOptimizationStep.TypeInference2)
			{
				return;
			}
			TypeAnalysis.Reset(method, Optimize_List_ILExpression);
			GetTypeAnalysis().Run(context, method);
			if (abortBeforeStep != ILAstOptimizationStep.RemoveRedundantCode3)
			{
				GotoRemoval.RemoveRedundantCode(method, context);
				if (abortBeforeStep != ILAstOptimizationStep.IntroduceConstants)
				{
					IntroduceConstants(method);
				}
			}
		}
		finally
		{
			Optimize_List_CatchBlockBase.Clear();
			Optimize_List_CatchBlocks.Clear();
			Optimize_List_ILWhileLoop.Clear();
			Optimize_List_ILBlock.Clear();
			Optimize_List_ILNode.Clear();
			Optimize_List_ILExpression.Clear();
			Optimize_List_ILExpression2.Clear();
			Optimize_Dict_ILLabel_Int32.Clear();
			Optimize_Dict_Local_ILVariable.Clear();
			Optimize_Dict_ILLabel_ILNode.Clear();
			Optimize_List_ILExpressionx2.Clear();
		}
	}

	private void IntroduceConstants(ILBlock method)
	{
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
		{
			IntroduceConstantsCore(item);
		}
	}

	private static bool IsMscorlibSystemClass(TypeDef type, string name)
	{
		if (type.Namespace != nameSystem)
		{
			return false;
		}
		if (!type.DefinitionAssembly.IsCorLib())
		{
			return false;
		}
		return type.Name == name;
	}

	private void IntroduceConstantsCore(ILBlock block)
	{
		List<ILExpression> optimize_List_ILExpression = Optimize_List_ILExpression;
		optimize_List_ILExpression.Clear();
		List<ILNode> body = block.Body;
		for (int i = 0; i < body.Count; i++)
		{
			if (body[i] is ILExpression item)
			{
				optimize_List_ILExpression.Add(item);
			}
		}
		while (optimize_List_ILExpression.Count > 0)
		{
			ILExpression iLExpression = optimize_List_ILExpression[optimize_List_ILExpression.Count - 1];
			optimize_List_ILExpression.RemoveAt(optimize_List_ILExpression.Count - 1);
			List<ILExpression> arguments = iLExpression.Arguments;
			for (int j = 0; j < arguments.Count; j++)
			{
				optimize_List_ILExpression.Add(arguments[j]);
			}
			TypeSig typeSig = (iLExpression.InferredType ?? iLExpression.ExpectedType).RemovePinnedAndModifiers();
			if (typeSig == null)
			{
				continue;
			}
			switch (typeSig.ElementType)
			{
			case ElementType.Char:
				if (iLExpression.Code == ILCode.Ldc_I4)
				{
					int num4 = (int)iLExpression.Operand;
					if (num4 == 65535 && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Char"))
					{
						ModuleDef currentModule4 = context.CurrentModule;
						MemberRefUser operand4 = new MemberRefUser(currentModule4, "MaxValue", new FieldSig(currentModule4.CorLibTypes.Char), currentModule4.CorLibTypes.Char.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand4;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.I1:
				if (iLExpression.Code == ILCode.Ldc_I4)
				{
					int num6 = (int)iLExpression.Operand;
					if ((num6 == 127 || num6 == -128) && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "SByte"))
					{
						ModuleDef currentModule6 = context.CurrentModule;
						MemberRefUser operand6 = new MemberRefUser(currentModule6, (num6 == 127) ? "MaxValue" : "MinValue", new FieldSig(currentModule6.CorLibTypes.SByte), currentModule6.CorLibTypes.SByte.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand6;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.U1:
				if (iLExpression.Code == ILCode.Ldc_I4)
				{
					int num3 = (int)iLExpression.Operand;
					if (num3 == 255 && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Byte"))
					{
						ModuleDef currentModule3 = context.CurrentModule;
						MemberRefUser operand3 = new MemberRefUser(currentModule3, "MaxValue", new FieldSig(currentModule3.CorLibTypes.Byte), currentModule3.CorLibTypes.Byte.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand3;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.I2:
				if (iLExpression.Code == ILCode.Ldc_I4)
				{
					int num7 = (int)iLExpression.Operand;
					if ((num7 == 32767 || num7 == -32768) && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Int16"))
					{
						ModuleDef currentModule7 = context.CurrentModule;
						MemberRefUser operand7 = new MemberRefUser(currentModule7, (num7 == 32767) ? "MaxValue" : "MinValue", new FieldSig(currentModule7.CorLibTypes.Int16), currentModule7.CorLibTypes.Int16.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand7;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.U2:
				if (iLExpression.Code == ILCode.Ldc_I4)
				{
					int num9 = (int)iLExpression.Operand;
					if (num9 == 65535 && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "UInt16"))
					{
						ModuleDef currentModule9 = context.CurrentModule;
						MemberRefUser operand9 = new MemberRefUser(currentModule9, "MaxValue", new FieldSig(currentModule9.CorLibTypes.UInt16), currentModule9.CorLibTypes.UInt16.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand9;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.I4:
				if (iLExpression.Code == ILCode.Ldc_I4)
				{
					int num10 = (int)iLExpression.Operand;
					if ((num10 == int.MaxValue || num10 == int.MinValue) && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Int32"))
					{
						ModuleDef currentModule10 = context.CurrentModule;
						MemberRefUser operand10 = new MemberRefUser(currentModule10, (num10 == int.MaxValue) ? "MaxValue" : "MinValue", new FieldSig(currentModule10.CorLibTypes.Int32), currentModule10.CorLibTypes.Int32.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand10;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.U4:
				if (iLExpression.Code == ILCode.Ldc_I4)
				{
					int num2 = (int)iLExpression.Operand;
					if (num2 == -1 && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "UInt32"))
					{
						ModuleDef currentModule2 = context.CurrentModule;
						MemberRefUser operand2 = new MemberRefUser(currentModule2, "MaxValue", new FieldSig(currentModule2.CorLibTypes.UInt32), currentModule2.CorLibTypes.UInt32.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand2;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.I8:
				if (iLExpression.Code == ILCode.Ldc_I8)
				{
					long num11 = (long)iLExpression.Operand;
					if ((num11 == long.MaxValue || num11 == long.MinValue) && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Int64"))
					{
						ModuleDef currentModule11 = context.CurrentModule;
						MemberRefUser operand11 = new MemberRefUser(currentModule11, (num11 == long.MaxValue) ? "MaxValue" : "MinValue", new FieldSig(currentModule11.CorLibTypes.Int64), currentModule11.CorLibTypes.Int64.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand11;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.U8:
				if (iLExpression.Code == ILCode.Ldc_I8)
				{
					long num5 = (long)iLExpression.Operand;
					if (num5 == -1 && !IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "UInt64"))
					{
						ModuleDef currentModule5 = context.CurrentModule;
						MemberRefUser operand5 = new MemberRefUser(currentModule5, "MaxValue", new FieldSig(currentModule5.CorLibTypes.UInt64), currentModule5.CorLibTypes.UInt64.TypeDefOrRef);
						iLExpression.Code = ILCode.Ldsfld;
						iLExpression.Operand = operand5;
						iLExpression.Arguments.Clear();
					}
				}
				break;
			case ElementType.R4:
			{
				if (iLExpression.Code != ILCode.Ldc_R4)
				{
					break;
				}
				float num12 = (float)iLExpression.Operand;
				string text3;
				if (float.IsNaN(num12))
				{
					text3 = "NaN";
				}
				else if (float.IsPositiveInfinity(num12))
				{
					text3 = "PositiveInfinity";
				}
				else if (float.IsNegativeInfinity(num12))
				{
					text3 = "NegativeInfinity";
				}
				else if (num12 == float.Epsilon)
				{
					text3 = "Epsilon";
				}
				else if (num12 == float.MinValue)
				{
					text3 = "MinValue";
				}
				else
				{
					if (num12 != float.MaxValue)
					{
						break;
					}
					text3 = "MaxValue";
				}
				if (!IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Single"))
				{
					ModuleDef currentModule12 = context.CurrentModule;
					MemberRefUser operand12 = new MemberRefUser(currentModule12, text3, new FieldSig(currentModule12.CorLibTypes.Single), currentModule12.CorLibTypes.Single.TypeDefOrRef);
					iLExpression.Code = ILCode.Ldsfld;
					iLExpression.Operand = operand12;
					iLExpression.Arguments.Clear();
				}
				break;
			}
			case ElementType.R8:
			{
				if (iLExpression.Code != ILCode.Ldc_R8)
				{
					break;
				}
				double num8 = (double)iLExpression.Operand;
				string text2;
				if (double.IsNaN(num8))
				{
					text2 = "NaN";
				}
				else if (double.IsPositiveInfinity(num8))
				{
					text2 = "PositiveInfinity";
				}
				else if (double.IsNegativeInfinity(num8))
				{
					text2 = "NegativeInfinity";
				}
				else if (num8 == double.Epsilon)
				{
					text2 = "Epsilon";
				}
				else if (num8 == double.MinValue)
				{
					text2 = "MinValue";
				}
				else
				{
					if (num8 != double.MaxValue)
					{
						break;
					}
					text2 = "MaxValue";
				}
				if (!IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Double"))
				{
					ModuleDef currentModule8 = context.CurrentModule;
					MemberRefUser operand8 = new MemberRefUser(currentModule8, text2, new FieldSig(currentModule8.CorLibTypes.Double), currentModule8.CorLibTypes.Double.TypeDefOrRef);
					iLExpression.Code = ILCode.Ldsfld;
					iLExpression.Operand = operand8;
					iLExpression.Arguments.Clear();
				}
				break;
			}
			case ElementType.ValueType:
			{
				if (iLExpression.Code != ILCode.Ldc_Decimal)
				{
					break;
				}
				decimal num = (decimal)iLExpression.Operand;
				string text;
				if (num == decimal.MinValue)
				{
					text = "MinValue";
				}
				else
				{
					if (!(num == decimal.MaxValue))
					{
						break;
					}
					text = "MaxValue";
				}
				if (!IsMscorlibSystemClass(context.CurrentMethod.DeclaringType, "Decimal"))
				{
					ModuleDef currentModule = context.CurrentModule;
					TypeRef typeRef = currentModule.CorLibTypes.GetTypeRef("System", "Decimal");
					MemberRefUser operand = new MemberRefUser(currentModule, text, new FieldSig(new ValueTypeSig(typeRef)), typeRef);
					iLExpression.Code = ILCode.Ldsfld;
					iLExpression.Operand = operand;
					iLExpression.Arguments.Clear();
				}
				break;
			}
			}
		}
	}

	private void CreateLoopLocal(ILBlock method)
	{
		foreach (ILWhileLoop item in method.GetSelfAndChildrenRecursive(Optimize_List_ILWhileLoop))
		{
			CreateLoopLocalCore(item);
		}
	}

	private void CreateLoopLocalCore(ILWhileLoop block)
	{
		if ((!((ILNode)block.Condition).Match(ILCode.Call, out IMethod operand, out ILExpression arg) && !((ILNode)block.Condition).Match(ILCode.Callvirt, out operand, out arg)) || operand.Name != nameMoveNext || operand.MethodSig.GetParamCount() != 0 || (!((ILNode)arg).Match(ILCode.Ldloc, out ILVariable operand2) && !((ILNode)arg).Match(ILCode.Ldloca, out operand2)))
		{
			return;
		}
		List<ILNode> list = block.BodyBlock?.Body;
		if (list == null || list.Count == 0 || !(list[0] is ILExpression iLExpression) || (((ILNode)iLExpression).Match(ILCode.Stloc, out ILVariable _, out ILExpression arg2) && MatchCallGetterCurrent(arg2, operand2)))
		{
			return;
		}
		List<KeyValuePair<ILExpression, ILExpression>> optimize_List_ILExpressionx = Optimize_List_ILExpressionx2;
		optimize_List_ILExpressionx.Clear();
		optimize_List_ILExpressionx.Add(new KeyValuePair<ILExpression, ILExpression>(iLExpression, null));
		KeyValuePair<ILExpression, ILExpression> keyValuePair = default(KeyValuePair<ILExpression, ILExpression>);
		while (optimize_List_ILExpressionx.Count > 0)
		{
			KeyValuePair<ILExpression, ILExpression> keyValuePair2 = optimize_List_ILExpressionx[optimize_List_ILExpressionx.Count - 1];
			optimize_List_ILExpressionx.RemoveAt(optimize_List_ILExpressionx.Count - 1);
			ILExpression key = keyValuePair2.Key;
			if (MatchCallGetterCurrent(key, operand2))
			{
				if (keyValuePair.Key != null)
				{
					return;
				}
				keyValuePair = keyValuePair2;
			}
			List<ILExpression> arguments = key.Arguments;
			for (int i = 0; i < arguments.Count; i++)
			{
				optimize_List_ILExpressionx.Add(new KeyValuePair<ILExpression, ILExpression>(arguments[i], key));
			}
		}
		if (keyValuePair.Value != null)
		{
			ILExpression value = keyValuePair.Value;
			ILExpression key2 = keyValuePair.Key;
			int num = value.Arguments.IndexOf(key2);
			if (num >= 0)
			{
				ILVariable operand4 = CreateTempLocal();
				ILExpression item = new ILExpression(ILCode.Wrap, null, new ILExpression(ILCode.Stloc, operand4, key2));
				list.Insert(0, item);
				value.Arguments[num] = new ILExpression(ILCode.Ldloc, operand4);
			}
		}
	}

	private static bool MatchCallGetterCurrent(ILExpression expr, ILVariable enumeratorVar)
	{
		if ((((ILNode)expr).Match(ILCode.CallGetter, out IMethod operand, out ILExpression arg) || ((ILNode)expr).Match(ILCode.CallvirtGetter, out operand, out arg)) && operand.Name == name_get_Current && (arg.MatchLdloc(enumeratorVar) || arg.MatchLdloca(enumeratorVar)))
		{
			return true;
		}
		return false;
	}

	private void ConvertFieldAccessesToPropertyMethodCalls(ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		if (autoPropertyProvider == null)
		{
			autoPropertyProvider = new AutoPropertyProvider();
		}
		AutoPropertyInfo orCreate = autoPropertyProvider.GetOrCreate(context.CurrentMethod.DeclaringType);
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
		{
			ConvertFieldAccessesToPropertyMethodCallsCore(orCreate, item);
		}
	}

	private void ConvertFieldAccessesToPropertyMethodCallsCore(AutoPropertyInfo info, ILBlock block)
	{
		List<ILNode> body = block.Body;
		TypeDef declaringType = context.CurrentMethod.DeclaringType;
		for (int i = 0; i < body.Count; i++)
		{
			if (!(body[i] is ILExpression iLExpression))
			{
				continue;
			}
			if (iLExpression.Code == ILCode.Stfld || iLExpression.Code == ILCode.Stsfld)
			{
				FieldDef fieldDef = (iLExpression.Operand as IField).ResolveFieldWithinSameModule();
				if (fieldDef?.DeclaringType != declaringType)
				{
					continue;
				}
				IMethod method = info.TryGetSetter(fieldDef);
				ILCode code = ILCode.Call;
				if (method == null)
				{
					method = info.TryGetGetter(fieldDef);
					if (method == null)
					{
						continue;
					}
					code = ILCode.CallReadOnlySetter;
				}
				iLExpression.Code = code;
				iLExpression.Operand = method;
			}
			else
			{
				if (iLExpression.Code != ILCode.Initobj || iLExpression.Arguments.Count != 1)
				{
					continue;
				}
				ILExpression iLExpression2 = iLExpression.Arguments[0];
				if (iLExpression2.Code != ILCode.Ldflda && iLExpression2.Code != ILCode.Ldsflda)
				{
					continue;
				}
				FieldDef fieldDef2 = (iLExpression2.Operand as IField).ResolveFieldWithinSameModule();
				if (fieldDef2?.DeclaringType != declaringType)
				{
					continue;
				}
				IMethod method2 = info.TryGetSetter(fieldDef2);
				ILCode code2 = ILCode.Call;
				if (method2 == null)
				{
					method2 = info.TryGetGetter(fieldDef2);
					if (method2 == null)
					{
						continue;
					}
					code2 = ILCode.CallReadOnlySetter;
				}
				if (context.CalculateILSpans)
				{
					iLExpression.ILSpans.AddRange(iLExpression2.ILSpans);
				}
				object operand = iLExpression.Operand;
				ILVariable operand2 = new ILVariable("rop_" + readOnlyPropTempLocalNameCounter++)
				{
					GeneratedByDecompiler = true
				};
				ILExpression item = new ILExpression(ILCode.Initobj, operand, new ILExpression(ILCode.Ldloca, operand2));
				body.Insert(i++, item);
				iLExpression.Code = code2;
				iLExpression.Operand = method2;
				iLExpression.Arguments.Clear();
				iLExpression.Arguments.AddRange(iLExpression2.Arguments);
				iLExpression.Arguments.Add(new ILExpression(ILCode.Ldloc, operand2));
			}
		}
	}

	private void FixRoslynStaticDelegates(ILBlock method)
	{
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
		{
			FixRoslynStaticDelegatesCore(item);
		}
	}

	private bool FixRoslynStaticDelegatesCore(ILBlock block)
	{
		List<ILNode> body = block.Body;
		bool result = false;
		for (int i = 0; i < body.Count; i++)
		{
			if (!(body[i] is ILCondition { TrueBlock: not null, FalseBlock: not null } iLCondition) || iLCondition.FalseBlock.Body.Count != 0)
			{
				continue;
			}
			ILExpression condition = iLCondition.Condition;
			if (!((ILNode)condition).Match(ILCode.LogicNot, out ILExpression arg))
			{
				continue;
			}
			IField operand2;
			ILExpression arg3;
			ILExpression arg4;
			IField operand4;
			IMethod operand5;
			if (((ILNode)arg).Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg2))
			{
				FieldDef fieldDef;
				if (!((ILNode)arg2).Match(ILCode.Ldsfld, out operand2) || (fieldDef = operand2.ResolveFieldWithinSameModule()) == null || operand2.DeclaringType.DeclaringType == null)
				{
					continue;
				}
				List<ILNode> body2 = iLCondition.TrueBlock.Body;
				FieldDef fieldDef2;
				MethodDef methodDef;
				if (body2.Count == 1 && body2[0].MatchStloc(operand, out var expr) && ((ILNode)expr).Match(ILCode.Stsfld, out operand2, out arg3) && operand2.ResolveFieldWithinSameModule() == fieldDef && arg3.Match<IMethod>(ILCode.Newobj, out var _, out arg2, out arg4) && ((ILNode)arg2).Match(ILCode.Ldsfld, out operand4) && (fieldDef2 = operand4.ResolveFieldWithinSameModule()) != null && fieldDef2.DeclaringType == fieldDef.DeclaringType && ((ILNode)arg4).Match(ILCode.Ldftn, out operand5) && (methodDef = operand5.ResolveMethodWithinSameModule()) != null && methodDef.DeclaringType == fieldDef.DeclaringType && !methodDef.IsStatic)
				{
					if (context.CalculateILSpans)
					{
						arg3.ILSpans.AddRange(iLCondition.GetSelfAndChildrenRecursiveILSpans().ToArray());
					}
					body[i] = new ILExpression(ILCode.Stloc, operand, arg3);
					result = true;
				}
			}
			else
			{
				FieldDef fieldDef;
				if (!((ILNode)arg).Match(ILCode.Ldsfld, out operand2) || (fieldDef = operand2.ResolveFieldWithinSameModule()) == null || operand2.DeclaringType.DeclaringType == null)
				{
					continue;
				}
				List<ILNode> body3 = iLCondition.TrueBlock.Body;
				FieldDef fieldDef2;
				MethodDef methodDef;
				if (body3.Count == 1 && body3[0].Match(ILCode.Stsfld, out operand2, out arg3) && operand2.ResolveFieldWithinSameModule() == fieldDef && arg3.Match<IMethod>(ILCode.Newobj, out var _, out arg2, out arg4) && ((ILNode)arg2).Match(ILCode.Ldsfld, out operand4) && (fieldDef2 = operand4.ResolveFieldWithinSameModule()) != null && fieldDef2.DeclaringType == fieldDef.DeclaringType && ((ILNode)arg4).Match(ILCode.Ldftn, out operand5) && (methodDef = operand5.ResolveMethodWithinSameModule()) != null && methodDef.DeclaringType == fieldDef.DeclaringType && !methodDef.IsStatic)
				{
					if (context.CalculateILSpans)
					{
						arg3.ILSpans.AddRange(iLCondition.GetSelfAndChildrenRecursiveILSpans().ToArray());
					}
					body[i] = new ILExpression(ILCode.Wrap, null, new ILExpression(ILCode.Stloc, CreateTempLocal(), arg3));
					result = true;
				}
			}
		}
		return result;
	}

	private ILVariable CreateTempLocal()
	{
		return new ILVariable("_tmp_" + tmpLocalCounter++)
		{
			GeneratedByDecompiler = true
		};
	}

	private bool IsVisualBasicModule()
	{
		foreach (AssemblyRef assemblyRef in context.CurrentModule.GetAssemblyRefs())
		{
			if (assemblyRef.Name == nameAssemblyVisualBasic)
			{
				return true;
			}
		}
		AssemblyDef assembly = context.CurrentModule.Assembly;
		if (assembly != null && assembly.IsDefined(nameAssemblyVisualBasic, nameEmbedded))
		{
			return true;
		}
		if (context.CurrentModule.IsDefined(nameAssemblyVisualBasic, nameEmbedded))
		{
			return true;
		}
		if (context.CurrentModule.Assembly?.Name == nameAssemblyVisualBasic)
		{
			return true;
		}
		return false;
	}

	private void RemoveVisualBasicCompilerCode(ILBlock method)
	{
		Optimize_List_CatchBlockBase.Clear();
		foreach (ILTryCatchBlock.CatchBlockBase item in method.GetSelfAndChildrenRecursive(Optimize_List_CatchBlockBase))
		{
			List<ILNode> body = item.Body;
			for (int i = 0; i < body.Count; i++)
			{
				ILExpression iLExpression = body[i] as ILExpression;
				if (!((ILNode)iLExpression).Match(ILCode.Call, out IMethod operand, out List<ILExpression> args))
				{
					continue;
				}
				ITypeDefOrRef declaringType = operand.DeclaringType;
				if (declaringType.Name != nameProjectData || declaringType.Namespace != "Microsoft.VisualBasic.CompilerServices")
				{
					continue;
				}
				if (args.Count == 0)
				{
					if (!(operand.Name != nameClearProjectError))
					{
						iLExpression.Code = ILCode.Nop;
						iLExpression.Operand = null;
					}
				}
				else
				{
					if ((args.Count != 1 && args.Count != 2) || operand.Name != nameSetProjectError)
					{
						continue;
					}
					if (context.CalculateILSpans)
					{
						foreach (ILExpression item2 in args)
						{
							iLExpression.ILSpans.AddRange(item2.GetSelfAndChildrenRecursiveILSpans());
						}
					}
					iLExpression.Code = ILCode.Nop;
					iLExpression.Operand = null;
					iLExpression.Arguments.Clear();
				}
			}
		}
	}

	private void FixFilterBlocks(ILBlock method)
	{
		if (!hasFilters)
		{
			return;
		}
		Optimize_List_CatchBlocks.Clear();
		foreach (ILTryCatchBlock.CatchBlock item in method.GetSelfAndChildrenRecursive(Optimize_List_CatchBlocks))
		{
			if (item.FilterBlock != null && FixFilter(item, out var exVar, out var exType))
			{
				item.ExceptionType = exType.ToTypeSig();
				item.ExceptionVariable = exVar;
				if (item.ExceptionVariable != null && item.ExceptionVariable.Type == null)
				{
					item.ExceptionVariable.Type = item.ExceptionType;
				}
			}
		}
	}

	private bool FixFilter(ILTryCatchBlock.CatchBlock catchBlock, out ILVariable exVar, out ITypeDefOrRef exType)
	{
		if (!FixFilterRoslyn(catchBlock, out exVar, out exType))
		{
			return FixFilterMcs(catchBlock, out exVar, out exType);
		}
		return true;
	}

	private bool FixFilterRoslyn(ILTryCatchBlock.CatchBlock catchBlock, out ILVariable exVar, out ITypeDefOrRef exType)
	{
		exVar = null;
		exType = null;
		ILTryCatchBlock.FilterILBlock filterBlock = catchBlock.FilterBlock;
		if (filterBlock == null)
		{
			return false;
		}
		List<ILNode> body = filterBlock.Body;
		int pos = 0;
		if (!TryGetFilterExceptionType(body, ref pos, filterBlock, out exVar, out exType))
		{
			if (body.Count == 1)
			{
				if (!body[0].Match(ILCode.Endfilter, out ILExpression arg))
				{
					return false;
				}
				if (!((ILNode)arg).Match(ILCode.LogicAnd, out List<ILExpression> args) || args.Count != 2)
				{
					return false;
				}
				if (!((ILNode)args[0]).Match(ILCode.Isinst, out exType, out ILExpression arg2))
				{
					return false;
				}
				if (!((ILNode)arg2).Match(ILCode.Ldloc, out exVar))
				{
					return false;
				}
				if (exVar != filterBlock.ExceptionVariable)
				{
					return false;
				}
				if (!((ILNode)args[1]).Match(ILCode.Cgt_Un, out List<ILExpression> args2) || args2.Count != 2)
				{
					return false;
				}
				if (!((ILNode)args2[1]).Match(ILCode.Ldc_I4, out int operand) || operand != 0)
				{
					return false;
				}
				ILExpression iLExpression = args2[0];
				if (context.CalculateILSpans)
				{
					ILSpan[] collection = filterBlock.GetSelfAndChildrenRecursiveILSpans().ToArray();
					iLExpression.ILSpans.AddRange(collection);
				}
				body.Clear();
				body.Add(iLExpression);
				return true;
			}
			if (body.Count == 2)
			{
				if (!(body[pos] is ILCondition { TrueBlock: not null, FalseBlock: not null, Condition: var condition } iLCondition))
				{
					return false;
				}
				if (!((ILNode)condition).Match(ILCode.LogicNot, out ILExpression arg3))
				{
					return false;
				}
				if (!((ILNode)arg3).Match(ILCode.Isinst, out exType, out ILExpression arg4))
				{
					return false;
				}
				if (!((ILNode)arg4).Match(ILCode.Ldloc, out exVar))
				{
					return false;
				}
				if (exVar != filterBlock.ExceptionVariable)
				{
					return false;
				}
				List<ILNode> body2 = iLCondition.TrueBlock.Body;
				if (body2.Count != 1 || !body2[0].Match(ILCode.Stloc, out ILVariable operand2, out ILExpression arg5))
				{
					return false;
				}
				if (!((ILNode)arg5).Match(ILCode.Ldc_I4, out int operand3) || operand3 != 0)
				{
					return false;
				}
				List<ILNode> body3 = iLCondition.FalseBlock.Body;
				if (body3.Count != 2)
				{
					return false;
				}
				if (!body3[0].Match(ILCode.Stloc, out ILVariable operand4, out ILExpression arg6))
				{
					return false;
				}
				if (!body3[1].Match(ILCode.Stloc, out ILVariable operand5, out ILExpression arg7) || operand5 != operand2)
				{
					return false;
				}
				if (!((ILNode)arg7).Match(ILCode.Cgt_Un, out List<ILExpression> args3) || args3.Count != 2)
				{
					return false;
				}
				if (!((ILNode)args3[0]).Match(ILCode.Ldloc, out operand5) || operand5 != operand4)
				{
					return false;
				}
				if (!((ILNode)args3[1]).Match(ILCode.Ldc_I4, out operand3) || operand3 != 0)
				{
					return false;
				}
				if (!body[1].Match(ILCode.Endfilter, out ILExpression arg8) || !((ILNode)arg8).Match(ILCode.Ldloc, out operand5) || operand5 != operand2)
				{
					return false;
				}
				if (context.CalculateILSpans)
				{
					ILSpan[] collection2 = filterBlock.GetSelfAndChildrenRecursiveILSpans().ToArray();
					arg6.ILSpans.AddRange(collection2);
				}
				body.Clear();
				body.Add(arg6);
				return true;
			}
			return false;
		}
		if (pos >= body.Count)
		{
			return false;
		}
		if (pos + 1 == body.Count)
		{
			if (!body[pos].Match(ILCode.Endfilter, out ILExpression arg9))
			{
				return false;
			}
			if (!((ILNode)arg9).Match(ILCode.LogicAnd, out List<ILExpression> args4) || args4.Count != 2)
			{
				return false;
			}
			if (!((ILNode)args4[0]).Match(ILCode.Ldloc, out ILVariable operand6) || operand6 != exVar)
			{
				return false;
			}
			if (!((ILNode)args4[1]).Match(ILCode.Cgt_Un, out List<ILExpression> args5) || args5.Count != 2)
			{
				return false;
			}
			if (!((ILNode)args5[1]).Match(ILCode.Ldc_I4, out int operand7) || operand7 != 0)
			{
				return false;
			}
			ILExpression iLExpression2 = args5[0];
			if (context.CalculateILSpans)
			{
				iLExpression2.ILSpans.AddRange(body[0].GetSelfAndChildrenRecursiveILSpans());
				iLExpression2.ILSpans.AddRange(body[pos].ILSpans);
				iLExpression2.ILSpans.AddRange(arg9.ILSpans);
				iLExpression2.ILSpans.AddRange(args4[0].GetSelfAndChildrenRecursiveILSpans());
				iLExpression2.ILSpans.AddRange(args4[1].ILSpans);
				iLExpression2.ILSpans.AddRange(args5[1].GetSelfAndChildrenRecursiveILSpans());
			}
			body.Clear();
			body.Add(iLExpression2);
			return true;
		}
		if (!(body[pos] is ILCondition { TrueBlock: not null, FalseBlock: not null, Condition: var condition2 } iLCondition2))
		{
			return false;
		}
		if (!((ILNode)condition2).Match(ILCode.LogicNot, out ILExpression arg10))
		{
			return false;
		}
		if (!((ILNode)arg10).Match(ILCode.Ldloc, out ILVariable operand8) || operand8 != exVar)
		{
			return false;
		}
		List<ILNode> body4 = iLCondition2.TrueBlock.Body;
		if (body4.Count != 1 || !body4[0].Match(ILCode.Stloc, out ILVariable operand9, out ILExpression arg11))
		{
			return false;
		}
		if (!((ILNode)arg11).Match(ILCode.Ldc_I4, out int operand10) || operand10 != 0)
		{
			return false;
		}
		List<ILNode> body5 = iLCondition2.FalseBlock.Body;
		if (body5.Count < 2)
		{
			return false;
		}
		if (!body5[0].Match(ILCode.Stloc, out ILVariable operand11, out ILExpression arg12))
		{
			return false;
		}
		if (!((ILNode)arg12).Match(ILCode.Ldloc, out operand8) || operand8 != exVar)
		{
			return false;
		}
		if (body5.Count == 2)
		{
			if (!body5[1].Match(ILCode.Stloc, out operand8, out ILExpression arg13) || operand8 != operand9)
			{
				return false;
			}
			if (!((ILNode)arg13).Match(ILCode.Cgt_Un, out List<ILExpression> args6) || args6.Count != 2)
			{
				return false;
			}
			if (!((ILNode)args6[1]).Match(ILCode.Ldc_I4, out operand10) || operand10 != 0)
			{
				return false;
			}
			if (!body[2].Match(ILCode.Endfilter, out arg10) || !((ILNode)arg10).Match(ILCode.Ldloc, out operand8) || operand8 != operand9)
			{
				return false;
			}
			ILExpression iLExpression3 = args6[0];
			if (context.CalculateILSpans)
			{
				ILSpan[] collection3 = filterBlock.GetSelfAndChildrenRecursiveILSpans().ToArray();
				iLExpression3.ILSpans.AddRange(collection3);
			}
			body.Clear();
			body.Add(iLExpression3);
			exVar = operand11;
			return true;
		}
		if (body5.Count == 3)
		{
			if (!body5[1].Match(ILCode.Stloc, out ILVariable operand12, out ILExpression arg14))
			{
				return false;
			}
			if (!body5[2].Match(ILCode.Stloc, out operand8, out ILExpression arg15) || operand8 != operand9)
			{
				return false;
			}
			if (!((ILNode)arg15).Match(ILCode.Cgt_Un, out List<ILExpression> args7) || args7.Count != 2)
			{
				return false;
			}
			if (!((ILNode)args7[0]).Match(ILCode.Ldloc, out operand8) || operand8 != operand12)
			{
				return false;
			}
			if (!((ILNode)args7[1]).Match(ILCode.Ldc_I4, out operand10) || operand10 != 0)
			{
				return false;
			}
			if (!body[2].Match(ILCode.Endfilter, out arg10) || !((ILNode)arg10).Match(ILCode.Ldloc, out operand8) || operand8 != operand9)
			{
				return false;
			}
			if (context.CalculateILSpans)
			{
				ILSpan[] collection4 = filterBlock.GetSelfAndChildrenRecursiveILSpans().ToArray();
				arg14.ILSpans.AddRange(collection4);
			}
			body.Clear();
			body.Add(arg14);
			exVar = operand11;
			return true;
		}
		return false;
	}

	private static bool TryGetFilterExceptionType(List<ILNode> body, ref int pos, ILTryCatchBlock.FilterILBlock filterBlock, out ILVariable exVar, out ITypeDefOrRef exType)
	{
		exVar = null;
		exType = null;
		if (pos >= body.Count || !body[pos].Match(ILCode.Stloc, out exVar, out ILExpression arg))
		{
			return false;
		}
		if (!((ILNode)arg).Match(ILCode.Isinst, out exType, out ILExpression arg2))
		{
			return false;
		}
		if (!((ILNode)arg2).Match(ILCode.Ldloc, out ILVariable operand))
		{
			return false;
		}
		if (operand != filterBlock.ExceptionVariable)
		{
			return false;
		}
		pos++;
		return true;
	}

	private bool FixFilterMcs(ILTryCatchBlock.CatchBlock catchBlock, out ILVariable exVar, out ITypeDefOrRef exType)
	{
		exVar = null;
		exType = null;
		ILTryCatchBlock.FilterILBlock filterBlock = catchBlock.FilterBlock;
		if (filterBlock == null)
		{
			return false;
		}
		List<ILNode> body = filterBlock.Body;
		int pos = 0;
		if (TryGetFilterExceptionType(body, ref pos, filterBlock, out exVar, out exType))
		{
			if (pos >= body.Count)
			{
				return false;
			}
			if (!body[pos++].Match(ILCode.Endfilter, out ILExpression arg))
			{
				return false;
			}
			if (!((ILNode)arg).Match(ILCode.LogicAnd, out List<ILExpression> args) || args.Count != 2)
			{
				return false;
			}
			if (!args[0].MatchLdloc(exVar))
			{
				return false;
			}
			ILExpression iLExpression = args[1];
			if (context.CalculateILSpans)
			{
				ILSpan[] collection = filterBlock.GetSelfAndChildrenRecursiveILSpans().ToArray();
				iLExpression.ILSpans.AddRange(collection);
			}
			body.Clear();
			body.Add(iLExpression);
			return true;
		}
		if (body.Count == 1)
		{
			if (!body[pos++].Match(ILCode.Endfilter, out ILExpression arg2))
			{
				return false;
			}
			if (!((ILNode)arg2).Match(ILCode.LogicAnd, out List<ILExpression> args2) || args2.Count != 2)
			{
				return false;
			}
			if (!((ILNode)args2[0]).Match(ILCode.Isinst, out exType, out ILExpression arg3))
			{
				return false;
			}
			if (!((ILNode)arg3).Match(ILCode.Ldloc, out exVar))
			{
				return false;
			}
			ILExpression iLExpression2 = args2[1];
			if (context.CalculateILSpans)
			{
				ILSpan[] collection2 = filterBlock.GetSelfAndChildrenRecursiveILSpans().ToArray();
				iLExpression2.ILSpans.AddRange(collection2);
			}
			body.Clear();
			body.Add(iLExpression2);
			return true;
		}
		return false;
	}

	internal static void RemoveRedundantCode(DecompilerContext context, ILBlock method, List<ILExpression> listExpr, List<ILBlock> listBlock, Dictionary<ILLabel, int> labelRefCount)
	{
		labelRefCount.Clear();
		foreach (ILExpression item in method.GetSelfAndChildrenRecursive(listExpr, (ILExpression e) => e.IsBranch()))
		{
			foreach (ILLabel branchTarget in item.GetBranchTargets())
			{
				labelRefCount[branchTarget] = labelRefCount.GetOrDefault(branchTarget) + 1;
			}
		}
		foreach (ILBlock item2 in method.GetSelfAndChildrenRecursive(listBlock))
		{
			List<ILNode> body = item2.Body;
			List<ILNode> list = new List<ILNode>(body.Count);
			for (int num = 0; num < body.Count; num++)
			{
				ILExpression arg;
				if (body[num].Match(ILCode.Br, out ILLabel operand) && num + 1 < body.Count && body[num + 1] == operand)
				{
					ILNode prev = ((list.Count > 0) ? list[list.Count - 1] : null);
					ILNode iLNode = null;
					ILNode removed = body[num];
					if (labelRefCount[operand] == 1)
					{
						iLNode = body[num + 1];
						num++;
					}
					if (context.CalculateILSpans)
					{
						ILNode next = ((num + 1 < body.Count) ? body[num + 1] : null);
						Utils.AddILSpansTryPreviousFirst(removed, prev, next, item2);
						if (iLNode != null)
						{
							Utils.AddILSpansTryPreviousFirst(iLNode, prev, next, item2);
						}
					}
				}
				else if (body[num].Match(ILCode.Nop))
				{
					if (context.CalculateILSpans)
					{
						Utils.NopMergeILSpans(item2, list, num);
					}
				}
				else if (body[num].Match(ILCode.Pop, out arg))
				{
					if (!((ILNode)arg).Match(ILCode.Ldloc, out ILVariable operand2))
					{
						throw new Exception("Pop should have just ldloc at this stage");
					}
					if (context.CalculateILSpans)
					{
						if (num - 1 >= 0 && body[num - 1].Match(ILCode.Stloc, out ILVariable operand3, out ILExpression arg2) && operand3 == operand2)
						{
							arg2.ILSpans.AddRange(((ILExpression)body[num]).ILSpans);
						}
						else
						{
							Utils.AddILSpansTryPreviousFirst(list, body, num, item2);
						}
					}
				}
				else if (body[num] is ILLabel iLLabel)
				{
					if (labelRefCount.GetOrDefault(iLLabel) > 0)
					{
						list.Add(iLLabel);
					}
					else if (context.CalculateILSpans)
					{
						Utils.LabelMergeILSpans(item2, list, num);
					}
				}
				else
				{
					list.Add(body[num]);
				}
			}
			item2.Body = list;
		}
		foreach (ILExpression item3 in method.GetSelfAndChildrenRecursive(listExpr, (ILExpression e) => e.Code == ILCode.Leave))
		{
			if (item3.Arguments.Any((ILExpression node) => !node.Match(ILCode.Ldloc)))
			{
				throw new Exception("Leave should have just ldloc at this stage");
			}
			if (context.CalculateILSpans)
			{
				foreach (ILExpression argument in item3.Arguments)
				{
					argument.AddSelfAndChildrenRecursiveILSpans(item3.ILSpans);
				}
			}
			item3.Arguments.Clear();
		}
		foreach (ILExpression item4 in method.GetSelfAndChildrenRecursive(listExpr))
		{
			for (int num2 = 0; num2 < item4.Arguments.Count; num2++)
			{
				if (!((ILNode)item4.Arguments[num2]).Match(ILCode.Dup, out ILExpression arg3))
				{
					continue;
				}
				if (context.CalculateILSpans)
				{
					long index = 0L;
					bool done = false;
					ILExpression iLExpression = item4.Arguments[num2];
					while (true)
					{
						ILSpan allILSpans = iLExpression.GetAllILSpans(ref index, ref done);
						if (done)
						{
							break;
						}
						arg3.ILSpans.Add(allILSpans);
					}
				}
				item4.Arguments[num2] = arg3;
			}
		}
	}

	private void ReduceBranchInstructionSet(ILBlock block)
	{
		for (int i = 0; i < block.Body.Count; i++)
		{
			if (!(block.Body[i] is ILExpression { Prefixes: null } iLExpression))
			{
				continue;
			}
			ILCode code;
			switch (iLExpression.Code)
			{
			case ILCode.Brtrue:
			case ILCode.Switch:
				if (context.CalculateILSpans)
				{
					iLExpression.Arguments.Single().ILSpans.AddRange(iLExpression.ILSpans);
					iLExpression.ILSpans.Clear();
				}
				continue;
			case ILCode.Brfalse:
				code = ILCode.LogicNot;
				break;
			case ILCode.Beq:
				code = ILCode.Ceq;
				break;
			case ILCode.Bne_Un:
				code = ILCode.Cne;
				break;
			case ILCode.Bgt:
				code = ILCode.Cgt;
				break;
			case ILCode.Bgt_Un:
				code = ILCode.Cgt_Un;
				break;
			case ILCode.Ble:
				code = ILCode.Cle;
				break;
			case ILCode.Ble_Un:
				code = ILCode.Cle_Un;
				break;
			case ILCode.Blt:
				code = ILCode.Clt;
				break;
			case ILCode.Blt_Un:
				code = ILCode.Clt_Un;
				break;
			case ILCode.Bge:
				code = ILCode.Cge;
				break;
			case ILCode.Bge_Un:
				code = ILCode.Cge_Un;
				break;
			default:
				continue;
			}
			ILExpression iLExpression2 = new ILExpression(code, null, iLExpression.Arguments);
			block.Body[i] = new ILExpression(ILCode.Brtrue, iLExpression.Operand, iLExpression2);
			if (context.CalculateILSpans)
			{
				iLExpression2.ILSpans.AddRange(iLExpression.ILSpans);
			}
		}
	}

	private void IntroducePropertyAccessInstructions(ILNode node)
	{
		if (node is ILExpression iLExpression)
		{
			for (int i = 0; i < iLExpression.Arguments.Count; i++)
			{
				ILExpression iLExpression2 = iLExpression.Arguments[i];
				IntroducePropertyAccessInstructions(iLExpression2);
				IntroducePropertyAccessInstructions(iLExpression2, iLExpression, i);
			}
			return;
		}
		foreach (ILNode child in node.GetChildren())
		{
			IntroducePropertyAccessInstructions(child);
			if (child is ILExpression expr)
			{
				IntroducePropertyAccessInstructions(expr, null, -1);
			}
		}
	}

	private void IntroducePropertyAccessInstructions(ILExpression expr, ILExpression parentExpr, int posInParent)
	{
		ILVariable operand;
		if (expr.Code == ILCode.Call || expr.Code == ILCode.Callvirt)
		{
			IMethod method = (IMethod)expr.Operand;
			if ((method.DeclaringType as TypeSpec)?.TypeSig.RemovePinnedAndModifiers() is ArraySigBase arraySigBase)
			{
				switch (method.Name)
				{
				case "Get":
					expr.Code = ILCode.CallGetter;
					break;
				case "Set":
					expr.Code = ILCode.CallSetter;
					break;
				case "Address":
					if (method.MethodSig.GetRetType() is ByRefSig)
					{
						IMethod method2 = new MemberRefUser(method.Module, "Get", method.MethodSig?.Clone(), arraySigBase.ToTypeDefOrRef());
						if (method2.MethodSig != null)
						{
							method2.MethodSig.RetType = arraySigBase.Next;
						}
						expr.Operand = method2;
					}
					expr.Code = ILCode.CallGetter;
					if (parentExpr != null)
					{
						parentExpr.Arguments[posInParent] = new ILExpression(ILCode.AddressOf, null, expr);
					}
					break;
				}
			}
			else if (expr.Arguments.Count == 1 && method.Name == name_get_HasValue && method.MethodSig.GetParamCount() == 0 && method.MethodSig.GetRetType().RemovePinnedAndModifiers().GetElementType() == ElementType.Boolean && IsSystemNullable(method.DeclaringType))
			{
				expr.Code = ILCode.Cnotnull;
				expr.Operand = null;
				expr.Prefixes = null;
			}
			else
			{
				MethodDef methodDef = method.Resolve();
				if (methodDef?.IsGetter ?? method.Name.StartsWith("get_"))
				{
					expr.Code = ((expr.Code == ILCode.Call) ? ILCode.CallGetter : ILCode.CallvirtGetter);
				}
				else if (methodDef?.IsSetter ?? method.Name.StartsWith("set_"))
				{
					expr.Code = ((expr.Code == ILCode.Call) ? ILCode.CallSetter : ILCode.CallvirtSetter);
				}
			}
		}
		else if (expr.Code == ILCode.Newobj && expr.Arguments.Count == 2 && ((ILNode)expr.Arguments[0]).Match(ILCode.Ldloc, out operand) && expr.Arguments[1].Code == ILCode.Ldvirtftn && expr.Arguments[1].Arguments.Count == 1 && expr.Arguments[1].Arguments[0].MatchLdloc(operand))
		{
			if (context.CalculateILSpans)
			{
				expr.Arguments[1].Arguments[0].AddSelfAndChildrenRecursiveILSpans(expr.Arguments[1].ILSpans);
			}
			expr.Arguments[1].Arguments.Clear();
		}
	}

	private static bool IsSystemNullable(ITypeDefOrRef tdr)
	{
		return ((tdr as TypeSpec)?.TypeSig as GenericInstSig)?.GenericType.IsSystemNullable() ?? false;
	}

	private void SplitToBasicBlocks(ILBlock block)
	{
		List<ILNode> list = new List<ILNode>();
		ILLabel iLLabel = (block.Body.FirstOrDefault() as ILLabel) ?? new ILLabel
		{
			Name = "Block_" + nextLabelIndex++
		};
		ILBasicBlock iLBasicBlock = new ILBasicBlock();
		list.Add(iLBasicBlock);
		iLBasicBlock.Body.Add(iLLabel);
		block.EntryGoto = new ILExpression(ILCode.Br, iLLabel);
		if (block.Body.Count > 0)
		{
			if (block.Body[0] != iLLabel)
			{
				iLBasicBlock.Body.Add(block.Body[0]);
			}
			for (int i = 1; i < block.Body.Count; i++)
			{
				ILNode node = block.Body[i - 1];
				ILNode iLNode = block.Body[i];
				if (iLNode is ILLabel || iLNode is ILTryCatchBlock || node.IsConditionalControlFlow() || node.IsUnconditionalControlFlow())
				{
					ILLabel iLLabel2 = (iLNode as ILLabel) ?? new ILLabel
					{
						Name = "Block_" + nextLabelIndex++
					};
					if (!node.IsUnconditionalControlFlow())
					{
						iLBasicBlock.Body.Add(new ILExpression(ILCode.Br, iLLabel2));
					}
					iLBasicBlock = new ILBasicBlock();
					list.Add(iLBasicBlock);
					iLBasicBlock.Body.Add(iLLabel2);
					if (iLNode != iLLabel2)
					{
						iLBasicBlock.Body.Add(iLNode);
					}
				}
				else
				{
					iLBasicBlock.Body.Add(iLNode);
				}
			}
		}
		block.Body = list;
	}

	private void DuplicateReturnStatements(ILBlock method)
	{
		Optimize_Dict_ILLabel_ILNode.Clear();
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
		{
			List<ILNode> body = item.Body;
			for (int i = 0; i < body.Count - 1; i++)
			{
				if (body[i] is ILLabel key)
				{
					Optimize_Dict_ILLabel_ILNode[key] = body[i + 1];
				}
			}
		}
		foreach (ILBlock item2 in Optimize_List_ILBlock)
		{
			List<ILNode> body2 = item2.Body;
			for (int j = 0; j < body2.Count; j++)
			{
				if (!(body2[j] is ILExpression iLExpression) || (iLExpression.Code != ILCode.Br && iLExpression.Code != ILCode.Leave))
				{
					continue;
				}
				ILLabel iLLabel = (ILLabel)iLExpression.Operand;
				ILNode value;
				while (Optimize_Dict_ILLabel_ILNode.TryGetValue(iLLabel, out value) && value is ILLabel iLLabel2)
				{
					iLLabel = iLLabel2;
				}
				if (Optimize_Dict_ILLabel_ILNode.TryGetValue(iLLabel, out var value2))
				{
					if (!value2.Match(ILCode.Ret, out List<ILExpression> args))
					{
						continue;
					}
					ILVariable operand;
					object operand3;
					if (args.Count == 0)
					{
						body2[j] = new ILExpression(ILCode.Ret, null).WithILSpansFrom(context.CalculateILSpans, body2[j]);
					}
					else if (((ILNode)args[0]).Match(ILCode.Ldloc, out operand))
					{
						if (j > 0 && body2[j - 1].Match(ILCode.Stloc, out ILVariable operand2, out ILExpression arg) && operand2 == operand)
						{
							ILExpression iLExpression2 = new ILExpression(ILCode.Ret, null, arg);
							if (context.CalculateILSpans)
							{
								iLExpression2.ILSpans.AddRange(body2[j - 1].ILSpans);
								body2[j].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
							}
							body2[j - 1] = iLExpression2;
							body2.RemoveAt(j);
							j--;
						}
						else
						{
							body2[j] = new ILExpression(ILCode.Ret, null, new ILExpression(ILCode.Ldloc, operand)).WithILSpansFrom(context.CalculateILSpans, body2[j]);
						}
					}
					else if (((ILNode)args[0]).Match(ILCode.Ldc_I4, out operand3))
					{
						body2[j] = new ILExpression(ILCode.Ret, null, new ILExpression(ILCode.Ldc_I4, operand3)).WithILSpansFrom(context.CalculateILSpans, body2[j]);
					}
				}
				else if (method.Body.Count > 0 && method.Body.Last() == iLLabel)
				{
					body2[j] = new ILExpression(ILCode.Ret, null).WithILSpansFrom(context.CalculateILSpans, body2[j]);
				}
			}
		}
	}

	private void FlattenBasicBlocks(ILNode node)
	{
		if (node is ILBlock iLBlock)
		{
			ILBasicBlock iLBasicBlock = null;
			List<ILNode> list = new List<ILNode>();
			foreach (ILNode child in iLBlock.GetChildren())
			{
				FlattenBasicBlocks(child);
				if (child is ILBasicBlock iLBasicBlock2)
				{
					if (!(iLBasicBlock2.Body.FirstOrDefault() is ILLabel))
					{
						throw new Exception("Basic block has to start with a label. \n" + iLBasicBlock2.ToString());
					}
					if (iLBasicBlock2.Body.LastOrDefault() is ILExpression && !iLBasicBlock2.Body.LastOrDefault().IsUnconditionalControlFlow())
					{
						throw new Exception("Basci block has to end with unconditional control flow. \n" + iLBasicBlock2.ToString());
					}
					if (context.CalculateILSpans)
					{
						if (list.Count > 0)
						{
							list[list.Count - 1].EndILSpans.AddRange(iLBasicBlock2.ILSpans);
						}
						else
						{
							iLBlock.ILSpans.AddRange(iLBasicBlock2.ILSpans);
						}
					}
					foreach (ILNode child2 in iLBasicBlock2.GetChildren())
					{
						list.Add(child2);
					}
					iLBasicBlock = iLBasicBlock2;
				}
				else
				{
					list.Add(child);
					if (context.CalculateILSpans && iLBasicBlock != null)
					{
						child.ILSpans.AddRange(iLBasicBlock.EndILSpans);
					}
					iLBasicBlock = null;
				}
			}
			iLBlock.EntryGoto = null;
			iLBlock.Body = list;
			if (context.CalculateILSpans && iLBasicBlock != null)
			{
				iLBlock.EndILSpans.AddRange(iLBasicBlock.EndILSpans);
			}
		}
		else
		{
			if (node is ILExpression || node == null)
			{
				return;
			}
			foreach (ILNode child3 in node.GetChildren())
			{
				FlattenBasicBlocks(child3);
			}
		}
	}

	private void RemoveEndFinally(ILBlock method)
	{
		List<ILTryCatchBlock> selfAndChildrenRecursive = method.GetSelfAndChildrenRecursive((ILTryCatchBlock tc) => tc.FinallyBlock != null);
		for (int num = selfAndChildrenRecursive.Count - 1; num >= 0; num--)
		{
			ILTryCatchBlock iLTryCatchBlock = selfAndChildrenRecursive[num];
			ILLabel iLLabel = new ILLabel
			{
				Name = "EndFinally_" + nextLabelIndex++
			};
			iLTryCatchBlock.FinallyBlock.Body.Add(iLLabel);
			foreach (ILBlock item in iLTryCatchBlock.FinallyBlock.GetSelfAndChildrenRecursive(Optimize_List_ILBlock))
			{
				for (int num2 = 0; num2 < item.Body.Count; num2++)
				{
					if (item.Body[num2].Match(ILCode.Endfinally))
					{
						item.Body[num2] = new ILExpression(ILCode.Br, iLLabel).WithILSpansFrom(context.CalculateILSpans, item.Body[num2]);
					}
				}
			}
		}
	}

	private void ReduceIfNesting(ILNode node)
	{
		List<ILNode> optimize_List_ILNode = Optimize_List_ILNode;
		optimize_List_ILNode.Clear();
		optimize_List_ILNode.Add(node);
		while (optimize_List_ILNode.Count > 0)
		{
			node = optimize_List_ILNode[optimize_List_ILNode.Count - 1];
			optimize_List_ILNode.RemoveAt(optimize_List_ILNode.Count - 1);
			if (node is ILBlock iLBlock)
			{
				for (int i = 0; i < iLBlock.Body.Count; i++)
				{
					if (iLBlock.Body[i] is ILCondition iLCondition)
					{
						bool flag = iLCondition.TrueBlock.Body.LastOrDefault().IsUnconditionalControlFlow();
						bool flag2 = iLCondition.FalseBlock.Body.LastOrDefault().IsUnconditionalControlFlow();
						if (flag)
						{
							iLBlock.Body.InsertRange(i + 1, iLCondition.FalseBlock.GetChildren());
							iLCondition.FalseBlock = new ILBlock(CodeBracesRangeFlags.ConditionalBraces);
						}
						else if (flag2)
						{
							iLBlock.Body.InsertRange(i + 1, iLCondition.TrueBlock.GetChildren());
							iLCondition.TrueBlock = new ILBlock(CodeBracesRangeFlags.ConditionalBraces);
						}
						if (!iLCondition.TrueBlock.HasChildren && iLCondition.FalseBlock.HasChildren)
						{
							ILBlock trueBlock = iLCondition.TrueBlock;
							iLCondition.TrueBlock = iLCondition.FalseBlock;
							iLCondition.FalseBlock = trueBlock;
							iLCondition.Condition = new ILExpression(ILCode.LogicNot, null, iLCondition.Condition);
						}
					}
				}
			}
			foreach (ILNode child in node.GetChildren())
			{
				if (child != null && !(child is ILExpression))
				{
					optimize_List_ILNode.Add(child);
				}
			}
		}
	}

	private void RecombineVariables(ILBlock method)
	{
		Optimize_Dict_Local_ILVariable.Clear();
		ReplaceVariables(method, delegate(ILVariable v)
		{
			if (v.OriginalVariable == null)
			{
				return v;
			}
			if (!Optimize_Dict_Local_ILVariable.TryGetValue(v.OriginalVariable, out var value))
			{
				Optimize_Dict_Local_ILVariable.Add(v.OriginalVariable, v);
				return v;
			}
			return value;
		});
	}

	private void HandlePointerArithmetic(ILNode method)
	{
		foreach (ILExpression item in method.GetSelfAndChildrenRecursive(Optimize_List_ILExpression2))
		{
			List<ILExpression> arguments = item.Arguments;
			switch (item.Code)
			{
			case ILCode.Add:
			case ILCode.Add_Ovf:
			case ILCode.Add_Ovf_Un:
			{
				ILExpression pointerExpr2 = arguments[0];
				ILExpression adjustmentExpr2 = arguments[1];
				if (item.InferredType is PtrSig)
				{
					if (pointerExpr2.ExpectedType is PtrSig)
					{
						DivideOrMultiplyBySize(ref pointerExpr2, ref adjustmentExpr2, ((PtrSig)item.InferredType).Next, divide: true);
					}
					else if (adjustmentExpr2.ExpectedType is PtrSig)
					{
						DivideOrMultiplyBySize(ref adjustmentExpr2, ref pointerExpr2, ((PtrSig)item.InferredType).Next, divide: true);
					}
				}
				arguments[0] = pointerExpr2;
				arguments[1] = adjustmentExpr2;
				break;
			}
			case ILCode.Sub:
			case ILCode.Sub_Ovf:
			case ILCode.Sub_Ovf_Un:
			{
				ILExpression pointerExpr3 = arguments[0];
				ILExpression adjustmentExpr3 = arguments[1];
				if (item.InferredType is PtrSig && pointerExpr3.ExpectedType is PtrSig && !(adjustmentExpr3.InferredType is PtrSig))
				{
					DivideOrMultiplyBySize(ref pointerExpr3, ref adjustmentExpr3, ((PtrSig)item.InferredType).Next, divide: true);
				}
				arguments[0] = pointerExpr3;
				arguments[1] = adjustmentExpr3;
				break;
			}
			case ILCode.Conv_I8:
			{
				ILExpression adjustmentExpr = arguments[0];
				if (adjustmentExpr.Code == ILCode.Div && adjustmentExpr.InferredType.RemovePinnedAndModifiers().GetElementType() == ElementType.I)
				{
					ILExpression pointerExpr = adjustmentExpr.Arguments[0];
					if (pointerExpr.InferredType.RemovePinnedAndModifiers().GetElementType() == ElementType.I && (pointerExpr.Code == ILCode.Sub || pointerExpr.Code == ILCode.Sub_Ovf || pointerExpr.Code == ILCode.Sub_Ovf_Un))
					{
						PtrSig ptrSig = pointerExpr.Arguments[0].InferredType as PtrSig;
						PtrSig ptrSig2 = pointerExpr.Arguments[1].InferredType as PtrSig;
						if (ptrSig != null && ptrSig2 != null)
						{
							if (ptrSig.Next.RemovePinnedAndModifiers().GetElementType() == ElementType.Void || !default(SigComparer).Equals(ptrSig.Next, ptrSig2.Next))
							{
								ptrSig = (ptrSig2 = new PtrSig(corLib.Byte));
								pointerExpr.Arguments[0] = Cast(pointerExpr.Arguments[0], ptrSig);
								pointerExpr.Arguments[1] = Cast(pointerExpr.Arguments[1], ptrSig2);
							}
							DivideOrMultiplyBySize(ref pointerExpr, ref adjustmentExpr, ptrSig.Next, divide: false);
							if (arguments[0].Arguments[0] != pointerExpr)
							{
								throw new InvalidOperationException();
							}
						}
					}
				}
				arguments[0] = adjustmentExpr;
				break;
			}
			}
		}
	}

	private ILExpression UnwrapIntPtrCast(ILExpression expr)
	{
		if (expr.Code != ILCode.Conv_I && expr.Code != ILCode.Conv_U)
		{
			return expr;
		}
		ILExpression iLExpression = expr.Arguments[0];
		ElementType elementType = iLExpression.InferredType.GetElementType();
		if (elementType - 4 <= ElementType.U2)
		{
			if (context.CalculateILSpans)
			{
				iLExpression.ILSpans.AddRange(expr.ILSpans);
			}
			return iLExpression;
		}
		return expr;
	}

	private static ILExpression Cast(ILExpression expr, TypeSig type)
	{
		return new ILExpression(ILCode.Castclass, type.ToTypeDefOrRef(), expr)
		{
			InferredType = type,
			ExpectedType = type
		};
	}

	private void DivideOrMultiplyBySize(ref ILExpression pointerExpr, ref ILExpression adjustmentExpr, TypeSig elementType, bool divide)
	{
		adjustmentExpr = UnwrapIntPtrCast(adjustmentExpr);
		int informationAmount = TypeAnalysis.GetInformationAmount(elementType);
		ILExpression iLExpression;
		if (informationAmount <= 8)
		{
			if (informationAmount != 0)
			{
				if (informationAmount != 1 && informationAmount != 8)
				{
					goto IL_008c;
				}
			}
			else
			{
				pointerExpr = Cast(pointerExpr, new PtrSig(corLib.Byte));
			}
			iLExpression = new ILExpression(ILCode.Ldc_I4, 1);
		}
		else if (informationAmount != 16)
		{
			if (informationAmount != 32)
			{
				if (informationAmount != 64)
				{
					goto IL_008c;
				}
				iLExpression = new ILExpression(ILCode.Ldc_I4, 8);
			}
			else
			{
				iLExpression = new ILExpression(ILCode.Ldc_I4, 4);
			}
		}
		else
		{
			iLExpression = new ILExpression(ILCode.Ldc_I4, 2);
		}
		goto IL_009d;
		IL_008c:
		iLExpression = new ILExpression(ILCode.Sizeof, elementType.ToTypeDefOrRef());
		goto IL_009d;
		IL_009d:
		if ((divide && (adjustmentExpr.Code == ILCode.Mul || adjustmentExpr.Code == ILCode.Mul_Ovf || adjustmentExpr.Code == ILCode.Mul_Ovf_Un)) || (!divide && (adjustmentExpr.Code == ILCode.Div || adjustmentExpr.Code == ILCode.Div_Un)))
		{
			ILExpression iLExpression2 = adjustmentExpr.Arguments[1];
			if (iLExpression2.Code == iLExpression.Code && iLExpression.Operand.Equals(iLExpression2.Operand))
			{
				ILExpression iLExpression3 = adjustmentExpr.Arguments[0];
				if (context.CalculateILSpans)
				{
					iLExpression3.ILSpans.AddRange(adjustmentExpr.ILSpans);
					iLExpression2.AddSelfAndChildrenRecursiveILSpans(iLExpression3.ILSpans);
				}
				adjustmentExpr = UnwrapIntPtrCast(iLExpression3);
				return;
			}
		}
		if (adjustmentExpr.Code == iLExpression.Code)
		{
			if (iLExpression.Operand.Equals(adjustmentExpr.Operand))
			{
				adjustmentExpr = new ILExpression(ILCode.Ldc_I4, 1).WithILSpansFrom(context.CalculateILSpans, adjustmentExpr);
				return;
			}
			if (adjustmentExpr.Code == ILCode.Ldc_I4)
			{
				int num = (int)adjustmentExpr.Operand;
				int num2 = (int)iLExpression.Operand;
				if (num % num2 != 0)
				{
					pointerExpr = Cast(pointerExpr, new PtrSig(corLib.Byte));
				}
				else
				{
					adjustmentExpr.Operand = num / num2;
				}
				return;
			}
		}
		if (iLExpression.Code != ILCode.Ldc_I4 || (int)iLExpression.Operand != 1)
		{
			adjustmentExpr = new ILExpression(divide ? ILCode.Div_Un : ILCode.Mul, null, adjustmentExpr, iLExpression);
		}
	}

	public static void ReplaceVariables(ILNode node, Func<ILVariable, ILVariable> variableMapping)
	{
		if (node is ILExpression iLExpression)
		{
			if (iLExpression.Operand is ILVariable arg)
			{
				iLExpression.Operand = variableMapping(arg);
			}
			{
				foreach (ILExpression argument in iLExpression.Arguments)
				{
					ReplaceVariables(argument, variableMapping);
				}
				return;
			}
		}
		if (node is ILTryCatchBlock.CatchBlockBase { ExceptionVariable: not null } catchBlockBase)
		{
			catchBlockBase.ExceptionVariable = variableMapping(catchBlockBase.ExceptionVariable);
		}
		foreach (ILNode child in node.GetChildren())
		{
			ReplaceVariables(child, variableMapping);
		}
	}

	private bool TypeConversionSimplifications(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		bool flag = false;
		flag |= TransformDecimalCtorToConstant(expr);
		flag |= SimplifyLdcI4ConvI8(expr);
		flag |= RemoveConvIFromArrayCreation(expr);
		foreach (ILExpression argument in expr.Arguments)
		{
			flag |= TypeConversionSimplifications(block, null, argument, -1);
		}
		return flag;
	}

	private bool TransformDecimalCtorToConstant(ILExpression expr)
	{
		IField operand15;
		if (((ILNode)expr).Match(ILCode.Newobj, out IMethod operand, out List<ILExpression> args))
		{
			if (!operand.DeclaringType.Compare(systemString, decimalString))
			{
				return false;
			}
			MethodSig methodSig = operand.MethodSig;
			if (methodSig == null || methodSig.GetGenParamCount() != 0)
			{
				return false;
			}
			int operand3;
			int operand4;
			int operand5;
			int operand6;
			int operand7;
			if (args.Count == 1)
			{
				if (((ILNode)args[0]).Match(ILCode.Ldc_I4, out int operand2))
				{
					if (methodSig.Params.Count != 1)
					{
						return false;
					}
					ElementType elementType = methodSig.Params[0].RemovePinnedAndModifiers().GetElementType();
					if (elementType != ElementType.I4 && elementType != ElementType.U4)
					{
						return false;
					}
					expr.Code = ILCode.Ldc_Decimal;
					expr.Operand = ((elementType == ElementType.I4) ? new decimal(operand2) : new decimal((uint)operand2));
					expr.InferredType = operand.DeclaringType.ToTypeSig();
					if (context.CalculateILSpans)
					{
						foreach (ILExpression argument in expr.Arguments)
						{
							argument.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
						}
					}
					expr.Arguments.Clear();
					return true;
				}
				if (MatchLdci8(args[0], out var value))
				{
					if (methodSig.Params.Count != 1)
					{
						return false;
					}
					ElementType elementType2 = methodSig.Params[0].RemovePinnedAndModifiers().GetElementType();
					if (elementType2 != ElementType.I8 && elementType2 != ElementType.U8)
					{
						return false;
					}
					expr.Code = ILCode.Ldc_Decimal;
					expr.Operand = ((elementType2 == ElementType.I8) ? new decimal(value) : new decimal((ulong)value));
					expr.InferredType = operand.DeclaringType.ToTypeSig();
					if (context.CalculateILSpans)
					{
						foreach (ILExpression argument2 in expr.Arguments)
						{
							argument2.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
						}
					}
					expr.Arguments.Clear();
					return true;
				}
			}
			else if (args.Count == 5 && ((ILNode)expr.Arguments[0]).Match(ILCode.Ldc_I4, out operand3) && ((ILNode)expr.Arguments[1]).Match(ILCode.Ldc_I4, out operand4) && ((ILNode)expr.Arguments[2]).Match(ILCode.Ldc_I4, out operand5) && ((ILNode)expr.Arguments[3]).Match(ILCode.Ldc_I4, out operand6) && ((ILNode)expr.Arguments[4]).Match(ILCode.Ldc_I4, out operand7))
			{
				expr.Code = ILCode.Ldc_Decimal;
				expr.Operand = new decimal(operand3, operand4, operand5, operand6 != 0, (byte)Math.Min(28u, (uint)operand7));
				expr.InferredType = operand.DeclaringType.ToTypeSig();
				if (context.CalculateILSpans)
				{
					foreach (ILExpression argument3 in expr.Arguments)
					{
						argument3.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
					}
				}
				expr.Arguments.Clear();
				return true;
			}
		}
		else if (((ILNode)expr).Match(ILCode.Call, out operand, out args))
		{
			if (!operand.DeclaringType.Compare(systemString, decimalString))
			{
				return false;
			}
			if (operand.Name != nameCtor)
			{
				return false;
			}
			if (args.Count == 0)
			{
				return false;
			}
			MethodSig methodSig2 = operand.MethodSig;
			if (methodSig2 == null || methodSig2.GetGenParamCount() != 0)
			{
				return false;
			}
			if (!((ILNode)args[0]).Match(ILCode.Ldloca, out ILVariable operand8))
			{
				return false;
			}
			int operand10;
			int operand11;
			int operand12;
			int operand13;
			int operand14;
			if (args.Count == 2)
			{
				if (((ILNode)args[1]).Match(ILCode.Ldc_I4, out int operand9))
				{
					if (methodSig2.Params.Count != 1)
					{
						return false;
					}
					ElementType elementType3 = methodSig2.Params[0].RemovePinnedAndModifiers().GetElementType();
					if (elementType3 != ElementType.I4 && elementType3 != ElementType.U4)
					{
						return false;
					}
					ILExpression iLExpression = new ILExpression(ILCode.Ldc_Decimal, (elementType3 == ElementType.I4) ? new decimal(operand9) : new decimal((uint)operand9));
					iLExpression.InferredType = operand.DeclaringType.ToTypeSig();
					if (context.CalculateILSpans)
					{
						foreach (ILExpression argument4 in expr.Arguments)
						{
							argument4.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
						}
					}
					expr.Code = ILCode.Stloc;
					expr.Operand = operand8;
					expr.Arguments.Clear();
					expr.Arguments.Add(iLExpression);
					expr.InferredType = iLExpression.InferredType;
					expr.ExpectedType = null;
					return true;
				}
				if (MatchLdci8(args[1], out var value2))
				{
					if (methodSig2.Params.Count != 1)
					{
						return false;
					}
					ElementType elementType4 = methodSig2.Params[0].RemovePinnedAndModifiers().GetElementType();
					if (elementType4 != ElementType.I8 && elementType4 != ElementType.U8)
					{
						return false;
					}
					ILExpression iLExpression2 = new ILExpression(ILCode.Ldc_Decimal, (elementType4 == ElementType.I8) ? new decimal(value2) : new decimal((ulong)value2));
					iLExpression2.InferredType = operand.DeclaringType.ToTypeSig();
					if (context.CalculateILSpans)
					{
						foreach (ILExpression argument5 in expr.Arguments)
						{
							argument5.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
						}
					}
					expr.Code = ILCode.Stloc;
					expr.Operand = operand8;
					expr.Arguments.Clear();
					expr.Arguments.Add(iLExpression2);
					expr.InferredType = iLExpression2.InferredType;
					expr.ExpectedType = null;
					return true;
				}
			}
			else if (args.Count == 6 && ((ILNode)expr.Arguments[1]).Match(ILCode.Ldc_I4, out operand10) && ((ILNode)expr.Arguments[2]).Match(ILCode.Ldc_I4, out operand11) && ((ILNode)expr.Arguments[3]).Match(ILCode.Ldc_I4, out operand12) && ((ILNode)expr.Arguments[4]).Match(ILCode.Ldc_I4, out operand13) && ((ILNode)expr.Arguments[5]).Match(ILCode.Ldc_I4, out operand14))
			{
				ILExpression iLExpression3 = new ILExpression(ILCode.Ldc_Decimal, new decimal(operand10, operand11, operand12, operand13 != 0, (byte)Math.Min(28u, (uint)operand14)));
				iLExpression3.InferredType = operand.DeclaringType.ToTypeSig();
				if (context.CalculateILSpans)
				{
					foreach (ILExpression argument6 in expr.Arguments)
					{
						argument6.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
					}
				}
				expr.Code = ILCode.Stloc;
				expr.Operand = operand8;
				expr.Arguments.Clear();
				expr.Arguments.Add(iLExpression3);
				expr.InferredType = iLExpression3.InferredType;
				expr.ExpectedType = null;
				return true;
			}
		}
		else if (((ILNode)expr).Match(ILCode.Ldsfld, out operand15))
		{
			if (!operand15.DeclaringType.Compare(systemString, decimalString))
			{
				return false;
			}
			decimal num;
			if (operand15.Name == "MinValue")
			{
				num = decimal.MinValue;
			}
			else if (operand15.Name == "MaxValue")
			{
				num = decimal.MaxValue;
			}
			else if (operand15.Name == "Zero")
			{
				num = 0m;
			}
			else if (operand15.Name == "MinusOne")
			{
				num = -1m;
			}
			else
			{
				if (!(operand15.Name == "One"))
				{
					return false;
				}
				num = 1m;
			}
			expr.Code = ILCode.Ldc_Decimal;
			expr.Operand = num;
			expr.InferredType = operand15.DeclaringType.ToTypeSig();
			return true;
		}
		return false;
	}

	private static bool MatchLdci8(ILExpression expr, out long value)
	{
		if (((ILNode)expr).Match(ILCode.Ldc_I8, out value))
		{
			return true;
		}
		if ((expr.Code == ILCode.Conv_I8 || expr.Code == ILCode.Conv_U8) && ((ILNode)expr.Arguments[0]).Match(ILCode.Ldc_I4, out int operand))
		{
			value = ((expr.Code == ILCode.Conv_I8) ? ((long)operand) : ((long)(uint)operand));
			return true;
		}
		return false;
	}

	private bool SimplifyLdcI4ConvI8(ILExpression expr)
	{
		if (((ILNode)expr).Match(ILCode.Conv_I8, out ILExpression arg) && ((ILNode)arg).Match(ILCode.Ldc_I4, out int operand))
		{
			expr.Code = ILCode.Ldc_I8;
			expr.Operand = (long)operand;
			if (context.CalculateILSpans)
			{
				foreach (ILExpression argument in expr.Arguments)
				{
					argument.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
				}
			}
			expr.Arguments.Clear();
			return true;
		}
		return false;
	}

	private bool RemoveConvIFromArrayCreation(ILExpression expr)
	{
		if (((ILNode)expr).Match(ILCode.Newarr, out ITypeDefOrRef _, out ILExpression arg) && (((ILNode)arg).Match(ILCode.Conv_Ovf_I, out ILExpression arg2) || ((ILNode)arg).Match(ILCode.Conv_I, out arg2) || ((ILNode)arg).Match(ILCode.Conv_Ovf_I_Un, out arg2) || ((ILNode)arg).Match(ILCode.Conv_U, out arg2)))
		{
			expr.Arguments[0] = arg2;
			if (context.CalculateILSpans)
			{
				arg2.ILSpans.AddRange(arg.ILSpans);
			}
			return true;
		}
		return false;
	}

	private bool SimplifyLdObjAndStObj(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		bool modified = false;
		expr = SimplifyLdObjAndStObj(expr, ref modified);
		if (modified && body != null)
		{
			body[pos] = expr;
		}
		for (int i = 0; i < expr.Arguments.Count; i++)
		{
			expr.Arguments[i] = SimplifyLdObjAndStObj(expr.Arguments[i], ref modified);
			modified |= SimplifyLdObjAndStObj(block, null, expr.Arguments[i], -1);
		}
		return modified;
	}

	private ILExpression SimplifyLdObjAndStObj(ILExpression expr, ref bool modified)
	{
		if (expr.Code == ILCode.Initobj)
		{
			expr.Code = ILCode.Stobj;
			expr.Arguments.Add(new ILExpression(ILCode.DefaultValue, expr.Operand));
			modified = true;
		}
		else if (expr.Code == ILCode.Cpobj)
		{
			expr.Code = ILCode.Stobj;
			expr.Arguments[1] = new ILExpression(ILCode.Ldobj, expr.Operand, expr.Arguments[1]);
			modified = true;
		}
		ILCode? iLCode = null;
		if (expr.Match<ITypeDefOrRef>(ILCode.Stobj, out var operand, out var arg, out var arg2))
		{
			switch (arg.Code)
			{
			case ILCode.Ldelema:
				iLCode = ILCode.Stelem;
				break;
			case ILCode.Ldloca:
				iLCode = ILCode.Stloc;
				break;
			case ILCode.Ldflda:
				iLCode = ILCode.Stfld;
				break;
			case ILCode.Ldsflda:
				iLCode = ILCode.Stsfld;
				break;
			}
		}
		else if (((ILNode)expr).Match(ILCode.Ldobj, out operand, out arg))
		{
			switch (arg.Code)
			{
			case ILCode.Ldelema:
				iLCode = ILCode.Ldelem;
				break;
			case ILCode.Ldloca:
				iLCode = ILCode.Ldloc;
				break;
			case ILCode.Ldflda:
				iLCode = ILCode.Ldfld;
				break;
			case ILCode.Ldsflda:
				iLCode = ILCode.Ldsfld;
				break;
			}
		}
		if (iLCode.HasValue)
		{
			arg.Code = iLCode.Value;
			if (expr.Code == ILCode.Stobj)
			{
				arg.InferredType = expr.InferredType;
				arg.ExpectedType = expr.ExpectedType;
				arg.Arguments.Add(arg2);
			}
			if (context.CalculateILSpans)
			{
				arg.ILSpans.AddRange(expr.ILSpans);
			}
			modified = true;
			return arg;
		}
		return expr;
	}

	private void CachedDelegateInitializationWithField(ILBlock block, ref int i)
	{
		if (!(block.Body[i] is ILCondition iLCondition) || (iLCondition.Condition == null && iLCondition.TrueBlock == null) || iLCondition.FalseBlock == null || iLCondition.TrueBlock.Body.Count != 1 || iLCondition.FalseBlock.Body.Count != 0 || !iLCondition.Condition.Match(ILCode.LogicNot))
		{
			return;
		}
		ILExpression iLExpression = iLCondition.Condition.Arguments.Single();
		if (iLExpression == null || iLExpression.Code != ILCode.Ldsfld)
		{
			return;
		}
		FieldDef field = ((iLExpression.Operand is MemberRef) ? ((MemberRef)iLExpression.Operand).ResolveFieldWithinSameModule() : ((FieldDef)iLExpression.Operand));
		if (field == null || !field.IsCompilerGeneratedOrIsInCompilerGeneratedClass() || !(iLCondition.TrueBlock.Body[0] is ILExpression { Code: ILCode.Stsfld } iLExpression2) || ((IField)iLExpression2.Operand).ResolveFieldWithinSameModule() != field)
		{
			return;
		}
		ILExpression iLExpression3 = iLExpression2.Arguments[0];
		if (iLExpression3.Code != ILCode.Newobj || iLExpression3.Arguments.Count != 2 || iLExpression3.Arguments[0].Code != ILCode.Ldnull || iLExpression3.Arguments[1].Code != ILCode.Ldftn)
		{
			return;
		}
		MethodDef methodDef = ((IMethod)iLExpression3.Arguments[1].Operand).ResolveMethodWithinSameModule();
		if (!DelegateConstruction.IsAnonymousMethod(context, methodDef))
		{
			return;
		}
		ILNode iLNode = block.Body.ElementAtOrDefault(i + 1);
		if (iLNode == null || iLNode.GetSelfAndChildrenRecursive(Optimize_List_ILExpression).Count((ILExpression e) => e.Code == ILCode.Ldsfld && ((IField)e.Operand).ResolveFieldWithinSameModule() == field) != 1)
		{
			return;
		}
		foreach (ILExpression item in Optimize_List_ILExpression)
		{
			for (int num = 0; num < item.Arguments.Count; num++)
			{
				if (item.Arguments[num].Code != ILCode.Ldsfld || ((IField)item.Arguments[num].Operand).ResolveFieldWithinSameModule() != field)
				{
					continue;
				}
				if (context.CalculateILSpans)
				{
					long index = 0L;
					bool done = false;
					while (true)
					{
						ILSpan allILSpans = iLCondition.GetAllILSpans(ref index, ref done);
						if (done)
						{
							break;
						}
						iLExpression3.ILSpans.Add(allILSpans);
					}
					iLCondition.Condition.AddSelfAndChildrenRecursiveILSpans(iLExpression3.ILSpans);
					iLCondition.FalseBlock.AddSelfAndChildrenRecursiveILSpans(iLExpression3.ILSpans);
					index = 0L;
					done = false;
					while (true)
					{
						ILSpan allILSpans2 = iLCondition.TrueBlock.GetAllILSpans(ref index, ref done);
						if (done)
						{
							break;
						}
						iLExpression3.ILSpans.Add(allILSpans2);
					}
					foreach (ILNode item2 in iLCondition.TrueBlock.Body.Skip(1))
					{
						item2.AddSelfAndChildrenRecursiveILSpans(iLExpression3.ILSpans);
					}
					iLExpression3.ILSpans.AddRange(iLExpression2.ILSpans);
					foreach (ILExpression item3 in iLExpression2.Arguments.Skip(1))
					{
						item3.AddSelfAndChildrenRecursiveILSpans(iLExpression3.ILSpans);
					}
					iLExpression3.ILSpans.AddRange(item.Arguments[num].ILSpans);
				}
				item.Arguments[num] = iLExpression3;
				block.Body.RemoveAt(i);
				i -= GetILInlining(method).InlineInto(block, block.Body, i, aggressive: false);
				return;
			}
		}
	}

	private void CachedDelegateInitializationWithLocal(ILBlock block, ref int i)
	{
		if (!(block.Body[i] is ILCondition iLCondition) || (iLCondition.Condition == null && iLCondition.TrueBlock == null) || iLCondition.FalseBlock == null || iLCondition.TrueBlock.Body.Count != 1 || iLCondition.FalseBlock.Body.Count != 0 || !iLCondition.Condition.Match(ILCode.LogicNot))
		{
			return;
		}
		ILExpression iLExpression = iLCondition.Condition.Arguments.Single();
		if (iLExpression == null || iLExpression.Code != ILCode.Ldloc)
		{
			return;
		}
		ILVariable v = (ILVariable)iLExpression.Operand;
		if (!(iLCondition.TrueBlock.Body[0] is ILExpression { Code: ILCode.Stloc } iLExpression2) || (ILVariable)iLExpression2.Operand != v)
		{
			return;
		}
		ILExpression iLExpression3 = iLExpression2.Arguments[0];
		if (iLExpression3.Code != ILCode.Newobj || iLExpression3.Arguments.Count != 2 || iLExpression3.Arguments[0].Code != ILCode.Ldloc || iLExpression3.Arguments[1].Code != ILCode.Ldftn)
		{
			return;
		}
		MethodDef methodDef = ((IMethod)iLExpression3.Arguments[1].Operand).ResolveMethodWithinSameModule();
		if (!DelegateConstruction.IsAnonymousMethod(context, methodDef))
		{
			return;
		}
		ILNode iLNode = block.Body.ElementAtOrDefault(i + 1);
		if (iLNode == null || iLNode.GetSelfAndChildrenRecursive<ILExpression>().Count((ILExpression e) => e.Code == ILCode.Ldloc && (ILVariable)e.Operand == v) != 1)
		{
			return;
		}
		ILInlining iLInlining = GetILInlining(method);
		if (iLInlining.numLdloc.GetOrDefault(v) != 2 || iLInlining.numStloc.GetOrDefault(v) != 2 || iLInlining.numLdloca.GetOrDefault(v) != 0)
		{
			return;
		}
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
		{
			for (int num = 0; num < item.Body.Count; num++)
			{
				if (item.Body[num].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && operand == v && arg.Match(ILCode.Ldnull))
				{
					if (context.CalculateILSpans)
					{
						Utils.AddILSpans(item, item.Body, num);
					}
					item.Body.RemoveAt(num);
					if (item == block && num < i)
					{
						i--;
					}
					break;
				}
			}
		}
		if (context.CalculateILSpans)
		{
			long index = 0L;
			bool done = false;
			while (true)
			{
				ILSpan allILSpans = iLCondition.GetAllILSpans(ref index, ref done);
				if (done)
				{
					break;
				}
				iLExpression2.ILSpans.Add(allILSpans);
			}
			iLCondition.Condition.AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			iLCondition.FalseBlock.AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			index = 0L;
			done = false;
			while (true)
			{
				ILSpan allILSpans2 = iLCondition.TrueBlock.GetAllILSpans(ref index, ref done);
				if (done)
				{
					break;
				}
				iLExpression2.ILSpans.Add(allILSpans2);
			}
			foreach (ILNode item2 in iLCondition.TrueBlock.Body.Skip(1))
			{
				item2.AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			}
		}
		block.Body[i] = iLExpression2;
		iLInlining = GetILInlining(method);
		iLInlining.InlineIfPossible(block, block.Body, ref i);
	}

	private bool MakeAssignmentExpression(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		if (!((ILNode)expr).Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || !operand.GeneratedByDecompiler)
		{
			return false;
		}
		if (!(body.ElementAtOrDefault(pos + 1) is ILExpression iLExpression))
		{
			return false;
		}
		if (((ILNode)iLExpression).Match(ILCode.Stloc, out ILVariable _, out ILExpression arg2) && arg2.MatchLdloc(operand))
		{
			ILExpression iLExpression2 = body.ElementAtOrDefault(pos + 2) as ILExpression;
			if (StoreCanBeConvertedToAssignment(iLExpression2, operand))
			{
				ILInlining iLInlining = GetILInlining(method);
				if (iLInlining.numLdloc.GetOrDefault(operand) == 2 && iLInlining.numStloc.GetOrDefault(operand) == 1)
				{
					body.RemoveAt(pos + 2);
					body.RemoveAt(pos);
					if (context.CalculateILSpans)
					{
						iLExpression.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
					}
					iLExpression.Arguments[0] = iLExpression2;
					if (context.CalculateILSpans)
					{
						expr.AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
						iLExpression2.Arguments[iLExpression2.Arguments.Count - 1].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
					}
					iLExpression2.Arguments[iLExpression2.Arguments.Count - 1] = arg;
					iLInlining.InlineIfPossible(block, body, ref pos);
					return true;
				}
			}
			body.RemoveAt(pos + 1);
			if (context.CalculateILSpans)
			{
				iLExpression.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
			}
			iLExpression.Arguments[0] = arg;
			if (context.CalculateILSpans)
			{
				expr.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
			}
			expr.Arguments[0] = iLExpression;
			return true;
		}
		if ((iLExpression.Code == ILCode.Stsfld || iLExpression.Code == ILCode.CallSetter || iLExpression.Code == ILCode.CallvirtSetter) && iLExpression.Arguments.Count == 1 && iLExpression.Arguments[0].MatchLdloc(operand))
		{
			body.RemoveAt(pos + 1);
			if (context.CalculateILSpans)
			{
				iLExpression.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
			}
			iLExpression.Arguments[0] = arg;
			if (context.CalculateILSpans)
			{
				expr.Arguments[0].AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
			}
			expr.Arguments[0] = iLExpression;
			return true;
		}
		return false;
	}

	private bool StoreCanBeConvertedToAssignment(ILExpression store, ILVariable exprVar)
	{
		if (store == null)
		{
			return false;
		}
		switch (store.Code)
		{
		default:
			if (!store.Code.IsStoreToArray())
			{
				return false;
			}
			break;
		case ILCode.Stfld:
		case ILCode.Stsfld:
		case ILCode.Stobj:
		case ILCode.Stloc:
		case ILCode.CallSetter:
		case ILCode.CallvirtSetter:
		case ILCode.CallReadOnlySetter:
			break;
		}
		if (store.Arguments.Last().Code == ILCode.Ldloc)
		{
			return store.Arguments.Last().Operand == exprVar;
		}
		return false;
	}

	private bool MakeCompoundAssignments(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		bool flag = false;
		flag |= MakeCompoundAssignment(expr);
		foreach (ILExpression argument in expr.Arguments)
		{
			flag |= MakeCompoundAssignments(block, null, argument, -1);
		}
		if (flag && body != null)
		{
			GetILInlining(method).InlineInto(block, body, pos, aggressive: false);
		}
		return flag;
	}

	private bool MakeCompoundAssignment(ILExpression expr)
	{
		ILCode iLCode;
		switch (expr.Code)
		{
		case ILCode.Stelem:
			iLCode = ILCode.Ldelem;
			break;
		case ILCode.Stfld:
			iLCode = ILCode.Ldfld;
			break;
		case ILCode.Stobj:
			iLCode = ILCode.Ldobj;
			break;
		case ILCode.CallSetter:
			iLCode = ILCode.CallGetter;
			break;
		case ILCode.CallvirtSetter:
			iLCode = ILCode.CallvirtGetter;
			break;
		default:
			return false;
		}
		bool flag = false;
		for (int i = 0; i < expr.Arguments.Count - 1; i++)
		{
			if (!((ILNode)expr.Arguments[i]).Match(ILCode.Ldloc, out ILVariable operand))
			{
				return false;
			}
			flag |= operand.GeneratedByDecompiler;
		}
		if (!flag)
		{
			return false;
		}
		ILExpression iLExpression = expr.Arguments.Last();
		bool flag2 = false;
		if (iLExpression.Code == ILCode.NullableOf)
		{
			iLExpression = iLExpression.Arguments[0];
			flag2 = true;
		}
		if (!CanBeRepresentedAsCompoundAssignment(iLExpression))
		{
			return false;
		}
		ILExpression iLExpression2 = iLExpression.Arguments[0];
		if (flag2)
		{
			if (iLExpression2.Code != ILCode.ValueOf)
			{
				return false;
			}
			iLExpression2 = iLExpression2.Arguments[0];
		}
		if (iLExpression2.Code != iLCode)
		{
			return false;
		}
		for (int j = 0; j < iLExpression2.Arguments.Count; j++)
		{
			if (!iLExpression2.Arguments[j].MatchLdloc((ILVariable)expr.Arguments[j].Operand))
			{
				return false;
			}
		}
		expr.Code = ILCode.CompoundAssignment;
		expr.Operand = null;
		if (context.CalculateILSpans)
		{
			for (int k = 0; k < iLExpression2.Arguments.Count; k++)
			{
				expr.Arguments[k].AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
			}
		}
		expr.Arguments.RemoveRange(0, iLExpression2.Arguments.Count);
		return true;
	}

	private static bool CanBeRepresentedAsCompoundAssignment(ILExpression expr)
	{
		switch (expr.Code)
		{
		case ILCode.Add:
		case ILCode.Sub:
		case ILCode.Mul:
		case ILCode.Div:
		case ILCode.Div_Un:
		case ILCode.Rem:
		case ILCode.Rem_Un:
		case ILCode.And:
		case ILCode.Or:
		case ILCode.Xor:
		case ILCode.Shl:
		case ILCode.Shr:
		case ILCode.Shr_Un:
		case ILCode.Add_Ovf:
		case ILCode.Add_Ovf_Un:
		case ILCode.Mul_Ovf:
		case ILCode.Mul_Ovf_Un:
		case ILCode.Sub_Ovf:
		case ILCode.Sub_Ovf_Un:
			return true;
		case ILCode.Call:
			if (!(expr.Operand is IMethod { MethodSig: not null } method) || method.MethodSig.HasThis || expr.Arguments.Count != 2)
			{
				return false;
			}
			switch (method.Name)
			{
			case "op_Addition":
			case "op_Subtraction":
			case "op_Multiply":
			case "op_Division":
			case "op_Modulus":
			case "op_BitwiseAnd":
			case "op_BitwiseOr":
			case "op_ExclusiveOr":
			case "op_LeftShift":
			case "op_RightShift":
				return true;
			default:
				return false;
			}
		default:
			return false;
		}
	}

	private bool IntroducePostIncrement(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		bool result = IntroducePostIncrementForVariables(body, expr, pos);
		ILExpression iLExpression = IntroducePostIncrementForInstanceFields(expr);
		if (iLExpression != null)
		{
			result = true;
			body[pos] = iLExpression;
			GetILInlining(method).InlineIfPossible(block, body, ref pos);
		}
		return result;
	}

	private bool IntroducePostIncrementForVariables(List<ILNode> body, ILExpression expr, int pos)
	{
		if (!((ILNode)expr).Match(ILCode.Stloc, out ILVariable operand, out ILExpression exprInit) || !operand.GeneratedByDecompiler)
		{
			return false;
		}
		ILExpression nextExpr = body.ElementAtOrDefault(pos + 1) as ILExpression;
		if (nextExpr == null)
		{
			return false;
		}
		ILCode code = exprInit.Code;
		ILCode code2 = nextExpr.Code;
		bool flag = false;
		switch (code)
		{
		case ILCode.Ldloc:
		{
			if (code2 != ILCode.Stloc)
			{
				return false;
			}
			ILVariable iLVariable = (ILVariable)exprInit.Operand;
			ILVariable iLVariable2 = (ILVariable)nextExpr.Operand;
			if (iLVariable != iLVariable2)
			{
				if (iLVariable.OriginalVariable == null || iLVariable.OriginalVariable != iLVariable2.OriginalVariable)
				{
					return false;
				}
				flag = true;
			}
			break;
		}
		case ILCode.Ldsfld:
			if (code2 != ILCode.Stsfld)
			{
				return false;
			}
			if (exprInit.Operand != nextExpr.Operand)
			{
				return false;
			}
			break;
		case ILCode.CallGetter:
			if (exprInit.Arguments.Count != 0)
			{
				return false;
			}
			if (code2 != ILCode.CallSetter && code2 != ILCode.CallReadOnlySetter)
			{
				return false;
			}
			if (!IsGetterSetterPair(exprInit.Operand, nextExpr.Operand))
			{
				return false;
			}
			break;
		default:
			return false;
		}
		ILExpression iLExpression = nextExpr.Arguments[0];
		ILCode incrementCode = GetIncrementCode(iLExpression, out var incrementAmount);
		if (incrementAmount == 0 || !iLExpression.Arguments[0].MatchLdloc(operand))
		{
			return false;
		}
		if (flag)
		{
			ReplaceVariables(method, (ILVariable oldVar) => (oldVar != nextExpr.Operand) ? oldVar : ((ILVariable)exprInit.Operand));
		}
		switch (code)
		{
		case ILCode.Ldloc:
			exprInit.Code = ILCode.Ldloca;
			break;
		case ILCode.Ldsfld:
			exprInit.Code = ILCode.Ldsflda;
			break;
		case ILCode.CallGetter:
			exprInit = new ILExpression(ILCode.AddressOf, null, exprInit);
			break;
		}
		expr.Arguments[0] = new ILExpression(incrementCode, incrementAmount, exprInit);
		if (context.CalculateILSpans)
		{
			nextExpr.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
		}
		body.RemoveAt(pos + 1);
		return true;
	}

	private static bool IsGetterSetterPair(object getterOperand, object setterOperand)
	{
		IMethod method = getterOperand as IMethod;
		IMethod method2 = setterOperand as IMethod;
		if (method == null || method2 == null || !method.IsMethod || !method2.IsMethod)
		{
			return false;
		}
		if (!TypeAnalysis.IsSameType(method.DeclaringType, method2.DeclaringType))
		{
			return false;
		}
		MethodDef methodDef = method.Resolve();
		MethodDef methodDef2 = method2.Resolve();
		if (methodDef == null || methodDef2 == null)
		{
			return false;
		}
		foreach (PropertyDef property in methodDef.DeclaringType.Properties)
		{
			if (property.GetMethod == methodDef)
			{
				return property.SetMethod == methodDef2;
			}
		}
		return false;
	}

	private ILExpression IntroducePostIncrementForInstanceFields(ILExpression expr)
	{
		if (expr.Code != ILCode.Stfld && !expr.Code.IsStoreToArray() && expr.Code != ILCode.Stobj && expr.Code != ILCode.CallSetter && expr.Code != ILCode.CallvirtSetter)
		{
			return null;
		}
		for (int i = 0; i < expr.Arguments.Count - 1; i++)
		{
			if (expr.Arguments[i].Code != ILCode.Ldloc)
			{
				return null;
			}
		}
		ILExpression iLExpression = expr.Arguments[expr.Arguments.Count - 1];
		ILCode incrementCode = GetIncrementCode(iLExpression, out var incrementAmount);
		if (incrementAmount == 0 || !((ILNode)iLExpression.Arguments[0]).Match(ILCode.Stloc, out ILVariable _, out ILExpression arg))
		{
			return null;
		}
		if (expr.Code == ILCode.Stfld)
		{
			if (arg.Code != ILCode.Ldfld)
			{
				return null;
			}
			IField field = (IField)arg.Operand;
			IField field2 = (IField)expr.Operand;
			if (!TypeAnalysis.IsSameType(field.DeclaringType, field2.DeclaringType) || !(field.Name == field2.Name) || field.FieldSig == null || field2.FieldSig == null || !TypeAnalysis.IsSameType(field.FieldSig.Type, field2.FieldSig.Type))
			{
				return null;
			}
		}
		else if (expr.Code == ILCode.Stobj)
		{
			if (arg.Code != ILCode.Ldobj || arg.Operand != expr.Operand)
			{
				return null;
			}
		}
		else if (expr.Code == ILCode.CallSetter)
		{
			if (arg.Code != ILCode.CallGetter || !IsGetterSetterPair(arg.Operand, expr.Operand))
			{
				return null;
			}
		}
		else if (expr.Code == ILCode.CallvirtSetter)
		{
			if (arg.Code != ILCode.CallvirtGetter || !IsGetterSetterPair(arg.Operand, expr.Operand))
			{
				return null;
			}
		}
		else if (!arg.Code.IsLoadFromArray())
		{
			return null;
		}
		for (int j = 0; j < arg.Arguments.Count; j++)
		{
			if (!arg.Arguments[j].MatchLdloc((ILVariable)expr.Arguments[j].Operand))
			{
				return null;
			}
		}
		ILExpression iLExpression2 = iLExpression.Arguments[0];
		if (context.CalculateILSpans)
		{
			iLExpression2.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			iLExpression2.ILSpans.AddRange(expr.ILSpans);
			iLExpression2.ILSpans.AddRange(iLExpression.ILSpans);
			for (int k = 0; k < expr.Arguments.Count - 1; k++)
			{
				expr.Arguments[k].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			}
			for (int l = 1; l < iLExpression.Arguments.Count; l++)
			{
				iLExpression.Arguments[l].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
			}
		}
		if (expr.Code == ILCode.Stobj)
		{
			iLExpression2.Arguments[0] = new ILExpression(ILCode.PostIncrement, incrementAmount, arg.Arguments[0]);
		}
		else if (expr.Code == ILCode.CallSetter || expr.Code == ILCode.CallvirtSetter)
		{
			arg = new ILExpression(ILCode.AddressOf, null, arg);
			iLExpression2.Arguments[0] = new ILExpression(ILCode.PostIncrement, incrementAmount, arg);
		}
		else
		{
			iLExpression2.Arguments[0] = new ILExpression(ILCode.PostIncrement, incrementAmount, arg);
			arg.Code = ((expr.Code == ILCode.Stfld) ? ILCode.Ldflda : ILCode.Ldelema);
		}
		return iLExpression2;
	}

	private ILCode GetIncrementCode(ILExpression addExpr, out int incrementAmount)
	{
		bool flag = false;
		ILCode result;
		switch (addExpr.Code)
		{
		case ILCode.Add:
			result = ILCode.PostIncrement;
			break;
		case ILCode.Add_Ovf:
			result = ILCode.PostIncrement_Ovf;
			break;
		case ILCode.Add_Ovf_Un:
			result = ILCode.PostIncrement_Ovf_Un;
			break;
		case ILCode.Sub:
			result = ILCode.PostIncrement;
			flag = true;
			break;
		case ILCode.Sub_Ovf:
			result = ILCode.PostIncrement_Ovf;
			flag = true;
			break;
		case ILCode.Sub_Ovf_Un:
			result = ILCode.PostIncrement_Ovf_Un;
			flag = true;
			break;
		default:
			incrementAmount = 0;
			return ILCode.Nop;
		}
		if (((ILNode)addExpr.Arguments[1]).Match(ILCode.Ldc_I4, out incrementAmount) && (incrementAmount == -1 || incrementAmount == 1))
		{
			if (flag)
			{
				incrementAmount = -incrementAmount;
			}
			return result;
		}
		incrementAmount = 0;
		return ILCode.Nop;
	}

	private bool IntroduceFixedStatements(ILBlockBase block, List<ILNode> body, int i)
	{
		if (!MatchFixedInitializer(body, i, out var pinnedVar, out var initValue, out var nextPos))
		{
			return false;
		}
		if (body.ElementAtOrDefault(nextPos) is ILFixedStatement iLFixedStatement && iLFixedStatement.BodyBlock.Body.LastOrDefault() is ILExpression { Code: ILCode.Stloc } iLExpression && iLExpression.Operand == pinnedVar && IsNullOrZero(iLExpression.Arguments[0]))
		{
			iLFixedStatement.Initializers.Insert(0, initValue);
			if (context.CalculateILSpans)
			{
				for (int j = i; j < nextPos; j++)
				{
					initValue.ILSpans.AddRange(body[j].GetSelfAndChildrenRecursiveILSpans().ToArray());
				}
			}
			body.RemoveRange(i, nextPos - i);
			if (context.CalculateILSpans)
			{
				Utils.AddILSpans(iLFixedStatement.BodyBlock, iLFixedStatement.BodyBlock.Body, iLFixedStatement.BodyBlock.Body.Count - 1);
			}
			iLFixedStatement.BodyBlock.Body.RemoveAt(iLFixedStatement.BodyBlock.Body.Count - 1);
			if (pinnedVar.Type is ByRefSig)
			{
				pinnedVar.Type = new PtrSig(((ByRefSig)pinnedVar.Type).Next);
			}
			return true;
		}
		int k;
		ILVariable operand;
		ILExpression arg;
		for (k = nextPos; k < body.Count && (!body[k].Match(ILCode.Stloc, out operand, out arg) || operand != pinnedVar || !IsNullOrZero(arg)); k++)
		{
		}
		ILFixedStatement iLFixedStatement2 = new ILFixedStatement();
		iLFixedStatement2.Initializers.Add(initValue);
		iLFixedStatement2.BodyBlock = new ILBlock(body.GetRange(nextPos, k - nextPos), CodeBracesRangeFlags.FixedBraces);
		if (context.CalculateILSpans)
		{
			for (int l = i; l < nextPos; l++)
			{
				initValue.ILSpans.AddRange(body[l].GetSelfAndChildrenRecursiveILSpans().ToArray());
			}
		}
		body.RemoveRange(i + 1, Math.Min(k, body.Count - 1) - i);
		body[i] = iLFixedStatement2;
		if (pinnedVar.Type is ByRefSig)
		{
			pinnedVar.Type = new PtrSig(((ByRefSig)pinnedVar.Type).Next);
		}
		return true;
	}

	private bool IsNullOrZero(ILExpression expr)
	{
		if (expr.Code == ILCode.Conv_U || expr.Code == ILCode.Conv_I)
		{
			expr = expr.Arguments[0];
		}
		if (expr.Code != ILCode.Ldc_I4 || (int)expr.Operand != 0)
		{
			return expr.Code == ILCode.Ldnull;
		}
		return true;
	}

	private bool MatchFixedInitializer(List<ILNode> body, int i, out ILVariable pinnedVar, out ILExpression initValue, out int nextPos)
	{
		if (body[i].Match(ILCode.Stloc, out pinnedVar, out initValue) && pinnedVar.IsPinned && !IsNullOrZero(initValue))
		{
			initValue = (ILExpression)body[i];
			nextPos = i + 1;
			HandleStringFixing(pinnedVar, body, ref nextPos, ref initValue);
			return true;
		}
		if (body[i] is ILCondition iLCondition && MatchFixedArrayInitializerCondition(iLCondition.Condition, out var initValue2))
		{
			ILVariable iLVariable = (ILVariable)initValue2.Operand;
			if (iLCondition.TrueBlock != null && iLCondition.TrueBlock.Body.Count == 1 && iLCondition.TrueBlock.Body[0].Match(ILCode.Stloc, out pinnedVar, out ILExpression arg) && pinnedVar.IsPinned && IsNullOrZero(arg) && iLCondition.FalseBlock != null && iLCondition.FalseBlock.Body.Count == 1 && iLCondition.FalseBlock.Body[0] is ILFixedStatement)
			{
				ILFixedStatement iLFixedStatement = (ILFixedStatement)iLCondition.FalseBlock.Body[0];
				if (iLFixedStatement.Initializers.Count == 1 && iLFixedStatement.BodyBlock.Body.Count == 0 && ((ILNode)iLFixedStatement.Initializers[0]).Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg2) && operand == pinnedVar && arg2.Code == ILCode.Ldelema && ((ILNode)arg2.Arguments[0]).Match(ILCode.Ldloc, out ILVariable operand2) && operand2 == iLVariable && IsNullOrZero(arg2.Arguments[1]))
				{
					if (initValue2.Code == ILCode.Stloc)
					{
						ILInlining iLInlining = GetILInlining(method);
						if (iLInlining.numLdloc.GetOrDefault(iLVariable) == 2 && iLInlining.numStloc.GetOrDefault(iLVariable) == 1 && iLInlining.numLdloca.GetOrDefault(iLVariable) == 0)
						{
							initValue2 = initValue2.Arguments[0];
						}
					}
					initValue = new ILExpression(ILCode.Stloc, pinnedVar, initValue2);
					nextPos = i + 1;
					return true;
				}
			}
		}
		initValue = null;
		nextPos = -1;
		return false;
	}

	private bool MatchFixedArrayInitializerCondition(ILExpression condition, out ILExpression initValue)
	{
		if (((ILNode)condition).Match(ILCode.LogicNot, out ILExpression arg) && arg.Code == ILCode.LogicAnd)
		{
			initValue = UnpackDoubleNegation(arg.Arguments[0]);
			if (((ILNode)initValue).Match(ILCode.Ldloc, out ILVariable operand) || ((ILNode)initValue).Match(ILCode.Stloc, out operand, out ILExpression _))
			{
				ILExpression iLExpression = arg.Arguments[1];
				if (iLExpression.Code == ILCode.Conv_I4)
				{
					iLExpression = iLExpression.Arguments[0];
				}
				if (iLExpression.Code == ILCode.Ldlen)
				{
					return iLExpression.Arguments[0].MatchLdloc(operand);
				}
				return false;
			}
		}
		initValue = null;
		return false;
	}

	private ILExpression UnpackDoubleNegation(ILExpression expr)
	{
		if (((ILNode)expr).Match(ILCode.LogicNot, out ILExpression arg) && ((ILNode)arg).Match(ILCode.LogicNot, out arg))
		{
			return arg;
		}
		return expr;
	}

	private bool HandleStringFixing(ILVariable pinnedVar, List<ILNode> body, ref int pos, ref ILExpression fixedStmtInitializer)
	{
		if (pos >= body.Count)
		{
			return false;
		}
		if (!body[pos].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || !((ILNode)arg).Match(ILCode.Stloc, out ILVariable operand2, out ILExpression arg2))
		{
			return false;
		}
		if (!operand.GeneratedByDecompiler || !operand2.GeneratedByDecompiler)
		{
			return false;
		}
		if (arg2.Code == ILCode.Conv_I || arg2.Code == ILCode.Conv_U)
		{
			arg2 = arg2.Arguments[0];
		}
		if (!arg2.MatchLdloc(pinnedVar))
		{
			return false;
		}
		if (!(body[pos + 1] is ILCondition { TrueBlock: not null } iLCondition) || iLCondition.TrueBlock.Body.Count != 1 || (iLCondition.FalseBlock != null && iLCondition.FalseBlock.Body.Count != 0))
		{
			return false;
		}
		if (!UnpackDoubleNegation(iLCondition.Condition).MatchLdloc(operand))
		{
			return false;
		}
		if (!iLCondition.TrueBlock.Body[0].Match(ILCode.Stloc, out ILVariable operand3, out ILExpression arg3) || operand3 != operand2 || arg3.Code != ILCode.Add)
		{
			return false;
		}
		if (!arg3.Arguments[0].MatchLdloc(operand))
		{
			return false;
		}
		if (!((ILNode)arg3.Arguments[1]).Match(ILCode.Call, out IMethod operand4) && !((ILNode)arg3.Arguments[1]).Match(ILCode.CallGetter, out operand4))
		{
			return false;
		}
		if (!(operand4.Name == "get_OffsetToStringData") || operand4.DeclaringType == null || !(operand4.DeclaringType.FullName == "System.Runtime.CompilerServices.RuntimeHelpers"))
		{
			return false;
		}
		if (body[pos + 2].Match(ILCode.Stloc, out ILVariable operand5, out arg3) && arg3.MatchLdloc(operand2))
		{
			pos += 3;
			fixedStmtInitializer.Operand = operand5;
			return true;
		}
		return false;
	}

	private bool SimplifyLogicNot(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		bool modified = false;
		expr = SimplifyLogicNot(expr, ref modified);
		return modified;
	}

	private ILExpression SimplifyLogicNot(ILExpression expr, ref bool modified)
	{
		ILExpression iLExpression;
		if (expr.Code == ILCode.Ceq && expr.Arguments[0].InferredType.GetElementType() == ElementType.Boolean && (iLExpression = expr.Arguments[1]).Code == ILCode.Ldc_I4 && (int)iLExpression.Operand == 0)
		{
			expr.Code = ILCode.LogicNot;
			if (context.CalculateILSpans)
			{
				iLExpression.AddSelfAndChildrenRecursiveILSpans(expr.ILSpans);
			}
			expr.Arguments.RemoveAt(1);
			modified = true;
		}
		ILExpression iLExpression2 = null;
		while (expr.Code == ILCode.LogicNot)
		{
			iLExpression = expr.Arguments[0];
			if (iLExpression.Code == ILCode.LogicNot)
			{
				iLExpression2 = iLExpression.Arguments[0];
				if (context.CalculateILSpans)
				{
					iLExpression2.ILSpans.AddRange(expr.ILSpans);
					iLExpression2.ILSpans.AddRange(iLExpression.ILSpans);
				}
				expr = iLExpression2;
				continue;
			}
			if (SimplifyLogicNotArgument(expr))
			{
				iLExpression2 = (expr = iLExpression);
			}
			break;
		}
		for (int i = 0; i < expr.Arguments.Count; i++)
		{
			iLExpression = SimplifyLogicNot(expr.Arguments[i], ref modified);
			if (iLExpression != null)
			{
				expr.Arguments[i] = iLExpression;
				modified = true;
			}
		}
		return iLExpression2;
	}

	private bool SimplifyLogicNotArgument(ILExpression expr)
	{
		ILExpression iLExpression = expr.Arguments[0];
		ILCode code;
		switch (iLExpression.Code)
		{
		case ILCode.Cnull:
			code = ILCode.Cnotnull;
			break;
		case ILCode.Cnotnull:
			code = ILCode.Cnull;
			break;
		case ILCode.Ceq:
			code = ILCode.Cne;
			break;
		case ILCode.Cne:
			code = ILCode.Ceq;
			break;
		case ILCode.Cgt:
			code = ILCode.Cle;
			break;
		case ILCode.Cgt_Un:
			code = ILCode.Cle_Un;
			break;
		case ILCode.Cge:
			code = ILCode.Clt;
			break;
		case ILCode.Cge_Un:
			code = ILCode.Clt_Un;
			break;
		case ILCode.Clt:
			code = ILCode.Cge;
			break;
		case ILCode.Clt_Un:
			code = ILCode.Cge_Un;
			break;
		case ILCode.Cle:
			code = ILCode.Cgt;
			break;
		case ILCode.Cle_Un:
			code = ILCode.Cgt_Un;
			break;
		default:
			return false;
		}
		iLExpression.Code = code;
		if (context.CalculateILSpans)
		{
			iLExpression.ILSpans.AddRange(expr.ILSpans);
		}
		return true;
	}

	private bool SimplifyShiftOperators(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		bool modified = false;
		SimplifyShiftOperators(expr, ref modified);
		return modified;
	}

	private void SimplifyShiftOperators(ILExpression expr, ref bool modified)
	{
		for (int i = 0; i < expr.Arguments.Count; i++)
		{
			SimplifyShiftOperators(expr.Arguments[i], ref modified);
		}
		if (expr.Code != ILCode.Shl && expr.Code != ILCode.Shr && expr.Code != ILCode.Shr_Un)
		{
			return;
		}
		ILExpression iLExpression = expr.Arguments[1];
		if (iLExpression.Code != ILCode.And || iLExpression.Arguments[1].Code != ILCode.Ldc_I4 || expr.InferredType == null)
		{
			return;
		}
		int num;
		switch (expr.InferredType.ElementType)
		{
		default:
			return;
		case ElementType.I4:
		case ElementType.U4:
			num = 31;
			break;
		case ElementType.I8:
		case ElementType.U8:
			num = 63;
			break;
		}
		if ((int)iLExpression.Arguments[1].Operand == num)
		{
			ILExpression iLExpression2 = iLExpression.Arguments[0];
			if (context.CalculateILSpans)
			{
				iLExpression2.ILSpans.AddRange(iLExpression.ILSpans);
				iLExpression2.ILSpans.AddRange(iLExpression.Arguments[1].ILSpans);
			}
			expr.Arguments[1] = iLExpression2;
			modified = true;
		}
	}

	private bool InlineExpressionTreeParameterDeclarations(ILBlockBase block, List<ILNode> body, ILExpression expr, int pos)
	{
		for (int num = expr.Arguments.Count - 1; num >= 0; num--)
		{
			if (InlineExpressionTreeParameterDeclarations(block, body, expr.Arguments[num], pos))
			{
				return true;
			}
		}
		if (!expr.Match<IMethod>(ILCode.Call, out var operand, out var arg, out var arg2) || !(operand.Name == "Lambda"))
		{
			return false;
		}
		if (arg2.Code != ILCode.InitArray || operand.DeclaringType == null || !(operand.DeclaringType.FullName == "System.Linq.Expressions.Expression"))
		{
			return false;
		}
		int num2 = pos - arg2.Arguments.Count;
		if (num2 < 0)
		{
			return false;
		}
		ILExpression[] array = new ILExpression[arg2.Arguments.Count + 1];
		for (int i = 0; i < arg2.Arguments.Count; i++)
		{
			array[i] = body[num2 + i] as ILExpression;
			if (!MatchParameterVariableAssignment(array[i]))
			{
				return false;
			}
			ILVariable expectedVar = (ILVariable)array[i].Operand;
			if (!arg2.Arguments[i].MatchLdloc(expectedVar))
			{
				return false;
			}
		}
		array[array.Length - 1] = arg;
		expr.Arguments[0] = new ILExpression(ILCode.ExpressionTreeParameterDeclarations, null, array);
		body.RemoveRange(num2, arg2.Arguments.Count);
		return true;
	}

	private bool MatchParameterVariableAssignment(ILExpression expr)
	{
		if (expr == null)
		{
			return false;
		}
		if (!((ILNode)expr).Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
		{
			return false;
		}
		if (operand.GeneratedByDecompiler || operand.IsParameter || operand.IsPinned)
		{
			return false;
		}
		if (operand.Type == null || operand.Type.FullName != "System.Linq.Expressions.ParameterExpression")
		{
			return false;
		}
		if (!arg.Match<IMethod>(ILCode.Call, out var operand2, out var arg2, out var arg3))
		{
			return false;
		}
		if (!(operand2.Name == "Parameter") || operand2.DeclaringType == null || !(operand2.DeclaringType.FullName == "System.Linq.Expressions.Expression"))
		{
			return false;
		}
		if (!((ILNode)arg2).Match(ILCode.Call, out IMethod operand3, out ILExpression arg4))
		{
			return false;
		}
		if (!(operand3.Name == "GetTypeFromHandle") || operand3.DeclaringType == null || !(operand3.DeclaringType.FullName == "System.Type"))
		{
			return false;
		}
		if (arg4.Code == ILCode.Ldtoken)
		{
			return arg3.Code == ILCode.Ldstr;
		}
		return false;
	}
}
