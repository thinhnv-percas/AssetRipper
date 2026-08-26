using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public sealed class CSharpConversions
{
	private struct TypePair : IEquatable<TypePair>
	{
		public readonly IType FromType;

		public readonly IType ToType;

		public TypePair(IType fromType, IType toType)
		{
			FromType = fromType;
			ToType = toType;
		}

		public override bool Equals(object obj)
		{
			if (obj is TypePair)
			{
				return Equals((TypePair)obj);
			}
			return false;
		}

		public bool Equals(TypePair other)
		{
			if (object.Equals(FromType, other.FromType))
			{
				return object.Equals(ToType, other.ToType);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return 1000000007 * FromType.GetHashCode() + 1000000009 * ToType.GetHashCode();
		}
	}

	private sealed class DynamicErasure : TypeVisitor
	{
		private readonly IType objectType;

		public DynamicErasure(CSharpConversions conversions)
		{
			objectType = conversions.objectType;
		}

		public override IType VisitOtherType(IType type)
		{
			if (type.Kind == TypeKind.Dynamic)
			{
				return objectType;
			}
			return base.VisitOtherType(type);
		}
	}

	private class OperatorInfo
	{
		public readonly IMethod Method;

		public readonly IType SourceType;

		public readonly IType TargetType;

		public readonly bool IsLifted;

		public OperatorInfo(IMethod method, IType sourceType, IType targetType, bool isLifted)
		{
			Method = method;
			SourceType = sourceType;
			TargetType = targetType;
			IsLifted = isLifted;
		}
	}

	private readonly ConcurrentDictionary<TypePair, Conversion> implicitConversionCache = new ConcurrentDictionary<TypePair, Conversion>();

	private readonly ICompilation compilation;

	private readonly IType objectType;

	private readonly DynamicErasure dynamicErasure;

	private static readonly bool[,] implicitNumericConversionLookup = new bool[7, 6]
	{
		{ false, true, true, true, true, true },
		{ true, false, true, false, true, false },
		{ true, true, true, true, true, true },
		{ false, false, true, false, true, false },
		{ false, false, true, true, true, true },
		{ false, false, false, false, true, false },
		{ false, false, false, false, true, true }
	};

	public CSharpConversions(ICompilation compilation)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		this.compilation = compilation;
		objectType = compilation.FindType(KnownTypeCode.Object);
		dynamicErasure = new DynamicErasure(this);
	}

	public static CSharpConversions Get(ICompilation compilation)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		CacheManager cacheManager = compilation.CacheManager;
		CSharpConversions cSharpConversions = (CSharpConversions)cacheManager.GetShared(typeof(CSharpConversions));
		if (cSharpConversions == null)
		{
			cSharpConversions = (CSharpConversions)cacheManager.GetOrAddShared(typeof(CSharpConversions), new CSharpConversions(compilation));
		}
		return cSharpConversions;
	}

	private Conversion ImplicitConversion(ResolveResult resolveResult, IType toType, bool allowUserDefined)
	{
		Conversion conversion;
		if (resolveResult.IsCompileTimeConstant)
		{
			conversion = ImplicitEnumerationConversion(resolveResult, toType);
			if (conversion.IsValid)
			{
				return conversion;
			}
			if (ImplicitConstantExpressionConversion(resolveResult, toType))
			{
				return Conversion.ImplicitConstantExpressionConversion;
			}
			conversion = StandardImplicitConversion(resolveResult.Type, toType);
			if (conversion != Conversion.None)
			{
				return conversion;
			}
			if (allowUserDefined)
			{
				conversion = UserDefinedImplicitConversion(resolveResult, resolveResult.Type, toType);
				if (conversion != Conversion.None)
				{
					return conversion;
				}
			}
		}
		else
		{
			conversion = ImplicitConversion(resolveResult.Type, toType, allowUserDefined);
			if (conversion != Conversion.None)
			{
				return conversion;
			}
		}
		if (resolveResult.Type.Kind == TypeKind.Dynamic)
		{
			return Conversion.ImplicitDynamicConversion;
		}
		conversion = AnonymousFunctionConversion(resolveResult, toType);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		return MethodGroupConversion(resolveResult, toType);
	}

	private Conversion ImplicitConversion(IType fromType, IType toType, bool allowUserDefined)
	{
		Conversion conversion = StandardImplicitConversion(fromType, toType);
		if ((conversion == Conversion.None) & allowUserDefined)
		{
			conversion = UserDefinedImplicitConversion(null, fromType, toType);
		}
		return conversion;
	}

	public Conversion ImplicitConversion(ResolveResult resolveResult, IType toType)
	{
		if (resolveResult == null)
		{
			throw new ArgumentNullException("resolveResult");
		}
		return ImplicitConversion(resolveResult, toType, allowUserDefined: true);
	}

	public Conversion ImplicitConversion(IType fromType, IType toType)
	{
		if (fromType == null)
		{
			throw new ArgumentNullException("fromType");
		}
		if (toType == null)
		{
			throw new ArgumentNullException("toType");
		}
		TypePair key = new TypePair(fromType, toType);
		if (implicitConversionCache.TryGetValue(key, out var value))
		{
			return value;
		}
		value = ImplicitConversion(fromType, toType, allowUserDefined: true);
		implicitConversionCache[key] = value;
		return value;
	}

	public Conversion StandardImplicitConversion(IType fromType, IType toType)
	{
		if (fromType == null)
		{
			throw new ArgumentNullException("fromType");
		}
		if (toType == null)
		{
			throw new ArgumentNullException("toType");
		}
		if (IdentityConversion(fromType, toType))
		{
			return Conversion.IdentityConversion;
		}
		if (ImplicitNumericConversion(fromType, toType))
		{
			return Conversion.ImplicitNumericConversion;
		}
		Conversion conversion = ImplicitNullableConversion(fromType, toType);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		if (NullLiteralConversion(fromType, toType))
		{
			return Conversion.NullLiteralConversion;
		}
		if (ImplicitReferenceConversion(fromType, toType, 0))
		{
			return Conversion.ImplicitReferenceConversion;
		}
		if (IsBoxingConversion(fromType, toType))
		{
			return Conversion.BoxingConversion;
		}
		if (ImplicitTypeParameterConversion(fromType, toType))
		{
			return Conversion.BoxingConversion;
		}
		if (ImplicitPointerConversion(fromType, toType))
		{
			return Conversion.ImplicitPointerConversion;
		}
		return Conversion.None;
	}

	public bool IsConstraintConvertible(IType fromType, IType toType)
	{
		if (fromType == null)
		{
			throw new ArgumentNullException("fromType");
		}
		if (toType == null)
		{
			throw new ArgumentNullException("toType");
		}
		if (IdentityConversion(fromType, toType))
		{
			return true;
		}
		if (ImplicitReferenceConversion(fromType, toType, 0))
		{
			return true;
		}
		if (NullableType.IsNullable(fromType))
		{
			if (toType.IsKnownType(KnownTypeCode.Object))
			{
				return true;
			}
		}
		else if (IsBoxingConversion(fromType, toType))
		{
			return true;
		}
		if (ImplicitTypeParameterConversion(fromType, toType))
		{
			return true;
		}
		return false;
	}

	public Conversion ExplicitConversion(ResolveResult resolveResult, IType toType)
	{
		if (resolveResult == null)
		{
			throw new ArgumentNullException("resolveResult");
		}
		if (toType == null)
		{
			throw new ArgumentNullException("toType");
		}
		if (resolveResult.Type.Kind == TypeKind.Dynamic)
		{
			return Conversion.ExplicitDynamicConversion;
		}
		Conversion conversion = ImplicitConversion(resolveResult, toType, allowUserDefined: false);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		conversion = ExplicitConversionImpl(resolveResult.Type, toType);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		return UserDefinedExplicitConversion(resolveResult, resolveResult.Type, toType);
	}

	public Conversion ExplicitConversion(IType fromType, IType toType)
	{
		if (fromType == null)
		{
			throw new ArgumentNullException("fromType");
		}
		if (toType == null)
		{
			throw new ArgumentNullException("toType");
		}
		Conversion conversion = ImplicitConversion(fromType, toType, allowUserDefined: false);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		conversion = ExplicitConversionImpl(fromType, toType);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		return UserDefinedExplicitConversion(null, fromType, toType);
	}

	private Conversion ExplicitConversionImpl(IType fromType, IType toType)
	{
		if (AnyNumericConversion(fromType, toType))
		{
			return Conversion.ExplicitNumericConversion;
		}
		if (ExplicitEnumerationConversion(fromType, toType))
		{
			return Conversion.EnumerationConversion(isImplicit: false, isLifted: false);
		}
		Conversion conversion = ExplicitNullableConversion(fromType, toType);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		if (ExplicitReferenceConversion(fromType, toType))
		{
			return Conversion.ExplicitReferenceConversion;
		}
		if (UnboxingConversion(fromType, toType))
		{
			return Conversion.UnboxingConversion;
		}
		conversion = ExplicitTypeParameterConversion(fromType, toType);
		if (conversion != Conversion.None)
		{
			return conversion;
		}
		if (ExplicitPointerConversion(fromType, toType))
		{
			return Conversion.ExplicitPointerConversion;
		}
		return Conversion.None;
	}

	public bool IdentityConversion(IType fromType, IType toType)
	{
		return fromType.AcceptVisitor(dynamicErasure).Equals(toType.AcceptVisitor(dynamicErasure));
	}

	private bool ImplicitNumericConversion(IType fromType, IType toType)
	{
		TypeCode typeCode = ReflectionHelper.GetTypeCode(fromType);
		TypeCode typeCode2 = ReflectionHelper.GetTypeCode(toType);
		if (typeCode2 >= TypeCode.Single && typeCode2 <= TypeCode.Decimal)
		{
			if (typeCode < TypeCode.Char || typeCode > TypeCode.UInt64)
			{
				if (typeCode == TypeCode.Single)
				{
					return typeCode2 == TypeCode.Double;
				}
				return false;
			}
			return true;
		}
		if (typeCode >= TypeCode.Char && typeCode <= TypeCode.UInt32 && typeCode2 >= TypeCode.Int16 && typeCode2 <= TypeCode.UInt64)
		{
			return implicitNumericConversionLookup[(int)(typeCode - 4), (int)(typeCode2 - 7)];
		}
		return false;
	}

	private bool IsNumericType(IType type)
	{
		TypeCode typeCode = ReflectionHelper.GetTypeCode(type);
		if (typeCode >= TypeCode.Char)
		{
			return typeCode <= TypeCode.Decimal;
		}
		return false;
	}

	private bool AnyNumericConversion(IType fromType, IType toType)
	{
		if (IsNumericType(fromType))
		{
			return IsNumericType(toType);
		}
		return false;
	}

	private Conversion ImplicitEnumerationConversion(ResolveResult rr, IType toType)
	{
		TypeCode typeCode = ReflectionHelper.GetTypeCode(rr.Type);
		if (typeCode >= TypeCode.SByte && typeCode <= TypeCode.Decimal && Convert.ToDouble(rr.ConstantValue) == 0.0 && NullableType.GetUnderlyingType(toType).Kind == TypeKind.Enum)
		{
			return Conversion.EnumerationConversion(isImplicit: true, NullableType.IsNullable(toType));
		}
		return Conversion.None;
	}

	private bool ExplicitEnumerationConversion(IType fromType, IType toType)
	{
		if (fromType.Kind == TypeKind.Enum)
		{
			if (toType.Kind != TypeKind.Enum)
			{
				return IsNumericType(toType);
			}
			return true;
		}
		if (IsNumericType(fromType))
		{
			return toType.Kind == TypeKind.Enum;
		}
		return false;
	}

	private Conversion ImplicitNullableConversion(IType fromType, IType toType)
	{
		if (NullableType.IsNullable(toType))
		{
			IType underlyingType = NullableType.GetUnderlyingType(toType);
			IType underlyingType2 = NullableType.GetUnderlyingType(fromType);
			if (IdentityConversion(underlyingType2, underlyingType))
			{
				return Conversion.ImplicitNullableConversion;
			}
			if (ImplicitNumericConversion(underlyingType2, underlyingType))
			{
				return Conversion.ImplicitLiftedNumericConversion;
			}
		}
		return Conversion.None;
	}

	private Conversion ExplicitNullableConversion(IType fromType, IType toType)
	{
		if (NullableType.IsNullable(toType) || NullableType.IsNullable(fromType))
		{
			IType underlyingType = NullableType.GetUnderlyingType(toType);
			IType underlyingType2 = NullableType.GetUnderlyingType(fromType);
			if (IdentityConversion(underlyingType2, underlyingType))
			{
				return Conversion.ExplicitNullableConversion;
			}
			if (AnyNumericConversion(underlyingType2, underlyingType))
			{
				return Conversion.ExplicitLiftedNumericConversion;
			}
			if (ExplicitEnumerationConversion(underlyingType2, underlyingType))
			{
				return Conversion.EnumerationConversion(isImplicit: false, isLifted: true);
			}
		}
		return Conversion.None;
	}

	private bool NullLiteralConversion(IType fromType, IType toType)
	{
		if (fromType.Kind == TypeKind.Null)
		{
			if (!NullableType.IsNullable(toType))
			{
				return toType.IsReferenceType == true;
			}
			return true;
		}
		return false;
	}

	public bool IsImplicitReferenceConversion(IType fromType, IType toType)
	{
		return ImplicitReferenceConversion(fromType, toType, 0);
	}

	private bool ImplicitReferenceConversion(IType fromType, IType toType, int subtypeCheckNestingDepth)
	{
		bool? isReferenceType = fromType.IsReferenceType;
		bool flag = true;
		if (isReferenceType == true != flag || !isReferenceType.HasValue || toType.IsReferenceType == false)
		{
			return false;
		}
		if (fromType is ArrayType arrayType)
		{
			if (toType is ArrayType arrayType2)
			{
				if (arrayType.Dimensions == arrayType2.Dimensions)
				{
					return ImplicitReferenceConversion(arrayType.ElementType, arrayType2.ElementType, subtypeCheckNestingDepth);
				}
				return false;
			}
			IType type = UnpackGenericArrayInterface(toType);
			if (arrayType.Dimensions == 1 && type != null)
			{
				if (!IdentityConversion(arrayType.ElementType, type))
				{
					return ImplicitReferenceConversion(arrayType.ElementType, type, subtypeCheckNestingDepth);
				}
				return true;
			}
			IType fromType2 = compilation.FindType(KnownTypeCode.Array);
			return ImplicitReferenceConversion(fromType2, toType, subtypeCheckNestingDepth);
		}
		return IsSubtypeOf(fromType, toType, subtypeCheckNestingDepth);
	}

	private IType UnpackGenericArrayInterface(IType interfaceType)
	{
		if (interfaceType is ParameterizedType parameterizedType)
		{
			KnownTypeCode knownTypeCode = parameterizedType.GetDefinition().KnownTypeCode;
			if (knownTypeCode == KnownTypeCode.IListOfT || knownTypeCode == KnownTypeCode.ICollectionOfT || knownTypeCode == KnownTypeCode.IEnumerableOfT || knownTypeCode == KnownTypeCode.IReadOnlyListOfT)
			{
				return parameterizedType.GetTypeArgument(0);
			}
		}
		return null;
	}

	private bool IsSubtypeOf(IType s, IType t, int subtypeCheckNestingDepth)
	{
		if (t.Kind == TypeKind.Dynamic || t.Equals(objectType))
		{
			return true;
		}
		if (subtypeCheckNestingDepth > 10)
		{
			return false;
		}
		foreach (IType allBaseType in s.GetAllBaseTypes())
		{
			if (IdentityOrVarianceConversion(allBaseType, t, subtypeCheckNestingDepth + 1))
			{
				return true;
			}
		}
		return false;
	}

	private bool IdentityOrVarianceConversion(IType s, IType t, int subtypeCheckNestingDepth)
	{
		ITypeDefinition definition = s.GetDefinition();
		if (definition != null)
		{
			if (!definition.Equals(t.GetDefinition()))
			{
				return false;
			}
			ParameterizedType parameterizedType = s as ParameterizedType;
			ParameterizedType parameterizedType2 = t as ParameterizedType;
			if (parameterizedType != null && parameterizedType2 != null)
			{
				for (int i = 0; i < definition.TypeParameters.Count; i++)
				{
					IType typeArgument = parameterizedType.GetTypeArgument(i);
					IType typeArgument2 = parameterizedType2.GetTypeArgument(i);
					if (IdentityConversion(typeArgument, typeArgument2))
					{
						continue;
					}
					ITypeParameter typeParameter = definition.TypeParameters[i];
					switch (typeParameter.Variance)
					{
					case VarianceModifier.Covariant:
						if (!ImplicitReferenceConversion(typeArgument, typeArgument2, subtypeCheckNestingDepth))
						{
							return false;
						}
						break;
					case VarianceModifier.Contravariant:
						if (!ImplicitReferenceConversion(typeArgument2, typeArgument, subtypeCheckNestingDepth))
						{
							return false;
						}
						break;
					default:
						return false;
					}
				}
			}
			else if (parameterizedType != null || parameterizedType2 != null)
			{
				return false;
			}
			return true;
		}
		return s.Equals(t);
	}

	private bool ExplicitReferenceConversion(IType fromType, IType toType)
	{
		if (toType.IsReferenceType != true)
		{
			return false;
		}
		if (fromType.IsReferenceType != true)
		{
			if (fromType.Kind == TypeKind.TypeParameter)
			{
				return IsSubtypeOf(toType, fromType, 0);
			}
			return false;
		}
		if (toType.Kind == TypeKind.Array)
		{
			ArrayType arrayType = (ArrayType)toType;
			if (fromType.Kind == TypeKind.Array)
			{
				ArrayType arrayType2 = (ArrayType)fromType;
				if (arrayType2.Dimensions != arrayType.Dimensions)
				{
					return false;
				}
				return ExplicitReferenceConversion(arrayType2.ElementType, arrayType.ElementType);
			}
			IType type = UnpackGenericArrayInterface(fromType);
			if (type != null && arrayType.Dimensions == 1)
			{
				if (!ExplicitReferenceConversion(type, arrayType.ElementType))
				{
					return IdentityConversion(type, arrayType.ElementType);
				}
				return true;
			}
			return IsImplicitReferenceConversion(toType, fromType);
		}
		if (fromType.Kind == TypeKind.Array)
		{
			ArrayType arrayType3 = (ArrayType)fromType;
			IType type2 = UnpackGenericArrayInterface(toType);
			if (type2 != null && arrayType3.Dimensions == 1)
			{
				return ExplicitReferenceConversion(arrayType3.ElementType, type2);
			}
			return IsImplicitReferenceConversion(fromType, toType);
		}
		if (fromType.Kind == TypeKind.Delegate && toType.Kind == TypeKind.Delegate)
		{
			ITypeDefinition definition = fromType.GetDefinition();
			if (definition == null || !definition.Equals(toType.GetDefinition()))
			{
				return false;
			}
			ParameterizedType parameterizedType = fromType as ParameterizedType;
			ParameterizedType parameterizedType2 = toType as ParameterizedType;
			if (parameterizedType == null || parameterizedType2 == null)
			{
				if (parameterizedType == null)
				{
					return parameterizedType2 == null;
				}
				return false;
			}
			for (int i = 0; i < definition.TypeParameters.Count; i++)
			{
				IType typeArgument = parameterizedType.GetTypeArgument(i);
				IType typeArgument2 = parameterizedType2.GetTypeArgument(i);
				if (IdentityConversion(typeArgument, typeArgument2))
				{
					continue;
				}
				ITypeParameter typeParameter = definition.TypeParameters[i];
				switch (typeParameter.Variance)
				{
				case VarianceModifier.Covariant:
					if (!ExplicitReferenceConversion(typeArgument, typeArgument2))
					{
						return false;
					}
					break;
				case VarianceModifier.Contravariant:
				{
					bool? isReferenceType = typeArgument.IsReferenceType;
					bool flag = true;
					if (isReferenceType == true != flag || !isReferenceType.HasValue || typeArgument2.IsReferenceType != true)
					{
						return false;
					}
					break;
				}
				default:
					return false;
				}
			}
			return true;
		}
		if (IsSealedReferenceType(fromType))
		{
			return IsImplicitReferenceConversion(fromType, toType);
		}
		if (IsSealedReferenceType(toType))
		{
			return IsImplicitReferenceConversion(toType, fromType);
		}
		if (fromType.Kind == TypeKind.Interface || toType.Kind == TypeKind.Interface)
		{
			return true;
		}
		if (!IsImplicitReferenceConversion(toType, fromType))
		{
			return IsImplicitReferenceConversion(fromType, toType);
		}
		return true;
	}

	private bool IsSealedReferenceType(IType type)
	{
		TypeKind kind = type.Kind;
		if ((kind != TypeKind.Class || !type.GetDefinition().IsSealed) && kind != TypeKind.Delegate)
		{
			return kind == TypeKind.Anonymous;
		}
		return true;
	}

	public bool IsBoxingConversion(IType fromType, IType toType)
	{
		fromType = NullableType.GetUnderlyingType(fromType);
		bool? isReferenceType = fromType.IsReferenceType;
		bool flag = false;
		if (isReferenceType == true == flag && isReferenceType.HasValue && toType.IsReferenceType == true)
		{
			return IsSubtypeOf(fromType, toType, 0);
		}
		return false;
	}

	private bool UnboxingConversion(IType fromType, IType toType)
	{
		toType = NullableType.GetUnderlyingType(toType);
		bool? isReferenceType = fromType.IsReferenceType;
		bool flag = true;
		if (isReferenceType == true == flag && isReferenceType.HasValue && toType.IsReferenceType == false)
		{
			return IsSubtypeOf(toType, fromType, 0);
		}
		return false;
	}

	private bool ImplicitConstantExpressionConversion(ResolveResult rr, IType toType)
	{
		if (rr == null || !rr.IsCompileTimeConstant)
		{
			return false;
		}
		TypeCode typeCode = ReflectionHelper.GetTypeCode(rr.Type);
		TypeCode typeCode2 = ReflectionHelper.GetTypeCode(NullableType.GetUnderlyingType(toType));
		switch (typeCode)
		{
		case TypeCode.Int64:
		{
			long num2 = (long)rr.ConstantValue;
			if (num2 >= 0)
			{
				return typeCode2 == TypeCode.UInt64;
			}
			return false;
		}
		case TypeCode.Int32:
		{
			object constantValue = rr.ConstantValue;
			if (constantValue == null)
			{
				return false;
			}
			int num = (int)constantValue;
			switch (typeCode2)
			{
			case TypeCode.SByte:
				if (num >= -128)
				{
					return num <= 127;
				}
				return false;
			case TypeCode.Byte:
				if (num >= 0)
				{
					return num <= 255;
				}
				return false;
			case TypeCode.Int16:
				if (num >= -32768)
				{
					return num <= 32767;
				}
				return false;
			case TypeCode.UInt16:
				if (num >= 0)
				{
					return num <= 65535;
				}
				return false;
			case TypeCode.UInt32:
				return num >= 0;
			case TypeCode.UInt64:
				return num >= 0;
			}
			break;
		}
		}
		return false;
	}

	private bool ImplicitTypeParameterConversion(IType fromType, IType toType)
	{
		if (fromType.Kind != TypeKind.TypeParameter)
		{
			return false;
		}
		if (fromType.IsReferenceType == true)
		{
			return false;
		}
		return IsSubtypeOf(fromType, toType, 0);
	}

	private Conversion ExplicitTypeParameterConversion(IType fromType, IType toType)
	{
		if (toType.Kind == TypeKind.TypeParameter)
		{
			if (fromType.Kind == TypeKind.Interface || IsSubtypeOf(toType, fromType, 0))
			{
				return Conversion.UnboxingConversion;
			}
		}
		else if (fromType.Kind == TypeKind.TypeParameter && toType.Kind == TypeKind.Interface)
		{
			return Conversion.BoxingConversion;
		}
		return Conversion.None;
	}

	private bool ImplicitPointerConversion(IType fromType, IType toType)
	{
		if (fromType is PointerType && toType is PointerType && toType.ReflectionName == "System.Void*")
		{
			return true;
		}
		if (fromType.Kind == TypeKind.Null && toType is PointerType)
		{
			return true;
		}
		return false;
	}

	private bool ExplicitPointerConversion(IType fromType, IType toType)
	{
		if (fromType.Kind == TypeKind.Pointer)
		{
			if (toType.Kind != TypeKind.Pointer)
			{
				return IsIntegerType(toType);
			}
			return true;
		}
		if (toType.Kind == TypeKind.Pointer)
		{
			return IsIntegerType(fromType);
		}
		return false;
	}

	private bool IsIntegerType(IType type)
	{
		TypeCode typeCode = ReflectionHelper.GetTypeCode(type);
		if (typeCode >= TypeCode.SByte)
		{
			return typeCode <= TypeCode.UInt64;
		}
		return false;
	}

	private bool IsEncompassedBy(IType a, IType b)
	{
		if (a.Kind != TypeKind.Interface && b.Kind != TypeKind.Interface)
		{
			return StandardImplicitConversion(a, b).IsValid;
		}
		return false;
	}

	private bool IsEncompassingOrEncompassedBy(IType a, IType b)
	{
		if (a.Kind != TypeKind.Interface && b.Kind != TypeKind.Interface)
		{
			if (!StandardImplicitConversion(a, b).IsValid)
			{
				return StandardImplicitConversion(b, a).IsValid;
			}
			return true;
		}
		return false;
	}

	private IType FindMostEncompassedType(IEnumerable<IType> candidates)
	{
		IType type = null;
		foreach (IType candidate in candidates)
		{
			if (type == null || IsEncompassedBy(candidate, type))
			{
				type = candidate;
			}
			else if (!IsEncompassedBy(type, candidate))
			{
				return null;
			}
		}
		return type;
	}

	private IType FindMostEncompassingType(IEnumerable<IType> candidates)
	{
		IType type = null;
		foreach (IType candidate in candidates)
		{
			if (type == null || IsEncompassedBy(type, candidate))
			{
				type = candidate;
			}
			else if (!IsEncompassedBy(candidate, type))
			{
				return null;
			}
		}
		return type;
	}

	private Conversion SelectOperator(IType mostSpecificSource, IType mostSpecificTarget, IList<OperatorInfo> operators, bool isImplicit, IType source, IType target)
	{
		List<OperatorInfo> list = operators.Where((OperatorInfo op) => op.SourceType.Equals(mostSpecificSource) && op.TargetType.Equals(mostSpecificTarget)).ToList();
		if (list.Count == 0)
		{
			return Conversion.None;
		}
		if (list.Count != 1)
		{
			int num = list.Count((OperatorInfo s) => !s.IsLifted);
			if (num == 1)
			{
				OperatorInfo operatorInfo = list.First((OperatorInfo s) => !s.IsLifted);
				return Conversion.UserDefinedConversion(operatorInfo.Method, isLifted: operatorInfo.IsLifted, isImplicit: isImplicit, conversionBeforeUserDefinedOperator: ExplicitConversion(source, mostSpecificSource), conversionAfterUserDefinedOperator: ExplicitConversion(mostSpecificTarget, target));
			}
			return Conversion.UserDefinedConversion(list[0].Method, isLifted: list[0].IsLifted, isImplicit: isImplicit, conversionBeforeUserDefinedOperator: ExplicitConversion(source, mostSpecificSource), conversionAfterUserDefinedOperator: ExplicitConversion(mostSpecificTarget, target), isAmbiguous: true);
		}
		return Conversion.UserDefinedConversion(list[0].Method, isLifted: list[0].IsLifted, isImplicit: isImplicit, conversionBeforeUserDefinedOperator: ExplicitConversion(source, mostSpecificSource), conversionAfterUserDefinedOperator: ExplicitConversion(mostSpecificTarget, target));
	}

	private Conversion UserDefinedImplicitConversion(ResolveResult fromResult, IType fromType, IType toType)
	{
		List<OperatorInfo> applicableConversionOperators = GetApplicableConversionOperators(fromResult, fromType, toType, isExplicit: false);
		if (applicableConversionOperators.Count > 0)
		{
			IType type = (applicableConversionOperators.Any((OperatorInfo op) => op.SourceType.Equals(fromType)) ? fromType : FindMostEncompassedType(applicableConversionOperators.Select((OperatorInfo op) => op.SourceType)));
			if (type == null)
			{
				return Conversion.UserDefinedConversion(applicableConversionOperators[0].Method, isImplicit: true, isLifted: applicableConversionOperators[0].IsLifted, conversionBeforeUserDefinedOperator: Conversion.None, conversionAfterUserDefinedOperator: Conversion.None, isAmbiguous: true);
			}
			IType type2 = (applicableConversionOperators.Any((OperatorInfo op) => op.TargetType.Equals(toType)) ? toType : FindMostEncompassingType(applicableConversionOperators.Select((OperatorInfo op) => op.TargetType)));
			if (type2 == null)
			{
				if (NullableType.IsNullable(toType))
				{
					return UserDefinedImplicitConversion(fromResult, fromType, NullableType.GetUnderlyingType(toType));
				}
				return Conversion.UserDefinedConversion(applicableConversionOperators[0].Method, isImplicit: true, isLifted: applicableConversionOperators[0].IsLifted, conversionBeforeUserDefinedOperator: Conversion.None, conversionAfterUserDefinedOperator: Conversion.None, isAmbiguous: true);
			}
			Conversion conversion = SelectOperator(type, type2, applicableConversionOperators, isImplicit: true, fromType, toType);
			if (conversion != Conversion.None)
			{
				if (conversion.IsLifted && NullableType.IsNullable(toType))
				{
					Conversion conversion2 = UserDefinedImplicitConversion(fromResult, fromType, NullableType.GetUnderlyingType(toType));
					if (conversion2 != Conversion.None)
					{
						return conversion2;
					}
				}
				return conversion;
			}
			if (NullableType.IsNullable(toType))
			{
				return UserDefinedImplicitConversion(fromResult, fromType, NullableType.GetUnderlyingType(toType));
			}
			return Conversion.None;
		}
		return Conversion.None;
	}

	private Conversion UserDefinedExplicitConversion(ResolveResult fromResult, IType fromType, IType toType)
	{
		List<OperatorInfo> applicableConversionOperators = GetApplicableConversionOperators(fromResult, fromType, toType, isExplicit: true);
		if (applicableConversionOperators.Count > 0)
		{
			IType type;
			if (applicableConversionOperators.Any((OperatorInfo op) => op.SourceType.Equals(fromType)))
			{
				type = fromType;
			}
			else
			{
				List<OperatorInfo> source = applicableConversionOperators.Where((OperatorInfo op) => IsEncompassedBy(fromType, op.SourceType) || ImplicitConstantExpressionConversion(fromResult, NullableType.GetUnderlyingType(op.SourceType))).ToList();
				type = ((!source.Any()) ? FindMostEncompassingType(applicableConversionOperators.Select((OperatorInfo op) => op.SourceType)) : FindMostEncompassedType(source.Select((OperatorInfo op) => op.SourceType)));
			}
			if (type == null)
			{
				return Conversion.UserDefinedConversion(applicableConversionOperators[0].Method, isImplicit: false, isLifted: applicableConversionOperators[0].IsLifted, conversionBeforeUserDefinedOperator: Conversion.None, conversionAfterUserDefinedOperator: Conversion.None, isAmbiguous: true);
			}
			IType type2 = (applicableConversionOperators.Any((OperatorInfo op) => op.TargetType.Equals(toType)) ? toType : ((!applicableConversionOperators.Any((OperatorInfo op) => IsEncompassedBy(op.TargetType, toType))) ? FindMostEncompassedType(applicableConversionOperators.Select((OperatorInfo op) => op.TargetType)) : FindMostEncompassingType(from op in applicableConversionOperators
				where IsEncompassedBy(op.TargetType, toType)
				select op.TargetType)));
			if (type2 == null)
			{
				if (NullableType.IsNullable(toType))
				{
					return UserDefinedExplicitConversion(fromResult, fromType, NullableType.GetUnderlyingType(toType));
				}
				return Conversion.UserDefinedConversion(applicableConversionOperators[0].Method, isImplicit: false, isLifted: applicableConversionOperators[0].IsLifted, conversionBeforeUserDefinedOperator: Conversion.None, conversionAfterUserDefinedOperator: Conversion.None, isAmbiguous: true);
			}
			Conversion conversion = SelectOperator(type, type2, applicableConversionOperators, isImplicit: false, fromType, toType);
			if (conversion != Conversion.None)
			{
				if (conversion.IsLifted && NullableType.IsNullable(toType))
				{
					Conversion conversion2 = UserDefinedImplicitConversion(fromResult, fromType, NullableType.GetUnderlyingType(toType));
					if (conversion2 != Conversion.None)
					{
						return conversion2;
					}
				}
				return conversion;
			}
			if (NullableType.IsNullable(toType))
			{
				return UserDefinedExplicitConversion(fromResult, fromType, NullableType.GetUnderlyingType(toType));
			}
			if (NullableType.IsNullable(fromType))
			{
				return UserDefinedExplicitConversion(null, NullableType.GetUnderlyingType(fromType), toType);
			}
			return Conversion.None;
		}
		return Conversion.None;
	}

	private List<OperatorInfo> GetApplicableConversionOperators(ResolveResult fromResult, IType fromType, IType toType, bool isExplicit)
	{
		Predicate<IUnresolvedMethod> filter = ((!isExplicit) ? ((Predicate<IUnresolvedMethod>)((IUnresolvedMethod m) => m.IsStatic && m.IsOperator && m.Name == "op_Implicit" && m.Parameters.Count == 1)) : ((Predicate<IUnresolvedMethod>)((IUnresolvedMethod m) => m.IsStatic && m.IsOperator && (m.Name == "op_Explicit" || m.Name == "op_Implicit") && m.Parameters.Count == 1)));
		IEnumerable<IMethod> enumerable = NullableType.GetUnderlyingType(fromType).GetMethods(filter).Concat(NullableType.GetUnderlyingType(toType).GetMethods(filter))
			.Distinct();
		List<OperatorInfo> list = new List<OperatorInfo>();
		foreach (IMethod item in enumerable)
		{
			IType type = item.Parameters[0].Type;
			IType returnType = item.ReturnType;
			if ((!isExplicit) ? ((IsEncompassedBy(fromType, type) || ImplicitConstantExpressionConversion(fromResult, type)) && IsEncompassedBy(returnType, toType)) : ((IsEncompassingOrEncompassedBy(fromType, type) || ImplicitConstantExpressionConversion(fromResult, type)) && IsEncompassingOrEncompassedBy(returnType, toType)))
			{
				list.Add(new OperatorInfo(item, type, returnType, isLifted: false));
			}
			if (NullableType.IsNonNullableValueType(type))
			{
				IType type2 = NullableType.Create(compilation, type);
				IType type3 = (NullableType.IsNonNullableValueType(returnType) ? NullableType.Create(compilation, returnType) : returnType);
				if ((!isExplicit) ? (IsEncompassedBy(fromType, type2) && IsEncompassedBy(type3, toType)) : (IsEncompassingOrEncompassedBy(fromType, type2) && IsEncompassingOrEncompassedBy(type3, toType)))
				{
					list.Add(new OperatorInfo(item, type2, type3, isLifted: true));
				}
			}
		}
		return list;
	}

	private Conversion AnonymousFunctionConversion(ResolveResult resolveResult, IType toType)
	{
		if (!(resolveResult is LambdaResolveResult lambdaResolveResult))
		{
			return Conversion.None;
		}
		if (!lambdaResolveResult.IsAnonymousMethod)
		{
			toType = UnpackExpressionTreeType(toType);
		}
		IMethod delegateInvokeMethod = toType.GetDelegateInvokeMethod();
		if (delegateInvokeMethod == null)
		{
			return Conversion.None;
		}
		IType[] array = new IType[delegateInvokeMethod.Parameters.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = delegateInvokeMethod.Parameters[i].Type;
		}
		IType returnType = delegateInvokeMethod.ReturnType;
		if (lambdaResolveResult.HasParameterList)
		{
			if (delegateInvokeMethod.Parameters.Count != lambdaResolveResult.Parameters.Count)
			{
				return Conversion.None;
			}
			if (lambdaResolveResult.IsImplicitlyTyped)
			{
				foreach (IParameter parameter3 in delegateInvokeMethod.Parameters)
				{
					if (parameter3.IsIn || parameter3.IsOut || parameter3.IsRef)
					{
						return Conversion.None;
					}
				}
			}
			else
			{
				for (int j = 0; j < lambdaResolveResult.Parameters.Count; j++)
				{
					IParameter parameter = delegateInvokeMethod.Parameters[j];
					IParameter parameter2 = lambdaResolveResult.Parameters[j];
					if (parameter.IsIn != parameter2.IsIn || parameter.IsRef != parameter2.IsRef || parameter.IsOut != parameter2.IsOut)
					{
						return Conversion.None;
					}
					if (!IdentityConversion(array[j], parameter2.Type))
					{
						return Conversion.None;
					}
				}
			}
		}
		else
		{
			foreach (IParameter parameter4 in delegateInvokeMethod.Parameters)
			{
				if (parameter4.IsOut)
				{
					return Conversion.None;
				}
			}
		}
		return lambdaResolveResult.IsValid(array, returnType, this);
	}

	private static IType UnpackExpressionTreeType(IType type)
	{
		if (type is ParameterizedType { TypeParameterCount: 1, Name: "Expression", Namespace: "System.Linq.Expressions" } parameterizedType)
		{
			return parameterizedType.GetTypeArgument(0);
		}
		return type;
	}

	private Conversion MethodGroupConversion(ResolveResult resolveResult, IType toType)
	{
		if (!(resolveResult is MethodGroupResolveResult methodGroupResolveResult))
		{
			return Conversion.None;
		}
		IMethod delegateInvokeMethod = toType.GetDelegateInvokeMethod();
		if (delegateInvokeMethod == null)
		{
			return Conversion.None;
		}
		ResolveResult[] array = new ResolveResult[delegateInvokeMethod.Parameters.Count];
		for (int i = 0; i < array.Length; i++)
		{
			IParameter parameter = delegateInvokeMethod.Parameters[i];
			IType type = parameter.Type;
			if ((parameter.IsIn || parameter.IsRef || parameter.IsOut) && type.Kind == TypeKind.ByReference)
			{
				type = ((ByReferenceType)type).ElementType;
				array[i] = new ByReferenceResolveResult(type, parameter.IsIn, parameter.IsRef, parameter.IsOut);
			}
			else
			{
				array[i] = new ResolveResult(type);
			}
		}
		OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(compilation, array, null, allowExtensionMethods: true, allowExpandingParams: false, allowOptionalParameters: false, checkForOverflow: false, this);
		if (overloadResolution.FoundApplicableCandidate)
		{
			IMethod method = (IMethod)overloadResolution.GetBestCandidateWithSubstitutedTypeArguments();
			ThisResolveResult thisResolveResult = methodGroupResolveResult.TargetResult as ThisResolveResult;
			bool isVirtualMethodLookup = method.IsOverridable && (thisResolveResult == null || !thisResolveResult.CausesNonVirtualInvocation);
			bool flag = !overloadResolution.IsAmbiguous && IsDelegateCompatible(method, delegateInvokeMethod, overloadResolution.IsExtensionMethodInvocation);
			bool delegateCapturesFirstArgument = overloadResolution.IsExtensionMethodInvocation || !method.IsStatic;
			if (flag)
			{
				return Conversion.MethodGroupConversion(method, isVirtualMethodLookup, delegateCapturesFirstArgument);
			}
			return Conversion.InvalidMethodGroupConversion(method, isVirtualMethodLookup, delegateCapturesFirstArgument);
		}
		return Conversion.None;
	}

	public bool IsDelegateCompatible(IMethod method, IType delegateType)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		if (delegateType == null)
		{
			throw new ArgumentNullException("delegateType");
		}
		IMethod delegateInvokeMethod = delegateType.GetDelegateInvokeMethod();
		if (delegateInvokeMethod == null)
		{
			return false;
		}
		return IsDelegateCompatible(method, delegateInvokeMethod, isExtensionMethodInvocation: false);
	}

	private bool IsDelegateCompatible(IMethod m, IMethod invoke, bool isExtensionMethodInvocation)
	{
		if (m == null)
		{
			throw new ArgumentNullException("m");
		}
		if (invoke == null)
		{
			throw new ArgumentNullException("invoke");
		}
		int num = (isExtensionMethodInvocation ? 1 : 0);
		if (m.Parameters.Count - num != invoke.Parameters.Count)
		{
			return false;
		}
		for (int i = 0; i < invoke.Parameters.Count; i++)
		{
			IParameter parameter = m.Parameters[num + i];
			IParameter parameter2 = invoke.Parameters[i];
			if (parameter.IsIn != parameter2.IsIn || parameter.IsRef != parameter2.IsRef || parameter.IsOut != parameter2.IsOut)
			{
				return false;
			}
			if (parameter.IsIn || parameter.IsRef || parameter.IsOut)
			{
				if (!parameter.Type.Equals(parameter2.Type))
				{
					return false;
				}
			}
			else if (!IdentityConversion(parameter2.Type, parameter.Type) && !IsImplicitReferenceConversion(parameter2.Type, parameter.Type))
			{
				return false;
			}
		}
		if (!IdentityConversion(m.ReturnType, invoke.ReturnType))
		{
			return IsImplicitReferenceConversion(m.ReturnType, invoke.ReturnType);
		}
		return true;
	}

	public int BetterConversion(ResolveResult resolveResult, IType t1, IType t2)
	{
		if (resolveResult is LambdaResolveResult lambdaResolveResult)
		{
			if (!lambdaResolveResult.IsAnonymousMethod)
			{
				t1 = UnpackExpressionTreeType(t1);
				t2 = UnpackExpressionTreeType(t2);
			}
			IMethod delegateInvokeMethod = t1.GetDelegateInvokeMethod();
			IMethod delegateInvokeMethod2 = t2.GetDelegateInvokeMethod();
			if (delegateInvokeMethod == null || delegateInvokeMethod2 == null)
			{
				return 0;
			}
			if (delegateInvokeMethod.Parameters.Count != delegateInvokeMethod2.Parameters.Count)
			{
				return 0;
			}
			IType[] array = new IType[delegateInvokeMethod.Parameters.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = delegateInvokeMethod.Parameters[i].Type;
				if (!array[i].Equals(delegateInvokeMethod2.Parameters[i].Type))
				{
					return 0;
				}
			}
			if (lambdaResolveResult.HasParameterList && array.Length != lambdaResolveResult.Parameters.Count)
			{
				return 0;
			}
			IType returnType = delegateInvokeMethod.ReturnType;
			IType returnType2 = delegateInvokeMethod2.ReturnType;
			if (returnType.Kind == TypeKind.Void && returnType2.Kind != TypeKind.Void)
			{
				return 2;
			}
			if (returnType.Kind != TypeKind.Void && returnType2.Kind == TypeKind.Void)
			{
				return 1;
			}
			IType inferredReturnType = lambdaResolveResult.GetInferredReturnType(array);
			int num = BetterConversion(inferredReturnType, returnType, returnType2);
			if (num == 0 && lambdaResolveResult.IsAsync)
			{
				returnType = UnpackTask(returnType);
				returnType2 = UnpackTask(returnType2);
				inferredReturnType = UnpackTask(inferredReturnType);
				if (returnType != null && returnType2 != null && inferredReturnType != null)
				{
					num = BetterConversion(inferredReturnType, returnType, returnType2);
				}
			}
			return num;
		}
		return BetterConversion(resolveResult.Type, t1, t2);
	}

	private static IType UnpackTask(IType type)
	{
		if (type is ParameterizedType { TypeParameterCount: 1, Name: "Task", Namespace: "System.Threading.Tasks" } parameterizedType)
		{
			return parameterizedType.GetTypeArgument(0);
		}
		return null;
	}

	public int BetterConversion(IType s, IType t1, IType t2)
	{
		bool flag = IdentityConversion(s, t1);
		bool flag2 = IdentityConversion(s, t2);
		if (flag && !flag2)
		{
			return 1;
		}
		if (flag2 && !flag)
		{
			return 2;
		}
		return BetterConversionTarget(t1, t2);
	}

	private int BetterConversionTarget(IType t1, IType t2)
	{
		bool isValid = ImplicitConversion(t1, t2).IsValid;
		bool isValid2 = ImplicitConversion(t2, t1).IsValid;
		if (isValid && !isValid2)
		{
			return 1;
		}
		if (isValid2 && !isValid)
		{
			return 2;
		}
		TypeCode typeCode = ReflectionHelper.GetTypeCode(t1);
		TypeCode typeCode2 = ReflectionHelper.GetTypeCode(t2);
		if (IsBetterIntegralType(typeCode, typeCode2))
		{
			return 1;
		}
		if (IsBetterIntegralType(typeCode2, typeCode))
		{
			return 2;
		}
		return 0;
	}

	private bool IsBetterIntegralType(TypeCode t1, TypeCode t2)
	{
		switch (t1)
		{
		case TypeCode.SByte:
			if (t2 != TypeCode.Byte && t2 != TypeCode.UInt16 && t2 != TypeCode.UInt32)
			{
				return t2 == TypeCode.UInt64;
			}
			return true;
		case TypeCode.Int16:
			if (t2 != TypeCode.UInt16 && t2 != TypeCode.UInt32)
			{
				return t2 == TypeCode.UInt64;
			}
			return true;
		case TypeCode.Int32:
			if (t2 != TypeCode.UInt32)
			{
				return t2 == TypeCode.UInt64;
			}
			return true;
		case TypeCode.Int64:
			return t2 == TypeCode.UInt64;
		default:
			return false;
		}
	}
}
