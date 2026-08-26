using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler;

internal static class DnlibExtensions
{
	private static readonly UTF8String systemRuntimeCompilerServicesString = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String compilerGeneratedAttributeString = new UTF8String("CompilerGeneratedAttribute");

	private static readonly UTF8String systemString = new UTF8String("System");

	private static readonly UTF8String booleanString = new UTF8String("Boolean");

	private static readonly UTF8String objectString = new UTF8String("Object");

	private static readonly UTF8String nullableString = new UTF8String("Nullable`1");

	private static readonly UTF8String isReadOnlyAttributeString = new UTF8String("IsReadOnlyAttribute");

	private static readonly UTF8String isByRefLikeAttributeString = new UTF8String("IsByRefLikeAttribute");

	public static IEnumerable<TypeDef> GetNestedTypes(this TypeDef type, bool sortMembers)
	{
		if (!sortMembers)
		{
			return type.NestedTypes;
		}
		TypeDef[] array = type.NestedTypes.ToArray();
		Array.Sort(array, TypeDefComparer.Instance);
		return array;
	}

	public static IEnumerable<FieldDef> GetFields(this TypeDef type, bool sortMembers)
	{
		if (!sortMembers || !type.CanSortFields())
		{
			return type.Fields;
		}
		FieldDef[] array = type.Fields.ToArray();
		Array.Sort(array, FieldDefComparer.Instance);
		return array;
	}

	public static IEnumerable<EventDef> GetEvents(this TypeDef type, bool sortMembers)
	{
		if (!sortMembers || !type.CanSortMethods())
		{
			return type.Events;
		}
		EventDef[] array = type.Events.ToArray();
		Array.Sort(array, EventDefComparer.Instance);
		return array;
	}

	public static IEnumerable<PropertyDef> GetProperties(this TypeDef type, bool sortMembers)
	{
		if (!sortMembers || !type.CanSortMethods())
		{
			return type.Properties;
		}
		PropertyDef[] array = type.Properties.ToArray();
		Array.Sort(array, PropertyDefComparer.Instance);
		return array;
	}

	public static IEnumerable<MethodDef> GetMethods(this TypeDef type, bool sortMembers)
	{
		if (!sortMembers || !type.CanSortMethods())
		{
			return type.Methods;
		}
		MethodDef[] array = type.Methods.ToArray();
		Array.Sort(array, MethodDefComparer.Instance);
		return array;
	}

	public static int GetPushDelta(this Instruction instruction, MethodDef methodDef)
	{
		instruction.CalculateStackUsage(methodDef.HasReturnType, out var pushes, out var _);
		return pushes;
	}

	public static int GetPopDelta(this Instruction instruction, MethodDef methodDef)
	{
		instruction.CalculateStackUsage(methodDef.HasReturnType, out var _, out var pops);
		return pops;
	}

	public static bool IsSignedIntegralType(this TypeSig type)
	{
		if (type == null)
		{
			return false;
		}
		if (type.ElementType != ElementType.I1 && type.ElementType != ElementType.I2 && type.ElementType != ElementType.I4 && type.ElementType != ElementType.I8)
		{
			return type.ElementType == ElementType.I;
		}
		return true;
	}

	public static bool IsZero(this object value)
	{
		if (value == null)
		{
			return false;
		}
		Type type = value.GetType();
		switch (Type.GetTypeCode(type))
		{
		case TypeCode.Empty:
			return false;
		case TypeCode.DBNull:
			return false;
		case TypeCode.Boolean:
			return false;
		case TypeCode.Char:
			return (char)value == '\0';
		case TypeCode.SByte:
			return (sbyte)value == 0;
		case TypeCode.Byte:
			return (byte)value == 0;
		case TypeCode.Int16:
			return (short)value == 0;
		case TypeCode.UInt16:
			return (ushort)value == 0;
		case TypeCode.Int32:
			return (int)value == 0;
		case TypeCode.UInt32:
			return (uint)value == 0;
		case TypeCode.Int64:
			return (long)value == 0;
		case TypeCode.UInt64:
			return (ulong)value == 0;
		case TypeCode.Single:
			return (float)value == 0f;
		case TypeCode.Double:
			return (double)value == 0.0;
		case TypeCode.Decimal:
			return (decimal)value == 0m;
		case TypeCode.DateTime:
			return false;
		case TypeCode.String:
			return false;
		default:
			return false;
		case TypeCode.Object:
		{
			IntPtr? intPtr = value as IntPtr?;
			if (intPtr.HasValue)
			{
				return intPtr.Value == IntPtr.Zero;
			}
			UIntPtr? uIntPtr = value as UIntPtr?;
			if (uIntPtr.HasValue)
			{
				return uIntPtr.Value == UIntPtr.Zero;
			}
			return false;
		}
		}
	}

	public static int GetEndOffset(this Instruction inst)
	{
		if (inst == null)
		{
			return 0;
		}
		return (int)inst.Offset + inst.GetSize();
	}

	public static string OffsetToString(uint offset)
	{
		return $"IL_{offset:X4}";
	}

	public static TypeDef ResolveWithinSameModule(this ITypeDefOrRef type)
	{
		if (type != null && type.Scope == type.Module)
		{
			return type.ResolveTypeDef();
		}
		return null;
	}

	public static FieldDef ResolveFieldWithinSameModule(this MemberRef field)
	{
		if (field != null && field.DeclaringType != null && field.DeclaringType.Scope == field.Module)
		{
			return field.ResolveField();
		}
		return null;
	}

	public static FieldDef ResolveFieldWithinSameModule(this IField field)
	{
		if (field != null && field.DeclaringType != null && field.DeclaringType.Scope == field.Module)
		{
			if (!(field is FieldDef))
			{
				return ((MemberRef)field).ResolveField();
			}
			return (FieldDef)field;
		}
		return null;
	}

	public static MethodDef ResolveMethodWithinSameModule(this IMethod method)
	{
		if (method is MethodSpec)
		{
			method = ((MethodSpec)method).Method;
		}
		if (method != null && method.DeclaringType != null && method.DeclaringType.Scope == method.Module)
		{
			if (!(method is MethodDef))
			{
				return ((MemberRef)method).ResolveMethod();
			}
			return (MethodDef)method;
		}
		return null;
	}

	public static MethodDef Resolve(this IMethod method)
	{
		if (method is MethodSpec)
		{
			method = ((MethodSpec)method).Method;
		}
		if (method is MemberRef)
		{
			return ((MemberRef)method).ResolveMethod();
		}
		return (MethodDef)method;
	}

	public static FieldDef Resolve(this IField field)
	{
		if (field is MemberRef)
		{
			return ((MemberRef)field).ResolveField();
		}
		return (FieldDef)field;
	}

	public static TypeDef Resolve(this IType type)
	{
		return type?.ScopeType.ResolveTypeDef();
	}

	public static bool IsCompilerGenerated(this IHasCustomAttribute provider)
	{
		return provider.IsDefined(systemRuntimeCompilerServicesString, compilerGeneratedAttributeString);
	}

	public static bool IsCompilerGeneratedOrIsInCompilerGeneratedClass(this IMemberDef member)
	{
		for (int i = 0; i < 50; i++)
		{
			if (member == null)
			{
				break;
			}
			if (member.IsCompilerGenerated())
			{
				return true;
			}
			member = member.DeclaringType;
		}
		return false;
	}

	public static bool IsDynamicCallSiteContainerType(this ITypeDefOrRef type)
	{
		if (type == null)
		{
			return false;
		}
		if (!(type.Name == "<>o"))
		{
			return type.Name.StartsWith("<>o__");
		}
		return true;
	}

	public static bool IsAnonymousType(this ITypeDefOrRef type)
	{
		if (type == null)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(type.GetNamespaceInternal()))
		{
			return false;
		}
		string text = type.Name;
		if (text.StartsWith("VB$AnonymousType_") || (type.HasGeneratedName() && (text.Contains("AnonType") || text.Contains("AnonymousType"))))
		{
			return type.ResolveTypeDef()?.IsCompilerGenerated() ?? false;
		}
		return false;
	}

	public static bool HasGeneratedName(this IMemberRef member)
	{
		if (member == null)
		{
			return false;
		}
		UTF8String name = member.Name;
		if ((object)name != null && name.Data != null && name.Data.Length != 0)
		{
			if (name.Data[0] != 60)
			{
				if (name.Data[0] == 36)
				{
					return name.StartsWith("$VB", StringComparison.Ordinal);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool IsLocalFunction(this MethodDef method)
	{
		string text = method.Name.String;
		if (text.StartsWith("<"))
		{
			return text.Contains(">g__");
		}
		return false;
	}

	public static bool ContainsAnonymousType(this TypeSig type)
	{
		return type.ContainsAnonymousType(0);
	}

	private static bool ContainsAnonymousType(this TypeSig type, int depth)
	{
		if (depth >= 30)
		{
			return false;
		}
		if (type is GenericInstSig { GenericType: not null } genericInstSig)
		{
			if (genericInstSig.GenericType.TypeDefOrRef.IsAnonymousType())
			{
				return true;
			}
			for (int i = 0; i < genericInstSig.GenericArguments.Count; i++)
			{
				if (genericInstSig.GenericArguments[i].ContainsAnonymousType(depth + 1))
				{
					return true;
				}
			}
			return false;
		}
		if (type != null && type.Next != null)
		{
			return type.Next.ContainsAnonymousType(depth + 1);
		}
		return false;
	}

	public static string GetDefaultMemberName(this TypeDef type, out CustomAttribute defaultMemberAttribute)
	{
		if (type != null && type.HasCustomAttributes)
		{
			foreach (CustomAttribute item in type.CustomAttributes.FindAll("System.Reflection.DefaultMemberAttribute"))
			{
				if (item.Constructor != null && item.Constructor.FullName == "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)" && item.ConstructorArguments.Count == 1 && item.ConstructorArguments[0].Value is UTF8String)
				{
					defaultMemberAttribute = item;
					return (UTF8String)item.ConstructorArguments[0].Value;
				}
			}
		}
		defaultMemberAttribute = null;
		return null;
	}

	public static bool IsIndexer(this PropertyDef property)
	{
		CustomAttribute defaultMemberAttribute;
		return property.IsIndexer(out defaultMemberAttribute);
	}

	private static bool IsIndexer(this PropertyDef property, out CustomAttribute defaultMemberAttribute)
	{
		defaultMemberAttribute = null;
		if (property != null && property.PropertySig.GetParamCount() > 0)
		{
			MethodDef methodDef = property.GetMethod ?? property.SetMethod;
			PropertyDef propertyDef = property;
			if (methodDef != null && methodDef.HasOverrides)
			{
				MethodDef methodDef2 = methodDef.Overrides.First().MethodDeclaration.Resolve();
				if (methodDef2 == null)
				{
					return false;
				}
				foreach (PropertyDef property2 in methodDef2.DeclaringType.Properties)
				{
					if (property2.GetMethod == methodDef2 || property2.SetMethod == methodDef2)
					{
						propertyDef = property2;
						break;
					}
				}
			}
			string defaultMemberName = propertyDef.DeclaringType.GetDefaultMemberName(out var defaultMemberAttribute2);
			if (defaultMemberName == propertyDef.Name)
			{
				defaultMemberAttribute = defaultMemberAttribute2;
				return true;
			}
		}
		return false;
	}

	public static Instruction GetPrevious(this CilBody body, Instruction instr)
	{
		int num = body.Instructions.IndexOf(instr);
		if (num <= 0)
		{
			return null;
		}
		return body.Instructions[num - 1];
	}

	public static IList<TypeSig> GetParameters(this MethodBaseSig methodSig)
	{
		if (methodSig == null)
		{
			return new List<TypeSig>();
		}
		if (methodSig.ParamsAfterSentinel != null)
		{
			return methodSig.Params.Concat(new TypeSig[1]
			{
				new SentinelSig()
			}).Concat(methodSig.ParamsAfterSentinel).ToList();
		}
		return methodSig.Params;
	}

	public static ITypeDefOrRef GetTypeDefOrRef(this TypeSig type)
	{
		type = type.RemovePinnedAndModifiers();
		if (type == null)
		{
			return null;
		}
		if (type.IsGenericInstanceType)
		{
			return ((GenericInstSig)type).GenericType?.TypeDefOrRef;
		}
		if (type.IsTypeDefOrRef)
		{
			return ((TypeDefOrRefSig)type).TypeDefOrRef;
		}
		return null;
	}

	public static bool IsSystemBoolean(this ITypeDefOrRef type)
	{
		if (type == null)
		{
			return false;
		}
		if (!type.DefinitionAssembly.IsCorLib())
		{
			return false;
		}
		if (type is TypeRef typeRef)
		{
			if (typeRef.Namespace == systemString)
			{
				return typeRef.Name == booleanString;
			}
			return false;
		}
		if (type is TypeDef typeDef)
		{
			if (typeDef.Namespace == systemString)
			{
				return typeDef.Name == booleanString;
			}
			return false;
		}
		return false;
	}

	public static bool IsSystemObject(this ITypeDefOrRef type)
	{
		if (type == null)
		{
			return false;
		}
		if (!type.DefinitionAssembly.IsCorLib())
		{
			return false;
		}
		if (type is TypeRef typeRef)
		{
			if (typeRef.Namespace == systemString)
			{
				return typeRef.Name == objectString;
			}
			return false;
		}
		if (type is TypeDef typeDef)
		{
			if (typeDef.Namespace == systemString)
			{
				return typeDef.Name == objectString;
			}
			return false;
		}
		return false;
	}

	public static IEnumerable<Parameter> GetParameters(this PropertyDef property)
	{
		if (property == null)
		{
			yield break;
		}
		if (property.GetMethod != null)
		{
			foreach (Parameter parameter in property.GetMethod.Parameters)
			{
				yield return parameter;
			}
			yield break;
		}
		if (property.SetMethod != null)
		{
			int last = property.SetMethod.Parameters.Count - 1;
			foreach (Parameter parameter2 in property.SetMethod.Parameters)
			{
				if (parameter2.Index != last)
				{
					yield return parameter2;
				}
			}
			yield break;
		}
		int i = 0;
		foreach (TypeSig parameter3 in property.PropertySig.GetParameters())
		{
			yield return new Parameter(i, i, parameter3);
			i++;
		}
	}

	public static string GetScopeName(this IScope scope)
	{
		if (scope == null)
		{
			return string.Empty;
		}
		if (scope is IFullName)
		{
			return ((IFullName)scope).Name;
		}
		return scope.ScopeName;
	}

	public static int GetParametersSkip(this IList<Parameter> parameters)
	{
		if (parameters == null || parameters.Count == 0)
		{
			return 0;
		}
		if (parameters[0].IsHiddenThisParameter)
		{
			return 1;
		}
		return 0;
	}

	public static IEnumerable<Parameter> SkipNonNormal(this IList<Parameter> parameters)
	{
		if (parameters == null)
		{
			yield break;
		}
		foreach (Parameter parameter in parameters)
		{
			if (parameter.IsNormalMethodParameter)
			{
				yield return parameter;
			}
		}
	}

	public static int GetNumberOfNormalParameters(this IList<Parameter> parameters)
	{
		if (parameters == null)
		{
			return 0;
		}
		return parameters.Count - parameters.GetParametersSkip();
	}

	public static IEnumerable<int> GetLengths(this ArraySigBase ary)
	{
		IList<uint> sizes = ary.GetSizes();
		for (int i = 0; i < (int)ary.Rank; i++)
		{
			yield return (int)((i < sizes.Count) ? (sizes[i] - 1) : 0);
		}
	}

	public static string GetFnPtrFullName(FnPtrSig sig)
	{
		if (sig == null)
		{
			return string.Empty;
		}
		MethodSig methodSig = sig.MethodSig;
		if (methodSig == null)
		{
			return GetFnPtrName(sig);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("method ");
		FullNameFactory.FullNameSB(methodSig.RetType, isReflection: false, null, null, null, stringBuilder);
		stringBuilder.Append(" *(");
		PrintArgs(stringBuilder, methodSig.Params, isFirst: true);
		if (methodSig.ParamsAfterSentinel != null)
		{
			if (methodSig.Params.Count > 0)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append("...,");
			PrintArgs(stringBuilder, methodSig.ParamsAfterSentinel, isFirst: false);
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}

	public static string GetMethodSigFullName(MethodSig methodSig)
	{
		if (methodSig == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		FullNameFactory.FullNameSB(methodSig.RetType, isReflection: false, null, null, null, stringBuilder);
		stringBuilder.Append("(");
		PrintArgs(stringBuilder, methodSig.Params, isFirst: true);
		if (methodSig.ParamsAfterSentinel != null)
		{
			if (methodSig.Params.Count > 0)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append("...,");
			PrintArgs(stringBuilder, methodSig.ParamsAfterSentinel, isFirst: false);
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}

	private static void PrintArgs(StringBuilder sb, IList<TypeSig> args, bool isFirst)
	{
		foreach (TypeSig arg in args)
		{
			if (!isFirst)
			{
				sb.Append(",");
			}
			isFirst = false;
			FullNameFactory.FullNameSB(arg, isReflection: false, null, null, null, sb);
		}
	}

	public static string GetFnPtrName(FnPtrSig sig)
	{
		return "method";
	}

	public static bool IsValueType(ITypeDefOrRef tdr)
	{
		if (tdr == null)
		{
			return false;
		}
		if (tdr is TypeSpec typeSpec)
		{
			return IsValueType(typeSpec.TypeSig);
		}
		return tdr.IsValueType;
	}

	public static bool IsValueType(TypeSig ts)
	{
		return ts?.IsValueType ?? false;
	}

	private static string GetNamespaceInternal(this ITypeDefOrRef tdr)
	{
		if (tdr is TypeRef typeRef)
		{
			return typeRef.Namespace;
		}
		if (tdr is TypeDef typeDef)
		{
			return typeDef.Namespace;
		}
		return tdr.Namespace;
	}

	public static string GetNamespace(this IType type, StringBuilder sb)
	{
		if (type is TypeDef typeDef)
		{
			return typeDef.Namespace;
		}
		if (type is TypeRef typeRef)
		{
			return typeRef.Namespace;
		}
		sb.Length = 0;
		return FullNameFactory.Namespace(type, isReflection: false, sb);
	}

	public static string GetName(this IType type, StringBuilder sb)
	{
		if (type is TypeDef typeDef)
		{
			return typeDef.Name;
		}
		if (type is TypeRef typeRef)
		{
			return typeRef.Name;
		}
		sb.Length = 0;
		return FullNameFactory.Name(type, isReflection: false, sb);
	}

	public static bool Compare(this ITypeDefOrRef type, UTF8String expNs, UTF8String expName)
	{
		if (type == null)
		{
			return false;
		}
		if (type is TypeRef typeRef)
		{
			if (typeRef.Namespace == expNs)
			{
				return typeRef.Name == expName;
			}
			return false;
		}
		if (type is TypeDef typeDef)
		{
			if (typeDef.Namespace == expNs)
			{
				return typeDef.Name == expName;
			}
			return false;
		}
		return false;
	}

	public static bool IsSystemNullable(this ClassOrValueTypeSig sig)
	{
		if (sig is ValueTypeSig)
		{
			return sig.TypeDefOrRef.Compare(systemString, nullableString);
		}
		return false;
	}

	public static bool HasIsReadOnlyAttribute(IHasCustomAttribute hca)
	{
		if (hca == null)
		{
			return false;
		}
		foreach (CustomAttribute customAttribute in hca.CustomAttributes)
		{
			if (customAttribute.AttributeType.Compare(systemRuntimeCompilerServicesString, isReadOnlyAttributeString))
			{
				return true;
			}
		}
		return false;
	}

	public static bool HasIsByRefLikeAttribute(IHasCustomAttribute hca)
	{
		if (hca == null)
		{
			return false;
		}
		foreach (CustomAttribute customAttribute in hca.CustomAttributes)
		{
			if (customAttribute.AttributeType.Compare(systemRuntimeCompilerServicesString, isByRefLikeAttributeString))
			{
				return true;
			}
		}
		return false;
	}
}
