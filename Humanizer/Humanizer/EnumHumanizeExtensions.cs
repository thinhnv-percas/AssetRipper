using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Humanizer.Configuration;

namespace Humanizer;

public static class EnumHumanizeExtensions
{
	private const string DisplayAttributeTypeName = "System.ComponentModel.DataAnnotations.DisplayAttribute";

	private const string DisplayAttributeGetDescriptionMethodName = "GetDescription";

	private const string DisplayAttributeGetNameMethodName = "GetName";

	private static readonly Func<PropertyInfo, bool> StringTypedProperty = (PropertyInfo p) => (object)p.PropertyType == typeof(string);

	public static string Humanize(this Enum input)
	{
		Type type = input.GetType();
		TypeInfo typeInfo = type.GetTypeInfo();
		if (IsBitFieldEnum(typeInfo) && !Enum.IsDefined(type, input))
		{
			return Enumerable.Select<Enum, string>(Enumerable.Where<Enum>(Enumerable.Cast<Enum>((IEnumerable)Enum.GetValues(type)), (Func<Enum, bool>)((Enum e) => input.HasFlag(e))), (Func<Enum, string>)((Enum e) => e.Humanize())).Humanize();
		}
		string text = input.ToString();
		FieldInfo declaredField = typeInfo.GetDeclaredField(text);
		if ((object)declaredField != null)
		{
			string customDescription = GetCustomDescription(declaredField);
			if (customDescription != null)
			{
				return customDescription;
			}
		}
		return text.Humanize();
	}

	private static bool IsBitFieldEnum(TypeInfo typeInfo)
	{
		return typeInfo.GetCustomAttribute(typeof(FlagsAttribute)) != null;
	}

	private static string GetCustomDescription(MemberInfo memberInfo)
	{
		foreach (Attribute customAttribute in CustomAttributeExtensions.GetCustomAttributes(memberInfo, inherit: true))
		{
			Type type = customAttribute.GetType();
			if (type.FullName == "System.ComponentModel.DataAnnotations.DisplayAttribute")
			{
				MethodInfo runtimeMethod = type.GetRuntimeMethod("GetDescription", new Type[0]);
				if ((object)runtimeMethod != null)
				{
					object obj = runtimeMethod.Invoke(customAttribute, new object[0]);
					if (obj != null)
					{
						return obj.ToString();
					}
				}
				MethodInfo runtimeMethod2 = type.GetRuntimeMethod("GetName", new Type[0]);
				if ((object)runtimeMethod2 != null)
				{
					object obj2 = runtimeMethod2.Invoke(customAttribute, new object[0]);
					if (obj2 != null)
					{
						return obj2.ToString();
					}
				}
				return null;
			}
			PropertyInfo propertyInfo = Enumerable.FirstOrDefault<PropertyInfo>(Enumerable.Where<PropertyInfo>(type.GetRuntimeProperties(), StringTypedProperty), Configurator.EnumDescriptionPropertyLocator);
			if ((object)propertyInfo != null)
			{
				return propertyInfo.GetValue(customAttribute, null).ToString();
			}
		}
		return null;
	}

	public static string Humanize(this Enum input, LetterCasing casing)
	{
		return input.Humanize().ApplyCase(casing);
	}
}
