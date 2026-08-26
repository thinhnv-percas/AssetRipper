using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils;

internal class ReflectionHelper
{
	public static SetPropertyDelegate GetPropertySetter(PropertyInfo prop)
	{
		MethodInfo setter = prop.GetSetMethod(nonPublic: true);
		if (setter != null)
		{
			return delegate(object obj, object value)
			{
				setter.Invoke(obj, new object[1] { value });
			};
		}
		string name = $"<{prop.Name}>k__BackingField";
		FieldInfo backingField = prop.DeclaringType.GetTypeInfo().GetDeclaredField(name);
		if (backingField == null)
		{
			throw new InvalidOperationException("Could not find a way to set " + prop.DeclaringType.FullName + "." + prop.Name);
		}
		return delegate(object obj, object value)
		{
			backingField.SetValue(obj, value);
		};
	}

	public static MethodInfo[] GetPropertyOrMethod(Type type, string name)
	{
		return (from m in (from m in type.GetTypeInfo().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				where m.Name == name
				select m).Concat(from p in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				where p.Name == name
				select p.GetMethod)
			where m.ReturnType == typeof(string) && m.GetParameters().Length == 0
			select m).ToArray();
	}

	public static PropertyInfo[] GetProperties(Type type)
	{
		return type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
	}

	public static MemberInfo[] GetMembers(Type type)
	{
		return type.GetTypeInfo().GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
	}

	public static object[] BindParameters(MethodInfo method, CommandLineApplication command)
	{
		ParameterInfo[] parameters = method.GetParameters();
		object[] array = new object[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			if (typeof(CommandLineApplication).GetTypeInfo().IsAssignableFrom(parameterInfo.ParameterType))
			{
				array[i] = command;
				continue;
			}
			if (typeof(IConsole).GetTypeInfo().IsAssignableFrom(parameterInfo.ParameterType))
			{
				array[i] = command._context.Console;
				continue;
			}
			if (typeof(ValidationResult).GetTypeInfo().IsAssignableFrom(parameterInfo.ParameterType))
			{
				array[i] = command.GetValidationResult();
				continue;
			}
			if (typeof(CommandLineContext).GetTypeInfo().IsAssignableFrom(parameterInfo.ParameterType))
			{
				array[i] = command._context;
				continue;
			}
			array[i] = command.AdditionalServices?.GetService(parameterInfo.ParameterType);
			if (array[i] == null)
			{
				throw new InvalidOperationException(Strings.UnsupportedParameterTypeOnMethod(method.Name, parameterInfo));
			}
		}
		return array;
	}

	public static bool IsNullableType(TypeInfo typeInfo, out Type wrappedType)
	{
		bool flag = typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>);
		wrappedType = (flag ? typeInfo.GetGenericArguments().First() : null);
		return flag;
	}
}
