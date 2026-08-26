using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Internal;

internal static class AttributeServices
{
	public static IEnumerable<T> GetAttributes<T>(this MemberInfo memberInfo) where T : Attribute
	{
		return memberInfo.GetCustomAttributes<T>(inherit: false);
	}

	public static IEnumerable<T> GetAttributes<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
	{
		return memberInfo.GetCustomAttributes<T>(inherit);
	}

	public static T GetFirstAttribute<T>(this MemberInfo memberInfo) where T : Attribute
	{
		return memberInfo.GetAttributes<T>().FirstOrDefault();
	}

	public static T GetFirstAttribute<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
	{
		return memberInfo.GetAttributes<T>(inherit).FirstOrDefault();
	}

	public static bool IsAttributeDefined<T>(this MemberInfo memberInfo) where T : Attribute
	{
		return CustomAttributeExtensions.IsDefined(memberInfo, typeof(T), inherit: false);
	}

	public static bool IsAttributeDefined<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
	{
		return CustomAttributeExtensions.IsDefined(memberInfo, typeof(T), inherit);
	}

	public static IEnumerable<T> GetAttributes<T>(this ParameterInfo parameterInfo) where T : Attribute
	{
		return parameterInfo.GetCustomAttributes<T>(inherit: false);
	}

	public static IEnumerable<T> GetAttributes<T>(this ParameterInfo parameterInfo, bool inherit) where T : Attribute
	{
		return parameterInfo.GetCustomAttributes<T>(inherit);
	}

	public static T GetFirstAttribute<T>(this ParameterInfo parameterInfo) where T : Attribute
	{
		return parameterInfo.GetAttributes<T>().FirstOrDefault();
	}

	public static T GetFirstAttribute<T>(this ParameterInfo parameterInfo, bool inherit) where T : Attribute
	{
		return parameterInfo.GetAttributes<T>(inherit).FirstOrDefault();
	}

	public static bool IsAttributeDefined<T>(this ParameterInfo parameterInfo) where T : Attribute
	{
		return CustomAttributeExtensions.IsDefined(parameterInfo, typeof(T), inherit: false);
	}

	public static bool IsAttributeDefined<T>(this ParameterInfo parameterInfo, bool inherit) where T : Attribute
	{
		return CustomAttributeExtensions.IsDefined(parameterInfo, typeof(T), inherit);
	}
}
