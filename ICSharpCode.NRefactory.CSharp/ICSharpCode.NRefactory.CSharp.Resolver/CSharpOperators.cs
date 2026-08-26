using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

internal sealed class CSharpOperators
{
	internal class OperatorMethod : IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		private readonly ICompilation compilation;

		private readonly IList<IParameter> parameters = new List<IParameter>();

		public IList<IParameter> Parameters => parameters;

		public IType ReturnType { get; internal set; }

		public ICompilation Compilation => compilation;

		ITypeDefinition IEntity.DeclaringTypeDefinition => null;

		IType IEntity.DeclaringType => null;

		IMember IMember.MemberDefinition => this;

		IUnresolvedMember IMember.UnresolvedMember => null;

		IList<IMember> IMember.ImplementedInterfaceMembers => EmptyList<IMember>.Instance;

		bool IMember.IsVirtual => false;

		bool IMember.IsOverride => false;

		bool IMember.IsOverridable => false;

		SymbolKind ISymbol.SymbolKind => SymbolKind.Operator;

		[Obsolete("Use the SymbolKind property instead.")]
		EntityType IEntity.EntityType => EntityType.Operator;

		DomRegion IEntity.Region => DomRegion.Empty;

		DomRegion IEntity.BodyRegion => DomRegion.Empty;

		IList<IAttribute> IEntity.Attributes => EmptyList<IAttribute>.Instance;

		DocumentationComment IEntity.Documentation => null;

		Accessibility IHasAccessibility.Accessibility => Accessibility.Public;

		bool IEntity.IsStatic => true;

		bool IEntity.IsAbstract => false;

		bool IEntity.IsSealed => false;

		bool IEntity.IsShadowing => false;

		bool IEntity.IsSynthetic => true;

		bool IHasAccessibility.IsPrivate => false;

		bool IHasAccessibility.IsPublic => true;

		bool IHasAccessibility.IsProtected => false;

		bool IHasAccessibility.IsInternal => false;

		bool IHasAccessibility.IsProtectedOrInternal => false;

		bool IHasAccessibility.IsProtectedAndInternal => false;

		bool IMember.IsExplicitInterfaceImplementation => false;

		IAssembly IEntity.ParentAssembly => compilation.MainAssembly;

		TypeParameterSubstitution IMember.Substitution => TypeParameterSubstitution.Identity;

		string INamedElement.FullName => "operator";

		public string Name => "operator";

		string INamedElement.Namespace => string.Empty;

		string INamedElement.ReflectionName => "operator";

		protected OperatorMethod(ICompilation compilation)
		{
			this.compilation = compilation;
		}

		public virtual OperatorMethod Lift(CSharpOperators operators)
		{
			return null;
		}

		IMemberReference IMember.ToMemberReference()
		{
			throw new NotSupportedException();
		}

		ISymbolReference ISymbol.ToReference()
		{
			throw new NotSupportedException();
		}

		IMemberReference IMember.ToReference()
		{
			throw new NotSupportedException();
		}

		IMember IMember.Specialize(TypeParameterSubstitution substitution)
		{
			if (TypeParameterSubstitution.Identity.Equals(substitution))
			{
				return this;
			}
			throw new NotSupportedException();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(ReturnType, " operator("));
			for (int i = 0; i < parameters.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(parameters[i].Type);
			}
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}
	}

	internal class UnaryOperatorMethod : OperatorMethod
	{
		public virtual bool CanEvaluateAtCompileTime => false;

		public virtual object Invoke(CSharpResolver resolver, object input)
		{
			throw new NotSupportedException();
		}

		public UnaryOperatorMethod(ICompilation compilaton)
			: base(compilaton)
		{
		}
	}

	private sealed class LambdaUnaryOperatorMethod<T> : UnaryOperatorMethod
	{
		private readonly Func<T, T> func;

		public override bool CanEvaluateAtCompileTime => true;

		public LambdaUnaryOperatorMethod(CSharpOperators operators, Func<T, T> func)
			: base(operators.compilation)
		{
			TypeCode typeCode = Type.GetTypeCode(typeof(T));
			base.ReturnType = operators.compilation.FindType(typeCode);
			base.Parameters.Add(operators.MakeParameter(typeCode));
			this.func = func;
		}

		public override object Invoke(CSharpResolver resolver, object input)
		{
			if (input == null)
			{
				return null;
			}
			return func((T)resolver.CSharpPrimitiveCast(Type.GetTypeCode(typeof(T)), input));
		}

		public override OperatorMethod Lift(CSharpOperators operators)
		{
			return new LiftedUnaryOperatorMethod(operators, this);
		}
	}

	private sealed class LiftedUnaryOperatorMethod : UnaryOperatorMethod, OverloadResolution.ILiftedOperator, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		private UnaryOperatorMethod baseMethod;

		public IList<IParameter> NonLiftedParameters => baseMethod.Parameters;

		public LiftedUnaryOperatorMethod(CSharpOperators operators, UnaryOperatorMethod baseMethod)
			: base(operators.compilation)
		{
			this.baseMethod = baseMethod;
			base.ReturnType = NullableType.Create(baseMethod.Compilation, baseMethod.ReturnType);
			base.Parameters.Add(operators.MakeNullableParameter(baseMethod.Parameters[0]));
		}
	}

	internal class BinaryOperatorMethod : OperatorMethod
	{
		public virtual bool CanEvaluateAtCompileTime => false;

		public virtual object Invoke(CSharpResolver resolver, object lhs, object rhs)
		{
			throw new NotSupportedException();
		}

		public BinaryOperatorMethod(ICompilation compilation)
			: base(compilation)
		{
		}
	}

	private sealed class LambdaBinaryOperatorMethod<T1, T2> : BinaryOperatorMethod
	{
		private readonly Func<T1, T2, T1> checkedFunc;

		private readonly Func<T1, T2, T1> uncheckedFunc;

		public override bool CanEvaluateAtCompileTime => true;

		public LambdaBinaryOperatorMethod(CSharpOperators operators, Func<T1, T2, T1> func)
			: this(operators, func, func)
		{
		}

		public LambdaBinaryOperatorMethod(CSharpOperators operators, Func<T1, T2, T1> checkedFunc, Func<T1, T2, T1> uncheckedFunc)
			: base(operators.compilation)
		{
			TypeCode typeCode = Type.GetTypeCode(typeof(T1));
			base.ReturnType = operators.compilation.FindType(typeCode);
			base.Parameters.Add(operators.MakeParameter(typeCode));
			base.Parameters.Add(operators.MakeParameter(Type.GetTypeCode(typeof(T2))));
			this.checkedFunc = checkedFunc;
			this.uncheckedFunc = uncheckedFunc;
		}

		public override object Invoke(CSharpResolver resolver, object lhs, object rhs)
		{
			if (lhs == null || rhs == null)
			{
				return null;
			}
			Func<T1, T2, T1> func = (resolver.CheckForOverflow ? checkedFunc : uncheckedFunc);
			return func((T1)resolver.CSharpPrimitiveCast(Type.GetTypeCode(typeof(T1)), lhs), (T2)resolver.CSharpPrimitiveCast(Type.GetTypeCode(typeof(T2)), rhs));
		}

		public override OperatorMethod Lift(CSharpOperators operators)
		{
			return new LiftedBinaryOperatorMethod(operators, this);
		}
	}

	private sealed class LiftedBinaryOperatorMethod : BinaryOperatorMethod, OverloadResolution.ILiftedOperator, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		private readonly BinaryOperatorMethod baseMethod;

		public IList<IParameter> NonLiftedParameters => baseMethod.Parameters;

		public LiftedBinaryOperatorMethod(CSharpOperators operators, BinaryOperatorMethod baseMethod)
			: base(operators.compilation)
		{
			this.baseMethod = baseMethod;
			base.ReturnType = NullableType.Create(operators.compilation, baseMethod.ReturnType);
			base.Parameters.Add(operators.MakeNullableParameter(baseMethod.Parameters[0]));
			base.Parameters.Add(operators.MakeNullableParameter(baseMethod.Parameters[1]));
		}
	}

	private sealed class StringConcatenation : BinaryOperatorMethod
	{
		private bool canEvaluateAtCompileTime;

		public override bool CanEvaluateAtCompileTime => canEvaluateAtCompileTime;

		public StringConcatenation(CSharpOperators operators, TypeCode p1, TypeCode p2)
			: base(operators.compilation)
		{
			canEvaluateAtCompileTime = p1 == TypeCode.String && p2 == TypeCode.String;
			base.ReturnType = operators.compilation.FindType(KnownTypeCode.String);
			base.Parameters.Add(operators.MakeParameter(p1));
			base.Parameters.Add(operators.MakeParameter(p2));
		}

		public override object Invoke(CSharpResolver resolver, object lhs, object rhs)
		{
			return string.Concat(lhs, rhs);
		}
	}

	private sealed class EqualityOperatorMethod : BinaryOperatorMethod
	{
		public readonly TypeCode Type;

		public readonly bool Negate;

		public override bool CanEvaluateAtCompileTime => Type != TypeCode.Object;

		public EqualityOperatorMethod(CSharpOperators operators, TypeCode type, bool negate)
			: base(operators.compilation)
		{
			Negate = negate;
			Type = type;
			base.ReturnType = operators.compilation.FindType(KnownTypeCode.Boolean);
			base.Parameters.Add(operators.MakeParameter(type));
			base.Parameters.Add(operators.MakeParameter(type));
		}

		public override object Invoke(CSharpResolver resolver, object lhs, object rhs)
		{
			if (lhs == null && rhs == null)
			{
				return !Negate;
			}
			if (lhs == null || rhs == null)
			{
				return Negate;
			}
			lhs = resolver.CSharpPrimitiveCast(Type, lhs);
			rhs = resolver.CSharpPrimitiveCast(Type, rhs);
			bool flag = ((Type == TypeCode.Single) ? ((float)lhs == (float)rhs) : ((Type != TypeCode.Double) ? object.Equals(lhs, rhs) : ((double)lhs == (double)rhs)));
			return flag ^ Negate;
		}

		public override OperatorMethod Lift(CSharpOperators operators)
		{
			if (Type == TypeCode.Object || Type == TypeCode.String)
			{
				return null;
			}
			return new LiftedEqualityOperatorMethod(operators, this);
		}
	}

	private sealed class LiftedEqualityOperatorMethod : BinaryOperatorMethod, OverloadResolution.ILiftedOperator, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		private readonly EqualityOperatorMethod baseMethod;

		public override bool CanEvaluateAtCompileTime => baseMethod.CanEvaluateAtCompileTime;

		public IList<IParameter> NonLiftedParameters => baseMethod.Parameters;

		public LiftedEqualityOperatorMethod(CSharpOperators operators, EqualityOperatorMethod baseMethod)
			: base(operators.compilation)
		{
			this.baseMethod = baseMethod;
			base.ReturnType = baseMethod.ReturnType;
			IParameter item = operators.MakeNullableParameter(baseMethod.Parameters[0]);
			base.Parameters.Add(item);
			base.Parameters.Add(item);
		}

		public override object Invoke(CSharpResolver resolver, object lhs, object rhs)
		{
			return baseMethod.Invoke(resolver, lhs, rhs);
		}
	}

	private sealed class RelationalOperatorMethod<T1, T2> : BinaryOperatorMethod
	{
		private readonly Func<T1, T2, bool> func;

		public override bool CanEvaluateAtCompileTime => true;

		public RelationalOperatorMethod(CSharpOperators operators, Func<T1, T2, bool> func)
			: base(operators.compilation)
		{
			base.ReturnType = operators.compilation.FindType(KnownTypeCode.Boolean);
			base.Parameters.Add(operators.MakeParameter(Type.GetTypeCode(typeof(T1))));
			base.Parameters.Add(operators.MakeParameter(Type.GetTypeCode(typeof(T2))));
			this.func = func;
		}

		public override object Invoke(CSharpResolver resolver, object lhs, object rhs)
		{
			if (lhs == null || rhs == null)
			{
				return null;
			}
			return func((T1)resolver.CSharpPrimitiveCast(Type.GetTypeCode(typeof(T1)), lhs), (T2)resolver.CSharpPrimitiveCast(Type.GetTypeCode(typeof(T2)), rhs));
		}

		public override OperatorMethod Lift(CSharpOperators operators)
		{
			LiftedBinaryOperatorMethod liftedBinaryOperatorMethod = new LiftedBinaryOperatorMethod(operators, this);
			liftedBinaryOperatorMethod.ReturnType = base.ReturnType;
			return liftedBinaryOperatorMethod;
		}
	}

	private readonly ICompilation compilation;

	private IParameter[] normalParameters = new IParameter[18];

	private IParameter[] nullableParameters = new IParameter[13];

	private OperatorMethod[] unaryPlusOperators;

	private OperatorMethod[] uncheckedUnaryMinusOperators;

	private OperatorMethod[] checkedUnaryMinusOperators;

	private OperatorMethod[] logicalNegationOperators;

	private OperatorMethod[] bitwiseComplementOperators;

	private OperatorMethod[] multiplicationOperators;

	private OperatorMethod[] divisionOperators;

	private OperatorMethod[] remainderOperators;

	private OperatorMethod[] additionOperators;

	private OperatorMethod[] subtractionOperators;

	private OperatorMethod[] shiftLeftOperators;

	private OperatorMethod[] shiftRightOperators;

	private static readonly TypeCode[] valueEqualityOperatorsFor = new TypeCode[8]
	{
		TypeCode.Int32,
		TypeCode.UInt32,
		TypeCode.Int64,
		TypeCode.UInt64,
		TypeCode.Single,
		TypeCode.Double,
		TypeCode.Decimal,
		TypeCode.Boolean
	};

	private OperatorMethod[] valueEqualityOperators;

	private OperatorMethod[] valueInequalityOperators;

	private OperatorMethod[] referenceEqualityOperators;

	private OperatorMethod[] referenceInequalityOperators;

	private OperatorMethod[] lessThanOperators;

	private OperatorMethod[] lessThanOrEqualOperators;

	private OperatorMethod[] greaterThanOperators;

	private OperatorMethod[] greaterThanOrEqualOperators;

	private OperatorMethod[] logicalAndOperators;

	private OperatorMethod[] bitwiseAndOperators;

	private OperatorMethod[] logicalOrOperators;

	private OperatorMethod[] bitwiseOrOperators;

	private OperatorMethod[] bitwiseXorOperators;

	public OperatorMethod[] UnaryPlusOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref unaryPlusOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref unaryPlusOperators, Lift(new LambdaUnaryOperatorMethod<int>(this, (int i) => i), new LambdaUnaryOperatorMethod<uint>(this, (uint i) => i), new LambdaUnaryOperatorMethod<long>(this, (long i) => i), new LambdaUnaryOperatorMethod<ulong>(this, (ulong i) => i), new LambdaUnaryOperatorMethod<float>(this, (float i) => i), new LambdaUnaryOperatorMethod<double>(this, (double i) => i), new LambdaUnaryOperatorMethod<decimal>(this, (decimal i) => i)));
		}
	}

	public OperatorMethod[] UncheckedUnaryMinusOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref uncheckedUnaryMinusOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref uncheckedUnaryMinusOperators, Lift(new LambdaUnaryOperatorMethod<int>(this, (int i) => -i), new LambdaUnaryOperatorMethod<long>(this, (long i) => -i), new LambdaUnaryOperatorMethod<float>(this, (float i) => 0f - i), new LambdaUnaryOperatorMethod<double>(this, (double i) => 0.0 - i), new LambdaUnaryOperatorMethod<decimal>(this, (decimal i) => -i)));
		}
	}

	public OperatorMethod[] CheckedUnaryMinusOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref checkedUnaryMinusOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref checkedUnaryMinusOperators, checked(Lift(new LambdaUnaryOperatorMethod<int>(this, (int i) => -i), new LambdaUnaryOperatorMethod<long>(this, (long i) => -i), new LambdaUnaryOperatorMethod<float>(this, (float i) => 0f - i), new LambdaUnaryOperatorMethod<double>(this, (double i) => 0.0 - i), new LambdaUnaryOperatorMethod<decimal>(this, (decimal i) => -i))));
		}
	}

	public OperatorMethod[] LogicalNegationOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref logicalNegationOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref logicalNegationOperators, Lift(new LambdaUnaryOperatorMethod<bool>(this, (bool b) => !b)));
		}
	}

	public OperatorMethod[] BitwiseComplementOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref bitwiseComplementOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref bitwiseComplementOperators, Lift(new LambdaUnaryOperatorMethod<int>(this, (int i) => ~i), new LambdaUnaryOperatorMethod<uint>(this, (uint i) => ~i), new LambdaUnaryOperatorMethod<long>(this, (long i) => ~i), new LambdaUnaryOperatorMethod<ulong>(this, (ulong i) => ~i)));
		}
	}

	public OperatorMethod[] MultiplicationOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref multiplicationOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref multiplicationOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => checked(a * b), (int a, int b) => a * b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => checked(a * b), (uint a, uint b) => a * b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => checked(a * b), (long a, long b) => a * b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => checked(a * b), (ulong a, ulong b) => a * b), new LambdaBinaryOperatorMethod<float, float>(this, (float a, float b) => a * b, (float a, float b) => a * b), new LambdaBinaryOperatorMethod<double, double>(this, (double a, double b) => a * b, (double a, double b) => a * b), new LambdaBinaryOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a * b, (decimal a, decimal b) => a * b)));
		}
	}

	public OperatorMethod[] DivisionOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref divisionOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref divisionOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => a / b, (int a, int b) => a / b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => a / b, (uint a, uint b) => a / b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => a / b, (long a, long b) => a / b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a / b, (ulong a, ulong b) => a / b), new LambdaBinaryOperatorMethod<float, float>(this, (float a, float b) => a / b, (float a, float b) => a / b), new LambdaBinaryOperatorMethod<double, double>(this, (double a, double b) => a / b, (double a, double b) => a / b), new LambdaBinaryOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a / b, (decimal a, decimal b) => a / b)));
		}
	}

	public OperatorMethod[] RemainderOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref remainderOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref remainderOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => a % b, (int a, int b) => a % b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => a % b, (uint a, uint b) => a % b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => a % b, (long a, long b) => a % b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a % b, (ulong a, ulong b) => a % b), new LambdaBinaryOperatorMethod<float, float>(this, (float a, float b) => a % b, (float a, float b) => a % b), new LambdaBinaryOperatorMethod<double, double>(this, (double a, double b) => a % b, (double a, double b) => a % b), new LambdaBinaryOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a % b, (decimal a, decimal b) => a % b)));
		}
	}

	public OperatorMethod[] AdditionOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref additionOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref additionOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => checked(a + b), (int a, int b) => a + b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => checked(a + b), (uint a, uint b) => a + b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => checked(a + b), (long a, long b) => a + b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => checked(a + b), (ulong a, ulong b) => a + b), new LambdaBinaryOperatorMethod<float, float>(this, (float a, float b) => a + b, (float a, float b) => a + b), new LambdaBinaryOperatorMethod<double, double>(this, (double a, double b) => a + b, (double a, double b) => a + b), new LambdaBinaryOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a + b, (decimal a, decimal b) => a + b), new StringConcatenation(this, TypeCode.String, TypeCode.String), new StringConcatenation(this, TypeCode.String, TypeCode.Object), new StringConcatenation(this, TypeCode.Object, TypeCode.String)));
		}
	}

	public OperatorMethod[] SubtractionOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref subtractionOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref subtractionOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => checked(a - b), (int a, int b) => a - b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => checked(a - b), (uint a, uint b) => a - b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => checked(a - b), (long a, long b) => a - b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => checked(a - b), (ulong a, ulong b) => a - b), new LambdaBinaryOperatorMethod<float, float>(this, (float a, float b) => a - b, (float a, float b) => a - b), new LambdaBinaryOperatorMethod<double, double>(this, (double a, double b) => a - b, (double a, double b) => a - b), new LambdaBinaryOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a - b, (decimal a, decimal b) => a - b)));
		}
	}

	public OperatorMethod[] ShiftLeftOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref shiftLeftOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref shiftLeftOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => a << b), new LambdaBinaryOperatorMethod<uint, int>(this, (uint a, int b) => a << b), new LambdaBinaryOperatorMethod<long, int>(this, (long a, int b) => a << b), new LambdaBinaryOperatorMethod<ulong, int>(this, (ulong a, int b) => a << b)));
		}
	}

	public OperatorMethod[] ShiftRightOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref shiftRightOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref shiftRightOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => a >> b), new LambdaBinaryOperatorMethod<uint, int>(this, (uint a, int b) => a >> b), new LambdaBinaryOperatorMethod<long, int>(this, (long a, int b) => a >> b), new LambdaBinaryOperatorMethod<ulong, int>(this, (ulong a, int b) => a >> b)));
		}
	}

	public OperatorMethod[] ValueEqualityOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref valueEqualityOperators);
			if (array != null)
			{
				return array;
			}
			ref OperatorMethod[] target = ref valueEqualityOperators;
			OperatorMethod[] methods = valueEqualityOperatorsFor.Select((TypeCode c) => new EqualityOperatorMethod(this, c, negate: false)).ToArray();
			return LazyInit.GetOrSet(ref target, Lift(methods));
		}
	}

	public OperatorMethod[] ValueInequalityOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref valueInequalityOperators);
			if (array != null)
			{
				return array;
			}
			ref OperatorMethod[] target = ref valueInequalityOperators;
			OperatorMethod[] methods = valueEqualityOperatorsFor.Select((TypeCode c) => new EqualityOperatorMethod(this, c, negate: true)).ToArray();
			return LazyInit.GetOrSet(ref target, Lift(methods));
		}
	}

	public OperatorMethod[] ReferenceEqualityOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref referenceEqualityOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref referenceEqualityOperators, Lift(new EqualityOperatorMethod(this, TypeCode.Object, negate: false), new EqualityOperatorMethod(this, TypeCode.String, negate: false)));
		}
	}

	public OperatorMethod[] ReferenceInequalityOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref referenceInequalityOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref referenceInequalityOperators, Lift(new EqualityOperatorMethod(this, TypeCode.Object, negate: true), new EqualityOperatorMethod(this, TypeCode.String, negate: true)));
		}
	}

	public OperatorMethod[] LessThanOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref lessThanOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref lessThanOperators, Lift(new RelationalOperatorMethod<int, int>(this, (int a, int b) => a < b), new RelationalOperatorMethod<uint, uint>(this, (uint a, uint b) => a < b), new RelationalOperatorMethod<long, long>(this, (long a, long b) => a < b), new RelationalOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a < b), new RelationalOperatorMethod<float, float>(this, (float a, float b) => a < b), new RelationalOperatorMethod<double, double>(this, (double a, double b) => a < b), new RelationalOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a < b)));
		}
	}

	public OperatorMethod[] LessThanOrEqualOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref lessThanOrEqualOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref lessThanOrEqualOperators, Lift(new RelationalOperatorMethod<int, int>(this, (int a, int b) => a <= b), new RelationalOperatorMethod<uint, uint>(this, (uint a, uint b) => a <= b), new RelationalOperatorMethod<long, long>(this, (long a, long b) => a <= b), new RelationalOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a <= b), new RelationalOperatorMethod<float, float>(this, (float a, float b) => a <= b), new RelationalOperatorMethod<double, double>(this, (double a, double b) => a <= b), new RelationalOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a <= b)));
		}
	}

	public OperatorMethod[] GreaterThanOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref greaterThanOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref greaterThanOperators, Lift(new RelationalOperatorMethod<int, int>(this, (int a, int b) => a > b), new RelationalOperatorMethod<uint, uint>(this, (uint a, uint b) => a > b), new RelationalOperatorMethod<long, long>(this, (long a, long b) => a > b), new RelationalOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a > b), new RelationalOperatorMethod<float, float>(this, (float a, float b) => a > b), new RelationalOperatorMethod<double, double>(this, (double a, double b) => a > b), new RelationalOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a > b)));
		}
	}

	public OperatorMethod[] GreaterThanOrEqualOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref greaterThanOrEqualOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref greaterThanOrEqualOperators, Lift(new RelationalOperatorMethod<int, int>(this, (int a, int b) => a >= b), new RelationalOperatorMethod<uint, uint>(this, (uint a, uint b) => a >= b), new RelationalOperatorMethod<long, long>(this, (long a, long b) => a >= b), new RelationalOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a >= b), new RelationalOperatorMethod<float, float>(this, (float a, float b) => a >= b), new RelationalOperatorMethod<double, double>(this, (double a, double b) => a >= b), new RelationalOperatorMethod<decimal, decimal>(this, (decimal a, decimal b) => a >= b)));
		}
	}

	public OperatorMethod[] LogicalAndOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref logicalAndOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref logicalAndOperators, new OperatorMethod[1]
			{
				new LambdaBinaryOperatorMethod<bool, bool>(this, (bool a, bool b) => a & b)
			});
		}
	}

	public OperatorMethod[] BitwiseAndOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref bitwiseAndOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref bitwiseAndOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => a & b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => a & b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => a & b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a & b), LogicalAndOperators[0]));
		}
	}

	public OperatorMethod[] LogicalOrOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref logicalOrOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref logicalOrOperators, new OperatorMethod[1]
			{
				new LambdaBinaryOperatorMethod<bool, bool>(this, (bool a, bool b) => a | b)
			});
		}
	}

	public OperatorMethod[] BitwiseOrOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref bitwiseOrOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref bitwiseOrOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => a | b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => a | b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => a | b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a | b), LogicalOrOperators[0]));
		}
	}

	public OperatorMethod[] BitwiseXorOperators
	{
		get
		{
			OperatorMethod[] array = LazyInit.VolatileRead(ref bitwiseXorOperators);
			if (array != null)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref bitwiseXorOperators, Lift(new LambdaBinaryOperatorMethod<int, int>(this, (int a, int b) => a ^ b), new LambdaBinaryOperatorMethod<uint, uint>(this, (uint a, uint b) => a ^ b), new LambdaBinaryOperatorMethod<long, long>(this, (long a, long b) => a ^ b), new LambdaBinaryOperatorMethod<ulong, ulong>(this, (ulong a, ulong b) => a ^ b), new LambdaBinaryOperatorMethod<bool, bool>(this, (bool a, bool b) => a ^ b)));
		}
	}

	private CSharpOperators(ICompilation compilation)
	{
		this.compilation = compilation;
		InitParameterArrays();
	}

	public static CSharpOperators Get(ICompilation compilation)
	{
		CacheManager cacheManager = compilation.CacheManager;
		CSharpOperators cSharpOperators = (CSharpOperators)cacheManager.GetShared(typeof(CSharpOperators));
		if (cSharpOperators == null)
		{
			cSharpOperators = (CSharpOperators)cacheManager.GetOrAddShared(typeof(CSharpOperators), new CSharpOperators(compilation));
		}
		return cSharpOperators;
	}

	private OperatorMethod[] Lift(params OperatorMethod[] methods)
	{
		List<OperatorMethod> list = new List<OperatorMethod>(methods);
		foreach (OperatorMethod operatorMethod in methods)
		{
			OperatorMethod operatorMethod2 = operatorMethod.Lift(this);
			if (operatorMethod2 != null)
			{
				list.Add(operatorMethod2);
			}
		}
		return list.ToArray();
	}

	private void InitParameterArrays()
	{
		for (TypeCode typeCode = TypeCode.Object; typeCode <= TypeCode.String; typeCode++)
		{
			normalParameters[(int)(typeCode - 1)] = new DefaultParameter(compilation.FindType(typeCode), string.Empty);
		}
		for (TypeCode typeCode2 = TypeCode.Boolean; typeCode2 <= TypeCode.Decimal; typeCode2++)
		{
			IType type = NullableType.Create(compilation, compilation.FindType(typeCode2));
			nullableParameters[(int)(typeCode2 - 3)] = new DefaultParameter(type, string.Empty);
		}
	}

	private IParameter MakeParameter(TypeCode code)
	{
		return normalParameters[(int)(code - 1)];
	}

	private IParameter MakeNullableParameter(IParameter normalParameter)
	{
		for (TypeCode typeCode = TypeCode.Boolean; typeCode <= TypeCode.Decimal; typeCode++)
		{
			if (normalParameter == normalParameters[(int)(typeCode - 1)])
			{
				return nullableParameters[(int)(typeCode - 3)];
			}
		}
		throw new ArgumentException();
	}
}
