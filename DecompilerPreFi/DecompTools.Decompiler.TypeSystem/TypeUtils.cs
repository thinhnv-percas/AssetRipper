using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

public static class TypeUtils
{
	public const int NativeIntSize = 6;

	public static int GetSize(this IType type)
	{
		switch (type.Kind)
		{
		case TypeKind.Class:
		case TypeKind.Pointer:
		case TypeKind.ByReference:
			return 6;
		case TypeKind.Enum:
			type = type.GetEnumUnderlyingType();
			break;
		case TypeKind.ModOpt:
		case TypeKind.ModReq:
			return type.SkipModifiers().GetSize();
		}
		ITypeDefinition definition = type.GetDefinition();
		if (definition == null)
		{
			return 0;
		}
		switch (definition.KnownTypeCode)
		{
		case KnownTypeCode.Boolean:
		case KnownTypeCode.SByte:
		case KnownTypeCode.Byte:
			return 1;
		case KnownTypeCode.Char:
		case KnownTypeCode.Int16:
		case KnownTypeCode.UInt16:
			return 2;
		case KnownTypeCode.Int32:
		case KnownTypeCode.UInt32:
		case KnownTypeCode.Single:
			return 4;
		case KnownTypeCode.IntPtr:
		case KnownTypeCode.UIntPtr:
			return 6;
		case KnownTypeCode.Int64:
		case KnownTypeCode.UInt64:
		case KnownTypeCode.Double:
			return 8;
		default:
			return 0;
		}
	}

	public static int GetSize(this StackType type)
	{
		switch (type)
		{
		case StackType.I4:
			return 4;
		case StackType.I8:
			return 8;
		case StackType.I:
		case StackType.Ref:
			return 6;
		default:
			return 0;
		}
	}

	public static IType GetLargerType(IType type1, IType type2)
	{
		return (type1.GetSize() >= type2.GetSize()) ? type1 : type2;
	}

	public static bool IsSmallIntegerType(this IType type)
	{
		int size = type.GetSize();
		return size > 0 && size < 4;
	}

	public static bool IsCSharpSmallIntegerType(this IType type)
	{
		KnownTypeCode? knownTypeCode = type.GetDefinition()?.KnownTypeCode;
		KnownTypeCode? knownTypeCode2 = knownTypeCode;
		if (knownTypeCode2.HasValue)
		{
			KnownTypeCode valueOrDefault = knownTypeCode2.GetValueOrDefault();
			if ((uint)(valueOrDefault - 5) <= 3u)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsCSharpPrimitiveIntegerType(this IType type)
	{
		KnownTypeCode? knownTypeCode = type.GetDefinition()?.KnownTypeCode;
		KnownTypeCode? knownTypeCode2 = knownTypeCode;
		if (knownTypeCode2.HasValue)
		{
			KnownTypeCode valueOrDefault = knownTypeCode2.GetValueOrDefault();
			if ((uint)(valueOrDefault - 5) <= 7u)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsIntegerType(this StackType type)
	{
		StackType stackType = type;
		if (stackType - 1 <= StackType.I)
		{
			return true;
		}
		return false;
	}

	public static bool IsFloatType(this StackType type)
	{
		StackType stackType = type;
		if (stackType - 4 <= StackType.I4)
		{
			return true;
		}
		return false;
	}

	public static bool IsCompatiblePointerTypeForMemoryAccess(IType pointerType, IType accessType)
	{
		if (pointerType is PointerType || pointerType is ByReferenceType)
		{
			IType elementType = ((TypeWithElementType)pointerType).ElementType;
			return IsCompatibleTypeForMemoryAccess(elementType, accessType);
		}
		return false;
	}

	public static bool IsCompatibleTypeForMemoryAccess(IType memoryType, IType accessType)
	{
		memoryType = memoryType.AcceptVisitor(NormalizeTypeVisitor.TypeErasure);
		accessType = accessType.AcceptVisitor(NormalizeTypeVisitor.TypeErasure);
		if (memoryType.Equals(accessType))
		{
			return true;
		}
		if (memoryType.IsReferenceType == true && accessType.IsReferenceType == true)
		{
			return true;
		}
		StackType stackType = memoryType.GetStackType();
		StackType stackType2 = accessType.GetStackType();
		if (stackType == stackType2 && stackType.IsIntegerType() && memoryType.GetSize() == accessType.GetSize())
		{
			return true;
		}
		return memoryType.Kind == TypeKind.Unknown || accessType.Kind == TypeKind.Unknown;
	}

	public static StackType GetStackType(this IType type)
	{
		switch (type.Kind)
		{
		case TypeKind.Unknown:
			if (type.IsReferenceType == true)
			{
				return StackType.O;
			}
			return StackType.Unknown;
		case TypeKind.ByReference:
			return StackType.Ref;
		case TypeKind.Pointer:
			return StackType.I;
		case TypeKind.TypeParameter:
			return StackType.O;
		case TypeKind.ModOpt:
		case TypeKind.ModReq:
			return type.SkipModifiers().GetStackType();
		default:
		{
			ITypeDefinition definition = type.GetEnumUnderlyingType().GetDefinition();
			if (definition == null)
			{
				return StackType.O;
			}
			switch (definition.KnownTypeCode)
			{
			case KnownTypeCode.Boolean:
			case KnownTypeCode.Char:
			case KnownTypeCode.SByte:
			case KnownTypeCode.Byte:
			case KnownTypeCode.Int16:
			case KnownTypeCode.UInt16:
			case KnownTypeCode.Int32:
			case KnownTypeCode.UInt32:
				return StackType.I4;
			case KnownTypeCode.Int64:
			case KnownTypeCode.UInt64:
				return StackType.I8;
			case KnownTypeCode.Single:
				return StackType.F4;
			case KnownTypeCode.Double:
				return StackType.F8;
			case KnownTypeCode.Void:
				return StackType.Void;
			case KnownTypeCode.IntPtr:
			case KnownTypeCode.UIntPtr:
				return StackType.I;
			default:
				return StackType.O;
			}
		}
		}
	}

	public static IType GetEnumUnderlyingType(this IType type)
	{
		type = type.SkipModifiers();
		return (type.Kind == TypeKind.Enum) ? type.GetDefinition().EnumUnderlyingType : type;
	}

	public static Sign GetSign(this IType type)
	{
		type = type.SkipModifiers();
		if (type.Kind == TypeKind.Pointer)
		{
			return Sign.Unsigned;
		}
		ITypeDefinition definition = type.GetEnumUnderlyingType().GetDefinition();
		if (definition == null)
		{
			return Sign.None;
		}
		switch (definition.KnownTypeCode)
		{
		case KnownTypeCode.SByte:
		case KnownTypeCode.Int16:
		case KnownTypeCode.Int32:
		case KnownTypeCode.Int64:
		case KnownTypeCode.Single:
		case KnownTypeCode.Double:
		case KnownTypeCode.Decimal:
		case KnownTypeCode.IntPtr:
			return Sign.Signed;
		case KnownTypeCode.Boolean:
		case KnownTypeCode.Char:
		case KnownTypeCode.Byte:
		case KnownTypeCode.UInt16:
		case KnownTypeCode.UInt32:
		case KnownTypeCode.UInt64:
		case KnownTypeCode.UIntPtr:
			return Sign.Unsigned;
		default:
			return Sign.None;
		}
	}

	public static PrimitiveType ToPrimitiveType(this KnownTypeCode knownTypeCode)
	{
		switch (knownTypeCode)
		{
		case KnownTypeCode.SByte:
			return PrimitiveType.I1;
		case KnownTypeCode.Int16:
			return PrimitiveType.I2;
		case KnownTypeCode.Int32:
			return PrimitiveType.I4;
		case KnownTypeCode.Int64:
			return PrimitiveType.I8;
		case KnownTypeCode.Single:
			return PrimitiveType.R4;
		case KnownTypeCode.Double:
			return PrimitiveType.R8;
		case KnownTypeCode.Byte:
			return PrimitiveType.U1;
		case KnownTypeCode.Char:
		case KnownTypeCode.UInt16:
			return PrimitiveType.U2;
		case KnownTypeCode.UInt32:
			return PrimitiveType.U4;
		case KnownTypeCode.UInt64:
			return PrimitiveType.U8;
		case KnownTypeCode.IntPtr:
			return PrimitiveType.I;
		case KnownTypeCode.UIntPtr:
			return PrimitiveType.U;
		default:
			return PrimitiveType.None;
		}
	}

	public static PrimitiveType ToPrimitiveType(this IType type)
	{
		type = type.SkipModifiers();
		if (type.Kind == TypeKind.Unknown)
		{
			return PrimitiveType.Unknown;
		}
		if (type.Kind == TypeKind.ByReference)
		{
			return PrimitiveType.Ref;
		}
		return type.GetEnumUnderlyingType().GetDefinition()?.KnownTypeCode.ToPrimitiveType() ?? PrimitiveType.None;
	}

	public static KnownTypeCode ToKnownTypeCode(this PrimitiveType primitiveType)
	{
		return primitiveType switch
		{
			PrimitiveType.I1 => KnownTypeCode.SByte, 
			PrimitiveType.I2 => KnownTypeCode.Int16, 
			PrimitiveType.I4 => KnownTypeCode.Int32, 
			PrimitiveType.I8 => KnownTypeCode.Int64, 
			PrimitiveType.R4 => KnownTypeCode.Single, 
			PrimitiveType.R8 => KnownTypeCode.Double, 
			PrimitiveType.U1 => KnownTypeCode.Byte, 
			PrimitiveType.U2 => KnownTypeCode.UInt16, 
			PrimitiveType.U4 => KnownTypeCode.UInt32, 
			PrimitiveType.U8 => KnownTypeCode.UInt64, 
			PrimitiveType.I => KnownTypeCode.IntPtr, 
			PrimitiveType.U => KnownTypeCode.UIntPtr, 
			_ => KnownTypeCode.None, 
		};
	}

	public static KnownTypeCode ToKnownTypeCode(this StackType stackType, Sign sign = Sign.None)
	{
		return stackType switch
		{
			StackType.I4 => (sign == Sign.Unsigned) ? KnownTypeCode.UInt32 : KnownTypeCode.Int32, 
			StackType.I8 => (sign == Sign.Unsigned) ? KnownTypeCode.UInt64 : KnownTypeCode.Int64, 
			StackType.I => (sign == Sign.Unsigned) ? KnownTypeCode.UIntPtr : KnownTypeCode.IntPtr, 
			StackType.F4 => KnownTypeCode.Single, 
			StackType.F8 => KnownTypeCode.Double, 
			StackType.O => KnownTypeCode.Object, 
			StackType.Void => KnownTypeCode.Void, 
			_ => KnownTypeCode.None, 
		};
	}

	public static PrimitiveType ToPrimitiveType(this StackType stackType, Sign sign = Sign.None)
	{
		return stackType switch
		{
			StackType.I4 => (sign == Sign.Unsigned) ? PrimitiveType.U4 : PrimitiveType.I4, 
			StackType.I8 => (sign == Sign.Unsigned) ? PrimitiveType.U8 : PrimitiveType.I8, 
			StackType.I => (sign == Sign.Unsigned) ? PrimitiveType.U : PrimitiveType.I, 
			StackType.F4 => PrimitiveType.R4, 
			StackType.F8 => PrimitiveType.R8, 
			StackType.Ref => PrimitiveType.Ref, 
			StackType.Unknown => PrimitiveType.Unknown, 
			_ => PrimitiveType.None, 
		};
	}
}
