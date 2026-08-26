using System;
using System.IO;
using System.Reflection;

namespace ImageMagick;

internal static class TypeHelper
{
	public static T GetCustomAttribute<T>(Type type) where T : Attribute
	{
		return (T)type.Assembly.GetCustomAttributes(typeof(T), inherit: false)[0];
	}

	public static T[] GetCustomAttributes<T>(Enum value) where T : Attribute
	{
		FieldInfo field = value.GetType().GetField(value.ToString());
		if (field == null)
		{
			return null;
		}
		return (T[])field.GetCustomAttributes(typeof(T), inherit: false);
	}

	public static Type[] GetGenericArguments(Type type)
	{
		return type.GetGenericArguments();
	}

	public static Stream GetManifestResourceStream(Type type, string resourcePath, string resourceName)
	{
		return type.Assembly.GetManifestResourceStream(resourcePath + "." + resourceName);
	}

	public static bool IsEnum(Type type)
	{
		return type.IsEnum;
	}

	public static bool IsGeneric(Type type)
	{
		return type.IsGenericType;
	}

	public static bool IsNullable(Type type)
	{
		return type.GetGenericTypeDefinition() == typeof(Nullable<>);
	}

	public static bool IsValueType(Type type)
	{
		return type.IsValueType;
	}
}
