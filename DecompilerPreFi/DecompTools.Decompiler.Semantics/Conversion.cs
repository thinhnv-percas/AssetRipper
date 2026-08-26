using System;
using System.Collections.Immutable;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public abstract class Conversion : IEquatable<Conversion>
{
	private sealed class InvalidConversion : Conversion
	{
		public override bool IsValid => false;

		public override string ToString()
		{
			return "None";
		}
	}

	private sealed class NumericOrEnumerationConversion : Conversion
	{
		private readonly bool isImplicit;

		private readonly bool isLifted;

		private readonly bool isEnumeration;

		public override bool IsImplicit => isImplicit;

		public override bool IsExplicit => !isImplicit;

		public override bool IsNumericConversion => !isEnumeration;

		public override bool IsEnumerationConversion => isEnumeration;

		public override bool IsLifted => isLifted;

		public NumericOrEnumerationConversion(bool isImplicit, bool isLifted, bool isEnumeration = false)
		{
			this.isImplicit = isImplicit;
			this.isLifted = isLifted;
			this.isEnumeration = isEnumeration;
		}

		public override string ToString()
		{
			return (isImplicit ? "implicit" : "explicit") + (isLifted ? " lifted" : "") + (isEnumeration ? " enumeration" : " numeric") + " conversion";
		}

		public override bool Equals(Conversion other)
		{
			return other is NumericOrEnumerationConversion numericOrEnumerationConversion && isImplicit == numericOrEnumerationConversion.isImplicit && isLifted == numericOrEnumerationConversion.isLifted && isEnumeration == numericOrEnumerationConversion.isEnumeration;
		}

		public override int GetHashCode()
		{
			return checked((isImplicit ? 1 : 0) + (isLifted ? 2 : 0) + (isEnumeration ? 4 : 0));
		}
	}

	private sealed class BuiltinConversion : Conversion
	{
		private readonly bool isImplicit;

		private readonly byte type;

		public override bool IsImplicit => isImplicit;

		public override bool IsExplicit => !isImplicit;

		public override bool IsIdentityConversion => type == 0;

		public override bool IsNullLiteralConversion => type == 1;

		public override bool IsConstantExpressionConversion => type == 2;

		public override bool IsReferenceConversion => type == 3;

		public override bool IsDynamicConversion => type == 4;

		public override bool IsNullableConversion => type == 5;

		public override bool IsPointerConversion => type == 6;

		public override bool IsBoxingConversion => type == 7;

		public override bool IsUnboxingConversion => type == 8;

		public override bool IsTryCast => type == 9;

		public override bool IsInterpolatedStringConversion => type == 10;

		public BuiltinConversion(bool isImplicit, byte type)
		{
			this.isImplicit = isImplicit;
			this.type = type;
		}

		public override string ToString()
		{
			string text = null;
			switch (type)
			{
			case 0:
				return "identity conversion";
			case 1:
				return "null-literal conversion";
			case 2:
				text = "constant-expression";
				break;
			case 3:
				text = "reference";
				break;
			case 4:
				text = "dynamic";
				break;
			case 5:
				text = "nullable";
				break;
			case 6:
				text = "pointer";
				break;
			case 7:
				return "boxing conversion";
			case 8:
				return "unboxing conversion";
			case 9:
				return "try cast";
			case 10:
				return "interpolated string";
			}
			return (isImplicit ? "implicit " : "explicit ") + text + " conversion";
		}
	}

	private sealed class UserDefinedConv : Conversion
	{
		private readonly IMethod method;

		private readonly bool isLifted;

		private readonly Conversion conversionBeforeUserDefinedOperator;

		private readonly Conversion conversionAfterUserDefinedOperator;

		private readonly bool isImplicit;

		private readonly bool isValid;

		public override bool IsValid => isValid;

		public override bool IsImplicit => isImplicit;

		public override bool IsExplicit => !isImplicit;

		public override bool IsLifted => isLifted;

		public override bool IsUserDefined => true;

		public override Conversion ConversionBeforeUserDefinedOperator => conversionBeforeUserDefinedOperator;

		public override Conversion ConversionAfterUserDefinedOperator => conversionAfterUserDefinedOperator;

		public override IMethod Method => method;

		public UserDefinedConv(bool isImplicit, IMethod method, Conversion conversionBeforeUserDefinedOperator, Conversion conversionAfterUserDefinedOperator, bool isLifted, bool isAmbiguous)
		{
			this.method = method;
			this.isLifted = isLifted;
			this.conversionBeforeUserDefinedOperator = conversionBeforeUserDefinedOperator;
			this.conversionAfterUserDefinedOperator = conversionAfterUserDefinedOperator;
			this.isImplicit = isImplicit;
			isValid = !isAmbiguous;
		}

		public override bool Equals(Conversion other)
		{
			return other is UserDefinedConv userDefinedConv && isLifted == userDefinedConv.isLifted && isImplicit == userDefinedConv.isImplicit && isValid == userDefinedConv.isValid && method.Equals(userDefinedConv.method);
		}

		public override int GetHashCode()
		{
			return method.GetHashCode() + (isLifted ? 31 : 27) + (isImplicit ? 71 : 61) + (isValid ? 107 : 109);
		}

		public override string ToString()
		{
			return string.Concat(isImplicit ? "implicit" : "explicit", isLifted ? " lifted" : "", isValid ? "" : " ambiguous", "user-defined conversion (", method, ")");
		}
	}

	private sealed class MethodGroupConv : Conversion
	{
		private readonly IMethod method;

		private readonly bool isVirtualMethodLookup;

		private readonly bool delegateCapturesFirstArgument;

		private readonly bool isValid;

		public override bool IsValid => isValid;

		public override bool IsImplicit => true;

		public override bool IsMethodGroupConversion => true;

		public override bool IsVirtualMethodLookup => isVirtualMethodLookup;

		public override bool DelegateCapturesFirstArgument => delegateCapturesFirstArgument;

		public override IMethod Method => method;

		public MethodGroupConv(IMethod method, bool isVirtualMethodLookup, bool delegateCapturesFirstArgument, bool isValid)
		{
			this.method = method;
			this.isVirtualMethodLookup = isVirtualMethodLookup;
			this.delegateCapturesFirstArgument = delegateCapturesFirstArgument;
			this.isValid = isValid;
		}

		public override bool Equals(Conversion other)
		{
			return other is MethodGroupConv methodGroupConv && method.Equals(methodGroupConv.method);
		}

		public override int GetHashCode()
		{
			return method.GetHashCode();
		}
	}

	private sealed class TupleConv : Conversion
	{
		public override bool IsImplicit { get; }

		public override bool IsExplicit => !IsImplicit;

		public override ImmutableArray<Conversion> ElementConversions { get; }

		public override bool IsTupleConversion => true;

		public TupleConv(ImmutableArray<Conversion> elementConversions)
		{
			ElementConversions = elementConversions;
			IsImplicit = elementConversions.All((Conversion c) => c.IsImplicit);
		}

		public override bool Equals(Conversion other)
		{
			return other is TupleConv tupleConv && ElementConversions.SequenceEqual(tupleConv.ElementConversions);
		}

		public override int GetHashCode()
		{
			int num = 0;
			foreach (Conversion elementConversion in ElementConversions)
			{
				num *= 31;
				num += elementConversion.GetHashCode();
			}
			return num;
		}

		public override string ToString()
		{
			return (IsImplicit ? "implicit " : "explicit ") + " tuple conversion";
		}
	}

	public static readonly Conversion None = new InvalidConversion();

	public static readonly Conversion IdentityConversion = new BuiltinConversion(isImplicit: true, 0);

	public static readonly Conversion ImplicitNumericConversion = new NumericOrEnumerationConversion(isImplicit: true, isLifted: false);

	public static readonly Conversion ExplicitNumericConversion = new NumericOrEnumerationConversion(isImplicit: false, isLifted: false);

	public static readonly Conversion ImplicitLiftedNumericConversion = new NumericOrEnumerationConversion(isImplicit: true, isLifted: true);

	public static readonly Conversion ExplicitLiftedNumericConversion = new NumericOrEnumerationConversion(isImplicit: false, isLifted: true);

	public static readonly Conversion NullLiteralConversion = new BuiltinConversion(isImplicit: true, 1);

	public static readonly Conversion ImplicitConstantExpressionConversion = new BuiltinConversion(isImplicit: true, 2);

	public static readonly Conversion ImplicitReferenceConversion = new BuiltinConversion(isImplicit: true, 3);

	public static readonly Conversion ExplicitReferenceConversion = new BuiltinConversion(isImplicit: false, 3);

	public static readonly Conversion ImplicitDynamicConversion = new BuiltinConversion(isImplicit: true, 4);

	public static readonly Conversion ExplicitDynamicConversion = new BuiltinConversion(isImplicit: false, 4);

	public static readonly Conversion ImplicitNullableConversion = new BuiltinConversion(isImplicit: true, 5);

	public static readonly Conversion ExplicitNullableConversion = new BuiltinConversion(isImplicit: false, 5);

	public static readonly Conversion ImplicitPointerConversion = new BuiltinConversion(isImplicit: true, 6);

	public static readonly Conversion ExplicitPointerConversion = new BuiltinConversion(isImplicit: false, 6);

	public static readonly Conversion BoxingConversion = new BuiltinConversion(isImplicit: true, 7);

	public static readonly Conversion UnboxingConversion = new BuiltinConversion(isImplicit: false, 8);

	public static readonly Conversion TryCast = new BuiltinConversion(isImplicit: false, 9);

	public static readonly Conversion ImplicitInterpolatedStringConversion = new BuiltinConversion(isImplicit: true, 10);

	public virtual bool IsValid => true;

	public virtual bool IsImplicit => false;

	public virtual bool IsExplicit => false;

	public virtual bool IsTryCast => false;

	public virtual bool IsIdentityConversion => false;

	public virtual bool IsNullLiteralConversion => false;

	public virtual bool IsConstantExpressionConversion => false;

	public virtual bool IsNumericConversion => false;

	public virtual bool IsLifted => false;

	public virtual bool IsDynamicConversion => false;

	public virtual bool IsReferenceConversion => false;

	public virtual bool IsEnumerationConversion => false;

	public virtual bool IsNullableConversion => false;

	public virtual bool IsUserDefined => false;

	public virtual Conversion ConversionBeforeUserDefinedOperator => null;

	public virtual Conversion ConversionAfterUserDefinedOperator => null;

	public virtual bool IsBoxingConversion => false;

	public virtual bool IsUnboxingConversion => false;

	public virtual bool IsPointerConversion => false;

	public virtual bool IsMethodGroupConversion => false;

	public virtual bool IsVirtualMethodLookup => false;

	public virtual bool DelegateCapturesFirstArgument => false;

	public virtual bool IsAnonymousFunctionConversion => false;

	public virtual IMethod Method => null;

	public virtual bool IsTupleConversion => false;

	public virtual bool IsInterpolatedStringConversion => false;

	public virtual ImmutableArray<Conversion> ElementConversions => default(ImmutableArray<Conversion>);

	public static Conversion EnumerationConversion(bool isImplicit, bool isLifted)
	{
		return new NumericOrEnumerationConversion(isImplicit, isLifted, isEnumeration: true);
	}

	public static Conversion UserDefinedConversion(IMethod operatorMethod, bool isImplicit, Conversion conversionBeforeUserDefinedOperator, Conversion conversionAfterUserDefinedOperator, bool isLifted = false, bool isAmbiguous = false)
	{
		if (operatorMethod == null)
		{
			throw new ArgumentNullException("operatorMethod");
		}
		return new UserDefinedConv(isImplicit, operatorMethod, conversionBeforeUserDefinedOperator, conversionAfterUserDefinedOperator, isLifted, isAmbiguous);
	}

	public static Conversion MethodGroupConversion(IMethod chosenMethod, bool isVirtualMethodLookup, bool delegateCapturesFirstArgument)
	{
		if (chosenMethod == null)
		{
			throw new ArgumentNullException("chosenMethod");
		}
		return new MethodGroupConv(chosenMethod, isVirtualMethodLookup, delegateCapturesFirstArgument, isValid: true);
	}

	public static Conversion InvalidMethodGroupConversion(IMethod chosenMethod, bool isVirtualMethodLookup, bool delegateCapturesFirstArgument)
	{
		if (chosenMethod == null)
		{
			throw new ArgumentNullException("chosenMethod");
		}
		return new MethodGroupConv(chosenMethod, isVirtualMethodLookup, delegateCapturesFirstArgument, isValid: false);
	}

	public static Conversion TupleConversion(ImmutableArray<Conversion> conversions)
	{
		return new TupleConv(conversions);
	}

	public sealed override bool Equals(object obj)
	{
		return Equals(obj as Conversion);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual bool Equals(Conversion other)
	{
		return this == other;
	}
}
