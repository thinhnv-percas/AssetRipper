using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

internal static class ILTypeExtensions
{
	public static StackType GetStackType(this PrimitiveType primitiveType)
	{
		switch (primitiveType)
		{
		case PrimitiveType.I1:
		case PrimitiveType.U1:
		case PrimitiveType.I2:
		case PrimitiveType.U2:
		case PrimitiveType.I4:
		case PrimitiveType.U4:
			return StackType.I4;
		case PrimitiveType.I8:
		case PrimitiveType.U8:
			return StackType.I8;
		case (PrimitiveType)15:
		case PrimitiveType.I:
		case PrimitiveType.U:
		case (PrimitiveType)27:
			return StackType.I;
		case PrimitiveType.R4:
			return StackType.F4;
		case PrimitiveType.R8:
			return StackType.F8;
		case PrimitiveType.Ref:
			return StackType.Ref;
		case (PrimitiveType)1:
			return StackType.Void;
		case PrimitiveType.Unknown:
			return StackType.Unknown;
		default:
			return StackType.O;
		}
	}

	public static Sign GetSign(this PrimitiveType primitiveType)
	{
		switch (primitiveType)
		{
		case PrimitiveType.I1:
		case PrimitiveType.I2:
		case PrimitiveType.I4:
		case PrimitiveType.I8:
		case PrimitiveType.R4:
		case PrimitiveType.R8:
		case PrimitiveType.I:
			return Sign.Signed;
		case PrimitiveType.U1:
		case PrimitiveType.U2:
		case PrimitiveType.U4:
		case PrimitiveType.U8:
		case PrimitiveType.U:
			return Sign.Unsigned;
		default:
			return Sign.None;
		}
	}

	public static int GetSize(this PrimitiveType type)
	{
		switch (type)
		{
		case PrimitiveType.I1:
		case PrimitiveType.U1:
			return 1;
		case PrimitiveType.I2:
		case PrimitiveType.U2:
			return 2;
		case PrimitiveType.I4:
		case PrimitiveType.U4:
		case PrimitiveType.R4:
			return 4;
		case PrimitiveType.I8:
		case PrimitiveType.U8:
		case PrimitiveType.R8:
			return 8;
		case PrimitiveType.Ref:
		case PrimitiveType.I:
		case PrimitiveType.U:
			return 6;
		default:
			return 0;
		}
	}

	public static bool IsSmallIntegerType(this PrimitiveType type)
	{
		return type.GetSize() < 4;
	}

	public static bool IsIntegerType(this PrimitiveType primitiveType)
	{
		return primitiveType.GetStackType().IsIntegerType();
	}

	public static IType InferType(this ILInstruction inst, ICompilation compilation)
	{
		if (inst != null)
		{
			if (inst is NewObj newObj)
			{
				NewObj newObj2 = newObj;
				return newObj2.Method.DeclaringType;
			}
			if (inst is NewArr newArr)
			{
				NewArr newArr2 = newArr;
				if (compilation != null)
				{
					return new ArrayType(compilation, newArr2.Type, newArr2.Indices.Count);
				}
				return SpecialType.UnknownType;
			}
			if (inst is Call call)
			{
				Call call2 = call;
				return call2.Method.ReturnType;
			}
			if (inst is CallVirt callVirt)
			{
				CallVirt callVirt2 = callVirt;
				return callVirt2.Method.ReturnType;
			}
			if (inst is CallIndirect callIndirect)
			{
				CallIndirect callIndirect2 = callIndirect;
				return callIndirect2.ReturnType;
			}
			if (inst is UserDefinedLogicOperator userDefinedLogicOperator)
			{
				UserDefinedLogicOperator userDefinedLogicOperator2 = userDefinedLogicOperator;
				return userDefinedLogicOperator2.Method.ReturnType;
			}
			if (inst is LdObj ldObj)
			{
				LdObj ldObj2 = ldObj;
				return ldObj2.Type;
			}
			if (inst is StObj stObj)
			{
				StObj stObj2 = stObj;
				return stObj2.Type;
			}
			if (inst is LdLoc ldLoc)
			{
				LdLoc ldLoc2 = ldLoc;
				return ldLoc2.Variable.Type;
			}
			if (inst is StLoc stLoc)
			{
				StLoc stLoc2 = stLoc;
				return stLoc2.Variable.Type;
			}
			if (inst is LdLoca ldLoca)
			{
				LdLoca ldLoca2 = ldLoca;
				return new ByReferenceType(ldLoca2.Variable.Type);
			}
			if (inst is LdFlda ldFlda)
			{
				LdFlda ldFlda2 = ldFlda;
				return new ByReferenceType(ldFlda2.Field.Type);
			}
			if (inst is LdsFlda ldsFlda)
			{
				LdsFlda ldsFlda2 = ldsFlda;
				return new ByReferenceType(ldsFlda2.Field.Type);
			}
			if (inst is LdElema ldElema)
			{
				LdElema ldElema2 = ldElema;
				if (ldElema2.Array.InferType(compilation) is ArrayType arrayType && TypeUtils.IsCompatibleTypeForMemoryAccess(arrayType.ElementType, ldElema2.Type))
				{
					return new ByReferenceType(arrayType.ElementType);
				}
				return new ByReferenceType(ldElema2.Type);
			}
			if (inst is Comp comp)
			{
				Comp comp2 = comp;
				if (compilation == null)
				{
					return SpecialType.UnknownType;
				}
				switch (comp2.LiftingKind)
				{
				case ComparisonLiftingKind.None:
				case ComparisonLiftingKind.CSharp:
					return compilation.FindType(KnownTypeCode.Boolean);
				case ComparisonLiftingKind.ThreeValuedLogic:
					return NullableType.Create(compilation, compilation.FindType(KnownTypeCode.Boolean));
				default:
					return SpecialType.UnknownType;
				}
			}
			if (inst is BinaryNumericInstruction binaryNumericInstruction)
			{
				BinaryNumericInstruction binaryNumericInstruction2 = binaryNumericInstruction;
				if (binaryNumericInstruction2.IsLifted)
				{
					return SpecialType.UnknownType;
				}
				BinaryNumericOperator binaryNumericOperator = binaryNumericInstruction2.Operator;
				if (binaryNumericOperator - 6 <= BinaryNumericOperator.Sub)
				{
					IType type = binaryNumericInstruction2.Left.InferType(compilation);
					IType other = binaryNumericInstruction2.Right.InferType(compilation);
					if (type.Equals(other) && (type.IsCSharpPrimitiveIntegerType() || type.IsKnownType(KnownTypeCode.Boolean)))
					{
						return type;
					}
					return SpecialType.UnknownType;
				}
				return SpecialType.UnknownType;
			}
		}
		return SpecialType.UnknownType;
	}
}
