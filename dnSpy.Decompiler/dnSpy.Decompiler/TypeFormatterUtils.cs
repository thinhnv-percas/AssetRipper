#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler;

internal static class TypeFormatterUtils
{
	public const int DigitGroupSizeHex = 4;

	public const int DigitGroupSizeDecimal = 3;

	public const string DigitSeparator = "_";

	public const string NaN = "NaN";

	public const string NegativeInfinity = "-Infinity";

	public const string PositiveInfinity = "Infinity";

	public const int MAX_RECURSION = 200;

	public const int MAX_OUTPUT_LEN = 4096;

	private static readonly UTF8String ByRefLikeMarker = new UTF8String("Types with embedded references are not supported in this version of your compiler.");

	private static readonly UTF8String stringSystem_Threading_Tasks = new UTF8String("System.Threading.Tasks");

	private static readonly UTF8String stringTask = new UTF8String("Task");

	private static readonly UTF8String stringTask_1 = new UTF8String("Task`1");

	public static string ToFormattedNumber(bool digitSeparators, string prefix, string number, int digitGroupSize)
	{
		if (digitSeparators)
		{
			number = AddDigitSeparators(number, digitGroupSize, "_");
		}
		string text = number;
		if (prefix.Length != 0)
		{
			text = prefix + text;
		}
		return text;
	}

	private static string AddDigitSeparators(string number, int digitGroupSize, string digitSeparator)
	{
		if (number.Length <= digitGroupSize)
		{
			return number;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < number.Length; i++)
		{
			int num = number.Length - i;
			if (i != 0 && num % digitGroupSize == 0 && number[i - 1] != '-')
			{
				stringBuilder.Append("_");
			}
			stringBuilder.Append(number[i]);
		}
		return stringBuilder.ToString();
	}

	public static string FilterName(string s)
	{
		if (s == null)
		{
			return "<<NULL>>";
		}
		StringBuilder stringBuilder = new StringBuilder(s.Length);
		foreach (char c in s)
		{
			if (stringBuilder.Length >= 256)
			{
				break;
			}
			if (c >= ' ')
			{
				stringBuilder.Append(c);
			}
			else
			{
				stringBuilder.Append($"\\u{(ushort)c:X4}");
			}
		}
		if (stringBuilder.Length > 256)
		{
			stringBuilder.Length = 256;
		}
		return stringBuilder.ToString();
	}

	public static string RemoveGenericTick(string s)
	{
		int num = s.LastIndexOf('`');
		if (num < 0)
		{
			return s;
		}
		if (s[0] == '<')
		{
			return s;
		}
		return s.Substring(0, num);
	}

	public static string GetFileName(string s)
	{
		int num = Math.Max(s.LastIndexOf('/'), s.LastIndexOf('\\'));
		if (num < 0)
		{
			return s;
		}
		return s.Substring(num + 1);
	}

	public static string GetNumberOfOverloadsString(TypeDef type, string name)
	{
		int numberOfOverloads = GetNumberOfOverloads(type, name);
		if (numberOfOverloads == 1)
		{
			return $" (+ {dnSpy_Decompiler_Resources.ToolTip_OneMethodOverload})";
		}
		if (numberOfOverloads > 1)
		{
			return $" (+ {string.Format(dnSpy_Decompiler_Resources.ToolTip_NMethodOverloads, numberOfOverloads)})";
		}
		return null;
	}

	private static int GetNumberOfOverloads(TypeDef type, string name)
	{
		HashSet<MethodDef> hashSet = new HashSet<MethodDef>(MethodEqualityComparer.DontCompareDeclaringTypes);
		while (type != null)
		{
			foreach (MethodDef method in type.Methods)
			{
				if (method.Name == name)
				{
					hashSet.Add(method);
				}
			}
			type = type.BaseType.ResolveTypeDef();
		}
		return hashSet.Count - 1;
	}

	public static string GetPropertyName(IMethod method)
	{
		if (method == null)
		{
			return null;
		}
		UTF8String name = method.Name;
		if (name.StartsWith("get_", StringComparison.Ordinal) || name.StartsWith("set_", StringComparison.Ordinal))
		{
			return name.Substring(4);
		}
		return null;
	}

	public static string GetName(ISourceVariable variable)
	{
		string name = variable.Name;
		if (!string.IsNullOrWhiteSpace(name))
		{
			return name;
		}
		if (variable.Variable != null)
		{
			if (variable.IsLocal)
			{
				return "V_" + variable.Variable.Index;
			}
			return "A_" + variable.Variable.Index;
		}
		Debug.Fail("Decompiler generated variable without a name");
		return "???";
	}

	public static bool IsSystemNullable(GenericInstSig gis)
	{
		return gis.GenericType is ValueTypeSig { TypeDefOrRef: not null } valueTypeSig && valueTypeSig.TypeDefOrRef.DefinitionAssembly.IsCorLib() && valueTypeSig.TypeDefOrRef.FullName == "System.Nullable`1";
	}

	public static bool IsSystemValueTuple(GenericInstSig gis)
	{
		return GetSystemValueTupleRank(gis) >= 0;
	}

	private static int GetSystemValueTupleRank(GenericInstSig gis)
	{
		int num = 0;
		for (int i = 0; i < 1000; i++)
		{
			int valueTupleSimpleRank = GetValueTupleSimpleRank(gis);
			if (valueTupleSimpleRank < 0)
			{
				return -1;
			}
			if (num < 8)
			{
				return num + valueTupleSimpleRank;
			}
			num += valueTupleSimpleRank - 1;
			gis = gis.GenericArguments[valueTupleSimpleRank - 1] as GenericInstSig;
			if (gis == null)
			{
				return -1;
			}
		}
		return -1;
	}

	private static int GetValueTupleSimpleRank(GenericInstSig gis)
	{
		if (!(gis.GenericType is ValueTypeSig valueTypeSig))
		{
			return -1;
		}
		if (valueTypeSig.TypeDefOrRef == null)
		{
			return -1;
		}
		if (valueTypeSig.Namespace != "System")
		{
			return -1;
		}
		int num;
		switch (valueTypeSig.TypeDefOrRef.Name.String)
		{
		case "ValueTuple`1":
			num = 1;
			break;
		case "ValueTuple`2":
			num = 2;
			break;
		case "ValueTuple`3":
			num = 3;
			break;
		case "ValueTuple`4":
			num = 4;
			break;
		case "ValueTuple`5":
			num = 5;
			break;
		case "ValueTuple`6":
			num = 6;
			break;
		case "ValueTuple`7":
			num = 7;
			break;
		case "ValueTuple`8":
			num = 8;
			break;
		default:
			return -1;
		}
		if (gis.GenericArguments.Count != num)
		{
			return -1;
		}
		return num;
	}

	public static bool IsDelegate(TypeDef td)
	{
		return td != null && default(SigComparer).Equals(td.BaseType, td.Module.CorLibTypes.GetTypeRef("System", "MulticastDelegate")) && td.BaseType.DefinitionAssembly.IsCorLib();
	}

	public static (PropertyDef property, AccessorKind kind) TryGetProperty(MethodDef method)
	{
		if (method == null)
		{
			return (property: null, kind: AccessorKind.None);
		}
		foreach (PropertyDef property in method.DeclaringType.Properties)
		{
			if (method == property.GetMethod)
			{
				return (property: property, kind: AccessorKind.Getter);
			}
			if (method == property.SetMethod)
			{
				return (property: property, kind: AccessorKind.Setter);
			}
		}
		return (property: null, kind: AccessorKind.None);
	}

	public static (EventDef @event, AccessorKind kind) TryGetEvent(MethodDef method)
	{
		if (method == null)
		{
			return (@event: null, kind: AccessorKind.None);
		}
		foreach (EventDef @event in method.DeclaringType.Events)
		{
			if (method == @event.AddMethod)
			{
				return (@event: @event, kind: AccessorKind.Adder);
			}
			if (method == @event.RemoveMethod)
			{
				return (@event: @event, kind: AccessorKind.Remover);
			}
		}
		return (@event: null, kind: AccessorKind.None);
	}

	public static bool IsDeprecated(IMethod method)
	{
		MethodDef methodDef = method.ResolveMethodDef();
		if (methodDef == null)
		{
			return false;
		}
		return IsDeprecated(methodDef.CustomAttributes);
	}

	public static bool IsDeprecated(IField field)
	{
		FieldDef fieldDef = field.ResolveFieldDef();
		if (fieldDef == null)
		{
			return false;
		}
		return IsDeprecated(fieldDef.CustomAttributes);
	}

	public static bool IsDeprecated(PropertyDef prop)
	{
		if (prop == null)
		{
			return false;
		}
		return IsDeprecated(prop.CustomAttributes);
	}

	public static bool IsDeprecated(EventDef evt)
	{
		if (evt == null)
		{
			return false;
		}
		return IsDeprecated(evt.CustomAttributes);
	}

	public static bool IsDeprecated(ITypeDefOrRef type)
	{
		TypeDef typeDef = type.ResolveTypeDef();
		if (typeDef == null)
		{
			return false;
		}
		bool flag = false;
		foreach (CustomAttribute customAttribute in typeDef.CustomAttributes)
		{
			if (!(customAttribute.TypeFullName != "System.ObsoleteAttribute"))
			{
				if (customAttribute.ConstructorArguments.Count != 2)
				{
					return true;
				}
				if (!(customAttribute.ConstructorArguments[0].Value is UTF8String uTF8String) || !(uTF8String == ByRefLikeMarker))
				{
					return true;
				}
				object value = customAttribute.ConstructorArguments[1].Value;
				bool num = value is bool;
				bool flag2 = num && (bool)value;
				if (!(num & flag2))
				{
					return true;
				}
				flag = true;
			}
		}
		return flag && !IsByRefLike(typeDef);
	}

	private static bool IsDeprecated(CustomAttributeCollection customAttributes)
	{
		foreach (CustomAttribute customAttribute in customAttributes)
		{
			if (customAttribute.TypeFullName == "System.ObsoleteAttribute")
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsByRefLike(TypeDef td)
	{
		foreach (CustomAttribute customAttribute in td.CustomAttributes)
		{
			if (customAttribute.TypeFullName == "System.Runtime.CompilerServices.IsByRefLikeAttribute")
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsExtension(CustomAttributeCollection customAttributes)
	{
		foreach (CustomAttribute customAttribute in customAttributes)
		{
			if (customAttribute.TypeFullName == "System.Runtime.CompilerServices.ExtensionAttribute")
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsAwaitableType(TypeSig type)
	{
		if (type == null)
		{
			return false;
		}
		TypeDef typeDef = type.Resolve();
		if (typeDef == null)
		{
			return false;
		}
		return IsAwaitableType(typeDef);
	}

	private static bool IsAwaitableType(TypeDef td)
	{
		if (td == null)
		{
			return false;
		}
		if (td.GenericParameters.Count > 1)
		{
			return false;
		}
		if (td.Namespace == stringSystem_Threading_Tasks && (td.Name == stringTask || td.Name == stringTask_1))
		{
			return true;
		}
		foreach (CustomAttribute customAttribute in td.CustomAttributes)
		{
			if (customAttribute.TypeFullName != "System.Runtime.CompilerServices.AsyncMethodBuilderAttribute" || customAttribute.ConstructorArguments.Count != 1 || (customAttribute.ConstructorArguments[0].Type as ClassSig)?.TypeDefOrRef.FullName != "System.Type")
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public static MemberSpecialFlags GetMemberSpecialFlags(IMethod method)
	{
		MemberSpecialFlags memberSpecialFlags = MemberSpecialFlags.None;
		MethodDef methodDef = method.ResolveMethodDef();
		if (methodDef != null && IsExtension(methodDef.CustomAttributes))
		{
			memberSpecialFlags |= MemberSpecialFlags.Extension;
		}
		if (IsAwaitableType(method.MethodSig.GetRetType()))
		{
			memberSpecialFlags |= MemberSpecialFlags.Awaitable;
		}
		return memberSpecialFlags;
	}

	public static MemberSpecialFlags GetMemberSpecialFlags(ITypeDefOrRef type)
	{
		MemberSpecialFlags memberSpecialFlags = MemberSpecialFlags.None;
		if (IsAwaitableType(type.ResolveTypeDef()))
		{
			memberSpecialFlags |= MemberSpecialFlags.Awaitable;
		}
		return memberSpecialFlags;
	}

	public static bool HasConstant(IHasConstant hc, out CustomAttribute constantAttribute)
	{
		constantAttribute = null;
		if (hc == null)
		{
			return false;
		}
		if (hc.Constant != null)
		{
			return true;
		}
		foreach (CustomAttribute customAttribute in hc.CustomAttributes)
		{
			for (ITypeDefOrRef typeDefOrRef = customAttribute.AttributeType; typeDefOrRef != null; typeDefOrRef = typeDefOrRef.GetBaseType())
			{
				string fullName = typeDefOrRef.FullName;
				if (fullName == "System.Runtime.CompilerServices.CustomConstantAttribute" || fullName == "System.Runtime.CompilerServices.DecimalConstantAttribute")
				{
					constantAttribute = customAttribute;
					return true;
				}
			}
		}
		return false;
	}

	public static bool TryGetConstant(IHasConstant hc, CustomAttribute constantAttribute, out object constant)
	{
		if (hc.Constant != null)
		{
			constant = hc.Constant.Value;
			return true;
		}
		if (constantAttribute != null && constantAttribute.TypeFullName == "System.Runtime.CompilerServices.DecimalConstantAttribute" && TryGetDecimalConstantAttributeValue(constantAttribute, out var value))
		{
			constant = value;
			return true;
		}
		constant = null;
		return false;
	}

	private static bool TryGetDecimalConstantAttributeValue(CustomAttribute ca, out decimal value)
	{
		value = 0m;
		if (ca.ConstructorArguments.Count != 5)
		{
			return false;
		}
		object value2 = ca.ConstructorArguments[0].Value;
		bool num = value2 is byte;
		byte scale = (byte)(num ? ((byte)value2) : 0);
		if (!num)
		{
			return false;
		}
		value2 = ca.ConstructorArguments[1].Value;
		bool num2 = value2 is byte;
		byte b = (byte)(num2 ? ((byte)value2) : 0);
		if (!num2)
		{
			return false;
		}
		int hi;
		int mid;
		int lo;
		if (ca.ConstructorArguments[2].Value is int)
		{
			if (!(ca.ConstructorArguments[2].Value is int))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[3].Value is int))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[4].Value is int))
			{
				return false;
			}
			hi = (int)ca.ConstructorArguments[2].Value;
			mid = (int)ca.ConstructorArguments[3].Value;
			lo = (int)ca.ConstructorArguments[4].Value;
		}
		else
		{
			if (!(ca.ConstructorArguments[2].Value is uint))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[2].Value is uint))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[3].Value is uint))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[4].Value is uint))
			{
				return false;
			}
			hi = (int)(uint)ca.ConstructorArguments[2].Value;
			mid = (int)(uint)ca.ConstructorArguments[3].Value;
			lo = (int)(uint)ca.ConstructorArguments[4].Value;
		}
		try
		{
			value = new decimal(lo, mid, hi, b > 0, scale);
			return true;
		}
		catch (ArgumentOutOfRangeException)
		{
			return false;
		}
	}

	public static bool IsReadOnlyProperty(PropertyDef property)
	{
		return HasIsReadOnlyAttribute(property.CustomAttributes);
	}

	public static bool IsReadOnlyMethod(MethodDef method)
	{
		if (method == null || method.IsConstructor)
		{
			return false;
		}
		return HasIsReadOnlyAttribute(method.Parameters.ReturnParameter.ParamDef?.CustomAttributes);
	}

	public static bool IsReadOnlyParameter(ParamDef pd)
	{
		return HasIsReadOnlyAttribute(pd?.CustomAttributes);
	}

	public static bool IsReadOnlyType(TypeDef td)
	{
		return HasIsReadOnlyAttribute(td?.CustomAttributes);
	}

	private static bool HasIsReadOnlyAttribute(CustomAttributeCollection customAttributes)
	{
		if (customAttributes == null)
		{
			return false;
		}
		for (int i = 0; i < customAttributes.Count; i++)
		{
			CustomAttribute customAttribute = customAttributes[i];
			if (customAttribute.AttributeType?.FullName == "System.Runtime.CompilerServices.IsReadOnlyAttribute" && customAttribute.AttributeType.DeclaringType == null)
			{
				return true;
			}
		}
		return false;
	}
}
