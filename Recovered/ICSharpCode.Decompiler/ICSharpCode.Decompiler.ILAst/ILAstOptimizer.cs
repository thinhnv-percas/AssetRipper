using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.Utils;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
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
					return new ILPattern(ILCode.LogicNot, a);
				}
			}

			private sealed class ILPattern : Pattern
			{
				private readonly ILCode code;

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
					TypeReference inferredType = null;
					switch (code)
					{
					case ILCode.Ceq:
					case ILCode.Cne:
						inferredType = pm.typeSystem.Boolean;
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
					MethodReference methodReference = (MethodReference)e.Operand;
					if (methodReference.Name == method && TypeAnalysis.IsNullableType(methodReference.DeclaringType))
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
						if (type != 0)
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
					{
						MethodReference methodReference = e.Operand as MethodReference;
						if (methodReference == null || methodReference.HasThis || !methodReference.HasParameters || e.Arguments.Count > 2 || !IsCustomOperator(methodReference.Name))
						{
							return false;
						}
						break;
					}
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
						if (s == "op_GreaterThan" || s == "op_GreaterThanOrEqual" || s == "op_LessThan" || s == "op_LessThanOrEqual")
						{
							return true;
						}
						return false;
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
					ILExpression @operator = pm.Operator;
					@operator.Arguments.Clear();
					if (pm.SimpleLeftOperand)
					{
						@operator.Arguments.Add(pm.SimpleOperand);
					}
					@operator.Arguments.Add(VariableA.BuildNew(pm));
					if (pm.B != null)
					{
						@operator.Arguments.Add(VariableB.BuildNew(pm));
					}
					else if (pm.SimpleOperand != null && !pm.SimpleLeftOperand)
					{
						@operator.Arguments.Add(pm.SimpleOperand);
					}
					return @operator;
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

				private static readonly ILExpression[] EmptyArguments = new ILExpression[0];

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
					ILVariable iLVariable = e.Operand as ILVariable;
					if (iLVariable != null)
					{
						if (!b)
						{
							return Capture(ref pm.A, iLVariable);
						}
						return Capture(ref pm.B, iLVariable);
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
					ILVariable iLVariable = b ? pm.B : pm.A;
					ILExpression iLExpression = new ILExpression(ILCode.Ldloc, iLVariable, EmptyArguments);
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
					if (e.Code == ILCode.Ldc_I4 && TypeAnalysis.IsBoolean(e.InferredType))
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

			private readonly TypeSystem typeSystem;

			private static readonly Pattern VariableRefA = new VariablePattern(ILCode.Ldloca, b: false);

			private static readonly Pattern VariableRefB = new VariablePattern(ILCode.Ldloca, b: true);

			private static readonly Pattern VariableA = new VariablePattern(ILCode.Ldloc, b: false);

			private static readonly Pattern VariableB = new VariablePattern(ILCode.Ldloc, b: true);

			private static readonly Pattern VariableAHasValue = new MethodPattern(ILCode.CallGetter, "get_HasValue", VariableRefA);

			private static readonly Pattern VariableAGetValueOrDefault = new MethodPattern(ILCode.Call, "GetValueOrDefault", VariableRefA);

			private static readonly Pattern VariableBHasValue = new MethodPattern(ILCode.CallGetter, "get_HasValue", VariableRefB);

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

			private ILVariable A;

			private ILVariable B;

			private ILExpression Operator;

			private ILExpression SimpleOperand;

			private bool SimpleLeftOperand;

			public PatternMatcher(TypeSystem typeSystem)
			{
				this.typeSystem = typeSystem;
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
								iLExpression.Arguments[0] = iLExpression.Arguments[0].Arguments[0];
								iLExpression.Arguments[1] = iLExpression.Arguments[1].Arguments[0];
							}
						}
						else if (iLExpression.Code != ILCode.Ceq && iLExpression.Code != ILCode.Cne)
						{
							expr.Code = ILCode.NullableOf;
							TypeReference typeReference3 = expr.InferredType = (expr.ExpectedType = null);
						}
						return true;
					}
				}
				return false;
			}

			private static void SetResult(ILExpression expr, ILExpression n)
			{
				IEnumerable<ILExpression> source = expr.GetSelfAndChildrenRecursive<ILExpression>().Except(n.GetSelfAndChildrenRecursive<ILExpression>());
				n.ILRanges.AddRange(source.SelectMany((ILExpression el) => el.ILRanges));
				expr.Code = ILCode.Wrap;
				expr.Arguments.Clear();
				expr.Arguments.Add(n);
				expr.ILRanges.Clear();
				expr.InferredType = n.InferredType;
			}
		}

		private int nextLabelIndex;

		private DecompilerContext context;

		private TypeSystem typeSystem;

		private ILBlock method;

		private bool SimplifyLiftedOperators(List<ILNode> body, ILExpression expr, int pos)
		{
			if (!new PatternMatcher(typeSystem).SimplifyLiftedOperators(expr))
			{
				return false;
			}
			ILInlining iLInlining = new ILInlining(method);
			while (--pos >= 0 && iLInlining.InlineIfPossible(body, ref pos))
			{
			}
			return true;
		}

		private bool TransformArrayInitializers(List<ILNode> body, ILExpression expr, int pos)
		{
			int operand3;
			if (expr.Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && arg.Match(ILCode.Newarr, out TypeReference operand2, out ILExpression arg2) && arg2.Match(ILCode.Ldc_I4, out operand3) && operand3 > 0)
			{
				if (ForwardScanInitializeArrayRuntimeHelper(body, pos + 1, operand, operand2, operand3, out ILExpression[] values, out int foundPos))
				{
					ArrayType arrayType = new ArrayType(operand2, 1);
					arrayType.Dimensions[0] = new ArrayDimension(0, operand3);
					body[pos] = new ILExpression(ILCode.Stloc, operand, new ILExpression(ILCode.InitArray, arrayType, values));
					body.RemoveAt(foundPos);
				}
				List<ILExpression> list = new List<ILExpression>();
				int num = 0;
				for (int i = pos + 1; i < body.Count; i++)
				{
					ILExpression iLExpression = body[i] as ILExpression;
					ILVariable operand4;
					int operand5;
					if (iLExpression == null || !iLExpression.Code.IsStoreToArray() || !iLExpression.Arguments[0].Match(ILCode.Ldloc, out operand4) || operand != operand4 || !iLExpression.Arguments[1].Match(ILCode.Ldc_I4, out operand5) || operand5 < list.Count || operand5 > list.Count + 300 || iLExpression.Arguments[2].ContainsReferenceTo(operand4))
					{
						break;
					}
					while (list.Count < operand5)
					{
						list.Add(new ILExpression(ILCode.DefaultValue, operand2));
					}
					list.Add(iLExpression.Arguments[2]);
					num++;
				}
				if (list.Count == operand3)
				{
					ArrayType arrayType2 = new ArrayType(operand2, 1);
					arrayType2.Dimensions[0] = new ArrayDimension(0, operand3);
					expr.Arguments[0] = new ILExpression(ILCode.InitArray, arrayType2, list);
					body.RemoveRange(pos + 1, num);
					new ILInlining(method).InlineIfPossible(body, ref pos);
					return true;
				}
			}
			return false;
		}

		private bool TransformMultidimensionalArrayInitializers(List<ILNode> body, ILExpression expr, int pos)
		{
			List<ILExpression> args;
			ArrayType arrayType;
			if (expr.Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && arg.Match(ILCode.Newobj, out MethodReference operand2, out args) && (arrayType = (operand2.DeclaringType as ArrayType)) != null && arrayType.Rank == args.Count)
			{
				arrayType = new ArrayType(arrayType.ElementType, arrayType.Rank);
				int[] array = new int[arrayType.Rank];
				for (int i = 0; i < arrayType.Rank; i++)
				{
					if (!args[i].Match(ILCode.Ldc_I4, out array[i]))
					{
						return false;
					}
					if (array[i] <= 0)
					{
						return false;
					}
					arrayType.Dimensions[i] = new ArrayDimension(0, array[i]);
				}
				int arrayLength = array.Aggregate(1, (int t, int l) => t * l);
				if (ForwardScanInitializeArrayRuntimeHelper(body, pos + 1, operand, arrayType, arrayLength, out ILExpression[] values, out int foundPos))
				{
					body[pos] = new ILExpression(ILCode.Stloc, operand, new ILExpression(ILCode.InitArray, arrayType, values));
					body.RemoveAt(foundPos);
					return true;
				}
			}
			return false;
		}

		private bool ForwardScanInitializeArrayRuntimeHelper(List<ILNode> body, int pos, ILVariable array, TypeReference arrayType, int arrayLength, out ILExpression[] values, out int foundPos)
		{
			ILExpression arg2;
			ILVariable operand2;
			ILExpression arg;
			if (body.ElementAtOrDefault(pos).Match(ILCode.Call, out MethodReference operand, out arg, out arg2) && operand.DeclaringType.FullName == "System.Runtime.CompilerServices.RuntimeHelpers" && operand.Name == "InitializeArray" && arg.Match(ILCode.Ldloc, out operand2) && array == operand2 && arg2.Match(ILCode.Ldtoken, out FieldReference operand3))
			{
				FieldDefinition fieldDefinition = operand3.ResolveWithinSameModule();
				if (fieldDefinition != null && fieldDefinition.InitialValue != null)
				{
					ILExpression[] array2 = new ILExpression[arrayLength];
					if (DecodeArrayInitializer(arrayType.GetElementType(), fieldDefinition.InitialValue, array2))
					{
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

		private static bool DecodeArrayInitializer(TypeReference elementTypeRef, byte[] initialValue, ILExpression[] output)
		{
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
				TypeDefinition typeDefinition = elementTypeRef.ResolveWithinSameModule();
				if (typeDefinition != null && typeDefinition.IsEnum)
				{
					return DecodeArrayInitializer(typeDefinition.GetEnumUnderlyingType(), initialValue, output);
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

		private bool TransformObjectInitializers(List<ILNode> body, ILExpression expr, int pos)
		{
			if (!context.Settings.ObjectOrCollectionInitializers)
			{
				return false;
			}
			MethodReference operand2;
			TypeReference operand3;
			bool flag;
			List<ILExpression> args;
			if (expr.Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
			{
				if (arg.Match(ILCode.Newobj, out operand2, out args))
				{
					operand3 = operand2.DeclaringType;
					flag = false;
				}
				else
				{
					if (!arg.Match(ILCode.DefaultValue, out operand3))
					{
						return false;
					}
					flag = true;
				}
			}
			else
			{
				if (!expr.Match(ILCode.Call, out operand2, out args))
				{
					return false;
				}
				if (args.Count <= 0 || !args[0].Match(ILCode.Ldloca, out operand))
				{
					return false;
				}
				flag = true;
				operand3 = operand2.DeclaringType;
				args = new List<ILExpression>(args);
				args.RemoveAt(0);
				arg = new ILExpression(ILCode.Newobj, operand2, args);
			}
			if (operand3.IsValueType != flag)
			{
				return false;
			}
			int pos2 = pos;
			if (DelegateConstruction.IsPotentialClosure(context, operand3.ResolveWithinSameModule()))
			{
				return false;
			}
			ILExpression iLExpression = ParseObjectInitializer(body, ref pos, operand, arg, IsCollectionType(operand3), flag);
			if (iLExpression.Arguments.Count == 1)
			{
				return false;
			}
			int num = pos - pos2 - 1;
			if (pos >= body.Count)
			{
				return false;
			}
			ILInlining iLInlining = new ILInlining(method);
			if (flag)
			{
				if (iLInlining.numLdloc.GetOrDefault(operand) != 1)
				{
					return false;
				}
				if (iLInlining.numLdloca.GetOrDefault(operand) != num + ((expr.Code == ILCode.Call) ? 1 : 0))
				{
					return false;
				}
				if (iLInlining.numStloc.GetOrDefault(operand) != ((expr.Code != ILCode.Call) ? 1 : 0))
				{
					return false;
				}
			}
			else
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
			if (!iLInlining.CanInlineInto(expr2, operand, iLExpression))
			{
				return false;
			}
			if (expr.Code == ILCode.Stloc)
			{
				expr.Arguments[0] = iLExpression;
			}
			else
			{
				expr.Code = ILCode.Stloc;
				expr.Operand = operand;
				expr.Arguments.Clear();
				expr.Arguments.Add(iLExpression);
			}
			body.RemoveRange(pos2 + 1, pos - pos2 - 1);
			ChangeFirstArgumentToInitializedObject(iLExpression);
			iLInlining = new ILInlining(method);
			iLInlining.InlineIfPossible(body, ref pos2);
			return true;
		}

		private static bool IsCollectionType(TypeReference tr)
		{
			if (tr == null)
			{
				return false;
			}
			for (TypeDefinition typeDefinition = tr.Resolve(); typeDefinition != null; typeDefinition = ((typeDefinition.BaseType != null) ? typeDefinition.BaseType.Resolve() : null))
			{
				if (typeDefinition.Interfaces.Any((TypeReference intf) => intf.Name == "IEnumerable" && intf.Namespace == "System.Collections"))
				{
					return true;
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
			MethodReference operand;
			if ((expr.Match(ILCode.Callvirt, out operand, out List<ILExpression> args) || expr.Match(ILCode.Call, out operand, out args)) && operand.Name == "Add" && operand.HasThis)
			{
				return args.Count >= 2;
			}
			return false;
		}

		private ILExpression ParseObjectInitializer(List<ILNode> body, ref int pos, ILVariable v, ILExpression newObjExpr, bool isCollection, bool isValueType)
		{
			ILExpression iLExpression = new ILExpression(isCollection ? ILCode.InitCollection : ILCode.InitObject, null, newObjExpr);
			List<ILExpression> list = new List<ILExpression>();
			list.Add(iLExpression);
			while (++pos < body.Count)
			{
				ILExpression iLExpression2 = body[pos] as ILExpression;
				if (IsSetterInObjectInitializer(iLExpression2))
				{
					if (!AdjustInitializerStack(list, iLExpression2.Arguments[0], v, isCollection: false, isValueType))
					{
						CleanupInitializerStackAfterFailedAdjustment(list);
						break;
					}
					list[list.Count - 1].Arguments.Add(iLExpression2);
					continue;
				}
				if (!IsAddMethodCall(iLExpression2))
				{
					break;
				}
				if (!AdjustInitializerStack(list, iLExpression2.Arguments[0], v, isCollection: true, isValueType))
				{
					CleanupInitializerStackAfterFailedAdjustment(list);
					break;
				}
				list[list.Count - 1].Arguments.Add(iLExpression2);
			}
			return iLExpression;
		}

		private static bool AdjustInitializerStack(List<ILExpression> initializerStack, ILExpression argument, ILVariable v, bool isCollection, bool isValueType)
		{
			List<ILExpression> list = new List<ILExpression>();
			while (argument.Code == ILCode.CallvirtGetter || argument.Code == ILCode.CallGetter || argument.Code == ILCode.Ldfld)
			{
				list.Add(argument);
				if (argument.Arguments.Count != 1)
				{
					return false;
				}
				argument = argument.Arguments[0];
			}
			if (isValueType)
			{
				if (!argument.Match(ILCode.Ldloca, out ILVariable operand) || operand != v)
				{
					return false;
				}
			}
			else if (!argument.MatchLdloc(v))
			{
				return false;
			}
			int i;
			for (i = 1; i <= Math.Min(list.Count, initializerStack.Count - 1); i++)
			{
				ILExpression iLExpression = initializerStack[i].Arguments[0];
				ILExpression iLExpression2 = list[list.Count - i];
				if (iLExpression.Operand != iLExpression2.Operand)
				{
					break;
				}
			}
			initializerStack.RemoveRange(i, initializerStack.Count - i);
			for (; i <= list.Count; i++)
			{
				ILExpression iLExpression3 = list[list.Count - i];
				MemberReference memberReference = (MemberReference)iLExpression3.Operand;
				TypeReference tr = (!(memberReference is FieldReference)) ? TypeAnalysis.SubstituteTypeArgs(((MethodReference)memberReference).ReturnType, memberReference) : TypeAnalysis.GetFieldType((FieldReference)memberReference);
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

		private static void CleanupInitializerStackAfterFailedAdjustment(List<ILExpression> initializerStack)
		{
			while (initializerStack.Count > 1 && initializerStack[initializerStack.Count - 1].Arguments.Count == 1)
			{
				ILExpression iLExpression = initializerStack[initializerStack.Count - 2];
				iLExpression.Arguments.RemoveAt(iLExpression.Arguments.Count - 1);
				initializerStack.RemoveAt(initializerStack.Count - 1);
			}
		}

		private static void ChangeFirstArgumentToInitializedObject(ILExpression initializer)
		{
			for (int i = 1; i < initializer.Arguments.Count; i++)
			{
				ILExpression iLExpression = initializer.Arguments[i];
				if (iLExpression.Code == ILCode.InitCollection || iLExpression.Code == ILCode.InitObject)
				{
					iLExpression.Arguments[0].Arguments[0] = new ILExpression(ILCode.InitializedObject, null);
					ChangeFirstArgumentToInitializedObject(iLExpression);
				}
				else
				{
					iLExpression.Arguments[0] = new ILExpression(ILCode.InitializedObject, null);
				}
			}
		}

		public void Optimize(DecompilerContext context, ILBlock method, ILAstOptimizationStep abortBeforeStep = ILAstOptimizationStep.None)
		{
			this.context = context;
			typeSystem = context.CurrentMethod.Module.TypeSystem;
			this.method = method;
			if (abortBeforeStep == ILAstOptimizationStep.RemoveRedundantCode)
			{
				return;
			}
			RemoveRedundantCode(method);
			if (abortBeforeStep == ILAstOptimizationStep.ReduceBranchInstructionSet)
			{
				return;
			}
			foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				ReduceBranchInstructionSet(item);
			}
			if (abortBeforeStep == ILAstOptimizationStep.InlineVariables)
			{
				return;
			}
			ILInlining iLInlining = new ILInlining(method);
			iLInlining.InlineAllVariables();
			if (abortBeforeStep == ILAstOptimizationStep.CopyPropagation)
			{
				return;
			}
			iLInlining.CopyPropagation();
			if (abortBeforeStep == ILAstOptimizationStep.YieldReturn)
			{
				return;
			}
			YieldReturnDecompiler.Run(context, method);
			AsyncDecompiler.RunStep1(context, method);
			if (abortBeforeStep == ILAstOptimizationStep.AsyncAwait)
			{
				return;
			}
			AsyncDecompiler.RunStep2(context, method);
			if (abortBeforeStep == ILAstOptimizationStep.PropertyAccessInstructions)
			{
				return;
			}
			IntroducePropertyAccessInstructions(method);
			if (abortBeforeStep == ILAstOptimizationStep.SplitToMovableBlocks)
			{
				return;
			}
			foreach (ILBlock item2 in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				SplitToBasicBlocks(item2);
			}
			if (abortBeforeStep == ILAstOptimizationStep.TypeInference)
			{
				return;
			}
			TypeAnalysis.Run(context, method);
			if (abortBeforeStep == ILAstOptimizationStep.HandlePointerArithmetic)
			{
				return;
			}
			HandlePointerArithmetic(method);
			foreach (ILBlock item3 in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				bool flag;
				do
				{
					flag = false;
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyShortCircuit)
					{
						return;
					}
					flag |= item3.RunOptimization(new SimpleControlFlow(context, method).SimplifyShortCircuit);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyTernaryOperator)
					{
						return;
					}
					flag |= item3.RunOptimization(new SimpleControlFlow(context, method).SimplifyTernaryOperator);
					if (abortBeforeStep == ILAstOptimizationStep.SimplifyNullCoalescing)
					{
						return;
					}
					flag |= item3.RunOptimization(new SimpleControlFlow(context, method).SimplifyNullCoalescing);
					if (abortBeforeStep == ILAstOptimizationStep.JoinBasicBlocks)
					{
						return;
					}
					flag |= item3.RunOptimization(new SimpleControlFlow(context, method).JoinBasicBlocks);
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
					flag |= item3.RunOptimization(new SimpleControlFlow(context, method).SimplifyCustomShortCircuit);
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
					flag |= new ILInlining(method).InlineAllInBlock(item3);
					new ILInlining(method).CopyPropagation();
				}
				while (flag);
			}
			if (abortBeforeStep == ILAstOptimizationStep.FindLoops)
			{
				return;
			}
			foreach (ILBlock item4 in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				new LoopsAndConditions(context).FindLoops(item4);
			}
			if (abortBeforeStep == ILAstOptimizationStep.FindConditions)
			{
				return;
			}
			foreach (ILBlock item5 in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				new LoopsAndConditions(context).FindConditions(item5);
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
			RemoveRedundantCode(method);
			if (abortBeforeStep == ILAstOptimizationStep.GotoRemoval)
			{
				return;
			}
			new GotoRemoval().RemoveGotos(method);
			if (abortBeforeStep == ILAstOptimizationStep.DuplicateReturns)
			{
				return;
			}
			DuplicateReturnStatements(method);
			if (abortBeforeStep == ILAstOptimizationStep.GotoRemoval2)
			{
				return;
			}
			new GotoRemoval().RemoveGotos(method);
			if (abortBeforeStep == ILAstOptimizationStep.ReduceIfNesting)
			{
				return;
			}
			ReduceIfNesting(method);
			if (abortBeforeStep == ILAstOptimizationStep.InlineVariables3)
			{
				return;
			}
			new ILInlining(method).InlineAllVariables();
			if (abortBeforeStep == ILAstOptimizationStep.CachedDelegateInitialization)
			{
				return;
			}
			if (context.Settings.AnonymousMethods)
			{
				foreach (ILBlock item6 in method.GetSelfAndChildrenRecursive<ILBlock>())
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
						IntroduceFixedStatements(item7.Body, num);
					}
				}
			}
			if (abortBeforeStep == ILAstOptimizationStep.RecombineVariables)
			{
				return;
			}
			RecombineVariables(method);
			if (abortBeforeStep != ILAstOptimizationStep.TypeInference2)
			{
				TypeAnalysis.Reset(method);
				TypeAnalysis.Run(context, method);
				if (abortBeforeStep != ILAstOptimizationStep.RemoveRedundantCode3)
				{
					GotoRemoval.RemoveRedundantCode(method);
				}
			}
		}

		internal static void RemoveRedundantCode(ILBlock method)
		{
			Dictionary<ILLabel, int> dictionary = new Dictionary<ILLabel, int>();
			foreach (ILLabel item in method.GetSelfAndChildrenRecursive((ILExpression e) => e.IsBranch()).SelectMany((ILExpression e) => e.GetBranchTargets()))
			{
				dictionary[item] = dictionary.GetOrDefault(item) + 1;
			}
			foreach (ILBlock item2 in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				List<ILNode> body = item2.Body;
				List<ILNode> list = new List<ILNode>(body.Count);
				for (int i = 0; i < body.Count; i++)
				{
					ILLabel operand;
					if (body[i].Match(ILCode.Br, out operand) && i + 1 < body.Count && body[i + 1] == operand)
					{
						if (dictionary[operand] == 1)
						{
							i++;
						}
					}
					else if (!body[i].Match(ILCode.Nop))
					{
						if (body[i].Match(ILCode.Pop, out ILExpression arg2))
						{
							if (!arg2.Match(ILCode.Ldloc, out ILVariable operand2))
							{
								throw new Exception("Pop should have just ldloc at this stage");
							}
							ILVariable operand3;
							if (i - 1 >= 0 && body[i - 1].Match(ILCode.Stloc, out operand3, out ILExpression arg3) && operand3 == operand2)
							{
								arg3.ILRanges.AddRange(((ILExpression)body[i]).ILRanges);
							}
						}
						else
						{
							ILLabel iLLabel = body[i] as ILLabel;
							if (iLLabel != null)
							{
								if (dictionary.GetOrDefault(iLLabel) > 0)
								{
									list.Add(iLLabel);
								}
							}
							else
							{
								list.Add(body[i]);
							}
						}
					}
				}
				item2.Body = list;
			}
			foreach (ILExpression item3 in method.GetSelfAndChildrenRecursive((ILExpression e) => e.Code == ILCode.Leave))
			{
				if (item3.Arguments.Any((ILExpression arg) => !arg.Match(ILCode.Ldloc)))
				{
					throw new Exception("Leave should have just ldloc at this stage");
				}
				item3.Arguments.Clear();
			}
			foreach (ILExpression item4 in method.GetSelfAndChildrenRecursive<ILExpression>())
			{
				for (int j = 0; j < item4.Arguments.Count; j++)
				{
					if (item4.Arguments[j].Match(ILCode.Dup, out ILExpression arg4))
					{
						arg4.ILRanges.AddRange(item4.Arguments[j].ILRanges);
						item4.Arguments[j] = arg4;
					}
				}
			}
		}

		private void ReduceBranchInstructionSet(ILBlock block)
		{
			for (int i = 0; i < block.Body.Count; i++)
			{
				ILExpression iLExpression = block.Body[i] as ILExpression;
				if (iLExpression != null && iLExpression.Prefixes == null)
				{
					ILCode code;
					switch (iLExpression.Code)
					{
					case ILCode.Brtrue:
					case ILCode.Switch:
						iLExpression.Arguments.Single().ILRanges.AddRange(iLExpression.ILRanges);
						iLExpression.ILRanges.Clear();
						continue;
					case ILCode.__Brfalse:
						code = ILCode.LogicNot;
						break;
					case ILCode.__Beq:
						code = ILCode.Ceq;
						break;
					case ILCode.__Bne_Un:
						code = ILCode.Cne;
						break;
					case ILCode.__Bgt:
						code = ILCode.Cgt;
						break;
					case ILCode.__Bgt_Un:
						code = ILCode.Cgt_Un;
						break;
					case ILCode.__Ble:
						code = ILCode.Cle;
						break;
					case ILCode.__Ble_Un:
						code = ILCode.Cle_Un;
						break;
					case ILCode.__Blt:
						code = ILCode.Clt;
						break;
					case ILCode.__Blt_Un:
						code = ILCode.Clt_Un;
						break;
					case ILCode.__Bge:
						code = ILCode.Cge;
						break;
					case ILCode.__Bge_Un:
						code = ILCode.Cge_Un;
						break;
					default:
						continue;
					}
					ILExpression iLExpression2 = new ILExpression(code, null, iLExpression.Arguments);
					block.Body[i] = new ILExpression(ILCode.Brtrue, iLExpression.Operand, iLExpression2);
					iLExpression2.ILRanges = iLExpression.ILRanges;
				}
			}
		}

		private void IntroducePropertyAccessInstructions(ILNode node)
		{
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null)
			{
				for (int i = 0; i < iLExpression.Arguments.Count; i++)
				{
					ILExpression iLExpression2 = iLExpression.Arguments[i];
					IntroducePropertyAccessInstructions(iLExpression2);
					IntroducePropertyAccessInstructions(iLExpression2, iLExpression, i);
				}
			}
			else
			{
				foreach (ILNode child in node.GetChildren())
				{
					IntroducePropertyAccessInstructions(child);
					ILExpression iLExpression3 = child as ILExpression;
					if (iLExpression3 != null)
					{
						IntroducePropertyAccessInstructions(iLExpression3, null, -1);
					}
				}
			}
		}

		private void IntroducePropertyAccessInstructions(ILExpression expr, ILExpression parentExpr, int posInParent)
		{
			ILVariable operand;
			if (expr.Code == ILCode.Call || expr.Code == ILCode.Callvirt)
			{
				MethodReference methodReference = (MethodReference)expr.Operand;
				if (methodReference.DeclaringType is ArrayType)
				{
					string name = methodReference.Name;
					if (!(name == "Get"))
					{
						if (!(name == "Set"))
						{
							if (name == "Address")
							{
								ByReferenceType byReferenceType = methodReference.ReturnType as ByReferenceType;
								if (byReferenceType != null)
								{
									MethodReference methodReference2 = new MethodReference("Get", byReferenceType.ElementType, methodReference.DeclaringType);
									foreach (ParameterDefinition parameter in methodReference.Parameters)
									{
										methodReference2.Parameters.Add(parameter);
									}
									methodReference2.HasThis = methodReference.HasThis;
									expr.Operand = methodReference2;
								}
								expr.Code = ILCode.CallGetter;
								if (parentExpr != null)
								{
									parentExpr.Arguments[posInParent] = new ILExpression(ILCode.AddressOf, null, expr);
								}
							}
						}
						else
						{
							expr.Code = ILCode.CallSetter;
						}
					}
					else
					{
						expr.Code = ILCode.CallGetter;
					}
					return;
				}
				MethodDefinition methodDefinition = methodReference.Resolve();
				if (methodDefinition != null)
				{
					if (methodDefinition.IsGetter)
					{
						expr.Code = ((expr.Code == ILCode.Call) ? ILCode.CallGetter : ILCode.CallvirtGetter);
					}
					else if (methodDefinition.IsSetter)
					{
						expr.Code = ((expr.Code == ILCode.Call) ? ILCode.CallSetter : ILCode.CallvirtSetter);
					}
				}
			}
			else if (expr.Code == ILCode.Newobj && expr.Arguments.Count == 2 && expr.Arguments[0].Match(ILCode.Ldloc, out operand) && expr.Arguments[1].Code == ILCode.Ldvirtftn && expr.Arguments[1].Arguments.Count == 1 && expr.Arguments[1].Arguments[0].MatchLdloc(operand))
			{
				expr.Arguments[1].Arguments.Clear();
			}
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
							Name = "Block_" + nextLabelIndex++.ToString()
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
			Dictionary<ILLabel, ILNode> dictionary = new Dictionary<ILLabel, ILNode>();
			foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				for (int i = 0; i < item.Body.Count - 1; i++)
				{
					ILLabel iLLabel = item.Body[i] as ILLabel;
					if (iLLabel != null)
					{
						dictionary[iLLabel] = item.Body[i + 1];
					}
				}
			}
			foreach (ILBlock item2 in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				for (int j = 0; j < item2.Body.Count; j++)
				{
					if (item2.Body[j].Match(ILCode.Br, out ILLabel operand) || item2.Body[j].Match(ILCode.Leave, out operand))
					{
						while (dictionary.ContainsKey(operand) && dictionary[operand] is ILLabel)
						{
							operand = (ILLabel)dictionary[operand];
						}
						if (dictionary.TryGetValue(operand, out ILNode value))
						{
							if (value.Match(ILCode.Ret, out List<ILExpression> args))
							{
								ILVariable operand2;
								object operand3;
								if (args.Count == 0)
								{
									item2.Body[j] = new ILExpression(ILCode.Ret, null);
								}
								else if (args.Single().Match(ILCode.Ldloc, out operand2))
								{
									item2.Body[j] = new ILExpression(ILCode.Ret, null, new ILExpression(ILCode.Ldloc, operand2));
								}
								else if (args.Single().Match(ILCode.Ldc_I4, out operand3))
								{
									item2.Body[j] = new ILExpression(ILCode.Ret, null, new ILExpression(ILCode.Ldc_I4, operand3));
								}
							}
						}
						else if (method.Body.Count > 0 && method.Body.Last() == operand)
						{
							item2.Body[j] = new ILExpression(ILCode.Ret, null);
						}
					}
				}
			}
		}

		private void FlattenBasicBlocks(ILNode node)
		{
			ILBlock iLBlock = node as ILBlock;
			if (iLBlock != null)
			{
				List<ILNode> list = new List<ILNode>();
				foreach (ILNode child in iLBlock.GetChildren())
				{
					FlattenBasicBlocks(child);
					ILBasicBlock iLBasicBlock = child as ILBasicBlock;
					if (iLBasicBlock != null)
					{
						if (!(iLBasicBlock.Body.FirstOrDefault() is ILLabel))
						{
							throw new Exception("Basic block has to start with a label. \n" + iLBasicBlock.ToString());
						}
						if (iLBasicBlock.Body.LastOrDefault() is ILExpression && !iLBasicBlock.Body.LastOrDefault().IsUnconditionalControlFlow())
						{
							throw new Exception("Basci block has to end with unconditional control flow. \n" + iLBasicBlock.ToString());
						}
						list.AddRange(iLBasicBlock.GetChildren());
					}
					else
					{
						list.Add(child);
					}
				}
				iLBlock.EntryGoto = null;
				iLBlock.Body = list;
			}
			else if (!(node is ILExpression) && node != null)
			{
				foreach (ILNode child2 in node.GetChildren())
				{
					FlattenBasicBlocks(child2);
				}
			}
		}

		private void RemoveEndFinally(ILBlock method)
		{
			foreach (ILTryCatchBlock item in method.GetSelfAndChildrenRecursive((ILTryCatchBlock tc) => tc.FinallyBlock != null).Reverse())
			{
				ILLabel iLLabel = new ILLabel
				{
					Name = "EndFinally_" + nextLabelIndex++
				};
				item.FinallyBlock.Body.Add(iLLabel);
				foreach (ILBlock item2 in item.FinallyBlock.GetSelfAndChildrenRecursive<ILBlock>())
				{
					for (int i = 0; i < item2.Body.Count; i++)
					{
						if (item2.Body[i].Match(ILCode.Endfinally))
						{
							item2.Body[i] = new ILExpression(ILCode.Br, iLLabel).WithILRanges(((ILExpression)item2.Body[i]).ILRanges);
						}
					}
				}
			}
		}

		private void ReduceIfNesting(ILNode node)
		{
			ILBlock iLBlock = node as ILBlock;
			if (iLBlock != null)
			{
				for (int i = 0; i < iLBlock.Body.Count; i++)
				{
					ILCondition iLCondition = iLBlock.Body[i] as ILCondition;
					if (iLCondition != null)
					{
						bool num = iLCondition.TrueBlock.Body.LastOrDefault().IsUnconditionalControlFlow();
						bool flag = iLCondition.FalseBlock.Body.LastOrDefault().IsUnconditionalControlFlow();
						if (num)
						{
							iLBlock.Body.InsertRange(i + 1, iLCondition.FalseBlock.GetChildren());
							iLCondition.FalseBlock = new ILBlock();
						}
						else if (flag)
						{
							iLBlock.Body.InsertRange(i + 1, iLCondition.TrueBlock.GetChildren());
							iLCondition.TrueBlock = new ILBlock();
						}
						if (!iLCondition.TrueBlock.GetChildren().Any() && iLCondition.FalseBlock.GetChildren().Any())
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
					ReduceIfNesting(child);
				}
			}
		}

		private void RecombineVariables(ILBlock method)
		{
			Dictionary<VariableDefinition, ILVariable> dict = new Dictionary<VariableDefinition, ILVariable>();
			ReplaceVariables(method, delegate(ILVariable v)
			{
				if (v.OriginalVariable == null)
				{
					return v;
				}
				if (!dict.TryGetValue(v.OriginalVariable, out ILVariable value))
				{
					dict.Add(v.OriginalVariable, v);
					return v;
				}
				return value;
			});
		}

		private void HandlePointerArithmetic(ILNode method)
		{
			foreach (ILExpression item in method.GetSelfAndChildrenRecursive<ILExpression>())
			{
				List<ILExpression> arguments = item.Arguments;
				switch (item.Code)
				{
				case ILCode.Localloc:
				{
					PointerType pointerType3 = item.InferredType as PointerType;
					if (pointerType3 != null)
					{
						ILExpression adjustmentExpr4 = arguments[0];
						ILExpression pointerExpr4 = item;
						DivideOrMultiplyBySize(ref pointerExpr4, ref adjustmentExpr4, pointerType3.ElementType, divide: true);
						if (pointerExpr4 != item)
						{
							throw new InvalidOperationException();
						}
						arguments[0] = adjustmentExpr4;
					}
					break;
				}
				case ILCode.Add:
				case ILCode.Add_Ovf:
				case ILCode.Add_Ovf_Un:
				{
					ILExpression pointerExpr3 = arguments[0];
					ILExpression adjustmentExpr3 = arguments[1];
					if (item.InferredType is PointerType)
					{
						if (pointerExpr3.ExpectedType is PointerType)
						{
							DivideOrMultiplyBySize(ref pointerExpr3, ref adjustmentExpr3, ((PointerType)item.InferredType).ElementType, divide: true);
						}
						else if (adjustmentExpr3.ExpectedType is PointerType)
						{
							DivideOrMultiplyBySize(ref adjustmentExpr3, ref pointerExpr3, ((PointerType)item.InferredType).ElementType, divide: true);
						}
					}
					arguments[0] = pointerExpr3;
					arguments[1] = adjustmentExpr3;
					break;
				}
				case ILCode.Sub:
				case ILCode.Sub_Ovf:
				case ILCode.Sub_Ovf_Un:
				{
					ILExpression pointerExpr2 = arguments[0];
					ILExpression adjustmentExpr2 = arguments[1];
					if (item.InferredType is PointerType && pointerExpr2.ExpectedType is PointerType && !(adjustmentExpr2.InferredType is PointerType))
					{
						DivideOrMultiplyBySize(ref pointerExpr2, ref adjustmentExpr2, ((PointerType)item.InferredType).ElementType, divide: true);
					}
					arguments[0] = pointerExpr2;
					arguments[1] = adjustmentExpr2;
					break;
				}
				case ILCode.Conv_I8:
				{
					ILExpression adjustmentExpr = arguments[0];
					if (adjustmentExpr.Code == ILCode.Div && adjustmentExpr.InferredType.FullName == "System.IntPtr")
					{
						ILExpression pointerExpr = adjustmentExpr.Arguments[0];
						if (pointerExpr.InferredType.FullName == "System.IntPtr" && (pointerExpr.Code == ILCode.Sub || pointerExpr.Code == ILCode.Sub_Ovf || pointerExpr.Code == ILCode.Sub_Ovf_Un))
						{
							PointerType pointerType = pointerExpr.Arguments[0].InferredType as PointerType;
							PointerType pointerType2 = pointerExpr.Arguments[1].InferredType as PointerType;
							if (pointerType != null && pointerType2 != null)
							{
								if (pointerType.ElementType.FullName == "System.Void" || pointerType.ElementType.FullName != pointerType2.ElementType.FullName)
								{
									pointerType = (pointerType2 = new PointerType(typeSystem.Byte));
									pointerExpr.Arguments[0] = Cast(pointerExpr.Arguments[0], pointerType);
									pointerExpr.Arguments[1] = Cast(pointerExpr.Arguments[1], pointerType2);
								}
								DivideOrMultiplyBySize(ref pointerExpr, ref adjustmentExpr, pointerType.ElementType, divide: false);
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

		private static ILExpression UnwrapIntPtrCast(ILExpression expr)
		{
			if (expr.Code != ILCode.Conv_I && expr.Code != ILCode.Conv_U)
			{
				return expr;
			}
			ILExpression iLExpression = expr.Arguments[0];
			switch (iLExpression.InferredType.MetadataType)
			{
			case MetadataType.SByte:
			case MetadataType.Byte:
			case MetadataType.Int16:
			case MetadataType.UInt16:
			case MetadataType.Int32:
			case MetadataType.UInt32:
			case MetadataType.Int64:
			case MetadataType.UInt64:
				return iLExpression;
			default:
				return expr;
			}
		}

		private static ILExpression Cast(ILExpression expr, TypeReference type)
		{
			return new ILExpression(ILCode.Castclass, type, expr)
			{
				InferredType = type,
				ExpectedType = type
			};
		}

		private void DivideOrMultiplyBySize(ref ILExpression pointerExpr, ref ILExpression adjustmentExpr, TypeReference elementType, bool divide)
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
						goto IL_00a6;
					}
				}
				else
				{
					pointerExpr = Cast(pointerExpr, new PointerType(typeSystem.Byte));
				}
				iLExpression = new ILExpression(ILCode.Ldc_I4, 1);
			}
			else if (informationAmount != 16)
			{
				if (informationAmount != 32)
				{
					if (informationAmount != 64)
					{
						goto IL_00a6;
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
			goto IL_00b8;
			IL_00b8:
			if ((divide && (adjustmentExpr.Code == ILCode.Mul || adjustmentExpr.Code == ILCode.Mul_Ovf || adjustmentExpr.Code == ILCode.Mul_Ovf_Un)) || (!divide && (adjustmentExpr.Code == ILCode.Div || adjustmentExpr.Code == ILCode.Div_Un)))
			{
				ILExpression iLExpression2 = adjustmentExpr.Arguments[1];
				if (iLExpression2.Code == iLExpression.Code && iLExpression.Operand.Equals(iLExpression2.Operand))
				{
					adjustmentExpr = UnwrapIntPtrCast(adjustmentExpr.Arguments[0]);
					return;
				}
			}
			if (adjustmentExpr.Code == iLExpression.Code)
			{
				if (iLExpression.Operand.Equals(adjustmentExpr.Operand))
				{
					adjustmentExpr = new ILExpression(ILCode.Ldc_I4, 1);
					return;
				}
				if (adjustmentExpr.Code == ILCode.Ldc_I4)
				{
					int num = (int)adjustmentExpr.Operand;
					int num2 = (int)iLExpression.Operand;
					if (num % num2 != 0)
					{
						pointerExpr = Cast(pointerExpr, new PointerType(typeSystem.Byte));
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
			return;
			IL_00a6:
			iLExpression = new ILExpression(ILCode.Sizeof, elementType);
			goto IL_00b8;
		}

		public static void ReplaceVariables(ILNode node, Func<ILVariable, ILVariable> variableMapping)
		{
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null)
			{
				ILVariable iLVariable = iLExpression.Operand as ILVariable;
				if (iLVariable != null)
				{
					iLExpression.Operand = variableMapping(iLVariable);
				}
				foreach (ILExpression argument in iLExpression.Arguments)
				{
					ReplaceVariables(argument, variableMapping);
				}
			}
			else
			{
				ILTryCatchBlock.CatchBlock catchBlock = node as ILTryCatchBlock.CatchBlock;
				if (catchBlock != null && catchBlock.ExceptionVariable != null)
				{
					catchBlock.ExceptionVariable = variableMapping(catchBlock.ExceptionVariable);
				}
				foreach (ILNode child in node.GetChildren())
				{
					ReplaceVariables(child, variableMapping);
				}
			}
		}

		private void ReportUnassignedILRanges(ILBlock method)
		{
			int count = ILRange.Invert(method.GetSelfAndChildrenRecursive<ILExpression>().SelectMany((ILExpression e) => e.ILRanges), context.CurrentMethod.Body.CodeSize).ToList().Count;
		}

		private static bool TypeConversionSimplifications(List<ILNode> body, ILExpression expr, int pos)
		{
			bool flag = false;
			flag |= TransformDecimalCtorToConstant(expr);
			flag |= SimplifyLdcI4ConvI8(expr);
			flag |= RemoveConvIFromArrayCreation(expr);
			foreach (ILExpression argument in expr.Arguments)
			{
				flag |= TypeConversionSimplifications(null, argument, -1);
			}
			return flag;
		}

		private static bool TransformDecimalCtorToConstant(ILExpression expr)
		{
			MethodReference operand;
			if (expr.Match(ILCode.Newobj, out operand, out List<ILExpression> args) && operand.DeclaringType.Namespace == "System" && operand.DeclaringType.Name == "Decimal")
			{
				int operand7;
				int operand6;
				int operand5;
				int operand3;
				int operand4;
				if (args.Count == 1)
				{
					if (args[0].Match(ILCode.Ldc_I4, out int operand2))
					{
						expr.Code = ILCode.Ldc_Decimal;
						expr.Operand = new decimal(operand2);
						expr.InferredType = operand.DeclaringType;
						expr.Arguments.Clear();
						return true;
					}
				}
				else if (args.Count == 5 && expr.Arguments[0].Match(ILCode.Ldc_I4, out operand3) && expr.Arguments[1].Match(ILCode.Ldc_I4, out operand4) && expr.Arguments[2].Match(ILCode.Ldc_I4, out operand5) && expr.Arguments[3].Match(ILCode.Ldc_I4, out operand6) && expr.Arguments[4].Match(ILCode.Ldc_I4, out operand7))
				{
					expr.Code = ILCode.Ldc_Decimal;
					expr.Operand = new decimal(operand3, operand4, operand5, operand6 != 0, (byte)operand7);
					expr.InferredType = operand.DeclaringType;
					expr.Arguments.Clear();
					return true;
				}
			}
			return false;
		}

		private static bool SimplifyLdcI4ConvI8(ILExpression expr)
		{
			if (expr.Match(ILCode.Conv_I8, out ILExpression arg) && arg.Match(ILCode.Ldc_I4, out int operand))
			{
				expr.Code = ILCode.Ldc_I8;
				expr.Operand = (long)operand;
				expr.Arguments.Clear();
				return true;
			}
			return false;
		}

		private static bool RemoveConvIFromArrayCreation(ILExpression expr)
		{
			if (expr.Match(ILCode.Newarr, out TypeReference _, out ILExpression arg) && (arg.Match(ILCode.Conv_Ovf_I, out ILExpression arg2) || arg.Match(ILCode.Conv_I, out arg2) || arg.Match(ILCode.Conv_Ovf_I_Un, out arg2) || arg.Match(ILCode.Conv_U, out arg2)))
			{
				expr.Arguments[0] = arg2;
				return true;
			}
			return false;
		}

		private static bool SimplifyLdObjAndStObj(List<ILNode> body, ILExpression expr, int pos)
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
				modified |= SimplifyLdObjAndStObj(null, expr.Arguments[i], -1);
			}
			return modified;
		}

		private static ILExpression SimplifyLdObjAndStObj(ILExpression expr, ref bool modified)
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
			if (expr.Match(ILCode.Stobj, out TypeReference operand, out ILExpression arg, out ILExpression arg2))
			{
				switch (arg.Code)
				{
				case ILCode.Ldelema:
					iLCode = ILCode.Stelem_Any;
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
			else if (expr.Match(ILCode.Ldobj, out operand, out arg))
			{
				switch (arg.Code)
				{
				case ILCode.Ldelema:
					iLCode = ILCode.Ldelem_Any;
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
				arg.ILRanges.AddRange(expr.ILRanges);
				modified = true;
				return arg;
			}
			return expr;
		}

		private void CachedDelegateInitializationWithField(ILBlock block, ref int i)
		{
			ILCondition iLCondition = block.Body[i] as ILCondition;
			if (iLCondition == null || (iLCondition.Condition == null && iLCondition.TrueBlock == null) || iLCondition.FalseBlock == null || iLCondition.TrueBlock.Body.Count != 1 || iLCondition.FalseBlock.Body.Count != 0 || !iLCondition.Condition.Match(ILCode.LogicNot))
			{
				return;
			}
			ILExpression iLExpression = iLCondition.Condition.Arguments.Single();
			if (iLExpression == null || iLExpression.Code != ILCode.Ldsfld)
			{
				return;
			}
			FieldDefinition field = ((FieldReference)iLExpression.Operand).ResolveWithinSameModule();
			if (field == null || !field.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
			{
				return;
			}
			ILExpression iLExpression2 = iLCondition.TrueBlock.Body[0] as ILExpression;
			if (iLExpression2 == null || iLExpression2.Code != ILCode.Stsfld || ((FieldReference)iLExpression2.Operand).ResolveWithinSameModule() != field)
			{
				return;
			}
			ILExpression iLExpression3 = iLExpression2.Arguments[0];
			if (iLExpression3.Code != ILCode.Newobj || iLExpression3.Arguments.Count != 2 || iLExpression3.Arguments[0].Code != ILCode.Ldnull || iLExpression3.Arguments[1].Code != ILCode.Ldftn)
			{
				return;
			}
			MethodDefinition methodDefinition = ((MethodReference)iLExpression3.Arguments[1].Operand).ResolveWithinSameModule();
			if (DelegateConstruction.IsAnonymousMethod(context, methodDefinition))
			{
				ILNode iLNode = block.Body.ElementAtOrDefault(i + 1);
				if (iLNode != null && iLNode.GetSelfAndChildrenRecursive<ILExpression>().Count((ILExpression e) => e.Code == ILCode.Ldsfld && ((FieldReference)e.Operand).ResolveWithinSameModule() == field) == 1)
				{
					foreach (ILExpression item in iLNode.GetSelfAndChildrenRecursive<ILExpression>())
					{
						for (int j = 0; j < item.Arguments.Count; j++)
						{
							if (item.Arguments[j].Code == ILCode.Ldsfld && ((FieldReference)item.Arguments[j].Operand).ResolveWithinSameModule() == field)
							{
								item.Arguments[j] = iLExpression3;
								block.Body.RemoveAt(i);
								i -= new ILInlining(method).InlineInto(block.Body, i, aggressive: false);
								return;
							}
						}
					}
				}
			}
		}

		private void CachedDelegateInitializationWithLocal(ILBlock block, ref int i)
		{
			ILCondition iLCondition = block.Body[i] as ILCondition;
			if (iLCondition == null || (iLCondition.Condition == null && iLCondition.TrueBlock == null) || iLCondition.FalseBlock == null || iLCondition.TrueBlock.Body.Count != 1 || iLCondition.FalseBlock.Body.Count != 0 || !iLCondition.Condition.Match(ILCode.LogicNot))
			{
				return;
			}
			ILExpression iLExpression = iLCondition.Condition.Arguments.Single();
			if (iLExpression == null || iLExpression.Code != ILCode.Ldloc)
			{
				return;
			}
			ILVariable v = (ILVariable)iLExpression.Operand;
			ILExpression iLExpression2 = iLCondition.TrueBlock.Body[0] as ILExpression;
			if (iLExpression2 == null || iLExpression2.Code != ILCode.Stloc || (ILVariable)iLExpression2.Operand != v)
			{
				return;
			}
			ILExpression iLExpression3 = iLExpression2.Arguments[0];
			if (iLExpression3.Code != ILCode.Newobj || iLExpression3.Arguments.Count != 2 || iLExpression3.Arguments[0].Code != ILCode.Ldloc || iLExpression3.Arguments[1].Code != ILCode.Ldftn)
			{
				return;
			}
			MethodDefinition methodDefinition = ((MethodReference)iLExpression3.Arguments[1].Operand).ResolveWithinSameModule();
			if (!DelegateConstruction.IsAnonymousMethod(context, methodDefinition))
			{
				return;
			}
			ILNode iLNode = block.Body.ElementAtOrDefault(i + 1);
			if (iLNode != null && iLNode.GetSelfAndChildrenRecursive<ILExpression>().Count((ILExpression e) => e.Code == ILCode.Ldloc && (ILVariable)e.Operand == v) == 1)
			{
				ILInlining iLInlining = new ILInlining(method);
				if (iLInlining.numLdloc.GetOrDefault(v) == 2 && iLInlining.numStloc.GetOrDefault(v) == 2 && iLInlining.numLdloca.GetOrDefault(v) == 0)
				{
					foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
					{
						for (int j = 0; j < item.Body.Count; j++)
						{
							ILExpression arg;
							if (item.Body[j].Match(ILCode.Stloc, out ILVariable operand, out arg) && operand == v && arg.Match(ILCode.Ldnull))
							{
								item.Body.RemoveAt(j);
								if (item == block && j < i)
								{
									i--;
								}
								break;
							}
						}
					}
					block.Body[i] = iLExpression2;
					iLInlining = new ILInlining(method);
					iLInlining.InlineIfPossible(block.Body, ref i);
				}
			}
		}

		private bool MakeAssignmentExpression(List<ILNode> body, ILExpression expr, int pos)
		{
			if (!expr.Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || !operand.IsGenerated)
			{
				return false;
			}
			ILExpression iLExpression = body.ElementAtOrDefault(pos + 1) as ILExpression;
			if (iLExpression.Match(ILCode.Stloc, out ILVariable _, out ILExpression arg2) && arg2.MatchLdloc(operand))
			{
				ILExpression iLExpression2 = body.ElementAtOrDefault(pos + 2) as ILExpression;
				if (StoreCanBeConvertedToAssignment(iLExpression2, operand))
				{
					ILInlining iLInlining = new ILInlining(method);
					if (iLInlining.numLdloc.GetOrDefault(operand) == 2 && iLInlining.numStloc.GetOrDefault(operand) == 1)
					{
						body.RemoveAt(pos + 2);
						body.RemoveAt(pos);
						iLExpression.Arguments[0] = iLExpression2;
						iLExpression2.Arguments[iLExpression2.Arguments.Count - 1] = arg;
						iLInlining.InlineIfPossible(body, ref pos);
						return true;
					}
				}
				body.RemoveAt(pos + 1);
				iLExpression.Arguments[0] = arg;
				((ILExpression)body[pos]).Arguments[0] = iLExpression;
				return true;
			}
			if ((iLExpression.Code == ILCode.Stsfld || iLExpression.Code == ILCode.CallSetter || iLExpression.Code == ILCode.CallvirtSetter) && iLExpression.Arguments.Count == 1 && iLExpression.Arguments[0].MatchLdloc(operand))
			{
				body.RemoveAt(pos + 1);
				iLExpression.Arguments[0] = arg;
				((ILExpression)body[pos]).Arguments[0] = iLExpression;
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
				break;
			}
			if (store.Arguments.Last().Code == ILCode.Ldloc)
			{
				return store.Arguments.Last().Operand == exprVar;
			}
			return false;
		}

		private bool MakeCompoundAssignments(List<ILNode> body, ILExpression expr, int pos)
		{
			bool flag = false;
			flag |= MakeCompoundAssignment(expr);
			foreach (ILExpression argument in expr.Arguments)
			{
				flag |= MakeCompoundAssignments(null, argument, -1);
			}
			if (flag && body != null)
			{
				new ILInlining(method).InlineInto(body, pos, aggressive: false);
			}
			return flag;
		}

		private bool MakeCompoundAssignment(ILExpression expr)
		{
			ILCode iLCode;
			switch (expr.Code)
			{
			case ILCode.Stelem_Any:
				iLCode = ILCode.Ldelem_Any;
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
				if (!expr.Arguments[i].Match(ILCode.Ldloc, out ILVariable operand))
				{
					return false;
				}
				flag |= operand.IsGenerated;
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
			{
				MethodReference methodReference = expr.Operand as MethodReference;
				if (methodReference == null || methodReference.HasThis || expr.Arguments.Count != 2)
				{
					return false;
				}
				switch (methodReference.Name)
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
			}
			default:
				return false;
			}
		}

		private bool IntroducePostIncrement(List<ILNode> body, ILExpression expr, int pos)
		{
			bool result = IntroducePostIncrementForVariables(body, expr, pos);
			ILExpression iLExpression = IntroducePostIncrementForInstanceFields(expr);
			if (iLExpression != null)
			{
				result = true;
				body[pos] = iLExpression;
				new ILInlining(method).InlineIfPossible(body, ref pos);
			}
			return result;
		}

		private bool IntroducePostIncrementForVariables(List<ILNode> body, ILExpression expr, int pos)
		{
			if (!expr.Match(ILCode.Stloc, out ILVariable operand, out ILExpression exprInit) || !operand.IsGenerated)
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
				if (code2 != ILCode.CallSetter)
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
			int incrementAmount;
			ILCode incrementCode = GetIncrementCode(iLExpression, out incrementAmount);
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
			body.RemoveAt(pos + 1);
			return true;
		}

		private static bool IsGetterSetterPair(object getterOperand, object setterOperand)
		{
			MethodReference methodReference = getterOperand as MethodReference;
			MethodReference methodReference2 = setterOperand as MethodReference;
			if (methodReference == null || methodReference2 == null)
			{
				return false;
			}
			if (!TypeAnalysis.IsSameType(methodReference.DeclaringType, methodReference2.DeclaringType))
			{
				return false;
			}
			MethodDefinition methodDefinition = methodReference.Resolve();
			MethodDefinition methodDefinition2 = methodReference2.Resolve();
			if (methodDefinition == null || methodDefinition2 == null)
			{
				return false;
			}
			foreach (PropertyDefinition property in methodDefinition.DeclaringType.Properties)
			{
				if (property.GetMethod == methodDefinition)
				{
					return property.SetMethod == methodDefinition2;
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
			GetIncrementCode(iLExpression, out int incrementAmount);
			if (incrementAmount == 0 || !iLExpression.Arguments[0].Match(ILCode.Stloc, out ILVariable _, out ILExpression arg))
			{
				return null;
			}
			if (expr.Code == ILCode.Stfld)
			{
				if (arg.Code != ILCode.Ldfld)
				{
					return null;
				}
				FieldReference fieldReference = (FieldReference)arg.Operand;
				FieldReference fieldReference2 = (FieldReference)expr.Operand;
				if (!TypeAnalysis.IsSameType(fieldReference.DeclaringType, fieldReference2.DeclaringType) || !(fieldReference.Name == fieldReference2.Name) || !TypeAnalysis.IsSameType(fieldReference.FieldType, fieldReference2.FieldType))
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
			if (addExpr.Arguments[1].Match(ILCode.Ldc_I4, out incrementAmount) && (incrementAmount == -1 || incrementAmount == 1))
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

		private bool IntroduceFixedStatements(List<ILNode> body, int i)
		{
			if (!MatchFixedInitializer(body, i, out ILVariable pinnedVar, out ILExpression initValue, out int nextPos))
			{
				return false;
			}
			ILFixedStatement iLFixedStatement = body.ElementAtOrDefault(nextPos) as ILFixedStatement;
			if (iLFixedStatement != null)
			{
				ILExpression iLExpression = iLFixedStatement.BodyBlock.Body.LastOrDefault() as ILExpression;
				if (iLExpression != null && iLExpression.Code == ILCode.Stloc && iLExpression.Operand == pinnedVar && IsNullOrZero(iLExpression.Arguments[0]))
				{
					iLFixedStatement.Initializers.Insert(0, initValue);
					body.RemoveRange(i, nextPos - i);
					iLFixedStatement.BodyBlock.Body.RemoveAt(iLFixedStatement.BodyBlock.Body.Count - 1);
					if (pinnedVar.Type.IsByReference)
					{
						pinnedVar.Type = new PointerType(((ByReferenceType)pinnedVar.Type).ElementType);
					}
					return true;
				}
			}
			int j;
			ILExpression arg;
			ILVariable operand;
			for (j = nextPos; j < body.Count && (!body[j].Match(ILCode.Stloc, out operand, out arg) || operand != pinnedVar || !IsNullOrZero(arg)); j++)
			{
			}
			iLFixedStatement = new ILFixedStatement();
			iLFixedStatement.Initializers.Add(initValue);
			iLFixedStatement.BodyBlock = new ILBlock(body.GetRange(nextPos, j - nextPos));
			body.RemoveRange(i + 1, Math.Min(j, body.Count - 1) - i);
			body[i] = iLFixedStatement;
			if (pinnedVar.Type.IsByReference)
			{
				pinnedVar.Type = new PointerType(((ByReferenceType)pinnedVar.Type).ElementType);
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
			ILCondition iLCondition = body[i] as ILCondition;
			if (iLCondition != null && MatchFixedArrayInitializerCondition(iLCondition.Condition, out ILExpression initValue2))
			{
				ILVariable iLVariable = (ILVariable)initValue2.Operand;
				ILExpression arg;
				if (iLCondition.TrueBlock != null && iLCondition.TrueBlock.Body.Count == 1 && iLCondition.TrueBlock.Body[0].Match(ILCode.Stloc, out pinnedVar, out arg) && pinnedVar.IsPinned && IsNullOrZero(arg) && iLCondition.FalseBlock != null && iLCondition.FalseBlock.Body.Count == 1 && iLCondition.FalseBlock.Body[0] is ILFixedStatement)
				{
					ILFixedStatement iLFixedStatement = (ILFixedStatement)iLCondition.FalseBlock.Body[0];
					ILExpression arg2;
					ILVariable operand2;
					ILVariable operand;
					if (iLFixedStatement.Initializers.Count == 1 && iLFixedStatement.BodyBlock.Body.Count == 0 && iLFixedStatement.Initializers[0].Match(ILCode.Stloc, out operand, out arg2) && operand == pinnedVar && arg2.Code == ILCode.Ldelema && arg2.Arguments[0].Match(ILCode.Ldloc, out operand2) && operand2 == iLVariable && IsNullOrZero(arg2.Arguments[1]))
					{
						if (initValue2.Code == ILCode.Stloc)
						{
							ILInlining iLInlining = new ILInlining(method);
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
			if (condition.Match(ILCode.LogicNot, out ILExpression arg) && arg.Code == ILCode.LogicAnd)
			{
				initValue = UnpackDoubleNegation(arg.Arguments[0]);
				if (initValue.Match(ILCode.Ldloc, out ILVariable operand) || initValue.Match(ILCode.Stloc, out operand, out ILExpression _))
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
			if (expr.Match(ILCode.LogicNot, out ILExpression arg) && arg.Match(ILCode.LogicNot, out arg))
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
			if (!body[pos].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || !arg.Match(ILCode.Stloc, out ILVariable operand2, out ILExpression arg2))
			{
				return false;
			}
			if (!operand.IsGenerated || !operand2.IsGenerated)
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
			ILCondition iLCondition = body[pos + 1] as ILCondition;
			if (iLCondition == null || iLCondition.TrueBlock == null || iLCondition.TrueBlock.Body.Count != 1 || (iLCondition.FalseBlock != null && iLCondition.FalseBlock.Body.Count != 0))
			{
				return false;
			}
			if (!UnpackDoubleNegation(iLCondition.Condition).MatchLdloc(operand))
			{
				return false;
			}
			ILExpression arg3;
			if (!iLCondition.TrueBlock.Body[0].Match(ILCode.Stloc, out ILVariable operand3, out arg3) || operand3 != operand2 || arg3.Code != ILCode.Add)
			{
				return false;
			}
			if (!arg3.Arguments[0].MatchLdloc(operand))
			{
				return false;
			}
			if (!arg3.Arguments[1].Match(ILCode.Call, out MethodReference operand4) && !arg3.Arguments[1].Match(ILCode.CallGetter, out operand4))
			{
				return false;
			}
			if (!(operand4.Name == "get_OffsetToStringData") || !(operand4.DeclaringType.FullName == "System.Runtime.CompilerServices.RuntimeHelpers"))
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

		private static bool SimplifyLogicNot(List<ILNode> body, ILExpression expr, int pos)
		{
			bool modified = false;
			expr = SimplifyLogicNot(expr, ref modified);
			return modified;
		}

		private static ILExpression SimplifyLogicNot(ILExpression expr, ref bool modified)
		{
			ILExpression iLExpression;
			if (expr.Code == ILCode.Ceq && TypeAnalysis.IsBoolean(expr.Arguments[0].InferredType) && (iLExpression = expr.Arguments[1]).Code == ILCode.Ldc_I4 && (int)iLExpression.Operand == 0)
			{
				expr.Code = ILCode.LogicNot;
				expr.ILRanges.AddRange(iLExpression.ILRanges);
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
					iLExpression2.ILRanges.AddRange(expr.ILRanges);
					iLExpression2.ILRanges.AddRange(iLExpression.ILRanges);
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

		private static bool SimplifyLogicNotArgument(ILExpression expr)
		{
			ILExpression iLExpression = expr.Arguments[0];
			ILCode code;
			switch (iLExpression.Code)
			{
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
			iLExpression.ILRanges.AddRange(expr.ILRanges);
			return true;
		}

		private static bool SimplifyShiftOperators(List<ILNode> body, ILExpression expr, int pos)
		{
			bool modified = false;
			SimplifyShiftOperators(expr, ref modified);
			return modified;
		}

		private static void SimplifyShiftOperators(ILExpression expr, ref bool modified)
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
			if (iLExpression.Code == ILCode.And && iLExpression.Arguments[1].Code == ILCode.Ldc_I4 && expr.InferredType != null)
			{
				int num;
				switch (expr.InferredType.MetadataType)
				{
				default:
					return;
				case MetadataType.Int32:
				case MetadataType.UInt32:
					num = 31;
					break;
				case MetadataType.Int64:
				case MetadataType.UInt64:
					num = 63;
					break;
				}
				if ((int)iLExpression.Arguments[1].Operand == num)
				{
					ILExpression iLExpression2 = iLExpression.Arguments[0];
					iLExpression2.ILRanges.AddRange(iLExpression.ILRanges);
					iLExpression2.ILRanges.AddRange(iLExpression.Arguments[1].ILRanges);
					expr.Arguments[1] = iLExpression2;
					modified = true;
				}
			}
		}

		private bool InlineExpressionTreeParameterDeclarations(List<ILNode> body, ILExpression expr, int pos)
		{
			for (int num = expr.Arguments.Count - 1; num >= 0; num--)
			{
				if (InlineExpressionTreeParameterDeclarations(body, expr.Arguments[num], pos))
				{
					return true;
				}
			}
			if (!expr.Match(ILCode.Call, out MethodReference operand, out ILExpression arg, out ILExpression arg2) || !(operand.Name == "Lambda"))
			{
				return false;
			}
			if (arg2.Code != ILCode.InitArray || !(operand.DeclaringType.FullName == "System.Linq.Expressions.Expression"))
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
				array[i] = (body[num2 + i] as ILExpression);
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
			if (!expr.Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
			{
				return false;
			}
			if (operand.IsGenerated || operand.IsParameter || operand.IsPinned)
			{
				return false;
			}
			if (operand.Type == null || operand.Type.FullName != "System.Linq.Expressions.ParameterExpression")
			{
				return false;
			}
			if (!arg.Match(ILCode.Call, out MethodReference operand2, out ILExpression arg2, out ILExpression arg3))
			{
				return false;
			}
			if (!(operand2.Name == "Parameter") || !(operand2.DeclaringType.FullName == "System.Linq.Expressions.Expression"))
			{
				return false;
			}
			if (!arg2.Match(ILCode.Call, out MethodReference operand3, out ILExpression arg4))
			{
				return false;
			}
			if (!(operand3.Name == "GetTypeFromHandle") || !(operand3.DeclaringType.FullName == "System.Type"))
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
}
